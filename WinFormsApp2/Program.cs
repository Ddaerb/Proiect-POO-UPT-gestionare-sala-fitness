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

            var form1 = host.Services.GetRequiredService<Form1>();
            Application.Run(form1);
        }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                   
                    services.AddSingleton<Form1>();
                    services.AddSingleton<IMyService, MyService>(); 
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                  
                });
        }
    }
    public partial class Form1 : Form
    {
        private readonly IMyService _myService;

        public Form1(IMyService myService)
        {
            _myService = myService;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _myService.DoSomething();
        }
    }
}