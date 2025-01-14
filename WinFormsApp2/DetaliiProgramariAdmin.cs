using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

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
                    programare.Antrenor.ToString(),
                    programare.Data.ToString(),
                    programare.DurataProgramataOre.ToString(),
                    programare.StatusProgramare.ToString()

                });
                listView1.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void DetaliiProgramariAdmin_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            var contAdmin = _serviceProvider.GetRequiredService<ContAdmin>();
            contAdmin.Show();
        }
    }
}
