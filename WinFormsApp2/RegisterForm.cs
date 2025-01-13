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
        public RegisterForm()
        {
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
            string confirmPassword = txtConfirmPassword.Text;
            string subscriptionType = cmbSub.Text;
            Validare validare = new Validare();

            if (name == null || name == "") 
            {
                MessageBox.Show("Name Field is required");
            }
   
            string numeNou= validare.ValideazaNumeComplet(name);
            txtNume.Text = numeNou;

            if (cnp == null || cnp == "")
            {
                MessageBox.Show("CNP Field is required");
            }

            string cnpNou= validare.VerificareCNP(cnp);
            txtCNP.Text = cnpNou;

            if (username == null || username == "")
            {
                MessageBox.Show("Username Field is required");
            }

            if (password == null || password == "")
            {
                MessageBox.Show("Password Field is required");
            }

            if (confirmPassword == null || confirmPassword == "")
            {
                MessageBox.Show("Confirm Password Field is required");
            }

            if (password == confirmPassword) 
            {
                MessageBox.Show("Passwords doesn't match");
            }

            if (subscriptionType == null || subscriptionType == "")
            {
                MessageBox.Show("Type of Subscription Field is required");
            }

        }
    }
}
