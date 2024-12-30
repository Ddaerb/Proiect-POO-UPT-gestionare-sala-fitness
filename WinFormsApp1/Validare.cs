namespace WinFormsApp1;
using System.Linq; //folosim metoda All din LINQ impreuna cu functia char.IsDigit pentru a verifica daca un string contine doar cifre
public class Validare
{
    public static string ValideazaNume(string input)
    {
        while (string.IsNullOrWhiteSpace(input) || !IsAlphabetic(input))
        {
            Console.WriteLine("Numele trebuie să conțină doar caractere alfabetice. Introdu din nou:");
            input = Console.ReadLine();
        }
        return input;
    }

    public static int ValideazaNumarIntreg(string input, int min, int max)
    {
        int rezultat;
        while (!int.TryParse(input, out rezultat) || rezultat < min || rezultat > max)
        {
            Console.WriteLine($"Introduceți un număr între {min} și {max}:");
            input = Console.ReadLine();
        }
        return rezultat;
    }

    public static TimeSpan ValideazaOra(string input)
    {
        TimeSpan ora;
        while (!TimeSpan.TryParse(input, out ora))
        {
            Console.WriteLine("Ora nu este într-un format valid (HH:MM). Introdu din nou:");
            input = Console.ReadLine();
        }
        return ora;
    }

    public static (TimeSpan, TimeSpan) ValideazaInterval(string oraInceputInput, string oraSfarsitInput)
    {
        TimeSpan oraInceput, oraSfarsit;

        oraInceput = ValideazaOra(oraInceputInput);
        oraSfarsit = ValideazaOra(oraSfarsitInput);

        while (oraInceput >= oraSfarsit)
        {
            Console.WriteLine("Ora de început trebuie să fie mai mică decât ora de sfârșit.");
            oraInceput = ValideazaOra(Console.ReadLine());
            oraSfarsit = ValideazaOra(Console.ReadLine());
        }
        return (oraInceput, oraSfarsit);
    }

    private static bool IsAlphabetic(string input)
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

    //Metoda pentru verificarea cnp-ului unui abonat
    public static bool VerificareCNP(string cnp)
    {
        return cnp.Length == 13 && cnp.All(char.IsDigit);
    }

    //Metoda pentru validarea unei date (sa nu fie mai mica ca data curenta si sa fie o data valida)
    public static bool ValidareData(DateTime data)
    {
        if (data.Day < 1 || data.Day > DateTime.DaysInMonth(data.Year, data.Month))
        {
            Console.WriteLine("Ziua introdusa nu este corecta");
            return false;
        }

        if (data.Month < 1 || data.Month > 12)
        {
            Console.WriteLine("Luna introdusa nu este corecta");
            return false;
        }

        if (data < DateTime.Now)
        {
            Console.WriteLine("Data nu trebuie sa fie in trecut");
            return false;
        }
        return true;
    }


}