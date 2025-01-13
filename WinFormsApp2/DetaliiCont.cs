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
    public partial class DetaliiCont : Form
    {
        private readonly AbonatManager _abonatManager;
        private readonly IServiceProvider _serviceProvider;
        private AbonatStandard _abonat;

        public DetaliiCont(AbonatManager abonatManager, IServiceProvider serviceProvider)
        {
            _abonatManager = abonatManager;
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        public void InitializeUser(AbonatStandard abonat)
        {
            _abonat = abonat;
            txtNumeComplet.Text = "Nume Complet:";
            txtNumeComplet.Text += $" {_abonat.NumeComplet}";

            txtNumeUtilizator.Text = "Nume de utilizator:";
            txtNumeUtilizator.Text += $" {_abonat.Username}";

            txtCNP.Text = "CNP:";
            txtCNP.Text += $" {_abonat.CNP}";

            txtTipAbonament.Text = "Tip Abonament: ";
            txtTipAbonament.Text += $" {_abonat.TipAbonament}";

            txtPretAbonament.Text = "Pret Abonament:  ";
            txtPretAbonament.Text += $" {_abonat.PretAbonament}";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            var contAbonat = _serviceProvider.GetRequiredService<ContAbonat>();
            contAbonat.Show();
        }

        private void DetaliiCont_Load(object sender, EventArgs e)
        {

        }
    }
}
