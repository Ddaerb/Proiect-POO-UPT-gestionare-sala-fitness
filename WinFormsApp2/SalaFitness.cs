using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{


    public class SalaFitness
    {
        public string Nume { get; private set; }
        public string Adresa { get; private set; }
        public (TimeSpan OraInceput, TimeSpan OraSfarsit) ProgramFunctionare { get; private set; }
        public List<Antrenor> ListaAntrenoriDisponibili { get; private set; } = new List<Antrenor>();

        public SalaFitness(string nume, string adresa, TimeSpan oraInceput, TimeSpan oraSfarsit)
        {
            Nume = nume;
            Adresa = adresa;
            ProgramFunctionare = (oraInceput, oraSfarsit);
        }

    }
}