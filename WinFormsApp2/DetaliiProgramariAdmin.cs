using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Serilog;

namespace WinFormsApp2
{
    public partial class DetaliiProgramariAdmin : Form
    {
        private readonly AbonatManager _abonatManager;
        private readonly IServiceProvider _serviceProvider;
        private readonly ProgramareManager _programareManager;
        private readonly SalaFitness _salaFitness;
        public DetaliiProgramariAdmin(AbonatManager abonatManager, IServiceProvider serviceProvider, ProgramareManager programareManager, SalaFitness salaFitness)
        {
            _abonatManager = abonatManager;
            _serviceProvider = serviceProvider;
            _programareManager = programareManager;
            _salaFitness = salaFitness;
            InitializeComponent();
        }

        public void InitializeProgramariList()
        {
            listView1.Items.Clear();
            var programari = _programareManager.ListaProgramari;

            foreach (var programare in programari)
            {
                var item = new ListViewItem(new string[]
                {
                    programare.AbonatUsername.ToString(),
                    programare.Antrenor.NumeComplet.ToString(),
                    programare.Data.ToString(),
                    programare.DurataProgramataOre.ToString(),
                    programare.StatusProgramare.ToString()

                });
                listView1.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Te rog selecteaza o programare pentru a o anula.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error("Nu a fost selectata nicio programare pentru anulare.");
                return;
            }

            var selectedItem = listView1.SelectedItems[0];
            string username = selectedItem.SubItems[0].Text;
            string data = selectedItem.SubItems[2].Text;

            var abonatStd = _abonatManager.AbonatiStandard.FirstOrDefault(a => a.Username == username);
            var abonatPrm = _abonatManager.AbonatiPremium.FirstOrDefault(a => a.Username == username);

            if (abonatStd != null)
            {
                var programare = abonatStd.IstoricProgramari.FirstOrDefault(p => p.AbonatUsername == username && p.Data.ToString() == data);
                if (programare != null)
                {
                    int index = -1;

                    for (int i = 0; i < abonatStd.IstoricProgramari.Count; i++)
                    {
                        var programare2 = abonatStd.IstoricProgramari[i];
                        if (programare2.AbonatUsername == username && programare.Data.ToString() == data)
                        {
                            index = i;
                            break;
                        }
                    }
                    if (index != -1)
                    {
                        _programareManager.AnuleazaProgramare(username, index);
                        listView1.Items.Remove(selectedItem);
                        Log.Information("Programare anulata cu succes.");
                    }
                    else
                    {
                        MessageBox.Show("Indexul programării selectate nu a fost găsit în istoricul abonatului.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Log.Error("Indexul programarii selectate nu a fost gasit in istoricul abonatului.");
                    }
                    return;
                }
            }
            else if (abonatPrm != null)
            {
                var programare = abonatPrm.IstoricProgramari.FirstOrDefault(p => p.AbonatUsername == username && p.Data.ToString() == data);
                if (programare != null)
                {
                    int index = -1;

                    for (int i = 0; i < abonatPrm.IstoricProgramari.Count; i++)
                    {
                        var programare2 = abonatPrm.IstoricProgramari[i];
                        if (programare2.AbonatUsername == username && programare.Data.ToString() == data)
                        {
                            index = i;
                            break;
                        }
                    }
                    if (index != -1)
                    {
                        _programareManager.AnuleazaProgramare(username, index);
                        listView1.Items.Remove(selectedItem);
                        Log.Information("Programare anulata cu succes.");
                    }
                    else
                    {
                        MessageBox.Show("Indexul programării selectate nu a fost găsit în istoricul abonatului.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Log.Error("Indexul programarii selectate nu a fost gasit in istoricul abonatului.");
                    }
                    return;
                }
            }

            MessageBox.Show("Abonatul sau programarea selectată nu au fost găsite.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Log.Error("Abonatul sau programarea selectata nu au fost gasite.");

        }

        private void DetaliiProgramariAdmin_Load(object sender, EventArgs e)
        {
            Log.Information("DetaliiProgramariAdmin incarcata cu succes.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            var contAdmin = _serviceProvider.GetRequiredService<ContAdmin>();
            contAdmin.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            var programari = _programareManager.ListaProgramari.OrderBy(p => p.Antrenor.NumeComplet).ToList();
            foreach (var programare in programari)
            {
                var item = new ListViewItem(new string[]
                {
                    programare.AbonatUsername.ToString(),
                    programare.Antrenor.NumeComplet.ToString(),
                    programare.Data.ToString(),
                    programare.DurataProgramataOre.ToString(),
                    programare.StatusProgramare.ToString()

                });
                listView1.Items.Add(item);
            }
            Log.Information("Programarile au fost sortate dupa numele antrenorului.");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            var programari = _programareManager.ListaProgramari.OrderBy(p => p.DurataProgramataOre).ToList();
            foreach (var programare in programari)
            {
                var item = new ListViewItem(new string[]
                {
                    programare.AbonatUsername.ToString(),
                    programare.Antrenor.NumeComplet.ToString(),
                    programare.Data.ToString(),
                    programare.DurataProgramataOre.ToString(),
                    programare.StatusProgramare.ToString()

                });
                listView1.Items.Add(item);
            }
            Log.Information("Programarile au fost sortate dupa durata programarii.");
        }
    }
}
