using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class ProgramareManager
    {
        private string CaleFisier => FilePaths.GetFilePath("programari.json");
        public List<Programare> ListaProgramari { get; set; }
        private AbonatManager abonatManager; // Manager pentru gestionarea abonatilor

        public ProgramareManager(AbonatManager abonatManager)
        {
            this.abonatManager = abonatManager;

            var incarcate = JSONHelper.LoadFromFile<List<Programare>>(CaleFisier);
            if (incarcate != null)
            {
                ListaProgramari = incarcate;
            }
            else
            {
                ListaProgramari = new List<Programare>();
            }
        }

        private AbonatStandard GasesteAbonatDupaUsername(string username)
        {
            // Cautare în abonati standard
            var abonatStandard = abonatManager.AbonatiStandard.FirstOrDefault(a => a.Username == username);
            if (abonatStandard != null)
            {
                return abonatStandard;
            }

            // Cautare în abonati premium
            var abonatPremium = abonatManager.AbonatiPremium.FirstOrDefault(a => a.Username == username);
            if (abonatPremium != null)
            {
                // Transformam abonatul premium intr-unul standard pentru procesare uniforma
                return new AbonatStandard(
                    abonatPremium.NumeComplet,
                    abonatPremium.CNP,
                    abonatPremium.Username,
                    abonatPremium.Password
                );
            }

            return null; // Nu a fost gasit abonatul
        }

        private void ActualizeazaFisierJSON()
        {
            JSONHelper.SaveToFile(CaleFisier, ListaProgramari);
        }

        public void AdaugaProgramare(Programare programare)
        {
            var abonatStandard = abonatManager.AbonatiStandard.FirstOrDefault(a => a.Username == programare.AbonatUsername);
            var abonatPremium = abonatManager.AbonatiPremium.FirstOrDefault(a => a.Username == programare.AbonatUsername);

            if (abonatStandard == null && abonatPremium == null)
            {
                MessageBox.Show(
                    "Abonatul specificat nu a fost gasit.",
                    "Eroare",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (ListaProgramari.Contains(programare))
            {
                MessageBox.Show(
                    "Aceasta programare exista deja in sistem.",
                    "Eroare",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            ListaProgramari.Add(programare);
            ActualizeazaFisierJSON();

            if (abonatStandard != null)
            {
                abonatStandard.IstoricProgramari.Add(programare);
                abonatManager.ActualizeazaAbonati(abonatManager.AbonatiStandard, abonatManager.AbonatiPremium);
            }
            else if (abonatPremium != null)
            {
                abonatPremium.IstoricProgramari.Add(programare);
                abonatManager.ActualizeazaAbonati(abonatManager.AbonatiStandard, abonatManager.AbonatiPremium);
            }
        }

        public void ModificaProgramare(string username, int index, Programare programareNoua)
        {
            var programariAbonat = ListaProgramari.Where(p => p.AbonatUsername == username).ToList();
            if (index >= 0 && index < programariAbonat.Count)
            {
                var programareExistenta = programariAbonat[index];
                ListaProgramari.Remove(programareExistenta);
                ListaProgramari.Add(programareNoua);
                ActualizeazaFisierJSON();

                var abonatStandard = abonatManager.AbonatiStandard.FirstOrDefault(a => a.Username == username);
                var abonatPremium = abonatManager.AbonatiPremium.FirstOrDefault(a => a.Username == username);

                if (abonatStandard != null)
                {
                    abonatStandard.IstoricProgramari.RemoveAll(p =>
                        p.AbonatUsername == programareExistenta.AbonatUsername &&
                        p.Data == programareExistenta.Data);
                    abonatStandard.IstoricProgramari.Add(programareNoua);
                }
                else if (abonatPremium != null)
                {
                    abonatPremium.IstoricProgramari.RemoveAll(p =>
                        p.AbonatUsername == programareExistenta.AbonatUsername &&
                        p.Data == programareExistenta.Data);
                    abonatPremium.IstoricProgramari.Add(programareNoua);
                }

                abonatManager.ActualizeazaAbonati(abonatManager.AbonatiStandard, abonatManager.AbonatiPremium);
            }
            else
            {
                MessageBox.Show(
                    "Index invalid pentru programare.",
                    "Eroare",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public bool AnuleazaProgramare(string username, int index)
        {
            var programariAbonat = ListaProgramari.Where(p => p.AbonatUsername == username).ToList();
            if (index >= 0 && index < programariAbonat.Count)
            {
                var programareDeAnulat = programariAbonat[index];
                ListaProgramari.Remove(programareDeAnulat);
                ActualizeazaFisierJSON();

                var abonatStandard = abonatManager.AbonatiStandard.FirstOrDefault(a => a.Username == username);
                var abonatPremium = abonatManager.AbonatiPremium.FirstOrDefault(a => a.Username == username);

                if (abonatStandard != null)
                {
                    abonatStandard.IstoricProgramari.RemoveAll(p =>
                        p.AbonatUsername == programareDeAnulat.AbonatUsername &&
                        p.Data == programareDeAnulat.Data);
                }
                else if (abonatPremium != null)
                {
                    abonatPremium.IstoricProgramari.RemoveAll(p =>
                        p.AbonatUsername == programareDeAnulat.AbonatUsername &&
                        p.Data == programareDeAnulat.Data);
                }

                abonatManager.ActualizeazaAbonati(abonatManager.AbonatiStandard, abonatManager.AbonatiPremium);

                return (programareDeAnulat.Data - DateTime.Now).TotalHours < 24;
            }
            else
            {
                MessageBox.Show(
                    "Index invalid pentru anulare programare.",
                    "Eroare",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            return false;
        }


        public void ListeazaProgramariDupaNumeAntrenor()
        {
            var programariOrdonate = ListaProgramari
                .OrderBy(p => p.Antrenor.NumeComplet)
                .ToList();

            foreach (var programare in programariOrdonate)
            {
                Console.WriteLine($"Antrenor: {programare.Antrenor.NumeComplet}, Abonat: {programare.AbonatUsername}, Data: {programare.Data}, Durata: {programare.DurataProgramataOre} ore");
            }
        }

        public void ListeazaProgramariDupaDurata()
        {
            var programariOrdonate = ListaProgramari
                .OrderBy(p => p.DurataProgramataOre)
                .ToList();

            foreach (var programare in programariOrdonate)
            {
                Console.WriteLine($"Durata: {programare.DurataProgramataOre} ore, Antrenor: {programare.Antrenor.NumeComplet}, Abonat: {programare.AbonatUsername}, Data: {programare.Data}");
            }
        }
    }
}
