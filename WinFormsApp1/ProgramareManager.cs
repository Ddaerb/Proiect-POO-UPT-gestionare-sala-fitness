using System;
using System.Collections.Generic;
using System.Linq;

namespace WinFormsApp1;

public class ProgramareManager
{
    private const string CaleFisier = "programari.json";
    public List<Programare> ListaProgramari { get; set; }
    private AbonatManager abonatManager; // Manager pentru gestionarea abonatilor

    public ProgramareManager()
    {
        var incarcate = JSONHelper.LoadFromFile<List<Programare>>(CaleFisier);
        if (incarcate != null)
        {
            ListaProgramari = incarcate;
        }
        else
        {
            ListaProgramari = new List<Programare>();
        }

        abonatManager = new AbonatManager(); // Initializare manager abonati
    }

    private AbonatStandard GasesteAbonatDupaUsername(string username)
    {
        // Cautare în abonati standard
        var abonatStandard = abonatManager.AbonatiStandard.FirstOrDefault(a => a.Username == username);
        if (abonatStandard != null)
        {
            return abonatStandard;
        }

        // Cautare în abonati premium
        var abonatPremium = abonatManager.AbonatiPremium.FirstOrDefault(a => a.Username == username);
        if (abonatPremium != null)
        {
            // Transformam abonatul premium intr-unul standard pentru procesare uniforma
            return new AbonatStandard(
                abonatPremium.NumeComplet,
                abonatPremium.CNP,
                abonatPremium.Username,
                abonatPremium.Password
            );
        }

        return null; // Nu a fost gasit abonatul
    }

    private void ActualizeazaFisierJSON()
    {
        JSONHelper.SaveToFile(CaleFisier, ListaProgramari);
    }

    public void AdaugaProgramare(Programare programare)
    {
        ListaProgramari.Add(programare);
        ActualizeazaFisierJSON();
    }

    public void ModificaProgramare(string username, int index, Programare programareNoua)
    {
        var programariAbonat = ListaProgramari.Where(p => p.AbonatUsername == username).ToList();
        if (index >= 0 && index < programariAbonat.Count)
        {
            var programareExistenta = programariAbonat[index];
            ListaProgramari.Remove(programareExistenta);
            ListaProgramari.Add(programareNoua);
            ActualizeazaFisierJSON();
        }
        else
        {
            Console.WriteLine("Index invalid pentru programare.");
        }
    }

    public void AnuleazaProgramare(string username, int index)
    {
        var programariAbonat = ListaProgramari.Where(p => p.AbonatUsername == username).ToList();
        if (index >= 0 && index < programariAbonat.Count)
        {
            var programareDeAnulat = programariAbonat[index];
            ListaProgramari.Remove(programareDeAnulat);
            ActualizeazaFisierJSON();
        }
        else
        {
            Console.WriteLine("Index invalid pentru anulare programare.");
        }
    }

    public void ListeazaProgramariDupaNumeAntrenor()
    {
        var programariOrdonate = ListaProgramari
            .OrderBy(p => p.Antrenor.NumeComplet)
            .ToList();

        foreach (var programare in programariOrdonate)
        {
            Console.WriteLine($"Antrenor: {programare.Antrenor.NumeComplet}, Abonat: {programare.AbonatUsername}, Data: {programare.Data}, Durata: {programare.DurataProgramataOre} ore");
        }
    }

    public void ListeazaProgramariDupaDurata()
    {
        var programariOrdonate = ListaProgramari
            .OrderBy(p => p.DurataProgramataOre)
            .ToList();

        foreach (var programare in programariOrdonate)
        {
            Console.WriteLine($"Durata: {programare.DurataProgramataOre} ore, Antrenor: {programare.Antrenor.NumeComplet}, Abonat: {programare.AbonatUsername}, Data: {programare.Data}");
        }
    }
}

