using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static DnD_Hra.Recepty;
using static DnD_Hra.VytvorenePredmety;
using static System.Console;
using static DnD_Hra.DndHerniFunkce;

namespace DnD_Hra
{
    internal static class TvrobaPredmetu
    {
        private static int _PocetVylepseniZbrane(Zbrane z)
        {
            return z.pocetVylepseniPredmetu;
        }

        private static int _PocetVylepseniZbroje(Zbroje z)
        {
            return z.pocetVylepseniPredmetu;
        }

        //ZACATEK RECEPTU A JEJICH LISTU

        //zbrane
        private static readonly Recepty RMeč = new Recepty(Meč.nazevPredmetu, Meč, Železný_Ingot, 2, TypVyroby.Kovarna, null, null);
        private static readonly Recepty RDýka = new Recepty(Dýka.nazevPredmetu, Dýka, Železný_Ingot, 1, TypVyroby.Kovarna, null, null);
        private static readonly Recepty RLuk = new Recepty(Luk.nazevPredmetu, Luk, Dřevo, 2, TypVyroby.Kovarna, null, null);
        private static readonly Recepty RMagická_Hůl = new Recepty(Magická_Hůl.nazevPredmetu, Magická_Hůl, Dřevo, 2, TypVyroby.Kovarna, Manový_Krystal, 1);
        private static readonly Recepty ROhnivá_Koule = new Recepty(Ohnivá_Koule.nazevPredmetu, Ohnivá_Koule, Ohnivý_Prach, 1, TypVyroby.Kovarna, Dračí_Květ, 1);
        private static readonly Recepty RKrumpáč = new Recepty(Krumpáč.nazevPredmetu, Krumpáč, Železný_Ingot, 1, TypVyroby.Kovarna, Dřevo, 1);
        private static readonly Recepty RHalapartna = new Recepty(Halapartna.nazevPredmetu, Halapartna, Železný_Ingot, 2, TypVyroby.Kovarna, Dřevo, 1);
        
        // zbraně k unlocku
        public static readonly Recepty RŠťastlivcovo_Žihadlo = new Recepty(Štastlivcovo_Žihadlo.nazevPredmetu, Štastlivcovo_Žihadlo, Železný_Ingot, 1, TypVyroby.Kovarna, Zvláštní_Čtyřlístek, 1);
        public static readonly Recepty RSmaragdové_Kopí = new Recepty(Smaragdové_Kopí.nazevPredmetu, Smaragdové_Kopí, Dřevo, 1, TypVyroby.Kovarna, Smaragd, 1);
        public static readonly Recepty RProkletáČepel = new Recepty(Prokletá_Čepel.nazevPredmetu, Prokletá_Čepel, Železný_Ingot, 1, TypVyroby.Kovarna, Temná_Esence, 1);
        public static readonly Recepty RSrp_Vetešnice = new Recepty(Srp_Vetešnice.nazevPredmetu, Srp_Vetešnice, Železný_Ingot, 1, TypVyroby.Kovarna, Zvláštní_Čtyřlístek, 1);
        public static readonly Recepty RFletna_Krale_Koboldu = new Recepty(Fletna_Krale_Koboldu.nazevPredmetu, Fletna_Krale_Koboldu, Dřevo, 1, TypVyroby.Kovarna, Silovník_Šedý, 1);
        public static readonly Recepty RHarfa_Cisare_Koboldu = new Recepty(Harfa_Cisare_Koboldu.nazevPredmetu, Harfa_Cisare_Koboldu, Dřevo, 1, TypVyroby.Kovarna, Silovník_Šedý, 1);
        public static readonly Recepty RPalcat_Odporu_Smrti = new Recepty(Palcat_Odporu_Smrti.nazevPredmetu, Palcat_Odporu_Smrti, Železný_Ingot, 1, TypVyroby.Kovarna, Měsíční_Erb, 1);
        public static readonly Recepty RHul_Odporu_Smrti = new Recepty(Hul_Odporu_Smrti.nazevPredmetu, Hul_Odporu_Smrti, Dřevo, 1, TypVyroby.Kovarna, Osvícená_Smůla, 1);
        public static readonly Recepty RPekelny_Bic = new Recepty(Pekelny_Bič.nazevPredmetu, Pekelny_Bič, Látka, 2, TypVyroby.Kovarna, Dračí_Květ, 1);
        public static readonly Recepty RKrucifix_Naruby = new Recepty(Krucifix_Naruby.nazevPredmetu, Krucifix_Naruby, Smaragd, 1, TypVyroby.Kovarna, Temná_Esence, 1);
        //zbroje
        private static readonly Recepty RŽelezná_Zbroj = new Recepty(Železná_Zbroj.nazevPredmetu, Železná_Zbroj, Železný_Ingot, 2, TypVyroby.Kovarna, Kůže, 1);
        private static readonly Recepty RKožená_Zbroj = new Recepty(Kožená_Zbroj.nazevPredmetu, Kožená_Zbroj, Kůže, 2, TypVyroby.Kovarna, Látka, 1);
        private static readonly Recepty RLátková_Zbroj = new Recepty(Látková_Zbroj.nazevPredmetu, Látková_Zbroj, Látka, 3, TypVyroby.Kovarna, null, null);
        //zbroje k unlocku
        public static Recepty RTrnova_Useň = new Recepty(Trnová_Useň.nazevPredmetu, Trnová_Useň, Kůže, 1, TypVyroby.Kovarna, Houba_Bodavka, 1);
        public static Recepty RLichovoRoucho = new Recepty(Lichovo_Roucho.nazevPredmetu, Lichovo_Roucho, Látka, 2, TypVyroby.Kovarna, Temná_Esence, 1);
        public static Recepty RTunika_Vetešnice = new Recepty(Tunika_Vetešnice.nazevPredmetu, Tunika_Vetešnice, Látka, 1, TypVyroby.Kovarna, Zvláštní_Čtyřlístek, 1);
        public static Recepty RPekelné_Pláty = new Recepty(Pekelne_Platy.nazevPredmetu, Pekelne_Platy, Železný_Ingot, 2, TypVyroby.Kovarna, Ohnivý_Prach, 1);
        //pouzitelne
        private static readonly Recepty RLektvar_Zdraví = new Recepty(Lektvar_Zdraví.nazevPredmetu, Lektvar_Zdraví, Křídlo_Červeného_Motýla, 1, TypVyroby.Alchymie, Květina_Astra, 1);
        private static readonly Recepty RLektvar_Many = new Recepty(Lektvar_Many.nazevPredmetu, Lektvar_Many, Křídlo_Modrého_Motýla, 1, TypVyroby.Alchymie, Květina_Astra, 1);
        private static readonly Recepty RLektvar_Síly = new Recepty(Lektvar_Síly.nazevPredmetu, Lektvar_Síly, Silovník_Šedý, 1, TypVyroby.Alchymie, Květina_Astra, 1);
        private static readonly Recepty RJed = new Recepty(Jed.nazevPredmetu, Jed, Houba_Bodavka, 1, TypVyroby.Alchymie, Květina_Astra, 1);
        private static readonly Recepty RLektvar_Obratnosti = new Recepty(Lektvar_Obratnosti.nazevPredmetu, Lektvar_Obratnosti, Květina_Astra, 2, TypVyroby.Alchymie, null, null);
        private static readonly Recepty RLektvar_Inteligence = new Recepty(Lektvar_Inteligence.nazevPredmetu, Lektvar_Inteligence, Květina_Astra, 1, TypVyroby.Alchymie, Ohnivý_Prach, 1);
        private static readonly Recepty RLektvar_Stesti = new Recepty(Lektvar_Stesti.nazevPredmetu, Lektvar_Stesti, Květina_Astra, 1, TypVyroby.Alchymie, Zvláštní_Čtyřlístek, 1);
        private static readonly Recepty RLektvar_Utocnika = new Recepty(Lektvar_Utocnika.nazevPredmetu, Lektvar_Utocnika, Květina_Astra, 2, TypVyroby.Alchymie, Silovník_Šedý, 2);
        private static readonly Recepty RLektvar_Obrance = new Recepty(Lektvar_Obrance.nazevPredmetu, Lektvar_Obrance, Křídlo_Červeného_Motýla, 2, TypVyroby.Alchymie, Křídlo_Modrého_Motýla, 2);
        private static readonly Recepty RLektvar_Neskodnosti = new Recepty(Lektvar_Neskodnosti.nazevPredmetu, Lektvar_Neskodnosti, Temná_Esence, 2, TypVyroby.Alchymie, Silovník_Šedý, 2);
        private static readonly Recepty RLektvar_Prurazu = new Recepty(Lektvar_Prurazu.nazevPredmetu, Lektvar_Prurazu, Temná_Esence, 2, TypVyroby.Alchymie, Houba_Bodavka, 2);
        //pozitelne k unlocku
        public static readonly Recepty RLektvar_Vzkříšení = new Recepty(Lektvar_Vzkříšení.nazevPredmetu, Lektvar_Vzkříšení, Temná_Esence, 5, TypVyroby.Alchymie, Silovník_Šedý, 5);
        public static readonly Recepty RElixír_Časoprostoru = new Recepty(Elixír_Časoprostoru.nazevPredmetu, Elixír_Časoprostoru, Osvícená_Smůla, 4, TypVyroby.Alchymie, Měsíční_Erb, 3);
        public static readonly Recepty RDryák_Sebevznícení = new Recepty(Dryak_Sebevzniceni.nazevPredmetu, Dryak_Sebevzniceni, Ohnivý_Prach, 2, TypVyroby.Alchymie, Dračí_Květ, 1);
        public static readonly Recepty RPrach_Přízračnosti = new Recepty(Prach_Prizracnosti.nazevPredmetu, Prach_Prizracnosti, Ohnivý_Prach, 5, TypVyroby.Alchymie, Temná_Esence, 5);

