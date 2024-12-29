namespace WinFormsApp1;

public class AbonatStandard
{
    private string _numeComplet;
    private string _cnp;
    private string _username;
    private string _password;
    private string _tipAbonament;
    private int _pretAbonament;
    private int _taxaDepasireDurataProgramari;
    private List<Programare> _istoricProgramari;

    public string NumeComplet
    {
        get
        {
            return _numeComplet;
        }
        set
        {
            _numeComplet = value;
        }
    }

    public string CNP
    {
        get
        {
            return _cnp;
        }
        set
        {
            _cnp = value;
        }
    }

    public string Username
    {
        get
        {
            return _username;
        }
        set
        {
            _username = value;
        }
    }

    public string Password
    {
        get
        {
            return _password;
        }
        set
        {
            _password = value;
        }
    }

    public virtual string TipAbonament => "standard";
    public virtual int PretAbonament => 100;
    public virtual int TaxaDepasireDurataProgramari => 5;

    public List<Programare> IstoricProgramari
    {
        get
        {
            if (_istoricProgramari == null)
            {
                _istoricProgramari = new List<Programare>();
            }
            return _istoricProgramari;
        }
    }

    public AbonatStandard(string numeComplet, string cnp, string username, string password)
    {
        NumeComplet = numeComplet;
        CNP = cnp;
        Username = username;
        Password = password;
    }


}