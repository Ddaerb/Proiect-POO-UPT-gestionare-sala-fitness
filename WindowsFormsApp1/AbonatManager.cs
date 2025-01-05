namespace WindowsFormsApp1
{

    public class AbonatManager
    {
        public const string standardFilePath = "AbonatiStandard.json"; // Locatia fisierului JSON
        public List<AbonatStandard> AbonatiStandard { get; private set; } = new List<AbonatStandard>();

        public const string premiumFilePath = "AbonatiPremium.json";
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

                AbonatiPremium.Remove(abonatPremium);
                AbonatiStandard.Add(abonatStandard);

                JSONHelper.SaveToFile(standardFilePath, AbonatiStandard);
                JSONHelper.SaveToFile(premiumFilePath, AbonatiPremium);
            }
            else
            {
                Console.WriteLine("Abonatul premium nu a fost gasit.");
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

                AbonatiStandard.Remove(abonatStandard);
                AbonatiPremium.Add(abonatPremium);

                JSONHelper.SaveToFile(premiumFilePath, AbonatiPremium);
                JSONHelper.SaveToFile(standardFilePath, AbonatiStandard);

            }
            else
            {
                Console.WriteLine("Abonatul standard nu a fost gasit.");
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
                    Console.WriteLine("Parola a fost schimbata cu succes");
                    JSONHelper.SaveToFile(standardFilePath, AbonatiStandard);
                }
                else
                {
                    Console.WriteLine("Parola nu poate fi schimbata");
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
                    Console.WriteLine("Parola a fost schimbata cu succes");
                    JSONHelper.SaveToFile(premiumFilePath, AbonatiPremium);
                }
                else
                {
                    Console.WriteLine("Parola nu poate fi schimbata");
                }


                // Iesim din metoda daca gasim abonatul
                return;

            }
        }



        //Metoda care recalculeaza pretul abonamentului in functie de programarile anulate
        public void RecalcularePret(string username, bool programareAnulata)
        {
            var abonatStandard = AbonatiStandard.FirstOrDefault(a => a.Username == username);
            var abonatPremium = AbonatiPremium.FirstOrDefault(a => a.Username == username);
            if (abonatStandard == null && abonatPremium == null)
            {
                Console.WriteLine("Abonatul specificat nu a fost gasit.");
                return;
            }

            if (abonatStandard != null && programareAnulata)
            {
                abonatStandard.PretAbonament += 10;
                JSONHelper.SaveToFile(standardFilePath, AbonatiStandard);
            }

            else if (abonatPremium != null && programareAnulata)
            {
                abonatPremium.PretAbonament += 10;
                JSONHelper.SaveToFile(premiumFilePath, AbonatiPremium);
            }

        }


    }
}