        //dabelske k unlicku za hp
        public static readonly Recepty RDemonicka_Savle = new Recepty(Démonická_Šavle.nazevPredmetu, Démonická_Šavle, Železný_Ingot, 1, TypVyroby.Kovarna, Temná_Esence, 1);
        public static readonly Recepty RRemdich_Krvavych_Muk = new Recepty(Řemdich_Krvavách_Muk.nazevPredmetu, Řemdich_Krvavách_Muk, Železný_Ingot, 1, TypVyroby.Kovarna, Temná_Esence, 1);
        public static readonly Recepty RNuz_Osudu = new Recepty(Nůž_Osudu.nazevPredmetu, Nůž_Osudu, Železný_Ingot, 1, TypVyroby.Kovarna, Temná_Esence, 1);
        public static readonly Recepty RRoba_Nesmrtelnosti = new Recepty(Roucho_Nesmrtelnosti.nazevPredmetu, Roucho_Nesmrtelnosti, Látka, 1, TypVyroby.Kovarna, Temná_Esence, 1);
        public static readonly Recepty RDab_Plat = new Recepty(Ďábelsky_Nezničitelný_Plát.nazevPredmetu, Ďábelsky_Nezničitelný_Plát, Železný_Ingot, 1, TypVyroby.Kovarna, Temná_Esence, 1);
        public static List<Recepty> SeznamReceptů = new List<Recepty>
        {/*zbrane*/ RMeč, RDýka, RLuk, RMagická_Hůl, ROhnivá_Koule, RKrumpáč, RHalapartna,

         /*zbroje*/
          RŽelezná_Zbroj, RKožená_Zbroj, RLátková_Zbroj,

         /*Pouzitelne*/ RLektvar_Zdraví, RLektvar_Many, RLektvar_Síly, RLektvar_Obratnosti, RLektvar_Inteligence, RLektvar_Stesti, RJed,
         RLektvar_Utocnika, RLektvar_Obrance, RLektvar_Neskodnosti, RLektvar_Prurazu
        };

        // ZACATEK VYLEPSOVANI PREDMETU
        public static void Kovarna(TypVyroby tv = TypVyroby.Kovarna)
        {
            while (true)
            {
                int volba = MainM();
                if (volba == 0)
                    Tvroba(tv);
                else if (volba == 1)
                    UpgradePredmetu();
                else
                if (Opravdu())
                    break;
                else
                    continue;
            }
        }

        public static void Laborator()
        {
            Krafteni(TypVyroby.Alchymie);
        }

        private static int MainM()
        {
            Menu m = new Menu("Vyberte si Vámi požadovanou akci", new List<string> { "Tvorba předmětů v kovárně", "Vylepšování předmětů v kovárně", "Odejít" }, ConsoleColor.Yellow);
            return m.NavratIndexu();
        }

