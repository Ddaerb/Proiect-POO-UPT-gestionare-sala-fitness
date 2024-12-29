namespace WinFormsApp1;

public class Validare
{
    public static string ValideazaNume(string input)
    {
        while (string.IsNullOrWhiteSpace(input) || !IsAlphabetic(input))
        {
            Console.WriteLine("Numele trebuie sa contina doar caractere alfabetice. Introdu din nou:");
            input = Console.ReadLine();
        }
        return input;
    }

    public static int ValideazaNumarIntreg(string input, int min, int max)
    {
        int rezultat;
        while (!int.TryParse(input, out rezultat) || rezultat < min || rezultat > max)
        {
            Console.WriteLine($"Introduceti un numar intre {min} si {max}:");
            input = Console.ReadLine();
        }
        return rezultat;
    }

    public static TimeSpan ValideazaOra(string input)
    {
        TimeSpan ora;
        while (!TimeSpan.TryParse(input, out ora))
        {
            Console.WriteLine("Ora nu este intr-un format valid (HH:MM). Introdu din nou:");
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
            Console.WriteLine("Ora de inceput trebuie sa fie mai mica decat ora de sfarsit.");
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
}