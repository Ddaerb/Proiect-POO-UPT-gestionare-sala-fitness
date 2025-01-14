using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Serilog;

namespace WinFormsApp2
{
    public partial class ContAdmin : Form
    {

        private readonly AbonatManager _abonatManager;
        private readonly IServiceProvider _serviceProvider;
        private readonly ProgramareManager _programareManager;
        private readonly SalaFitness _salaFitness;
        private readonly AntrenorManager _antrenorManager;
        public ContAdmin(AbonatManager abonatManager, IServiceProvider serviceProvider, ProgramareManager programareManager, SalaFitness salaFitness, AntrenorManager antrenorManager)
        {
            _abonatManager = abonatManager;
            _serviceProvider = serviceProvider;
            _programareManager = programareManager;
            _salaFitness = salaFitness;
            _antrenorManager = antrenorManager;
            InitializeComponent();
        }

        private void ContAdmin_Load(object sender, EventArgs e)
        {
            Log.Information("ContAdmin incarcata cu succes.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            var detaliiAntrenoriAdmin = _serviceProvider.GetRequiredService<DetaliiAntrenoriAdmin>();
            detaliiAntrenoriAdmin.InitializeAntrenoriList();
            detaliiAntrenoriAdmin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            var detaliiAbonatiAdmin = _serviceProvider.GetRequiredService<DetaliiAbonatiAdmin>();
            detaliiAbonatiAdmin.InitializeProgramariList();
            detaliiAbonatiAdmin.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            var detaliiProgramariAdmin = _serviceProvider.GetRequiredService<DetaliiProgramariAdmin>();
            detaliiProgramariAdmin.InitializeProgramariList();
            detaliiProgramariAdmin.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();

            var paginaPrincipala = _serviceProvider.GetRequiredService<PaginaPrincipala>();
            paginaPrincipala.Show();
        }
    }
}