        private static void UpgradePredmetu()
        {
            Inventar.OdeberNepotrebne(VasePostava.inventarPostavy);
            while (true)
            {
                int volba = HMUpgrade();
                if (volba == 2)
                    break;
                else if (volba == 0)
                    UZbrani();
                else if (volba == 1)
                    UZbroji();
            }
        }

        // UPGRADE ZBRANI
        private static int HMUpgrade()
        {
            Menu menu = new Menu("Přejete si vylepšit Zbraně, Zbroje, nebo odejít z vylepšování?", new List<string> { "Zbraně", "Zbroje", "Odejít z vylepšování" }, ConsoleColor.Cyan);
            return menu.NavratIndexu();
        }

        private static void UZbrani()
        {

            var seznamZbrani = VasePostava.inventarPostavy.ListInventare()
                .Where(z => z.typPredmetu == TypPredmetu.Zbrane)
                .GroupBy(z => z.ID)
                .Select(g => g.First())
                .ToList();
            var vyberZbrani = seznamZbrani.Select(z =>
                    z.nazevPredmetu
                    + $" ({z.pocetPredmetu(VasePostava.inventarPostavy)})"
                    + (z == VasePostava.vybavenaAltZbran || z == VasePostava.vybavenaZbran ? " (Vybaveno)" : "")
                    + (z.pocetVylepseniPredmetu > 1 ? $" ({z.pocetVylepseniPredmetu - 1}x Vylepšeno)" : "")
                ).ToList();
            vyberZbrani.Add("Návrat zpět do menu");
            if (!seznamZbrani.Any())
            {
                Clear();
                ForegroundColor = ConsoleColor.Red;
                WriteLine();
                WriteLine("V inventáři se nenachází žádné zbraně.");
                WriteLine();
                ForegroundColor = ConsoleColor.Gray;
                WriteLine("stiskněte libovolné tlačítko pro pokračování...");
                ReadKey(true);
                return;
            }
            Menu menuZbrani = new Menu("Vyberte si příslušnou zbraň k vylepšení", vyberZbrani, ConsoleColor.DarkBlue);
            int index = menuZbrani.NavratIndexu();
            if (index == vyberZbrani.Count - 1)
                return;
            Zbrane vybranaZbran = (Zbrane)seznamZbrani[index];
            Recepty _receptZbrane = PriradReceptZbrani(vybranaZbran);
            Clear();
            if (_receptZbrane == null)
            {
                WriteLine();
                WriteLine("Recept nenalezen v systémovém seznamu receptů [BUG]");
                ResetColor();
                WriteLine();
                WriteLine("stiskněte libovolné tlačítko pokračování...");
                ReadKey(true);
            }
            else
            {
                if (_receptZbrane.sekundarniMaterialProVyrobu == null || _receptZbrane.pocetSekundarnihoMaterialu == null)
                {
                    ForegroundColor = ConsoleColor.DarkMagenta;
                    WriteLine($"Název zbraně k vylepšení: {vybranaZbran.nazevPredmetu}");
                    WriteLine();
                    WriteLine($"Tato zbraň, {vybranaZbran.nazevPredmetu}, bude vylepšena po: {_PocetVylepseniZbrane(vybranaZbran)}.");
                    WriteLine();
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine($"Název primárního materiálu na vylepšení zbraně: {_receptZbrane.primarniMaterialProVyrobu.nazevPredmetu}");
                    WriteLine();
                    WriteLine($"Počet primárního materiálu na vylepšení zbraně: {_receptZbrane.pocetPrimarnihoMaterialu * _PocetVylepseniZbrane(vybranaZbran)}");
                    WriteLine();
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine($"Počet primárního materiálu {_receptZbrane.primarniMaterialProVyrobu.nazevPredmetu} ve Vašem vlastnictví: {VasePostava.inventarPostavy.PocetPredmetu(_receptZbrane.primarniMaterialProVyrobu)}");
                }
                else
                {
                    ForegroundColor = ConsoleColor.DarkMagenta;
                    WriteLine($"Název zbraně k vylepšení: {vybranaZbran.nazevPredmetu}");
                    WriteLine();
                    WriteLine($"Tato zbraň, {vybranaZbran.nazevPredmetu}, bude vylepšena po: {_PocetVylepseniZbrane(vybranaZbran)}.");
                    WriteLine();
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine($"Název primárního materiálu na vylepšení zbraně: {_receptZbrane.primarniMaterialProVyrobu.nazevPredmetu}");
                    WriteLine();
                    WriteLine($"Počet primárního materiálu na vylepšení zbraně: {_receptZbrane.pocetPrimarnihoMaterialu * _PocetVylepseniZbrane(vybranaZbran)}");
                    WriteLine();
                    ForegroundColor = ConsoleColor.Magenta;
                    WriteLine($"Název sekundárního materiálu na vylepšení zbraně: {_receptZbrane.sekundarniMaterialProVyrobu.nazevPredmetu}");
                    WriteLine();
                    WriteLine($"Počet sekundárního materiálu na vylepšení zbraně: {_receptZbrane.pocetSekundarnihoMaterialu * (int)(_PocetVylepseniZbrane(vybranaZbran) / 2)}");
                    WriteLine();
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine($"Počet primárního materiálu {_receptZbrane.primarniMaterialProVyrobu.nazevPredmetu} ve Vašem vlastnictví: {VasePostava.inventarPostavy.PocetPredmetu(_receptZbrane.primarniMaterialProVyrobu)}");
                    WriteLine();
                    WriteLine($"Počet sekundárního materiálu {_receptZbrane.sekundarniMaterialProVyrobu.nazevPredmetu} ve Vašem vlastnictví: {VasePostava.inventarPostavy.PocetPredmetu(_receptZbrane.sekundarniMaterialProVyrobu)}");
                }
                WriteLine();
                ForegroundColor = ConsoleColor.Blue;
                WriteLine("Nová vylepšená zbraň: ");
                WriteLine();
                WriteLine("Poškození se zvýší o: {0}", (vybranaZbran.poskozeniZbrane) + (int)(Math.Floor(vybranaZbran.pocetVylepseniPredmetu / 2.0) - vybranaZbran.poskozeniZbrane));
                WriteLine();
                WriteLine("Cena se zvýší o: {0}", (int)(vybranaZbran.hodnotaPredmetu * 1.35 - vybranaZbran.hodnotaPredmetu));
                WriteLine();
                ResetColor();
                Thread.Sleep(250);
                WriteLine($"stiskněte libovolné tlačítko pro menu vylepšení předmětu: {vybranaZbran.nazevPredmetu}");
                ReadKey(true);
                Clear();
                MenuVyberuZbrani(vybranaZbran, _receptZbrane);
            }
        }

