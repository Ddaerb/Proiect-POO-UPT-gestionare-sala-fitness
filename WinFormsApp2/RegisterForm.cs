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
    public partial class RegisterForm : Form
    {
        private readonly AbonatManager _abonatManager;
        private readonly IServiceProvider _serviceProvider;

        public RegisterForm(AbonatManager abonatManager, IServiceProvider serviceProvider)
        {
            _abonatManager = abonatManager;
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string name = txtNume.Text;
            string cnp = txtCNP.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = textBox1.Text;
            string subscriptionType = cmbSub.Text;
            Validare validare = new Validare();
            AbonatStandard abonatStandard;
            AbonatPremium abonatPremium;

            if (name == null || name == "")
            {
                MessageBox.Show("Campul pentru nume trebuie completat");
                return;
            }

            string numeNou = validare.ValideazaNumeComplet(name);
            txtNume.Text = numeNou;

            if (cnp == null || cnp == "")
            {
                MessageBox.Show("Campul pentru CNP treuie completat");
                return;
            }

            string cnpNou = validare.VerificareCNP(cnp);
            txtCNP.Text = cnpNou;

            if (username == null || username == "")
            {
                MessageBox.Show("Campul pentru numele de utilizator treuie completat");
                return;
            }

            if (password == null || password == "")
            {
                MessageBox.Show("Campul pentru parola treuie completat");
                return;
            }

            if (confirmPassword == null || confirmPassword == "")
            {
                MessageBox.Show("Campul pentru confirmarea parolei treuie completat");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Parolele nu se potrivesc");
                return;
            }

            if (subscriptionType == null || subscriptionType == "")
            {
                MessageBox.Show("Campul pentru tipul abonamentului treuie completat");
                return;
            }

            var contAbonat = _serviceProvider.GetRequiredService<ContAbonat>();

            if (subscriptionType == "Standard - 100 RON")
            {
                abonatStandard = new AbonatStandard(name, cnp, username, password);
                contAbonat.InitializeUser(abonatStandard);
                _abonatManager.AdaugaAbonatStandard(abonatStandard, username);
            }
            else if (subscriptionType == "Premium - 150 RON")
            {
                abonatPremium = new AbonatPremium(name, cnp, username, password);
                contAbonat.InitializeUser(abonatPremium);
                _abonatManager.AdaugaAbonatPremium(abonatPremium, username);
            }

            txtNume.Clear();
            txtCNP.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            textBox1.Clear();
            cmbSub.SelectedIndex = -1;

            MessageBox.Show("Utilizatorul a fost adaugat cu succes");
            this.Hide();

            contAbonat.ShowDialog();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
