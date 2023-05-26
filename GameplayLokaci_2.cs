using System;
using System.Collections.Generic;
using System.Threading;
using static DnD_Hra.DndHerniFunkce;
using static DnD_Hra.Lokace;
using static DnD_Hra.VytvoreneLokace;
using static System.Console;
using static DnD_Hra.VytvorenePredmety;
using static DnD_Hra.UkladaniFunkci;
using static DnD_Hra.NoveSpecialniSchopnosti;
using System.Linq;

namespace DnD_Hra
{
    class GameplayLokaci_2
    {
        public static bool EventH = false;
        private const int maxKapacitaUlo = 20;
        private static Random r = new Random();
        private static Inventar u1 = new Inventar();
        private static Inventar u2 = new Inventar();
        private static Inventar u3 = new Inventar();
        private static string u1Nazev = "Úložný prostor 1";
        private static string u2Nazev = "Úložný prostor 2";
        private static string u3Nazev = "Úložný prostor 3";
        public static void Tlacitko()
        {
            ResetColor();
            Thread.Sleep(150);
            WriteLine();
            WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            ReadKey(true);
            Clear();
        }
        public static void PrimaRec(string kdoToRika, string text, ConsoleColor barva = ConsoleColor.DarkGray)
        {
            ForegroundColor = barva;
            WriteLine();
            WriteLine($"{kdoToRika}{dt} \"{text}\"");
            Thread.Sleep(3000);
            ResetColor();
        }
        static string dt = ":";
        static bool prvniNavsteva = true;
        public static void OsobniDomecekGameplay()
        {
            Clear();
            if (!prvniNavsteva && !EventH)
                EventDum();
            if (prvniNavsteva)
            {
                prvniNavsteva = false;
                ForegroundColor = ConsoleColor.DarkCyan;
                AnimaceTextu("Díky Vašim zásluhám ve městě Valoria Vám byl přidělen místní dům v plné výbavě.");
                AnimaceTextu("V domě najdete kovárnu a alchymistickou laboratoř. Také zde naleznete úložný prostor pro Vaše předměty!");
                AnimaceTextu("Vše je jen Vaše, mezi výpravami sem můžete zajít a využít cokoliv si přejete.");
                AnimaceTextu("Avšak pozor, ne každý souhlasí s tím co se ve městě stalo a tudíž i s čím jste spojeni. Mějte se proto napozoru...");
                Tlacitko();
            }
            while (true)
            {
                Menu coChcete = new Menu("Co si přejete ve Vašem domě navštívit?", new List<string> { "Kovárna", "Alchymistická laboratoř"," Tavírna", "Úložný prostor", "Otevřít vedlejší menu", "Odejít z domu" }, ConsoleColor.Green);
                int volba = coChcete.NavratIndexu();
                if (volba == 0)
                    TvrobaPredmetu.Kovarna();
                else if (volba == 1)
                    TvrobaPredmetu.Laborator();
                else if (volba == 2)
                    TvrobaPredmetu.Tavirna();
                else if (volba == 3)
                    UloznyProstor(VasePostava.inventarPostavy);
                else if (volba == 4)
                    Menu.VedlejsiMenuPostavy();
                else if (volba == 5)
                    break;

                void UloznyProstor(Inventar hracuvInv)
                {
                    while (true)
                    {
                        Menu VP = new Menu("Přejete si vybrat, nebo vložit předměty?", new List<string> { "Vybrat", "Vložit", "Vrátit se" }, ConsoleColor.Yellow);
                        int v = VP.NavratIndexu();
                        if (v == 2)
                            break;
                        else if (v == 1)
                            VlozeniO(hracuvInv);
                        else if (v == 0)
                            VyberO(hracuvInv);
                    }
                    void VyberO(Inventar hracuvInv)
                    {
                        while (true)
                        {
                            Menu vyber = new Menu("Vyberte, z jakého uložiště chcete vybírat", new List<string> { u1Nazev, u2Nazev, u3Nazev, "Odejít" }, ConsoleColor.DarkMagenta);
                            int c = vyber.NavratIndexu();
                            if (c == 3)
                                break;
                            else if (c == 0)
                                VybraniZUloziste(hracuvInv, u1, u1Nazev);
                            else if (c == 1)
                                VybraniZUloziste(hracuvInv, u2, u2Nazev);
                            else if (c == 2)
                                VybraniZUloziste(hracuvInv, u3, u3Nazev);

                        }
                    }
                    void VlozeniO(Inventar hracuvInv)
                    {
                        while (true)
                        {
                            Menu vyber = new Menu("Vyberte, do jakého uložiště chcete vkládat", new List<string> { u1Nazev, u2Nazev, u3Nazev, "Odejít" }, ConsoleColor.DarkBlue);
                            int c = vyber.NavratIndexu();
                            if (c == 3)
                                break;
                            else if (c == 0)
                                VlozeniDoUloziste(hracuvInv, u1, ref u1Nazev);
                            else if (c == 1)
                                VlozeniDoUloziste(hracuvInv, u2, ref u2Nazev);
                            else if (c == 2)
                                VlozeniDoUloziste(hracuvInv, u3, ref u3Nazev);

                        }
                    }
                    void VlozeniDoUloziste(Inventar hracuvInv, Inventar ulozisteInv, ref string nazevUloziste)
                    {
                        while (true)
                        {

                            var seskupeniHracovaInc = hracuvInv.ListInventare().GroupBy(G => G.ID).Select(g => g.First()).ToList();
                            var displejHracovaInv = seskupeniHracovaInc.Select(p => "(" + p.pocetPredmetu(hracuvInv) + ") " + p.nazevPredmetu + (p == VasePostava.zbrojPostavy || p == VasePostava.zbranPostavy || p == VasePostava.alternativniZbranPostavy ? " (Vybaveno)" : "" + (p.pocetVylepseniPredmetu > 1 ? $" ({p.pocetVylepseniPredmetu - 1}x Vylepšeno)" : ""))).ToList();
                            displejHracovaInv.Add("Přejmenovat Uložiště");
                            displejHracovaInv.Add("Vrátit se");
                            Menu vyberPredmetuKUlo = new Menu($"Vyberte předmět, který chcete uložit, nebo akci, kterou chete provést s {nazevUloziste}" + VypisKapacit(ulozisteInv, hracuvInv, nazevUloziste), displejHracovaInv, ConsoleColor.Cyan);
                            int volba = vyberPredmetuKUlo.NavratIndexu();
                            if (volba == displejHracovaInv.Count - 1)
                                break;
                            if (volba == displejHracovaInv.Count - 2)
                            {
                                Clear();
                                ForegroundColor = ConsoleColor.Blue;
                                WriteLine();
                                WriteLine($"Nynější název tohoto uložiště je {nazevUloziste}, zadejte prosím nový název:");
                                WriteLine();
                                CursorVisible = true;
                                nazevUloziste = ReadLine();
                                CursorVisible = false;
                                while (!JePismenaNeboCislaNeboMezery(nazevUloziste) || nazevUloziste.Length > 20)
                                {
                                    ForegroundColor = ConsoleColor.Red;
                                    WriteLine();
                                    WriteLine("V názvu mohou být jen písmena, čísla, nebo mezery a také musí mít maximálně 20 znaků. Zadejte název znovu, prosím.");
                                    WriteLine();
                                    ForegroundColor = ConsoleColor.Blue;
                                    CursorVisible = true;
                                    nazevUloziste = ReadLine();
                                    CursorVisible = false;
                                }
                                WriteLine();
                                ForegroundColor = ConsoleColor.Green;
                                WriteLine($"Výborně, název byl změněn na {nazevUloziste}!");
                                Tlacitko();
                                return;
                            }
                            Predmety pKUlozeni = seskupeniHracovaInc[volba];
                            if (pKUlozeni == VasePostava.zbranPostavy || pKUlozeni == VasePostava.alternativniZbranPostavy || pKUlozeni == VasePostava.zbrojPostavy)
                            {
                                Clear();
                                ForegroundColor = ConsoleColor.Red;
                                WriteLine($"Předmět {pKUlozeni.nazevPredmetu} nelze vložit do {nazevUloziste}, protože ho nyní máte vybavený.");
                                Tlacitko();
                                return;
                            }
                            if(pKUlozeni is Specialni)
                            {
                                Clear();
                                ForegroundColor = ConsoleColor.DarkBlue;
                                WriteLine($"Předmět {pKUlozeni.nazevPredmetu} nelze vložit do {nazevUloziste}, protože je speciálním předmětem.");
                                Tlacitko();
                                return;
                            }
                            if (ulozisteInv.ZiskejPocetPredmetu(6) >= maxKapacitaUlo && pKUlozeni != Zlaťák)
                            {
                                Clear();
                                ForegroundColor = ConsoleColor.Red;
                                WriteLine();
                                WriteLine($"Předmět {pKUlozeni.nazevPredmetu} nelze vložit do {nazevUloziste}, kapacita by byla přesažena...");
                                Tlacitko();
                                return;
                            }
                            if (pKUlozeni.pocetPredmetu(hracuvInv) > 1)
                            {
                                MnozsteniVlozeni(hracuvInv, ulozisteInv, pKUlozeni, nazevUloziste);
                                return;
                            }
                            Clear();
                            ForegroundColor = ConsoleColor.Green;
                            WriteLine();
                            WriteLine($"Předmět {pKUlozeni.nazevPredmetu} byl úspěšně vložen do {nazevUloziste}!");
                            ulozisteInv.PridejPredmet(pKUlozeni);
                            hracuvInv.OdeberPredmet(pKUlozeni);
                            Tlacitko();
                            return;
                        }


                    }
                    void VybraniZUloziste(Inventar hracuvInv, Inventar ulozisteInv, string nazevUloziste)
                    {
                        while (true)
                        {

                            var seskupeniUlozisteInv = ulozisteInv.ListInventare().GroupBy(G => G.ID).Select(g => g.First()).ToList();
                            var displejUlozisteInv = seskupeniUlozisteInv.Select(p => "(" + p.pocetPredmetu(ulozisteInv) + ") " + p.nazevPredmetu + (p.pocetVylepseniPredmetu > 1 ? $" ({p.pocetVylepseniPredmetu - 1}x Vylepšeno)" : "")).ToList();
                            if (!seskupeniUlozisteInv.Any())
                            {
                                Clear();
                                ForegroundColor = ConsoleColor.Magenta;
                                WriteLine();
                                WriteLine($"V uložišti {nazevUloziste} zatím nejsou žádné předměty, zkuste nějaké přidat!");
                                Tlacitko();
                                break;
                            }
                            displejUlozisteInv.Add("Vrátit se");
                            Menu vyberPredmetuKVyb = new Menu($"Vyberte předmět, který si chcete vzít z {nazevUloziste}" + VypisKapacit(ulozisteInv, hracuvInv, nazevUloziste), displejUlozisteInv, ConsoleColor.DarkYellow);
                            int volba = vyberPredmetuKVyb.NavratIndexu();
                            if (volba == displejUlozisteInv.Count - 1)
                                break;
                            Predmety pKVybrani = seskupeniUlozisteInv[volba];
                            Clear();
                            if (hracuvInv.ZiskejPocetPredmetu(6) >= VasePostava.hracovaPostava.AktualizaceKapacity() && pKVybrani != Zlaťák)
                            {
                                ForegroundColor = ConsoleColor.Red;
                                WriteLine();
                                WriteLine($"Vybráním předmětu {pKVybrani.nazevPredmetu} přesáhnete doporučenou kapacitu Vašeho inventáře (Varování).");
                                Tlacitko();
                            }
                            if (pKVybrani.pocetPredmetu(ulozisteInv) > 1)
                            {
                                MnozsteniVybrani(hracuvInv, ulozisteInv, pKVybrani, nazevUloziste);
                                return;
                            }
                            ForegroundColor = ConsoleColor.Green;
                            WriteLine();
                            WriteLine($"Předmět {pKVybrani.nazevPredmetu} byl úspěšně vybrán z {nazevUloziste}!");
                            hracuvInv.PridejPredmet(pKVybrani);
                            ulozisteInv.OdeberPredmet(pKVybrani);
                            Tlacitko();
                            return;
                        }


                    }
                    string VypisKapacit(Inventar Ulozny, Inventar Hracuv, string nazevUloziste)
                    {
                        string h = $"\n\nDoporučená kapacita Vašeho inventáře: {Hracuv.ZiskejPocetPredmetu(6)}/{VasePostava.hracovaPostava.AktualizaceKapacity()}\n\n";
                        string u = $"Kapacita uložiště {nazevUloziste}: {Ulozny.ZiskejPocetPredmetu(6)}/{maxKapacitaUlo}\n";
                        return h + u;
                    }
                    void MnozsteniVlozeni(Inventar i, Inventar iV, Predmety p, string nazevUloziste)
                    {
                        int pocetKV;
                        if (p.pocetPredmetu(i) > 1)
                        {
                            Clear();
                            ForegroundColor = ConsoleColor.Blue;
                            WriteLine($"Vypadá to, že v Inventáři máte více předmětů {p.nazevPredmetu}, kolik jich chcete uložit?");
                            WriteLine();
                            WriteLine($"Zadejte číslo od 1 do {p.pocetPredmetu(i)}.");
                            WriteLine();
                            CursorVisible = true;
                            while (!int.TryParse(ReadLine(), out pocetKV) || pocetKV < 1 || pocetKV > p.pocetPredmetu(i))
                            {
                                ForegroundColor = ConsoleColor.Red;
                                WriteLine();
                                WriteLine($"Zadejte číslo od 1 do {p.pocetPredmetu(i)}");
                                WriteLine();
                                ForegroundColor = ConsoleColor.Blue;
                            }
                            CursorVisible = false;
                            ForegroundColor = ConsoleColor.Green;
                            WriteLine();
                            WriteLine($"Budou uloženy {pocetKV} předměty {p.nazevPredmetu} do {nazevUloziste}. Uložení budete mít přílžitost zrušit.");
                            GameplayLokaci_1.Tlacitko();
                            Menu potvrzeni = new Menu($"Přejete si uložit {pocetKV} předměty {p.nazevPredmetu}?", new List<string> { "Ano", "Ne" }, ConsoleColor.Blue);
                            int g = potvrzeni.NavratIndexu();
                            if (g == 1)
                                return;
                            else
                            {
                                Clear();
                                for (int k = 0; k < pocetKV; k++)
                                {
                                    i.OdeberPredmet(p);
                                    iV.PridejPredmet(p);
                                }
                                ForegroundColor = ConsoleColor.Green;
                                WriteLine();
                                WriteLine($"{pocetKV} předmětů {p.nazevPredmetu} bylo vloženo do {nazevUloziste}.");
                                Tlacitko();
                            }
                        }
                    }
                    void MnozsteniVybrani(Inventar i, Inventar iVyb, Predmety p, string nazevUloziste)
                    {
                        int pocetKV;
                        if (p.pocetPredmetu(iVyb) > 1)
                        {
                            Clear();
                            ForegroundColor = ConsoleColor.Blue;
                            WriteLine($"Vypadá to, že v {nazevUloziste} je více předmětů {p.nazevPredmetu}, kolik jich chcete vybrat?");
                            WriteLine();
                            WriteLine($"Zadejte číslo od 1 do {p.pocetPredmetu(iVyb)}.");
                            WriteLine();
                            CursorVisible = true;
                            while (!int.TryParse(ReadLine(), out pocetKV) || pocetKV < 1 || pocetKV > p.pocetPredmetu(iVyb))
                            {
                                ForegroundColor = ConsoleColor.Red;
                                WriteLine();
                                WriteLine($"Zadejte číslo od 1 do {p.pocetPredmetu(iVyb)}");
                                WriteLine();
                                ForegroundColor = ConsoleColor.Blue;
                            }
                            CursorVisible = false;
                            ForegroundColor = ConsoleColor.Green;
                            WriteLine();
                            WriteLine($"Budou vybrány {pocetKV} předměty {p.nazevPredmetu} z {nazevUloziste}. Vybrání budete mít přílžitost zrušit.");
                            GameplayLokaci_1.Tlacitko();
                            Menu potvrzeni = new Menu($"Přejete si vybrat {pocetKV} předměty {p.nazevPredmetu}?", new List<string> { "Ano", "Ne" }, ConsoleColor.Blue);
                            int g = potvrzeni.NavratIndexu();
                            if (g == 1)
                                return;
                            else
                            {
                                Clear();
                                for (int k = 0; k < pocetKV; k++)
                                {
                                    i.PridejPredmet(p);
                                    iVyb.OdeberPredmet(p);
                                }
                                ForegroundColor = ConsoleColor.Green;
                                WriteLine();
                                WriteLine($"{pocetKV} předmětů {p.nazevPredmetu} bylo vybráno z {nazevUloziste}.");
                                Tlacitko();
                            }
                        }
                    }

                }
            }
            void EventDum(int cislo = 0)
            {
                EventH = true;
                if (VasePostava.inventarPostavy.ZiskejPocetPredmetu(6) > VasePostava.hracovaPostava.AktualizaceKapacity() || u1.ZiskejPocetPredmetu(6) > maxKapacitaUlo
                    || u2.ZiskejPocetPredmetu(6) > maxKapacitaUlo || u3.ZiskejPocetPredmetu(6) > maxKapacitaUlo)
                    cislo = r.Next(5, 7);
                else
                    cislo = r.Next(-1, 5);
                if (cislo == 6)
                {
                    cislo = r.Next(0, 3);
                    var vybranyInv = VyberUloziste(cislo);
                    string jmenoInv = VyberNazev(cislo);
                    ForegroundColor = ConsoleColor.DarkRed;
                    Clear();
                    WriteLine();
                    WriteLine("Vypadá to, že v době Vaší nepřítomnosti někdo probral Vaše věci...");
                    WriteLine();
                    WriteLine($"Dotyčný vybral všechny věci z Vašeho uložiště {jmenoInv}.");
                    WriteLine();
                    if (vybranyInv.ListInventare().Count == 0)
                    {
                        WriteLine("Naštěstí pro Vás se v tomto uložišti nic nenacházelo.");
                        Tlacitko();
                        return;
                    }
                    if (!(VasePostava.inventarPostavy.ZiskejPocetPredmetu(6) > VasePostava.hracovaPostava.AktualizaceKapacity()))
                        WriteLine("Možná by se to nestalo, kdyby Vaše uložiště němělo více věcí, než je jeho kapacita...");
                    else
                        WriteLine("Možná, kdyby jste na zádech nenesli náklad, který překračuje doporučenou kapacitu a dorazili dříve, nestalo by se to...");
                    Tlacitko();
                    vybranyInv.ListInventare().Clear();
                    Inventar VyberUloziste(int c)
                    {
                        if (c == 0)
                            return u1;
                        if (c == 1)
                            return u2;
                        if (c == 2)
                            return u3;
                        else
                            throw new Exception("špatné číslo ve výběru inventáře (výběr uložiště)");
                    }
                    string VyberNazev(int c)
                    {
                        if (c == 0)
                            return u1Nazev;
                        if (c == 1)
                            return u2Nazev;
                        if (c == 2)
                            return u3Nazev;
                        else
                            throw new Exception("špatné číslo ve výběru inventáře (výběr názvu)");
                    }
                }
                else if (cislo == 5)
                {
                    ForegroundColor = ConsoleColor.DarkRed;
                    Clear();
                    WriteLine();
                    WriteLine("Vypadá to, že v domě máte nezvaného hosta.");
                    WriteLine();
                    WriteLine($"Dotyčného jste přerušili na počátku loupeže Vašeho domu. Bez rozmyslu na Vás útočí...");
                    Tlacitko();
                    Souboj(VasePostava.hracovaPostava, new Bandita(), false, true);
                    WriteLine();
                    Clear();
                    ForegroundColor = ConsoleColor.DarkRed;
                    if (!(VasePostava.inventarPostavy.ZiskejPocetPredmetu(6) > VasePostava.hracovaPostava.AktualizaceKapacity()))
                        WriteLine("Dotyčný by se možná neobjevil, kdyby neviděl věci přetékající z Vašeho uložiště, které má překročenou maximální kapacitu.");
                    else
                        WriteLine("Možná, kdyby jste na zádech nenesli náklad, který překračuje doporučenou kapacitu a dorazili dříve, šlo tomu zabránit...");
                    Tlacitko();
                }
                else if (cislo == 4)
                {
                    ForegroundColor = ConsoleColor.Blue;
                    Clear();
                    WriteLine();
                    WriteLine("Od Vaší poslední návštěvy Vám někdo na stole nechal knihu...");
                    WriteLine();
                    WriteLine("Kniha je plná zajímavých informací o artefaktech a magii.");
                    WriteLine();
                    VasePostava.hracovaPostava.vInteligence += 1;
                    WriteLine($"Inteligence se Vám proto zvýšila o 1, její hodnota je nyní {VasePostava.hracovaPostava.vInteligence}.");
                    Tlacitko();
                }
                else if (cislo == 3)
                {
                    ForegroundColor = ConsoleColor.Yellow;
                    Clear();
                    WriteLine();
                    WriteLine("Od Vaší poslední návštěvy Vám někdo na stole nechal knihu...");
                    WriteLine();
                    WriteLine("Kniha je plná zajímavých informací o akrobacii a plížení.");
                    WriteLine();
                    VasePostava.hracovaPostava.vObratnost += 1;
                    WriteLine($"Obratnost se Vám proto zvýšila o 1, její hodnota je nyní {VasePostava.hracovaPostava.vObratnost}.");
                    Tlacitko();
                }
                else if (cislo == 2)
                {
                    ForegroundColor = ConsoleColor.Red;
                    Clear();
                    WriteLine();
                    WriteLine("Od Vaší poslední návštěvy Vám někdo na stole nechal knihu...");
                    WriteLine();
                    WriteLine("Kniha je plná zajímavých informací o obraně a útoku v souboji.");
                    WriteLine();
                    VasePostava.hracovaPostava.vSila += 1;
                    WriteLine($"Síla se Vám proto zvýšila o 1, její hodnota je nyní {VasePostava.hracovaPostava.vSila}.");
                    Tlacitko();
                }
                else if (cislo == 1)
                {
                    ForegroundColor = ConsoleColor.Cyan;
                    Clear();
                    WriteLine();
                    WriteLine("Od Vaší poslední návštěvy Vám někdo na stole nechal knihu...");
                    WriteLine();
                    WriteLine("Kniha je plná zajímavých informací o způsobech, jak vyváznout z každé situace.");
                    WriteLine();
                    VasePostava.hracovaPostava.vStesti += 1;
                    WriteLine($"Štěstí se Vám proto zvýšilo o 1, jeho hodnota je nyní {VasePostava.hracovaPostava.vStesti}.");
                    Tlacitko();
                }
                else if (cislo == 0)
                {
                    ForegroundColor = ConsoleColor.DarkRed;
                    Clear();
                    WriteLine();
                    WriteLine("Vypadá to, že na Vás někdo najal dalšího zabijáka...");
                    WriteLine();
                    WriteLine($"Naštěstí si ho všímáte už u vchodových dveří a vrháte se do souboje.");
                    Tlacitko();
                    Souboj(VasePostava.hracovaPostava, new NajemnyZabijak(), false, true);
                }
                else return;
            }
        }

