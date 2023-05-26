using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static System.Console;
using static DnD_Hra.VytvorenePredmety;


namespace DnD_Hra
{
    class Spoluvezen : Stvoreni
    {
        void Tlacitko()
        {
            ResetColor();
            Thread.Sleep(150);
            WriteLine();
            WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            ReadKey(true);
            Clear();
        }
        bool ss1;
        public Spoluvezen() // hodnoty base atributů tohoto monstra
        {
            ss1 = true;
            zbranStvoreni = Dýka;
            zbrojStvoreni = Kožená_Zbroj;
            pouzitelnyPredmet = null;
            surovinyStvoreni = null;
            sInteligence = 2;
            sSila = 1;
            sObratnost = 1;
            sStesti = 2;
            maManu = true;
            pocetMany = 20;
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 2 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 1 + hodnotaBrneni;
            sZdravi = 15 + sObrannaHodnota + sSila;
            pocetZlata = 0;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;
            maxMana = pocetMany;
            nazevStvoreni = "Spoluvězeň";
            Bestiar.PridejDoBestiare(this);
            popis = @"'Kamarád z vězení, spolubojovník a někdo, kdo si mnohé zažil.

 Ve vězeňské revoluci bojoval nelítostně a hrdě. Dělal to pro svého otce. Kdo by byl čekal, že i kouzlí... '";

        }
        protected void StraznyAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.DarkCyan;
            WriteLine("Váš spoluvězeň použil svou speciální schopnost...");
            if(ss1)
            {
                Thread.Sleep(250);
                WriteLine();
                WriteLine("Netušili jste, že umí kouzlit...");
                ss1 = false;
            }
            Thread.Sleep(150);
            WriteLine(@"

                      //schopnost spoluvězně

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
            WriteLine("Váš spoluvězeň se připravuje k útoku...");
            Thread.Sleep(150);
            WriteLine(@"                                                                             ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀            // spoluvezen animace útoku.⠀");
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
            
            if (poskozeni >= 4)
            {
                WriteLine("Váš spoluvězeň bodl svou dýkou...");
            }
            else
            {
                WriteLine("Váš spoluvězeň se pokusil bodnout dýkou, ale moc se to nepodařilo ...");
            }
            if(poskozeni >= 7 && pocetMany<maxMana)
            {
                WriteLine();
                Thread.Sleep(400);
                WriteLine("Útokem si také přidal manu.");
            }
            Thread.Sleep(150);
            WriteLine();
            WriteLine("Bod dýkou způsobil {0} poškození {1}", poskozeni, (poskozeni >= 7 && pocetMany < maxMana)?$"a spoluvězeň má {pocetMany} many":"");
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
            poskozeni = sUtocnaHodnota + sStesti + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.DarkCyan;
            byte cena = 4;
            if (poskozeni >= 7 && poskozeni < 10 && pocetMany >= cena)
            {
                WriteLine("Váš spoluvězeň seslal protekční kouzlo na Vás i jeho...");
                pocetMany -= cena;
                Thread.Sleep(150);
                sObrannaHodnota += 1;
                VasePostava.hracovaPostava.vObrannaHodnota += 1;
                for (int i = 0; i < 4; i++)
                {
                    if (VasePostava.hracovaPostava.vZdravi >= VasePostava.hracovaPostava.zdraviPostavy)
                    {
                        break;
                    }
                    VasePostava.hracovaPostava.vZdravi += 1;
                }
                for (int i = 0; i < 4; i++)
                {
                    if (sZdravi >= maxZdravi)
                    {
                        break;
                    }
                    sZdravi += 1;
                }
                WriteLine();
                WriteLine("Tím se oběma zvýší obranná hodnota o 1 a také se vyléčíte, pokud Vám zdraví chybí.");
                Thread.Sleep(250);
                WriteLine();
                WriteLine("Vaše obranná hodnota je nyní {0} a zdraví potom {1}.", VasePostava.hracovaPostava.vObrannaHodnota
                    , VasePostava.hracovaPostava.vZdravi);                
            }
            else if (poskozeni >=10 && pocetMany >= cena)
            {
                WriteLine("Váš spoluvězeň seslal posilující kouzlo na Vás i jeho...");
                pocetMany -= cena;
                Thread.Sleep(150);
                sUtocnaHodnota += 2;
                VasePostava.hracovaPostava.vUtocnaHodnota += 2;
                for (int i = 0; i < 2; i++)
                {
                    if (VasePostava.hracovaPostava.pocetMany >= VasePostava.hracovaPostava.maxMana ||!VasePostava.hracovaPostava.maManu)
                    {
                        break;
                    }
                    VasePostava.hracovaPostava.pocetMany += 1;
                }
                for (int i = 0; i < 2; i++)
                {
                    if (pocetMany >= maxMana)
                    {
                        break;
                    }
                    pocetMany += 1;
                }
                WriteLine();
                WriteLine("Tím se oběma zvýší útočná hodnota o 2 a také si doplníte manu, pokud nějakou máte.");
                Thread.Sleep(250);
                WriteLine();
                WriteLine("Vaše útočná hodnota je nyní {0} a mana potom {1}.", VasePostava.hracovaPostava.vUtocnaHodnota
                    , (VasePostava.hracovaPostava.maManu? VasePostava.hracovaPostava.pocetMany :"0, žádnou nemáte"),sUtocnaHodnota, pocetMany);             

            }
            else if (poskozeni<7)
            {
                WriteLine("Spoluvězeň se pokusil o posilovací kouzlo, ale selhal...");
            }
            else if (pocetMany < cena)
            {
                WriteLine("Spoluvězeň se pokusil o posilovací kouzlo, nemá na něj ale dost many. Nyní má jen {0} many a kouzlo stojí {1}...", pocetMany, cena);
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

            ⠀              //spoluvezen art
                                                ");
            Thread.Sleep(2000);
            ResetColor();
            Clear();
        }
    }
    class GeneralValorie : Stvoreni
    {
        
