using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static System.Console;

namespace DnD_Hra
{
    //Main, OhnivyElemental (CARODEJUV), A VSICHNI 3 SKRETI - BOJOVNIK, TRAVIC A STRELEC   
    internal abstract class Stvoreni // kreatury
    {       
        public abstract void SchopnostStvoreni(); // abstraktní funkce, musíme je upravit / doplnit

        public abstract int PoskozeniStvoreni();

        public abstract void UtokStvoreni();
    

        public abstract void ArtStvoreni();
        // metody, jakožto proměnné

        public int pocetZlata { get; set; }
        public Zbrane zbranStvoreni { get; set; }
        public Zbroje zbrojStvoreni { get; set; }

        public List<Predmety> seznamPredmetu;
        public Pouzitelne pouzitelnyPredmet { get; set; }
        public Suroviny surovinyStvoreni { get; set; }     
        public Specialni specialniPredmet { get; set; }
        public int sObratnost { get; set; }
        public int maxZdravi { get; set; }
        public int maxMana { get; set; }

        public int sSila { get; set; }
        public int sInteligence { get; set; }
        public int sStesti { get; set; }
        public int sZdravi { get; set; }
        public int sUtocnaHodnota { get; set; }
        public int sObrannaHodnota { get; set; }
        public int poskozeniZbrane { get; set; }
        public int hodnotaBrneni { get; set; }
        public bool maManu { get; set; }
        public int pocetMany { get; set; }
        public int poskozeni { get; set; }
        public string nazevStvoreni { get; set; }
        public string popis { get; protected set; }
    }

    //----------------------------------------------------------------------------GOBLINI-------------------------------------------------------------------------//
    internal class SkretBojovnik : Stvoreni             //-------------- //SKŘET
    {
        public SkretBojovnik() // hodnoty base atributů tohoto monstra
        {
            zbranStvoreni = VytvorenePredmety.Dýka;
            zbrojStvoreni = VytvorenePredmety.Látková_Zbroj;
            pouzitelnyPredmet = null;
            surovinyStvoreni = null;
            sInteligence = 0;
            sSila = 1;
            sObratnost = 0;
            sStesti = 0;
            maManu = false;
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 1 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 1 + hodnotaBrneni;
            sZdravi = 12 + sObrannaHodnota + sSila;
            pocetZlata = 1;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;
            nazevStvoreni = "Skřet Válečník";
            popis = @"'Nejobyčejnější typ skřeta. Není složitý na poražení.

 Pokud se dobře trefí, dokáže způsobit škody.'";
            Bestiar.PridejDoBestiare(this);
        }
       
       

