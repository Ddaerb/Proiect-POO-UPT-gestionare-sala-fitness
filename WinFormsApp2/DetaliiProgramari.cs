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
        public DetaliiProgramari()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            ContAbonat contAbonat = new ContAbonat();
            contAbonat.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            AdaugaProgramare adaugaProgramare = new AdaugaProgramare();
            adaugaProgramare.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            ModificareProgramare modificareProgramare = new ModificareProgramare();
            modificareProgramare.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
