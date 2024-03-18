class ParcoGiochi
{
    static void Main(string[] args)
    {
        List<(string, int)> attrazioniPerTutti = new List<(string, int)>();
        List<(string, int)> attrazioniPerAdulti = new List<(string, int)>();
        RiempiAttrazioni(attrazioniPerTutti, attrazioniPerAdulti);
        bool exit = false;
        int freeTicket = 3;
        int spesa = 0;
        System.Console.WriteLine("ciao e Bevenuto al Parco!");
        System.Console.Write("inserisci la tua età: ");
        int etaUtente = Convert.ToInt16(Console.ReadLine());
        while (!exit)
        {
            StampaAttrazioni(attrazioniPerTutti, attrazioniPerAdulti);
            System.Console.WriteLine("\nscegli l'attrazione in base al numero corrispondente o premi '0' per uscire dal parco");
            int scelta = Convert.ToInt16(Console.ReadLine());
            if (scelta == 0)
            {
                exit = true;
            }
            else
            {
                ScegliAttrazione(attrazioniPerTutti, attrazioniPerAdulti, etaUtente, scelta, ref freeTicket, ref spesa);
            }
        }
        StampaGiri(attrazioniPerTutti, attrazioniPerAdulti, ref spesa);

    }
    static void RiempiAttrazioni(List<(string, int)> attrazioniPerTutti, List<(string, int)> attrazioniPerAdulti)
    {
        // Attrazioni per tutti
        attrazioniPerTutti.Add(("Ruota panoramica", 0));
        attrazioniPerTutti.Add(("Carosello", 0));
        attrazioniPerTutti.Add(("Giro in trenino", 0));
        attrazioniPerTutti.Add(("Casa infestata", 0));
        // Attrazioni per adulti
        attrazioniPerAdulti.Add(("Montagne russe", 0));
        attrazioniPerAdulti.Add(("Salto con l'elastico", 0));
        attrazioniPerAdulti.Add(("Corsa in go-kart", 0));
        attrazioniPerAdulti.Add(("Escape room", 0));
    }
    static void StampaAttrazioni(List<(string, int)> attrazioniPerTutti, List<(string, int)> attrazioniPerAdulti)
    {
        System.Console.WriteLine("\nElenco attrazioni nel parco: ");
        System.Console.WriteLine("\tPER TUTTI:");
        for (int i = 0; i < attrazioniPerTutti.Count; i++)
        {
            System.Console.WriteLine($"{i + 1} - {attrazioniPerTutti[i].Item1}");
        }
        System.Console.WriteLine("\tSOLO PER ADULTI");
        for (int i = 0; i < attrazioniPerAdulti.Count; i++)
        {
            System.Console.WriteLine($"{i + attrazioniPerTutti.Count + 1} - {attrazioniPerAdulti[i].Item1}");
        }
    }
    static void ScegliAttrazione(List<(string, int)> attrazioniPerTutti, List<(string, int)> attrazioniPerAdulti, int eta, int scelta, ref int freeTicket, ref int spesa)
    {
        int index = scelta - 1;
        if (scelta < 1 || scelta > attrazioniPerTutti.Count + attrazioniPerAdulti.Count)
        {
            Console.WriteLine("\nScelta non valida.");
            return;
        }

        if (scelta <= attrazioniPerTutti.Count)
        {
            if (eta < 18 && scelta > attrazioniPerTutti.Count)
            {
                Console.WriteLine($"\nNon hai l'età adatta per salire su questa attrazione!\nHai ancora {freeTicket} ticket");
                return;
            }

            if (freeTicket > 0)
            {
                Console.WriteLine($"\nHai fatto un giro gratuito a {attrazioniPerTutti[index].Item1}");
                attrazioniPerTutti[index] = (attrazioniPerTutti[index].Item1, attrazioniPerTutti[index].Item2 + 1);
                freeTicket--;
                Console.WriteLine($"Ti restano: {freeTicket} ticket gratuiti");
            }
            else
            {
                Console.WriteLine($"\nHai fatto un giro a {attrazioniPerTutti[index].Item1} e non avendo altri ticket gratuiti ti sono stati addebitati 2€");
                attrazioniPerTutti[index] = (attrazioniPerTutti[index].Item1, attrazioniPerTutti[index].Item2 + 1);
                spesa += 2;
            }
        }
        else // Se la scelta è nell'elenco delle attrazioni per adulti
        {
            if (eta < 18)
            {
                Console.WriteLine($"\nNon hai l'età adatta per salire su questa attrazione!\nHai ancora {freeTicket} ticket");
                return;
            }

            index -= attrazioniPerTutti.Count;

            if (freeTicket > 0)
            {
                Console.WriteLine($"\nHai fatto un giro gratuito a {attrazioniPerAdulti[index].Item1}");
                attrazioniPerAdulti[index] = (attrazioniPerAdulti[index].Item1, attrazioniPerAdulti[index].Item2 + 1);
                freeTicket--;
                Console.WriteLine($"Ti restano: {freeTicket} ticket gratuiti");
            }
            else
            {
                Console.WriteLine($"\nHai fatto un giro a {attrazioniPerAdulti[index].Item1} e non avendo altri ticket gratuiti ti sono stati addebitati 2€");
                attrazioniPerAdulti[index] = (attrazioniPerAdulti[index].Item1, attrazioniPerAdulti[index].Item2 + 1);
                spesa += 2;
            }
        }
    }

    static void StampaGiri(List<(string, int)> attrazioniPerTutti, List<(string, int)> attrazioniPerAdulti, ref int spesa)
    {
        System.Console.WriteLine("\nHai finito il tuo giro per il parco!\nhai fatto le seguenti attrazioni: ");

        foreach (var a in attrazioniPerTutti)
        {
            if (a.Item2 > 0)
            {
                System.Console.WriteLine($"-{a.Item1}: {a.Item2} volte");
            }
        }
        foreach (var a in attrazioniPerAdulti)
        {
            if (a.Item2 > 0)
            {
                System.Console.WriteLine($"-{a.Item1}: {a.Item2} volte");
            }
        }
        System.Console.WriteLine($"e hai speso: {spesa}€\nGrazie e arrivederci");
    }

}