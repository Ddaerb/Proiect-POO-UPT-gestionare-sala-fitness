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
    public partial class DetaliiAbonatiAdmin : Form
    {

        private readonly AbonatManager _abonatManager;
        private readonly IServiceProvider _serviceProvider;
        public DetaliiAbonatiAdmin(AbonatManager abonatManager, IServiceProvider serviceProvider)
        {
            _abonatManager = abonatManager;
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        public void InitializeProgramariList()
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
            var abonatiStandard = _abonatManager.AbonatiStandard;
            var abonatiPremium = _abonatManager.AbonatiPremium;

            foreach (var abonatStd in abonatiStandard)
            {
                var item = new ListViewItem(new string[]
                {
                    abonatStd.NumeComplet.ToString(),
                    abonatStd.CNP.ToString(),
                    abonatStd.Username.ToString(),
                    abonatStd.TipAbonament.ToString(),
                    abonatStd.PretAbonament.ToString(),

                });
                listView1.Items.Add(item);
            }

            foreach (var abonatPrm in abonatiPremium)
            {
                var item = new ListViewItem(new string[]
                {
                    abonatPrm.NumeComplet.ToString(),
                    abonatPrm.CNP.ToString(),
                    abonatPrm.Username.ToString(),
                    abonatPrm.TipAbonament.ToString(),
                    abonatPrm.PretAbonament.ToString(),

                });
                listView2.Items.Add(item);
            }
        }

        private void DetaliiAbonatiAdmin_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            var contAdmin = _serviceProvider.GetRequiredService<ContAdmin>();
            contAdmin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var index = listView1.SelectedIndices[0]; 
                _abonatManager.StergeAbonatStandard(index); 
                InitializeProgramariList(); 
                return;
            }

            if (listView2.SelectedItems.Count > 0)
            {
                var index = listView2.SelectedIndices[0]; 
                _abonatManager.StergeAbonatPremium(index); 
                InitializeProgramariList(); 
                return;
            }

            MessageBox.Show("Va rugam sa selectati un abonat pentru a-l sterge.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        

    }
}
