using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static DnD_Hra.VytvorenePredmety;
using static System.Console;

namespace DnD_Hra
{
    internal sealed class Inventar
    {
        
        private List<Predmety> ObsahInventare;

        public Inventar()
        {
            ObsahInventare = new List<Predmety>();
        }

        public void PridejPredmet(Predmety predmet)
        {           
            if (predmet != null)
            {                            
                ObsahInventare.Add(predmet);                
            }
        }

        public void OdeberPredmet(Predmety predmet)
        {
            if (ObsahInventare.Contains(predmet))
            {
                
                
              ObsahInventare.Remove(predmet);
                
            }
        }

        public int PocetPredmetu(Predmety predmet)
        {
            if (ObsahInventare.Contains(predmet))
                return predmet.pocetPredmetu(this);
            else
                return 0;
        }

        public bool MaPredmet(Predmety predmet)
        {
            if (ObsahInventare.Contains(predmet) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
        public void ZobrazVsechnyPredmety()
        {
            Console.Clear();

            var groupings = ObsahInventare.GroupBy(p => p.typPredmetu);
            foreach (var grouping in groupings)
            {
                Console.ForegroundColor = GetTypPredmetuColor(grouping.Key);
                Console.WriteLine($" {grouping.Key}:");
                Console.WriteLine();
                grouping.Distinct().ToList().ForEach(p =>
                {
                    string additionalInfo = "";
                    if (p == VasePostava.zbranPostavy || p == VasePostava.zbrojPostavy || p == VasePostava.alternativniZbranPostavy)
                    {
                        additionalInfo += " (Vybaveno)";
                    }
                    if (p.pocetVylepseniPredmetu > 1)
                    {
                        additionalInfo += $" ({p.pocetVylepseniPredmetu - 1}x Vylepšeno)";
                    }
                    if (p is Zbrane zbrane && zbrane.schopnostZbrane != null)
                    {
                        additionalInfo += " (Se schopností)";
                    }
                    if (p is Zbroje zbroje && zbroje.schopnostZbroje != null)
                    {
                        additionalInfo += " (Se schopností)";
                    }

                    Console.WriteLine($"  ({p.pocetPredmetu(this)}) {p.nazevPredmetu}{additionalInfo}");
                    Console.WriteLine();
                });
            }
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine();
            Write($" Celkové zaplnění inventáře / Doporučený limit celkového zaplnění:");
            if (ZiskejPocetPredmetu(6) <= VasePostava.hracovaPostava.AktualizaceKapacity())
                ForegroundColor = ConsoleColor.Green;
            else
                ForegroundColor = ConsoleColor.Red;
            Write($" {ZiskejPocetPredmetu(6)}/{VasePostava.hracovaPostava.AktualizaceKapacity()}");
            WriteLine();
            Console.ResetColor();
            Thread.Sleep(100);
            Console.WriteLine();
            Console.WriteLine("stiskněte libovolné tlačítko...");
            Console.ReadKey(true);
            Console.Clear();
        }

        private ConsoleColor GetTypPredmetuColor(TypPredmetu typPredmetu)
        {
            switch (typPredmetu)
            {
                case TypPredmetu.Pouzitelne:
                    return ConsoleColor.Cyan;
                case TypPredmetu.Suroviny:
                    return ConsoleColor.DarkYellow;
                case TypPredmetu.Specialni:
                    return ConsoleColor.DarkBlue;
                case TypPredmetu.Zbrane:
                    return ConsoleColor.Red;
                case TypPredmetu.Zbroje:
                    return ConsoleColor.Blue;
                default:
                    throw new ArgumentException($"Invalid value of {nameof(TypPredmetu)}: {typPredmetu}", nameof(typPredmetu));
            }
        }

        public void ZobrazPredmetyPodleTypu(TypPredmetu typPredmetu)
        {
            int typP = (int)typPredmetu + 1;
            Console.Clear();
            string typPredmetuString = "";
            ConsoleColor barvaPredmetu = ConsoleColor.White;

            switch (typPredmetu)
            {
                case TypPredmetu.Zbrane:
                    typPredmetuString = " Zbraně:";
                    barvaPredmetu = ConsoleColor.Red;
                    break;
                case TypPredmetu.Zbroje:
                    typPredmetuString = " Zbroje:";
                    barvaPredmetu = ConsoleColor.Blue;
                    break;
                case TypPredmetu.Pouzitelne:
                    typPredmetuString = " Použitelné:";
                    barvaPredmetu = ConsoleColor.Cyan;
                    break;
                case TypPredmetu.Specialni:
                    typPredmetuString = " Speciální:";
                    barvaPredmetu = ConsoleColor.DarkBlue;
                    break;
                case TypPredmetu.Suroviny:
                    typPredmetuString = " Suroviny:";
                    barvaPredmetu = ConsoleColor.DarkYellow;
                    break;
                default:
                    break;
            }

            Console.ForegroundColor = barvaPredmetu;
            Console.WriteLine(typPredmetuString);
            Console.WriteLine();

            foreach (Predmety p in ObsahInventare.Distinct())
            {
                if (p.typPredmetu == typPredmetu)
                {
                    Console.ForegroundColor = barvaPredmetu;

                    string vybavenoString = (p == VasePostava.zbranPostavy || p == VasePostava.zbrojPostavy || p == VasePostava.alternativniZbranPostavy) ? " (Vybaveno)" : "";
                    string vylepsenoString = (p.pocetVylepseniPredmetu > 1) ? string.Format(" ({0}x Vylepšeno)", p.pocetVylepseniPredmetu - 1) : "";
                    string schopnostString = "";

                    if (p is Zbrane && (p as Zbrane).schopnostZbrane != null)
                    {
                        schopnostString = " (Se schopností)";
                    }
                    else if (p is Zbroje && (p as Zbroje).schopnostZbroje != null)
                    {
                        schopnostString = " (Se schopností)";
                    }

                    Console.WriteLine("  ({0}) {1}{2}{3}{4}{5}", p.pocetPredmetu(this), p.nazevPredmetu, vybavenoString, vylepsenoString, schopnostString, Environment.NewLine);
                }
            }
            ForegroundColor = ConsoleColor.Yellow;
            var novyTyp = typPredmetuString.Replace(":", "");            
            Write($" Zaplnění inventáře typem předmětu{novyTyp} / Doporučený limit celkového zaplnění: ");
            if (ZiskejPocetPredmetu(typP) <= VasePostava.hracovaPostava.AktualizaceKapacity())
                ForegroundColor = ConsoleColor.Green;
            else
                ForegroundColor = ConsoleColor.Red;
            Write($"{ZiskejPocetPredmetu(typP)}/{VasePostava.hracovaPostava.AktualizaceKapacity()}");
            Console.ResetColor();
            Thread.Sleep(100);
            Console.WriteLine();
            WriteLine();
            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
            Console.ReadKey(true);
            Console.Clear();
        }
        /// <summary>
        /// 1 - zbraně, 2 - zbroje, 3 - použitelné, 4 - Suroviny, 5 - speciální, 6 - všechny
        /// </summary>
        /// <param name="typ"></param>
        /// <returns></returns>
        public int ZiskejPocetPredmetu(int typ)
        {
            if (typ == 1)
                return ObsahInventare.OfType<Zbrane>().Count();
            else if (typ == 2)
                return ObsahInventare.OfType<Zbroje>().Count();
            else if (typ == 3)
            {
                var bezZlata = ObsahInventare.Where(p => p != Zlaťák);
                return bezZlata.OfType<Pouzitelne>().Count();
            }

            else if (typ == 4)
                return ObsahInventare.OfType<Suroviny>().Count();
            else if (typ == 5)
                return ObsahInventare.OfType<Specialni>().Count();
            else if (typ == 6)
            {
                var bezZlata = ObsahInventare.Where(p => p != Zlaťák).ToList();
                return bezZlata.Count;
            }
            else
                throw new Exception("Číslo není v rámci definice typů předmětů");
        }

        public List<Predmety> ListInventare()
        {
            return ObsahInventare;
        }

        public int PocetZlata()
        {
            if (ObsahInventare.Contains(Zlaťák))
                return Zlaťák.pocetPredmetu(this);
            else
                return 0;
        }

        public static void PridejZlato(int pocetZlataKPridani, Inventar inventar)
        {
            for (int i = 0; i < pocetZlataKPridani; i++)
                inventar.PridejPredmet(Zlaťák);
        }

        public static void OdeberZlato(int pocetZlataKOdebrani, Inventar inventar)
        {
            for (int i = 0; i < pocetZlataKOdebrani; i++)
                inventar.OdeberPredmet(Zlaťák);
        }

        //vybavení
        public static void OdeberVseHraci()
        {
            VasePostava.inventarPostavy.ListInventare().Clear();
            VasePostava.zbranPostavy = Žádná_Zbraň;
            VasePostava.zbrojPostavy = Žádná_Zbroj;
            VasePostava.vybavenaZbran = Žádná_Zbraň;
            VasePostava.vybavenaZbroj = Žádná_Zbroj;
            if (VasePostava.alternativniZbranPostavy != null && VasePostava.vybavenaAltZbran != null)
            {
                VasePostava.alternativniZbranPostavy = Žádná_Zbraň;
                VasePostava.hracovaPostava.RekonfiguraceAltUH();
            }
            VasePostava.hracovaPostava.RekonfiguraceOH();
            VasePostava.hracovaPostava.RekonfiguraceUH();
        }

        public static void VybavitSe(Inventar hracuvInventar)
        {
            while (true)
            {
                int zvolenyIndex = ZobrazMenuVybaveni(hracuvInventar);
                if (zvolenyIndex == 2)
                {
                    break;
                }
                if (zvolenyIndex == 0)
                {
                    VybavZbran(hracuvInventar);
                }
                else if (zvolenyIndex == 1)
                {
                    VybavZbroj(hracuvInventar);
                }
            }
        }

        private static int ZobrazMenuVybaveni(Inventar hracuvInventar)
        {
            Console.CursorVisible = false;
            Menu menu = new Menu("Vyberte si, čím se chcete vybavit", new List<string> { "Zbraně", "Zbroje", "Vrátit se" }, ConsoleColor.Yellow);
            return menu.NavratIndexu();
        }

        private static void VybavZbran(Inventar hracuvInventar)
        {
            Console.Clear();
            while(true)
            {             
                var inventarZbrani = hracuvInventar.ListInventare().Where(p => p is Zbrane).GroupBy(G=> G.ID).Select(g => g.First()).ToList();         
                if (!VasePostava.hracovaPostava.maManu)
                {
                    inventarZbrani.RemoveAll(p => ((Zbrane)p).manovaCena > 0);
                }

                if (!inventarZbrani.Any())
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nemáte žádné zbraně v inventáři.");
                    Console.ResetColor();
                    Thread.Sleep(100);
                    Console.WriteLine();
                    Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
                    Console.ReadKey(true);
                    return;
                }

                var listInventareZbrani = inventarZbrani.Select(p => p.nazevPredmetu + " (" + (p as Zbrane).poskozeniZbrane + " poškození)" + ((p as Zbrane).manovaCena > 0 ? $" (Útok stojí {(p as Zbrane).manovaCena} many)" : "") + (p == VasePostava.zbranPostavy || p == VasePostava.alternativniZbranPostavy ? " (Vybaveno)" : "") + (p.pocetVylepseniPredmetu > 1 ? $" ({p.pocetVylepseniPredmetu - 1}x Vylepšeno)" : "") + ((p as Zbrane).schopnostZbrane!= null? " (Se schopností)":"")).ToList();

                listInventareZbrani.Add("Vrátit zpět");
                Menu menuVybaveniZbrane = new Menu("Vyberte si zbraň k vybavení", listInventareZbrani, ConsoleColor.Yellow);
                int indexZbrane = menuVybaveniZbrane.NavratIndexu();
                if (indexZbrane == listInventareZbrani.Count - 1)
                {
                    break;
                }
                Zbrane vybranaZbran = (Zbrane)inventarZbrani[indexZbrane];
                if (vybranaZbran == VasePostava.zbranPostavy)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Tuto zbraň již máte vybavenou.");
                    Console.ResetColor();
                    Thread.Sleep(100);
                    Console.WriteLine();
                    Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
                    Console.ReadKey(true);
                    return;
                }
                if (vybranaZbran.manovaCena > VasePostava.hracovaPostava.pocetMany)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nemáte dostatek many na útok touto zbraní. Potřebná mana je {0}, Vaše postava má {1} many.", vybranaZbran.manovaCena, VasePostava.hracovaPostava.pocetMany);
                    Console.ResetColor();
                    Thread.Sleep(100);
                    Console.WriteLine();
                    Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
                    Console.ReadKey(true);
                    return;
                }
                if (VasePostava.alternativniZbranPostavy != null)
                {
                    Menu hlavniNeboAlt = new Menu("Přejete si tuto zbraň vybavit jako hlavní, nebo záložní zbraň?", new List<string> { "Hlavní", "Záložní" }, ConsoleColor.DarkBlue);
                    int vybranaMoznost = hlavniNeboAlt.NavratIndexu();
                    switch (vybranaMoznost)
                    {
                        case 0:
                            Console.Clear();
                            VasePostava.zbranPostavy = vybranaZbran;
                            VasePostava.vybavenaZbran = vybranaZbran;
                            VasePostava.hracovaPostava.RekonfiguraceUH();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine();
                            Console.WriteLine("Vybavili jste si zbraň {0} s poškozením {1}.", vybranaZbran.nazevPredmetu, vybranaZbran.poskozeniZbrane);
                            Thread.Sleep(150);
                            Console.WriteLine();
                            Console.WriteLine("Vaše útočná hodnota je po vybavení této zbraně {0}.", VasePostava.hracovaPostava.vUtocnaHodnota);
                            Console.ResetColor();
                            Thread.Sleep(100);
                            Console.WriteLine();
                            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
                            Console.ReadKey(true);
                            break;

                        case 1:
                            Console.Clear();
                            if (vybranaZbran.manovaCena > 0 || vybranaZbran.schopnostZbrane != null)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine();
                                if(vybranaZbran.manovaCena > 0)
                                Console.WriteLine("Záložní zbraň nemůže mít manovou cenu útoku větší než 0, aby Vaše postava mohla vždy zaútočit.");                                                               
                                else if(vybranaZbran.schopnostZbrane != null)
                                Console.WriteLine("Záložní zbraň nemůže mít schopnost.");
                                Console.ResetColor();
                                Thread.Sleep(100);
                                Console.WriteLine();
                                Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
                                Console.ReadKey(true);
                                return;
                            }
                            else
                            {
                                VasePostava.alternativniZbranPostavy = vybranaZbran;
                                VasePostava.vybavenaAltZbran = vybranaZbran;
                                VasePostava.hracovaPostava.RekonfiguraceAltUH();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine();
                                Console.WriteLine("Vybavili jste si záložní zbraň {0} s poškozením {1}.", vybranaZbran.nazevPredmetu, vybranaZbran.poskozeniZbrane);
                                Thread.Sleep(150);
                                Console.WriteLine();
                                Console.WriteLine("Vaše útočná hodnota záložním útokem je po vybavení této zbraně {0}.", VasePostava.hracovaPostava.altUtocnaHodnota);
                                Console.ResetColor();
                                Thread.Sleep(100);
                                Console.WriteLine();
                                Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
                                Console.ReadKey(true);

                                break;
                            }
                    }
                }
                else
                {
                    Console.Clear();
                    VasePostava.zbranPostavy = vybranaZbran;
                    VasePostava.vybavenaZbran = vybranaZbran;
                    VasePostava.hracovaPostava.RekonfiguraceUH();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine();
                    Console.WriteLine("Vybavili jste si zbraň {0} s poškozením {1}.", vybranaZbran.nazevPredmetu, vybranaZbran.poskozeniZbrane);
                    Thread.Sleep(150);
                    Console.WriteLine();
                    Console.WriteLine("Vaše útočná hodnota je po vybavení této zbraně {0}.", VasePostava.hracovaPostava.vUtocnaHodnota);
                    Console.ResetColor();
                    Thread.Sleep(100);
                    Console.WriteLine();
                    Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
                    Console.ReadKey(true);
                }
            }
        }

        private static void VybavZbroj(Inventar hracuvInventar)
        {
            Console.Clear();
            while(true)
            {

                var inventarZbroji = hracuvInventar.ListInventare().Where(p => p is Zbroje).GroupBy(G => G.ID).Select(g => g.First()).ToList();
                if (!inventarZbroji.Any())
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nemáte žádnou zbroj v inventáři.");
                    Console.ResetColor();
                    Thread.Sleep(100);
                    Console.WriteLine();
                    Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
                    Console.ReadKey(true);
                    return;
                }

                var listInventareZbroji = inventarZbroji.Select(p => p.nazevPredmetu + " (" + (p as Zbroje).hodnotaBrneni + " obranná hodnota)" + (p == VasePostava.zbrojPostavy ? " (Vybaveno)" : "") + (p.pocetVylepseniPredmetu > 1 ? $" ({p.pocetVylepseniPredmetu - 1}x Vylepšeno)" : "") + ((p as Zbroje).schopnostZbroje != null? " (Se schopností)":"")).ToList();
                listInventareZbroji.Add("Vrátit zpět");
                Menu menuVybaveniZbroje = new Menu("Vyberte si zbroj k vybavení", listInventareZbroji, ConsoleColor.Yellow);
                int indexZbroje = menuVybaveniZbroje.NavratIndexu();
                if (indexZbroje == listInventareZbroji.Count - 1)
                {
                    // Návrat do hlavního menu
                    break;
                }
                Zbroje vybranaZbroj = (Zbroje)inventarZbroji[indexZbroje];
                if (vybranaZbroj == VasePostava.zbrojPostavy)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("Tuto zbroj již máte vybavenou.");
                    Console.ResetColor();
                    Thread.Sleep(100);
                    Console.WriteLine();
                    Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
                    Console.ReadKey(true);
                    return;
                }
                Console.Clear();
                VasePostava.zbrojPostavy = vybranaZbroj;
                VasePostava.vybavenaZbroj = vybranaZbroj;
                VasePostava.hracovaPostava.RekonfiguraceOH();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine();
                Console.WriteLine("Vybavili jste si zbroj {0} s hodnotou brnění {1}.", vybranaZbroj.nazevPredmetu, vybranaZbroj.hodnotaBrneni);
                Thread.Sleep(150);
                Console.WriteLine();
                Console.WriteLine("Vaše obranná hodnota je po vybavení této zbroje {0}.", VasePostava.hracovaPostava.vObrannaHodnota);
                Console.ResetColor();
                Thread.Sleep(100);
                Console.WriteLine();
                Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
                Console.ReadKey(true);
            }
        }

        public static void OdeberNepotrebne(Inventar inventar)
        {
            if (inventar.ObsahInventare.Contains(Žádná_Zbraň))
                inventar.ObsahInventare.RemoveAll(z => z == Žádná_Zbraň);
            if (inventar.ObsahInventare.Contains(Žádná_Zbroj))
                inventar.ObsahInventare.RemoveAll(z => z == Žádná_Zbroj);
        }
        public static void OdebratPredmey(Inventar i)
        {
            string Vypis(int pocetVP, int maxCarryCap)
            {
                ForegroundColor = ConsoleColor.Yellow;
                if (pocetVP > maxCarryCap)
                {
                    string vypis1 = "Celkové zaplnění inventáře / Doporučený limit celkového zaplnění:";
                    ForegroundColor = ConsoleColor.Red;
                    string pomer = $" {pocetVP}/{maxCarryCap}";
                    return vypis1 + pomer;
                }
                else
                {
                    string vypis1 = "Celkové zaplnění inventáře / Doporučený limit celkového zaplnění:";
                    ForegroundColor = ConsoleColor.Green;
                    string pomer = $" {pocetVP}/{maxCarryCap}";
                    return vypis1 + pomer;
                }
            }
            int MC = VasePostava.hracovaPostava.AktualizaceKapacity();            
            while(true)
            {
                int pocetVsechP = VasePostava.inventarPostavy.ZiskejPocetPredmetu(6);
                Menu vyberTypu = new Menu(Vypis(pocetVsechP, MC) + $"\n\nVyberte kategorii předmětů, ze které budete vyhazovat:", new List<string> { "Zbraně", "Zbroje", "Použitelné", "Suroviny", "Odejít" }, ConsoleColor.Red);
                int volba = vyberTypu.NavratIndexu();
                if (volba == 4)
                    break;
                else if (volba == 0)
                    VyberPredmet(TypPredmetu.Zbrane);
                else if (volba == 1)
                    VyberPredmet(TypPredmetu.Zbroje);
                else if (volba == 2)
                    VyberPredmet(TypPredmetu.Pouzitelne);
                else if (volba == 3)
                    VyberPredmet(TypPredmetu.Suroviny);
            }

            void VyberPredmet(TypPredmetu typP)
            {
                while(true)
                {
                    int pocetVsechP = VasePostava.inventarPostavy.ZiskejPocetPredmetu(6);                  
                    var filtrPredmetu = i.ListInventare().Where(p => p.typPredmetu == typP).GroupBy(G => G.ID).Select(g => g.First()).ToList();
                    var nazvyPredmetu = filtrPredmetu.Select(p => "(" + p.pocetPredmetu(i) + ") "+ p.nazevPredmetu + (p == VasePostava.zbrojPostavy || p == VasePostava.zbranPostavy || p == VasePostava.alternativniZbranPostavy ? " (Vybaveno)" : "" + (p.pocetVylepseniPredmetu > 1 ? $" ({p.pocetVylepseniPredmetu - 1}x Vylepšeno)" : ""))).ToList();
                    nazvyPredmetu.Add("Vrátit se");
                    Menu odebraniZKategorie = new Menu(Vypis(pocetVsechP, MC) + $"\n\nVyberte předmět, který chcete vyhodit:", nazvyPredmetu, ConsoleColor.Magenta);
                    int index = odebraniZKategorie.NavratIndexu();
                    if (index == nazvyPredmetu.Count - 1)
                        break;
                    Predmety PkOdebrani = filtrPredmetu[index];
                    if(PkOdebrani is Specialni)
                    {
                        ForegroundColor = ConsoleColor.DarkBlue;
                        Clear();
                        WriteLine();
                        WriteLine($"Předmět {PkOdebrani.nazevPredmetu} je speciálním předmětem, nelze ho vyhodit...");
                        GameplayLokaci_1.Tlacitko();
                        return;
                    }
                    if (PkOdebrani == VasePostava.alternativniZbranPostavy || PkOdebrani == VasePostava.zbranPostavy || PkOdebrani == VasePostava.zbrojPostavy)
                        if(Vybaven(PkOdebrani))
                        {
                            ForegroundColor = ConsoleColor.DarkYellow;
                            Clear();
                            WriteLine();
                            WriteLine($"Odebrali jste předmět {PkOdebrani.nazevPredmetu}");
                            i.OdeberPredmet(PkOdebrani);
                            if(PkOdebrani == VasePostava.alternativniZbranPostavy)
                            {
                                VasePostava.alternativniZbranPostavy = Žádná_Zbraň;
                                VasePostava.hracovaPostava.RekonfiguraceAltUH();
                            }
                            else if(PkOdebrani == VasePostava.zbranPostavy)
                            {
                                VasePostava.zbranPostavy = Žádná_Zbraň;
                                VasePostava.hracovaPostava.RekonfiguraceUH();
                            }
                            else if(PkOdebrani == VasePostava.zbrojPostavy)
                            {
                                VasePostava.zbrojPostavy = Žádná_Zbroj;
                                VasePostava.hracovaPostava.RekonfiguraceOH();
                            }
                            WriteLine();
                            Thread.Sleep(250);
                            ResetColor();
                            WriteLine("stiskněte libovolné tlačítko...");
                            ReadKey(true);
                            Clear();
                            return;
                        }
                    if(PkOdebrani.pocetPredmetu(i) > 1)
                    {
                        MnozsteniVyhozeni(i, PkOdebrani);
                        return;
                    }
                    if (Potvrzeni(PkOdebrani))
                    {
                        ForegroundColor = ConsoleColor.DarkYellow;
                        Clear();
                        WriteLine();
                        WriteLine($"Odebrali jste předmět {PkOdebrani.nazevPredmetu}");
                        i.OdeberPredmet(PkOdebrani);
                        WriteLine();
                        Thread.Sleep(250);
                        ResetColor();
                        WriteLine("stiskněte libovolné tlačítko...");
                        ReadKey(true);
                        Clear();
                    }
                    bool Vybaven(Predmety p)
                    {
                       
                        Menu opravdu = new Menu($"Opravdu si přejete vyhodit předmět {p.nazevPredmetu}? Jste jím vybaveni", new List<string> { "Ano", "Ne" }, ConsoleColor.Red);
                        int v = opravdu.NavratIndexu();
                        if (v == 0)
                            return true;
                        else
                            return false;
                        
                    }
                }
              
            }
            bool Potvrzeni(Predmety p)
            {
                Menu opravdu = new Menu($"Opravdu si přejete vyhodit předmět {p.nazevPredmetu}?", new List<string> { "Ano", "Ne" }, ConsoleColor.Red);
                int v = opravdu.NavratIndexu();
                if (v == 0)
                    return true;
                else
                    return false;
            }
            void MnozsteniVyhozeni(Inventar i, Predmety p)
            {
                int pocetKV;
                if (p.pocetPredmetu(i) > 1)
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Blue;
                    WriteLine($"Vypadá to, že v Inventáři máte více předmětů {p.nazevPredmetu}, kolik jich chcete odebrat?");
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
                    WriteLine($"Budou odebrány {pocetKV} předměty {p.nazevPredmetu}. Odebrání budete mít přílžitost zrušit.");
                    GameplayLokaci_1.Tlacitko();
                    Menu potvrzeni = new Menu($"Přejete si odebrat {pocetKV} předměty {p.nazevPredmetu}?", new List<string> {"Ano", "Ne"}, ConsoleColor.Blue);
                    int g = potvrzeni.NavratIndexu();
                    if (g == 1)
                        return;
                    else
                    {
                        Clear();
                        for (int k = 0; k < pocetKV; k++)
                            i.OdeberPredmet(p);
                        ForegroundColor = ConsoleColor.Green;
                        WriteLine();
                        WriteLine($"{pocetKV} předmětů {p.nazevPredmetu} bylo odebráno.");
                        GameplayLokaci_1.Tlacitko();
                    }
                }
            }
        }
    }
}