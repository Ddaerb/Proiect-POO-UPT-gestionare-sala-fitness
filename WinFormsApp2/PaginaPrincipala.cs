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
    public partial class PaginaPrincipala : Form
    {
        public PaginaPrincipala()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ToLoginButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 loginForm = new Form1();
            loginForm.ShowDialog();
        }

        private void ToRegisterButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
