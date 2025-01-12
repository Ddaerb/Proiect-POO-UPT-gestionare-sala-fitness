using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        [STAThread]
        static void Main()
        {
            
            AbonatManager abonatmanager = new AbonatManager();
            AntrenorManager antrenormanager = new AntrenorManager();
            ProgramareManager programaremanager = new ProgramareManager(abonatmanager);
            var abonat1 = new AbonatStandard("Ion Popescu", "1234567890123", "ion.popescu", "parola123");
            var abonat2 = new AbonatStandard("Maria Ionescu", "2234567890123", "maria.ionescu", "parola456");
            var abonat3 = new AbonatStandard("George Vasilescu", "3234567890123", "george.vasilescu", "parola789");
            var abonat4 = new AbonatPremium("George Gheorghe", "3234327890123", "george.gheorghe", "parola749");

            var antrenor2 = new Antrenor("Diana Pop", "Yoga", 8, TimeSpan.FromHours(8), TimeSpan.FromHours(16));
            var antrenor3 = new Antrenor("Vlad Ionescu", "Culturism", 6, TimeSpan.FromHours(10), TimeSpan.FromHours(18));

            var programare8 = new Programare("george.vasilescu", antrenor2, DateTime.Parse("2025/1/11"), 5);

            //programaremanager.ModificaProgramare("ion.popescu",0,programare8);
            //programaremanager.AnuleazaProgramare("george.gheorghe", 0,abonat4);

            programaremanager.ModificaProgramare("george.vasilescu", 0, programare8);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
