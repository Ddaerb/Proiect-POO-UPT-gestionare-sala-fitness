using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace WindowsFormsApp1
{


    public class AntrenorManager
    {
        private string CaleFisier => FilePaths.GetFilePath("antrenori.json");
        public List<Antrenor> ListaAntrenori { get; set; }

        public AntrenorManager()
        {
            ListaAntrenori = JSONHelper.LoadFromFile<List<Antrenor>>(CaleFisier);
            if (ListaAntrenori == null)
            {
                ListaAntrenori = new List<Antrenor>();
            }
        }

        private void ActualizeazaFisierJSON()
        {
            JSONHelper.SaveToFile(CaleFisier, ListaAntrenori);
        }

        public void AdaugaAntrenor(Antrenor antrenor)
        {
            ListaAntrenori.Add(antrenor);
            ActualizeazaFisierJSON();
        }

        public void ListareAntrenori()
        {
            if (ListaAntrenori.Count == 0)
            {
                MessageBox.Show
                (
                "Nu exista antrenori �n lista.",
                "Eroare",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
                return;
            }

            Console.WriteLine("Lista antrenorilor:");
            foreach (var antrenor in ListaAntrenori)
            {
                Console.WriteLine($"Nume: {antrenor.NumeComplet}");
                Console.WriteLine($"Specializare: {antrenor.Specializare}");
                Console.WriteLine($"Numar maxim clienti: {antrenor.NumarMaximClienti}");
                Console.WriteLine($"Orar: {antrenor.OrarPrestabilit.OraInceput} - {antrenor.OrarPrestabilit.OraSfarsit}");
                Console.WriteLine("-------------------");
            }
        }

        public Antrenor CautareAntrenor(string nume, string specializare)
        {
            foreach (var antrenor in ListaAntrenori)
            {
                if (antrenor.NumeComplet.Equals(nume, StringComparison.OrdinalIgnoreCase) &&
                    antrenor.Specializare.Equals(specializare, StringComparison.OrdinalIgnoreCase))
                {
                    return antrenor;
                }
            }

            MessageBox.Show
            (
            $"Nu a fost gasit niciun antrenor cu numele '{nume}' si specializarea '{specializare}'.",
            "Eroare",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
            );
            return null;
        }
    }
}