        private static void MenuVyberuZbrani(Zbrane vybranaZbran, Recepty vybranyRecept)
        {
            Menu menu = new Menu("Vyberte si prosím akci, kterou chcete využít:", new List<string> { $"Vylepšit {vybranaZbran.nazevPredmetu}", "Návrat do menu vylepšení předmětů" }, ConsoleColor.DarkMagenta);
            int volba = menu.NavratIndexu();
            if (volba == 0)
            {
                if (VasePostava.inventarPostavy.PocetPredmetu(vybranyRecept.primarniMaterialProVyrobu) < vybranyRecept.pocetPrimarnihoMaterialu * _PocetVylepseniZbrane(vybranaZbran) ||
                    VasePostava.inventarPostavy.PocetPredmetu(vybranyRecept.sekundarniMaterialProVyrobu) < vybranyRecept.pocetSekundarnihoMaterialu * (int)(_PocetVylepseniZbrane(vybranaZbran)/2))
                {
                    WriteLine();
                    Clear();
                    ResetColor();
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine($"Nemáte dostatek materiálů na vylepšení zbraně: {vybranaZbran.nazevPredmetu}");
                    ResetColor();
                    WriteLine();
                    WriteLine($"stiskněte libovolné tlačítko pokračování...");
                    ReadKey(true);
                    return;
                }
                else
                {
                    Clear();
                    Menu menu1 = new Menu($"Opravdu chcete vylepšit zbraň: {vybranaZbran.nazevPredmetu} ?", new List<string> { "Ano, vylepšit zbraň", "Ne, nevylepšovat zbraň" }, ConsoleColor.Red);
                    int volba1 = menu1.NavratIndexu();
                    if (volba1 == 1)
                        return;
                    else
                    {
                        for (int i = 0; i < vybranyRecept.pocetPrimarnihoMaterialu * _PocetVylepseniZbrane(vybranaZbran); i++)
                            VasePostava.inventarPostavy.OdeberPredmet(vybranyRecept.primarniMaterialProVyrobu);
                        if (vybranyRecept.sekundarniMaterialProVyrobu != null)
                        {
                            for (int i = 0; i < vybranyRecept.pocetSekundarnihoMaterialu * (int)(_PocetVylepseniZbrane(vybranaZbran)/2); i++) ;
                            VasePostava.inventarPostavy.OdeberPredmet(vybranyRecept.sekundarniMaterialProVyrobu);
                        }
                        Clear();
                        Zbrane.VylepseniZbrane(vybranaZbran);
                        WriteLine();
                        ForegroundColor = ConsoleColor.Cyan;
                        WriteLine($"Výborně, vylepšili jste zbraň {vybranaZbran.nazevPredmetu}, toto je {vybranaZbran.pocetVylepseniPredmetu}. vylepšení této zbraně!");
                        WriteLine();
                        ResetColor();
                        WriteLine($"stiskněte libovolné tlačítko pro pokračování...");
                        ReadKey(true);
                        return;
                    }
                }
            }
            else if (volba == 1)
                return;
        }

