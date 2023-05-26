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
    internal class UctivacDabla : Stvoreni //SKŘET travič
    {
      static  Random rnd = new Random();
        private bool _krvaci;
        private int _krvaceniDamage;
       int ra = rnd.Next(0, 2);
        public UctivacDabla() // hodnoty base atributů tohoto monstra
        {
            zbranStvoreni = Prokletá_Čepel;
            zbrojStvoreni = Trnová_Useň;
            pouzitelnyPredmet = ra == 0?Lektvar_Neskodnosti:Lektvar_Obrance;
            surovinyStvoreni = VytvorenePredmety.Houba_Bodavka;
            sInteligence = 6;
            sSila = 9;
            sObratnost = 8;
            sStesti = 6;
            maManu = false;
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 5 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 11 + hodnotaBrneni;
            sZdravi = 25 + sObrannaHodnota + sSila;
            pocetZlata = 20;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;
            nazevStvoreni = "Uctívač Ďábla";
            _krvaceniDamage = 8;
            popis = @"'Blázen a šílenec, také masochista. Uctívá Ďábla a to je jeho náplň života.

 Je zvyklý na muka, čím méně zdraví má, tím nebezpečnější může být. Také způsobuje krvácení.'";
            Bestiar.PridejDoBestiare(this);

        }
        void PrubehOtravy()
        {
            if (_krvaci == true)
            {
                WriteLine();
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Vaše postava je postižena krvácením, je Vám tedy způsobeno {0} poškození...", _krvaceniDamage);
                if (VasePostava.spolecnik != null)
                {
                    Thread.Sleep(150);
                    WriteLine();
                    WriteLine("Váš společník krvácí také, proto obdrží {0} poškození...", _krvaceniDamage);

                }
                VasePostava.hracovaPostava.vZdravi -= _krvaceniDamage;
                if (VasePostava.hracovaPostava.vZdravi < 0)
                    VasePostava.hracovaPostava.vZdravi = 0;
                WriteLine();
                Thread.Sleep(300);
                WriteLine("Nyní má {1} {0} zdraví.", VasePostava.hracovaPostava.vZdravi, VasePostava.hracovaPostava.vJmeno);
                if (VasePostava.spolecnik != null)
                {
                    VasePostava.spolecnik.sZdravi -= _krvaceniDamage;
                    if (VasePostava.spolecnik.sZdravi < 0)
                        VasePostava.spolecnik.sZdravi = 0;
                    Thread.Sleep(150);
                    WriteLine();
                    WriteLine("A Váš společník {0} zdraví...", VasePostava.spolecnik.sZdravi);
                }
                ResetColor();
                Thread.Sleep(250);
                WriteLine();
                WriteLine("stiskněte libovolné tlačítko pro pokračování...");
                ReadKey(true);
                Clear();
            }

        }
        protected void SkretAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine($"{nazevStvoreni} použil svou speciální schopnost...");
            Thread.Sleep(150);
            WriteLine(@"

                      //schopnost skřeta traviče

                                                            ");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void SkretUtokAnimace()
        {
            Thread.Sleep(150);
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine($"{nazevStvoreni} se připravuje k útoku...");
            Thread.Sleep(150);
            WriteLine(@"                                                                             ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀            // skřet travič animace útoku.⠀");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void SkretUtokPrubeh()
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
            WriteLine($"{nazevStvoreni} sekl svou čepelí a trefil se přesně...");                      
            WriteLine();
            Thread.Sleep(250);
            WriteLine($"{nazevStvoreni} si navíc ubírá 2 zdraví a přidává 1 k obranné hodnotě...");
            WriteLine();
            Thread.Sleep(150);
            WriteLine("Sek způsobil {0} poškození!", poskozeni);
            sObrannaHodnota += 1;
            sZdravi -= 2;
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

            if (sObrannaHodnota >= 12)
            {
                WriteLine($"{nazevStvoreni} provedl točitý sek, způsobujíc všem v dosahu krvácení...");
                WriteLine();
                Thread.Sleep(250);
                if (_krvaci == false)
                {
                    WriteLine("Odteď krvácíte, při každé další akci Uctívače Vám bude způsobováno {0} poškození.", _krvaceniDamage);
                    _krvaci = true;
                    poskozeni = 0;
                }
                else
                {
                    _krvaceniDamage += (maxZdravi-sZdravi)/2;
                    WriteLine("Už krvácíte, vážnost postihu se tedy zvyšuje, krvácení nyní způsobuje {0} poškození", _krvaceniDamage);
                    WriteLine();
                    poskozeni = 0;
                    Thread.Sleep(150);
                    WriteLine("Útok prozatím způsobil 0 poškození...");
                    poskozeni = 0;
                }

            }
            else
            {
                int pridaniOH = (int)(poskozeni * 0.33);
                WriteLine($"{nazevStvoreni} před sebou vytvořil plamennou bariéru, spalujíc nepřítele v procesu...");
                Thread.Sleep(250);
                WriteLine();
                WriteLine($"{nazevStvoreni} si přidal {pridaniOH} obranné hodnoty a způsobil {poskozeni} poškození.");
                sObrannaHodnota += pridaniOH;
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
            PrubehOtravy();
            SkretAnimace();
            PrubehSchopnostiStvoreni();
        }

        public override void UtokStvoreni()
        {
            Clear();
            PrubehOtravy();
            SkretUtokAnimace();
            SkretUtokPrubeh();
        }

        public override void ArtStvoreni() // printik artu postavy skřeta
        {
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.DarkGreen;
            Thread.Sleep(100);
            WriteLine(@"

            ⠀              //skřet travič art
                                                ");
            Thread.Sleep(2000);
            ResetColor();
            Clear();
        }
    }
    internal class Strach : Stvoreni //SKŘET travič
    {
        Random re = new Random();
        bool a0;
        int minHod;
        public Strach() // hodnoty base atributů tohoto monstra
        {
            minHod = 25;
            a0 = false;           
            zbranStvoreni = Žádná_Zbraň;
            zbrojStvoreni = Žádná_Zbroj;
            pouzitelnyPredmet = null;
            surovinyStvoreni = Temná_Esence;
            sInteligence = 20;
            sSila = 2;
            sObratnost = 25;
            sStesti = 0;
            maManu = false;
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 0 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 6 + hodnotaBrneni;
            sZdravi = 30 + sObrannaHodnota + sSila;
            pocetZlata = 0;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;
            nazevStvoreni = "Strach";           
            popis = @"'Co když moje vybavení náhle přestane fungovat, zbraň se otupí a zbroj zrezne?

 Co když posilující Lektvary, na které spoléhám, náhle zmizí? 
 
 Co když moje bohatství z ničeho nic bude ukradeno?'";
            Bestiar.PridejDoBestiare(this);

        }        
        protected void SkretAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine($"{nazevStvoreni} se vás snaží dostat...");
            Thread.Sleep(150);
            WriteLine(@"

                      //schopnost skřeta traviče

                                                            ");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void SkretUtokAnimace()
        {
            Thread.Sleep(150);
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine($"{nazevStvoreni} útočí na Vaši racionalitu...");
            Thread.Sleep(150);
            WriteLine(@"                                                                             ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀            // skřet travič animace útoku.⠀");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void SkretUtokPrubeh()
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
            int ran = re.Next(0, 2);
            if(_UtokNaSpolecnika)
            {
                WriteLine("Strach se odvrátil od Vašeho společníka a věnuje se raději Vám...");
                GameplayLokaci_1.Tlacitko();
            }
            Past past = new Past(minHod, VasePostava.hracovaPostava.vInteligence, "inteligenci", VasePostava.hracovaPostava.vJmeno);
            ForegroundColor = ConsoleColor.DarkGreen;
            if (past.Uspech())
            {
                minHod += 3;
                WriteLine($"{nazevStvoreni} Vás tentokrát nedostal, dobrá práce...");
            }
            else
            {
                if(ran == 0 && !a0)
                {
                    a0 = true;
                    WriteLine($"{nazevStvoreni} Vás dostal...");
                    Thread.Sleep(250);
                    WriteLine();
                    WriteLine($"Co když má výzbroj není dostatečně dobrá?");
                    Thread.Sleep(250);
                    WriteLine();
                    WriteLine("Poškození hlavní zbraně a hodnota brnění zbroje je 1...");
                    WriteLine();
                    Thread.Sleep(250);
                    WriteLine("Pokud jsem měl nějaké bojové bonusy, také jsou pryč...");
                    VasePostava.zbranPostavy.poskozeniZbrane = 1;
                    VasePostava.zbrojPostavy.hodnotaBrneni = 1;
                    VasePostava.hracovaPostava.RekonfiguraceOH();
                    VasePostava.hracovaPostava.RekonfiguraceUH();
                }
                else if(ran == 1 || a0)
                {
                    if (VasePostava.inventarPostavy.ZiskejPocetPredmetu(3) > 0)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (VasePostava.inventarPostavy.ZiskejPocetPredmetu(3) == 0)
                                return;
                            Random r = new Random();
                            var listPouzitych = VasePostava.inventarPostavy.ListInventare().Where(p => p is Pouzitelne && p != VytvorenePredmety.Zlaťák).GroupBy(p => p.ID).Select(l => l.First()).ToList();
                            Pouzitelne vybranyPredmet = (Pouzitelne)listPouzitych[r.Next(0, listPouzitych.Count)];
                            VasePostava.inventarPostavy.OdeberPredmet(vybranyPredmet);
                            if (i == 0)
                                WriteLine("Ale ne, ztratil se mi {0}!", vybranyPredmet.nazevPredmetu);
                            else if (i == 1)
                                WriteLine("Také u sebe už nemám {0}...", vybranyPredmet.nazevPredmetu);
                            else
                                WriteLine("Dokonce nevidím ani {0}...", vybranyPredmet.nazevPredmetu);
                            WriteLine();
                        }
                    }
                    else
                    {
                        WriteLine("Lekl jsem se, že jsem ztratil pár lektvarů, ale vše je v pořádku, žádné jsem neměl v první řadě!");
                    }
                }
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
            poskozeni = sSila + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.DarkGreen;
            if (_UtokNaSpolecnika)
            {
                WriteLine("Strach se odvrátil od Vašeho společníka a věnuje se raději Vám...");
                GameplayLokaci_1.Tlacitko();
            }
            Past past = new Past(minHod, VasePostava.hracovaPostava.vInteligence, "inteligenci", VasePostava.hracovaPostava.vJmeno);
            ForegroundColor = ConsoleColor.DarkGreen;
            if(past.Uspech())
            {
                minHod += 3;
                WriteLine($"{nazevStvoreni} se Vám podařilo odvrátit...");
            }
            else
            {
                int odebraneZL = VasePostava.inventarPostavy.PocetZlata() / 3;
                WriteLine("Co když ztratím bohatství, které u sebe nesu?");
                WriteLine();
                Thread.Sleep(250);
                WriteLine("A třetina zlata je pryč...");
                Inventar.OdeberZlato(odebraneZL, VasePostava.inventarPostavy);
            }
            Thread.Sleep(450);
            ResetColor();
            poskozeni = 0;
        }
        public override int PoskozeniStvoreni() // vracíme hodnotu speciální schopnosti
        {
            return poskozeni;
        }

        public override void SchopnostStvoreni() // už celá funkce, která provede schopnost se vším všudy
        {
            Clear();          
            SkretAnimace();
            PrubehSchopnostiStvoreni();
        }

        public override void UtokStvoreni()
        {
            Clear();           
            SkretUtokAnimace();
            SkretUtokPrubeh();
        }

        public override void ArtStvoreni() // printik artu postavy skřeta
        {
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.DarkGreen;
            Thread.Sleep(100);
            WriteLine(@"

            ⠀              //skřet travič art
                                                ");
            Thread.Sleep(2000);
            ResetColor();
            Clear();
        }
    }
}