        //gameplay SkřetíPanství
        public static int pocetNavstev = 0;       
        private static List<Stvoreni> FinalSkret = new List<Stvoreni>() { };
        public static List<Stvoreni> KraloviPomocnici = new List<Stvoreni>() { };
        public static void SkřetíPanství()
        {
            
            int pocetUspesnychSouboju = 0;
            List<Stvoreni> Skreti1 = new List<Stvoreni> { new SkretBojovnik(), new SkretBojovnik(), new SkretStrelec() };
            List<Stvoreni> Skreti2 = new List<Stvoreni> {new SkretStrelec(), new SkretBojovnik(), new SkretTravic() };
            List<Stvoreni> Skreti3 = new List<Stvoreni> { new SkretStrelec(), new SkretTravic(), new SkretTravic() };
            List<Stvoreni> Skreti4 = new List<Stvoreni> { new SkretTravic(), new SkretTravic(), new SkretTravic() };
            
            pocetNavstev++;
            if (pocetNavstev == 3)
                UzamkniLokace(Skřetí_Panství);
            Clear();
            ForegroundColor = ConsoleColor.DarkGreen;
            if(pocetNavstev == 1)
            {
                AnimaceTextu("Na Vašich cestách úplnou náhodou narážíte na malý tábor. Hemží se malými zelenými tvory, a nejsou zrovna přátelští...");
                AnimaceTextu("Celý jejich komplex můžete dobýt sami pro sebe a získat tak vše, co tyto zelené potvůrky vlastní.");
                AnimaceTextu("Do tohoto místa se můžete vrátit celkem třikrát. Pokud se Vám kdykoliv podaří místo úspěšně dobýt, bude Vaše, a s ním i jeho výhody.");
                AnimaceTextu("Čekají na Vás vlny skřetích nepřátel, které se pokouší místo bránit. Zabijete-li je všechny, místo bude dobyto.");
                AnimaceTextu("Pokud se po nějaké sekvenci soubojů nebudete cítit na další várku skřetů, můžete odejít.");
                AnimaceTextu("Když odejdete, Vaše odměna z dobývání bude dramaticky snížena - ale pořád lepší než zemřít a tak ztratit Váš drahocený život...");
                AnimaceTextu("Pokud se Vám ani na třetí pokus nepoodaří místo dobýt (ať už utečete nebo zemřete), lokace se uzavře a další dobývání nebude možné.");
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine();
                WriteLine("Hodně štěstí při dobývání!...");
                AnimaceTextu(".....");
                Tlacitko();
                Okradeni();
            }
            else
            {
                AnimaceTextu("Další návštěva, další skřeti... Hodně štěstí dobrodruhu!");
                Okradeni();
                Tlacitko();
            }
            WaveSouboj(Skreti1, 1);
            WaveSouboj(Skreti2, 2);
            WaveSouboj(Skreti3, 3);
            WaveSouboj(Skreti4, 4);
            FinalSkret.Add(new KralSkretu());
            WaveSouboj(FinalSkret, 5, false);
            Recepty.PridejReceptDoSeznamu(TvrobaPredmetu.RTrnova_Useň);
            WaveSouboj(KraloviPomocnici, 6, false);

            Clear();
            ForegroundColor = ConsoleColor.Green;
            AnimaceTextu("Poslední vlna byla úspěšně poražena, Skřetí Král padl...");
            AnimaceTextu("Ostatní skřetí po smrti jejich krále nemají zájem o další krveprolití. Teď poslouchají Vás!");
            AnimaceTextu("Gratulace k úspěšnému dobití skřetího panství, nyní je to Vaše panství.");
            AnimaceTextu("Můžete si najmout skřeta jako bojového společníka, obchodovat se skřetími překupníky, nebo se učit novým věcem!");
            Tlacitko();
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine();
            WriteLine("V panství jste našli nějaké poklady!");
            Tlacitko();
            Loot(VsechnyZbroje, 3);
            Loot(VsechnyZbrane, 3, ConsoleColor.Red);
            Loot(VsechnyKovSuroviny, 3, ConsoleColor.DarkCyan);
            Loot(VsechnyAlchSuroviny, 3, ConsoleColor.Cyan);
            Loot(VsechnyPouzitelne, 3, ConsoleColor.Yellow);
            Clear();
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine();
            WriteLine("Mimo to jste zde našli navíc ještě 15 zlata!");
            Inventar.PridejZlato(15, VasePostava.inventarPostavy);            
            Tlacitko();
            DokonciLokaci(Skřetí_Panství);
            DokonciFinalneLokaci(Skřetí_Panství);
            OdemkniLokace(Dobyté_Panství);
            //Lokace.VyberoveMenu();
            
            void WaveSouboj(List<Stvoreni> nepratele, int cisloVlny, bool odejitMenu = true)
            {
                if (nepratele == KraloviPomocnici && !KraloviPomocnici.Any())
                    return;
                foreach(Stvoreni s in nepratele)
                {
                    if(s is KralSkretu)
                    {
                        Souboj(VasePostava.hracovaPostava, s, true, true);
                        return;
                    }                    
                    if (s == nepratele[0] && nepratele.Count!=1)
                        Souboj(VasePostava.hracovaPostava, s, true, true);
                    else if (s == nepratele[^1] && nepratele.Count != 1)
                        Souboj(VasePostava.hracovaPostava, s, false, false);
                    else if (s == nepratele[^1] && nepratele.Count == 1)
                        Souboj(VasePostava.hracovaPostava, s, false, true);
                    else
                        Souboj(VasePostava.hracovaPostava, s, true, false);
                }
                Clear();
                ForegroundColor = ConsoleColor.DarkCyan;
                pocetUspesnychSouboju++;
                WriteLine();
                WriteLine($"Vlna číslo {cisloVlny} byla úspěšně poražena!");
                if(nepratele == FinalSkret && KraloviPomocnici.Any())
                {
                    WriteLine();
                    WriteLine("Je před Vámi poslední souboj s pomocníky Krále skřetů!");
                }
                Tlacitko();
                if(odejitMenu)
                Odejít();
            }
            void Odejít()
            {
                Clear();
                Menu Odejit = new Menu("Přejete si po této vlně skřetů odejít?", new List<string> { "Ne, bojotvat dále", "Ano, odejít" }, ConsoleColor.Red);
                int vb = Odejit.NavratIndexu();
                if(vb == 1)
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Blue;
                    WriteLine();
                    WriteLine("Úspěšně odcházíte, při dobývání jste nalezli následující předměty: ");
                    Tlacitko();
                    for (int i = 0; i < pocetUspesnychSouboju; i++)                   
                        Loot(NahodnyVyberKategoriePredmetu(), 2);
                    
                    ForegroundColor = ConsoleColor.Blue;
                    WriteLine();
                    WriteLine((3-pocetNavstev > 0)?$"Zbývá Vám ještě {3 - pocetNavstev} pokusů na dobytí!":"Toto byl Váš poslední pokus...třeba se to podaří jinému dobrodruhoví.");
                    Tlacitko();
                    Lokace.VyberoveMenu();
                }
                else
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Blue;
                    WriteLine();
                    WriteLine("Připravte se na další vlnu nepřítel!"); ;
                    Tlacitko();
                }
            }
        }
        //gameplay VasehoPanstvi
        static int pnavstev = 0;
        public static bool DoplneniInv = false;
        static Dictionary<string, Action<int>> Vyuka = new Dictionary<string, Action<int>>
        {
    {"Síla",  i => VasePostava.hracovaPostava.vSila += i },
    {"Obratnost", i => VasePostava.hracovaPostava.vObratnost += i },
    {"Inteligence", i => VasePostava.hracovaPostava.vInteligence += i },
    {"Štěstí", i => VasePostava.hracovaPostava.vStesti += i },
    {"Základní útočná hodnota",i => VasePostava.hracovaPostava.zakladniUtocnaHodnota += i },
    {"Základní obranná hodnota", i => VasePostava.hracovaPostava.zakladniObrannaHodnota+=i }
        };
        static Inventar Zbrojirna = new Inventar();
            static Inventar Pouzitelne = new Inventar();
            static Inventar Suroviny = new Inventar();         
        public static void DobytePanstvi()
        {
            Clear();
                if (!DoplneniInv)
                DoplneniObchodniku(Zbrojirna, Pouzitelne, Suroviny);
            pnavstev++;
            if(pnavstev == 1)
            {
                ForegroundColor = ConsoleColor.DarkCyan;
                AnimaceTextu("Vítejte ve Vašem novém panství! Skřeti se zde jeví po Vašem nájezdu přátelští, nabízejí Vám své služby.");
                AnimaceTextu("Můžete zde nakoupit různé věci, najmout si skřetího společníka, nebo zvýšit své atributy učením se nových věcí!");
                AnimaceTextu("Skřeti však mají omezené zásoby. třeba když půjdete na další výpravu, zásoby se obnoví...");
                AnimaceTextu("Užijte si návštěvu Vašeho nového panství!");
                AnimaceTextu("......");
                AnimaceTextu("Tip: Skřetí obchody mají lepší prodejní ceny, než většina městských obchodů, na které narazíte!");
                Tlacitko();
            }
            while(true)
            {
                Menu VPanstvi = new Menu("Vyberte si, co chcete ve Vašem novém panství dělat", new List<string> { "Obchodovat", "Najmout si společníka", "Naučit se novým večem", "Odejít" }, ConsoleColor.DarkCyan);
                int volba = VPanstvi.NavratIndexu();
                if (volba == 3)
                    break;
                else if (volba == 0)
                    Obchodovani();
                else if (volba == 1)
                    NajmutiSpol();
                else if (volba == 2)
                    UceniSe();
            }
            void Obchodovani()
            {
               while(true)
               {
                    Menu obchodniMenu = new Menu("Vyberte si, ze kterého skřetího obchodu chcete nakupovat", new List<string> { "Zbrojírna", "Alchymistická Laboratoř", "Obchod se surovinami", "Odejít" }, ConsoleColor.DarkCyan);
                    int volba = obchodniMenu.NavratIndexu();
                    if (volba == 0)
                        Obchod.KovarnaObchod(VasePostava.inventarPostavy, Zbrojirna, "Skřetí", 0.75);
                    else if (volba == 1)
                        Obchod.LaboratorObchod(VasePostava.inventarPostavy, Pouzitelne, "Skřetí", 0.75);
                    else if (volba == 2)
                        Obchod.SurovinyObchod(VasePostava.inventarPostavy, Suroviny, "Skřetím", 0.75);
                    else
                        break;
               }
             
            }
            void NajmutiSpol()
            {
                int Cena = 6;
                while(true)
                {
                    Menu spolecnikS = new Menu($"Přejete si najmout skřetího společníka? (tento společník nemizí, když souboj skončí a stojí {Cena} zlatých)\n\nNyní máte {VasePostava.inventarPostavy.PocetZlata()} zlata", new List<string> { "Ano", "Ne" }, ConsoleColor.DarkCyan);
                    int v = spolecnikS.NavratIndexu();
                    if (v == 1)
                        break;
                    else
                    {

                        if (VasePostava.spolecnik != null && VasePostava.inventarPostavy.PocetZlata() >=Cena)
                        {
                            Clear();
                            Menu m = new Menu($"Vypadá to, že již máte společníka ({VasePostava.spolecnik.nazevStvoreni}). Přejete si ho zaměnit za nového Skřetího společníka?", new List<string> { "Ano", "Ne" }, ConsoleColor.Red);
                            int t = m.NavratIndexu();
                            if (t == 0)
                            {
                                Inventar.OdeberZlato(Cena, VasePostava.inventarPostavy);
                                VasePostava.spolecnik = new SkretBojovnik();
                                Clear();
                                ForegroundColor = ConsoleColor.DarkGreen;
                                WriteLine();
                                WriteLine("Výbroně, skřet je nyní Váš společník...");
                                Tlacitko();
                            }
                            else break;
                        }
                        else if(VasePostava.spolecnik == null && VasePostava.inventarPostavy.PocetZlata() >= Cena)
                        {
                            Inventar.OdeberZlato(Cena, VasePostava.inventarPostavy);
                            VasePostava.spolecnik = new SkretBojovnik();
                            Clear();
                            ForegroundColor = ConsoleColor.DarkGreen;
                            WriteLine();
                            WriteLine("Výbroně, skřet je nyní Váš společník...");
                            Tlacitko();
                        }
                        else
                        {
                            Clear();
                            ForegroundColor = ConsoleColor.Red;
                            WriteLine();
                            WriteLine($"Vypadá to, že na skřeta nemáte dost peněz. Stojí {Cena} zlatých a Vy máte jen {VasePostava.inventarPostavy.PocetZlata()}.");
                            Tlacitko();
                        }
                    }
                    
                }   
                
            }
            void UceniSe()
            {
                int cena = 8;
                while (true)
                {
                    var MenuSkillu = Vyuka.Keys.ToList();
                    MenuSkillu.Add("Odejít");
                    Menu m = new Menu($"Ve kterém atributu se chcete zlepšit?\n\nCena je {cena} zlatých za atribut, nyní máte {VasePostava.inventarPostavy.PocetZlata()} zlata", MenuSkillu, ConsoleColor.Blue);
                    int c = m.NavratIndexu();
                    if (c == MenuSkillu.Count - 1)
                        break;
                    string vybranyAtribut = MenuSkillu[c];
                    Uceni(vybranyAtribut);
       
                }

                void Uceni(string nazev)
                {
                    if(VasePostava.inventarPostavy.PocetZlata() < cena)
                    {
                        Clear();
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine();
                        WriteLine("Nemáte dostatek peněz na výuku, cena je {0} zlatých a Vy máte jen {1}.", cena ,VasePostava.inventarPostavy.PocetZlata());
                        Tlacitko();
                        return;
                    }
                    else
                    {
                        Inventar.OdeberZlato(cena, VasePostava.inventarPostavy);
                        ForegroundColor = ConsoleColor.Blue;
                        Clear();
                        WriteLine();
                        WriteLine("Výborě, výukou se Vám zvýšil atribut {0} o 1!", nazev);
                        Vyuka[nazev](1);
                        int atribut = 0;
                        switch (nazev)
                        {
                            case "Síla": atribut = VasePostava.hracovaPostava.vSila; break;
                            case "Obratnost": atribut = VasePostava.hracovaPostava.vObratnost; break;
                            case "Inteligence": atribut = VasePostava.hracovaPostava.vInteligence; break;
                            case "Štěstí": atribut = VasePostava.hracovaPostava.vStesti; break;
                            case "Základní útočná hodnota": atribut = VasePostava.hracovaPostava.zakladniUtocnaHodnota;
                                VasePostava.hracovaPostava.RekonfiguraceAltUH(); VasePostava.hracovaPostava.RekonfiguraceUH(); break;
                            case "Základní obranná hodnota":
                                atribut = VasePostava.hracovaPostava.zakladniObrannaHodnota;
                                VasePostava.hracovaPostava.RekonfiguraceOH(); break;
                                    }
                        WriteLine();
                        WriteLine("Hodnota atributu {0} je nyní {1}.", nazev, atribut);
                        Tlacitko();
                        Vyuka.Remove(nazev);
                    }
                }
            }
            void DoplneniObchodniku(Inventar iZ, Inventar iP, Inventar iS)
                 {
                if (DoplneniInv)
                    return;
                DoplneniInv = true;
                Vyuka = new Dictionary<string, Action<int>>
                    {
                  {"Síla",  i => VasePostava.hracovaPostava.vSila += i },
                {"Obratnost", i => VasePostava.hracovaPostava.vObratnost += i },
                {"Inteligence", i => VasePostava.hracovaPostava.vInteligence += i },
                {"Štěstí", i => VasePostava.hracovaPostava.vStesti += i },
                {"Základní útočná hodnota",i => VasePostava.hracovaPostava.zakladniUtocnaHodnota += i },
                {"Základní obranná hodnota", i => VasePostava.hracovaPostava.zakladniObrannaHodnota+=i }
                    };
                DoplneniInventareFull(iZ, VsechnyZbroje);
                DoplneniInventareFull(iZ, VsechnyZbrane);
                DoplneniInventareFull(iP, VsechnyPouzitelne);
                DoplneniInventareFull(iS, VsechnyKovSuroviny);
                DoplneniInventareFull(iS, VsechnyAlchSuroviny);
                    void DoplneniInventareFull(Inventar invKdoplneni3x, List<Predmety> doplnuji)
                    {
                        foreach(Predmety P in doplnuji)
    {                       
                            if (P.pocetPredmetu(invKdoplneni3x) < 5)
                            {                           
                                while (P.pocetPredmetu(invKdoplneni3x) < 5)
                                {
                                    invKdoplneni3x.PridejPredmet(P);
                                
                                }
                            }
                        }

                    }
                 }
        }
    }
}