        //UPGRADE ZBROJI
        private static void UZbroji()
        {
            var seznamZbroji = VasePostava.inventarPostavy.ListInventare()
                .Where(z => z.typPredmetu == TypPredmetu.Zbroje)
                .GroupBy(z => z.ID)
                .Select(g => g.First())
                .ToList();
            var vyberZbroji = seznamZbroji.Select(Z => Z.nazevPredmetu + $" ({Z.pocetPredmetu(VasePostava.inventarPostavy)})" + (Z == VasePostava.vybavenaZbroj ? " (Vybaveno)" : "") + (Z.pocetVylepseniPredmetu > 1 ? $" ({Z.pocetVylepseniPredmetu - 1}x Vylepšeno)" : "")).ToList();
            vyberZbroji.Add("Návrat zpět do menu");
            if (!seznamZbroji.Any())
            {
                Clear();
                ForegroundColor = ConsoleColor.Red;
                WriteLine();
                WriteLine("V inventáři se nenachází žádné zbroje.");
                WriteLine();
                ForegroundColor = ConsoleColor.Gray;
                WriteLine("stiskněte libovolné tlačítko pro pokračování...");
                ReadKey(true);
                return;
            }
            Menu menuZbrani = new Menu("Vyberte si příslušnou zbroj k vylepšení", vyberZbroji, ConsoleColor.DarkYellow);
            int index = menuZbrani.NavratIndexu();
            if (index == vyberZbroji.Count - 1)
                return;
            Zbroje vybranaZbroj = (Zbroje)seznamZbroji[index];
            Recepty _receptZbroje = PriradReceptZbroji(vybranaZbroj);
            Clear();
            if (_receptZbroje == null)
            {
                WriteLine();
                WriteLine("Recept nenalezen v systémovém seznamu receptů. [BUG] -> Developer je debil a nepřidal tento předmět do receptů.");
                ResetColor();
                WriteLine();
                WriteLine($"stiskněte libovolné tlačítko pokračování...");
                ReadKey(true);
            }
            else
            {
                if (_receptZbroje.sekundarniMaterialProVyrobu == null || _receptZbroje.pocetSekundarnihoMaterialu == null)
                {
                    ForegroundColor = ConsoleColor.DarkMagenta;
                    WriteLine($"Název zbroje k vylepšení: {vybranaZbroj.nazevPredmetu}");
                    WriteLine();
                    WriteLine($"Tato zbroj, {vybranaZbroj.nazevPredmetu}, bude vylepšena po: {_PocetVylepseniZbroje(vybranaZbroj)}.");
                    WriteLine();
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine($"Název primárního materiálu na vylepšení zbroje: {_receptZbroje.primarniMaterialProVyrobu.nazevPredmetu}");
                    WriteLine();
                    WriteLine($"Počet primárního materiálu na vylepšení zbroje: {_receptZbroje.pocetPrimarnihoMaterialu * _PocetVylepseniZbroje(vybranaZbroj)}");
                    WriteLine();
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine($"Počet primárního materiálu {_receptZbroje.primarniMaterialProVyrobu.nazevPredmetu} ve Vašem vlastnictví: {VasePostava.inventarPostavy.PocetPredmetu(_receptZbroje.primarniMaterialProVyrobu)}");
                }
                else
                {
                    ForegroundColor = ConsoleColor.DarkMagenta;
                    WriteLine($"Název zbroje k vylepšení: {vybranaZbroj.nazevPredmetu}");
                    WriteLine();
                    WriteLine($"Tato zbroj, {vybranaZbroj.nazevPredmetu}, bude vylepšena po: {_PocetVylepseniZbroje(vybranaZbroj)}.");
                    WriteLine();
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine($"Název primárního materiálu na vylepšení zbroje: {_receptZbroje.primarniMaterialProVyrobu.nazevPredmetu}");
                    WriteLine();
                    WriteLine($"Počet primárního materiálu na vylepšení zbroje: {_receptZbroje.pocetPrimarnihoMaterialu * _PocetVylepseniZbroje(vybranaZbroj)}");
                    WriteLine();
                    ForegroundColor = ConsoleColor.Magenta;
                    WriteLine($"Název sekundárního materiálu na vylepšení zbroje: {_receptZbroje.sekundarniMaterialProVyrobu.nazevPredmetu}");
                    WriteLine();
                    WriteLine($"Počet sekundárního materiálu na vylepšení zbroje: {_receptZbroje.pocetSekundarnihoMaterialu * (int)(_PocetVylepseniZbroje(vybranaZbroj) / 2)}");
                    WriteLine();
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine($"Počet primárního materiálu {_receptZbroje.primarniMaterialProVyrobu.nazevPredmetu} ve Vašem vlastnictví: {VasePostava.inventarPostavy.PocetPredmetu(_receptZbroje.primarniMaterialProVyrobu)}");
                    WriteLine();
                    WriteLine($"Počet sekundárního materiálu {_receptZbroje.sekundarniMaterialProVyrobu.nazevPredmetu} ve Vašem vlastnictví: {VasePostava.inventarPostavy.PocetPredmetu(_receptZbroje.sekundarniMaterialProVyrobu)}");
                }
                WriteLine();
                ForegroundColor = ConsoleColor.Blue;
                WriteLine("Nová vylepšená zbroj: ");
                WriteLine();
                WriteLine("Hodnota brnění se zvýší o: {0}", (vybranaZbroj.hodnotaBrneni) + (int)(Math.Floor(vybranaZbroj.pocetVylepseniPredmetu / 2.0) - vybranaZbroj.hodnotaBrneni));
                WriteLine();
                WriteLine("Cena se zvýší o: {0}", (int)(vybranaZbroj.hodnotaPredmetu * 1.35 - vybranaZbroj.hodnotaPredmetu));
                WriteLine();
                ResetColor();
                Thread.Sleep(250);
                WriteLine($"stiskněte libovolné tlačítko pro menu vylepšení předmětu: {vybranaZbroj.nazevPredmetu}");
                ReadKey(true);
                Clear();
                MenuVyberuZbroji(vybranaZbroj, _receptZbroje);
            }
        }

        private static void MenuVyberuZbroji(Zbroje vybranaZbroj, Recepty vybranyRecept)
        {
            Menu menu = new Menu("Vyberte si prosím akci, kterou chcete využít:", new List<string> { $"Vylepšit {vybranaZbroj.nazevPredmetu}", "Návrat do menu vylepšení předmětů" }, ConsoleColor.DarkMagenta);
            int volba = menu.NavratIndexu();
            if (volba == 0)
            {
                if (VasePostava.inventarPostavy.PocetPredmetu(vybranyRecept.primarniMaterialProVyrobu) < vybranyRecept.pocetPrimarnihoMaterialu * _PocetVylepseniZbroje(vybranaZbroj) ||
                    VasePostava.inventarPostavy.PocetPredmetu(vybranyRecept.sekundarniMaterialProVyrobu) < vybranyRecept.pocetSekundarnihoMaterialu * (int)(_PocetVylepseniZbroje(vybranaZbroj)/2))
                {
                    WriteLine();
                    Clear();
                    ResetColor();
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine($"Nemáte dostatek materiálů na vylepšení zbroje: {vybranaZbroj.nazevPredmetu}");
                    ResetColor();
                    WriteLine();
                    WriteLine($"stiskněte libovolné tlačítko pokračování...");
                    ReadKey(true);
                    return;
                }
                else
                {
                    Clear();
                    Menu menu1 = new Menu($"Opravdu chcete vylepšit zbroj: {vybranaZbroj.nazevPredmetu} ?", new List<string> { "Ano, vylepšit zbroj", "Ne, nevylepšovat zbroj" }, ConsoleColor.Red);
                    int volba1 = menu1.NavratIndexu();
                    if (volba1 == 1)
                        return;
                    else
                    {
                        for (int i = 0; i < vybranyRecept.pocetPrimarnihoMaterialu * _PocetVylepseniZbroje(vybranaZbroj); i++)
                            VasePostava.inventarPostavy.OdeberPredmet(vybranyRecept.primarniMaterialProVyrobu);
                        if (vybranyRecept.sekundarniMaterialProVyrobu != null)
                        {
                            for (int i = 0; i < vybranyRecept.pocetSekundarnihoMaterialu * (int)(_PocetVylepseniZbroje(vybranaZbroj)/2); i++) ;
                            VasePostava.inventarPostavy.OdeberPredmet(vybranyRecept.sekundarniMaterialProVyrobu);
                        }
                        Clear();
                        Zbroje.VylepseniZbroje(vybranaZbroj);
                        WriteLine();
                        ForegroundColor = ConsoleColor.Cyan;
                        WriteLine($"Výborně, vylepšili jste zbroj {vybranaZbroj.nazevPredmetu}, toto je {vybranaZbroj.pocetVylepseniPredmetu}. vylepšení této zbroje!");
                        WriteLine();
                        ResetColor();
                        WriteLine($"stiskněte libovolné tlačítko pro pokračování...");
                        ReadKey(true);
                        return;
                    }
                }
            }
            else if (volba == 1)
                return;
        }

