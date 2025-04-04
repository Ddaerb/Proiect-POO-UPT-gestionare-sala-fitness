﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Serilog;

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
        private Validare validare = new Validare();

        public AdaugaProgramare(AbonatManager abonatManager, IServiceProvider serviceProvider, ProgramareManager programareManager, SalaFitness salaFitness, AntrenorManager antrenorManager)
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
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Selectati un antrenor.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("Nu a fost selectat niciun antrenor.");
                return;
            }

            Antrenor antrenor = _antrenorManager.ListaAntrenori[comboBox1.SelectedIndex];
            DateTime data = dateTimePicker2.Value;


            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Introduceti durata programarii.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("Nu a fost introdusa durata programarii.");
                return;
            }

            if (!int.TryParse(textBox2.Text, out int durata))
            {
                MessageBox.Show("Durata trebuie sa fie un numar intreg.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("Durata trebuie sa fie un numar intreg.");
                return;
            }

            durata = validare.VerificareOreProgramare(durata);

            if (antrenor == null)
            {
                MessageBox.Show("Selectati un antrenor.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("Nu a fost selectat niciun antrenor.");
                return;
            }


            if (data == null)
            {
                MessageBox.Show("Selectati o data.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("Nu a fost selectata nicio data.");
                return;
            }

            if (durata == null)
            {
                MessageBox.Show("Introduceti durata programarii.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("Nu a fost introdusa durata programarii.");
                return;
            }

            int durataNoua = validare.VerificareOreProgramare(durata);
            textBox2.Text = durataNoua.ToString();

            Programare programare = new Programare(_abonat.Username, antrenor, data, durataNoua);
            _programareManager.AdaugaProgramare(programare);
            MessageBox.Show("Programarea a fost adaugata cu succes.");
            Log.Information("Programare adaugata cu succes.");

            this.Hide();

            var detaliiProgramari = _serviceProvider.GetRequiredService<DetaliiProgramari>();
            detaliiProgramari.InitializeUser(_abonat);
            detaliiProgramari.InitializeIstoricList();
            detaliiProgramari.Show();
        }

        private void AdaugaProgramare_Load(object sender, EventArgs e)
        {
            Log.Information("AdaugaProgramare incarcata cu succes.");

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
            dateTimePicker2.MinDate = DateTime.Now;
            _antrenorManager.ListaAntrenori.ForEach(antrenor => comboBox1.Items.Add(antrenor.NumeComplet + ", " + antrenor.Specializare));
            //comboBox1.Items.Add();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
