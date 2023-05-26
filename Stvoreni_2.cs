using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static System.Console;
using static DnD_Hra.VytvorenePredmety;

namespace DnD_Hra
{
    internal class Bandita : Stvoreni
    {

        public Bandita() // hodnoty base atributů tohoto monstra
        {
            int random = new Random().Next(0, 3);
            zbranStvoreni = (random ==0)?Meč:(random == 1) ?Luk:Dýka;
            zbrojStvoreni = Kožená_Zbroj;
            pouzitelnyPredmet = null;
            surovinyStvoreni = (random == 0)? Kůže :(random == 1)?Železný_Ingot:Zvláštní_Čtyřlístek;
            sInteligence = 1;
            sSila = 2;
            sObratnost = 1;
            sStesti = 1;
            maManu = false;
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 2 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 1 + hodnotaBrneni;
            sZdravi = 14 + sObrannaHodnota + sSila;
            pocetZlata = 3;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;
            nazevStvoreni = "Bandita";
            Bestiar.PridejDoBestiare(this);
            popis = @"'Banditi jsou hodně nepříjemní, věčně mají zálusk na to, co si nesu v batohu...
                    
 Co se boje týče rozhodně na tom nejsou špatně, nejhorší je, že obvykle bojují ve skupinách...'";
            
        }
        protected void BanditaAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("Bandita použil svou speciální schopnost...");
            Thread.Sleep(150);
            WriteLine(@"

                      //schopnost bandity

                                                            ");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void BanditaUtokAnimace()
        {
            Thread.Sleep(150);
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("Bandita se připravuje k útoku...");
            Thread.Sleep(150);
            WriteLine(@"                                                                             ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀            // bandita animace útoku.⠀");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void BanditaUtokPrubeh()
        {

            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            kostka.HodKostkou();
            WriteLine();
            Thread.Sleep(250);
            ResetColor();
            poskozeni = sUtocnaHodnota + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.Yellow;

            if (poskozeni >= 6)
            {
                WriteLine("Bandita se rozmáchl svým mečem a zasadil poměrně přesnou ránu");
            }
            else
            {
                WriteLine("Banditovi se jeho výpad mečem moc nepodařil...");
            }

            WriteLine();
            Thread.Sleep(150);
            WriteLine("Výpad mečem způsobil {0} poškození!", poskozeni);
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
            poskozeni = sUtocnaHodnota + sObratnost + sStesti + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("Bandita se pokusil o cílený zásah na křehké předměty v inventáři cíle.");
            Thread.Sleep(150);
            WriteLine();
            if (poskozeni >= 9)
            {

                if (DndHerniFunkce._UtokNaSpolecnika == false)
                {

                    if (VasePostava.inventarPostavy.ZiskejPocetPredmetu(3) > 0)
                    {
                        Random r = new Random();
                        var listPouzitych = VasePostava.inventarPostavy.ListInventare().Where(p => p is Pouzitelne && p!= VytvorenePredmety.Zlaťák).GroupBy(p => p.ID).Select(l => l.First()).ToList();
                        Pouzitelne vybranyPredmet = (Pouzitelne)listPouzitych[r.Next(0, listPouzitych.Count)];
                        VasePostava.inventarPostavy.OdeberPredmet(vybranyPredmet);
                        WriteLine("Bandita Vám svoji mířenou ránou rozbil {0}!", vybranyPredmet.nazevPredmetu);

                    }
                    else
                    {
                        WriteLine("Ve Vašem inventáři se naštěstí pro vás nenachází žádný křehký předmět...");

                    }

                }
                else
                {

                    WriteLine("Váš společník nemá ale v inventáři žádné křehké předměty.");
                    Thread.Sleep(200);
                    WriteLine();
                    WriteLine("Zásah způsobí tedy jen poškození...");


                }

            }
            else
            {
                WriteLine("Zásah se mu ale nepovedl, způsobí tedy jen poškození...");
               
            }
            poskozeni -= (sStesti + sObratnost);
            WriteLine();
            Thread.Sleep(250);
            WriteLine("Bandita jeho mířeným zásahem mečem způsobil {0} poškození!", poskozeni);
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
            BanditaAnimace();
            PrubehSchopnostiStvoreni();
        }

        public override void UtokStvoreni()
        {
            Clear();
            BanditaUtokAnimace();
            BanditaUtokPrubeh();
        }

        public override void ArtStvoreni() 
        {
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.Yellow;
            Thread.Sleep(100);
            WriteLine(@"

            ⠀              //bandita art
                                                ");
            Thread.Sleep(2000);
            ResetColor();
            Clear();
        }
    }
    //------------------------------VŮDCE BANDITŮ

    internal class VudceBanditu : Stvoreni
    {

        public VudceBanditu() // hodnoty base atributů tohoto monstra
        {
            zbranStvoreni = Štastlivcovo_Žihadlo;
            zbrojStvoreni = Železná_Zbroj;
            pouzitelnyPredmet = Lektvar_Síly;
            surovinyStvoreni = Zvláštní_Čtyřlístek;
            sInteligence = 2;
            sSila = 3;
            sObratnost = 3;
            sStesti = 2;
            maManu = false;
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 4 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 3 + hodnotaBrneni;
            sZdravi = 20 + sObrannaHodnota + sSila;
            pocetZlata = 5;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;
            nazevStvoreni = "Bandita Vůdce";
            Bestiar.PridejDoBestiare(this);
            popis = @"'Bandita, ale tenhle byl silnější. Vypadal nebezpečně a měl u sebe očarované šídlo...

 V souboji exceloval a vyčerpal mě, snad moc takových už nepotkám...'";
           

        }
        protected void BanditaAnimace() // animace schopnosti
        {            
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine("Bandita použil svou speciální schopnost...");
            Thread.Sleep(150);
            WriteLine(@"

                      //schopnost bandityV

                                                            ");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void BanditaUtokAnimace()
        {
            Thread.Sleep(150);
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine("Bandita se připravuje k útoku...");
            Thread.Sleep(150);
            WriteLine(@"                                                                             ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀            // bandita animace útoku.⠀");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void BanditaUtokPrubeh()
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
            if (poskozeni >= 6)
            {
                WriteLine("Bandita Vůdce bodl svým šídlem a zasadil poměrně přesnou ránu");
            }
            else
            {
                WriteLine("Vůdci banditů se jeho výpad šídlem moc nepodařil...");
            }

            WriteLine();
            Thread.Sleep(150);
            WriteLine("Výpad šídlem způsobil {0} poškození!", poskozeni);
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
            poskozeni = sUtocnaHodnota + sObratnost + sStesti + kostka.VysledekHodu();                         
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine("Bandita Vůdce se pokusil o cílený zásah na suroviny v inventáři cíle.");
            Thread.Sleep(150);
            WriteLine();
            if (poskozeni >= 9)
            {

                if (DndHerniFunkce._UtokNaSpolecnika == false)
                {

                    if (VasePostava.inventarPostavy.ZiskejPocetPredmetu(4) > 0)
                    {
                        Random r = new Random();
                        var listPouzitych = VasePostava.inventarPostavy.ListInventare().Where(p => p is Suroviny).GroupBy(p => p.ID).Select(l => l.First()).ToList();
                        Suroviny vybranyPredmet = (Suroviny)listPouzitych[r.Next(0, listPouzitych.Count)];
                        VasePostava.inventarPostavy.OdeberPredmet(vybranyPredmet);
                        WriteLine("Bandita Vůdce Vám svoji mířenou ránou zničil {0}!", vybranyPredmet.nazevPredmetu);

                    }
                    else
                    {
                        WriteLine("Ve Vašem inventáři se naštěstí pro vás nenachází žádné suroviny...");

                    }

                }
                else
                {

                    WriteLine("Váš společník nemá ale v inventáři žádné suroviny.");
                    Thread.Sleep(200);
                    WriteLine();
                    WriteLine("Zásah způsobí tedy jen poškození...");


                }

            }
            else
            {
                WriteLine("Zásah se mu ale nepovedl, způsobí tedy jen poškození...");

            }
            poskozeni -= sStesti;
            WriteLine();
            Thread.Sleep(250);
            WriteLine("Bandita Vůdce jeho mířeným zásahem šídlem způsobil {0} poškození!", poskozeni);
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
            BanditaAnimace();
            PrubehSchopnostiStvoreni();
        }

        public override void UtokStvoreni()
        {
            Clear();
            BanditaUtokAnimace();
            BanditaUtokPrubeh();
        }

        public override void ArtStvoreni()
        {
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.DarkYellow;
            Thread.Sleep(100);
            WriteLine(@"

            ⠀              //bandita art
                                                ");
            Thread.Sleep(2000);
            ResetColor();
            Clear();
        }
    }
    internal class DrevenyPanak : Stvoreni             //-------------- //SKŘET
    {
        public DrevenyPanak() // hodnoty base atributů tohoto monstra
        {
            zbranStvoreni = Žádná_Zbraň;
            zbrojStvoreni = Žádná_Zbroj;
            pouzitelnyPredmet = null;
            surovinyStvoreni = null;
            sInteligence = -4;
            sSila = -3;
            sObratnost = -10;
            sStesti = -2;
            maManu = false;
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 0 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 1 + hodnotaBrneni;
            sZdravi = 25 + sObrannaHodnota + sSila;
            pocetZlata = 0;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;
            nazevStvoreni = "Dřvěný panák";           
        }



        protected void DrevenyPanakAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.DarkMagenta;
            WriteLine("Dřevěný panák svou speciální schopnost...");
            Thread.Sleep(150);
            WriteLine(@"

                   //dřevěný panák schopnost

                                                            ");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void DPUtokAnimace()
        {
            Thread.Sleep(150);
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.DarkMagenta;
            WriteLine("Dřevěný panák se připravuje k útoku...");
            Thread.Sleep(150);
            WriteLine(@"  

                //dřevěný panák útok
                    ⠀");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void DrevenyPanakUtokPrubeh()
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


            if (poskozeni >= 3)
            {
                WriteLine("Dřevěný panák se větrem otočil zády k Vám a přidal si tak obrannou hodnotu!");
                sObrannaHodnota += 1;
                WriteLine();
                WriteLine("Obranná hodnota Dřevěného panáka je nyní {0}", sObrannaHodnota);
            }
            else
            {
                WriteLine("Dřevěný panák nehybně stojí...");
            }
            poskozeni = 0;
            WriteLine();
            Thread.Sleep(150);
            WriteLine("Dřevěný panák Vám způsobil {0} poškození", poskozeni);           
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
            poskozeni = (2 + sUtocnaHodnota) + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.DarkMagenta;

            if (poskozeni >= 4)
            {
                WriteLine("Dřevěný panák Vám spadl na nohu...");
            }
            else
            {
                WriteLine("Dřevěný panák se bezmocně válí po zemi...");
                poskozeni = 0;
            }

            WriteLine();
            Thread.Sleep(150);
            WriteLine("Dřevěný panák Vám způsobil {0} poškození", poskozeni);

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
            DrevenyPanakAnimace();
            PrubehSchopnostiStvoreni();
        }

        //**********************************************************************************
        public override void UtokStvoreni()
        {
            Clear();
            DPUtokAnimace();
            DrevenyPanakUtokPrubeh();
        }

        public override void ArtStvoreni() // printik artu postavy skřeta
        {
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.DarkMagenta;
            Thread.Sleep(100);
            WriteLine(@"

            ⠀            //dřevěný panák art");
            Thread.Sleep(2000);
            ResetColor();
            Clear();
        }
    }
    internal class Vetesnice : Stvoreni
    {

        public Vetesnice () // hodnoty base atributů tohoto monstra
        {
            
            zbranStvoreni = Srp_Vetešnice;
            zbrojStvoreni = Tunika_Vetešnice;
            pouzitelnyPredmet = null;
            specialniPredmet = Vlčí_Talisman;
            surovinyStvoreni = Látka;
            sInteligence = 1;
            sSila = 2;
            sObratnost = 1;
            sStesti = 1;
            maManu = false;
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 2 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 1 + hodnotaBrneni;
            sZdravi = 14 + sObrannaHodnota + sSila;
            pocetZlata = 3;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni, specialniPredmet };
            maxZdravi = sZdravi;
            nazevStvoreni = "Vetešnice";
            Bestiar.PridejDoBestiare(this);
            popis = @"'Vetešnice, skvělá prodavačka, držitelka podivného talismanu...
                    
 Jinak bandita jak se patří, nic zvláštního... až na její podezřelý majetek.'";

        }
        protected void BanditaAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("Vetešnice použil asvou speciální schopnost...");
            Thread.Sleep(150);
            WriteLine(@"

                      //schopnost veteš

                                                            ");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void BanditaUtokAnimace()
        {
            Thread.Sleep(150);
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("Vetešnice se připravuje k útoku...");
            Thread.Sleep(150);
            WriteLine(@"                                                                             ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀            // Vetešnice animace útoku.⠀");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void BanditaUtokPrubeh()
        {

            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            kostka.HodKostkou();
            WriteLine();
            Thread.Sleep(250);
            ResetColor();
            poskozeni = sUtocnaHodnota + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.Yellow;

            if (poskozeni >= 6)
            {
                WriteLine("Vetešnice se rozmáchla svým srpem a zasadila poměrně přesnou ránu");
            }
            else
            {
                WriteLine("Vetešnici se jeho výpad srpem moc nepodařil...");
            }

            WriteLine();
            Thread.Sleep(150);
            WriteLine("Výpad srpem způsobil {0} poškození!", poskozeni);
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
            poskozeni = sUtocnaHodnota + sObratnost + sStesti + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("Vetešnice se pokusila o cílený zásah na křehké předměty v inventáři cíle.");
            Thread.Sleep(150);
            WriteLine();
            if (poskozeni >= 9)
            {

                if (DndHerniFunkce._UtokNaSpolecnika == false)
                {

                    if (VasePostava.inventarPostavy.ZiskejPocetPredmetu(3) > 0)
                    {
                        Random r = new Random();
                        var listPouzitych = VasePostava.inventarPostavy.ListInventare().Where(p => p is Pouzitelne && p!= Zlaťák).GroupBy(p => p.ID).Select(l => l.First()).ToList();
                        Pouzitelne vybranyPredmet = (Pouzitelne)listPouzitych[r.Next(0, listPouzitych.Count)];
                        VasePostava.inventarPostavy.OdeberPredmet(vybranyPredmet);
                        WriteLine("Vetešnice Vám svoji mířenou ránou rozbila {0}!", vybranyPredmet.nazevPredmetu);

                    }
                    else
                    {
                        WriteLine("Ve Vašem inventáři se naštěstí pro vás nenachází žádný křehký předmět...");
                    }

                }
                else
                {

                    WriteLine("Váš společník nemá ale v inventáři žádné křehké předměty.");
                    Thread.Sleep(200);
                    WriteLine();
                    WriteLine("Zásah způsobí tedy jen poškození...");


                }

            }
            else
            {
                WriteLine("Zásah se jí ale nepovedl, způsobí tedy jen poškození...");

            }
            poskozeni -= (sStesti + sObratnost);
            WriteLine();
            Thread.Sleep(250);
            WriteLine("Vetešnice jejím mířeným zásahem srpem způsobila {0} poškození!", poskozeni);
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
            BanditaAnimace();
            PrubehSchopnostiStvoreni();
        }

        public override void UtokStvoreni()
        {
            Clear();
            BanditaUtokAnimace();
            BanditaUtokPrubeh();
        }

        public override void ArtStvoreni()
        {
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.Yellow;
            Thread.Sleep(100);
            WriteLine(@"

            ⠀              //Vetešnice art
                                                ");
            Thread.Sleep(2000);
            ResetColor();
            Clear();
        }
    }

}
