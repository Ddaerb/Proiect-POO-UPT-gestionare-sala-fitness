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
    public partial class DetaliiProgramari : Form
    {
        private readonly AbonatManager _abonatManager;
        private readonly IServiceProvider _serviceProvider;
        private readonly ProgramareManager _programareManager;
        private readonly SalaFitness _salaFitness;
        private AbonatStandard _abonat;
        public DetaliiProgramari(AbonatManager abonatManager, IServiceProvider serviceProvider, ProgramareManager programareManager, SalaFitness salaFitness)
        {

            _abonatManager = abonatManager;
            _serviceProvider = serviceProvider;
            _programareManager = programareManager;
            _salaFitness = salaFitness;
            InitializeComponent();
        }

        public void InitializeIstoricList()
        {
            listView1.Items.Clear();
            var istoricProgramari = _abonat.IstoricProgramari;

            foreach (var programare in istoricProgramari)
            {
                var item = new ListViewItem(new string[]
                {
                    programare.Antrenor.NumeComplet.ToString(),
                    programare.Antrenor.Specializare.ToString(),
                    programare.Data.ToString(),
                    programare.DurataProgramataOre.ToString(),
                    programare.StatusProgramare.ToString()
                });
                listView1.Items.Add(item);
            }
        }
        public void InitializeUser(AbonatStandard abonat)
        {
            _abonat = abonat;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            var contAbonat = _serviceProvider.GetRequiredService<ContAbonat>();
            contAbonat.InitializeUser(_abonat);
            contAbonat.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            var adaugaProgramare = _serviceProvider.GetRequiredService<AdaugaProgramare>();
            adaugaProgramare.InitializeUser(_abonat);
            adaugaProgramare.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Te rog selecteaza o programare pentru a o modifica.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int selectedIndex = listView1.SelectedItems[0].Index;

            var programareSelectata = _abonat.IstoricProgramari[selectedIndex];

            if (programareSelectata.StatusProgramare == "anulata.")
            {
                MessageBox.Show("Nu poti modifica o programare anulata.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            this.Hide();

            var modificareProgramare = _serviceProvider.GetRequiredService<ModificareProgramare>();
            modificareProgramare.InitializeUser(_abonat);
            modificareProgramare.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int index = listView1.SelectedItems[0].Index;

                listView1.SelectedItems[0].SubItems[4].Text = "anulata.";

                _programareManager.AnuleazaProgramare(_abonat.Username, index);
            }
            else
            {
                MessageBox.Show("Te rog selecteaza o programare pentru a o anula.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DetaliiProgramari_Load(object sender, EventArgs e)
        {
            label1.Text = $"Daca depasiti orele [{_salaFitness.OraInceput:hh\\:mm},{_salaFitness.OraSfarsit:hh\\:mm}], se adauga o \r\n                              taxa de penalizare de {_abonat.TaxaDepasireDurataProgramari} RON/ora!!!";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
