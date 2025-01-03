using System.Data;

namespace WinFormsApp1;
using System.Linq; //folosim metoda All din LINQ impreuna cu functia char.IsDigit pentru a verifica daca un string contine doar cifre

public class Validare
{
    public string ValideazaNume(string input)
    {
        while (string.IsNullOrWhiteSpace(input) || !IsAlphabetic(input))
        {
            Console.WriteLine("Numele trebuie sa contina doar caractere alfabetice. Introdu din nou:");
            input = Console.ReadLine();
        }
        return input;
    }

    public int ValideazaNrClienti(string input)
    {
        int rezultat;
        while (!int.TryParse(input, out rezultat) || rezultat < 1 || rezultat > 10)
        {
            Console.WriteLine($"Introduceti un numar intre 1 si 10:");
            input = Console.ReadLine();
        }
        return rezultat;
    }

    public TimeSpan ValideazaOra(string input)
    {
        TimeSpan ora;
        while (!TimeSpan.TryParse(input, out ora))
        {
            Console.WriteLine("Ora nu este intr-un format valid (HH:MM:SS). Introdu din nou:");
            input = Console.ReadLine();
        }
        return ora;
    }

    public (TimeSpan, TimeSpan) ValideazaInterval(string oraInceputInput, string oraSfarsitInput)
    {
        TimeSpan oraInceput, oraSfarsit;

        oraInceput = ValideazaOra(oraInceputInput);
        oraSfarsit = ValideazaOra(oraSfarsitInput);

        while (oraInceput >= oraSfarsit)
        {
            Console.WriteLine("Ora de inceput trebuie sa fie mai mica decat ora de sfarsit.");
            oraInceput = ValideazaOra(Console.ReadLine());
            oraSfarsit = ValideazaOra(Console.ReadLine());
        }
        return (oraInceput, oraSfarsit);
    }

    private bool IsAlphabetic(string input)
    {
        foreach (char c in input)
        {
            if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
            {
                return false;
            }
        }
        return true;
    }

    //metoda pentru verificarea cnp-ului unui abonat
    public string VerificareCNP(string cnp)
    {
        while (!(cnp.Length == 13) || !(cnp.All(char.IsDigit)))
        {
            Console.WriteLine("CNP-ul nu este intr-un format valid.");
            cnp = Console.ReadLine();
        }
        return cnp;
    }

    //Metoda pentru validarea unei date (sa nu fie mai mica ca data curenta si sa fie o data valida)
    public DateTime ValidareData(string dataInput)
    {
        DateTime data;

        if (!DateTime.TryParse(dataInput, out data))
        {
            Console.WriteLine("Formatul introdus nu este corect. Introduceti o data valida (ex. 'YYYY/MM/DD').");
            return ValidareData(Console.ReadLine());
        }

        if (data.Day < 1 || data.Day > DateTime.DaysInMonth(data.Year, data.Month))
        {
            Console.WriteLine("Ziua introdusa nu este corecta.");
            return ValidareData(Console.ReadLine());
        }

        if (data.Month < 1 || data.Month > 12)
        {
            Console.WriteLine("Luna introdusa nu este corecta.");
            return ValidareData(Console.ReadLine());
        }

        if (data < DateTime.Now)
        {
            Console.WriteLine("Data nu trebuie sa fie in trecut.");
            return ValidareData(Console.ReadLine());
        }

        return data;
    }

    public string ValideazaNumeComplet(string input)
    {
        while (!IsAlphabetic(input))
        {
            Console.WriteLine("Numele complet trebuie sa contina doar caractere alfabetice. Introdu din nou:");
            input = Console.ReadLine();
        }
        return input;
    }

}