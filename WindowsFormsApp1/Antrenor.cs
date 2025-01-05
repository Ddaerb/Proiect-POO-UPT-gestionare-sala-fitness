using System;

namespace WindowsFormsApp1
{


    public class Antrenor
    {
        public string NumeComplet { get; set; }
        public string Specializare { get; set; }
        public int NumarMaximClienti { get; set; }
        public (TimeSpan OraInceput, TimeSpan OraSfarsit) OrarPrestabilit { get; set; }

        public Antrenor(string numeComplet, string specializare, int numarMaximClienti, TimeSpan oraInceput, TimeSpan oraSfarsit)
        {
            NumeComplet = numeComplet;
            Specializare = specializare;
            NumarMaximClienti = numarMaximClienti;
            OrarPrestabilit = (oraInceput, oraSfarsit);
        }

        //Constructor fara parametrii pentru compatibilitate cu JSON
        public Antrenor() { }
    }
}
