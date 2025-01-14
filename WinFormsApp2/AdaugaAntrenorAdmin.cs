using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Serilog;

namespace WinFormsApp2
{
    public partial class AdaugaAntrenorAdmin : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly AntrenorManager _antrenorManager;
        private Validare validare = new Validare();
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
            Log.Information("AdaugaAntrenorAdmin incarcata cu succes.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            var detaliiAntrenoriAdmin = _serviceProvider.GetRequiredService<DetaliiAntrenoriAdmin>();
            detaliiAntrenoriAdmin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("Toate campurile trebuie completate.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.Error("Unul sau mai multe campuri nu au fost completate.");
                    return;
                }

                if (!int.TryParse(textBox3.Text, out int nrMaximClienti) || nrMaximClienti <= 0)
                {
                    MessageBox.Show("Numarul maxim de clienti trebuie sa fie un numar pozitiv.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.Error("Numarul maxim de clienti trebuie sa fie un numar pozitiv.");
                    return;
                }

                string numeComplet = validare.ValideazaNumeComplet(textBox1.Text);
                textBox1.Text = numeComplet;
                string specializare = validare.ValideazaSpecializare(textBox2.Text);
                textBox2.Text = specializare;
                TimeSpan oraInceput = new TimeSpan(dateTimePicker1.Value.Hour, dateTimePicker1.Value.Minute, dateTimePicker1.Value.Second);
                TimeSpan oraSfarsit = new TimeSpan(dateTimePicker2.Value.Hour, dateTimePicker2.Value.Minute, dateTimePicker2.Value.Second);

                if (oraInceput > oraSfarsit)
                {
                    MessageBox.Show("Ora de inceput nu poate fi mai mare decat ora de sfarsit.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.Error("Ora de inceput nu poate fi mai mare decat ora de sfarsit.");
                    return;
                }

                var antrenor = new Antrenor
                {
                    NumeComplet = numeComplet,
                    Specializare = specializare,
                    NumarMaximClienti = nrMaximClienti,
                    OrarPrestabilit = new Orar
                    {
                        OraInceput = oraInceput,
                        OraSfarsit = oraSfarsit
                    }
                };

                _antrenorManager.AdaugaAntrenor(antrenor);

                MessageBox.Show($"Antrenorul '{numeComplet}' a fost adaugat cu succes.", "Informatie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Log.Information($"Antrenorul '{numeComplet}' a fost adaugat cu succes.");

                this.Hide();
                var detaliiAntrenoriAdmin = _serviceProvider.GetRequiredService<DetaliiAntrenoriAdmin>();
                detaliiAntrenoriAdmin.InitializeAntrenoriList();
                detaliiAntrenoriAdmin.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"A aparut o eroare: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "A aparut o eroare.");
            }
        }
    }
}
