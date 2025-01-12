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
            // Adaugare abonati
            var abonat1 = new AbonatStandard("Ion Popescu", "1234567890123", "ion.popescu", "parola123");
            var abonat2 = new AbonatStandard("Maria Ionescu", "2234567890123", "maria.ionescu", "parola456");
            var abonat3 = new AbonatStandard("George Vasilescu", "3234567890123", "george.vasilescu", "parola789");
            var abonat4 = new AbonatPremium("George Gheorghe", "3234327890123", "george.gheorghe", "parola749");
            var abonat5 = new AbonatPremium("Ana Popescu", "3234127890123", "ana.popescu", "parola2349");



            // Adaugare antrenori
            var antrenor1 = new Antrenor("Alex Stan", "Fitness", 9, TimeSpan.FromHours(9), TimeSpan.FromHours(17));
            var antrenor2 = new Antrenor("Diana Pop", "Yoga", 8, TimeSpan.FromHours(8), TimeSpan.FromHours(16));
            var antrenor3 = new Antrenor("Vlad Ionescu", "Culturism", 6, TimeSpan.FromHours(10), TimeSpan.FromHours(18));

            // Creare programari
            var programare1 = new Programare("ion.popescu", antrenor1, DateTime.Now.AddDays(1), 2);
            var programare2 = new Programare("maria.ionescu", antrenor2, DateTime.Now.AddDays(2), 1);
            var programare3 = new Programare("george.vasilescu", antrenor3, DateTime.Now.AddDays(3), 3);
            var programare4 = new Programare("ion.popescu", antrenor2, DateTime.Now.AddDays(4), 1);
            var programare5 = new Programare("maria.ionescu", antrenor1, DateTime.Now.AddDays(5), 2);
            var programare6 = new Programare("george.vasilescu", antrenor1, DateTime.Parse("2025/1/8"), 2);
            var programare7 = new Programare("ana.popescu", antrenor2, DateTime.Parse("2025/1/10"), 4);
            var programare8 = new Programare("george.gheorghe", antrenor2, DateTime.Parse("2025/1/11"), 5);

            //programari pentru modificat
            var programarenoua1 = new Programare("ion.popescu", antrenor2, DateTime.Now.AddDays(6), 6);
            var programarenoua2 = new Programare("maria.ionescu", antrenor3, DateTime.Now.AddDays(7), 7);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
