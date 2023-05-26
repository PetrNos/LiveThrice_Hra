using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static System.Console;

namespace DnD_Hra
{
    internal class VasePostava
    {
        //deleg

        private static int __MAXZIVOTY__ = 3;
        public static void OdebraniNeboSmrt()
        {
            if (__MAXZIVOTY__ != 1)
            {
                __MAXZIVOTY__--;
                SmrtUbraniHP();
            }
            else
                SmrtAndCrash();
            void SmrtAndCrash()
            {
                
                Clear();
                ForegroundColor = ConsoleColor.Red;               
                //animace              
                DndHerniFunkce.AnimaceTextu("....");
                WriteLine();
                WriteLine("Váš poslední život je u konce a s ním i tahle zpropadená pouť.");
                WriteLine();
                WriteLine("Mnoho štěstí na té příští...");
                GameplayLokaci_1.Tlacitko();
                Environment.Exit(0);
            }
            void SmrtUbraniHP()
            {
                Clear();
                ForegroundColor = ConsoleColor.Red;
                //animace              
                DndHerniFunkce.AnimaceTextu("....");
                WriteLine();
                if (__MAXZIVOTY__ == 2)
                    WriteLine($"Zemřeli jste. Ještě ale zdaleka není konec, zbývají Vám {__MAXZIVOTY__} životy. Hlavu vzhůru!");
                if(__MAXZIVOTY__ == 1)
                    WriteLine($"Zemřeli jste. Ještě ale není konec, zbývá poslední šance, zbývá poslední život...");
                GameplayLokaci_1.Tlacitko();
            }
        }
        public static Dictionary<string, Action> _seznamSpecialnichSchopnostiHrace = new Dictionary<string, Action>();
        public static Zbrane zbranPostavy;
        public static Zbroje zbrojPostavy;
        public static Zbrane vybavenaZbran;
        public static Zbrane vybavenaAltZbran;
        public static Zbroje vybavenaZbroj;
        public static Zbrane alternativniZbranPostavy;      
        public static VasePostava hracovaPostava;
        public static Inventar inventarPostavy;

        private const int maximalniKapacita = 25;
        public int AktualizaceKapacity()
        {
            return maximalniKapacita + (vSila * 2);
        }
        public Action RasovaSchopnost { get; set; }

        public Action PovolaniSchopnost { get; set; }

        public Action Utok { get; set; }

        public Action ArtHrdiny { get; set; }

        

        public Func<int> HodnotaPoskozeni { get; set; }

        public Func<int> HodnotaRasoveSchopnosti { get; set; }

        // properties
        public int vObratnost;

        public int zakladniUtocnaHodnota { get; set; }
        public int zakladniObrannaHodnota { get; set; }
        public int vSila;
        public int vInteligence;
        public int vStesti;
        public int vZdravi;
        public int poskozeniZbrane { get; set; }
        public string vJmeno { get; set; }
        public int vUtocnaHodnota { get; set; }
        public int vObrannaHodnota { get; set; }
        public int hodnotaBrneni { get; set; }
        public bool maManu { get; set; }
        public int pocetMany { get; set; }

        //wizard special
        public int poskozeniAlternativniZbrane;

        private const int zakladniAltUH = 3;
        public int altUtocnaHodnota;
        public int cenaUtoku;

        // wizard special
        private int statRasy { get; set; }

        // staty k povoláním/rasám, individuální schopnosti
        //RASY       

        public int zdraviPostavy { get; set; } // elf

        public int maxMana { get; set; } // vsichni

        private bool hobitiKostka { get; set; } // hobit

        //POVOLANI
        public int bodPresnosti { get; set; } // valecnik

        private int kritickyZasah { get; set; } //zloděj
        public bool ZLock;//zlodej

        //SPOLECNIK

        public static Stvoreni spolecnik = null;
        public static Stvoreni _aktualniNepritel;

        private int uspesnaSchopnost { get; set; } // zloděj

       
        public int poskozeni { get; set; }
        

        public VasePostava()
        {
            ZLock = true;
            hobitiKostka = false;
        }

        public void RekonfiguraceUH()
        {
            poskozeniZbrane = zbranPostavy.poskozeniZbrane;
            vUtocnaHodnota = zakladniUtocnaHodnota + poskozeniZbrane;
            if (hracovaPostava.maManu)
                cenaUtoku = zbranPostavy.manovaCena;
        }

        public void RekonfiguraceOH()
        {
            hodnotaBrneni = zbrojPostavy.hodnotaBrneni;
            vObrannaHodnota = zakladniObrannaHodnota + hodnotaBrneni;
        }

        public void RekonfiguraceAltUH()
        {
            if (alternativniZbranPostavy != null)
            {
                poskozeniAlternativniZbrane = alternativniZbranPostavy.poskozeniZbrane;
                altUtocnaHodnota = zakladniAltUH + poskozeniAlternativniZbrane;
            }
        }

        public void RekonfiguraceHPaMany()
        {          
            zdraviPostavy = vZdravi;
            if (maManu)
                maxMana = pocetMany;
        }

        public int StatyRasoveSchopnosti()
        {
            return statRasy;
        }

       

        public int PoskozeniUtoku()
        {
            return poskozeni;
        }
        public void Hod_HK(DndKostka dndKostka)
        {
            if (hobitiKostka)
            {
                dndKostka.HodCinknutouKostkou();
                hobitiKostka = false;
            }
            else
                dndKostka.HodKostkou();
        }
        //--------------------------------------------------------------------------ELF