        public GeneralValorie() // hodnoty base atributů tohoto monstra
        {          
            zbranStvoreni = Smaragdové_Kopí;
            zbrojStvoreni = Železná_Zbroj;
            pouzitelnyPredmet = Lektvar_Síly;
            surovinyStvoreni = Smaragd;
            sInteligence = 1;
            sSila = 3;
            sObratnost = 1;
            sStesti = 1;
            maManu = false;
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 2 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 2 + hodnotaBrneni;
            sZdravi = 17 + sObrannaHodnota + sSila;
            pocetZlata = 10;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;
            nazevStvoreni = "Valorijský Generál";
            Bestiar.PridejDoBestiare(this);
            popis = @"'Velitel. Generál legie - tedy toho co z ní po našem nájezdu zbylo.

 Ctižádostivý a jak vím, jednoduše manipulovatelný. V souboji exceluje. ";

        }
        protected void StraznyAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Magenta;
            WriteLine("Generál použil svou speciální schopnost...");           
            Thread.Sleep(150);
            WriteLine(@"

                      //schopnost generál

                                                            ");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void StraznyUtokAnimace()
        {
            Thread.Sleep(150);
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.Magenta;
            WriteLine("Generál se připravuje k útoku...");
            Thread.Sleep(150);
            WriteLine(@"                                                                             ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀            // Generál ua.⠀");
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
            ForegroundColor = ConsoleColor.Magenta;
            WriteLine("Generál obratně bodl svým kopím.");                     
            Thread.Sleep(150);
            WriteLine();
            WriteLine("Zásah kopím způsobil {0} poškození", poskozeni);
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
            poskozeni = sUtocnaHodnota +sSila + sStesti + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.Magenta;
            if(poskozeni >= 11)
            {
                WriteLine("Generál provedl mrštný výpad kopím");
                Thread.Sleep(250);
                WriteLine();
                WriteLine("Stíhá tak ve své akci ještě jednou zaútočit...");
                int vypadDMG = (int)(poskozeni *0.33);
                WriteLine();
                WriteLine($"Výpad způsobil {vypadDMG} poškození.");
                Thread.Sleep(250);
                GameplayLokaci_1.Tlacitko();
                UtokStvoreni();
                poskozeni += vypadDMG;
                WriteLine();
                ForegroundColor = ConsoleColor.Magenta;
                WriteLine("Celkové poškození Generálových útočných sekvencí tedy je {0}.", poskozeni);
            }
            else
            {
                int ublizeni = new Random().Next(1, 4);
                WriteLine("Generál se pokusil o výpad kopím, avšak se mu nepovedl a ublížil sám sobě.");
                Thread.Sleep(250);
                sZdravi -= ublizeni;
                if (sZdravi < 0)
                    sZdravi = 0;
                WriteLine();
                WriteLine($"Generál si nešikovností způsobil {ublizeni} poškození a nyní má {sZdravi} zdraví.");
                poskozeni = 0;
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
            ForegroundColor = ConsoleColor.DarkCyan;
            Thread.Sleep(100);
            WriteLine(@"

            ⠀              //spoluvezen art
                                                ");
            Thread.Sleep(2000);
            ResetColor();
            Clear();
        }
    }
    class MarkrabeMatador : Stvoreni
    {
        bool Promenen;
        byte pocitadlo;
        public MarkrabeMatador() // hodnoty base atributů tohoto monstra
        {
            pocitadlo = 0;
            Promenen = false;
            zbranStvoreni = Prokletá_Čepel;
            zbrojStvoreni = Lichovo_Roucho;
            pouzitelnyPredmet = Lektvar_Vzkříšení;
            surovinyStvoreni = Temná_Esence;
            sInteligence = 3;
            sSila = 2;
            sObratnost = 3;
            sStesti = 2;           
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 2 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 3 + hodnotaBrneni;
            sZdravi = 20 + sObrannaHodnota + sSila;
            pocetZlata = 0;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;
            nazevStvoreni = "Markrabě Matador de Ángel";
            Bestiar.PridejDoBestiare(this);
            popis = @"'Šílenec. Nepředvídatelná entita, ovládá nepopsanou magii.
 
 Měl dohodu s Eirlys, zašel však moc daleko. Bez Eirlys jsem v boji bez šance.

 Je v něm mnohem, mnohem víc, než se může zdát...'";

        }
        protected void StraznyAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
            if (!Promenen)
                ForegroundColor = ConsoleColor.Magenta;
            else
                ForegroundColor = ConsoleColor.DarkBlue;
            WriteLine($"{nazevStvoreni} použil svou speciální schopnost...");
            Thread.Sleep(150);
            if (pocitadlo >= 2 && !Promenen)
                WriteLine(@"

                      //proměna v Liche

                                                            ");
            else if (Promenen)
                WriteLine(@"

                      //Schopnost v lichovi

                                                            ");
            else if(pocitadlo<2)
                WriteLine(@"

                      //Schopnost v makrabeti

                                                            ");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void StraznyUtokAnimace()
        {
            Thread.Sleep(150);
            OutputEncoding = Encoding.UTF8;
            if (!Promenen)
                ForegroundColor = ConsoleColor.Magenta;
            else
                ForegroundColor = ConsoleColor.DarkBlue;           
                WriteLine($"{nazevStvoreni} se připravuje k útoku...");
            Thread.Sleep(150);
            if(!Promenen)
            WriteLine(@"                                                                             ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀            // Markrabě atk anim⠀");
            else
                WriteLine(@"                                                                             ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀            // Markrabě lich⠀");
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
            if (!Promenen)
            {
                ForegroundColor = ConsoleColor.Magenta;
                poskozeni = sUtocnaHodnota + kostka.VysledekHodu();
            }
            else
            {
                ForegroundColor = ConsoleColor.DarkBlue;
                poskozeni = sUtocnaHodnota + kostka.VysledekHodu() + sInteligence;
               
            }
            

            if (!Promenen)
            {
                WriteLine($"{nazevStvoreni} sekl svou Prokletou čepelí...");
                WriteLine();
                Thread.Sleep(150);
                WriteLine("Zásah způsobil {0} poškození.", poskozeni);
               
            }
            else
            {
                WriteLine($"{nazevStvoreni} využil životosajné síly, ukradl cíli část jeho života...");
                WriteLine();
                Thread.Sleep(150);
                poskozeni = (int)(poskozeni* 0.65);
                WriteLine("Životosajná síla způsobila {0} poškození a Lichovi přidala {0} zdraví, pokud mu chybí.", poskozeni);
                WriteLine();
                sZdravi += poskozeni;
                if (sZdravi > maxZdravi)
                    sZdravi = maxZdravi;
                WriteLine($"{nazevStvoreni} má nyní {sZdravi} zdraví...");
            }
            Thread.Sleep(450);
            ResetColor();

        }

        private void PrubehSchopnostiStvoreni() // to, co se stane při speciální schopnosti
        {
            pocitadlo ++;
            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            kostka.HodKostkou();
            WriteLine();
            Thread.Sleep(250);
            ResetColor();
            if (Promenen)
                poskozeni = sUtocnaHodnota + sInteligence + kostka.VysledekHodu();
            else
                poskozeni = sUtocnaHodnota + kostka.VysledekHodu();
            if (pocitadlo >= 2 && !Promenen)
                Promena();
            else
                SS();            
            Thread.Sleep(450);
            ResetColor();
            void Promena()
            {
                Promenen = true;
                ForegroundColor = ConsoleColor.DarkBlue;
                WriteLine($"{nazevStvoreni} se proměnil v nemrtvého Liche, disponujícího magií, která bere život samotný...");
                WriteLine();
                Thread.Sleep(350);
                WriteLine("Získal tedy nový set schopností a nový vzhled, který Vás zužuje. Také si přidal zdraví a změnil výbavu...");

                sZdravi += 15;
                maxZdravi += 15;
                zbranStvoreni = Žádná_Zbraň;
                sUtocnaHodnota = 5 + zbranStvoreni.poskozeniZbrane;
                sUtocnaHodnota += 4;
                sObrannaHodnota += 2;
                sInteligence += 2;
                WriteLine();
                nazevStvoreni = "Markrabě - nemrtvý Lich";
                WriteLine($"{nazevStvoreni} má nyní {sZdravi} zdraví!");
                poskozeni = 0;               
            }
            void SS()
            {
                if(Promenen)
                {
                    ForegroundColor = ConsoleColor.DarkBlue;
                   int pridavek = (int)(poskozeni * 0.25);
                    WriteLine($"{nazevStvoreni} se očaroval temnou magií a přidal si tak {pridavek} k obranné a útočné hodnotě...");
                    sObrannaHodnota += pridavek;
                    sUtocnaHodnota += pridavek;
                    WriteLine();
                    Thread.Sleep(300);
                    WriteLine("Nyní má obrannou hodnotu {0} a útočnou {1}...", sObrannaHodnota, sUtocnaHodnota);
                    WriteLine();
                    Thread.Sleep(250);
                    poskozeni = (int)(poskozeni * 0.65);
                    WriteLine("Přítomnost temné magie cíl také poškodila a vzala cíli {0} zdraví...", poskozeni);
                }
                else
                {
                   
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine($"{nazevStvoreni} se dotkl svého amuletu a tak si vypůjčil démonickou sílu..."); 
                    int amuletP = (poskozeni >= 7 && poskozeni < 11)? 2:3;
                    int OHP = amuletP+1;
                    WriteLine();
                    Thread.Sleep(300);
                    WriteLine($"Zvýšil tak VŠECHNY své atributy o {amuletP} a k tomu si navíc přidá {OHP} k obranné hodnotě!");
                    WriteLine();
                    Thread.Sleep(300);                   
                    sInteligence += amuletP;
                    sSila += amuletP;
                    sObratnost += amuletP;
                    sStesti += amuletP;                   
                    sUtocnaHodnota += amuletP;                   
                    sObrannaHodnota += amuletP + OHP;
                    sZdravi += amuletP;
                    maxZdravi += amuletP;
                    if (sZdravi > maxZdravi)
                        sZdravi = maxZdravi;
                    WriteLine($"{nazevStvoreni} má nyní {sZdravi} zdraví, {sObrannaHodnota} obranné hodnoty a {sUtocnaHodnota} útočné hodnoty!");
                    Thread.Sleep(250);
                    poskozeni = 0;                    
                }
            }
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
            if(pocitadlo == 0 || (!Promenen && (sZdravi < maxZdravi/2)))
            {
                StraznyAnimace();
                PrubehSchopnostiStvoreni();
                return;
            }

            StraznyUtokAnimace();
            StraznyUtokPrubeh();
        }

        public override void ArtStvoreni()
        {
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.DarkCyan;
            Thread.Sleep(100);
            WriteLine(@"

            ⠀              //spoluvezen art
                                                ");
            Thread.Sleep(2000);
            ResetColor();
            Clear();
        }
    }

}