        protected void SkretAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
           ForegroundColor = ConsoleColor.DarkGreen;
           WriteLine("Skřet Válečník použil svou speciální schopnost...");
            Thread.Sleep(150);
            WriteLine(@"

                                                  .___.
                              /)               ,-^     ^-.
                             //               /           \
                    .-------| |--------------/  __     __  \-------------------.__
                    |WMWMWMW| |>>>>>>>>>>>>> | />>\   />>\ |>>>>>>>>>>>>>>>>>>>>>>:>
                    `-------| |--------------| \__/   \__/ |-------------------'^^
                             \\               \    /|\    /
                              \)               \   \_/   /
                                                |       |
                                                |+H+H+H+|
                                                \       /
                                                 ^-----^

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
            WriteLine("Skřet Válečník se připravuje k útoku...");
            Thread.Sleep(150);
            WriteLine(@"                                                                             ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⡶⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⡜⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀      ⢀⡠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠂⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⡄⢤⢶⣾⡇⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⡐⠀⡇⠀⠀⠀⠀⢠⢄⣀⣀⡨⢂⢁⠀⢐⠉⠀⠀⠀⣿⡀⠆⡀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⡇⢸⠁⠀⠀⠀⠀⣮⠢⣽⣿⠀⠀⠀⠀⠁⠀⡀⠀⢰⣼⡷⢶⡿⠿⢶⣄⢀⣀⣀⢠⣼⣶⣓⢲⠄⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⢸⠀⢸⡆⠀ ⠀⠀⢰⣑⢼⢁⠀⠆⡠⠂⣄⠀⡅⡰⠰⠻⡏⠙⡃⠁⠄⠉⡁⡀⠘⠽⠄⢔⠘⠉⢇⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⢈⠀⠀⡇⠀⠀⠀⠀⠐⢵⡀⣻⢇⡠⡗⡄⣤⠠⢵⠌⠱⡀⠐⢸⣷⣤⠼⣏⢉⠗⠂⢰⣭⡃⠀⣰⠞⠳⡄⠀⠀⠀⠀⠀
⠀⠀⠀⠀⢀⡄⠀⡇⠀⠀⠀⣠⡜⣹⡿⢥⡁⣵⣕⣀⠊⠁⠨⣠⡴⠓⢸⣿⣽⣷⡀⢨⣧⠷⢴⠟⠊⠑⢧⢁⣰⣶⠚⡂⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠁⠀⡇⠀⠀⣀⣝⡺⢻⠍⣲⣧⣓⡇⠈⠉⠉⡉⢢⠄⢀⢀⣆⡷⡃⠓⣾⠋⢆⠀⠀⠀⠀⠈⢺⠁⣾⡿⣟⢀⠀⠀⠀
⠀⠀⠀⠀⠀⡦⠰⢰⠀⠀⢲⣹⢳⠳⠎⣙⡸⣻⣷⡄⠰⣀⢥⠄⠠⠛⣼⠌⡟⠟⡒⡮⠀⠈⠀⢠⡲⡀⠀⠱⡡⡘⠿⡑⠑⡇⠀⠀
⠀⠀⠀⠀⠀⠡⠀⠘⡀⠐⡻⣾⠑⠧⢭⠤⠓⢩⣉⣿⣳⣤⣀⡀⠀⣰⣿⠀⡇⠀⢨⡇⠀⠀⠀⡜⣻⠃⠀⠀⠳⣮⣋⡿⡚⡅⠀⠀
⠀⠀⠀⠀⠀⠀⢂⡄⠃⣾⡆⢶⣷⣿⣼⡄⠀⢀⡶⠿⢟⡿⣯⢿⣿⣽⣫⣡⡏⠀⣜⠙⣦⣀⡼⣌⠇⠀⠀⠀⠀⠈⢿⡟⢼⡄⠀⠀
⠀⠀⠀⠀⠀⠀⢡⢠⠣⠅⠙⢿⡻⠳⢿⡿⣷⡿⣷⡄⣨⡵⠉⠉⢛⠛⠻⣯⡹⠙⠞⠀⡟⣼⣧⣾⠀⠀⠀⠀⠀⠀⢈⣻⡞⠀⠀⠀
⠀⠀⠀⠀⠀⠀⡞⠂⠸⠈⠀⡂⠜⠘⠀⠸⠟⣫⣰⡫⣿⣟⣒⣲⣦⡀⣴⣃⣀⣠⣗⢫⡜⠁⡹⣺⠀⠀⠀⠀⠀⠀⠸⠎⡏⠀⠀⠀
⠀⠀⠀⠀⠀⠀⡗⢳⠀⡇⢢⡇⠀⠀⠰⣷⣠⣷⣛⡯⢱⢋⢄⢺⣭⣊⣠⠟⠋⠉⠁⠀⠀⢀⡵⣗⠀⠀⠀⠀⠀⠀⠀⡀⢹⠀⠀⠀
⠀⠀⠀⠀⠀⢠⠊⣹⡐⢢⢤⡾⠀⠀⠄⠀⢨⠛⡿⡟⠉⠻⠿⠓⣽⣲⡷⡂⢄⣀⢀⡀⢀⡼⠀⠀⠑⢄⠀⠀⠀⠀⠀⠇⡎⠀⠀⠀
⠀⠀⠀⠀⠀⠀⡿⢋⣇⠘⡴⣆⠀⠀⠑⢄⣆⣀⡇⣄⠀⣀⠁⠐⢃⠉⣾⢿⣷⣯⣴⠓⠉⢄⡀⠀⠀⠀⡆⠀⠀⠀⠀⠀⠇⠀⠀⠀
⠀⠀⠀⠀⠀⠀⣇⡖⠜⡖⠃⠀⣷⠀⠀⠀⠊⠿⣦⠍⠻⣭⠤⠈⣌⣀⠙⡍⡫⠹⣟⣷⡆⠀⠐⢄⡀⠘⢱⠀⠀⠀⠀⠈⠈⠀⠀⠀
⠀⠀⠀⠀⠀⠀⢸⢀⡇⢷⠠⣜⣇⠥⠀⠀⠀⠀⠙⡀⠀⠀⠉⠀⢹⡇⠀⢰⠈⡍⢸⠫⠷⣤⣄⠀⠀⠀⠈⠃⠀⠀⠀⢠⡀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⢗⣧⡀⢰⠃⡸⣪⠀⠀⠀⠀⠀⢣⡐⠀⠠⠀⢸⡁⠀⠈⣟⣀⡏⠀⠀⠈⠋⠑⠪⢄⠚⠀⠀⠀⠀⠘⠃⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⣹⢎⡕⠹⡄⠀⠀⠀⠀⠀⡗⡴⠋⢉⠒⢺⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⢾⣵⢃⠀⠀⠀⠀⠀⢹⠕⠁⠀⣀⣛⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠻⠋⠀⠀⠀⠀⠀⠘⢦⠚⠉⠓⠒⢵⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣡⣠⠖⠉⢸⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⠖⠒⠲⠖⣣⣠⢤⣨⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⡀⠀⠀⠀⠀⠈⠑⠤⣮⣭⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠳⡄⠀⠀⠀⠀⠀⠢⣂⠁⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠑⠤⢀⣀⠀⠀⠀⢈⡁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠙⠶⠒⠀");
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
            

            if (poskozeni >= 3)
            {
                WriteLine("Skřet se rozmáchl a udeřil poměrně přesně...");
            }
            else
            {
                WriteLine("Skřetovi se jeho útok moc nepovedl...");
            }

            WriteLine();
            Thread.Sleep(150);
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
            poskozeni = (2 + sUtocnaHodnota) + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.DarkGreen;           
            WriteLine("Skřet se zakousl do svého cíle...");                      
            WriteLine();
            Thread.Sleep(150);
            WriteLine("Kousnutí způsobilo {0} poškození!", poskozeni);

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
            SkretAnimace();
            PrubehSchopnostiStvoreni();
        }

        //**********************************************************************************
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

            ⠀                         ⣰⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                        ⠀⠀⠀⠀⠀⠀⠀⡀⠄⠒⠒⢲⣤⠗⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                        ⠀⠀⠀⠀⠀⠀⡞⠀⠀⠀⡠⠼⠟⣷⡏⠆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                        ⠀⠀⠀⢠⡀⠀⡄⠀⠠⡜⠁⢰⣾⡯⠝⣿⢖⡛⣳⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                        ⣖⠀⠀⠀⢹⣶⣿⣨⠒⠀⣲⠺⡿⡧⣨⣵⡄⢀⣘⢛⣯⣟⡢⢀⠀⠀⠀⠀⠀⠀⠀
                        ⡏⢂⠀⠀⠀⠈⠛⠚⡟⠛⣻⢆⢀⣯⡟⣿⡇⣼⠽⢉⣧⣿⣧⠈⢦⠀⠀⠀⠀⠀⠀
                        ⢓⡈⢅⠀⠀⠀⠀⠀⠈⠁⠚⣿⣏⠹⣥⣽⣿⣿⣶⣻⡏⣿⠹⡆⠈⡄⠀⠀⠀⠀⠀
                        ⠐⡐⡀⠡⠀⠀⠀⠀⠀⠀⢀⣿⢿⠗⠋⡇⡆⣿⣿⠈⢣⢻⠀⡔⢰⡇⠀⠀⠀⠀⠀
                        ⠀⠈⢄⢦⠙⣂⡄⠀⢀⣀⣘⠿⠛⢁⣄⡼⣟⡿⠟⠛⢛⡾⠙⡏⠁⠰⠀⠀⠀⠀⠀
                        ⠀⠀⢀⡷⣄⢈⠛⣻⣍⡭⣵⠦⠭⣾⠿⠛⠉⠀⠀⢀⡞⣵⣤⡤⡜⣴⣄⠀⠀⠀⠀
                        ⠀⢴⡿⣾⣞⠳⢄⢈⣧⣶⣋⠉⠉⢁⠀⢒⣒⣀⠀⢾⣼⣷⠵⡞⢋⣾⣽⣇⡀⠀⠀
                        ⠨⠿⠛⠋⠉⠓⢷⣁⣻⣟⡁⢃⡞⢉⠏⠀⠀⠀⣤⢿⣤⣀⡀⣟⠿⣨⠘⣎⣟⡄⠀
                        ⠀⠀⠀⠀⠀⠀⠈⠒⢿⣵⠶⢥⣱⡮⡀⠀⢀⠔⠙⣿⡇⠀⠁⡇⣩⢱⠶⡓⣽⣇⠀
                        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⠹⢋⡠⣿⣋⠀⠀⢀⣨⠃⠀⠸⢇⢛⡾⣦⣀⣹⣻⣇
                        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢨⡼⣿⣭⣷⢀⢀⣹⢠⠀⠀⣯⣟⠩⠸⡟⢛⢫⠝
                        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠛⠽⣾⡷⠷⠟⠹⡘⠀⠀⠱⣽⡦⢡⡷⡂⡧⠕
                        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢧⡀⠘⠛⠄⠀⠀⠡⡀⢐⠃⢘⣠⡄⠑⣿⣷⣿
                        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣇⠀⠠⣸⠀⠀⠀⠡⠃⠀⢘⢌⠁⠀⠛⢹⡏
                        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠩⡀⠹⡛⠀⠀⠀⠀⠀⠀⠘⠻⠖⠤⠔⢻⠛
                        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣧⣤⡷⠀⠀⠀⠀⠀⠀⠀⠀⢡⠀⠀⡇⠀
                        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠠⣄⠶⡂⠑⠁⠀⢓⠀⠀⠀⠀⠀⠀⠀⠀⠈⡇⠆⣇⠀
                        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠿⣿⢃⡉⡀⡤⠚⠒⠚⠀⠀⠀⠀⠀⠀⠀⠀⢰⢛⠠⠰⠄");
            Thread.Sleep(2000);
            ResetColor();
            Clear();
        }
    }
    //-------------- //SKŘET STŘELEC
    internal class SkretStrelec : Stvoreni           
    {
           
        public SkretStrelec() // hodnoty base atributů tohoto monstra
        {
            zbranStvoreni = VytvorenePredmety.Luk;
            zbrojStvoreni = VytvorenePredmety.Žádná_Zbroj;
            pouzitelnyPredmet = null;
            surovinyStvoreni = VytvorenePredmety.Dřevo;
            sInteligence = 0;
            sSila = 0;
            sObratnost = 2;
            sStesti = 1;
            maManu = false;
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 2 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 0 + hodnotaBrneni;
            sZdravi = 10 + sObrannaHodnota + sSila;
            pocetZlata = 1;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;
            nazevStvoreni = "Skřet Střelec";
            popis = @"'Obratný typ skřeta, který však moc nevydrží

 Jeho paralyzující střely dokážou bát nepříjemné, když se trefí.'";
            Bestiar.PridejDoBestiare(this);

        }        
        protected void SkretAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine("Skřet Střelec použil svou speciální schopnost...");
            Thread.Sleep(150);
            WriteLine(@"

                      //schopnost skřeta střelce

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
            WriteLine("Skřet Střelec se připravuje k útoku...");
            Thread.Sleep(150);
            WriteLine(@"                                                                             ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀            // skřet střelec animace útoku.⠀");
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

            if (poskozeni >= 6)
            {
                WriteLine("Skřet vystřelil ze svého luku a zasadil přesnou ránu...");
            }
            else
            {
                WriteLine("Skřetovi se výstřel z luku moc nepodařil...");
            }

            WriteLine();
            Thread.Sleep(150);
            WriteLine("Šíp způsobil {0} poškození!", poskozeni);
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
            poskozeni = sUtocnaHodnota + sObratnost + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.DarkGreen;

            if (poskozeni >= 8 && poskozeni <=12)
            {
                WriteLine("Skřet zasáhl svůj cíl do slabin oslabujícím zásahem, který dočasně sníží obratnost.");
                WriteLine();
                if(DndHerniFunkce._UtokNaSpolecnika == false)
                {
                    VasePostava.hracovaPostava.vObratnost -= 1;
                    Thread.Sleep(200);
                    WriteLine("Zásah snížil obratnost Vaší postavě o 1. Po zásahu je Vaše obratnost: {0}.", VasePostava.hracovaPostava.vObratnost);
                    
                }
                else
                {
                    VasePostava.spolecnik.sObratnost -= 1;                   
                    Thread.Sleep(200);
                    WriteLine("Zásah snížil obratnost Vašemu společníkovi o 1. Po zásahu je obratnost společníka: {0}.", VasePostava.spolecnik.sObratnost);
                    
                }

            }
            else if(poskozeni > 12)
            {
                WriteLine("Skřet zasáhl svůj cíl do slabin paralizujícím zásahem, který dočasně sníží obratnost a sílu.");
                WriteLine();
                if (DndHerniFunkce._UtokNaSpolecnika == false)
                {
                    VasePostava.hracovaPostava.vObratnost -= 1;
                    VasePostava.hracovaPostava.vSila -= 1;                  
                    Thread.Sleep(200);
                    WriteLine("Zásah snížil obratnost a sílu Vaší postavě o 1. Po zásahu je Vaše obratnost {0}, síla poté {1}.", VasePostava.hracovaPostava.vObratnost, VasePostava.hracovaPostava.vSila);                  
                }
                else
                {
                    VasePostava.spolecnik.sObratnost -= 1;
                    VasePostava.spolecnik.sSila -= 1;
                    if (VasePostava.spolecnik.sObratnost < 0)
                        VasePostava.spolecnik.sObratnost = 0;
                    if (VasePostava.spolecnik.sSila < 0)
                        VasePostava.spolecnik.sSila = 0;
                    Thread.Sleep(200);
                    WriteLine("Zásah snížil obratnost a sílu Vašemu společníkovi o 1. Po zásahu je obratnost společníka {0}, síla poté {1}.", VasePostava.spolecnik.sObratnost, VasePostava.spolecnik.sSila);                  
                }
            }
            else
            {
                WriteLine("Skřet zasáhl svůj cíl dobře mířeným zásahem, který však nemá fatální následky.");                        
                Thread.Sleep(150);
               
            }

            WriteLine();
            WriteLine($"Zásah způsobil {poskozeni} poškození.");
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

            ⠀              //skřet střelec art
                                                ");
            Thread.Sleep(2000);
            ResetColor();
            Clear();
        }
    }
    internal class SkretTravic : Stvoreni //SKŘET travič
    {
        private bool _otraven;
        private int _jedDamage;
        public SkretTravic() // hodnoty base atributů tohoto monstra
        {
            zbranStvoreni = VytvorenePredmety.Dýka;
            zbrojStvoreni = VytvorenePredmety.Železná_Zbroj;
            pouzitelnyPredmet = null;
            surovinyStvoreni = VytvorenePredmety.Houba_Bodavka;
            sInteligence = 2;
            sSila = 0;
            sObratnost = 1;
            sStesti = 0;
            maManu = false;
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 0 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 2 + hodnotaBrneni;
            sZdravi = 15 + sObrannaHodnota + sSila;
            pocetZlata = 2;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };
            maxZdravi = sZdravi;
            nazevStvoreni = "Skřet Travič";
            _jedDamage = 3;
            popis = @"'Skřet, který se vyzná v plynových výbušninách

 Je silnější, než ostatní jeho druhu, také těžší na zabití. Je také chytřejší.'";
            Bestiar.PridejDoBestiare(this);

        }
        void PrubehOtravy()
        {
            if (_otraven == true)
            {
                WriteLine();
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Vaše postava je otrávená plynem od Skřeta Traviče, je Vám tedy způsobeno {0} poškození...", _jedDamage);
                if (VasePostava.spolecnik != null)
                {
                    Thread.Sleep(150);
                    WriteLine();
                    WriteLine("Váš společník je v zoně jedovatého plynu také, proto obdrží {0} poškození...", _jedDamage);

                }
                VasePostava.hracovaPostava.vZdravi -= _jedDamage;
                if (VasePostava.hracovaPostava.vZdravi < 0)
                    VasePostava.hracovaPostava.vZdravi = 0;
                WriteLine();
                Thread.Sleep(300);
                WriteLine("Nyní má {1} {0} zdraví.", VasePostava.hracovaPostava.vZdravi, VasePostava.hracovaPostava.vJmeno);
                if (VasePostava.spolecnik != null)
                {
                    VasePostava.spolecnik.sZdravi -= _jedDamage;
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
            WriteLine("Skřet Travič použil svou speciální schopnost...");
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
            WriteLine("Skřet Travič se připravuje k útoku...");
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

            if (poskozeni >= 3)
            {
                WriteLine("Skřet sekl dýkou a trefil se přesně...");
            }
            else
            {
                WriteLine("Skřetovi se jeho sek dýkou moc nepovedl...");
            }

            WriteLine();
            Thread.Sleep(150);
            WriteLine("Sek způsobil {0} poškození!", poskozeni);
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
            ForegroundColor = ConsoleColor.DarkGreen;

            if (poskozeni >= 4)
            {
                WriteLine("Skřet otrávil své nepřátele výbušnou plynovou bombičkou, která bohužel neminula...");
                WriteLine();
                Thread.Sleep(250);
                if (_otraven == false)
                {
                    WriteLine("Odteď jste otráveni, při každé další Skřetově akci Vám bude způsobováno {0} poškození.", _jedDamage);
                    _otraven = true;
                    poskozeni = 0;
                }
                else
                {
                    _jedDamage += 3;
                    WriteLine("Už otráveni jste, vážnost Vaší otravy se tedy zvyšuje, jed nyní způsobuje {0} poškození", _jedDamage);
                    WriteLine();
                    poskozeni = 0;
                    Thread.Sleep(150);
                    WriteLine("Útok prozatím způsobil 0 poškození...");
                }

            }
            else
            {
                WriteLine("Skřet se pokusil otrávit své nepřátele plynovou bombičkou, ale minul.");
                WriteLine();
                poskozeni = 0;
                Thread.Sleep(150);
                WriteLine("Nikomu nebyla způsobena žádná ujma - {0} poškození způsobeno.", poskozeni);
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


    //--------------------//OhnivyElemental-----------------------------------------------------------------------------------------------------------------------------//
    internal class OhnivyElemental : Stvoreni        
    {
        private int cenaUtoku { get; set; }
        private int maxManaPostavy { get; set; }
        public static bool SmrtSchopnosti { get; set; }

        public OhnivyElemental() // hodnoty base atributů tohoto monstra
        {
            pocetZlata = 0;
            zbranStvoreni = VytvorenePredmety.Ohnivá_Koule;
            zbrojStvoreni = VytvorenePredmety.Žádná_Zbroj;
            pouzitelnyPredmet = null;
            surovinyStvoreni = VytvorenePredmety.Ohnivý_Prach;
            sInteligence = 2;
            sSila = 0;
            sObratnost = 1;
            sStesti = 1;
            maManu = true;
            pocetMany = 4;
            cenaUtoku = zbranStvoreni.manovaCena;
            poskozeniZbrane = zbranStvoreni.poskozeniZbrane;
            sUtocnaHodnota = 2 + poskozeniZbrane;
            hodnotaBrneni = zbrojStvoreni.hodnotaBrneni;
            sObrannaHodnota = 0 + hodnotaBrneni;
            sZdravi = 10 + sObrannaHodnota + sSila;
            maxZdravi = sZdravi;
            maxMana = pocetMany;
            maxManaPostavy = VasePostava.hracovaPostava.pocetMany;
            seznamPredmetu = new List<Predmety> { zbranStvoreni, zbrojStvoreni, pouzitelnyPredmet, surovinyStvoreni };            
            nazevStvoreni = "Ohnivý Elemental";
            Bestiar.PridejDoBestiare(this);
            popis = @"'Elegantní a inteligentní stvoření, vím že slouží jako společník nejednoho čaroděje... 
 
 Co se souboje týče, dokáže být velice nebezpečný.
                    
 Když je napokraji smrti tak exploduje a způsobuje neuvěřitelné škody.'";
            
        }

        protected void AtronachAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.Red;
            WriteLine("OhnivyElemental použil svou speciální schopnost...");
            Thread.Sleep(350);
            WriteLine(@"  ⠀⠀
⠀⠀⠀⠀⠀⠀⠸⠖⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢻⣧⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣻⣿⣒⣷⣄⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⢻⣿⣆⡀⠀⠀⠀⠀⢀⠜⠀⠀⢰⣿⣿⣶⣿⣷⡄⠀⠀⠀⠀⠀⠀⠀⣤⣤⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠋⠈⠉⠁⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⣿⣿⣿⣿⣿⣿⣿⣿⣧⡙⠻⣷⣦⠀⠀⠀⠀⠀⡀⠀⠁⣿⣿⣿⣿⣿⣿⣆⠀⠀⠀⣦⣤⣿⠟⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠄⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⢠⣤⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣦⣄⠀⠀⣰⣿⣴⠀⣹⣿⣿⣿⣿⣿⣿⡗⠀⠀⢈⣉⣃⣠⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣁⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⣿⡟⣈⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠙⠠⢾⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠉⠉⠉⠛⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠇⠀⠀⠈⠉⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠁⠀⠀⠀⠀⠈⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡏⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠏⠀⠀⠀⠀⠀⠀⠀⢀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⣴⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠟⠁⠀⠀⠈⠀⠀⠐⠀⠀⠙⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢃⡈⠉⢹⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠟⠋⢁⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⠉⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠺⠇⠀⠀⠀⠿⣿⣿⣿⣿⣿⣿⣿⣿⠟⠋⣁⣤⣾⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⣶⣌⠛⠿⣿⣿⣿⣿⣿⣿⣿⡿⠿⠳⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣡⣴⣿⣿⣿⣿⣿⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣷⣦⡘⣿⣿⣿⣿⣿⣿⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⣿⡟⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⣸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠰⠂⣴⢾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡀⠀⠀⠀⠀⠀⢀⣸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⣄⣩⣝⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣇⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠹⠿⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡀⠀⠀⠀⢀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣬⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⢘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠇⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⣠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣄⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⠴⠒⠿⠿⠿⠛⠻⠿⠿⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⡿⠟⠃⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠟⠛⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡀");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void AtronachUtokAnimace()
        {
            Thread.Sleep(150);
            OutputEncoding = Encoding.UTF8;
            ForegroundColor = ConsoleColor.Red;
            WriteLine("OhnivyElemental se připravuje k útoku...");
            Thread.Sleep(150);

            WriteLine(@"
                               ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⢈⠈⠙⠫⣝⡲⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠈⠀⠀⠀⠀⠙⠿⣿⣿⣧⣂⠄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠈⢻⣿⣿⣷⣬⣑⣦⣄⠀⠀⣿⣶⡂⠀⠱⣦⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣿⣿⣿⣿⣿⣿⣷⣿⣿⣷⡄⠀⠙⢿⣿⣦⡐⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⢰⣄⡀⠀⠐⢦⣄⣀⠈⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣄⡀⠀⠙⢿⣿⣿⣿⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠈⢿⣿⣦⠀⠈⠻⣿⣿⣦⣜⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣤⣦⣽⢿⣿⣿⣿⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠈⠻⢿⣷⣄⠀⠀⠉⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠙⠻⢷⣦⣄⣀⠈⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⠀⢠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠬⣭⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣼⣧⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⠿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠲⢶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡷⠍⠛⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣄⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⠻⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢦⡀⠀⠈⠙⠉⠙⠻⢿⡿⣿⣿⣿⣿⣿⣦⣆⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡷⠑⠀⠀⠀⠀⠀⠀⠀⠁⠀⠑⠀⠉⠻⢿⣿⣆⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠐⠀⠀⠀⠀⠀⠠⡀⠀⠀⠀⠹⣿⣷⣀⡀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢀⠀⢰⣵⣼⣿⣿⣷
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠿⣿⣿⣿⣿⣿⣿⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠣⣸⣿⣿⣿⣿⣿
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢿⣿⣿⣿⣿⣿⡆⠀⢀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣛⣿⣿⡟⣿⣿
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⢙⣿⣿⣿⣄⠀⢾⣧⡀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⣿⡇⣿⡇
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⣿⣿⣿⣿⣷⣼⣿⣿⣷⣄⠀⠀⠀⠀⣰⣿⣿⡿⣿⢠⡿⢠
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠿⣿⣯⡙⢿⣿⣿⣯⣾⣿⣶⣶⣿⣿⣿⡿⠛⠁⡜⢠⠃
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⢿⣿⣦⡈⠙⢛⢿⣿⣿⣿⣿⠿⠟⠁⠀⢀⠔⠁⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠪⣍⡒⠀⠀⠉⠁⠀⠀⠀⢀⡠⠐⠁⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠁⠀⠀⠀⠉⠉⠀⠀⠀⠀

                                                            ");
            Thread.Sleep(4000);
            ResetColor();
            Clear();
        }

        private void AtronachUtokPrubeh()
        {
            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            kostka.HodKostkou();
            WriteLine();
            Thread.Sleep(250);
            ForegroundColor = ConsoleColor.Red;
            if (pocetMany >= cenaUtoku)
            {
                pocetMany -= cenaUtoku;
                WriteLine("OhnivyElemental na ohnivou kouli spotřeboval manu, po útoku má {0} many.", pocetMany);
                Thread.Sleep(300);
                WriteLine();
            }
            else
            {
                sZdravi -= cenaUtoku;
                WriteLine("OhnivyElemental nemá dostatek many na seslání ohnivé koule, použil proto své zdraví. Nyní má {1} zdraví.", pocetMany, sZdravi);
                Thread.Sleep(300);
                WriteLine();
                if (pocetMany > 0)
                {
                    sZdravi += pocetMany;
                    pocetMany = 0;
                    Thread.Sleep(300);
                    WriteLine();
                    WriteLine("Atronachova zbývající mana se konvertovala do jeho zdraví, proto se jeho zdraví zvýšilo na {1}. Teď má {0} many.", pocetMany, sZdravi);
                    Thread.Sleep(300);
                    WriteLine();
                }
            }

            ResetColor();
            poskozeni = sUtocnaHodnota + kostka.VysledekHodu();
            ForegroundColor = ConsoleColor.Red;          
            WriteLine("OhnivyElemental zasáhl svůj cíl ohnivou koulí...");            
            WriteLine();
            Thread.Sleep(150);
            WriteLine("Útok způsobil {0} poškození, OhnivyElemental nyní má {1} many a {2} zdraví", poskozeni, pocetMany, sZdravi);           
            ResetColor();            
        }

        public override int PoskozeniStvoreni()
        {
            return poskozeni;
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
            poskozeni = (sInteligence + sUtocnaHodnota + sZdravi) + kostka.VysledekHodu();
            int doplnenaMana = sZdravi;

            VasePostava.hracovaPostava.pocetMany += doplnenaMana;
            if (VasePostava.hracovaPostava.pocetMany > maxManaPostavy)
            {
                VasePostava.hracovaPostava.pocetMany = maxManaPostavy;
            }
            sZdravi -= sZdravi;

            ForegroundColor = ConsoleColor.Red;
            WriteLine("OhnivyElemental se zastavil a vzplanul...");
            WriteLine();
            Thread.Sleep(200);
            WriteLine("Vzplanutí způsobilo {0} poškození a OhnivyElemental také doplnil magickou aurou svému okolí {1} many!", poskozeni, doplnenaMana);
            WriteLine();
            Thread.Sleep(200);
            WriteLine("Po vzplanutí Atronacha máte {0} many.", VasePostava.hracovaPostava.pocetMany);
            WriteLine();
            Thread.Sleep(250);
            WriteLine("OhnivyElemental se tímto obětoval a zemřel...");
            Thread.Sleep(250);         
            ResetColor();          
        }

        public override void SchopnostStvoreni() // už celá funkce, která provede schopnost se vším všudy
        {
            Clear();
            if (sZdravi <= (int)(maxZdravi * 0.4))
            {
                AtronachAnimace();
                PrubehSchopnostiStvoreni();
            }
            else
            {
                AtronachUtokAnimace();
                AtronachUtokPrubeh();
            }
        }

        //**********************************************************************************
        public override void UtokStvoreni()
        {
            Clear();
            if (sZdravi <= (int)(maxZdravi * 0.4))
            {
                
                AtronachAnimace();
                PrubehSchopnostiStvoreni();
            }
            else
            {
                AtronachUtokAnimace();
                AtronachUtokPrubeh();
            }
        }

        public override void ArtStvoreni()
        {
            OutputEncoding = Encoding.UTF8;
            Thread.Sleep(100);
            ForegroundColor = ConsoleColor.Red;

            WriteLine(@"

⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀⠀⠀⡠⢤⡟⠀⢀⡀⠀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣷⢀⣀⣀⣿⣁⣤⡶⣧⣷⠞⣻⢚⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⣀⣴⣿⣿⣻⣿⣿⣿⣿⣷⣿⣿⣛⠈⠽⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⢀⣴⣿⡿⠟⣿⣿⠟⣻⣿⣻⣿⠛⠙⠡⣴⡷⠞⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⢸⡏⠻⠁⢸⣿⣧⢠⣿⣯⡽⠛⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠈⢹⣆⡀⢀⣿⢧⣾⠋⠀⠀⣄⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠘⣿⣿⣿⣿⣿⣿⣤⣿⣿⣿⡇⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⠿⠛⣷⣿⣿⣿⠍⠙⣿⣒⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⣟⣿⣿⣿⣿⣿⡿⢿⢿⣤⣄⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⣿⣿⣯⣽⣿⣿⣿⣟⢿⣶⣤⣽⣿⣿⣦⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⣿⣿⣿⣿⣿⣻⣿⣿⣿⣿⣿⣯⠻⠿⠻⣿⣷⣾⢟⣂⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢿⣿⣿⣿⣽⣾⣿⡃⠀⠈⠛⣿⣿⣷⣄⡀⠀⠛⠻⠿⢿⣿⣷⣶⣦⣀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢺⣿⣿⣿⣿⣿⣿⣌⠛⠈⠀⢀⠘⠛⠿⠿⡶⣦⡀⠀⠀⠀⠀⠈⣻⣿⣇⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣿⣿⣿⢿⣿⣇⠈⠛⠛⠈⠀⠀⠀⠀⠀⠀⣼⣷⠀⠀⠀⠀⠀⣿⠻⣿⡀⠀⠀⠀
⠀⠀⠀⠀⠀⠐⠀⠀⠀⠀⠀⠹⣿⣿⢸⣿⢿⢶⣶⣶⣦⣤⣄⣀⡀⢀⡴⠻⣿⠀⠀⠀⠀⠐⠃⢠⣿⣇⠀⠀⠀
⠀⠀⠀⠐⠁⠀⠀⠀⠀⠀⠀⠀⢻⣷⣾⣿⣶⣦⣿⣿⣿⣿⡿⡿⣿⣶⣄⢾⠋⡀⠀⠀⠀⠀⠀⠠⠁⠘⠀⠀⠀
⠀⠀⠀⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⢿⣿⣿⣿⣿⣿⣿⣷⡀⠈⠻⣿⣦⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀⠀⠀⠀
⠀⠀⠀⣂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⠇⢀⣤⣿⣿⡇⠀⠀⠀⠀⠀⡀⠈⠀⠀⠀⠀⠀
⠀⠀⠀⠀⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡿⢿⣿⣻⡿⣃⣴⣷⣿⣿⣿⠃⠀⠀⠀⠀⠈⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠂⠀⠀⠠⠀⠀⠀⠀⠂⠀⣿⣾⣿⣿⣯⣾⣿⣿⣿⣿⣿⠁⠀⠀⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⣿⣿⣿⣿⣿⣿⡿⣿⣿⣿⠏⠐⠀⠀⠀⠀⠀⠀⠈⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠑⠀⠀⠀⠀⠀⠀⠻⣿⣿⣿⡿⠟⠋⢐⣿⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⠀⢿⣿⣿⢄⣴⣿⣼⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⣿⣷⣿⣿⣿⡿⠛⠀⠀⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⣿⣿⣿⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⡟⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⡇");

            Thread.Sleep(2000);
        }
    }
}