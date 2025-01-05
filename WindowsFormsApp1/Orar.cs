using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Orar
    {
        public TimeSpan OraInceput { get; set; }
        public TimeSpan OraSfarsit { get; set; }

        public Orar() { }

        public Orar(TimeSpan oraInceput, TimeSpan oraSfarsit)
        {
            OraInceput = oraInceput;
            OraSfarsit = oraSfarsit;
        }
    }
}
