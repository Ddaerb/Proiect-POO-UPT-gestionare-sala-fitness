namespace WinFormsApp1;

public class Antrenor
{
    public string NumeComplet { get; private set; }
    public string Specializare { get; private set; }
    public int NumarMaximClienti { get; private set; }
    public (TimeSpan OraInceput, TimeSpan OraSfarsit) OrarePrestabilit { get; private set; }

    public Antrenor(string numeComplet, string specializare, int numarMaximClienti, TimeSpan oraInceput, TimeSpan oraSfarsit)
    {
        NumeComplet = numeComplet;
        Specializare = specializare;
        NumarMaximClienti = numarMaximClienti;
        OrarePrestabilit = (oraInceput, oraSfarsit);
    }
}