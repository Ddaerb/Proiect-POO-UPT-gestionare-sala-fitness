namespace WinFormsApp2;

public class Programare
{
    private string _abonatUsername;
    public string AbonatUsername
    {
        get { return _abonatUsername; }
        set { _abonatUsername = value; }
    }

    private Antrenor _antrenor;

    public Antrenor Antrenor
    {
        get { return _antrenor; }
        set { _antrenor = value; }
    }

    private DateTime _data;

    public DateTime Data
    {
        get { return _data; }
        set { _data = value; }
    }

    private int _durataProgramataOre;

    public int DurataProgramataOre
    {
        get { return _durataProgramataOre; }
        set { _durataProgramataOre = value; }
    }

    private string _statusProgramare;

    public string StatusProgramare
    {
        get { return _statusProgramare; }
        set { _statusProgramare = value; }
    }

    public Programare(string abonatUsername, Antrenor antrenor, DateTime data, int durataProgramataOre)
    {
        AbonatUsername = abonatUsername;
        Antrenor = antrenor;
        Data = data;
        DurataProgramataOre = durataProgramataOre;
        StatusProgramare = "Valida.";
    }
}