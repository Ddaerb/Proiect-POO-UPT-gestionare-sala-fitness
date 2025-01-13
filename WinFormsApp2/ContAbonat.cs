﻿using Microsoft.Extensions.DependencyInjection;
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
    public partial class ContAbonat : Form
    {
        private readonly AbonatManager _abonatManager;
        private readonly IServiceProvider _serviceProvider;
        private AbonatStandard _abonat; 

        public ContAbonat(AbonatManager abonatManager, IServiceProvider serviceProvider)
        {
            _abonatManager = abonatManager;
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        public void InitializeUser(AbonatStandard abonat)
        {
            _abonat = abonat;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            var paginaPrincipala = _serviceProvider.GetRequiredService<PaginaPrincipala>();
            paginaPrincipala.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            var detaliiCont = _serviceProvider.GetRequiredService<DetaliiCont>();
            detaliiCont.InitializeUser(_abonat);
            detaliiCont.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            var detaliiProgramari = _serviceProvider.GetRequiredService<DetaliiProgramari>();
            detaliiProgramari.ShowDialog();
        }
    }
}
