using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Windows.Forms.Design;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp2
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var host = CreateHostBuilder().Build();

            var paginaPrincipala = host.Services.GetRequiredService<PaginaPrincipala>();

            TimeSpan oraInceput = new TimeSpan(8, 0, 0);
            TimeSpan oraSfarsit = new TimeSpan(20, 0, 0);
            var salafitness = new SalaFitness("AbcdFitness", "Ioan Cuza nr.10", oraInceput, oraSfarsit);

            var abonatmanager = new AbonatManager();
            var antrenormanager = new AntrenorManager();
            var programaremanager = new ProgramareManager(abonatmanager, salafitness);

            // Adaugare abonati
            var abonat1 = new AbonatStandard("Ion Popescu", "1234567890123", "ion.popescu", "parola123");
            var abonat2 = new AbonatStandard("Maria Ionescu", "2234567890123", "maria.ionescu", "parola456");
            var abonat3 = new AbonatStandard("George Vasilescu", "3234567890123", "george.vasilescu", "parola789");
            var abonat4 = new AbonatPremium("George Gheorghe", "3234327890123", "george.gheorghe", "parola749");
            var abonat5 = new AbonatPremium("Ana Popescu", "3234127890123", "ana.popescu", "parola2349");

            /*abonatmanager.AdaugaAbonatStandard(abonat1, "ion.popescu");
            abonatmanager.AdaugaAbonatStandard(abonat2, "maria.ionescu");
            abonatmanager.AdaugaAbonatStandard(abonat3, "george.vasilescu");
            abonatmanager.AdaugaAbonatPremium(abonat4, "george.gheorghe");
            abonatmanager.AdaugaAbonatPremium(abonat5, "ana.popescu");*/


            // Adaugare antrenori
            var antrenor1 = new Antrenor("Alex Stan", "Fitness", 9, TimeSpan.FromHours(9), TimeSpan.FromHours(17));
            var antrenor2 = new Antrenor("Diana Pop", "Yoga", 8, TimeSpan.FromHours(8), TimeSpan.FromHours(16));
            var antrenor3 = new Antrenor("Vlad Ionescu", "Culturism", 6, TimeSpan.FromHours(10), TimeSpan.FromHours(18));

            /*antrenormanager.AdaugaAntrenor(antrenor1);
            antrenormanager.AdaugaAntrenor(antrenor2);
            antrenormanager.AdaugaAntrenor(antrenor3);*/

            // Creare programari
            var programare1 = new Programare("ion.popescu", antrenor1, DateTime.Now.AddHours(6), 2);
            var programare2 = new Programare("maria.ionescu", antrenor2, DateTime.Now.AddDays(2), 1);
            var programare3 = new Programare("george.vasilescu", antrenor3, DateTime.Now.AddDays(3), 3);
            var programare4 = new Programare("ion.popescu", antrenor2, DateTime.Now.AddDays(4), 1);
            var programare5 = new Programare("maria.ionescu", antrenor1, DateTime.Now.AddDays(5), 2);
            var programare6 = new Programare("george.vasilescu", antrenor1, DateTime.Parse("2025/1/8"), 2);
            var programare7 = new Programare("ana.popescu", antrenor2, DateTime.Parse("2025/1/20"), 4);
            var programare8 = new Programare("george.gheorghe", antrenor2, DateTime.Parse("2025/1/14"), 5);

            /*programaremanager.AdaugaProgramare(programare1);
            programaremanager.AdaugaProgramare(programare2);
            programaremanager.AdaugaProgramare(programare3);
            programaremanager.AdaugaProgramare(programare4);
            programaremanager.AdaugaProgramare(programare5);
            programaremanager.AdaugaProgramare(programare6);
            programaremanager.AdaugaProgramare(programare7);
            programaremanager.AdaugaProgramare(programare8);*/



            // Test modificare programare
            //var programarenoua1 = new Programare("ion.popescu", antrenor2, DateTime.Now.AddDays(6), 6);
            //programaremanager.ModificaProgramare("ion.popescu", 0, programarenoua1);

            // Test anulare programare
            //programaremanager.AnuleazaProgramare("ion.popescu", 1);
            //programaremanager.AnuleazaProgramare("george.vasilescu", 0);

            Application.Run(paginaPrincipala);
        }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {

                    services.AddSingleton<PaginaPrincipala>();
                    services.AddTransient<Form1>();
                    services.AddTransient<RegisterForm>();
                    services.AddSingleton<ContAbonat>();         
                    services.AddSingleton<DetaliiCont>();      
                    services.AddSingleton<DetaliiProgramari>();
                    services.AddSingleton<AdaugaProgramare>();
                    services.AddSingleton<ModificareProgramare>();
                    services.AddSingleton<IMyService, MyService>();
                    services.AddSingleton<AbonatManager>();
                    services.AddSingleton<AntrenorManager>();
                    services.AddSingleton<ProgramareManager>();
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();

                });

        }
    }
    
}