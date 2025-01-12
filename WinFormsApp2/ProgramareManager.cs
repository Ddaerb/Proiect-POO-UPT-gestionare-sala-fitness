using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public class ProgramareManager
    {
        private string CaleFisier => FilePaths.GetFilePath("programari.json");
        public List<Programare> ListaProgramari { get; set; }
        private AbonatManager abonatManager;// Manager pentru gestionarea abonatilor
        private SalaFitness salaFitness;// Sala de fitness pentru care se fac programarile

        public ProgramareManager(AbonatManager abonatManager, SalaFitness salafitness)
        {
            this.abonatManager = abonatManager;
            this.salaFitness = salafitness;

            var incarcate = JSONHelper.LoadFromFile<List<Programare>>(CaleFisier);
            if (incarcate != null)
            {
                ListaProgramari = incarcate;
            }
            else
            {
                ListaProgramari = new List<Programare>();
            }

            this.salaFitness = salaFitness;
        }

        private void RecalcularePretAbonament(AbonatStandard abonat, bool status, Programare programare)
        {
            if (programare.StatusProgramare == "anulata.")
            {
                if (status)
                {
                    abonat.PretAbonament += 10;
                }
                return;
            }

            if (programare.StatusProgramare == "modificata." && status)
            {
                abonat.PretAbonament += 10;
            }

            double oreDepasite = CalculareOreDepasite(programare, salaFitness);

            if (oreDepasite > 0)
            {
                int costOra = 0;

                if (abonat.TipAbonament == "standard")
                {
                    costOra = 5;
                }
                else if (abonat.TipAbonament == "premium")
                {
                    costOra = 2;
                }
                else
                {
                    costOra = 0;
                }

                abonat.PretAbonament += (int)Math.Ceiling(oreDepasite) * costOra;
            }
        }

        private double CalculareOreDepasite(Programare programare, SalaFitness salaFitness)
        {
            DateTime interval1start = programare.Data;
            DateTime interval1end = programare.Data.AddHours(programare.DurataProgramataOre);

            DateTime interval2start = programare.Data.Date.Add(salaFitness.OraInceput);
            DateTime interval2end = programare.Data.Date.Add(salaFitness.OraSfarsit);

            double oreDepasite = 0;

            if (interval1start < interval2start)
            {
                oreDepasite += (interval2start - interval1start).TotalHours;
            }

            if (interval1end > interval2end)
            {
                oreDepasite += (interval1end - interval2end).TotalHours;
            }

            return oreDepasite;
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
                RecalcularePretAbonament(abonatStandard, false, programare);

                abonatStandard.IstoricProgramari.Add(programare);
                abonatManager.ActualizeazaAbonati(abonatManager.AbonatiStandard, abonatManager.AbonatiPremium);
            }
            else if (abonatPremium != null)
            {
                RecalcularePretAbonament(abonatPremium, false, programare);

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
                programareNoua.StatusProgramare = "modificata.";
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

                    var status = (programareNoua.Data - DateTime.Now).TotalHours < 24;
                    RecalcularePretAbonament(abonatStandard, status, programareNoua);
                }
                else if (abonatPremium != null)
                {
                    abonatPremium.IstoricProgramari.RemoveAll(p =>
                        p.AbonatUsername == programareExistenta.AbonatUsername &&
                        p.Data == programareExistenta.Data);
                    abonatPremium.IstoricProgramari.Add(programareNoua);

                    var status = (programareNoua.Data - DateTime.Now).TotalHours < 24;
                    RecalcularePretAbonament(abonatPremium, status, programareNoua);
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

        public void AnuleazaProgramare(string username, int index)
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
                    var programareDinIstoric = abonatStandard.IstoricProgramari.FirstOrDefault(p => p.AbonatUsername == programareDeAnulat.AbonatUsername && p.Data == programareDeAnulat.Data);

                    if (programareDinIstoric != null)
                    {
                        programareDinIstoric.StatusProgramare = "anulata.";
                    }

                    var status = (programareDeAnulat.Data - DateTime.Now).TotalHours < 24;
                    RecalcularePretAbonament(abonatStandard, status, programareDeAnulat);
                }
                else if (abonatPremium != null)
                {
                    var programareDinIstoric = abonatPremium.IstoricProgramari.FirstOrDefault(p => p.AbonatUsername == programareDeAnulat.AbonatUsername && p.Data == programareDeAnulat.Data);

                    if (programareDinIstoric != null)
                    {
                        programareDinIstoric.StatusProgramare = "anulata.";
                    }

                    var status = (programareDeAnulat.Data - DateTime.Now).TotalHours < 24;
                    RecalcularePretAbonament(abonatPremium, status, programareDeAnulat);
                }

                abonatManager.ActualizeazaAbonati(abonatManager.AbonatiStandard, abonatManager.AbonatiPremium);
            }
            else
            {
                MessageBox.Show(
                    "Index invalid pentru anulare programare.",
                    "Eroare",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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
