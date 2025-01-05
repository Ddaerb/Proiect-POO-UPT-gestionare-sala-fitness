using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public class ProgramareManager
    {
        private string CaleFisier => FilePaths.GetFilePath("programari.json");
        private string CaleFisierAbonatiStandard => FilePaths.GetFilePath("AbonatiStandard.json");
        private string CaleFisierAbonatiPremium => FilePaths.GetFilePath("Abonati.json");
        public List<Programare> ListaProgramari { get; set; }
        private AbonatManager abonatManager { get; set; } // Manager pentru gestionarea abonatilor

        public ProgramareManager()
        {
            var incarcate = JSONHelper.LoadFromFile<List<Programare>>(CaleFisier);
            if (incarcate != null)
            {
                ListaProgramari = incarcate;
            }
            else
            {
                ListaProgramari = new List<Programare>();
            }

            abonatManager = new AbonatManager(); // Initializare manager abonati
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

        public void AdaugaProgramare(Programare programare, AbonatStandard abonatStandard)
        {
            if (abonatStandard == null)
            {
                MessageBox.Show
                (
                "Nu s-a gasit acest abonat.",
                "Eroare",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
                return;
            }

            if (programare.AbonatUsername != abonatStandard.Username)
            {
                MessageBox.Show
                (
                "Abonatul specificat nu corespunde cu utilizatorul gasit.",
                "Eroare",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
                return;
            }

            if (ListaProgramari.Contains(programare))
            {
                MessageBox.Show
                (
                "Aceasta programare exista deja in sistem.",
                "Eroare",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
                return;
            }

            ListaProgramari.Add(programare);

            if (!abonatStandard.IstoricProgramari.Contains(programare))
            {
                abonatManager = new AbonatManager();
                if(abonatStandard.TipAbonament=="standard")
                {
                    foreach(var abonat in abonatManager.AbonatiStandard)
                    {
                        if(abonat.Username==abonatStandard.Username)
                        {
                            abonat.IstoricProgramari.Add (programare);
                            abonatManager.ActualizeazaAbonati();
                        }
                    }
                }
                else if (abonatStandard.TipAbonament=="premium")
                {
                    foreach (var abonat in abonatManager.AbonatiPremium)
                    {
                        if (abonat.Username == abonatStandard.Username)
                        {
                            abonat.IstoricProgramari.Add(programare);
                            abonatManager.ActualizeazaAbonati();
                        }
                    }
                }
                //abonatStandard.IstoricProgramari.Add(programare);
            }

            ActualizeazaFisierJSON();
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
            }
            else
            {
                MessageBox.Show
                (
                "Index invalid pentru programare.",
                "Eroare",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
            }
        }

        public bool AnuleazaProgramare(string username, int index, AbonatStandard abonatStandard)
        {
            var programariAbonat = ListaProgramari.Where(p => p.AbonatUsername == username).ToList();
            if (index >= 0 && index < programariAbonat.Count)
            {
                var programareDeAnulat = programariAbonat[index];
                if (programareDeAnulat.AbonatUsername != abonatStandard.Username)
                {
                    MessageBox.Show
                    (
                    "Username-ul nu corespunde cu utilizatorul gasit.",
                    "Eroare",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                    return false;
                }
                else
                {
                    ListaProgramari.Remove(programareDeAnulat);
                    ActualizeazaFisierJSON();
                    if ((programareDeAnulat.Data - DateTime.Now).TotalHours < 24)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                MessageBox.Show
                (
                "Index invalid pentru anulare programare.",
                "Eroare",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
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

