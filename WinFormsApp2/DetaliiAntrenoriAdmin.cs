﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace WinFormsApp2
{
    public partial class DetaliiAntrenoriAdmin : Form
    {

        private readonly IServiceProvider _serviceProvider;
        private readonly AntrenorManager _antrenorManager;
        public DetaliiAntrenoriAdmin(IServiceProvider serviceProvider, AntrenorManager antrenorManager)
        {
            _antrenorManager = antrenorManager;
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        public void InitializeAntrenoriList()
        {
            listView1.Items.Clear();
            var antrenori = _antrenorManager.ListaAntrenori;

            foreach (var antrenor in antrenori)
            {
                var item = new ListViewItem(new string[]
                {
                    antrenor.NumeComplet.ToString(),
                    antrenor.Specializare.ToString(),
                    antrenor.NumarMaximClienti.ToString(),
                    antrenor.OrarPrestabilit.ToString()

                });
                listView1.Items.Add(item);
            }
        }

        private void DetaliiAntrenoriAdmin_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            var contAdmin = _serviceProvider.GetRequiredService<ContAdmin>();
            contAdmin.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            var adaugaAntrenorAdmin = _serviceProvider.GetRequiredService<AdaugaAntrenorAdmin>();
            adaugaAntrenorAdmin.Show();
        }
    }
}
