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

        private AbonatStandard RecalcularePretAbonament(AbonatStandard abonat, bool status, Programare programare)
        {

            if (programare.StatusProgramare == "anulata." || programare.StatusProgramare == "modificata.")
            {
                if (status)  // status verifica daca programarea a fost facuta cu mai putin de 24 de ore inainte (true-da, false-nu)
                {
                    abonat.PretAbonament += 10;
                }
                return abonat;
            }

            // Calculare ore depasite, transmitem salaFitness pentru a-i accesa orele de functionare
            double oreDepasite = CalculareOreDepasite(programare, salaFitness);

            if (abonat.TipAbonament == "standard" && oreDepasite > 0)
            {
                int costOra = 5;
                abonat.PretAbonament += (int)Math.Ceiling(oreDepasite) * costOra;
            }
            else if (abonat.TipAbonament == "premium" && oreDepasite > 2) 
            {
                int costOra = 2;
                abonat.PretAbonament += (int)Math.Ceiling(oreDepasite) * costOra;
            }

            return abonat;
        }

        private double CalculareOreDepasite(Programare programare, SalaFitness salaFitness)
        {

            //interval1 e intervalul programarii
            DateTime interval1start = programare.Data; //folosim aceeasi data la toate intervalele deoarece sala functioneaza in fiecare zi intre orele 8-20
            DateTime interval1end = programare.Data.AddHours(programare.DurataProgramataOre); //adaugam durata programarii la data de inceput a programarii

            //interval2 e intervalul de functionare al salii
            DateTime interval2start = programare.Data.Date.Add(salaFitness.OraInceput);
            DateTime interval2end = programare.Data.Date.Add(salaFitness.OraSfarsit);

            double oreDepasite = 0;

            //daca depasim intervalul in jos
            if (interval1start < interval2start)
            {
                oreDepasite += (interval2start - interval1start).TotalHours;
            }

            //daca depasim intervalul in sus
            if (interval1end > interval2end)
            {
                oreDepasite += (interval1end - interval2end).TotalHours;
            }

            if (oreDepasite < 0)
            {
                oreDepasite = 0;
            }

            if (oreDepasite > programare.DurataProgramataOre)
            {
                oreDepasite = programare.DurataProgramataOre;
            }


            return oreDepasite;
        }


        private void ActualizeazaFisierJSON()
        {
            JSONHelper.SaveToFile(CaleFisier, ListaProgramari);
        }

        public void AdaugaProgramare(Programare programare)
        {
            // Verificam daca abonatul exista in lista de abonati cu FirstOrDefault din LINQ
            var abonatStandard = abonatManager.AbonatiStandard.FirstOrDefault(a => a.Username == programare.AbonatUsername);
            var abonatPremium = abonatManager.AbonatiPremium.FirstOrDefault(a => a.Username == programare.AbonatUsername);

            //Daca nu s-a gasit abonatul, afisam un mesaj de eroare
            if (abonatStandard == null && abonatPremium == null)
            {
                MessageBox.Show(
                    "Abonatul specificat nu a fost gasit.",
                    "Eroare",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            //Daca exista deja o programare cu acelasi abonat, data si durata, afisam un mesaj de eroare
            if (ListaProgramari.Any(p =>p.AbonatUsername == programare.AbonatUsername &&p.Data.Date == programare.Data.Date &&p.DurataProgramataOre == programare.DurataProgramataOre))
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

            if (abonatStandard != null) //recalculam pretul abonamentului in functie de abonat standard
            {

                abonatStandard = RecalcularePretAbonament(abonatStandard, false, programare);
                abonatStandard.IstoricProgramari.Add(programare);
            }
            else if (abonatPremium != null) //recalculam pretul abonamentului in functie de abonat premium
            {
                abonatPremium = (AbonatPremium)RecalcularePretAbonament(abonatPremium, false, programare);
                abonatPremium.IstoricProgramari.Add(programare);
            }

            abonatManager.ActualizeazaAbonati(abonatManager.AbonatiStandard, abonatManager.AbonatiPremium);
        }


        public void ModificaProgramare(string username, int index, Programare programareNoua)
        {

            //gasieste programarile abonatului cu Where din LINQ si le adaugam in lista
            var programariAbonat = ListaProgramari.Where(p => p.AbonatUsername == username).ToList();
            if (index >= 0 && index < programariAbonat.Count)
            {
                //gasim programarea existenta si o stergem din lista
                var programareExistenta = programariAbonat[index];
                ListaProgramari.Remove(programareExistenta);
                //adaugam programarea noua in lista
                programareNoua.StatusProgramare = "modificata.";
                ListaProgramari.Add(programareNoua);
                ActualizeazaFisierJSON();

                //gasim abonatul standard si premium
                var abonatStandard = abonatManager.AbonatiStandard.FirstOrDefault(a => a.Username == username);
                var abonatPremium = abonatManager.AbonatiPremium.FirstOrDefault(a => a.Username == username);

                if (abonatStandard != null)
                {
                    //stergem programarea existenta din istoricul abonatului si adaugam programarea noua pt abonat standard

                    abonatStandard.IstoricProgramari.RemoveAll(p =>
                        p.AbonatUsername == programareExistenta.AbonatUsername &&
                        p.Data == programareExistenta.Data);
                    abonatStandard.IstoricProgramari.Add(programareNoua);

                    //verificam daca programarea a fost facuta cu mai putin de 24 de ore inainte
                    var status = (programareNoua.Data - DateTime.Now).TotalHours < 24;
                    abonatStandard = RecalcularePretAbonament(abonatStandard, status, programareNoua);
                }
                else if (abonatPremium != null)
                {
                    //stergem programarea existenta din istoricul abonatului si adaugam programarea noua pt abonat premium
                    abonatPremium.IstoricProgramari.RemoveAll(p =>
                        p.AbonatUsername == programareExistenta.AbonatUsername &&
                        p.Data == programareExistenta.Data);
                    abonatPremium.IstoricProgramari.Add(programareNoua);

                    //verificam daca programarea a fost facuta cu mai putin de 24 de ore inainte
                    var status = (programareNoua.Data - DateTime.Now).TotalHours < 24;
                    abonatPremium = (AbonatPremium)RecalcularePretAbonament(abonatPremium, status, programareNoua);
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
            //gasieste programarile abonatului cu Where din LINQ si le adaugam in lista
            var programariAbonat = ListaProgramari.Where(p => p.AbonatUsername == username).ToList();
            if (index >= 0 && index < programariAbonat.Count)
            {
                //gasim programarea existenta si o stergem din lista
                var programareDeAnulat = programariAbonat[index];
                ListaProgramari.Remove(programareDeAnulat);
                ActualizeazaFisierJSON();

                //gasim abonatul standard si premium
                var abonatStandard = abonatManager.AbonatiStandard.FirstOrDefault(a => a.Username == username);
                var abonatPremium = abonatManager.AbonatiPremium.FirstOrDefault(a => a.Username == username);

                if (abonatStandard != null)
                {
                    //modificam statusul programarii in "anulata." deoarece e istoricul abonatului
                    var programareDinIstoric = abonatStandard.IstoricProgramari.FirstOrDefault(p => p.AbonatUsername == programareDeAnulat.AbonatUsername && p.Data == programareDeAnulat.Data);

                    if (programareDinIstoric != null)
                    {
                        programareDinIstoric.StatusProgramare = "anulata.";
                    }

                    //verificam daca programarea a fost facuta cu mai putin de 24 de ore inainte
                    var status = (programareDeAnulat.Data - DateTime.Now).TotalHours < 24;
                    abonatStandard = RecalcularePretAbonament(abonatStandard, status, programareDeAnulat);
                }
                else if (abonatPremium != null)
                {
                    //modificam statusul programarii in "anulata." deoarece e istoricul abonatului
                    var programareDinIstoric = abonatPremium.IstoricProgramari.FirstOrDefault(p => p.AbonatUsername == programareDeAnulat.AbonatUsername && p.Data == programareDeAnulat.Data);

                    if (programareDinIstoric != null)
                    {
                        programareDinIstoric.StatusProgramare = "anulata.";
                    }

                    //verificam daca programarea a fost facuta cu mai putin de 24 de ore inainte
                    var status = (programareDeAnulat.Data - DateTime.Now).TotalHours < 24;
                    abonatPremium = (AbonatPremium)RecalcularePretAbonament(abonatPremium, status, programareDeAnulat);
                }

                abonatManager.ActualizeazaAbonati(abonatManager.AbonatiStandard, abonatManager.AbonatiPremium);
            }
            else
            {
                MessageBox.Show(
                    "Programarea a fost deja anulata.",
                    "Eroare",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

    }
}