        //PRIRAZENI RECEPTU KE ZBROJI NEBO ZBRANI
        public static Recepty PriradReceptZbrani(Zbrane z)
        {
            foreach (Recepty r in SeznamReceptů)
            {             
                if (r.nazevVyrobenehoPredmetu == z.nazevPredmetu)
                    return r;
            }
            return null;
        }

        public static Recepty PriradReceptZbroji(Zbroje z)
        {
            foreach (Recepty r in SeznamReceptů)
            {
                if (r.nazevVyrobenehoPredmetu == z.nazevPredmetu)
                    return r;
            }
            return null;
        }

        // ZACATEK VYROBY PREDMETU
        private static void Krafteni(TypVyroby typVyroby)
        {
            while (true)
            {
                int volba = ZakladniMenu();
                if (volba == 1)
                    if (Opravdu())
                        break;
                    else
                        continue;
                else if (volba == 0)
                    Tvroba(typVyroby);
            }
        }

        private static bool Opravdu()
        {
            Menu menu = new Menu("Opravdu si přejete odejít?", new List<string> { "Ano, odejít", "Ne, zůstat" }, ConsoleColor.Red);
            if (menu.NavratIndexu() == 0)
                return true;
            else
                return false;
        }

        private static int ZakladniMenu()
        {
            Menu menu = new Menu("Vítejte v Laboratoři, přejete si zobrazit recepty, nebo odejít z tvorby?", new List<string> { "Zobrazit recepty", "Odejít z tvorby" }, ConsoleColor.Cyan);
            return menu.NavratIndexu();
        }

        private static void Tvroba(TypVyroby typVyroby)
        {
            List<Recepty> seznamReceptu = new List<Recepty>();

            foreach (Recepty r in SeznamReceptů)
                if (r.typVyroby == typVyroby)
                    seznamReceptu.Add(r);

            var vyberReceptu = seznamReceptu.Select(k => "Recept: " + k.nazevVyrobenehoPredmetu).ToList();
            vyberReceptu.Add("Odejít z menu receptů");
            Menu menu = new Menu("Vyberte si žádáný recept: ", vyberReceptu, ConsoleColor.Blue);
            int volba = menu.NavratIndexu();
            Clear();
            if (volba == vyberReceptu.Count - 1)
                return;
            Recepty vybranyRecept = seznamReceptu[volba];

            if (vybranyRecept.sekundarniMaterialProVyrobu == null || vybranyRecept.pocetSekundarnihoMaterialu == null)
            {
                ForegroundColor = ConsoleColor.DarkMagenta;
                WriteLine($"Název předmětu k výrobě: {vybranyRecept.nazevVyrobenehoPredmetu}");
                WriteLine();
                ForegroundColor = ConsoleColor.Red;
                WriteLine($"Název primárního materiálu na výrobu receptu: {vybranyRecept.primarniMaterialProVyrobu.nazevPredmetu}");
                WriteLine();
                WriteLine($"Počet primárního materiálu na výrobu receptu: {vybranyRecept.pocetPrimarnihoMaterialu}");
                WriteLine();
                ForegroundColor = ConsoleColor.Green;
                WriteLine($"Počet primárního materiálu {vybranyRecept.primarniMaterialProVyrobu.nazevPredmetu} ve Vašem vlastnictví: {VasePostava.inventarPostavy.PocetPredmetu(vybranyRecept.primarniMaterialProVyrobu)}");
            }
            else
            {
                ForegroundColor = ConsoleColor.DarkMagenta;
                WriteLine($"Název předmětu k výrobě: {vybranyRecept.nazevVyrobenehoPredmetu}");
                WriteLine();
                ForegroundColor = ConsoleColor.Red;
                WriteLine($"Název primárního materiálu na výrobu receptu: {vybranyRecept.primarniMaterialProVyrobu.nazevPredmetu}");
                WriteLine();
                WriteLine($"Počet primárního materiálu na výrobu receptu: {vybranyRecept.pocetPrimarnihoMaterialu}");
                WriteLine();
                ForegroundColor = ConsoleColor.Magenta;
                WriteLine($"Název sekundárního materiálu na výrobu receptu: {vybranyRecept.sekundarniMaterialProVyrobu.nazevPredmetu}");
                WriteLine();
                WriteLine($"Počet sekundárního materiálu na výrobu receptu: {vybranyRecept.pocetSekundarnihoMaterialu}");
                WriteLine();
                ForegroundColor = ConsoleColor.Green;
                WriteLine($"Počet primárního materiálu {vybranyRecept.primarniMaterialProVyrobu.nazevPredmetu} ve Vašem vlastnictví: {VasePostava.inventarPostavy.PocetPredmetu(vybranyRecept.primarniMaterialProVyrobu)}");
                WriteLine();
                WriteLine($"Počet sekundárního materiálu {vybranyRecept.sekundarniMaterialProVyrobu.nazevPredmetu} ve Vašem vlastnictví: {VasePostava.inventarPostavy.PocetPredmetu(vybranyRecept.sekundarniMaterialProVyrobu)}");
            }
            WriteLine();
            ResetColor();
            Thread.Sleep(250);
            WriteLine($"stiskněte libovolné tlačítko pro menu tvoření předmětu: {vybranyRecept.nazevVyrobenehoPredmetu}");
            ReadKey(true);
            Clear();
            MenuVyberu(vybranyRecept);
        }

