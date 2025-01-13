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

namespace WinFormsApp2
{
    public partial class AdaugaProgramare : Form
    {
        private readonly AbonatManager _abonatManager;
        private readonly IServiceProvider _serviceProvider;
        private readonly ProgramareManager _programareManager;
        private readonly SalaFitness _salaFitness;
        private readonly AntrenorManager _antrenorManager;
        private AbonatStandard _abonat;

        public AdaugaProgramare(AbonatManager abonatManager, IServiceProvider serviceProvider, ProgramareManager programareManager, SalaFitness salaFitness,AntrenorManager antrenorManager)
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
            detaliiProgramari.Show();
        }

        private void AdaugaProgramare_Load(object sender, EventArgs e)
        {
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            dateTimePicker2.MinDate = DateTime.Now;
            _antrenorManager.ListaAntrenori.ForEach(antrenor => comboBox1.Items.Add(antrenor.NumeComplet+", "+antrenor.Specializare));
            //comboBox1.Items.Add();
        }


    }
}
