using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static System.Console;
using static DnD_Hra.VytvorenePredmety;
using static DnD_Hra.DndHerniFunkce;

namespace DnD_Hra
{
    class NemrtvyKnihovnik : Stvoreni
    {
        Func<bool> hadanka;
        bool bylaHadanka;
        public NemrtvyKnihovnik(string otazka, string odpoved, int pocetPokusus, ConsoleColor barvaOtazky = ConsoleColor.Blue) // hodnoty base atributů tohoto monstra
        {

            zbranStvoreni = Dýka;
            zbrojStvoreni = Látková_Zbroj;
            pouzitelnyPredmet = null;
            surovinyStvoreni = null;
            sInteligence = 5;
            sSila = 1;
            sObratnost = 5;
            sStesti = 3;
            maManu = true;
            pocetMany = 10;
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 4 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 4 + hodnotaBrneni;
            sZdravi = 19 + sObrannaHodnota + sSila;
            pocetZlata = 1;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;
            nazevStvoreni = "Nemrtvý Knihovník";
            Bestiar.PridejDoBestiare(this);
            popis = @"'Sečtělí a už nějakou dobu neživí.

 Jejich hádanky jsou občasně zapeklité, když je nezodpovím správně, čeká mě trest.'";
            this.hadanka = () => GameplayLokaci_3.Hadanka(otazka, odpoved, pocetPokusus, barvaOtazky);
            bylaHadanka = false;

        }
        protected void StraznyAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.DarkBlue;
            WriteLine($"{nazevStvoreni} použil svou speciální schopnost...");
            Thread.Sleep(150);
            WriteLine(@"

                      //schopnost knih

                                                            ");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void StraznyUtokAnimace()
        {
            Thread.Sleep(150);
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.DarkBlue;
            WriteLine($"{nazevStvoreni} se připravuje k útoku...");
            Thread.Sleep(150);
            WriteLine(@"                                                                             ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀            // knih animace útoku.⠀");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void StraznyUtokPrubeh()
        {

            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            kostka.HodKostkou();
            WriteLine();
            Thread.Sleep(250);
            ResetColor();
            poskozeni = sUtocnaHodnota + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.DarkBlue;
            WriteLine($"{nazevStvoreni} sekl svou dýkou...");
            Thread.Sleep(150);
            WriteLine();
            WriteLine("Bod dykou způsobil {0} poškození", poskozeni);
            Thread.Sleep(450);
            ResetColor();

        }

        private void PrubehSchopnostiStvoreni() // to, co se stane při speciální schopnosti
        {
            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            kostka.HodKostkou();
            WriteLine();
            Thread.Sleep(250);
            ResetColor();
            poskozeni = sInteligence + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.DarkBlue;
            if (!bylaHadanka)
            {
                bylaHadanka = true;
                bool uhodl = hadanka();
                if (_UtokNaSpolecnika && !uhodl)
                {
                    ForegroundColor = ConsoleColor.DarkBlue;
                    WriteLine("Neuhodli jste hádanku a tento útok byl mířen na společníka...");
                    WriteLine();
                    WriteLine("Společník se mění v prach...");
                    VasePostava.spolecnik.sZdravi = 0;
                    if (VasePostava.hracovaPostava.maManu)
                    {
                        WriteLine();
                        VasePostava.hracovaPostava.pocetMany -= 5;
                        if (VasePostava.hracovaPostava.pocetMany < 0)
                            VasePostava.hracovaPostava.pocetMany = 0;
                        WriteLine($"A knihovník z Vás vysál 5 many. Nyní máte {VasePostava.hracovaPostava.pocetMany} many...");
                    }
                }
                else if (!_UtokNaSpolecnika && !uhodl)
                {
                    ForegroundColor = ConsoleColor.DarkBlue;
                    WriteLine("Neuhodli jste hádanku a tento útok byl mířen na Vás...");
                    WriteLine();
                    WriteLine("Knihovník nabral podobu stínu, čímž se znatelně zvýšila jeho obratnost...");
                    sObratnost = 20;
                    if (VasePostava.hracovaPostava.maManu)
                    {
                        WriteLine();
                        VasePostava.hracovaPostava.pocetMany -= 5;
                        if (VasePostava.hracovaPostava.pocetMany < 0)
                            VasePostava.hracovaPostava.pocetMany = 0;
                        WriteLine($"A knihovník z Vás vysál 5 many. Nyní máte {VasePostava.hracovaPostava.pocetMany} many...");
                    }
                }
                else if (uhodl)
                {
                    ForegroundColor = ConsoleColor.DarkBlue;
                    WriteLine("Uhodli jste knihovníkovu hádánku...");
                    WriteLine();
                    WriteLine("Knihovník tomu nedokáže uvěřit, musí se potrestat...");
                    WriteLine();
                    WriteLine("Vzal svou dýku a probodl si ruku. Jeho zdraví se tak snižuje o 5.");
                    sZdravi -= 5;
                    if (sZdravi < 0)
                        sZdravi = 0;
                }
                poskozeni = 0;
            }
            else
            {
                byte cena = 5; 
                if(sZdravi + pocetMany <= maxZdravi && pocetMany > 0)
                {
                    sZdravi += pocetMany;
                    WriteLine("Knihovník konvertoval všechnou svou zbývající manu na zdraví...");
                    WriteLine();
                    WriteLine($"Přidal si tak {pocetMany} zdraví.");
                    pocetMany = 0;
                    poskozeni = 0;
                }
                else if(pocetMany >= cena)
                {
                    pocetMany -= cena;
                    WriteLine();
                    WriteLine("Knihovník změnil magickou energii na temnou hmotu...");
                }
                else
                {                  
                    WriteLine("Vypadá to, že knovník vyčerpal všechny své triky.");
                    WriteLine();
                    WriteLine("Nesvede nic lepšího, než obyčejný výpad dýkou...");
                    WriteLine();
                    Thread.Sleep(350);
                    WriteLine($"Způsobil {poskozeni} poškození.");
                    poskozeni -= sInteligence;
                }
            }
            Thread.Sleep(450);
            ResetColor();
            
        }

        public override int PoskozeniStvoreni() // vracíme hodnotu speciální schopnosti
        {
            return poskozeni;
        }

        public override void SchopnostStvoreni() // už celá funkce, která provede schopnost se vším všudy
        {
            Clear();
            StraznyAnimace();
            PrubehSchopnostiStvoreni();
        }

        public override void UtokStvoreni()
        {
            Clear();
            StraznyUtokAnimace();
            StraznyUtokPrubeh();
        }

        public override void ArtStvoreni()
        {
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.DarkBlue;
            Thread.Sleep(100);
            WriteLine(@"

            ⠀              //Valk art stv
                                                ");
            Thread.Sleep(2000);
            ResetColor();
            Clear();
        }
    }
    class MystickyStin : Stvoreni
    {
        Func<bool> hadanka;
        public bool uspel;
        public MystickyStin (string otazka, string odpoved, int pocetPokusus, ConsoleColor barvaOtazky = ConsoleColor.Blue) // hodnoty base atributů tohoto monstra
        {

            this.hadanka = () => GameplayLokaci_3.Hadanka(otazka, odpoved, pocetPokusus, barvaOtazky);
            uspel = hadanka.Invoke();
            zbranStvoreni = Žádná_Zbraň;
            zbrojStvoreni = Žádná_Zbroj;
            pouzitelnyPredmet = null;
            surovinyStvoreni = Temná_Esence;
            sInteligence = uspel?1:3;
            sSila = uspel ? 0:2;
            sObratnost = 5;
            sStesti = uspel ? 3:6;
            maManu = false;          
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = uspel ?3 + poskozeniZbrane:5+poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 3 + hodnotaBrneni;
            sZdravi = 17 + sObrannaHodnota + sSila;
            pocetZlata = 0;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;
            nazevStvoreni = uspel?"Mystický stín":"Rozzuřený mystický stín";
            Bestiar.PridejDoBestiare(this);
            popis = @"'Tmavě fialová entita, která se mě ptá na hádanky...

 Pokud odpovím správně, nejen že je slabší, ale dokonce mě díky runové magii naučí nové umy...'";
           

        }
        protected void StraznyAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.DarkMagenta;
            WriteLine($"{nazevStvoreni} použil svou speciální schopnost...");
            Thread.Sleep(150);
            WriteLine(@"

                      //schopnost stinu

                                                            ");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void StraznyUtokAnimace()
        {
            Thread.Sleep(150);
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.DarkMagenta;
            WriteLine($"{nazevStvoreni} se připravuje k útoku...");
            Thread.Sleep(150);
            WriteLine(@"                                                                             ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀            // stin animace útoku.⠀");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void StraznyUtokPrubeh()
        {

            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            kostka.HodKostkou();
            WriteLine();
            Thread.Sleep(250);
            ResetColor();
            poskozeni = sUtocnaHodnota + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.DarkMagenta;
            if(sObratnost < 45)
            {

                WriteLine($"{nazevStvoreni} se rychle pohybuje po místnosti a tak je obtížnější ho trefit...");
                Thread.Sleep(150);
                WriteLine();
                WriteLine($"{nazevStvoreni} si zvýšil obratnost o {(int)(poskozeni*1.25)}.");
                sObratnost += (int)(poskozeni*1.25);
                if (sObratnost > 45)
                    sObratnost = 45;
            }
            else if(sStesti<50)
            {
                WriteLine($"{nazevStvoreni} se pohybuje tak rychle, že máte problém ho vidět. Jeho šance na žákeřný útok se zvyšuje...");
                Thread.Sleep(150);
                WriteLine();
                WriteLine($"{nazevStvoreni} si zvýšil štěstí o {(int)(poskozeni * 1.25)}.");
                sStesti += (int)(poskozeni * 1.25);
                if (sStesti > 50)
                    sStesti = 50;
            }
            else
            {
                WriteLine($"{nazevStvoreni} začíná být netrpělivý a přeje si smrt hosta v knihovně...");
                Thread.Sleep(150);
                WriteLine();
                WriteLine($"{nazevStvoreni} si zvýšil útočnou hodnotu o {(int)(poskozeni * 1.25)}.");
                sUtocnaHodnota += (int)(poskozeni * 1.25);
            }
            Thread.Sleep(450);
            ResetColor();
            poskozeni = 0;
        }

        private void PrubehSchopnostiStvoreni() // to, co se stane při speciální schopnosti
        {
            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            kostka.HodKostkou();
            WriteLine();
            Thread.Sleep(250);
            ResetColor();
            poskozeni = sInteligence + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.DarkMagenta;
            WriteLine($"{nazevStvoreni} prolétává skrz svůj cíl, oslabujíce ho v procesu...");
            WriteLine();
            int snizeniUH = (int)(poskozeni * 0.33);
            if(_UtokNaSpolecnika)
            {
                WriteLine("Průlet oslabil Vašeho společníka...");
                WriteLine();
                Thread.Sleep(300);
                WriteLine($"Vzal mu tak {snizeniUH} útočné hodnoty a způsobil {poskozeni} poškození.");
                VasePostava.spolecnik.sUtocnaHodnota -= snizeniUH;
                if (VasePostava.spolecnik.sUtocnaHodnota < 0)
                    VasePostava.spolecnik.sUtocnaHodnota = 0;
            }
            else
            {
                WriteLine("Průlet Vás oslabil...");
                WriteLine();
                Thread.Sleep(300);
                WriteLine($"Vzal Vám tak {snizeniUH} útočné hodnoty a způsobil {poskozeni} poškození.");
                VasePostava.hracovaPostava.vUtocnaHodnota -= snizeniUH;
                if (VasePostava.hracovaPostava.vUtocnaHodnota < 0)
                    VasePostava.hracovaPostava.vUtocnaHodnota = 0;
            }
            Thread.Sleep(250);
            ResetColor();
        }

        public override int PoskozeniStvoreni() // vracíme hodnotu speciální schopnosti
        {
            return poskozeni;
        }

        public override void SchopnostStvoreni() // už celá funkce, která provede schopnost se vším všudy
        {
            Clear();
            StraznyAnimace();
            PrubehSchopnostiStvoreni();
        }

        public override void UtokStvoreni()
        {
            Clear();
            StraznyUtokAnimace();
            StraznyUtokPrubeh();
        }

        public override void ArtStvoreni()
        {
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.DarkMagenta;
            Thread.Sleep(100);
            WriteLine(@"

            ⠀              //Valk art stv
                                                ");
            Thread.Sleep(2000);
            ResetColor();
            Clear();
        }
        public void VyberNoveSchopnosti()
        {
            if (!uspel)
                return;
            NoveSpecialniSchopnosti.VyberSSchopnosti(UkladaniFunkci.ShadowAbility, ConsoleColor.DarkCyan);
        }
    }
    class Gargoyl : Stvoreni
    {
       
        public Gargoyl() // hodnoty base atributů tohoto monstra
        {
            int rnd = new Random().Next(0, 2);
            zbranStvoreni = Ohnivá_Koule;
            zbrojStvoreni = Žádná_Zbroj;
            pouzitelnyPredmet = null;
            surovinyStvoreni = rnd == 0?Kůže:Železný_Ingot;
            sInteligence = 2;
            sSila = 4;
            sObratnost = 3;
            sStesti = 2;
            maManu = true;
            pocetMany = 6;
            maxMana = pocetMany;
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 2 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 6 + hodnotaBrneni;
            sZdravi = 19 + sObrannaHodnota + sSila;
            pocetZlata = 2;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;
            nazevStvoreni = "Gargoyl";
            Bestiar.PridejDoBestiare(this);
            popis = @"'Na první pohled nehybná socha.

 Avšak po probuzení lítá stvůra, která je připravena bránit své zapečetěné místo'";
           
        }
        protected void StraznyAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.DarkCyan;
            WriteLine($"{nazevStvoreni} použil svou speciální schopnost...");
            Thread.Sleep(150);
            WriteLine(@"

                      //schopnost knih

                                                            ");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void StraznyUtokAnimace()
        {
            Thread.Sleep(150);
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.DarkCyan;
            WriteLine($"{nazevStvoreni} se připravuje k útoku...");
            Thread.Sleep(150);
            WriteLine(@"                                                                             ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀            // knih animace útoku.⠀");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void StraznyUtokPrubeh()
        {

            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            kostka.HodKostkou();
            WriteLine();
            Thread.Sleep(250);
            ResetColor();
            poskozeni = sUtocnaHodnota + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.DarkCyan;
            if(pocetMany >= zbranStvoreni.manovaCena)
            {
                pocetMany -= zbranStvoreni.manovaCena;
                WriteLine($"{nazevStvoreni} vyslal na cíl ohnivou kouli...");
                Thread.Sleep(150);
                WriteLine();
                WriteLine("Ohnivá koule způsobila {0} poškození!", poskozeni);
            }
            else
            {
                WriteLine($"{nazevStvoreni} sekl svým pařátem...");
                Thread.Sleep(150);
                WriteLine();
                poskozeni -= 4;
                if (poskozeni < 0)
                    poskozeni = 0;
                WriteLine("Útok způsobil {0} poškození!", poskozeni);
            }
            Thread.Sleep(450);
            ResetColor();

        }

        private void PrubehSchopnostiStvoreni() // to, co se stane při speciální schopnosti
        {
            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            kostka.HodKostkou();
            WriteLine();
            Thread.Sleep(250);
            ResetColor();
            poskozeni = sSila + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.DarkCyan;
            if(sZdravi < (int)(maxZdravi*0.5))
            {
                WriteLine($"{nazevStvoreni} zkameněl, čímž si doplnil zdraví a manu.");
                WriteLine();
                Thread.Sleep(350);
                WriteLine($"{nazevStvoreni} si také výrazně sníží útočnou hodnotu a přidá tu obrannou.");
                int dopleneni = (int)(poskozeni * 0.5);
                sZdravi += dopleneni;
                if (sZdravi > maxZdravi)
                    sZdravi = maxZdravi;
                pocetMany += dopleneni;
                if (pocetMany > maxMana)
                    pocetMany = maxMana;
                sUtocnaHodnota -= dopleneni;
                if (sUtocnaHodnota < 0)
                    sUtocnaHodnota = 0;
                sObrannaHodnota += dopleneni;
                WriteLine();
                Thread.Sleep(350);
                WriteLine($"{nazevStvoreni} si doplnil {dopleneni} zdraví a many, pokud mu chybějí.");
                WriteLine();
                Thread.Sleep(350);
                WriteLine($"Také zvýšil obrannou hodnotu o {dopleneni} a útočnou o tento počet snížil.");
            }
            else
            {
                WriteLine($"{nazevStvoreni} sundal kamennou kůži, čímž si zvýší sílu a obratnost.");
                WriteLine();
                Thread.Sleep(350);
                WriteLine($"{nazevStvoreni} si také výrazně sníží obrannou hodnotu a přidá tu útočnou.");
                int dopleneni = (int)(poskozeni * 0.5);
                sSila += dopleneni;                
                sObratnost += dopleneni;
                if (sObratnost > 45)
                    sObratnost = 45;
                sObrannaHodnota -= dopleneni;
                if (sObrannaHodnota < 0)
                    sObrannaHodnota = 0;
                sUtocnaHodnota += dopleneni;
                WriteLine();
                Thread.Sleep(350);
                WriteLine($"{nazevStvoreni} si zvyšil obratnost a sílu o {dopleneni}.");
                WriteLine();
                Thread.Sleep(350);
                WriteLine($"Také zvýšil útočnou hodnotu o {dopleneni} a obrannou o tento počet snížil.");
            }
            poskozeni = 0;
            Thread.Sleep(450);
            ResetColor();

        }

        public override int PoskozeniStvoreni() // vracíme hodnotu speciální schopnosti
        {
            return poskozeni;
        }

        public override void SchopnostStvoreni() // už celá funkce, která provede schopnost se vším všudy
        {
            Clear();
            StraznyAnimace();
            PrubehSchopnostiStvoreni();
        }

        public override void UtokStvoreni()
        {
            Clear();
            StraznyUtokAnimace();
            StraznyUtokPrubeh();
        }

        public override void ArtStvoreni()
        {
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.DarkCyan;
            Thread.Sleep(100);
            WriteLine(@"

            ⠀              //Valk art stv
                                                ");
            Thread.Sleep(2000);
            ResetColor();
            Clear();
        }
    }
    class Kobold : Stvoreni
    {

        public Kobold() // hodnoty base atributů tohoto monstra
        {            
            zbranStvoreni = Žádná_Zbraň;
            zbrojStvoreni = Žádná_Zbroj;
            pouzitelnyPredmet = null;
            surovinyStvoreni = null;
            sInteligence = 0;
            sSila = 1;
            sObratnost = 0;
            sStesti = 0;
            maManu = false;          
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 0 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 0 + hodnotaBrneni;
            sZdravi = 9 + sObrannaHodnota + sSila;
            pocetZlata = 0;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;
            nazevStvoreni = "Drzý Kobold";
            Bestiar.PridejDoBestiare(this);
            popis = @"'Malé prasečí stvoření, na první pohled neškodné.

 Mohu si ho vyvolat pomocí jednoho předmětu, v souboji přijde vhod!'";

        }
        protected void StraznyAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine($"{nazevStvoreni} použil svou speciální schopnost...");
            Thread.Sleep(150);
            WriteLine(@"

                      //schopnost knih

                                                            ");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void StraznyUtokAnimace()
        {
            Thread.Sleep(150);
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine($"{nazevStvoreni} se připravuje k útoku...");
            Thread.Sleep(150);
            WriteLine(@"                                                                             ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀            // knih animace útoku.⠀");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void StraznyUtokPrubeh()
        {

            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            kostka.HodKostkou();
            WriteLine();
            Thread.Sleep(250);
            ResetColor();
            poskozeni = sUtocnaHodnota + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.DarkYellow;          
                WriteLine($"{nazevStvoreni} dal soupeři pěstí...");
                Thread.Sleep(150);
                WriteLine();                              
                WriteLine("Útok způsobil {0} poškození!", poskozeni);           
            Thread.Sleep(450);
            ResetColor();

        }

        private void PrubehSchopnostiStvoreni() // to, co se stane při speciální schopnosti
        {
            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            kostka.HodKostkou();
            WriteLine();
            Thread.Sleep(250);
            ResetColor();
            poskozeni = sSila + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine($"{nazevStvoreni} dal soupeři pravý hák!");
            WriteLine();
            Thread.Sleep(350);
            WriteLine($"Pravý hák způsobil {poskozeni} poškození!");
            Thread.Sleep(450);
            ResetColor();

        }

        public override int PoskozeniStvoreni() // vracíme hodnotu speciální schopnosti
        {
            return poskozeni;
        }

        public override void SchopnostStvoreni() // už celá funkce, která provede schopnost se vším všudy
        {
            Clear();
            StraznyAnimace();
            PrubehSchopnostiStvoreni();
        }

        public override void UtokStvoreni()
        {
            Clear();
            StraznyUtokAnimace();
            StraznyUtokPrubeh();
        }

        public override void ArtStvoreni()
        {
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.DarkYellow;
            Thread.Sleep(100);
            WriteLine(@"

            ⠀              //Valk art stv
                                                ");
            Thread.Sleep(2000);
            ResetColor();
            Clear();
        }
    }
    class LucistniceTemnychElfu : Stvoreni
    {
        static Random r = new Random();
        int rand = r.Next(0, 2);
        bool maska = false;
        public LucistniceTemnychElfu() // hodnoty base atributů tohoto monstra
        {

            zbranStvoreni = Luk;
            zbrojStvoreni = Kožená_Zbroj;
            pouzitelnyPredmet = null;
            surovinyStvoreni = rand == 0?Osvícená_Smůla:Měsíční_Erb;
            sInteligence = 3;
            sSila = 2;
            sObratnost = 6;
            sStesti = 4;
            maManu = false;
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 3 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 1 + hodnotaBrneni;
            sZdravi = 17 + sObrannaHodnota + sSila;
            pocetZlata = 3;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;
            nazevStvoreni = "Lučištnice Temných Elfů";
            Bestiar.PridejDoBestiare(this);
            popis = @"'Pohledná žena menšího vzrůstu s nafialovělou pletí a špičatými uši.

 Velmi teritoriální a zvláštním způsobem nebezpečná'";

        }
        protected void StraznyAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine($"{nazevStvoreni} použila svou speciální schopnost...");
            Thread.Sleep(150);
            WriteLine(@"

                      //schopnost knih

                                                            ");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void StraznyUtokAnimace()
        {
            Thread.Sleep(150);
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine($"{nazevStvoreni} se připravuje k útoku...");
            Thread.Sleep(150);
            WriteLine(@"                                                                             ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀            // knih animace útoku.⠀");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void StraznyUtokPrubeh()
        {

            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            kostka.HodKostkou();
            WriteLine();
            Thread.Sleep(250);
            ResetColor();
            poskozeni = sUtocnaHodnota + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine($"{nazevStvoreni} vystřelila z luku...");
            Thread.Sleep(150);
            WriteLine();
            WriteLine("Útok způsobil {0} poškození!", poskozeni);
            Thread.Sleep(450);
            ResetColor();

        }

        private void PrubehSchopnostiStvoreni() // to, co se stane při speciální schopnosti
        {
            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            kostka.HodKostkou();
            WriteLine();
            Thread.Sleep(250);
            ResetColor();
            poskozeni = sObratnost + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.DarkGreen;
            if(sZdravi <= (int)(maxZdravi)*0.5 && !maska)
            {
                maska = true;
                WriteLine($"{nazevStvoreni} se proměninila v křehce vypadající přízrak...");
                Thread.Sleep(350);
                WriteLine();
                WriteLine($"Její obratnost se tak zvýšila na 30, avšak zdraví kleslo na 1.");
                sZdravi = 1;
                sObratnost = 30;
                poskozeni = 0;
            }
            else
            {
                if(!_UtokNaSpolecnika)
                {
                    WriteLine($"{nazevStvoreni} na Vás použila hypnózu...");                    
                    StatSwaperoo(r, ConsoleColor.DarkGreen);
                    poskozeni = 0;
                }
                else
                {
                    WriteLine($"{nazevStvoreni} vystřelila překvapivě přesnou ránu...");
                    WriteLine();
                    WriteLine($"Střela způsobila {poskozeni} poškození.");
                }
            }           
            Thread.Sleep(450);
            ResetColor();

            //zmena statu

            void StatSwaperoo(Random r, ConsoleColor barvaVypisu)
            {
                ForegroundColor = barvaVypisu;
                string[] nazvy = { "Síla", "Obratnost", "Inteligence", "Štěstí" };
                int index = r.Next(0, nazvy.Length);
                int index2;
                do
                {
                    index2 = r.Next(0, nazvy.Length);
                }
                while (index == index2);

                string nazev1 = nazvy[index];
                int hodnota1 = 0;
                switch (nazev1)
                {
                    case "Síla":
                        hodnota1 = VasePostava.hracovaPostava.vSila;
                        break;
                    case "Obratnost":
                        hodnota1 = VasePostava.hracovaPostava.vObratnost;
                        break;
                    case "Inteligence":
                        hodnota1 = VasePostava.hracovaPostava.vInteligence;
                        break;
                    case "Štěstí":
                        hodnota1 = VasePostava.hracovaPostava.vStesti;
                        break;
                }

                string nazev2 = nazvy[index2];
                int hodnota2 = 0;
                switch (nazev2)
                {
                    case "Síla":
                        hodnota2 = VasePostava.hracovaPostava.vSila;
                        break;
                    case "Obratnost":
                        hodnota2 = VasePostava.hracovaPostava.vObratnost;
                        break;
                    case "Inteligence":
                        hodnota2 = VasePostava.hracovaPostava.vInteligence;
                        break;
                    case "Štěstí":
                        hodnota2 = VasePostava.hracovaPostava.vStesti;
                        break;
                }

                // Swap the values
                switch (nazev1)
                {
                    case "Síla":
                        VasePostava.hracovaPostava.vSila = hodnota2;
                        break;
                    case "Obratnost":
                        VasePostava.hracovaPostava.vObratnost = hodnota2;
                        break;
                    case "Inteligence":
                        VasePostava.hracovaPostava.vInteligence = hodnota2;
                        break;
                    case "Štěstí":
                        VasePostava.hracovaPostava.vStesti = hodnota2;
                        break;
                }

                switch (nazev2)
                {
                    case "Síla":
                        VasePostava.hracovaPostava.vSila = hodnota1;
                        break;
                    case "Obratnost":
                        VasePostava.hracovaPostava.vObratnost = hodnota1;
                        break;
                    case "Inteligence":
                        VasePostava.hracovaPostava.vInteligence = hodnota1;
                        break;
                    case "Štěstí":
                        VasePostava.hracovaPostava.vStesti = hodnota1;
                        break;
                }
                WriteLine();
                WriteLine($"Byla vyměněna hodnota atributu {nazev1} s atributem {nazev2}...");
                WriteLine();
                Thread.Sleep(350);
                WriteLine($"Hodnota stributu {nazev1} je nyní {hodnota2} a hodnota atributu {nazev2} je {hodnota1}.");
            }//metoda na stat swap (jde pouzit jinde)
        }

        public override int PoskozeniStvoreni() // vracíme hodnotu speciální schopnosti
        {
            return poskozeni;
        }

        public override void SchopnostStvoreni() // už celá funkce, která provede schopnost se vším všudy
        {
            Clear();
            StraznyAnimace();
            PrubehSchopnostiStvoreni();
        }

        public override void UtokStvoreni()
        {
            Clear();
            StraznyUtokAnimace();
            StraznyUtokPrubeh();
        }

        public override void ArtStvoreni()
        {
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.DarkGreen;
            Thread.Sleep(100);
            WriteLine(@"

            ⠀              //Valk art stv
                                                ");
            Thread.Sleep(2000);
            ResetColor();
            Clear();
        }
    }
    class ProkletaDryada : Stvoreni
    {
        static Random r = new Random();
        int rand = r.Next(0, 2);
        int cena = 5;
        public ProkletaDryada() // hodnoty base atributů tohoto monstra
        {

            zbranStvoreni = Žádná_Zbraň;
            zbrojStvoreni = Žádná_Zbroj;
            pouzitelnyPredmet = null;
            surovinyStvoreni = rand == 0 ? Osvícená_Smůla : Měsíční_Erb;
            sInteligence = 4;
            sSila = 1;
            sObratnost = 5;
            sStesti = 3;
            maManu = true;
            pocetMany = 10;
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 5 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 3 + hodnotaBrneni;
            sZdravi = 20 + sObrannaHodnota + sSila;
            pocetZlata = 0;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;
            nazevStvoreni = "Prokletá Dryáda";
            Bestiar.PridejDoBestiare(this);
            popis = @"'Mrštné lesní stvoření, které určitě neoplývalo sklony zla...
 
Něco se však stalo, a místo něčeho, co miluje přírodu, se předemnou zjevila chladnokrevná stvůra.'";

        }
        protected void StraznyAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine($"{nazevStvoreni} použila svou speciální schopnost...");
            Thread.Sleep(150);
            WriteLine(@"

                      //schopnost knih

                                                            ");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void StraznyUtokAnimace()
        {
            Thread.Sleep(150);
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine($"{nazevStvoreni} se připravuje k útoku...");
            Thread.Sleep(150);
            WriteLine(@"                                                                             ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀            // knih animace útoku.⠀");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void StraznyUtokPrubeh()
        {

            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            kostka.HodKostkou();
            WriteLine();
            Thread.Sleep(250);
            ResetColor();
            poskozeni = sUtocnaHodnota + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.DarkGreen;         
            WriteLine($"{nazevStvoreni} agresisvně kouše...");
            Thread.Sleep(150);
            WriteLine();
            WriteLine("Útok způsobil {0} poškození!", poskozeni);
            Thread.Sleep(450);
            ResetColor();

        }

        private void PrubehSchopnostiStvoreni() // to, co se stane při speciální schopnosti
        {
            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            kostka.HodKostkou();
            WriteLine();
            Thread.Sleep(250);
            ResetColor();
            poskozeni = (sObratnost + kostka.VysledekHodu())/2;
            ForegroundColor = ConsoleColor.DarkGreen;
            int random = r.Next(0, 2);
            if(!_UtokNaSpolecnika)
            {

                WriteLine($"{nazevStvoreni} se Vás pokusila proklít svou magickou silou...");
                WriteLine();
                if(pocetMany >= cena)
                {
                    pocetMany -= cena;
                    if(random == 0)
                    {
                        VasePostava.hracovaPostava.vUtocnaHodnota -= 1;
                        WriteLine($"Prokletí bylo úspěšné, útočná hodnota se Vám snižuje o 1!");

                    }
                    else
                    {
                        VasePostava.hracovaPostava.vObrannaHodnota -= 1;
                        WriteLine($"Prokletí bylo úspěšné, obranná hodnota se Vám snižuje o 1!");
                    }
                }
                else
                {
                    WriteLine("Prokletí se však nepodařilo...");
                }
            }
            else
            {
                WriteLine($"{nazevStvoreni} se Vašeho společníka pokusila proklít svou magickou silou...");
                WriteLine();
                if (pocetMany >= cena)
                {
                    pocetMany -= cena;
                    if (random == 0)
                    {
                        VasePostava.spolecnik.sUtocnaHodnota -= 1;
                        WriteLine($"Prokletí bylo úspěšné, útočná hodnota se společníkovi snižuje o 1!");

                    }
                    else
                    {
                        VasePostava.spolecnik.sObrannaHodnota -= 1;
                        WriteLine($"Prokletí bylo úspěšné, obranná hodnota se společníkovi snižuje o 1!");
                    }
                }
                else
                {
                    WriteLine("Prokletí se však nepodařilo...");
                }
            }
            WriteLine();
            WriteLine($"Magie způsobila {poskozeni} poškození...");
            Thread.Sleep(450);
            ResetColor();

            //zmena statu
          
        }

        public override int PoskozeniStvoreni() // vracíme hodnotu speciální schopnosti
        {
            return poskozeni;
        }

        public override void SchopnostStvoreni() // už celá funkce, která provede schopnost se vším všudy
        {
            Clear();
            StraznyAnimace();
            PrubehSchopnostiStvoreni();
        }

        public override void UtokStvoreni()
        {
            Clear();
            StraznyUtokAnimace();
            StraznyUtokPrubeh();
        }

        public override void ArtStvoreni()
        {
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.DarkGreen;
            Thread.Sleep(100);
            WriteLine(@"

            ⠀              //Valk art stv
                                                ");
            Thread.Sleep(2000);
            ResetColor();
            Clear();
        }
    }

}