        private void ElfAnimaceSS()
        {
            Thread.Sleep(200);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0} použil svou rasovou speciální schopnost...", vJmeno);
            Thread.Sleep(150);
            Console.WriteLine(@"

                                 (¯`v´¯)
                                (`.¸.´
                                 ¸. ♥´ ¸.´¯)¸. ♥´)
                                (¸.´ (¸ ´¯`.¸
                                ¸.¨`¸.´♥`*` `*`)
                                   ¯`v´¯)`.¸.´   (¸.´ (¸ .)
                                      ¯`v´¯)`.¸.♥¸.¨`¸.)
                                          .¸.
                                       _..,----,.._
                                    .-;'-.,____,.-';
                                   (( |            |
                                    `))            ;
                                     ` \          /
                                    .-' `,.____.,' '-.
                                   (     '------'     )
                                    `-=..________..--'

                                                                     ");
            Thread.Sleep(4000);
            Console.ResetColor();
            Console.Clear();
        }

        private void SpecialniSchopnostElfa() // jen zdraví když není mana, i mana když má manu. Pro úspěch musí být zdraví <= 75% maxZdr
        {
            if (ZLock)
                ZLock = false;
            if (vZdravi <= (zdraviPostavy * 0.75))
            {
                DndKostka kostka = new DndKostka();
                Thread.Sleep(150);
                kostka.KostkyArt();
                Hod_HK(kostka);
                Console.WriteLine();
                Thread.Sleep(200);
                Console.ResetColor();
                statRasy = (vStesti + vInteligence) + kostka.VysledekHodu();
                Console.ForegroundColor = ConsoleColor.Green;
                if (maManu == false)
                {                 
                    Console.WriteLine("{0} použil svůj magický šálek a úspěšně si navýšil zdraví.", vJmeno);                                                            
                    if (statRasy < 0)
                    {
                        statRasy = 0;
                    }
                    vZdravi += statRasy;
                    if (vZdravi > zdraviPostavy)
                    {
                        vZdravi = zdraviPostavy;
                    }
                    Console.WriteLine();
                    Thread.Sleep(200);
                    Console.WriteLine("{1} si  přidal {0} životů!", statRasy, vJmeno);
                    Console.WriteLine();
                    Thread.Sleep(200);
                    Console.WriteLine("{1} má nyní {0} životů...", vZdravi, vJmeno);
                    Thread.Sleep(300);
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
                    Console.ReadKey(true);
                    Console.Clear();
                }
                else if (maManu == true)
                {
                    int pridaniMany = (int)(statRasy*0.4);                  
                    Console.WriteLine("{0} použil svůj magický šálek a úspěšně si navýšil zdraví a manu.", vJmeno);                                 
                    if (statRasy < 0)
                    {
                        statRasy = 0;
                    }
                    vZdravi += statRasy;
                    pocetMany += pridaniMany;
                    if (pocetMany > maxMana)
                    {
                        pocetMany = maxMana;                       
                    }
                    if (vZdravi > zdraviPostavy)
                    {
                        vZdravi = zdraviPostavy;
                    }
                    Console.WriteLine();
                    Thread.Sleep(150);
                    Console.WriteLine("{1} si přidal {0} životů a také si přidal {2} many!", statRasy, vJmeno, pridaniMany);
                    Console.WriteLine();
                    Thread.Sleep(200);
                    Console.WriteLine("{1} má nyní {0} životů a {2} many...", vZdravi, vJmeno, pocetMany);
                    Thread.Sleep(300);
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Thread.Sleep(250);
                Console.WriteLine();
                Console.WriteLine("{0} má moc zdraví na použití této schopnosti, maximální hranice zdraví pro použití je {1}, nyní je zdraví {2}.", vJmeno, (int)(zdraviPostavy * 0.75), vZdravi);
                Console.WriteLine();
                Thread.Sleep(450);
                Console.ResetColor();
                Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
                Console.ReadKey(true);
                Console.Clear();
            }
        }

        public void SchopnostElfa()
        {
            ElfAnimaceSS();
            SpecialniSchopnostElfa();
        }

        // -----------------------------------------------------------------KONEC ELFA

        //-----------------------------------------------------------------HOBIT

        private void HobitAnimaceSS()
        {
            Thread.Sleep(150);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("{0} použil svou rasovou speciální schopnost...", vJmeno);
            Console.OutputEncoding = Encoding.UTF8;
            Thread.Sleep(350);
            Console.WriteLine(@"

           ⢠⡶⠶⢦⣤⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣠⡤⠶⢶⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡿⠀⠀⢠⣄⡉⠛⢷⣤⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⠶⠛⣩⣥⣤⣤⠈⢿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⣧⣴⣦⣿⣿⣷⡀⣼⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡟⣧⢸⣿⣿⣿⣿⣧⣼⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡿⣼⣿⣿⣿⣿⣿⣿⣿⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⣻⣿⣿⣿⣿⣿⣿⣿⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⠃⠹⢿⣿⣿⣿⣿⣿⣿⠁⠀⠀⠀⠀⣠⡶⢶⣶⣄⣤⣶⣶⣦⡄⠀⠀⠀⠀⠘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⣸⡏⣰⣿⣿⣷⣿⣿⣿⣿⡇⠀⠀⠀⠀⢰⣯⣶⣿⣿⣿⡿⣿⣿⣿⣿⡆⠀⠀⠀⠀⢹⣿⣿⣿⣿⣿⣿⣿⣿⣿⡆⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⢀⣿⢠⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠘⣿⣿⣿⣿⣿⣥⣿⣿⣿⣿⠇⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⣸⠇⣸⣿⣧⣤⣿⣿⣿⣿⡇⢀⣴⠾⢳⣶⣦⣜⣿⣿⣿⣿⡧⣿⣿⣿⣯⢶⣛⣻⣿⣷⣄⢸⣿⣿⣿⣿⣧⣽⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⣿⠀⣿⣿⣿⣿⣿⣿⣿⣿⠁⣾⣷⣾⣿⣿⣿⣿⣿⣿⠿⣿⣧⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⢠⣿⣤⣿⣿⣿⣿⣿⣿⣿⣿⠀⠙⣿⣿⣿⣿⣿⣿⣿⣿⣷⣾⣿⣾⣿⣿⠿⠿⠿⣿⣿⣿⡋⠀⣿⣿⠁⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⠛⢻⣿⣿⣿⣿⠀⢸⣯⣥⣶⣶⣶⣶⣶⣿⣫⣿⡿⣿⣷⣶⣶⣶⣶⣿⣿⣿⣷⠀⣿⣿⠀⣻⣿⠛⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠘⡿⠿⣿⣿⣷⣿⣿⣿⣿⣿⡀⠸⣿⣿⣿⣿⣿⣿⣿⣿⣇⢸⡇⣿⣿⣿⣿⣿⣿⣿⣿⣿⠏⢰⣿⡟⠀⣽⣿⣾⣿⣿⣿⢻⡇⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⣇⠀⢿⣿⣿⣿⣿⠙⠛⣿⣇⠀⠈⠙⠛⠛⠋⣱⣿⣿⣿⣿⡇⢼⣿⣿⣿⡌⠉⠉⠉⠀⠀⣼⣿⡇⠀⣿⣿⣿⣿⣿⣥⣼⠁⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⣿⠀⢸⣿⣿⣿⣿⡆⠀⠸⣿⣆⠀⠀⠀⠀⢰⣿⣿⣿⣿⣿⣧⣿⣿⣿⣿⡇⠀⠀⠀⠀⣰⣿⣿⣦⣼⣿⣿⣿⣿⣿⡟⣿⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⢸⡇⠀⣿⣿⡋⣹⣷⡀⢀⣙⣿⣆⠀⠀⠀⠀⢿⣿⣿⣿⣿⢿⣿⣿⣿⠟⠀⠀⠀⠀⣰⣿⣿⣿⣽⣿⣿⢉⣿⣿⣿⣸⡇⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⣿⡄⠹⣿⣿⣿⣿⣿⣾⣿⣿⣿⣷⣄⣀⣀⣠⣬⣭⣭⠤⣤⢬⣭⣤⣤⣀⣀⣠⣾⣷⣿⣿⣿⣿⣿⣿⣿⣿⠏⢻⡿⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⣀⣤⣶⣾⣿⣿⣄⣹⣿⣿⣿⠿⠿⠿⠛⠋⠉⠉⠉⠉⠀⠁⠈⠉⠀⠀⠀⠀⠀⠀⠉⠀⠛⠉⠛⠿⢿⢿⣿⣿⣿⣿⣏⣰⣿⣿⣷⣶⣤⡀⠀⠀⠀
⠀⠀⢠⣾⣿⣿⣿⣽⣿⣿⣿⠿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⠛⠻⠿⣿⣿⣿⣿⣿⣿⣿⣷⡄⠀
⠀⠀⠈⠙⠻⣿⣿⣿⣿⡉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣿⣿⣿⣿⣿⠟⠋⠁⠀
⠀⠀⠀⠀⠀⠙⣿⣿⣿⣧⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣀⣀⣀⣀⣀⣀⣀⣀⣀⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⡿⣿⣿⣿⠃⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⢹⣿⣿⣿⣿⡇⣠⣤⣤⣰⣶⣶⣶⣶⠛⠛⠛⠛⠛⠟⠛⢿⣿⣿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣶⣶⣦⣤⣤⣾⣿⣿⣿⣇⡇⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠸⠿⠟⠻⠿⠿⠞⠛⠉⠉⠀⠉⠻⢿⣿⣶⣤⣤⣀⣀⣀⣀⡀⠀⣀⣉⣉⣉⣩⣤⣶⣿⡿⠟⠉⠀⠉⠉⠛⠛⠿⠿⠛⠛⠿⠃⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠙⠛⠻⠿⠿⠿⠿⠿⠿⠿⠿⠿⠛⠛⠉⠁⠀⠀⠀⠀ ");
            Thread.Sleep(4000);
            Console.ResetColor();
            Console.Clear();
        }

        private void SpecialniSchopnostHobita()
        {
            if (ZLock)
                ZLock = false;
            DndKostka kostka = new DndKostka();
            Thread.Sleep(150);
            kostka.KostkyArt();
            Hod_HK(kostka);                    
            Console.WriteLine();
            Thread.Sleep(250);
            Console.ResetColor();
            statRasy = vStesti + kostka.VysledekHodu();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            int zvyseniObrHod = (int)(statRasy*0.25);
            if (statRasy < 0)
            {
                statRasy = 0;
            }
            if(statRasy > 5 && statRasy <= 15)
            {
                Console.WriteLine("{0} má velice šťastný den, jeho další hod bude cinknutý a zároveň se dočasně zvýšila obranná hodnota o {1}.", vJmeno, zvyseniObrHod);                
                hobitiKostka = true;
                vObrannaHodnota += zvyseniObrHod;
                Thread.Sleep(200);
                Console.WriteLine();
                Console.WriteLine("Obranná hodnota je nyní {0}.", vObrannaHodnota);
            }        
            else if(statRasy > 15)
            {

                Console.WriteLine("{0} má velice šťastný den, jeho další hod bude cinknutý a zároveň se dočasně zvýšila obranná hodnota o {1}.", vJmeno, zvyseniObrHod);
                WriteLine();
                WriteLine($"{vJmeno} má dokonce takové štěstí, že na zemi našel lektvar zdraví! Naleznete ho v osobním inventáři.");
                VasePostava.inventarPostavy.PridejPredmet(VytvorenePredmety.Lektvar_Zdraví);
                hobitiKostka = true;
                vObrannaHodnota += zvyseniObrHod;
                Thread.Sleep(200);
                Console.WriteLine();
                Console.WriteLine("Obranná hodnota je nyní {0}.", vObrannaHodnota);
            }
            else
            {
                Console.WriteLine("{0} zkusil najít své štěstí, ale tentokrát to nevyšlo...", vJmeno);
                hobitiKostka = false;
            }
            Thread.Sleep(200);
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
            Console.ReadKey(true);
            Console.Clear();
        }

        public void SchopnostHobita()
        {
            HobitAnimaceSS();
            SpecialniSchopnostHobita();
        }

        //------------------------------------------------------------------KONEC HOBITA
        //------------------------------------------------------------KROLL

        private void KrollAnimaceSS()
        {
            Thread.Sleep(150);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("{0} použil svou rasovou speciální schopnost...", vJmeno);
            Thread.Sleep(150);
            Console.WriteLine(@"

                               // clovek SS art zde

                                                                     ");
            Thread.Sleep(4000);
            Console.ResetColor();
            Console.Clear();
        }

        private void SpecialniSchopnostKrolla()
        {
            
            if (ZLock)
                ZLock = false;
            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            Hod_HK(kostka);
            Console.WriteLine();
            Thread.Sleep(250);
            Console.ResetColor();
            statRasy = vSila +kostka.VysledekHodu();
            int UHP = (int)(statRasy*0.4);
            int OHU = UHP/2;
            ForegroundColor = ConsoleColor.Red;
            if(vObrannaHodnota > 0)
            {
                if (UHP < 0)
                    UHP = 0;
                if (OHU < 0)
                    OHU = 0;
                WriteLine($"Bersekrův řev Vám přidal {UHP} útočné hodnoty.");
                Thread.Sleep(350);
                WriteLine();
                WriteLine($"A ubral {OHU} té obranné.");
                Thread.Sleep(350);
                WriteLine();
                vUtocnaHodnota += UHP;
                vObrannaHodnota -= OHU;
                if (vObrannaHodnota < 0)
                    vObrannaHodnota = 0;
                WriteLine($"Nyní máte {vUtocnaHodnota} útočné hodnoty a {vObrannaHodnota} té obranné!");
            }
            else
            {
                if (UHP < 0)
                    UHP = 0;
                if (OHU < 0)
                    OHU = 0;
                WriteLine($"Bersekrův řev Vám přidal {UHP} útočné hodnoty.");
                Thread.Sleep(350);
                WriteLine();
                WriteLine($"A ubral {OHU} životů.");
                Thread.Sleep(350);
                WriteLine();
                vUtocnaHodnota += UHP;
                vZdravi -= OHU;
                if (vZdravi < 0)
                    vZdravi = 0;
                WriteLine($"Nyní máte {vUtocnaHodnota} útočné hodnoty a {vZdravi} zdraví!");
            }
            Console.WriteLine();
            Console.ResetColor();
            Thread.Sleep(150);
            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
            Console.ReadKey(true);
            Console.Clear();
        }

        public void SchopnostKrolla()
        {
            KrollAnimaceSS();
            SpecialniSchopnostKrolla();
        }

        //-------------------------------------------------------------KONEC KROLLA
            
        //----------------------------POVOLÁNÍ--------------------------------------------------

        //---------------------------------------------------------------------------ČARODĚJ
        protected void CarodejAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("{0} použil svou speciální schopnost...", vJmeno);
            Thread.Sleep(250);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
            ⢀⠀⠀⠀⠀⡠⢤⡟⠀⢀⡀⠀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
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
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⡇ ");
            Thread.Sleep(4000);
            Console.ResetColor();
            Console.Clear();
        }

        private void CUtokAnimace() // animace útoku
        {
            Thread.Sleep(150);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("{0} se připravuje k útoku...", vJmeno);
            Thread.Sleep(150);
            Console.WriteLine(@"
                                                     /\
                                                    /@ \
                                                   |    |
                                                 --:'''':--
                                                   :'_' :
                                                   _:VV:\___
                                    ' '      ____.' :V:     '._
                                   . *=====<<=)           \    :
                                    .  '      '-'-'\_      /'._.'
                                                     \====:_ L_j
                                                    .'     \\
                                                   :       :
                                                  /   :    \
                                                 :   .      '.
                                 ,. _            :  : :      :
                              '-'    ).          :__:-:__.;--'
                            (        '  )        '-'   '-'
                         ( -   .00.   - _
                        (    .'  _ )     )
                        '-  ()_.\,\,   -

                                                         ");
            Thread.Sleep(4000);
            Console.ResetColor();
            Console.Clear();
        }

        private void CUtokPrubeh() // vizuální průběh útoku
        {
            Console.Clear();
            Console.CursorVisible = false;

            string plakat = @$"

                                                    ___________
                                                   |           |
                                                   |    ___    |
                                                   |   |   |   |
                                             ______|   |___|___|______
                                            |      |   |              |
                                            |   ___|   |_______ ___   |
                                            |  |   |   |   |   |   |  |
                                            |  |___|___|___|   |___|  |
                                            |              |   |      |
                                            |______________|   |______|
                                                   |   |   |   |
                                                   |   |___|   |
                                                   |           |
                                                   |___________|

                                  Vyberte si typ útoku, aktuální počet many je: {pocetMany}
                                                                                            ";

            string[] moznosti = { $"Útok hlavní zbraní (- {cenaUtoku} many)", $"Útok záložní zbraní (+ {(int)(maxMana*0.25)} many)" };
            Menu hlavniMenu = new Menu(plakat, moznosti.ToList(), ConsoleColor.DarkCyan);
            int vybranyIndex = hlavniMenu.NavratIndexu();
            Console.CursorVisible = true;
            switch (vybranyIndex)
            {
                case 0:
                    if (pocetMany >= cenaUtoku)
                    {
                        Thread.Sleep(150);
                        Console.Clear();
                        DndKostka kostka = new DndKostka();
                        Thread.Sleep(200);
                        kostka.KostkyArt();
                        Hod_HK(kostka);
                        Console.WriteLine();
                        Thread.Sleep(250);
                        Console.ResetColor();
                        poskozeni = vUtocnaHodnota + kostka.VysledekHodu();                     
                        Console.ForegroundColor = ConsoleColor.DarkCyan;                     
                        pocetMany -= cenaUtoku;                      
                         Console.WriteLine("{0} zasadil povedenou ránu!", vJmeno);                       
                        Console.WriteLine();
                        Thread.Sleep(350);
                        Console.WriteLine("Útok způsobil {0} poškození!", poskozeni);
                        Console.WriteLine();
                        Thread.Sleep(350);
                        Console.WriteLine("{0} má nyní {1} many", vJmeno, pocetMany);                      
                        Console.ResetColor();                                              
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Thread.Sleep(150);
                        Console.WriteLine();
                        Console.WriteLine("{0} nemá dostatek many na útok touto zbraní, aktuální počet many je {1}...", vJmeno, pocetMany);
                        Console.ResetColor();
                        Thread.Sleep(150);
                        Console.WriteLine();
                        Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
                        Console.ReadKey(true);
                        poskozeni = 0;
                        
                    }
                    break;

                case 1:
                    UtokZalozniZbrani();
                    break;
            }
        }

        private void UtokZalozniZbrani()
        {
            Thread.Sleep(150);
            Console.Clear();
            DndKostka kostka2 = new DndKostka();
            Thread.Sleep(200);
            kostka2.KostkyArt();
            Hod_HK(kostka2);
            Console.WriteLine();
            Thread.Sleep(250);
            Console.ResetColor();
            poskozeni = altUtocnaHodnota + kostka2.VysledekHodu();
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            pocetMany += (int)(maxMana * 0.25);
            if (pocetMany > maxMana)
                pocetMany = maxMana;

            if (poskozeni >= 4)
            {
                Console.WriteLine("{0} zasadil poměrně přesnou ránu...", vJmeno);
            }
            else 
            {
                Console.WriteLine("{0} se pokusil udeřit soupeře svou záložní zbraní, ale moc to nevyšlo...", vJmeno);
            }

            Console.WriteLine();
            Thread.Sleep(350);
            Console.WriteLine("Útok záložní zbraní způsobil {0} poškození!", poskozeni);
            Console.WriteLine();
            Thread.Sleep(300);
            Console.WriteLine("{0} má nyní {1} many", vJmeno, pocetMany);           
            Console.ResetColor();            
            
        }

        private void SpecialniSchopnostCarodeje() // to, co se stane při speciální schopnosti
        {
            int cenaAtronacha = 5;
            Thread.Sleep(150);
            DndKostka kostka = new DndKostka();
            kostka.KostkyArt();
            Hod_HK(kostka);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            if (spolecnik is Eirlys)
            {
                Thread.Sleep(300);
                WriteLine("Eirlys atronacha okamžitě rozptýlila, prý by jen překážel...");
                poskozeni = 0;
                return;
            }
            if (vInteligence + kostka.VysledekHodu() < 5)
            {
                Thread.Sleep(200);
                Console.WriteLine("{0} se pokusil vyvolat svého společníka, ale nepodařilo se to...", vJmeno);
            }
            else if (pocetMany < cenaAtronacha)
            {
                Thread.Sleep(200);
                Console.WriteLine();
                Console.WriteLine("{0} nemá dostatek many na vyvolání, vyvolání stojí {1} many a nynější počet many je {2} ...", vJmeno, cenaAtronacha, pocetMany);
            }
            else if (spolecnik != null && pocetMany >= cenaAtronacha && (vInteligence + kostka.VysledekHodu()) >= 5 && (vInteligence + kostka.VysledekHodu()) < 14)
            {
                Thread.Sleep(200);
                Menu menu = new Menu($"{vJmeno} už nějakého společníka má ({spolecnik.nazevStvoreni}), přejete si ho zaměnit za nového Atronacha?", new List<string> { "Ano", "Ne" }, ConsoleColor.Red);
                int v = menu.NavratIndexu();
                Console.Clear();
                if (v == 0)
                {
                    spolecnik = new OhnivyElemental();
                    pocetMany -= cenaAtronacha;
                    Thread.Sleep(200);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("{0} úspěšne vyvolal svého společníka, který se zapojí do boje, nynější počet many je {1}...", vJmeno, pocetMany);
                }
                else
                {
                    Thread.Sleep(200);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Rozhodli jste se ponechat Vašeho stávajícího společníka.");
                }
            }
            else if (spolecnik == null && pocetMany >= cenaAtronacha && (vInteligence + kostka.VysledekHodu()) >= 5 && (vInteligence + kostka.VysledekHodu()) < 14)
            {
                spolecnik = new OhnivyElemental();
                pocetMany -= cenaAtronacha;
                Thread.Sleep(200);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("{0} úspěšne vyvolal svého společníka, který se zapojí do boje, nynější počet many je {1}...", vJmeno, pocetMany);
            }
            else if (spolecnik != null && pocetMany >= cenaAtronacha && (vInteligence + kostka.VysledekHodu()) >= 14)
            {
                Thread.Sleep(200);
                Menu menu = new Menu($"{vJmeno} už nějakého společníka má ({spolecnik.nazevStvoreni}), přejete si ho zaměnit za nového Atronacha?", new List<string> { "Ano", "Ne" }, ConsoleColor.Red);
                int v = menu.NavratIndexu();
                Console.Clear();
                if (v == 0)
                {
                    spolecnik = new OhnivyElemental();
                    Thread.Sleep(200);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("{0} úspěšne vyvolal svého společníka, který se zapojí do boje, nynější počet many je {1}...", vJmeno, pocetMany);
                    WriteLine();
                    WriteLine("Vyvolání se Vám veice povedlo, nestálo žádnou manu!");
                }
                else
                {
                    Thread.Sleep(200);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Rozhodli jste se ponechat Vašeho stávajícího společníka.");
                }

            }
            else if (spolecnik == null && pocetMany >= cenaAtronacha && (vInteligence + kostka.VysledekHodu()) >= 14)
            {
                spolecnik = new OhnivyElemental();
                Thread.Sleep(200);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("{0} úspěšne vyvolal svého společníka, který se zapojí do boje, nynější počet many je {1}...", vJmeno, pocetMany);
                WriteLine();
                WriteLine("Vyvolání se Vám veice povedlo, nestálo žádnou manu!");
            }
            else
                throw new Exception("Tady něco nevychádza (čaroděj ability)");
            poskozeni = 0;            
            Console.ResetColor();           
            
        }

        public void CarodejovaSchopnost() // už celá funkce, která provede schopnost se vším všudy
        {
            Console.Clear();
            CarodejAnimace();
            SpecialniSchopnostCarodeje();
           
        }

        public void UtokCarodeje()
        {
            Console.Clear();
            CUtokAnimace();
            CUtokPrubeh();
            
        }

        //-------------------------------------------------------------------KONEC ČARODĚJE
        //--------------------------------------------------------VÁLEČNÍK
        protected void ValecnikAnimace() // animace schopnosti
        {
            Console.Clear();
            Thread.Sleep(150);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("{0} použil svou speciální schopnost...", vJmeno);
            Thread.Sleep(150);
            Console.WriteLine(@"

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
            Console.ResetColor();
            Console.Clear();
        }

        //**********************************************************************************
        private void VUtokAnimace()
        {
            Thread.Sleep(150);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("{0} se připravuje k útoku...", vJmeno);
            Thread.Sleep(150);
            Console.WriteLine(@"
                           ⣣⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠸⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⢳⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠐⡅⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⡆⠀⠀⠀⠀⠀⠀⢠⣶⣿⣷⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢿⠀⠀⠀⠀⠀⠀⣸⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢘⣣⠀⠀⠀⠀⢀⣿⣷⢯⣿⡿⠦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⣃⠀⠀⣀⠐⣿⣿⣿⣟⣠⣵⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣄⠤⢾⣿⣯⠁⠀⢼⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⣿⣷⣦⣺⣿⣿⣿⣿⣿⣿⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⡿⠟⢿⣿⣿⢻⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⢿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡸⢁⣿⣿⣿⣿⣿⣿⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⠁⣼⣿⣿⣿⣿⣿⣿⠈⠻⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣎⣼⣿⣿⣿⣿⣿⣿⣿⣧⠀⠈⠛⢷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡐⣿⣿⣿⠋⠉⠉⠻⣿⣿⣿⣆⠀⠀⠀⠙⠳⣦⡀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢳⣿⣿⣿⠀⠀⠀⠀⠸⣿⣿⣿⣧⠀⠀⠀⠀⠈⠻⣦⡄⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢻⣿⣿⡆⠀⠀⠀⠀⠈⢿⣿⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣻⣿⣿⣷⣦⣠⣄⣀⣤⣠⣿⣿⣧⣄⣄⣀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣦⠱⣿⣿⣿⣿⣿⡿⣿⠛⠉⠉⣙⣿⣿⣿⣿⣿⣿⣿⣿⣆⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠿⣶⣈⢉⣻⣿⣿⡇⠀⡀⢀⣀⣈⣙⣻⣿⣿⣿⣿⣿⣿⣟⣁⡀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣴⠬⠉⠈⠀⠾⠷⠿⠿⠿⠛⠛⠛⠋⠛⠛⠻⠯⠟⠟⠉⠐⠉⠉⠀⠀⠀

                                                            ");
            Thread.Sleep(4000);
            Console.ResetColor();
            Console.Clear();
        }

        private void VUtokPrubeh()
        {
            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            Hod_HK(kostka);                     
            Console.WriteLine();
            Thread.Sleep(250);
            Console.ResetColor();
            poskozeni = vUtocnaHodnota + kostka.VysledekHodu();        
            Console.ForegroundColor = ConsoleColor.Blue;           
            if (poskozeni >= 4 && poskozeni < 6)
            {
                bodPresnosti++;
                Console.WriteLine("{0} zaútočil svou zbraní a úspěšně zasadil ránu nepříteli, čímž si přidal 1 bod přesnosti...", vJmeno);
            }
            else if (poskozeni >= 6 && poskozeni < 13)
            {
                bodPresnosti += 2;
                Console.WriteLine("{0} zaútočil svou zbraní a zasadil skvěle mířenou ránu nepříteli, čímž si přidal 2 body přesnosti...", vJmeno);
            }
            else if (poskozeni >= 13)
            {
                bodPresnosti += 3;
                Console.WriteLine("{0} zaútočil svou zbraní a zasadil dokonalou ránu nepříteli, čímž si přidal 3 body přesnosti...", vJmeno);
            }
            else
            {
                Console.WriteLine("{0} zaútočil svou zbraní a provedl něco, co bychom možná mohli nazvat škrábnutím...", vJmeno);
            }
            Console.WriteLine();
            Thread.Sleep(150);
            Console.WriteLine("Útok způsobil {0} poškození, nynější počet bodů přesnosti je {1}", poskozeni, bodPresnosti);           
            Console.ResetColor();          
           
        }

        private void SpecialniSchopnostValecnika() // to, co se stane při speciální schopnosti
        {
            Console.ResetColor();
            byte cenaSchopnosti = 3;
            if (bodPresnosti >= cenaSchopnosti)
            {
                bodPresnosti -= 3;
                DndKostka kostka = new DndKostka();
                Thread.Sleep(250);
                kostka.KostkyArt();
                Hod_HK(kostka);                            
                Console.WriteLine();
                poskozeni = 2 * vUtocnaHodnota + vSila + kostka.VysledekHodu();
                Console.ForegroundColor = ConsoleColor.Blue;            
                Thread.Sleep(250);                            
                Console.WriteLine("{0} se rozmáchl svou zbraní a zasadil překavapivě přesný zásah...", vJmeno);             
                Console.WriteLine();
                Thread.Sleep(150);
                Console.WriteLine("Přímý Zásah způsobil {0} poškození a {1} má nyní {2} bodů přesnosti.", poskozeni, vJmeno, bodPresnosti);
                Thread.Sleep(200);
                ResetColor();
            }
            else
            {
                Thread.Sleep(250);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("{0} nenasbíral dostatek informací o slabinách nepřítele, potřebuje {1} body přesnosti, teď má ale jen {2}.", vJmeno, cenaSchopnosti, bodPresnosti);
                poskozeni = 0;
                Console.ResetColor();                
               
            }
        }

        public void ValecnikovaSchopnost() // už celá funkce, která provede schopnost se vším všudy
        {
            Console.Clear();
            ValecnikAnimace();
            SpecialniSchopnostValecnika();
            
        }

        public void UtokValecnika()
        {
            Console.Clear();
            VUtokAnimace();
            VUtokPrubeh();
           
        }

        //-------------------------------------------------------------------KONEC VÁLEČNÍKA
        //------------------------------------------------------ZLODĚJ
        protected void ZlodejAnimace() // animace schopnosti
        {
            Thread.Sleep(150);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0} použil svou speciální schopnost...", vJmeno);
            Thread.Sleep(150);
            Console.WriteLine(@"

                             ~~   >>>>>----------------------->
                                ~

                         ~~       >>>>>>>_____________________\`-._
                           ~~     >>>>>>>                     /.-'

                                                            ");
            Thread.Sleep(4000);
            Console.ResetColor();
            Console.Clear();
        }

        //**********************************************************************************
        private void ZUtokAnimace() // animace útoku
        {
            Thread.Sleep(150);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0} se připravuje k útoku...", vJmeno);
            Thread.Sleep(150);
            Console.WriteLine(@"

                                                                            \.
                                                                            /|.
                                                                          /  `|.
                                                                        /     |.
                                                                      /       |.
                                                                    /         `|.
                                                                  /            |.
                                                                /              |.
                                                              /                |.
                                                            /                  `|.
                                                          /                     |.
                                                        /                       |.
                                                      /                         |.
                                                    /                           |\
                                 #####\          /                              ||
                             ==###########>     /                               ||
                              \##==      \    /                                 ||
                         ______ =       =|__/___                                ||
                     ,--' ,----`-,__ ___/'  --,-`-==============================##==========>
                    \               '        ##_______ ______   ______,--,____,=##,__
                     `,    __==    ___,-,__,--'#'  ==='      `-'              | ##,-/
                       `-,____,---'       \####\              |        ____,--\_##,/
                           #_              |##   \  _____,---==,__,---'         ##
                            #              ]===--==\                            ||
                            #,             ]         \                          ||
                             #_            |           \                        ||
                              ##_       __/'             \                      ||
                               ####='     |                \                    |/
                                ###       |                  \                  |.
                                ##       _'                    \                |.
                               ###=======]                       \              |.
                              ///        |                         \           ,|.
                              //         |                           \         |.
                                                                       \      ,|.
                                                                         \    |.
                                                                           \  |.
                                                                             \|.
                                                                             /

                                                         ");
            Thread.Sleep(4000);
            Console.ResetColor();
            Console.Clear();
        }

        //**********************************************************************************
        private void ZUtokPrubeh() // vizuální průběh útoku
        {
            if (ZLock)
                ZLock = false;
            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            Hod_HK(kostka);                   
            Console.WriteLine();
            Thread.Sleep(250);
            Console.ResetColor();
            poskozeni = vUtocnaHodnota + kostka.VysledekHodu();
            Console.ForegroundColor = ConsoleColor.Yellow;

            if (poskozeni>= 4)
            {
                Console.WriteLine("{0} provedl mrštný útok zbraní a zasáhl tak nepřítele...", vJmeno);
            }
            else
            {
                Console.WriteLine("{0} se pokusil o mrštný úder, avšak se mu to moc nepodařilo...", vJmeno);
            }

            Console.WriteLine();
            Thread.Sleep(150);
            Console.WriteLine("Útok způsobil {0} poškození!", poskozeni);           
            Console.ResetColor();            
           
        }

        //**********************************************************************************
        private void ZRedukovanyUtokPrubeh() // průběh útoku z redukcí
        {
            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            kostka.KostkyArt();
            kostka.HodKostkou();
            Console.WriteLine();
            Thread.Sleep(250);
            Console.ResetColor();
            poskozeni = (int)(vUtocnaHodnota  + (kostka.VysledekHodu()*0.75));
            Console.ForegroundColor = ConsoleColor.Yellow;

            if (poskozeni >= 3)
            {
                Console.WriteLine("{0} při první části schopnosti nepřítele trefil úderem zbraní...", vJmeno);
            }
            else
            {
                Console.WriteLine("{0} při první části schopnosti nepřesně udeřil nepřítele zbraní...", vJmeno);
            }
            if (poskozeni < 0)
                poskozeni = 0;
            Console.WriteLine();
            Thread.Sleep(350);
            Console.WriteLine("První útok schopnosti způsobil {0} poškození!", poskozeni);
            Console.WriteLine();
            Console.ResetColor();           
           
        }

        private void SpecialniSchopnostZlodeje() // to, co se stane při speciální schopnosti
        {
            DndKostka kostka = new DndKostka();
            Thread.Sleep(250);
            if(ZLock)
            {
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine($"{vJmeno} není fyzicky připraven na použití této schopnosti, zkuste nejdříve zaútočit, nebo použít Vaši rasovou schopnost...");
                poskozeni = 0;
                return;
            }
            kostka.KostkyArt();
            kostka.HodKostkou();
            Console.WriteLine();
            Thread.Sleep(250);
            Console.ResetColor();
            uspesnaSchopnost = vStesti + vObratnost + kostka.VysledekHodu();
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (uspesnaSchopnost >= 9)
            {
                ZLock = true;
                Console.WriteLine("{0} udělal rychlý výpadek a tak uspěl v Mistrovství Hbitosti...", vJmeno);
                Console.ResetColor();
                Thread.Sleep(200);
                ZRedukovanyUtokPrubeh();              
                Console.WriteLine();
                kostka.KostkyArt();            
                Hod_HK(kostka);                            
                kostka.VysledekHodu();
                Console.WriteLine();              
                Console.ForegroundColor = ConsoleColor.Yellow;               
                kritickyZasah = vUtocnaHodnota + 3 * kostka.VysledekHodu();
                Console.WriteLine("U druhého útoku {1} provedl útok z přemetu a nepřítel tak utrpěl {0} poškození.", kritickyZasah, vJmeno);
                Thread.Sleep(200);
                poskozeni += kritickyZasah;
            }
            else
            {
                Console.WriteLine("{0} se pokusil o výpadek, ale bohužel to nevyšlo...", vJmeno);
                poskozeni = 0;
            }

            Console.WriteLine();
            Thread.Sleep(350);
            Console.WriteLine("Mistrovství Hbitosti celkem způsobilo {0} poškození!", poskozeni);           
            Console.ResetColor();                      
        }

        public void ZlodejovaSchopnost() // už celá funkce, která provede schopnost se vším všudy
        {
            Console.Clear();
            ZlodejAnimace();
            SpecialniSchopnostZlodeje();
           
        }

        //**********************************************************************************
        public void UtokZlodeje()
        {
            Console.Clear();
            ZUtokAnimace();
            ZUtokPrubeh();
            
        }
    }
}