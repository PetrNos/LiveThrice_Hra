using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static System.Console;
using static DnD_Hra.VasePostava;
using static DnD_Hra.VytvorenePredmety;

namespace DnD_Hra
{
    class NoveSpecialniSchopnosti
    {
               
        public static void VyberSSchopnosti(Dictionary<string, Action> seznamSSkVyberu, ConsoleColor barvaNadpisu)
        {
            while(true)
            {
                var vypisSpecShopnosti = seznamSSkVyberu.Select(p => p.Key).ToList();
                Menu vyberSchopnosti = new(" Vyberte si schopnost, kterou chcete získat:\n\n Pozor, pokud schopnost stojí manu a Vy manu nemáte, nelze schopnost aktivně využít! ", vypisSpecShopnosti, barvaNadpisu);
                int vb = vyberSchopnosti.NavratIndexu();
                var NazevSchopnosti = vypisSpecShopnosti[vb];
                var vybranaSchopnost = seznamSSkVyberu[NazevSchopnosti];
                if (_seznamSpecialnichSchopnostiHrace.ContainsValue(vybranaSchopnost))
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine($"Tato schopnost už je obsažena ve Vašich speciálních schopnostech. Zkuste vybrat nějakou jinou...");
                    WriteLine();
                    Thread.Sleep(400);
                    ResetColor();
                    WriteLine("stiskněte libovolné tlačítko...");
                    ReadKey(true);
                    Clear();
                    
                }
                else
                {

                    if (Potvrzeni())
                    {
                        Clear();
                        WriteLine();
                        string necutNazev = NazevSchopnosti;
                        char OdebratOd = '(';
                        int indexOdebrani = necutNazev.IndexOf(OdebratOd);
                        if(indexOdebrani >= 0)
                        {
                            NazevSchopnosti = necutNazev.Substring(0, indexOdebrani-1);
                        }
                        ForegroundColor = barvaNadpisu;                  
                        VasePostava._seznamSpecialnichSchopnostiHrace.Add(NazevSchopnosti, vybranaSchopnost);
                        WriteLine($"Získali jste {NazevSchopnosti}! Odteď je tato schopnost dostupná v souboji pod volbou 'speciální schopnost povolání'!");
                        WriteLine();
                        Thread.Sleep(400);
                        ResetColor();
                        WriteLine("stiskněte libovolné tlačítko...");
                        ReadKey(true);
                        Clear();
                        break;
                    }
                    else
                        continue;
                }
            }
            bool Potvrzeni()
            {
                Menu menu = new Menu($"Jste si jisti výběrem této schopnosti?", new List<string> { "Ano, pokračovat", "Ne, vrátit se do výběru" }, ConsoleColor.Red);
                int v = menu.NavratIndexu();
                if (v == 0)
                    return true;
                else
                    return false;
            }
        }

    }
    static class UkladaniFunkci
    {
        //ready slovniky
        public static Dictionary<string, Action> EirlysAbility = new Dictionary<string, Action>()
        {
            {"Celestiální Tanec (Obratnost, nestojí manu)", EirlysCelestialniTanec},
            {"Společenství z Nebes (Síla, nestojí manu)", EirlysSpolecenstviZNebes},
            {"Astrální Vězení (Inteligence, stojí manu)", EirlysAstralniVezeni}
        };
        public static Dictionary<string, Action> ShadowAbility = new Dictionary<string, Action>()
        {
            {"Pád silných (Síla, nestojí manu)", ShadowPS},
            {"Paralýza (Obratnost, nestojí manu)", ShadowPA},
            {"Průraz vůle (Inteligence, nestojí manu)", ShadowPV },
            {"Neštěstí (Štěstí, nestojí manu)", ShadowN}
        };
        public static Dictionary<string, Action> BludickyAbility = new Dictionary<string, Action>()
        {
            {"Efekt Silnějšího (Síla, nestojí manu)", BluEfSil},
            {"Efekt Mrštnějšího (Obratnost, nestojí manu)", BluEfMrs},
            {"Efekt Moudřejšího (Inteligence, nestojí manu)", BluEfMou }
           
        };
        //promenne pro schopnosti
        public static bool CelestialniTanec = false;
        public static bool MaValkyru = false;
        public static bool AstralniVezeni = false;
        
        //resety promennych(add na konci souboje if multis = false...)
        public static void ResetEirlysAbilit()
        {
            if (CelestialniTanec)
                CelestialniTanec = false;
            if (MaValkyru)
                MaValkyru = false;
            if (AstralniVezeni)
                AstralniVezeni = false;
        }
        //arty
        private static void EirlysArtCTanec() // animace schopnosti
        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"{hracovaPostava.vJmeno} použil svou speciální schopnost...");
            Thread.Sleep(150);
            WriteLine(@"

                      //schopnost eirlys    

                                                            ");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }
        private static void EirlysArtSpolecSNebes() // animace schopnosti
        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"{hracovaPostava.vJmeno} použil svou speciální schopnost...");
            Thread.Sleep(150);
            WriteLine(@"

                      //schopnost eirlys    

                                                            ");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }
        private static void EirlysArtAstralniVezeni() // animace schopnosti

        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"{hracovaPostava.vJmeno} použil svou speciální schopnost...");
            Thread.Sleep(150);
            WriteLine(@"

                      //schopnost eirlys Avez   

                                                            ");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }
        private static void ShadowPadSilnych() // animace schopnosti

        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"{hracovaPostava.vJmeno} použil svou speciální schopnost...");
            Thread.Sleep(150);
            WriteLine(@"

                      //schopnost pad silnych   

                                                            ");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }
        private static void ShadowParalyza() // animace schopnosti

        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"{hracovaPostava.vJmeno} použil svou speciální schopnost...");
            Thread.Sleep(150);
            WriteLine(@"

                      //schopnost pad silnych   

                                                            ");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }
        private static void ShadowPrurazVule() // animace schopnosti

        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"{hracovaPostava.vJmeno} použil svou speciální schopnost...");
            Thread.Sleep(150);
            WriteLine(@"

                      //schopnost pad silnych   

                                                            ");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }
        private static void ShadowNestesti() // animace schopnosti

        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"{hracovaPostava.vJmeno} použil svou speciální schopnost...");
            Thread.Sleep(150);
            WriteLine(@"

                      //schopnost pad silnych   

                                                            ");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }
        private static void BluEfektSilnejsiho() // animace schopnosti

        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"{hracovaPostava.vJmeno} použil svou speciální schopnost...");
            Thread.Sleep(150);
            WriteLine(@"

                      //schopnost pad silnych   

                                                            ");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }
        private static void BluEfektMrstnejsiho() // animace schopnosti

        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"{hracovaPostava.vJmeno} použil svou speciální schopnost...");
            Thread.Sleep(150);
            WriteLine(@"

                      //schopnost pad silnych   

                                                            ");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }
        private static void BluEfektMoudrejsiho() // animace schopnosti

        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"{hracovaPostava.vJmeno} použil svou speciální schopnost...");
            Thread.Sleep(150);
            WriteLine(@"

                      //schopnost pad silnych   

                                                            ");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }
        //prubehy
        private static void PrubehEirlysCTanec() // to, co se stane při speciální schopnosti
        {
            if(CelestialniTanec)
            {
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine();
                WriteLine("Celestiální Tanec už byl v tomto souboj použit, zkuste to ten příští!");
                Thread.Sleep(250);
                hracovaPostava.poskozeni = 0;
                return;
            }          
            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            hracovaPostava.Hod_HK(kostka);
            WriteLine();
            Thread.Sleep(250);
            ResetColor();
            hracovaPostava.poskozeni =  hracovaPostava.vObratnost + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.Yellow;
            if (hracovaPostava.poskozeni >= 6)
            {
                CelestialniTanec = true;
                WriteLine("Z bojiště se stává taneční plocha, kdo tančit neumí, prohraje!");
                Thread.Sleep(250);
                WriteLine();
                WriteLine("Vaše obratnost se do konce souboje zdvojnásobila. Obranná hodnota a útočná hodnota se zvýšily o 2...");
                hracovaPostava.vObratnost *= 2;
                hracovaPostava.vObrannaHodnota+=2;
                hracovaPostava.vUtocnaHodnota +=2;
                WriteLine();
                WriteLine($"Nyní máte {hracovaPostava.vObratnost} obratnosti, {hracovaPostava.vObrannaHodnota} obranné hodnoty a {hracovaPostava.vUtocnaHodnota} té utočné...");             
            }   
            else
            {
                WriteLine("Nic se nestalo... možná to chce trochu více...");
            }
            Thread.Sleep(450);
            ResetColor();
            hracovaPostava.poskozeni = 0;
        }
        private static void PrubehEirlysSpolecSNebes() // to, co se stane při speciální schopnosti
        {          
            if(MaValkyru)
            {
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine();
                WriteLine("Valkýra v tomto souboji už byla jednou přivolána. Zkuste to v tom dalším!");
                Thread.Sleep(250);
                hracovaPostava.poskozeni = 0;
                return;
            }
            Thread.Sleep(150);
            DndKostka kostka = new DndKostka();
            kostka.KostkyArt();
            hracovaPostava.Hod_HK(kostka);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;           
            if (hracovaPostava.vSila + kostka.VysledekHodu() < 8)
            {
                Thread.Sleep(200);
                Console.WriteLine("Valkýry následují jen toho, kdo oplývá dostatečnou silou. To zatím nejste...");
                hracovaPostava.poskozeni = 0;
                return;
            }                      
            else if (spolecnik != null)
            {
                Thread.Sleep(200);
                Menu menu = new Menu($"{hracovaPostava.vJmeno} už nějakého společníka má ({spolecnik.nazevStvoreni}), přejete si ho zaměnit za Valkýru?", new List<string> { "Ano", "Ne" }, ConsoleColor.Red);
                int v = menu.NavratIndexu();
                Console.Clear();
                if (v == 0)
                {
                    spolecnik = new Valkyrie();                  
                    Thread.Sleep(200);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Na bojiště se z výšin nebes majestátně snesla Valkýra. Teď bojuje po Vašem boku.");
                    MaValkyru = true;
                }
                else
                {
                    Thread.Sleep(200);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Rozhodli jste se ponechat Vašeho stávajícího společníka.");
                }
            }
            else
            {
                spolecnik = new Valkyrie();               
                Thread.Sleep(200);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Na bojiště se z výšin nebes majestátně snesla Valkýra. Teď bojuje po Vašem boku.");
                MaValkyru = true;
            }
            hracovaPostava.poskozeni = 0;
            Console.ResetColor();
        }
        private static void PrubehEirlysAstralniVezeni() // to, co se stane při speciální schopnosti
        {
            if(AstralniVezeni)
            {
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine();
                WriteLine("V tomto souboji jste již využili sílu Astrálního vězení. Zkuste to v tom dalším!");
                Thread.Sleep(250);
                hracovaPostava.poskozeni = 0;
                return;
            }
            byte cena = 4;
            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            hracovaPostava.Hod_HK(kostka);
            WriteLine();
            Thread.Sleep(250);
            ResetColor();
            hracovaPostava.poskozeni = hracovaPostava.vInteligence + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.Yellow;
            if(hracovaPostava.pocetMany < cena)
            {
                WriteLine($"Nemáte dostatek many na použití Astrálního vězení. Minimum je {cena} many, nyní máte jen {hracovaPostava.pocetMany}...");
                hracovaPostava.poskozeni = 0;
                return;
            }
            if (hracovaPostava.poskozeni > 5)
            {
                hracovaPostava.pocetMany -= cena;
                WriteLine("Provedete mentální souboj s Vaším soupeřem...");
                GameplayLokaci_1.Tlacitko();
                Past astralniVezeni = new Past(hracovaPostava.poskozeni, _aktualniNepritel.sInteligence, "inteligenci", _aktualniNepritel.nazevStvoreni);
                Clear();
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine();
                if (astralniVezeni.Uspech())
                    Proslo();
                else
                    Neproslo();
                WriteLine();
                WriteLine($"Nyní máte {hracovaPostava.pocetMany} many.");
                void Proslo()
                {
                    WriteLine("Úspěšně jste soupeře porazili. Soupeř se nachází v Astrálním vězení, které mu značně komplikuje souboj...");
                    WriteLine();
                    _aktualniNepritel.sUtocnaHodnota -= _aktualniNepritel.zbranStvoreni.poskozeniZbrane;
                    _aktualniNepritel.zbranStvoreni = Žádná_Zbraň;
                    _aktualniNepritel.sObrannaHodnota -= _aktualniNepritel.zbrojStvoreni.hodnotaBrneni;
                    _aktualniNepritel.zbrojStvoreni = Žádná_Zbroj;                                       
                    hracovaPostava.poskozeni = (int)(_aktualniNepritel.maxZdravi * 0.3333) + _aktualniNepritel.sObrannaHodnota;
                    Thread.Sleep(350);
                    WriteLine("Soupeř ztratil jednu třetinu jeho maximálního zdraví. Také mu byla odebráno bojové vybavení (zbraň a zbroj)");
                    Thread.Sleep(450);
                    WriteLine();                    
                    Thread.Sleep(250);
                    WriteLine($"Soupeř má nyní {_aktualniNepritel.sObrannaHodnota} obranné hodnoty.");
                    WriteLine();
                    Thread.Sleep(250);
                    WriteLine($"Také má {_aktualniNepritel.sUtocnaHodnota} útočné hodnoty...");
                    
                }
                void Neproslo()
                {
                    WriteLine("Soupeře se Vám nepodařilo porazit mentálním souboji...");
                    hracovaPostava.poskozeni = 0;
                }
            }
            else
            {
                WriteLine("Inteligence je klíčová vlastnost při použití Astrálního vězení...třeba se Vám podaří příště!");
                hracovaPostava.poskozeni = 0;
            }
            Thread.Sleep(450);
            ResetColor();
        }
        private static void PadSilnych() // to, co se stane při speciální schopnosti
        {           
            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            hracovaPostava.Hod_HK(kostka);
            WriteLine();
            Thread.Sleep(250);
            ResetColor();
            hracovaPostava.poskozeni = hracovaPostava.vSila + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.DarkRed;
            if(hracovaPostava.poskozeni >= 10)
            {
                int pridavekUber = (int)(_aktualniNepritel.sSila* 0.5);
                if (pridavekUber < 0)
                    pridavekUber = 0;
                WriteLine("Vašemu soupeři vezmete polovinu jeho síly. Stejné množství si přidáte...");
                WriteLine();
                Thread.Sleep(250);
                WriteLine($"Ubrali jste soupeři {pridavekUber} síly.");
                Thread.Sleep(250);
                VasePostava.hracovaPostava.vSila += pridavekUber;
                _aktualniNepritel.sSila -= pridavekUber;
            }
            else
            {
                WriteLine("Ne pokaždé se povede překonat ty silnější...");
            }
            Thread.Sleep(450);
            ResetColor();
            hracovaPostava.poskozeni = 0;
        }
        private static void Paralyza() // to, co se stane při speciální schopnosti
        {
            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            hracovaPostava.Hod_HK(kostka);
            WriteLine();
            Thread.Sleep(250);
            ResetColor();
            hracovaPostava.poskozeni = hracovaPostava.vObratnost + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.DarkYellow;
            if (hracovaPostava.poskozeni >= 10)
            {
                int pridavekUber = (int)(_aktualniNepritel.sObratnost * 0.5);
                if (pridavekUber < 0)
                    pridavekUber = 0;
                WriteLine("Vašemu soupeři vezmete polovinu jeho obratnosti. Stejné množství si přidáte...");
                WriteLine();
                Thread.Sleep(250);
                WriteLine($"Ubrali jste soupeři {pridavekUber} obratnosti.");
                Thread.Sleep(250);
                VasePostava.hracovaPostava.vObratnost += pridavekUber;               
                _aktualniNepritel.sObratnost -= pridavekUber;
            }
            else
            {
                WriteLine("Ne pokaždé se povede překonat ty mrštnější...");
            }
            Thread.Sleep(450);
            ResetColor();
            hracovaPostava.poskozeni = 0;
        }
        private static void PrurazVule() // to, co se stane při speciální schopnosti
        {
            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            hracovaPostava.Hod_HK(kostka);
            WriteLine();
            Thread.Sleep(250);
            ResetColor();
            hracovaPostava.poskozeni = hracovaPostava.vInteligence + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.DarkBlue;
            if (hracovaPostava.poskozeni >= 10)
            {
                int pridavekUber = (int)(_aktualniNepritel.sInteligence * 0.5);
                if (pridavekUber < 0)
                    pridavekUber = 0;
                WriteLine("Vašemu soupeři vezmete polovinu jeho inteligence. Stejné množství si přidáte...");
                WriteLine();
                Thread.Sleep(250);
                WriteLine($"Ubrali jste soupeři {pridavekUber} inteligence.");
                Thread.Sleep(250);
                VasePostava.hracovaPostava.vInteligence += pridavekUber;
                _aktualniNepritel.sInteligence -= pridavekUber;
            }
            else
            {
                WriteLine("Ne pokaždé se povede překonat ty chytřejší...");
            }
            Thread.Sleep(450);
            ResetColor();
            hracovaPostava.poskozeni = 0;
        }
        private static void Nestesti() // to, co se stane při speciální schopnosti
        {
            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            hracovaPostava.Hod_HK(kostka);
            WriteLine();
            Thread.Sleep(250);
            ResetColor();
            hracovaPostava.poskozeni = hracovaPostava.vStesti + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.DarkCyan;
            if (hracovaPostava.poskozeni >= 10)
            {
                int pridavekUber = (int)(_aktualniNepritel.sStesti * 0.5);
                if (pridavekUber < 0)
                    pridavekUber = 0;
                WriteLine("Vašemu soupeři vezmete polovinu jeho stěstí. Stejné množství si přidáte...");
                WriteLine();
                Thread.Sleep(250);
                WriteLine($"Ubrali jste soupeři {pridavekUber} štěstí.");
                Thread.Sleep(250);
                VasePostava.hracovaPostava.vStesti += pridavekUber;
                _aktualniNepritel.sStesti -= pridavekUber;
            }
            else
            {
                WriteLine("Ne pokaždé se povede překonat ty šťastnější...");
            }
            Thread.Sleep(450);
            ResetColor();
            hracovaPostava.poskozeni = 0;
        }
        private static void EfektSilensjho() // to, co se stane při speciální schopnosti
        {
            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            hracovaPostava.Hod_HK(kostka);
            WriteLine();
            Thread.Sleep(250);
            ResetColor();
            hracovaPostava.poskozeni = 2*hracovaPostava.vSila + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.Red;
            if (hracovaPostava.vSila > _aktualniNepritel.sSila)
            {
                hracovaPostava.vSila /= 2;
                WriteLine("Efektivně využíváte, že jste silnější...");
                WriteLine();
                Thread.Sleep(250);
                WriteLine("Způsobíte tak vysoké poškození, síla se Vám ale dočasně o polovinu sníží.");
                WriteLine();
                Thread.Sleep(250);
                WriteLine($"Způsobili jste {hracovaPostava.poskozeni} poškození a Vaše síla je nyní {hracovaPostava.vSila}.");
                Thread.Sleep(250);                
            }
            else
            {
                WriteLine("Pro využití efektu silnějšího musíte být silnější než soupeř...");
            }
            Thread.Sleep(450);
            ResetColor();           
        }
        private static void EfektMrstnejsiho() // to, co se stane při speciální schopnosti
        {
            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            hracovaPostava.Hod_HK(kostka);
            WriteLine();
            Thread.Sleep(250);
            ResetColor();
            hracovaPostava.poskozeni = 2 * hracovaPostava.vObratnost + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.Yellow;
            if (hracovaPostava.vObratnost > _aktualniNepritel.sObratnost)
            {
                hracovaPostava.vObratnost /= 2;
                WriteLine("Efektivně využíváte, že jste mrštnější...");
                WriteLine();
                Thread.Sleep(250);
                WriteLine("Způsobíte tak vysoké poškození, obratnost se Vám ale dočasně o polovinu sníží.");
                WriteLine();
                Thread.Sleep(250);
                WriteLine($"Způsobili jste {hracovaPostava.poskozeni} poškození a Vaše obratnost je nyní {hracovaPostava.vObratnost}.");
                Thread.Sleep(250);
            }
            else
            {
                WriteLine("Pro využití efektu mrštnějšího musíte být mrštnější než soupeř...");
            }
            Thread.Sleep(450);
            ResetColor();
        }
        private static void EfektMoudrejsiho() // to, co se stane při speciální schopnosti
        {
            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            hracovaPostava.Hod_HK(kostka);
            WriteLine();
            Thread.Sleep(250);
            ResetColor();
            hracovaPostava.poskozeni = 2 * hracovaPostava.vInteligence + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.Yellow;
            if (hracovaPostava.vInteligence > _aktualniNepritel.sInteligence)
            {
                hracovaPostava.vInteligence /= 2;
                WriteLine("Efektivně využíváte, že jste moudřejší...");
                WriteLine();
                Thread.Sleep(250);
                WriteLine("Způsobíte tak vysoké poškození, inteligence se Vám ale dočasně o polovinu sníží.");
                WriteLine();
                Thread.Sleep(250);
                WriteLine($"Způsobili jste {hracovaPostava.poskozeni} poškození a Vaše inteligence je nyní {hracovaPostava.vInteligence}.");
                Thread.Sleep(250);
            }
            else
            {
                WriteLine("Pro využití efektu moudřejšího musíte být moudřejší než soupeř...");
            }
            Thread.Sleep(450);
            ResetColor();
        }
        //hotove!
        private static void EirlysCelestialniTanec()
        {
            Clear();
            EirlysArtCTanec();
            PrubehEirlysCTanec();
        }
        private static void EirlysSpolecenstviZNebes()
        {
            Clear();
            EirlysArtSpolecSNebes();
            PrubehEirlysSpolecSNebes();
        }
        private static void EirlysAstralniVezeni()
        {
            Clear();
            EirlysArtAstralniVezeni();
            PrubehEirlysAstralniVezeni();
        }
        private static void ShadowPS()
        {
            Clear();
            ShadowPadSilnych();
            PadSilnych();
        }
        private static void ShadowPA()
        {
            Clear();
            ShadowParalyza();
            Paralyza();
        }
        private static void ShadowPV()
        {
            Clear();
            ShadowPrurazVule();
            PrurazVule();
        }
        private static void ShadowN()
        {
            Clear();
            ShadowNestesti();
            Nestesti();
        }
        private static void BluEfSil()
        {
            Clear();
            BluEfektSilnejsiho();
            EfektSilensjho();
        }
        private static void BluEfMrs()
        {
            Clear();
            BluEfektMrstnejsiho();
            EfektMrstnejsiho();
        }
        private static void BluEfMou()
        {
            Clear();
            BluEfektMoudrejsiho();
            EfektMoudrejsiho();
        }
    }
}
