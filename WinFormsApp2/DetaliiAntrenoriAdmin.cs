using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Serilog;

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
                    "["+antrenor.OrarPrestabilit.OraInceput.ToString()+"-"+antrenor.OrarPrestabilit.OraSfarsit.ToString()+"]"

                });
                listView1.Items.Add(item);
            }
        }

        private void DetaliiAntrenoriAdmin_Load(object sender, EventArgs e)
        {
            Log.Information("DetaliiAntrenoriAdmin incarcata cu succes.");
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];
                string numeComplet = selectedItem.SubItems[0].Text;
                string specializare = selectedItem.SubItems[1].Text;

                var antrenor = _antrenorManager.ListaAntrenori.FirstOrDefault(a => a.NumeComplet == numeComplet && a.Specializare == specializare);

                if (antrenor != null)
                {
                    _antrenorManager.StergeAntrenor(antrenor);
                    listView1.Items.Remove(selectedItem);
                    Log.Information("Antrenorul a fost sters cu succes.");
                }
                else
                {
                    MessageBox.Show("Antrenorul selectat nu mai exista.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.Error("Antrenorul selectat nu mai exista.");
                }
            }
            else
            {
                MessageBox.Show("Te rog selecteaza un antrenor pentru a-l sterge.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("Nu a fost selectat niciun antrenor pentru stergere.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string numeComplet = Microsoft.VisualBasic.Interaction.InputBox("Introduceti numele complet al antrenorului:", "Cautare Antrenor");
            string specializare = Microsoft.VisualBasic.Interaction.InputBox("Introduceti specializarea antrenorului:", "Cautare Antrenor");

            if (string.IsNullOrWhiteSpace(numeComplet) || string.IsNullOrWhiteSpace(specializare))
            {
                MessageBox.Show("Ambele campuri trebuie completate pentru a cauta un antrenor.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("Ambele campuri trebuie completate pentru a cauta un antrenor.");
                return;
            }
            foreach (ListViewItem item in listView1.Items)
            {
                string itemNumeComplet = item.SubItems[0].Text;
                string itemSpecializare = item.SubItems[1].Text;

                if (itemNumeComplet.Equals(numeComplet, StringComparison.OrdinalIgnoreCase) &&
                    itemSpecializare.Equals(specializare, StringComparison.OrdinalIgnoreCase))
                {
                    listView1.SelectedItems.Clear();
                    item.Selected = true;
                    item.EnsureVisible();
                    MessageBox.Show($"Antrenorul '{numeComplet}' cu specializarea '{specializare}' a fost gasit si selectat.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Log.Information($"Antrenorul '{numeComplet}' cu specializarea '{specializare}' a fost gasit si selectat.");
                    return;
                }
            }
            MessageBox.Show($"Antrenorul '{numeComplet}' cu specializarea '{specializare}' nu a fost gasit.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Log.Error($"Antrenorul '{numeComplet}' cu specializarea '{specializare}' nu a fost gasit.");
            return;
        }
    }
}
