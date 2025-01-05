using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public class AbonatPremium : AbonatStandard
    {
        public override string TipAbonament => "premium";

        public override int TaxaDepasireDurataProgramari => 2;

        public AbonatPremium(string numeComplet, string cnp, string username, string password)
            : base(numeComplet, cnp, username, password)
        {
            PretAbonament = 150;
        }


    }
}