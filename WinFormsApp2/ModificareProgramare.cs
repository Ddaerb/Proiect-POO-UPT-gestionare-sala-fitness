using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp2
{
    public partial class ModificareProgramare : Form
    {
        private readonly AbonatManager _abonatManager;
        private readonly IServiceProvider _serviceProvider;
        private readonly ProgramareManager _programareManager;
        private readonly SalaFitness _salaFitness;
        private AbonatStandard _abonat;
        private readonly AntrenorManager _antrenorManager;
        public ModificareProgramare(AbonatManager abonatManager, IServiceProvider serviceProvider, ProgramareManager programareManager, SalaFitness salaFitness, AntrenorManager antrenorManager)
        {

            _abonatManager = abonatManager;
            _serviceProvider = serviceProvider;
            _programareManager = programareManager;
            _salaFitness = salaFitness;
            _antrenorManager = antrenorManager;
            InitializeComponent();
        }

        public void InitializeUser(AbonatStandard abonat)
        {
            _abonat = abonat;
        }

        private void ModificareProgramare_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            dateTimePicker1.MinDate = DateTime.Now;
            _antrenorManager.ListaAntrenori.ForEach(antrenor => comboBox3.Items.Add(antrenor.NumeComplet + ", " + antrenor.Specializare));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            var detaliiProgramari = _serviceProvider.GetRequiredService<DetaliiProgramari>();
            detaliiProgramari.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            var detaliiProgramari = _serviceProvider.GetRequiredService<DetaliiProgramari>();
            detaliiProgramari.InitializeUser(_abonat);
            detaliiProgramari.InitializeIstoricList();
            detaliiProgramari.ShowDialog();
        }
    }
}
