using System;
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
    public partial class AdaugaAntrenorAdmin : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly AntrenorManager _antrenorManager;
        public AdaugaAntrenorAdmin(IServiceProvider serviceProvider, AntrenorManager antrenorManager)
        {
            _antrenorManager = antrenorManager;
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void AdaugaAntrenorAdmin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            var detaliiAntrenoriAdmin = _serviceProvider.GetRequiredService<DetaliiAntrenoriAdmin>();
            detaliiAntrenoriAdmin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            var detaliiAntrenoriAdmin = _serviceProvider.GetRequiredService<DetaliiAntrenoriAdmin>();
            detaliiAntrenoriAdmin.InitializeAntrenoriList();
            detaliiAntrenoriAdmin.Show();
        }
    }
}
