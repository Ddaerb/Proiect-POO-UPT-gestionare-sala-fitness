namespace WinFormsApp2;

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