﻿using System;
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
        public AdaugaProgramare()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            DetaliiProgramari detaliiProgramari = new DetaliiProgramari();
            detaliiProgramari.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            DetaliiProgramari detaliiProgramari = new DetaliiProgramari();
            detaliiProgramari.ShowDialog();
        }
    }
}