        private static void MenuVyberu(Recepty recept)
        {
            Menu menu = new Menu("Vyberte si prosím akci, kterou chcete využít:", new List<string> { $"Vytvořit {recept.nazevVyrobenehoPredmetu}", "Návrat do menu receptů" }, ConsoleColor.DarkMagenta);
            int volba = menu.NavratIndexu();
            if (volba == 0)
            {
                if (VasePostava.inventarPostavy.PocetPredmetu(recept.primarniMaterialProVyrobu) < recept.pocetPrimarnihoMaterialu ||
                    VasePostava.inventarPostavy.PocetPredmetu(recept.sekundarniMaterialProVyrobu) < recept.pocetSekundarnihoMaterialu)
                {
                    WriteLine();
                    Clear();
                    ResetColor();
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine($"Nemáte dostatek materiálů na výrobu {recept.nazevVyrobenehoPredmetu}");
                    ResetColor();
                    WriteLine();
                    WriteLine($"stiskněte libovolné tlačítko pokračování...");
                    ReadKey(true);
                    return;
                }
                else
                {
                    Menu menu1 = new Menu($"Opravdu chcete vytvořit předmět: {recept.nazevVyrobenehoPredmetu} ?", new List<string> { "Ano, vytvořit předmět", "Ne, nevytvářet" }, ConsoleColor.Red);
                    int volba1 = menu1.NavratIndexu();
                    if (volba1 == 1)
                        return;
                    else
                    {
                        for (int i = 0; i < recept.pocetPrimarnihoMaterialu; i++)
                            VasePostava.inventarPostavy.OdeberPredmet(recept.primarniMaterialProVyrobu);
                        if (recept.sekundarniMaterialProVyrobu != null)
                        {
                            for (int i = 0; i < recept.pocetSekundarnihoMaterialu; i++) ;
                            VasePostava.inventarPostavy.OdeberPredmet(recept.sekundarniMaterialProVyrobu);
                        }
                        VasePostava.inventarPostavy.PridejPredmet(recept.vyrobenyPredmet);
                        Clear();
                        WriteLine();
                        ForegroundColor = ConsoleColor.Cyan;
                        WriteLine($"Výborně, vyrobili jste předmět {recept.nazevVyrobenehoPredmetu}!");
                        WriteLine();
                        ResetColor();
                        WriteLine($"stiskněte libovolné tlačítko pro pokračování...");
                        ReadKey(true);
                        return;
                    }
                }
            }
            else if (volba == 1)
                return;
        }

        private static int pocetNavstevVTavirne = 0;
        //SMELTER
        public static void Tavirna()
        {
            Inventar.OdeberNepotrebne(VasePostava.inventarPostavy);
            pocetNavstevVTavirne++;
            if(pocetNavstevVTavirne == 1)
            {
                Clear();
                ForegroundColor = ConsoleColor.Blue;
                AnimaceTextu("Vítejte v tavírně!");
                AnimaceTextu("Místě, kde můžete nepotřebné předměty rozložit skoro na molekuly...");
                AnimaceTextu("Vyberte si libovolný předmět, který chcete roztavit a vezměte si z něj základní suroviny!");
                AnimaceTextu("......");
                GameplayLokaci_1.Tlacitko();
                while(true)
                {
                    int vyberTaveni = VyberHMenu();
                    if (vyberTaveni == 0)
                        TaveniZbrani();
                    else if (vyberTaveni == 1)
                        TaveniZbroji();
                    else if (vyberTaveni == 2)
                        TaveniPouzitelnych();
                    else
                        break;
                }

            }
            int VyberHMenu()
            {
                Menu hlavniMenu = new Menu("Vyberte si, který typ předmětu chcete zničit a získat tak jeho základní suorivny?"
                    , new List<string> { "Zbraně", "Zbroje", "Použitelné", "Odejít" }, ConsoleColor.Blue);
                return hlavniMenu.NavratIndexu();
            }
            void TaveniZbrani()
            {
                while(true)
                {
                    var ZbraneKTaveni = VasePostava.inventarPostavy.ListInventare().Where(p => p is Zbrane).GroupBy(p => p.ID).Select(p => p.First()).ToList();
                    var vypisZbrani = ZbraneKTaveni.Select(g => g.nazevPredmetu + " (" + g.pocetPredmetu(VasePostava.inventarPostavy) + ") " + ((g as Zbrane).schopnostZbrane != null ? "(Se schopností) " : "") + ((g == VasePostava.alternativniZbranPostavy || g == VasePostava.zbranPostavy)?"(Vybaveno)":"")).ToList();
                    vypisZbrani.Add("Odejít");
                    Menu vypZ = new Menu("Vyberte si zbraň k roztavení:", vypisZbrani, ConsoleColor.Red);
                    int v = vypZ.NavratIndexu();
                    if (v == vypisZbrani.Count - 1)
                        break;
                    Zbrane tavenaZ = (Zbrane)ZbraneKTaveni[v];
                    if (tavenaZ == VasePostava.alternativniZbranPostavy || tavenaZ == VasePostava.zbranPostavy)
                    {
                        Clear();
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine();
                        WriteLine($"Předmět {tavenaZ.nazevPredmetu} nelze roztavit, máte jej vybaveni!");
                        GameplayLokaci_1.Tlacitko();
                        return;
                    }
                    else if (tavenaZ.pocetVylepseniPredmetu > 1)
                    {

                        Clear();
                        if (PotvrzeniRoz(tavenaZ))
                            Roztaveni(tavenaZ);
                        else continue;
                    }
                    else
                        Roztaveni(tavenaZ);

                }

            }
            void TaveniZbroji()
            {
                while (true)
                {
                    var ZbraneKTaveni = VasePostava.inventarPostavy.ListInventare().Where(p => p is Zbroje).GroupBy(p => p.ID).Select(p => p.First()).ToList();
                    var vypisZbrani = ZbraneKTaveni.Select(g => g.nazevPredmetu + " (" + g.pocetPredmetu(VasePostava.inventarPostavy) + ") " + (g is Zbroje && (g as Zbroje).schopnostZbroje != null ? "(Se schopností) " : "") + ((g == VasePostava.zbrojPostavy) ? "(Vybaveno)" : "")).ToList();
                    vypisZbrani.Add("Odejít");
                    Menu vypZ = new Menu("Vyberte si zbroj k roztavení:", vypisZbrani, ConsoleColor.Blue);
                    int v = vypZ.NavratIndexu();
                    if (v == vypisZbrani.Count - 1)
                        break;
                    Zbroje tavenaZ = (Zbroje)ZbraneKTaveni[v];
                    if (tavenaZ == VasePostava.zbrojPostavy)
                    {
                        Clear();
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine();
                        WriteLine($"Předmět {tavenaZ.nazevPredmetu} nelze roztavit, máte jej vybaveni!");
                        GameplayLokaci_1.Tlacitko();
                        return;
                    }
                    else if (tavenaZ.pocetVylepseniPredmetu > 1)
                    {

                        Clear();
                        if (PotvrzeniRoz(tavenaZ))
                            Roztaveni(tavenaZ);
                        else continue;
                    }
                    else
                        Roztaveni(tavenaZ);

                }

            }
            void TaveniPouzitelnych()
            {
                while (true)
                {
                    var ZbraneKTaveni = VasePostava.inventarPostavy.ListInventare().Where(p => p is Pouzitelne && p!= Zlaťák).GroupBy(p => p.ID).Select(p => p.First()).ToList();
                    var vypisZbrani = ZbraneKTaveni.Select(g => g.nazevPredmetu + " (" + g.pocetPredmetu(VasePostava.inventarPostavy) + ") ").ToList();
                    vypisZbrani.Add("Odejít");
                    Menu vypZ = new Menu("Vyberte si použitelný předmět k roztavení:", vypisZbrani.ToList(), ConsoleColor.Yellow);
                    int v = vypZ.NavratIndexu();
                    if (v == vypisZbrani.Count - 1)
                        break;
                    Pouzitelne tavenaZ = (Pouzitelne)ZbraneKTaveni[v];                 
                    if (tavenaZ.pocetVylepseniPredmetu > 1)
                    {

                        Clear();
                        if (PotvrzeniRoz(tavenaZ))
                            Roztaveni(tavenaZ);
                        else continue;
                    }
                    else
                        Roztaveni(tavenaZ);

                }

            }
            bool PotvrzeniRoz(Predmety p)
            {
                Menu menu = new Menu($"Opravdu roztavit předmět {p.nazevPredmetu}? Je vylepšený.", new List<string> { "Ano", "Ne" }, ConsoleColor.Red);
                int volba = menu.NavratIndexu();
                if (volba == 0)
                    return true;
                else
                    return false;
            }
            void Roztaveni(Predmety p)
            {
                
                Recepty receptTavenehoPR = PriradReceptPredmetu(p);
                if (receptTavenehoPR == null)
                    throw new Exception("Recept předmětu při tavení nenalezen v seznamu receptů");
                Clear();
                if (p is Zbrane)
                    ForegroundColor = ConsoleColor.Red;
                else if (p is Zbroje)
                    ForegroundColor = ConsoleColor.Blue;
                else
                    ForegroundColor = ConsoleColor.Yellow;
                WriteLine();
                WriteLine($" Roztavili jste předmět {p.nazevPredmetu}!");
                WriteLine();
                WriteLine(" Z tavení jste získali:");
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine();
                WriteLine($" {receptTavenehoPR.pocetPrimarnihoMaterialu}x {receptTavenehoPR.primarniMaterialProVyrobu.nazevPredmetu}");
                for (int i = 0; i < receptTavenehoPR.pocetPrimarnihoMaterialu; i++)
                    VasePostava.inventarPostavy.PridejPredmet(receptTavenehoPR.primarniMaterialProVyrobu);
                if(receptTavenehoPR.sekundarniMaterialProVyrobu != null)
                {
                    WriteLine();
                    WriteLine($" {receptTavenehoPR.pocetSekundarnihoMaterialu}x {receptTavenehoPR.sekundarniMaterialProVyrobu.nazevPredmetu}");
                    for (int i = 0; i < receptTavenehoPR.pocetSekundarnihoMaterialu; i++)
                        VasePostava.inventarPostavy.PridejPredmet(receptTavenehoPR.sekundarniMaterialProVyrobu);
                }
                VasePostava.inventarPostavy.OdeberPredmet(p);
                GameplayLokaci_1.Tlacitko();
                
            }
            Recepty PriradReceptPredmetu(Predmety pr)
            {
                foreach(Recepty r in SeznamReceptů)
                {
                    if (r.vyrobenyPredmet == pr)
                        return r;
                }
                return null;
            }
        }
    }

