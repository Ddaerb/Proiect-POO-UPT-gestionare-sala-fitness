using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Serilog;

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
        private Validare validare = new Validare();
        private Programare _programare;
        public ModificareProgramare(AbonatManager abonatManager, IServiceProvider serviceProvider, ProgramareManager programareManager, SalaFitness salaFitness, AntrenorManager antrenorManager)
        {

            _abonatManager = abonatManager;
            _serviceProvider = serviceProvider;
            _programareManager = programareManager;
            _salaFitness = salaFitness;
            _antrenorManager = antrenorManager;
            InitializeComponent();
        }

        public void InitializeProgramare(Programare programare)
        {
            _programare = programare;

            comboBox3.Items.Clear();
            foreach (var antrenor in _antrenorManager.ListaAntrenori)
            {
                comboBox3.Items.Add(antrenor.NumeComplet);
            }

            comboBox3.SelectedItem = programare.Antrenor.NumeComplet;

            dateTimePicker1.Value = programare.Data;

            textBox1.Text = programare.DurataProgramataOre.ToString();
        }

        public void InitializeUser(AbonatStandard abonat)
        {
            _abonat = abonat;
        }

        private void ModificareProgramare_Load(object sender, EventArgs e)
        {
            Log.Information("ModificareProgramare incarcata cu succes.");

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
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
            if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Selectati un antrenor.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("Nu a fost selectat un antrenor.");
                return;
            }

            Antrenor antrenor = _antrenorManager.ListaAntrenori[comboBox3.SelectedIndex];
            DateTime data = dateTimePicker1.Value;


            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Introduceți durata programării.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("Nu a fost introdusa durata programarii.");
                return;
            }

            if (!int.TryParse(textBox1.Text, out int durata))
            {
                MessageBox.Show("Durata trebuie sa fie un numar intreg.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("Durata trebuie sa fie un numar intreg.");
                return;
            }

            durata = validare.VerificareOreProgramare(durata);

            if (antrenor == null)
            {
                MessageBox.Show("Selectati un antrenor.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                Log.Error("Nu a fost selectat un antrenor.");
            }


            if (data == null)
            {
                MessageBox.Show("Selectati o data.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                Log.Error("Nu a fost selectata o data.");
            }

            if (durata == null)
            {
                MessageBox.Show("Introduceti durata programarii.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("Nu a fost introdusa durata programarii.");
                return;
            }

            int durataNoua = validare.VerificareOreProgramare(durata);
            textBox1.Text = durataNoua.ToString();

            Programare programare = new Programare(_abonat.Username, antrenor, data, durataNoua);
            _programareManager.ModificaProgramare(_abonat.Username, comboBox3.SelectedIndex, programare);
            MessageBox.Show("Programarea a fost modificata cu succes.");
            Log.Information("Programarea a fost modificata cu succes.");


            this.Hide();
            
            var detaliiProgramari = _serviceProvider.GetRequiredService<DetaliiProgramari>();
            detaliiProgramari.InitializeUser(_abonat);
            detaliiProgramari.InitializeIstoricList();
            detaliiProgramari.Show();
        }
    }
}
