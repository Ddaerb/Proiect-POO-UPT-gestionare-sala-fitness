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
        private readonly IServiceProvider _serviceProvider;
        public DetaliiProgramari(IServiceProvider serviceProvider)
        {
       
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            var contAbonat = _serviceProvider.GetRequiredService<ContAbonat>();
            contAbonat.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            var adaugaProgramare = _serviceProvider.GetRequiredService<AdaugaProgramare>();
            adaugaProgramare.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            var modificareProgramare = _serviceProvider.GetRequiredService<ModificareProgramare>();
            modificareProgramare.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
