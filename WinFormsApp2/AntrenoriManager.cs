using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace WinFormsApp2
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
            if(antrenor==null)
            {
                MessageBox.Show
                (
                "Antrenorul nu poate fi null.",
                "Eroare",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
                return;
            }
            //Verificam daca antrenorul exista deja in lista
            if (ListaAntrenori.Any(a => a.NumeComplet == antrenor.NumeComplet && a.Specializare == antrenor.Specializare))
            {
                MessageBox.Show
                (
                $"Antrenorul cu numele '{antrenor.NumeComplet}' si specializarea '{antrenor.Specializare}' exista deja in lista.",
                "Eroare",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
                return;
            }

            //Adaugam antrenorul in lista
            ListaAntrenori.Add(antrenor);
            ActualizeazaFisierJSON();
        }

        public void StergeAntrenor(Antrenor antrenor)
        {
            if (antrenor == null)
            {
                MessageBox.Show
                (
                "Antrenorul nu poate fi null.",
                "Eroare",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
                return;
            }

            //Verificam daca antrenorul exista in lista
            var antrenorDeSters = ListaAntrenori.FirstOrDefault(a =>
                a.NumeComplet == antrenor.NumeComplet &&
                a.Specializare == antrenor.Specializare);

            if (antrenorDeSters == null)
            {
                MessageBox.Show
                (
                $"Antrenorul cu numele '{antrenor.NumeComplet}' si specializarea '{antrenor.Specializare}' nu exista in lista.",
                "Eroare",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
                return;
            }

            //Stergem antrenorul din lista
            ListaAntrenori.Remove(antrenorDeSters);
            ActualizeazaFisierJSON();

            MessageBox.Show
            (
            $"Antrenorul cu numele '{antrenor.NumeComplet}' si specializarea '{antrenor.Specializare}' a fost sters din lista.",
            "Informatie",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
            );
        }

    }
}