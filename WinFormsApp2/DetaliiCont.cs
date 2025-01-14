using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Serilog;

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

            if (_abonat.TipAbonament == "standard")
            {
                btnStandard.Visible = true;
                btbPremium.Visible = false;
            }
            else if (_abonat.TipAbonament == "premium")
            {
                btnStandard.Visible = false;
                btbPremium.Visible = true;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            var contAbonat = _serviceProvider.GetRequiredService<ContAbonat>();
            contAbonat.InitializeUser(_abonat);
            contAbonat.Show();
        }

        private void DetaliiCont_Load(object sender, EventArgs e)
        {
            Log.Information("DetaliiCont incarcata cu succes.");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string parolaNoua = PromptForInput("Introduceti parola noua:");
            while (_abonat.Password == parolaNoua)
            {
                MessageBox.Show("Noua parola nu poate fi la fel cu cea veche!");
                Log.Error("Noua parola este la fel cu cea veche.");
                parolaNoua = PromptForInput("Introduceti parola noua:");
            }
            _abonatManager.SchimbareParola(_abonat.Username, _abonat.Password, parolaNoua);
            Log.Information("Parola schimbata cu succes.");
        }

        private string PromptForInput(string message)
        {
            using (var prompt = new Form())
            {
                prompt.Width = 400;
                prompt.Height = 150;
                prompt.Text = "Input";

                Label textLabel = new Label() { Left = 10, Top = 20, Text = message, Width = 360 };
                TextBox inputBox = new TextBox() { Left = 10, Top = 50, Width = 360 };
                Button confirmation = new Button() { Text = "OK", Left = 150, Width = 100, Top = 80, DialogResult = DialogResult.OK };

                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(inputBox);
                prompt.Controls.Add(confirmation);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : string.Empty;
            }
        }

        private void btnStandard_Click(object sender, EventArgs e)
        {
            _abonatManager.PromoveazaAbonatStandard(_abonat.CNP);
            _abonat = _abonatManager.GasesteAbonatDupaUsername(_abonat.Username);
            InitializeUser(_abonat);
            MessageBox.Show("Abonament promovat cu succes!");
            Log.Information("Abonament promovat cu succes.");
        }

        private void btbPremium_Click(object sender, EventArgs e)
        {
            _abonatManager.RetrogradeazaAbonatPremium(_abonat.CNP);
            _abonat = _abonatManager.GasesteAbonatDupaUsername(_abonat.Username);
            InitializeUser(_abonat);
            MessageBox.Show("Abonament retogradat cu succes!");
            Log.Information("Abonament retrogradat cu succes.");
        }

        private void btnStergereCont_Click(object sender, EventArgs e)
        {
            if (_abonat.TipAbonament == "standard")
            {
                _abonatManager.AbonatiStandard.Remove(_abonat);
                JSONHelper.SaveToFile(_abonatManager.standardFilePath, _abonatManager.AbonatiStandard);
                MessageBox.Show("Contul a fost sters cu succes!");
                Log.Information("Contul a fost sters cu succes.");

            }
            if (_abonat.TipAbonament == "premium")
            {
                var abonatPremium = _abonat as AbonatPremium;
                if (abonatPremium != null)
                {
                    _abonatManager.AbonatiPremium.Remove(abonatPremium);
                    JSONHelper.SaveToFile(_abonatManager.premiumFilePath, _abonatManager.AbonatiPremium);
                    MessageBox.Show("Contul a fost sters cu succes!");
                    Log.Information("Contul a fost sters cu succes.");
                }

            }
            this.Close();

            var paginaPrincipala = _serviceProvider.GetRequiredService<PaginaPrincipala>();
            paginaPrincipala.Show();
        }

    }
}
