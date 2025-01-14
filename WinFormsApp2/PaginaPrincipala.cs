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
    public partial class PaginaPrincipala : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public PaginaPrincipala(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ToLoginButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var login = _serviceProvider.GetRequiredService<Form1>();
            login.Show();
        }

        private void ToRegisterButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var registerForm = _serviceProvider.GetRequiredService<RegisterForm>();
            registerForm.Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PaginaPrincipala_Load(object sender, EventArgs e)
        {
            var contAbonat = _serviceProvider.GetRequiredService<ContAbonat>();
            contAbonat.FormClosed += (s, args) => this.Show();
        }
    }
}
