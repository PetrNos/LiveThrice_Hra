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
    class VelitelTemnychElfu : Stvoreni
    {
        static Random r = new Random();
        int rand = r.Next(0, 2);
        static int prvniVelitel = 0;
        public VelitelTemnychElfu() // hodnoty base atributů tohoto monstra
        {
            prvniVelitel++;
            zbranStvoreni = Meč; ;
            zbrojStvoreni = Kožená_Zbroj;
            pouzitelnyPredmet = prvniVelitel == 1?Elixír_Časoprostoru:Lektvar_Zdraví;
            surovinyStvoreni = rand == 0 ? Osvícená_Smůla : Měsíční_Erb;
            specialniPredmet = prvniVelitel == 1 ?Maska_Míru:null;
            sInteligence = 5;
            sSila = 3;
            sObratnost = 6;
            sStesti = 4;
            maManu = false;            
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 1 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 1 + hodnotaBrneni;
            sZdravi = 30 + sObrannaHodnota + sSila;
            pocetZlata = 5;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni, specialniPredmet };
            maxZdravi = sZdravi;
            nazevStvoreni = "Velitel Temných Elfů";
            Bestiar.PridejDoBestiare(this);
            popis = @"'Komandér a koordinátor experimentů této rasy.

 Lítý v souboji, chladný povahou a nešetrný k přírodě jako všichni temní elfové.";

        }
        protected void StraznyAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.DarkGreen;
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
            WriteLine($"{nazevStvoreni} seká svou zbraní...");
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
            poskozeni = (int)((sObratnost + kostka.VysledekHodu()) *0.8);
            ForegroundColor = ConsoleColor.DarkGreen;           
            if (!_UtokNaSpolecnika)
            {
                if(VasePostava.hracovaPostava.vObrannaHodnota > sObrannaHodnota)
                {
                    WriteLine($"{nazevStvoreni} je zaujat Vaší schopností se bránit...");
                    WriteLine();
                    WriteLine("Mění tak svou obrannou hodnotu s tou Vaší...");
                    int temp = VasePostava.hracovaPostava.vObrannaHodnota;
                    VasePostava.hracovaPostava.vObrannaHodnota = sObrannaHodnota;
                    sObrannaHodnota = temp;
                    WriteLine();
                    Thread.Sleep(300);
                    WriteLine($"Nyní máte {VasePostava.hracovaPostava.vObrannaHodnota} obranné hodnoty.");
                    poskozeni = 0;
                   
                }
                else if (VasePostava.hracovaPostava.vUtocnaHodnota > sUtocnaHodnota)
                {
                     WriteLine($"{nazevStvoreni} je zaujat Vaší schopností útočit...");
                    WriteLine();
                    WriteLine("Mění tak svou útočnou hodnotu s tou Vaší...");
                    int temp = VasePostava.hracovaPostava.vUtocnaHodnota;
                    VasePostava.hracovaPostava.vUtocnaHodnota = sUtocnaHodnota;
                    sUtocnaHodnota = temp;
                    WriteLine();
                    Thread.Sleep(300);
                    WriteLine($"Nyní máte {VasePostava.hracovaPostava.vUtocnaHodnota} útočné hodnoty.");
                    poskozeni = 0;
                }
                else
                {
                    WriteLine($"{nazevStvoreni} hypnózou mění Vaši útočnou hodnotu s Obrannou hodnotou...");
                    WriteLine();                   
                    int temp = VasePostava.hracovaPostava.vObrannaHodnota;
                    int t2 = VasePostava.hracovaPostava.vUtocnaHodnota;
                    VasePostava.hracovaPostava.vUtocnaHodnota = temp;
                    VasePostava.hracovaPostava.vObrannaHodnota = t2;
                    Thread.Sleep(300);
                    WriteLine($"Nyní máte {VasePostava.hracovaPostava.vObrannaHodnota} obranné hodnoty a {VasePostava.hracovaPostava.vUtocnaHodnota} té útočné.");
                    WriteLine();
                    Thread.Sleep(350);
                    WriteLine($"Hypnóza Vám také způsobila {poskozeni} poškození...");
                }

            }
            else
            {
                WriteLine($"{nazevStvoreni} zasadil silný zásah s nenávistí pro odlišná stvoření...");
                WriteLine();
                Thread.Sleep(250);
                poskozeni += 2;
                WriteLine($"Zásah způsobil {poskozeni} poškození.");                  
            }                    
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
    class Dryada : Stvoreni
    {
        static Random r = new Random();
        int cena = 2;
        public Dryada() // hodnoty base atributů tohoto monstra
        {

            zbranStvoreni = Žádná_Zbraň;
            zbrojStvoreni = Žádná_Zbroj;
            pouzitelnyPredmet = null;
            surovinyStvoreni = null;
            sInteligence = 4;
            sSila = 1;
            sObratnost = 5;
            sStesti = 3;
            maManu = true;
            pocetMany = 10;
            maxMana = pocetMany;
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 5 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 4 + hodnotaBrneni;
            sZdravi = 20 + sObrannaHodnota + sSila;
            pocetZlata = 0;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;
            nazevStvoreni = "Dryáda";
            Bestiar.PridejDoBestiare(this);
            popis = @"'Neškodné lesní stvoření, kterému jde o dobré bytí jejich ekosystému

 Tvoří skvělé a obětavé společníky na výpravách.'";

        }
        protected void StraznyAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Green;
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
            ForegroundColor = ConsoleColor.Green;
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
            ForegroundColor = ConsoleColor.Green;
            int cena = 2;
            if (pocetMany >= cena)
            {

                WriteLine($"{nazevStvoreni} používá lesní magii...");
                poskozeni += 2;
            }
            else
            {
                WriteLine($"{nazevStvoreni} útočí na nepřítele...");
            }
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
            poskozeni = (int)((sObratnost + sInteligence + kostka.VysledekHodu()) / 2.5);
            ForegroundColor = ConsoleColor.Green;
            int random = r.Next(0, 2);
            WriteLine($"{nazevStvoreni} se nepřítele pokusila proklít svou magickou silou...");
            WriteLine();
            if (pocetMany >= cena)
            {
                int heal = (int)(poskozeni * 0.5);
                pocetMany -= cena;
                if (random == 0)
                {
                    VasePostava._aktualniNepritel.sUtocnaHodnota -= 1;
                    WriteLine($"Prokletí bylo úspěšné, útočná hodnota se nepříteli snižuje o 1!");


                }
                else
                {
                    VasePostava._aktualniNepritel.sObrannaHodnota -= 1;
                    WriteLine($"Prokletí bylo úspěšné, obranná hodnota se nepříteli snižuje o 1!");
                }
                WriteLine($"Také Vám oběma doplní {heal} životů, pokud Vám nějaké chybí!");
                VasePostava.hracovaPostava.vZdravi += heal;
                if (VasePostava.hracovaPostava.vZdravi > VasePostava.hracovaPostava.zdraviPostavy)
                    VasePostava.hracovaPostava.vZdravi = VasePostava.hracovaPostava.zdraviPostavy;
                sZdravi += heal;
                if (sZdravi > maxZdravi)
                    sZdravi = maxZdravi;
                WriteLine();
                WriteLine($"Nyní máte {VasePostava.hracovaPostava.vZdravi} životů.");
            }
            else
            {
                WriteLine("Prokletí se však nepodařilo...");
            }
            WriteLine();
            WriteLine($"Magie také způsobila {poskozeni} poškození nepříteli!");
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
            ForegroundColor = ConsoleColor.Green;
            Thread.Sleep(100);
            WriteLine(@"

            ⠀              //Valk art stv
                                                ");
            Thread.Sleep(2000);
            ResetColor();
            Clear();
        }
    }

    class DabelskaKamikaze : Stvoreni
    {
        static Random r = new Random();            
        public DabelskaKamikaze() // hodnoty base atributů tohoto monstra
        {
            int rn = r.Next(0, 2);
            zbranStvoreni = Žádná_Zbraň;
            zbrojStvoreni = Žádná_Zbroj;
            pouzitelnyPredmet = Dryak_Sebevzniceni;
            surovinyStvoreni = rn==0?Ohnivý_Prach:Dračí_Květ;
            sInteligence = 2;
            sSila = 2;
            sObratnost = 10;
            sStesti = 10;
            maManu = false;           
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 6 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 2 + hodnotaBrneni;
            sZdravi = 15 + sObrannaHodnota + sSila;
            pocetZlata = 5;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;
            nazevStvoreni = "Ďábelská Kamikaze";
            Bestiar.PridejDoBestiare(this);
            popis = @"'Komando pekelných odpalovačů, nikdy nejsou sami.

 Impulzivní a nepředvídatelní, klidně obětují svůj život za pořádný výbuch.'";

        }
        protected void StraznyAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Red;
            WriteLine($"{nazevStvoreni} použilo svou speciální schopnost...");
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
            ForegroundColor = ConsoleColor.Red;
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
            ForegroundColor = ConsoleColor.Red;                      
            WriteLine($"{nazevStvoreni} po Vás háže dynamit...");           
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
            poskozeni = 2 * sZdravi + sUtocnaHodnota + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.Red;
            WriteLine("Komando se na místě odpálilo, způsobujíc značné poškození...");
            Thread.Sleep(350);
            WriteLine();
            WriteLine($"Odpálení způsobilo {poskozeni} poškození!");
            WriteLine();
            Thread.Sleep(250);
            WriteLine("Tím komando umírá...");
            sZdravi = 0;
            Thread.Sleep(200);
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
            ForegroundColor = ConsoleColor.Red;
            Thread.Sleep(100);
            WriteLine(@"

            ⠀              //Valk art stv
                                                ");
            Thread.Sleep(2000);
            ResetColor();
            Clear();
        }
    }
    class ZaskodnickyImp : Stvoreni
    {
        static Random r = new Random();
        public ZaskodnickyImp() // hodnoty base atributů tohoto monstra
        {
            int rn = r.Next(0, 2);
            zbranStvoreni = Žádná_Zbraň;
            zbrojStvoreni = Žádná_Zbroj;
            pouzitelnyPredmet = rn ==0?Lektvar_Obratnosti:Lektvar_Stesti;
            surovinyStvoreni = rn == 0 ? Ohnivý_Prach : Dračí_Květ;
            sInteligence = 4;
            sSila = 1;
            sObratnost = 15;
            sStesti = 12;
            maManu = false;
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 5 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 3 + hodnotaBrneni;
            sZdravi = 15 + sObrannaHodnota + sSila;
            pocetZlata = 6;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;
            nazevStvoreni = "Záškodnický Imp";
            Bestiar.PridejDoBestiare(this);
            popis = @"'Mrštná létavá stvoření. Nesmím je nechat moc dlouho na živu, nebo začnou létat moc rychle.

 Také mi dokáží snížit všechny atributy jejich speciálním plynem.'";

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
            WriteLine($"{nazevStvoreni} udělál výpad a rychle polétává okolo...");
            Thread.Sleep(150);
            WriteLine();
            WriteLine("Útok způsobil {0} poškození!", poskozeni);
            Thread.Sleep(300);
            WriteLine();
            WriteLine("Také si svou obratnost a štěstí zvyšuje o 10!");
            sObratnost += 10;
            sStesti += 10;
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
            poskozeni = (int)((sUtocnaHodnota + kostka.VysledekHodu())*0.3333333);
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine("Imp vyhazuje bombičku ze zvláštním plynem...");
            Thread.Sleep(350);
            WriteLine();
            if (!_UtokNaSpolecnika)
            {

                WriteLine($"Plyn Vám snižuje VŠECHNY atributy o {poskozeni}!");
                snizeniStatu(poskozeni, true);
                poskozeni = 0;
            }
            else
            {
                WriteLine($"Plyn VAšemu společníkovi snižuje VŠECHNY atributy o {poskozeni}!");
                snizeniStatu(poskozeni, false);
                poskozeni = 0;
            }
            Thread.Sleep(200);
            ResetColor();

            //zmena statu
            void snizeniStatu(int snizeni, bool hrac)
            {
                if(hrac)
                {
                    VasePostava.hracovaPostava.vSila -= snizeni;
                    VasePostava.hracovaPostava.vObratnost -= snizeni;
                    VasePostava.hracovaPostava.vInteligence -= snizeni;
                    VasePostava.hracovaPostava.vStesti -= snizeni;
                    VasePostava.hracovaPostava.vUtocnaHodnota -= snizeni;
                    VasePostava.hracovaPostava.vObrannaHodnota -= snizeni;
                    VasePostava.hracovaPostava.vZdravi -= snizeni;
                    if (VasePostava.hracovaPostava.vZdravi < 0)
                        VasePostava.hracovaPostava.vZdravi = 0;
                    if (VasePostava.hracovaPostava.maManu)
                        VasePostava.hracovaPostava.pocetMany -= snizeni;
                    if (VasePostava.hracovaPostava.pocetMany < 0)
                        VasePostava.hracovaPostava.pocetMany = 0;
                }
                else
                {
                    VasePostava.spolecnik.sSila -= snizeni;
                    VasePostava.spolecnik.sObratnost -= snizeni;
                    VasePostava.spolecnik.sInteligence -= snizeni;
                    VasePostava.spolecnik.sStesti -= snizeni;
                    VasePostava.spolecnik.sUtocnaHodnota -= snizeni;
                    VasePostava.spolecnik.sObrannaHodnota -= snizeni;
                    VasePostava.spolecnik.sZdravi -= snizeni;
                    if (VasePostava.spolecnik.sZdravi < 0)
                        VasePostava.spolecnik.sZdravi = 0;
                    if (VasePostava.spolecnik.maManu)
                        VasePostava.spolecnik.pocetMany -= snizeni;
                    if (VasePostava.spolecnik.pocetMany < 0)
                        VasePostava.spolecnik.pocetMany = 0;
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
    class RohatyVyhazovac : Stvoreni
    {
        static Random r = new Random();
        public RohatyVyhazovac() // hodnoty base atributů tohoto monstra
        {
            int rn = r.Next(0, 2);
            zbranStvoreni = Pekelny_Bič;
            zbrojStvoreni = Pekelne_Platy;
            pouzitelnyPredmet = rn == 0 ? Lektvar_Síly : Lektvar_Stesti;
            surovinyStvoreni = rn == 0 ? Ohnivý_Prach : Železný_Ingot;
            sInteligence = 3;
            sSila = 8;
            sObratnost = 3;
            sStesti = 5;
            maManu = false;
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 5 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 6 + hodnotaBrneni;
            sZdravi = 22 + sObrannaHodnota + sSila;
            pocetZlata = 8;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;
            nazevStvoreni = "Rohatý Vyhazovač";
            Bestiar.PridejDoBestiare(this);
            popis = @"'Odolný a nekompromisní vyhazovač. Nemá rád cizince.

 Kombinace jeho biče a plátové zbroje mu v souboji sedí, je velmi nebezpečný.'";

        }
        protected void StraznyAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.DarkRed;
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
            ForegroundColor = ConsoleColor.DarkRed;
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
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine($"{nazevStvoreni} udeřil svým bičem...");
            Thread.Sleep(150);
            WriteLine();
            WriteLine("Útok způsobil {0} poškození!", poskozeni);
            Thread.Sleep(300);          
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
            poskozeni = (int)((sUtocnaHodnota + kostka.VysledekHodu()) * 0.75);
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine($"{nazevStvoreni} se zastavuje a nabírá sílu...");
            Thread.Sleep(350);
            WriteLine();
            WriteLine($"{nazevStvoreni} zvyšuje svou sílu a štěstí o {poskozeni}.");                      
            Thread.Sleep(200);
            WriteLine();
            WriteLine($"Hořící aura také způsobila {poskozeni} poškození!");
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
            ForegroundColor = ConsoleColor.DarkRed;
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