    // ZACATEK TRIDY RECEPTU
    internal class Recepty
    {
        internal enum TypVyroby
        { Kovarna, Alchymie }

        
        internal string nazevVyrobenehoPredmetu { get; private set; }
        internal TypVyroby typVyroby { get; private set; }
        internal Predmety vyrobenyPredmet { get; private set; }
        internal Suroviny primarniMaterialProVyrobu { get; private set; }
        internal Suroviny sekundarniMaterialProVyrobu { get; private set; }

        internal int pocetPrimarnihoMaterialu { get; private set; }

        internal int? pocetSekundarnihoMaterialu { get; private set; }

        internal Recepty(string nazevVyrobenehoPredmetu, Predmety vyrobenyPredmet, Suroviny primarniMaterialProVyrobu, int pocetPrimarnihoMaterialu,
            TypVyroby typVyroby, Suroviny sekundarniMaterialProVyrobu, int? pocetSekundarnihoMaterialu)
        {
            this.nazevVyrobenehoPredmetu = nazevVyrobenehoPredmetu;
            this.vyrobenyPredmet = vyrobenyPredmet;
            this.primarniMaterialProVyrobu = primarniMaterialProVyrobu;
            this.pocetPrimarnihoMaterialu = pocetPrimarnihoMaterialu;
            this.typVyroby = typVyroby;
            this.sekundarniMaterialProVyrobu = sekundarniMaterialProVyrobu;
            this.pocetSekundarnihoMaterialu = pocetSekundarnihoMaterialu;
            
        }
        public static void PridejReceptDoSeznamu(Recepty recept)
        {
            if(!TvrobaPredmetu.SeznamReceptů.Contains(recept))
            {
                TvrobaPredmetu.SeznamReceptů.Add(recept);
                ForegroundColor = ConsoleColor.Cyan;
                Clear();
                WriteLine("Právě jste objevili unikátní předmět {0}!", recept.nazevVyrobenehoPredmetu);
                Thread.Sleep(200);
                WriteLine();
                WriteLine("Odteď ho naleznete v seznamu receptů v {0}.", recept.typVyroby == TypVyroby.Kovarna?"Kovárně":"Laboratoři");
                Thread.Sleep(200);
                if (recept.typVyroby == TypVyroby.Kovarna)
                {
                    WriteLine();
                    WriteLine("Předmět také v Kovárně můžete vylepšovat.");
                    Thread.Sleep(200);
                }
                WriteLine();
                ResetColor();
                WriteLine("stiskněte libovolné tlačítko pro pokračování");
                ReadKey(true);
                Clear();

            }
        }
    }
}