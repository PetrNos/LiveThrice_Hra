using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static System.Console;
using static DnD_Hra.VytvorenePredmety;

namespace DnD_Hra
{
    internal class NajemnyZabijak : Stvoreni
    {

        public NajemnyZabijak() // hodnoty base atributů tohoto monstra
        {
            zbranStvoreni = Dýka;
            zbrojStvoreni = Látková_Zbroj;
            pouzitelnyPredmet = Jed;
            surovinyStvoreni = Houba_Bodavka;
            sInteligence = 1;
            sSila = 1;
            sObratnost = 2;
            sStesti = 1;
            maManu = false;
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 2 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 0 + hodnotaBrneni;
            sZdravi = 15 + sObrannaHodnota + sSila;
            pocetZlata = 2;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;
            nazevStvoreni = "Nájemný zabiják";
            Bestiar.PridejDoBestiare(this);
            popis = @"'Zvláštní to člověk. Zabiják a v tomhle městě...
                    
 V souboji nebyl tak špatný, ale nechápu kde se tu vzal. Nebo spíš kdo měl potřebu si ho najmout.'";

        }
        protected void ZabijakAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Magenta;
            WriteLine("Nájemný zabiják použil svou speciální schopnost...");
            Thread.Sleep(150);
            WriteLine(@"

                      //schopnost zabijaka

                                                            ");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void ZabijakUtokAnimace()
        {
            Thread.Sleep(150);
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.Magenta;
            WriteLine("Nájemný zabiják se připravuje k útoku...");
            Thread.Sleep(150);
            WriteLine(@"                                                                             ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀            // zabijka animace útoku.⠀");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void ZabijakUtokPrubeh()
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

            if (poskozeni >= 5)
            {
                WriteLine("Zabiják šikovně bodl svou dýkou...");
            }
            else
            {
                WriteLine("Zabiják se pokusil o výpad jeho dýkou...");
            }

            WriteLine();
            Thread.Sleep(150);
            WriteLine("Bod dýkou způsobil {0} poškození!", poskozeni);
            Thread.Sleep(450);
            ResetColor();

        }

        private void PrubehSchopnostiStvoreni() // to, co se stane při speciální schopnosti
        {
            
            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            kostka.HodCinknutouKostkou();
            WriteLine();
            Thread.Sleep(250);
            ResetColor();
            poskozeni = sUtocnaHodnota + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.Magenta;           
            WriteLine("Zabiják využil příležitosti pro zákeřný zásah dýkou...");            
            WriteLine();
            Thread.Sleep(150);
            WriteLine("Zákeřný zásah dýkou způsobil {0} poškození!", poskozeni);
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
            ZabijakAnimace();
            PrubehSchopnostiStvoreni();
        }

        public override void UtokStvoreni()
        {
            Clear();
            ZabijakUtokAnimace();
            ZabijakUtokPrubeh();
        }

        public override void ArtStvoreni()
        {
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.Magenta;
            Thread.Sleep(100);
            WriteLine(@"

            ⠀              //bandita art
                                                ");
            Thread.Sleep(2000);
            ResetColor();
            Clear();
        }
    }
    class Strazny : Stvoreni
    {
        int random;

        public Strazny() // hodnoty base atributů tohoto monstra
        {
            random = new Random().Next(0, 2);
            zbranStvoreni = Meč;
            zbrojStvoreni = Kožená_Zbroj;
            pouzitelnyPredmet = null;
            surovinyStvoreni = random == 0?Kůže:Železný_Ingot;
            sInteligence = 1;
            sSila = 2;
            sObratnost = 1;
            sStesti = 0;
            maManu = false;
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 2 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 1 + hodnotaBrneni;
            sZdravi = 13 + sObrannaHodnota + sSila;
            pocetZlata = 1;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;
            nazevStvoreni = "Strážný";
            Bestiar.PridejDoBestiare(this);
            popis = @"'Tihle nejsou moc chytří. Vlastně jsou občas i podlí...
                    
 Jde jim většinou jen o peníze, medovinu a o to, co se říká. Často bývají i líní.

 V souboji nejsou špatní. Musí se jim nechat, že když je potřeba město chránit, chrání.'";

        }
        protected void StraznyAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("Strážný použil svou speciální schopnost...");
            Thread.Sleep(150);
            WriteLine(@"

                      //schopnost strazneho

                                                            ");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void StraznyUtokAnimace()
        {
            Thread.Sleep(150);
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("Strážný se připravuje k útoku...");
            Thread.Sleep(150);
            WriteLine(@"                                                                             ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀            // strazny animace útoku.⠀");
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
            ForegroundColor = ConsoleColor.Cyan;

            if (poskozeni >= 4)
            {
                WriteLine("Strážný bodl svým mečem...");
            }
            else
            {
                WriteLine("Strážný marně švihl svým mečem...");
            }

            WriteLine();
            Thread.Sleep(150);
            WriteLine("Sek mečem způsobil {0} poškození!", poskozeni);
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
            poskozeni = sUtocnaHodnota + sSila + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.Cyan;

            if (poskozeni >= 7 && poskozeni < 10)
            {
                WriteLine("Strážný zaujmul defenzivní formaci a tak si přidal obrannou hodnotu.");
                Thread.Sleep(150);
                sObrannaHodnota += 1;
                WriteLine();
                WriteLine("Obranná hodnota strážného je nyní {0}.", sObrannaHodnota);
            }
            else if(poskozeni >=10 && poskozeni <14)
            {
                WriteLine("Strážný zaujmul ofenzivní formaci a přidal si tím útočnou hodnotu.");
                Thread.Sleep(150);
                sUtocnaHodnota += 2;
                WriteLine();
                WriteLine("Útočná hodnota strážného je nyní {0}.", sUtocnaHodnota);

            }
            else if(poskozeni >=14)
            {
                WriteLine("Strážný zaujmul multifunkční formaci a přidal si tím útočnou i obrannou hodnotu.");
                Thread.Sleep(150);
                sUtocnaHodnota += 2;
                sObrannaHodnota += 1;
                WriteLine();
                WriteLine("Útočná hodnota strážného je nyní {0}.", sUtocnaHodnota);
                WriteLine();
                Thread.Sleep(300);
                WriteLine("Obranná hodnota poté {0}.", sObrannaHodnota);
            }
            else
            {
                WriteLine("Strážný se pokusil zaujmout jednu z formací, avšak selhal.");
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
            ForegroundColor = ConsoleColor.Cyan;
            Thread.Sleep(100);
            WriteLine(@"

            ⠀              //bandita art
                                                ");
            Thread.Sleep(2000);
            ResetColor();
            Clear();
        }
    }
    class Valkyrie : Stvoreni
    {
             
        public Valkyrie() // hodnoty base atributů tohoto monstra
        {
            
            zbranStvoreni = Meč;
            zbrojStvoreni = Kožená_Zbroj;
            pouzitelnyPredmet = null;
            surovinyStvoreni = null;
            sInteligence = 3;
            sSila = 2;
            sObratnost = 3;
            sStesti = 1;
            maManu = false;            
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 3 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 1 + hodnotaBrneni;
            sZdravi = 13 + sObrannaHodnota + sSila;
            pocetZlata = 0;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;            
            nazevStvoreni = "Valkýrie";
            Bestiar.PridejDoBestiare(this);
            popis = @"'Eirlysiny soudružky, nelítostné v souboji proti zlu.

 Je čest je mít po mém boku, za nebeské posily Eirlys děkuji.'";

        }
        protected void StraznyAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"{nazevStvoreni} použila svou speciální schopnost...");          
            Thread.Sleep(150);
            WriteLine(@"

                      //schopnost Valk

                                                            ");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void StraznyUtokAnimace()
        {
            Thread.Sleep(150);
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"{nazevStvoreni} se připravuje k útoku...");
            Thread.Sleep(150);
            WriteLine(@"                                                                             ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀            // valk animace útoku.⠀");
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
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"{nazevStvoreni} sekla svým mečem...");                     
            Thread.Sleep(150);
            WriteLine();
            WriteLine("Úder mečem způsobil {0} poškození", poskozeni);
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
            ForegroundColor = ConsoleColor.Yellow;
            if(poskozeni > 18)
            {
                WriteLine($"{nazevStvoreni} Vám dobrotivě podala lektvar vzkříšení!");
                Thread.Sleep(350);
                WriteLine();
                WriteLine("Najdete ho ve Vašem inventáři... Smrt Vás nedostihne!");
                VasePostava.inventarPostavy.PridejPredmet(Lektvar_Vzkříšení);
            }
            else if(poskozeni > 5)
            {
                WriteLine($"{nazevStvoreni} Vám dobrotivě podala lektvar síly!");
                Thread.Sleep(350);
                WriteLine();
                WriteLine("Najdete ho ve Vašem inventáři!");
                VasePostava.inventarPostavy.PridejPredmet(Lektvar_Síly);
            }
            else
            {
                WriteLine($"{nazevStvoreni} se Vám pokusila podat lektvar, ale v chaosu souboje jste ho upustili a lektvar se rozlil...");
                Thread.Sleep(350);
                WriteLine();
                WriteLine("Třeba příště!");               
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
            ForegroundColor = ConsoleColor.Yellow;
            Thread.Sleep(100);
            WriteLine(@"

            ⠀              //Valk art stv
                                                ");
            Thread.Sleep(2000);
            ResetColor();
            Clear();
        }
    }
    class Sberac : Stvoreni
    {

        public Sberac() // hodnoty base atributů tohoto monstra
        {

            zbranStvoreni = Žádná_Zbraň;
            zbrojStvoreni = Žádná_Zbroj;
            pouzitelnyPredmet = null;
            surovinyStvoreni = null;
            sInteligence = 4;
            sSila = 2;
            sObratnost = 4;
            sStesti = 4;
            maManu = false;
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 0 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 3 + hodnotaBrneni;
            sZdravi = 25 + sObrannaHodnota + sSila;
            pocetZlata = 0;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;
            nazevStvoreni = "Sběrač";
            Bestiar.PridejDoBestiare(this);
            popis = @"'Jakási entita v kapuci a tmavě šedém plášti.

 Vždy, když mám velký náklad, tak se objeví a začne mi bezlítostně krást věci...'";

        }
        protected void SberacAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine($"{nazevStvoreni} použil svou speciální schopnost...");
            Thread.Sleep(150);
            WriteLine(@"

                      //sběrač art

                                                            ");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void StraznyUtokAnimace()
        {
            throw new NotImplementedException("sběraš nemá animaci útoku");
        }

        private void StraznyUtokPrubeh()
        {

            throw new NotImplementedException("Sběrač neútočí");

        }

        private void PrubehSchopnostiStvoreni() // to, co se stane při speciální schopnosti
        {            
            Thread.Sleep(250);
            ResetColor();
            Past okradeni = new Past(25, VasePostava.hracovaPostava.vObratnost, "obratnost", VasePostava.hracovaPostava.vJmeno);
            if(okradeni.Uspech())
            {
                Clear();
                ForegroundColor = ConsoleColor.DarkYellow;
                WriteLine();
                WriteLine("Sběrač se Vás pokusil okrást, avšak se mu to nepodařilo...");
                WriteLine();
                WriteLine("Opatrně, kolik toho nesete v inventáři...");

            }
            else
            {
                int randomItem;
                Clear();
                ForegroundColor = ConsoleColor.DarkYellow;
                int kolikratBere = new Random().Next(4, 11);
                WriteLine();
                WriteLine($"Sběrač Vám nyní {kolikratBere}x vezme náhodný předmět...");
                GameplayLokaci_1.Tlacitko();
                for(int i =0; i< kolikratBere; i++)
                {
                    ForegroundColor = ConsoleColor.DarkYellow;
                    if (VasePostava.inventarPostavy.ZiskejPocetPredmetu(6) == 0)
                    {
                        WriteLine("Vypadá to, že v inventáři žádný předmět nemáte, Sběrač tedy odchází...");
                        GameplayLokaci_1.Tlacitko();
                        break;
                    }
                    var filtrPredmetu = VasePostava.inventarPostavy.ListInventare().GroupBy(G => G.ID).Select(g => g.First()).ToList();
                   
                    randomItem = new Random().Next(0, filtrPredmetu.Count - 1);
                    Predmety vybranyPredmet = VasePostava.inventarPostavy.ListInventare()[randomItem];               
                    WriteLine();
                    WriteLine("Sběrač Vám vzal předmět {0}.{1}{2}", vybranyPredmet.nazevPredmetu, vybranyPredmet.pocetVylepseniPredmetu > 1 ?$" Tento předmět byl {vybranyPredmet.pocetVylepseniPredmetu}x vylepšen.":"",
                        vybranyPredmet == VasePostava.zbranPostavy || vybranyPredmet == VasePostava.zbrojPostavy || vybranyPredmet == VasePostava.alternativniZbranPostavy?" Tento předmět jste měli vybaveni.":"");
                    if (vybranyPredmet == VasePostava.alternativniZbranPostavy)
                    {
                        VasePostava.alternativniZbranPostavy = Žádná_Zbraň;
                        VasePostava.hracovaPostava.RekonfiguraceAltUH();
                    }
                    if (vybranyPredmet == VasePostava.zbranPostavy)
                    {
                        VasePostava.zbranPostavy = Žádná_Zbraň;
                        VasePostava.hracovaPostava.RekonfiguraceUH();
                    }
                    if (vybranyPredmet == VasePostava.zbrojPostavy)
                    {
                        VasePostava.zbrojPostavy = Žádná_Zbroj;
                        VasePostava.hracovaPostava.RekonfiguraceOH();

                    }
                    VasePostava.inventarPostavy.OdeberPredmet(vybranyPredmet);
                }
                
                
            }
            poskozeni = 0;
            GameplayLokaci_1.Tlacitko();
        }

        public override int PoskozeniStvoreni() // vracíme hodnotu speciální schopnosti
        {
            return poskozeni;
        }

        public override void SchopnostStvoreni() // už celá funkce, která provede schopnost se vším všudy
        {
            Clear();
            SberacAnimace();
            PrubehSchopnostiStvoreni();
        }

        public override void UtokStvoreni()
        {
            throw new NotImplementedException("Nemá full útok sekvenci, sběrač");
        }

        public override void ArtStvoreni()
        {
            throw new NotImplementedException("Sběrač nemá art");
        }
    }   
}
