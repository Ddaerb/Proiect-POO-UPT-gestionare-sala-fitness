using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{


    public class Antrenor
    {
        public string NumeComplet { get; set; }
        public string Specializare { get; set; }
        public int NumarMaximClienti { get; set; }
        public Orar OrarPrestabilit { get; set; }

        public Antrenor(string numeComplet, string specializare, int numarMaximClienti, TimeSpan oraInceput, TimeSpan oraSfarsit)
        {
            NumeComplet = numeComplet;
            Specializare = specializare;
            NumarMaximClienti = numarMaximClienti;
            OrarPrestabilit = new Orar(oraInceput, oraSfarsit);
        }

        //Constructor fara parametrii pentru compatibilitate cu JSON
        public Antrenor() { }
    }
}
