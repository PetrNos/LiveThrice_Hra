using System;
using System.Collections.Generic;
using System.Threading;
using static DnD_Hra.VytvoreneLokace;

namespace DnD_Hra
{
    internal enum ObtiznostLokace
    { Začátečnická = 0, Jednoduchá = 1, Pokročilá = 2, Náročná = 3}   
    internal class Lokace
    {       
        private static List<Lokace> SeznamVsechLokaci = new List<Lokace> { Město_Valoria, Osobní_Domeček, Skřetí_Panství, Dobyté_Panství, Průsmyk_Hrdlořezů, 
            Všudypřítomná_Knihovna, Nadčasový_Les, Astralni_Prechod, Experimentální_Jádro, Znovuzrozeny_Les, Dabelska_Herna, Skoro_Legální_Dábelské_Casino,
        Satanuv_chrtan, Chrám_tří_srdcí};
        private static int pocetLokaci = SeznamVsechLokaci.Count - 1;             

        public string NazevLokace
        { get; set; }

        public ObtiznostLokace obtiznostLokace { get; private set; }
        private Action<Lokace> ArtLokace;
        private Action GameplayLokace;
       
        public bool _UzamcenaLokace { get; set; }
        public bool _DokoncenaLokace { get; set; }
        public bool _DokoncenaFinalneLokace { get; set; }
        public static void OdemkniLokace(Lokace l)
        {
            if (l._UzamcenaLokace)
                l._UzamcenaLokace = false;
        }
        public static void UzamkniLokace(Lokace l)
        {
            if (!l._UzamcenaLokace)
                l._UzamcenaLokace = true;
        }
        public static void DokonciLokaci(Lokace l)
        {
            l._DokoncenaLokace = true;
            GameplayLokaci_2.EventH = false;
        }

        public static void DokonciFinalneLokaci(Lokace l)
        {
            GameplayLokaci_2.EventH = false;
            if (l._DokoncenaLokace == true)
                l._DokoncenaFinalneLokace = true;
            else
            {
                Console.WriteLine("Finálně Lokace nemůže být dokončena, není ještě dokončena její obyčejná forma...[dev bug]");
                Console.ReadKey(true);
            }
        }
        
        public Lokace(string NazevLokace, ObtiznostLokace obtiznostLokace, Action<Lokace> ArtLokace, Action GameplayLokace, bool _UzamcenaLokace )
        {
            this.NazevLokace = NazevLokace;
            this.obtiznostLokace = obtiznostLokace;
            this.ArtLokace = ArtLokace;
            this.GameplayLokace = GameplayLokace;
            this._UzamcenaLokace = _UzamcenaLokace;
            ;
            _DokoncenaLokace = false;
            _DokoncenaFinalneLokace = false;           
        }

        public static void VyberoveMenu()
        {
            ConsoleKeyInfo keyInfo;
            int index = 0;
            do
            {
                Console.Clear();
                Lokace nynejsiLokace = SeznamVsechLokaci[index];
                nynejsiLokace.ArtLokace(nynejsiLokace);
                Console.ResetColor();
                Console.WriteLine("Stiskněte enter pro vstup do lokace. Levou a pravou šipku pro změnu lokace.");
                keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (nynejsiLokace._UzamcenaLokace)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Lokace je zamčená, nelze vstoupit");
                        Console.WriteLine();
                        Thread.Sleep(200);
                        Console.ResetColor();
                        Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                    else if (nynejsiLokace._DokoncenaFinalneLokace)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Lokace i její případné variace jsou dokončeny, zkuste jinou Lokaci a gratulujeme k úspěchu!");
                        Console.WriteLine();
                        Thread.Sleep(200);
                        Console.ResetColor();
                        Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                    else
                    {
                        Menu menu = new Menu($"Opravdu si přejete vstoupit do lokace {nynejsiLokace.NazevLokace}?", new List<string> { "Ano, vstoupit", "Ne, zpět do výběru lokací" }, ConsoleColor.Red);
                        int volba = menu.NavratIndexu();
                        if (volba == 0)
                        {
                            Console.Clear();
                            DndHerniFunkce.basePostavaDung = new BasePostava(VasePostava.hracovaPostava);
                            if(nynejsiLokace != Osobní_Domeček && nynejsiLokace != Dobyté_Panství && nynejsiLokace != Nadčasový_Les && nynejsiLokace != Skoro_Legální_Dábelské_Casino)
                            {
                                GameplayLokaci_2.EventH = false;                           
                                GameplayLokaci_2.DoplneniInv = false;
                                GameplayLokaci_4.DoplneniMoonI = false;
                                GameplayLokaci_4.DoplnenDabInv = false;
                            }
                            nynejsiLokace.GameplayLokace();
                        }
                    }
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    index--;
                    if (index < 0)
                    {
                        index = pocetLokaci;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    index++;
                    if (index > pocetLokaci)
                    {
                        index = 0;
                    }
                }
            } while (true);
        }
    }
}