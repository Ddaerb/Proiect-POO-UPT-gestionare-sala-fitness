using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{

    public class AbonatManager
    {
        public string standardFilePath => FilePaths.GetFilePath("AbonatiStandard.json"); // Locatia fisierului JSON
        public List<AbonatStandard> AbonatiStandard { get; private set; } = new List<AbonatStandard>();

        public string premiumFilePath => FilePaths.GetFilePath("AbonatiPremium.json");
        public List<AbonatPremium> AbonatiPremium { get; private set; } = new List<AbonatPremium>();


        public AbonatManager()
        {
            // Incarcam lista din fisier la initializare

            //Pentru abonati standard
            var listaDinFisierStandard = JSONHelper.LoadFromFile<List<AbonatStandard>>(standardFilePath);
            if (listaDinFisierStandard != null)
            {
                AbonatiStandard = listaDinFisierStandard;
            }
            else
            {
                AbonatiStandard = new List<AbonatStandard>();
            }

            //Pentru abonati premium
            var listaDinFisierPremium = JSONHelper.LoadFromFile<List<AbonatPremium>>(premiumFilePath);
            if (listaDinFisierPremium != null)
            {
                AbonatiPremium = listaDinFisierPremium;
            }
            else
            {
                AbonatiPremium = new List<AbonatPremium>();
            }
        }

        //Reseteaza datele 
        public void ReseteazaDate()
        {
            // Goleste listele
            AbonatiStandard.Clear();
            AbonatiPremium.Clear();

            // Salveaza liste goale in fisierele JSON
            JSONHelper.SaveToFile(standardFilePath, AbonatiStandard);
            JSONHelper.SaveToFile(premiumFilePath, AbonatiPremium);

            Console.WriteLine("Datele au fost resetate.");
        }

        //Metoda pentru stergerea unui abonat standard
        public void StergeAbonatStandard(int index)
        {
            if (index >= 0 && index < AbonatiStandard.Count)
            {
                var abonatDeSters = AbonatiStandard[index];
                AbonatiStandard.RemoveAt(index);
                JSONHelper.SaveToFile(standardFilePath, AbonatiStandard);
                MessageBox.Show($"Abonatul standard '{abonatDeSters.NumeComplet}' a fost sters cu succes.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Index invalid pentru lista de abonati standard.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Metoda pentru stergerea unui abonat premium
        public void StergeAbonatPremium(int index)
        {
            if (index >= 0 && index < AbonatiPremium.Count)
            {
                var abonatDeSters = AbonatiPremium[index];
                AbonatiPremium.RemoveAt(index);
                JSONHelper.SaveToFile(premiumFilePath, AbonatiPremium);
                MessageBox.Show($"Abonatul premium '{abonatDeSters.NumeComplet}' a fost sters cu succes.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Index invalid pentru lista de abonati premium.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Adauga un nou abonat standard si actualizeaza fisierul JSON
        public void AdaugaAbonatStandard(AbonatStandard abonatStd, string username)
        {
            //Verificam daca abonatul pe care dorim sa-l adaugam se afla deja in una dintre liste
            var abonatStandard = AbonatiStandard.FirstOrDefault(a => a.Username == username);
            var abonatPremium = AbonatiPremium.FirstOrDefault(a => a.Username == username);
            if (abonatStandard == null && abonatPremium == null)
            {
                AbonatiStandard.Add(abonatStd);
                JSONHelper.SaveToFile(standardFilePath, AbonatiStandard);
            }
            else
            {
                MessageBox.Show
                (
                "Aveti deja cont. Va rugam sa va autentificati.",
                "Eroare",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
            }
        }

        // Adauga un nou abonat premium si actualizeaza fisierul JSON
        public void AdaugaAbonatPremium(AbonatPremium abonatPrem, string username)
        {
            //Verificam daca abonatul pe care dorim sa-l adaugam se afla deja in una dintre liste
            var abonatPremium = AbonatiPremium.FirstOrDefault(a => a.Username == username);
            var abonatStandard = AbonatiStandard.FirstOrDefault(a => a.Username == username);
            if (abonatPremium == null && abonatStandard == null)
            {
                AbonatiPremium.Add(abonatPrem);
                JSONHelper.SaveToFile(premiumFilePath, AbonatiPremium);
            }
            else
            {
                MessageBox.Show
                (
                "Aveti deja cont. Va rugam sa va autentificati.",
                "Eroare",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
            }
        }

        // Metoda pentru retrogradarea unui abonat
        public void RetrogradeazaAbonatPremium(string cnp)
        {
            var abonatPremium = AbonatiPremium.FirstOrDefault(a => a.CNP == cnp);
            if (abonatPremium != null)
            {
                // Cream un nou abonat standard pastrand toate informatiile
                var abonatStandard = new AbonatStandard(
                    abonatPremium.NumeComplet,
                    abonatPremium.CNP,
                    abonatPremium.Username,
                    abonatPremium.Password);
                abonatStandard.IstoricProgramari = abonatPremium.IstoricProgramari;

                AbonatiPremium.Remove(abonatPremium);
                AbonatiStandard.Add(abonatStandard);

                JSONHelper.SaveToFile(standardFilePath, AbonatiStandard);
                JSONHelper.SaveToFile(premiumFilePath, AbonatiPremium);
            }
            else
            {
                MessageBox.Show
                (
                "Abonatul premium nu a fost gasit.",
                "Eroare",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
            }
        }

        //Metoda pentru promovarea unui abonat
        public void PromoveazaAbonatStandard(string cnp)
        {
            var abonatStandard = AbonatiStandard.FirstOrDefault(a => a.CNP == cnp);
            if (abonatStandard != null)
            {
                var abonatPremium = new AbonatPremium(
                    abonatStandard.NumeComplet,
                    abonatStandard.CNP,
                    abonatStandard.Username,
                    abonatStandard.Password);
                abonatPremium.IstoricProgramari = abonatStandard.IstoricProgramari;
                AbonatiStandard.Remove(abonatStandard);
                AbonatiPremium.Add(abonatPremium);

                JSONHelper.SaveToFile(premiumFilePath, AbonatiPremium);
                JSONHelper.SaveToFile(standardFilePath, AbonatiStandard);

            }
            else
            {
                MessageBox.Show
                (
                "Abonatul standard nu a fost gasit.",
                "Eroare",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
            }
        }

        //Metoda pentru listarea tuturor abonatilor
        public void ListeazaAbonati()
        {
            Console.WriteLine("Lista tuturor abonatilor: ");
            foreach (var abonat in AbonatiStandard)
            {
                Console.WriteLine($"Nume: {abonat.NumeComplet}, CNP: {abonat.CNP}, Tip: {abonat.TipAbonament}, Pret: {abonat.PretAbonament}");
            }
            foreach (var abonat in AbonatiPremium)
            {
                Console.WriteLine($"Nume: {abonat.NumeComplet}, CNP: {abonat.CNP}, Tip: {abonat.TipAbonament}, Pret: {abonat.PretAbonament}");
            }
        }

        //Metoda pentru schimbarea parolei unui abonat
        public void SchimbareParola(string username, string parolaVeche, string parolaNoua)
        {
            //Cautam abonatul dupa username in lista de abonati standard
            var abonatStandard = AbonatiStandard.FirstOrDefault(a => a.Username == username);
            if (abonatStandard != null)
            {
                if (abonatStandard.Password == parolaVeche)
                {
                    abonatStandard.Password = parolaNoua;
                    MessageBox.Show
                    (
                    "Parola a fost schimbata cu succes.",
                    "Parola schimbata",
                    MessageBoxButtons.OK
                    );
                    JSONHelper.SaveToFile(standardFilePath, AbonatiStandard);
                }
                else
                {
                    MessageBox.Show
                    (
                    "Parola nu poate fi schimbata.",
                    "Eroare",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                }
                return; // Iesim din metoda daca gasim abonatul
            }


            //Cautam abonatul in lista de abonati premium
            var abonatPremium = AbonatiPremium.FirstOrDefault(a => a.Username == username);
            if (abonatPremium != null)
            {
                if (abonatPremium.Password == parolaVeche)
                {
                    abonatPremium.Password = parolaNoua;
                    MessageBox.Show
                    (
                    "Parola a fost schimbata cu succes.",
                    "Parola schimbata",
                    MessageBoxButtons.OK
                    );
                    JSONHelper.SaveToFile(premiumFilePath, AbonatiPremium);
                }
                else
                {
                    MessageBox.Show
                    (
                    "Parola nu poate fi schimbata.",
                    "Eroare",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                }


                // Iesim din metoda daca gasim abonatul
                return;

            }
        }

        public AbonatStandard GasesteAbonatDupaUsername(string username)
        {
            // Cautam in lista de abonati standard
            var abonatStandard = AbonatiStandard.FirstOrDefault(a => a.Username == username);
            if (abonatStandard != null)
            {
                return abonatStandard; // Returnnam userul standard gasit
            }

            // Cautam in lista de abonati premium
            var abonatPremium = AbonatiPremium.FirstOrDefault(a => a.Username == username);
            if (abonatPremium != null)
            {
                return abonatPremium; // Returnam userul premium gasit
            }

            return null; //Nu s-a gasit
        }

        public void ActualizeazaAbonati(List<AbonatStandard> liststd,List<AbonatPremium> listprm)
        {
            JSONHelper.SaveToFile(standardFilePath, liststd);
            JSONHelper.SaveToFile(premiumFilePath, listprm);
        }

        }
}