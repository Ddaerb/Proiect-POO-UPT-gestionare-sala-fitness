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
    public partial class ModificareProgramare : Form
    {
        private readonly IServiceProvider _serviceProvider;
        public ModificareProgramare(IServiceProvider serviceProvider)
        {

            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        private void ModificareProgramare_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            var detaliiProgramari = _serviceProvider.GetRequiredService<ContAbonat>();
            detaliiProgramari.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
