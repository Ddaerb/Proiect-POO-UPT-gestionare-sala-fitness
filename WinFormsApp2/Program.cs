using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Windows.Forms.Design;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Serilog;

namespace WinFormsApp2
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Configuram Serilog
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("logs\\app.log", rollingInterval: RollingInterval.Month) // creeaza un noi fisier de tip log doar o data pe luna
                .CreateLogger();
            try
            {
                // Crearea host-ului si rularea aplicatiei
                var host = CreateHostBuilder().Build();

                var paginaPrincipala = host.Services.GetRequiredService<PaginaPrincipala>();

                Application.Run(paginaPrincipala);
                Log.Information("Applicatia a pornit.");
            }
            catch (Exception ex) 
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        static IHostBuilder CreateHostBuilder()
        {

            // Configurarea serviciilor

            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {

                    services.AddSingleton<PaginaPrincipala>();
                    services.AddTransient<Form1>();
                    services.AddTransient<RegisterForm>();
                    services.AddTransient<ContAbonat>();         
                    services.AddTransient<DetaliiCont>();      
                    services.AddSingleton<DetaliiProgramari>();
                    services.AddSingleton<AdaugaProgramare>();
                    services.AddSingleton<ModificareProgramare>();
                    services.AddSingleton<AbonatManager>();
                    services.AddSingleton<AntrenorManager>();
                    services.AddSingleton<ProgramareManager>();
                    services.AddSingleton<SalaFitness>(provider => new SalaFitness("AbcdFitness", "Ioan Cuza nr.10", new TimeSpan(8, 0, 0), new TimeSpan(20, 0, 0)));
                    services.AddTransient<ContAdmin>();
                    services.AddSingleton<DetaliiProgramariAdmin>();
                    services.AddSingleton<DetaliiAntrenoriAdmin>();
                    services.AddSingleton<DetaliiAbonatiAdmin>();
                    services.AddSingleton<AdaugaAntrenorAdmin>();
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddSerilog();

                });

        }
    }
    
}