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
    public partial class ContAbonat : Form
    {
        public ContAbonat()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            PaginaPrincipala paginaPrincipala = new PaginaPrincipala();
            paginaPrincipala.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            DetaliiCont detaliiCont = new DetaliiCont();
            detaliiCont.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            DetaliiProgramari detaliiProgramari = new DetaliiProgramari();
            detaliiProgramari.ShowDialog();
        }
    }
}
