using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static System.Console;
using static DnD_Hra.VytvorenePredmety;


namespace DnD_Hra
{
    class Eirlys : Stvoreni
    {

        public Eirlys() // hodnoty base atributů tohoto monstra
        {
            zbranStvoreni = Žádná_Zbraň;
            zbrojStvoreni = Žádná_Zbroj;
            pouzitelnyPredmet = null;
            surovinyStvoreni = null ;
            sInteligence = 5;
            sSila = 3;
            sObratnost = 5;
            sStesti = 6;
            maManu = false;
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 0 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 5 + hodnotaBrneni;
            sZdravi = 40 + sObrannaHodnota + sSila;
            pocetZlata = 0;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;
            nazevStvoreni = "Eirlys";
            Bestiar.PridejDoBestiare(this);
            popis = @"'Eirlys je představitelkou bájných Valkýr.

 Myslel jsem si, že je to jen mýtus, legenda. Vypadá to, že jsem se pletl...' ";

        }
        protected void StraznyAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"{nazevStvoreni} použila svou speciální schopnost...");
            Thread.Sleep(150);
            WriteLine(@"

                      //schopnost eirlys    

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
⠀⠀⠀⠀            // Eirlys ua.⠀");
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
            poskozeni = sStesti + sInteligence + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"{nazevStvoreni} prorazila soupeřovu obranu a oslabila útok...");
            Thread.Sleep(150);
            WriteLine();
           int prurazOH;
           int prurazUH;
            if(poskozeni <= 13)
            {
                prurazOH = (int)(VasePostava._aktualniNepritel.sObrannaHodnota * 0.4);
                prurazUH = (int)(VasePostava._aktualniNepritel.sUtocnaHodnota * 0.4);
            }
            else
            {
                prurazOH = (int)(VasePostava._aktualniNepritel.sObrannaHodnota * 0.6);
                prurazUH = (int)(VasePostava._aktualniNepritel.sUtocnaHodnota * 0.6);
            }
            WriteLine($"Průraz soupeři sebral {prurazOH} obranné hodnoty a oslabení mu sebralo {prurazUH} útočné hodnoty.");
            Thread.Sleep(450);
            WriteLine();
            VasePostava._aktualniNepritel.sObrannaHodnota -= prurazOH;
            VasePostava._aktualniNepritel.sUtocnaHodnota -= prurazUH;
            if (VasePostava._aktualniNepritel.sObrannaHodnota < 0)
                VasePostava._aktualniNepritel.sObrannaHodnota = 0;
            if (VasePostava._aktualniNepritel.sUtocnaHodnota < 0)
                VasePostava._aktualniNepritel.sUtocnaHodnota = 0;
            WriteLine($"{VasePostava._aktualniNepritel.nazevStvoreni} má nyní {VasePostava._aktualniNepritel.sObrannaHodnota} obranné hodnoty a {VasePostava._aktualniNepritel.sUtocnaHodnota} útočné hodnoty.");
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
            poskozeni = sInteligence + sObratnost + sStesti + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"{nazevStvoreni} posílila Vás i ji nebeskou silou...");
            WriteLine();
            Thread.Sleep(450);          
            int prZd = (int)(poskozeni * 0.5);
            int prOH = (int)(poskozeni * 0.2);
            int prU = (int)(poskozeni * 0.3);
            VasePostava.hracovaPostava.vZdravi += prZd;
            if (VasePostava.hracovaPostava.vZdravi > VasePostava.hracovaPostava.zdraviPostavy)
                VasePostava.hracovaPostava.vZdravi = VasePostava.hracovaPostava.zdraviPostavy;            
            VasePostava.hracovaPostava.vUtocnaHodnota += prU;
            sUtocnaHodnota += prU;
            sZdravi += prZd;
            if (sZdravi > maxZdravi)
                sZdravi = maxZdravi;
            if (poskozeni <=19)
            {
                WriteLine($"{nazevStvoreni} vám oběma vyléčí zdraví, pokud vám nějaké chybí a přidá vám útočnou hodnotu...");
                Thread.Sleep(350);
                WriteLine();
                WriteLine($"{nazevStvoreni} oběma přidala {prZd} zdraví a {prU} útočné hodnoty!");
                Thread.Sleep(400);
                WriteLine(); 
                WriteLine($"Nyní máte {VasePostava.hracovaPostava.vZdravi} zdraví.");
                WriteLine();
                WriteLine($"Také máte {VasePostava.hracovaPostava.vUtocnaHodnota} útočné hodnoty.");
            }
            else
            {
                VasePostava.hracovaPostava.vObrannaHodnota += prOH;
                sObrannaHodnota += prOH;
                WriteLine($"{nazevStvoreni} vám oběma vyléčí zdraví, pokud vám nějaké chybí a přidá vám obrannou a útočnou hodnotu...");
                Thread.Sleep(350);
                WriteLine();
                WriteLine($"{nazevStvoreni} oběma přidala {prZd} zdraví, {prOH} obranné hodnoty a {prU} útočné hodnoty!");
                Thread.Sleep(400);
                WriteLine();
                WriteLine($"Nyní máte {VasePostava.hracovaPostava.vZdravi} zdraví.");
                WriteLine();
                WriteLine($"Také máte {VasePostava.hracovaPostava.vObrannaHodnota} obranné hodnoty.");
                WriteLine();
                WriteLine($"A nakonec {VasePostava.hracovaPostava.vUtocnaHodnota} útočné hodnoty.");
            }
            poskozeni = 0;
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
            if((VasePostava._aktualniNepritel.sObrannaHodnota < 3 && VasePostava._aktualniNepritel.sUtocnaHodnota < 3) || (VasePostava.hracovaPostava.vZdravi < VasePostava.hracovaPostava.zdraviPostavy*0.2))
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
    class KralSkretu : Stvoreni
    {

        public KralSkretu() // hodnoty base atributů tohoto monstra
        {

            zbranStvoreni = Halapartna;
            zbrojStvoreni = Trnová_Useň;
            pouzitelnyPredmet = Lektvar_Síly;
            surovinyStvoreni = Kůže;
            sInteligence = 2;
            sSila = 5;
            sObratnost = 1;
            sStesti = 2;
            maManu = false;
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 4 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 2 + hodnotaBrneni;
            sZdravi = 20 + sObrannaHodnota + sSila;
            pocetZlata = 4;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;
            nazevStvoreni = "Král Skřetů";
            Bestiar.PridejDoBestiare(this);
            popis = @"'Zelená ohavnost, hromada tuku.

 Avšak velice respektovaný vůdce ve skřetí hirearchii a nelítostný bojovník...'";

        }
        protected void StraznyAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine($"{nazevStvoreni} použil svou speciální schopnost...");
            Thread.Sleep(150);
            WriteLine(@"

                      //schopnost KSKR

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
⠀⠀⠀⠀            // KSKR animace útoku.⠀");
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
            WriteLine($"{nazevStvoreni} sekl svou halapartnou...");
            Thread.Sleep(150);
            WriteLine();
            WriteLine("Seknutí způsobilo {0} poškození", poskozeni);
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
            ForegroundColor = ConsoleColor.DarkGreen;
            if (poskozeni >= 7 && poskozeni <= 9)
                PrivolaniPomoci(new SkretBojovnik());
            else if (poskozeni >= 10 && poskozeni <= 12)
                PrivolaniPomoci(new SkretStrelec());
            else if (poskozeni >= 13)
                PrivolaniPomoci(new SkretTravic());
            else            
                WriteLine("Král skřetů se pokusil vyžádat pomoc od ostatních, avšak ho v chaosu nikdo neslyší...");
            
            poskozeni = 0;
            Thread.Sleep(450);
            ResetColor();
            void PrivolaniPomoci(Stvoreni s)
            {
                WriteLine("Král skřetů si vynutil pomoc od svých podřízených...");
                WriteLine();
                Thread.Sleep(250);
                WriteLine($"Na pomoc mu přijde {s.nazevStvoreni}! Po tomto souboji budete bojovat ještě s tímto stvořením...");
                GameplayLokaci_2.KraloviPomocnici.Add(s);
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
            ForegroundColor = ConsoleColor.DarkGreen;
            Thread.Sleep(100);
            WriteLine(@"

            ⠀              //Goblin king stv art
                                                ");
            Thread.Sleep(2000);
            ResetColor();
            Clear();
        }
    }
    class AstralniStrazce : Stvoreni
    {


        public AstralniStrazce() // hodnoty base atributů tohoto monstra
        {

            zbranStvoreni = Žádná_Zbraň;
            zbrojStvoreni = Žádná_Zbroj;
            pouzitelnyPredmet = Prach_Prizracnosti;
            surovinyStvoreni = Temná_Esence;
            specialniPredmet = Teleportacni_Prach;
            sInteligence = 10;
            sSila = 12;
            sObratnost = 10;
            sStesti = 15;
            maManu = false;
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 9 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 5 + hodnotaBrneni;
            sZdravi = 25 + sObrannaHodnota + sSila;
            pocetZlata = 15;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;
            nazevStvoreni = "Astrální Strážce";
            Bestiar.PridejDoBestiare(this);
            popis = @"'Bestie, stráží portál do jiných dimenzí.

 Nesmírně krvelačná a nebezpečná v boji, musím si dávat pozor...'";

        }
        protected void StraznyAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.DarkMagenta;
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
            ForegroundColor = ConsoleColor.DarkMagenta;
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
            ForegroundColor = ConsoleColor.DarkMagenta;
            WriteLine($"{nazevStvoreni} se zakousl svými tesáky...");
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
            poskozeni = (int)((sUtocnaHodnota + kostka.VysledekHodu()) * 0.25);
            ForegroundColor = ConsoleColor.DarkMagenta;
            WriteLine($"{nazevStvoreni} vypustil hustý dým, když se z něj vynořil, vypadá jinak...");
            Thread.Sleep(350);
            WriteLine();
            WriteLine($"{nazevStvoreni} si zvyšuje obrannou a útočnou hodnotu o {poskozeni}, poté si tyto hodnoty vymění.");
            sObrannaHodnota += poskozeni;
            sUtocnaHodnota += poskozeni;
            int temp = sObrannaHodnota;
            sObrannaHodnota = sUtocnaHodnota;
            sUtocnaHodnota = temp;
            Thread.Sleep(250);
            WriteLine();
            WriteLine($"Dým Vám také způsobil {poskozeni}!");
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
            ForegroundColor = ConsoleColor.DarkMagenta;
            Thread.Sleep(100);
            WriteLine(@"

            ⠀              //Valk art stv
                                                ");
            Thread.Sleep(2000);
            ResetColor();
            Clear();
        }
    }
    class CEODabelskeHerny : Stvoreni
    {


        public CEODabelskeHerny() // hodnoty base atributů tohoto monstra
        {

            zbranStvoreni = Palcat_Odporu_Smrti;
            zbrojStvoreni = Žádná_Zbroj;
            pouzitelnyPredmet = Dryak_Sebevzniceni;
            surovinyStvoreni = Ohnivý_Prach;            
            sInteligence = 4;
            sSila = 9;
            sObratnost = 6;
            sStesti = 9;
            maManu = false;
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 7 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 10 + hodnotaBrneni;
            sZdravi = 24 + sObrannaHodnota + sSila;
            pocetZlata = 50;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;
            nazevStvoreni = "CEO Ďábelské Herny";
            Bestiar.PridejDoBestiare(this);
            popis = @"'Komandér celé Ďábelské Herny a také businessman

 Talentovaný v mluvě i akci, nedej bože, aby ho někdo o podnik připravil!...'";

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
            WriteLine($"{nazevStvoreni} zaútočil svým palcátem...");
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
            poskozeni = (int)((sUtocnaHodnota + kostka.VysledekHodu()) * 0.65);

            ForegroundColor = ConsoleColor.DarkRed;
            if(!DndHerniFunkce._UtokNaSpolecnika)
            {


                Past p = new Past(60, VasePostava.hracovaPostava.vSila + VasePostava.hracovaPostava.vObratnost + VasePostava.hracovaPostava.vInteligence + VasePostava.hracovaPostava.vStesti, "kombinaci všech statů", VasePostava.hracovaPostava.vJmeno);
                if(p.Uspech())
                {
                    WriteLine($"{nazevStvoreni} se pokusil zacílit na Vaše slabiny, avšak to nevyšlo.");
                    WriteLine();
                    Thread.Sleep(350);
                    WriteLine($"Útok tedy způsobil jen {poskozeni} poškození.");
                }
                else
                {
                    WriteLine($"{nazevStvoreni} zacílil na Vaše slabiny...");
                    Thread.Sleep(350);
                    WriteLine();
                    int min = Min();
                    VasePostava.hracovaPostava.vSila = min;
                    VasePostava.hracovaPostava.vObratnost = min;
                    VasePostava.hracovaPostava.vInteligence = min;
                    VasePostava.hracovaPostava.vStesti = min;
                    WriteLine($"Jste nejsilnější jako Vás nejslabší stat, jehož hodnota je {min}.");
                    WriteLine();
                    Thread.Sleep(250);
                    WriteLine("Vaše čtyři základní staty tedy teď mají takovou hodnotu...");
                    Thread.Sleep(250);
                    WriteLine();
                    WriteLine($"Útok Vám také způsobil {poskozeni} poškození!");
                }            

            }
            else
            {
                WriteLine($"{nazevStvoreni} drtivě zasahuje Vašeho společníka...");
                WriteLine();
                Thread.Sleep(250);
                poskozeni *= 2;
                WriteLine($"Útok způsobil {poskozeni} poškození.");
            }
            ResetColor();

            //srazeniNS
            int Min()
            {
                int m =Math.Min( Math.Min(VasePostava.hracovaPostava.vSila, VasePostava.hracovaPostava.vObratnost), Math.Min(VasePostava.hracovaPostava.vInteligence, VasePostava.hracovaPostava.vStesti));
                return m;
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

    class Satan : Stvoreni
    {


        public Satan() // hodnoty base atributů tohoto monstra
        {

            zbranStvoreni = Krucifix_Naruby;
            zbrojStvoreni = Žádná_Zbroj;
            pouzitelnyPredmet = Lektvar_Síly;
            surovinyStvoreni = Temná_Esence;
            sInteligence = 8;
            sSila = 20;
            sObratnost = 15;
            sStesti = 15;
            maManu = false;
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 15 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 15 + hodnotaBrneni;
            sZdravi = 35 + sObrannaHodnota + sSila;
            pocetZlata = 400;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;
            nazevStvoreni = "Satan";
            Bestiar.PridejDoBestiare(this);
            popis = @"'Zrůdnost samotná, představa temné síly a všeho špatného.

 Jestli se odtamtud vrátím, bude to zázrak...'";

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
            WriteLine($"{nazevStvoreni} zaútočil svým křížem...");
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
            poskozeni = (int)((sUtocnaHodnota + kostka.VysledekHodu()) * 0.5);

            ForegroundColor = ConsoleColor.DarkRed;
            if (!DndHerniFunkce._UtokNaSpolecnika)
            {
                Random rn = new Random();
                int r = rn.Next(0, 3);
                int maxS = Max();
                int minS = Min();
                if (r == 0)
                {
                    WriteLine($"{nazevStvoreni} oceňuje Vaše bojové schopnosti.");
                    WriteLine();
                    Thread.Sleep(350);
                    WriteLine($"Bere si Váš nejsilnější stat a přiřazuje ho všem jeho statům ze základní čtyřky, které jsou menší než ty Vaše...");
                    WriteLine();
                    Thread.Sleep(250);
                    WriteLine($"Hodnota Vašeho nejvyššího statu je {maxS}...");
                    if (sSila < maxS)
                        sSila = maxS;
                    if (sObratnost < maxS)
                        sObratnost = maxS;
                    if (sInteligence < maxS)
                        sInteligence = maxS;
                    if (sStesti < maxS)
                        sStesti = maxS;
                    WriteLine();
                    Thread.Sleep(150);
                    WriteLine($"{nazevStvoreni} Vám také způsobil {poskozeni} poškození!");
                }
                else if(r == 1)
                {
                    WriteLine($"{nazevStvoreni} je překvapen Vašimi slabinami...");
                    Thread.Sleep(350);
                    WriteLine();                 
                    VasePostava.hracovaPostava.vSila = minS;
                    VasePostava.hracovaPostava.vObratnost = minS;
                    VasePostava.hracovaPostava.vInteligence = minS;
                    VasePostava.hracovaPostava.vStesti = minS;
                    WriteLine($"Všechny Vaše staty jsou nyní rovny nejslabšímu statu.");
                    WriteLine();
                    Thread.Sleep(250);
                    WriteLine($"Vaše čtyři základní staty jsou teď {minS}...");
                    Thread.Sleep(250);
                    WriteLine();
                    poskozeni = minS;
                    if (poskozeni < 0)
                        poskozeni = 0;
                    WriteLine($"Útok Vám také způsobil {minS} poškození!");
                }
                else
                {
                    WriteLine($"{nazevStvoreni}, spojen se smrtí, Vás doucuje balancovat na prahu smrti...");
                    Thread.Sleep(350);
                    WriteLine();                    
                    WriteLine($"Způsobuje Vám poškození ve výši třetiny Vašich životů...");
                    WriteLine();
                    Thread.Sleep(250);
                    poskozeni = VasePostava.hracovaPostava.zdraviPostavy / 3;
                    Thread.Sleep(250);
                    WriteLine();                   
                    WriteLine($"Útok Vám způsobil {poskozeni} poškození!");
                }

            }
            else
            {
                WriteLine($"{nazevStvoreni} temnou silou předvědčil Vašeho společníka k sabotáži...");
                Thread.Sleep(250);
                WriteLine();
                WriteLine("Způsobuje Vám tak poškození vzhledem k jeho zdraví. Také ho donucuje se zneškodnit.");
                poskozeni = VasePostava.spolecnik.sZdravi;
                VasePostava.spolecnik.sZdravi = 0;
                WriteLine();
                Thread.Sleep(150);
                Thread.Sleep(350);
                int dmgHraci = poskozeni - VasePostava.hracovaPostava.vObrannaHodnota;
                if (dmgHraci < 0)
                    dmgHraci = 0;
                VasePostava.hracovaPostava.vZdravi -= dmgHraci;
                WriteLine($"Je Vám tak způsobeno {dmgHraci} poškození, v čemž je započtená obranná hodnota, a Váš společník umírá...");
                WriteLine();
            }
            ResetColor();

            //srazeniNS
            int Min()
            {
                int m = Math.Min(Math.Min(VasePostava.hracovaPostava.vSila, VasePostava.hracovaPostava.vObratnost), Math.Min(VasePostava.hracovaPostava.vInteligence, VasePostava.hracovaPostava.vStesti));
                return m;
            }
            int Max()
            {
                int m = Math.Max(Math.Max(VasePostava.hracovaPostava.vSila, VasePostava.hracovaPostava.vObratnost), Math.Max(VasePostava.hracovaPostava.vInteligence, VasePostava.hracovaPostava.vStesti));
                return m;
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

    class DratanJednouSeSvetlem : Stvoreni
    {
        Random rand = new Random();
        private int pocetAkci;
        private bool sezZbran;
        public DratanJednouSeSvetlem(int divizeFaktor) // hodnoty base atributů tohoto monstra
        {

            sezZbran = false;
            pocetAkci = 0;
            zbranStvoreni = Žádná_Zbraň;
            zbrojStvoreni = Žádná_Zbroj;
            pouzitelnyPredmet = null;
            surovinyStvoreni = null;
            specialniPredmet = divizeFaktor == 1 ? Baňka_Sběratele_Duší : null;
            sInteligence = 50;
            sSila = 40;
            sObratnost = 40;
            sStesti = 40;
            maManu = false;
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 20 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 20 + hodnotaBrneni;
            sZdravi = 140 + sObrannaHodnota + sSila;
            sSila /= divizeFaktor;
            sObratnost /= divizeFaktor;
            sInteligence /= divizeFaktor;
            sStesti /= divizeFaktor;
            sObrannaHodnota /= divizeFaktor;
            sUtocnaHodnota /= divizeFaktor;
            sZdravi /= divizeFaktor;
            pocetZlata = 0;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;           
            nazevStvoreni = "Dratan, jednou se Světlem";
            Bestiar.PridejDoBestiare(this);
            popis = @"'Důvod proč jsem se vydal na tuto výpravu, drží část duší mých blízkých.

 Hodlám ho zabít a skončit prokletí jednou pro vždy. Je mi jedno, jak dlouho to bude trvat'";

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
            pocetAkci++;
            if (specialniPredmet == Baňka_Sběratele_Duší)
                pocetAkci = 0;
            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            kostka.HodKostkou();
            WriteLine();
            Thread.Sleep(250);
            ResetColor();
            poskozeni = sUtocnaHodnota + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine($"{nazevStvoreni} zaútočil temnou silou...");
            WriteLine();
            int random = rand.Next(0, 3);
            if(!DndHerniFunkce._UtokNaSpolecnika)
            {
                if(random == 0 && pocetAkci < 8)
                {
                    if(!sezZbran)
                    {
                        sezZbran = true;
                        WriteLine($"Temná síla proléva každý kout Vašeho vybavení, sžírajíc Vám zbraň a zbroj...");
                        WriteLine();
                        Thread.Sleep(250);
                        WriteLine("Poškození Vaší zbraně a hodnota brnění Vaší zbroje byla snížena na 1.");
                        WriteLine();
                        Thread.Sleep(250);
                        WriteLine("Veškeré bojové bonusy, případně postihy, byly odebrány.");
                        VasePostava.zbranPostavy.poskozeniZbrane =1;
                        if (VasePostava.alternativniZbranPostavy != null)
                            VasePostava.alternativniZbranPostavy.poskozeniZbrane =1;
                        VasePostava.hracovaPostava.RekonfiguraceUH();
                        VasePostava.hracovaPostava.RekonfiguraceAltUH();
                        VasePostava.zbrojPostavy.hodnotaBrneni = 1;
                        VasePostava.hracovaPostava.RekonfiguraceOH();
                    }
                    else
                    {
                        WriteLine($"Temná síla se Vám dostává do hlavy, ovlivňujíce způsob, kterým bojujete...");
                        WriteLine();
                        Thread.Sleep(250);
                        WriteLine("Vaše útočná a obranná hodnota byli sníženy o část knězova poškození.");
                        WriteLine();
                        Thread.Sleep(250);
                        WriteLine($"{nazevStvoreni} snížil Vaše bojové atributy o {(int)(poskozeni/2.5)} ");
                        VasePostava.hracovaPostava.vUtocnaHodnota -= (int)(poskozeni / 2.5);
                        VasePostava.hracovaPostava.vObrannaHodnota -= (int)(poskozeni / 2.5);
                    }
                }
                else if(random == 1 && pocetAkci < 8)
                {
                    WriteLine($"Temná síla Vás ovlivňuje, zjišťuje Vaše přednosti a slabiny...");
                    WriteLine();
                    Thread.Sleep(250);
                    WriteLine("Váš nejslinější stat byl sražen na polovinu.");
                    WriteLine();
                    Thread.Sleep(300);
                    WriteLine("Poté, Váš nový nejsilněší stat je sražen na hodnotu toho nejslabšího...");
                    NejsilnejsiStatRef() /= 2;
                    NejsilnejsiStatRef() = NejslabsiStatRef();
                }
                else if(random == 2 && pocetAkci <8)
                {
                    WriteLine($"Temná síla posiluje bývalého kněze, stabilizuje jeho atributy...");
                    WriteLine();
                    Thread.Sleep(250);
                    WriteLine("Pokud je nějaký atribut ze základní čtyřky pod hranicí 25, temná magie dorovná rozdíl.");
                    if (sSila < 25)
                        sSila = 25;
                    if (sObratnost < 25)
                        sObratnost = 25;
                    if (sInteligence < 25)
                        sInteligence = 25;
                    if (sStesti < 25)
                        sStesti = 25;
                }
                else if(pocetAkci >=8)
                {
                    WriteLine($"{nazevStvoreni} Vás vychytal ve slabé chvíli, způsobujíce kritický zásah.");
                    WriteLine();
                    poskozeni =(int)(VasePostava.hracovaPostava.zdraviPostavy*0.5);
                }
                Thread.Sleep(150);
                WriteLine();
                WriteLine("Útok také způsobil {0} poškození!", poskozeni);        

            }
            else
            {
                WriteLine($"{nazevStvoreni} okamžitě očarováva Vašeho společníka, poštvávajíce ho proti Vám.");
                Thread.Sleep(250);
                WriteLine();
                WriteLine($"Je Vám způsobeno poškození rovno čytřem základním statům společníka, plus jeho zdraví.");
                poskozeni = VasePostava.spolecnik.sSila + VasePostava.spolecnik.sObratnost + VasePostava.spolecnik.sInteligence + VasePostava.spolecnik.sStesti
                    + VasePostava.spolecnik.sZdravi;
                poskozeni -= VasePostava.hracovaPostava.vObrannaHodnota;
                WriteLine($"Po započtení obranné hodnoty je Vám způsobeno {poskozeni} poškození a Váš společník krutě zemřel.");
                VasePostava.spolecnik.sZdravi = 0;
            }
            Thread.Sleep(300);
            ResetColor();
            
            ref int NejsilnejsiStatRef()
            {
                int nejvyssiStat = Max();
                if (VasePostava.hracovaPostava.vObratnost == nejvyssiStat)
                    return ref VasePostava.hracovaPostava.vObratnost;
                else if (VasePostava.hracovaPostava.vStesti == nejvyssiStat)
                    return ref VasePostava.hracovaPostava.vStesti;
                else if (VasePostava.hracovaPostava.vSila == nejvyssiStat)
                    return ref VasePostava.hracovaPostava.vSila;
                else if (VasePostava.hracovaPostava.vInteligence == nejvyssiStat)
                    return ref VasePostava.hracovaPostava.vInteligence;
                else throw new Exception("žádný ze statů u dratana v abilitce se nerovná nejvyššímu statu");
            }
            ref int NejslabsiStatRef()
            {
                int nejnizsiStat = Min();
                if (VasePostava.hracovaPostava.vObratnost == nejnizsiStat)
                    return ref  VasePostava.hracovaPostava.vObratnost;
                else if (VasePostava.hracovaPostava.vStesti == nejnizsiStat)
                    return ref VasePostava.hracovaPostava.vStesti;
                else if (VasePostava.hracovaPostava.vSila == nejnizsiStat)
                    return ref VasePostava.hracovaPostava.vSila;
                else if (VasePostava.hracovaPostava.vInteligence == nejnizsiStat)
                    return ref VasePostava.hracovaPostava.vInteligence;
                else throw new Exception("žádný ze statů u dratana v abilitce se nerovná nejvnižšímu statu");
            }
            int Min()
            {
                int m = Math.Min(Math.Min(VasePostava.hracovaPostava.vSila, VasePostava.hracovaPostava.vObratnost), Math.Min(VasePostava.hracovaPostava.vInteligence, VasePostava.hracovaPostava.vStesti));
                return m;
            }
            int Max()
            {
                int m = Math.Max(Math.Max(VasePostava.hracovaPostava.vSila, VasePostava.hracovaPostava.vObratnost), Math.Max(VasePostava.hracovaPostava.vInteligence, VasePostava.hracovaPostava.vStesti));
                return m;
            }
        }

        private void PrubehSchopnostiStvoreni() // to, co se stane při speciální schopnosti
        {
            pocetAkci++;
            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            kostka.HodKostkou();
            WriteLine();
            Thread.Sleep(250);
            ResetColor();
            poskozeni = sUtocnaHodnota + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine($"{nazevStvoreni} začal kouzli, využívajíc temnou sílu k jeho prospěchu...");
            WriteLine();
            int random = rand.Next(0, 2);
            if(!DndHerniFunkce._UtokNaSpolecnika)
            {

                if(PodPulHp())
                {
                    WriteLine($"{nazevStvoreni} poznává, že je v nebezpečí, léčí se tedy temnou magií.");
                    WriteLine();
                    Thread.Sleep(250);
                    WriteLine($"Léčení je ekvivalentní poškození, tedy {poskozeni}...");
                    sZdravi += poskozeni;
                    if (sZdravi > maxZdravi)
                        sZdravi = maxZdravi;
                }
                else if(random == 0 && !PodPulHp())
                {
                    WriteLine($"{nazevStvoreni} je posílen temnou magií, zvyšúje si tak své bojové atributy.");
                    WriteLine();
                    Thread.Sleep(250);
                    WriteLine($"Zvyšuje si útočnou a obrannou hodnotu o {poskozeni/2}...");
                    sObrannaHodnota += poskozeni / 2;
                    sUtocnaHodnota += poskozeni / 2;               
                }
                else if (random == 1 && !PodPulHp())
                {
                    WriteLine($"{nazevStvoreni} očarovává své smysli temnou magií");
                    WriteLine();
                    Thread.Sleep(250);
                    WriteLine($"Zvyšuje si tak základní čtyřku jeho atributů o {(int)(poskozeni / 2.5)}...");
                    sSila += (int)(poskozeni / 2.5);
                    sObratnost += (int)(poskozeni / 2.5);
                    sInteligence += (int)(poskozeni / 2.5);
                    sStesti += (int)(poskozeni / 2.5);
                }
                WriteLine();
                WriteLine($"Magie také způsobila {poskozeni} poškození!");
            }
            else
            {
                WriteLine($"{nazevStvoreni} okamžitě očarováva Vašeho společníka, poštvávajíce ho proti Vám.");
                Thread.Sleep(250);
                WriteLine();
                WriteLine($"Je Vám způsobeno poškození rovno čytřem základním statům společníka, plus jeho zdraví.");
                poskozeni = VasePostava.spolecnik.sSila + VasePostava.spolecnik.sObratnost + VasePostava.spolecnik.sInteligence + VasePostava.spolecnik.sStesti
                    + VasePostava.spolecnik.sZdravi;
                poskozeni -= VasePostava.hracovaPostava.vObrannaHodnota;
                WriteLine($"Po započtení obranné hodnoty je Vám způsobeno {poskozeni} poškození a Váš společník krutě zemřel.");
                VasePostava.spolecnik.sZdravi = 0;
            }
            ResetColor();
            Thread.Sleep(200);
            bool PodPulHp()
            {
                if (sZdravi <= (int)maxZdravi * 0.5)
                    return true;
                else return false;
            }
            //srazeniNS
            
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
