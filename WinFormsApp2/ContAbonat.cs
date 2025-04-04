﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Serilog;

namespace WinFormsApp2
{
    public partial class ContAbonat : Form
    {
        private readonly AbonatManager _abonatManager;
        private readonly IServiceProvider _serviceProvider;
        private readonly ProgramareManager _programareManager;
        private readonly SalaFitness _salaFitness;
        private AbonatStandard _abonat;

        public ContAbonat(AbonatManager abonatManager, IServiceProvider serviceProvider, ProgramareManager programareManager, SalaFitness salaFitness)
        {
            _abonatManager = abonatManager;
            _serviceProvider = serviceProvider;
            _programareManager = programareManager;
            _salaFitness = salaFitness;
            InitializeComponent();
        }

        public void InitializeUser(AbonatStandard abonat)
        {
            _abonat = abonat;
        }



        private void button3_Click(object sender, EventArgs e)
        {

            this.Close();

            var paginaPrincipala = _serviceProvider.GetRequiredService<PaginaPrincipala>();
            paginaPrincipala.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            var detaliiCont = _serviceProvider.GetRequiredService<DetaliiCont>();
            detaliiCont.InitializeUser(_abonat);
            detaliiCont.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            var detaliiProgramari = _serviceProvider.GetRequiredService<DetaliiProgramari>();
            detaliiProgramari.InitializeUser(_abonat);
            detaliiProgramari.InitializeIstoricList();
            detaliiProgramari.Show();
        }

        private void ContAbonat_Load(object sender, EventArgs e)
        {
            Log.Information("ContAbonat incarcata cu succes.");
        }
    }
}
