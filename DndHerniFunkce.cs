using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using static System.Console;

namespace DnD_Hra
{
    internal class DndHerniFunkce
    {
        private static string oznameniRasy; // podle toho zjistujeme co si hráč vybral
        private static string oznameniPovolani;
        public static bool _UtokNaSpolecnika = false;
        public static BasePostava basePostavaSouboj = null;
        public static BasePostava basePostavaDung = null;
        private static void ObnovaSpolecnika()
        {

            VasePostava.spolecnik.sZdravi = VasePostava.spolecnik.maxZdravi;
            if (VasePostava.spolecnik.maManu)
                VasePostava.spolecnik.pocetMany = VasePostava.spolecnik.maxMana;
            if (VasePostava.spolecnik != null)
                VasePostava.spolecnik = null;


        }
        private static void ObnovaSpolecnikaBezNullovani()
        {

            VasePostava.spolecnik.sZdravi = VasePostava.spolecnik.maxZdravi;
            if (VasePostava.spolecnik.maManu)
                VasePostava.spolecnik.pocetMany = VasePostava.spolecnik.maxMana;
        }
        public static void SpustHlavniMenu()
        {
            MusicPlayer.nynejsiSong = MusicPlayer.DragonTaming;
            MusicPlayer.nynejsiSong.Play();              
            string plakat = @"⠀
                                               ⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                                ⠀⠀⠀⠀<Menu se ovládá pomocí šipek nahoru a dolů>";

            string[] moznosti = { "Hrát hru", "Důležité informace před hraním", "Poděkování", "Ukončit hru" }; // inicializace menu z menu classy
            Menu hlavniMenu = new Menu(plakat, moznosti.ToList(), ConsoleColor.Red);
            int vybranyIndex = hlavniMenu.NavratIndexu();
            MusicPlayer.nynejsiSong.Stop();
            MusicPlayer.nynejsiSong.Dispose();
           

            switch (vybranyIndex) // co se stane při vybrání možností
            {
                case 0:
                    Console.Clear();
                    break;

                case 1:
                    DuleziteInfo();
                    SpustHlavniMenu();
                    break;
                case 2:
                    Podekovani();
                    SpustHlavniMenu();
                    break;
                case 3:
                    KonecHryMenu();
                    break;
            }
        }

        private static void KonecHryMenu() // konec hry v menu
        {
            Clear();
            WriteLine();
            ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Zvolili jste konec hry, děkuji za hraní Live Thrice!");
            Thread.Sleep(150);
            WriteLine();
            Console.WriteLine("stiskněte kteroukoliv klávesu pro ukončení...");
            Console.ReadKey(true);
            ResetColor();
            Environment.Exit(0);
        }

        private static void DuleziteInfo() //důležité info
        {
            Clear();
            if(OperatingSystem.IsWindows())
            {
                ForegroundColor = ConsoleColor.Blue;
                WriteLine();
                WriteLine("Vypadá to, že Vás operační systém je windows. To znamená následující:");
                Thread.Sleep(500);
                WriteLine();
                WriteLine("Konzolové okno bylo nastaveno na doporučenou velikost (Výška 35px, Šířka 140px). Velikost je důležitá kvůli ASCII ilustracím a textu.");
                Thread.Sleep(500);
                WriteLine();
                WriteLine("Velikost konzole můžete libovolně měnit, může se ale stát, že text a ilustrace budou zobrazeny nesprávně.");
                Thread.Sleep(500);
                WriteLine();
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine("Také doporučujeme přenastavit Font konzole. Při zvolení nesprávného fontu se ilustrace nebudou zobrazovat tak, jak mají.");
                Thread.Sleep(500);
                WriteLine();
                WriteLine("Font na konzoli přenastavíte následovně:");
                Thread.Sleep(500);
                WriteLine();
                WriteLine("Pravý klik na horní lištu konzole -> vlastnosti -> písmo");
                Thread.Sleep(500);
                WriteLine();
                WriteLine("Doporučený font je Cascadia (libovolná), nebo kterýkoliv font, schopen zobrazení ilustrací. Preferována je Cascadia, vypadá lépe.");
                Thread.Sleep(500);
                WriteLine();
                WriteLine("Doporučená velikost Fontu je potom mezi 16 a 20 (18 je zlatý střed).");
                Thread.Sleep(500);                
                GameplayLokaci_1.Tlacitko();

            }
            else
            {
                ForegroundColor = ConsoleColor.Blue;
                WriteLine();
                WriteLine("Vypadá to, že Vás operační systém není windows. To znamená následující:");
                Thread.Sleep(500);
                WriteLine();
                WriteLine("Konzolové okno doporučujeme nastavit na doporučenou velikost (Výška 35px, Šířka 140px)");
                Thread.Sleep(500);
                WriteLine();
                WriteLine("Tato velikost je důležitá kvůli správnému zobrazení ilustrací a textu.");
                Thread.Sleep(500);
                WriteLine();           
                WriteLine("Základní velikost bývá 30/120. Okno kvůli OS, který není windows, nelze přenastavit automaticky. Bude to tedy třeba provést manuálně.");
                Thread.Sleep(500);
                WriteLine();
                WriteLine("Velikost konzole můžete samozřejmě libovolně měnit, může se ale stát, že text a ilustrace budou zobrazeny nesprávně.");
                Thread.Sleep(500);
                WriteLine();
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine("Také doporučujeme přenastavit Font konzole. Při zvolení nesprávného fontu se ilustrace nebudou zobrazovat tak, jak mají.");
                Thread.Sleep(500);
                WriteLine();
                WriteLine("Font na konzoli přenastavíte následovně:");
                Thread.Sleep(500);
                WriteLine();
                WriteLine("Pravý klik na horní lištu konzole -> vlastnosti -> písmo");
                Thread.Sleep(500);
                WriteLine();
                WriteLine("Doporučený font je Cascadia (libovolná), nebo kterýkoliv font, schopen zobrazení ilustrací. Preferována je Cascadia, vypadá lépe.");
                Thread.Sleep(500);
                WriteLine();
                WriteLine("Doporučená velikost Fontu je potom mezi 16 a 20 (18 je zlatý střed).");
                Thread.Sleep(500);              
                GameplayLokaci_1.Tlacitko();
            }
            TestAscii();
            void TestAscii()
            {
                Clear();
                Menu menu = new Menu("Přejete si vyzkoušet, jestli Váš font správně zobrazí ASCII ilustrace?", new List<string> { "Ano, vyzkoušet", "Ne, nezkoušet" }, ConsoleColor.Cyan);
                int m = menu.NavratIndexu();
                if (m == 0)
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine();
                    WriteLine("Nyní se zobrazí žlutá krychle. Znaky jsou tečky, pokud vidíte otazníky, nebo jiné symboly, font není kompatibiní.");
                    GameplayLokaci_1.Tlacitko();
                    ForegroundColor = ConsoleColor.Yellow;
                    WriteLine(@"⠀

                                ⠀⢀⣤⣾⣿⣿⣶⣶⣤⣤⣄⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣴⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣶⣤⣤⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣶⣦⣤⣄⣀⡀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⢀⣤⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⠀
                ⠀⠀⠀ ⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀
                ⠀⠀⠀ ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀
                ⠀⠀⠀ ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀
                ⠀⠀⠀ ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀
                ⠀⠀⠀ ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀
                ⠀⠀⠀ ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀
                ⠀⠀⠀ ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀
                ⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀
                ⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀
                ⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀
                ⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀
                ⠀⠀⠀⠀⢹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠀⠀⠀⠀
                ⠀⠀⠀⠀⠸⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠋⠁⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠉⠙⠛⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠛⠁⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠛⠿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠛⠿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⠻⢿⣿⣿⣿⣿⡿⠟⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠙⠉⠀⠀⠀⠀⠀⠀⠀⠀");
                    GameplayLokaci_1.Tlacitko();

                }
                else return;
            }
        }                    //**********************************************************************************
        public static void KonecHrySmrtSouboj() // konec hry při zabití
        {
            Clear();
            basePostavaDung.ObnovaAtributuPostavy(VasePostava.hracovaPostava);
            basePostavaDung = null;
            if (VasePostava.spolecnik != null)
                ObnovaSpolecnika();
            if (VasePostava._aktualniNepritel != null)
                VasePostava._aktualniNepritel = null;
            VasePostava.OdebraniNeboSmrt();
            Lokace.VyberoveMenu();
        }
        public static void KonecHryMimoSouboj() // konec hry při zabití mimo souboj
        {
            basePostavaDung.ObnovaAtributuPostavy(VasePostava.hracovaPostava);
            basePostavaDung = null;
            if (VasePostava.spolecnik != null)
                ObnovaSpolecnika();
            if (VasePostava._aktualniNepritel != null)
                VasePostava._aktualniNepritel = null;
            VasePostava.OdebraniNeboSmrt();
            Lokace.VyberoveMenu();
        }


        //**********************************************************************************

        private static void VyberRasyText()
        {
            Console.Clear();
            Console.ResetColor();
            ForegroundColor = ConsoleColor.DarkBlue;
            AnimaceTextu("Byli vám představeny všechny rasy a povolání, teď je na čase, aby jste si vybrali svou postavu...");
            AnimaceTextu("Začneme s výberem rasy.");
            Thread.Sleep(150);
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
            Console.ReadKey(true);
        }

        //**********************************************************************************
        public static void VyberRasy(VasePostava vasePostava, Hobit hobit, Elf elf, Kroll kroll) // zde si hráč vybere rasu
        {
            VyberRasyText();
            Console.Clear();
            Console.CursorVisible = false;

            string plakat = @"
                                                   ____
                                                  /\   \
                                                 /  \   \
                                                /    \   \
                                               /      \   \
                                              /   /\   \   \
                                             /   /  \   \   \
                                            /   /    \   \   \
                                           /   /    / \   \   \
                                          /   /    /   \   \   \
                                         /   /    /---------'   \
                                        /   /    /_______________\
                                        \  /                     /
                                         \/_____________________/

                                  <Menu se ovládá pomocí šipek nahoru a dolů>

                                              Vyberte si rasu";

            string[] moznosti = { "Hobit", "Elf", "Kroll" };
            Menu hlavniMenu = new Menu(plakat, moznosti.ToList(), ConsoleColor.DarkGreen);
            int vybranyIndex = hlavniMenu.NavratIndexu();
            Clear();
            switch (vybranyIndex)
            {
                case 0:
                    ForegroundColor = ConsoleColor.DarkYellow;
                    // tady proběhne přiřazení statů závisle na výběru rasy
                    Thread.Sleep(150);
                    AnimaceTextu("Vybrali jste si Hobita!");
                    Thread.Sleep(150);
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
                    Console.ReadKey(true);
                    vasePostava.vObratnost = hobit.rObratnost;
                    vasePostava.vSila = hobit.rSila;
                    vasePostava.vInteligence = hobit.rInteligence;
                    vasePostava.vStesti = hobit.rStesti;
                    VasePostava.hracovaPostava.vZdravi = hobit.rZdravi;
                    vasePostava.RasovaSchopnost = vasePostava.SchopnostHobita;
                    vasePostava.HodnotaRasoveSchopnosti = vasePostava.StatyRasoveSchopnosti;
                    oznameniRasy = "Hobit";
                    break;

                case 1:
                    ForegroundColor = ConsoleColor.Green;
                    Thread.Sleep(150);
                    AnimaceTextu("Vybrali jste si Elfa!");
                    Thread.Sleep(150);
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
                    Console.ReadKey(true);
                    vasePostava.vObratnost = elf.rObratnost;
                    vasePostava.vSila = elf.rSila;
                    vasePostava.vInteligence = elf.rInteligence;
                    vasePostava.vStesti = elf.rStesti;
                    VasePostava.hracovaPostava.vZdravi = elf.rZdravi;
                    vasePostava.RasovaSchopnost = vasePostava.SchopnostElfa;
                    vasePostava.HodnotaRasoveSchopnosti = vasePostava.StatyRasoveSchopnosti;

                    oznameniRasy = "Elf";
                    break;

                

                case 2:
                    ForegroundColor = ConsoleColor.Red;
                    Thread.Sleep(150);
                    AnimaceTextu("Vybrali jste si Krolla!");
                    Thread.Sleep(150);
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
                    Console.ReadKey(true);
                    vasePostava.vObratnost = kroll.rObratnost;
                    vasePostava.vSila = kroll.rSila;
                    vasePostava.vInteligence = kroll.rInteligence;
                    vasePostava.vStesti = kroll.rStesti;
                    VasePostava.hracovaPostava.vZdravi = kroll.rZdravi;
                    vasePostava.RasovaSchopnost = vasePostava.SchopnostKrolla;
                    vasePostava.HodnotaRasoveSchopnosti = vasePostava.StatyRasoveSchopnosti;
                    oznameniRasy = "Kroll";
                    break;
            }
        }

        private static void VyberPovolaniText()
        {
            Console.Clear();
            ForegroundColor = ConsoleColor.DarkGreen;
            AnimaceTextu("Úspěšně jste si vybrali rasu, pro kompletaci Vaší postavy zbývá ještě povolání.");

            AnimaceTextu("Je tedy čas na výběr povolání, možnosti jsou následující: ");

            Thread.Sleep(150);
            Console.WriteLine();
            ResetColor();
            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
            Console.ReadKey(true);
        }
        static string nazevSSchopnosti;
        public static void VyberPovolani(VasePostava vasePostava, Valecnik valecnik, Zlodej zlodej, Carodej carodej) // zde je výběr povolání
        {
            VyberPovolaniText();
            Console.Clear();
            Console.CursorVisible = false;

            string plakat = @"
                                        ._____. ._____. ._____. ._____.
                                        | ._. | | ._. | | ._. | | ._. |
                                        | !_| |_|_|_! | | !_| |_|_|_! |
                                        !___| |_______! !___| |_______!
                                        .___|_|_| |_________|_|_| |___.
                                        | ._____| |_____________| |_. |
                                        | !_! | | |         | | ! !_! |
                                        !_____! | |         | | !_____!
                                        ._____. | |         | | ._____.
                                        | ._. | | |         | | | ._. |
                                        | !_| |_|_|_________| |_|_|_! |
                                        !___| |_____________| |_______!
                                        .___|_|_| |___. .___|_|_| |___.
                                        | ._____| |_. | | ._____| |_. |
                                        | !_! | | !_! | | !_! | | !_! |
                                        !_____! !_____! !_____! !_____!

                                  <Menu se ovládá pomocí šipek nahoru a dolů>

                                            Vyberte si povolání";

            string[] moznosti = { "Válečník", "Zloděj", "Čaroděj" };
            Menu hlavniMenu = new Menu(plakat, moznosti.ToList(), ConsoleColor.DarkBlue);
            int vybranyIndex = hlavniMenu.NavratIndexu();
            Clear();
            switch (vybranyIndex)
            {
                case 0:
                    ForegroundColor = ConsoleColor.Blue;
                    // přiřazení a sečtení statů z povolání + rasy
                    Thread.Sleep(150);

                    AnimaceTextu("Vybrali jste si válečníka!");
                    vasePostava.vObratnost += valecnik.pObratnost;
                    vasePostava.vSila += valecnik.pSila;
                    vasePostava.vInteligence += valecnik.pInteligence;
                    VasePostava.hracovaPostava.vZdravi += valecnik.pZdravi;
                    vasePostava.vStesti += valecnik.pStesti;
                    vasePostava.vUtocnaHodnota = valecnik.pUtocnaHodnota;
                    vasePostava.vObrannaHodnota = valecnik.pObrannaHodnota;
                    vasePostava.poskozeniZbrane = valecnik.poskozeniZbrane;
                    vasePostava.hodnotaBrneni = valecnik.hodnotaBrneni;
                    vasePostava.maManu = valecnik.maManu;
                    vasePostava.PovolaniSchopnost = vasePostava.ValecnikovaSchopnost;
                    nazevSSchopnosti = "Přímy zásah";
                    vasePostava.Utok = vasePostava.UtokValecnika;
                    vasePostava.ArtHrdiny = valecnik.ArtPovolani;
                    vasePostava.zakladniUtocnaHodnota = valecnik.zakladniUtocnaHodnota;
                    vasePostava.zakladniObrannaHodnota = valecnik.zakladniObrannaHodnota;
                    VasePostava.zbranPostavy = Valecnik.valecnikovaZbran;
                    VasePostava.zbrojPostavy = Valecnik.valecnikovaZbroj;
                    VasePostava.alternativniZbranPostavy = null;
                    VasePostava.vybavenaZbran = Valecnik.valecnikovaZbran;
                    VasePostava.vybavenaZbroj = Valecnik.valecnikovaZbroj;
                    oznameniPovolani = "válečník";
                    break;

                case 1:
                    ForegroundColor = ConsoleColor.Yellow;
                    Thread.Sleep(150);

                    AnimaceTextu("Vybrali jste si zloděje!");
                    vasePostava.vObratnost += zlodej.pObratnost;
                    vasePostava.vSila += zlodej.pSila;
                    vasePostava.vInteligence += zlodej.pInteligence;
                    VasePostava.hracovaPostava.vZdravi += zlodej.pZdravi;
                    vasePostava.vStesti += zlodej.pStesti;
                    vasePostava.vUtocnaHodnota = zlodej.pUtocnaHodnota;
                    vasePostava.vObrannaHodnota = zlodej.pObrannaHodnota;
                    vasePostava.poskozeniZbrane = zlodej.poskozeniZbrane;
                    vasePostava.hodnotaBrneni = zlodej.hodnotaBrneni;
                    vasePostava.maManu = zlodej.maManu;
                    vasePostava.PovolaniSchopnost = vasePostava.ZlodejovaSchopnost;
                    nazevSSchopnosti = "Mistrovství hbitosti";
                    vasePostava.Utok = vasePostava.UtokZlodeje;
                    vasePostava.ArtHrdiny = zlodej.ArtPovolani;
                    vasePostava.zakladniUtocnaHodnota = zlodej.zakladniUtocnaHodnota;
                    vasePostava.zakladniObrannaHodnota = zlodej.zakladniObrannaHodnota;
                    VasePostava.zbranPostavy = Zlodej.zlodejovaZbran;
                    VasePostava.zbrojPostavy = Zlodej.zlodejovaZbroj;
                    VasePostava.alternativniZbranPostavy = null;
                    VasePostava.vybavenaZbran = Zlodej.zlodejovaZbran;
                    VasePostava.vybavenaZbroj = Zlodej.zlodejovaZbroj;
                    oznameniPovolani = "zloděj";
                    break;

                case 2:
                    Thread.Sleep(150);
                    ForegroundColor = ConsoleColor.DarkCyan;
                    AnimaceTextu("Vybrali jste si čarodějě!");
                    vasePostava.vObratnost += carodej.pObratnost;
                    vasePostava.vSila += carodej.pSila;
                    vasePostava.vInteligence += carodej.pInteligence;
                    VasePostava.hracovaPostava.vZdravi += carodej.pZdravi;
                    vasePostava.vStesti += carodej.pStesti;
                    vasePostava.vUtocnaHodnota = carodej.pUtocnaHodnota;
                    vasePostava.vObrannaHodnota = carodej.pObrannaHodnota;
                    vasePostava.poskozeniZbrane = carodej.poskozeniZbrane;
                    vasePostava.hodnotaBrneni = carodej.hodnotaBrneni;
                    vasePostava.maManu = carodej.maManu;
                    VasePostava.hracovaPostava.pocetMany = carodej.pocetMany;
                    vasePostava.PovolaniSchopnost = vasePostava.CarodejovaSchopnost;
                    nazevSSchopnosti = "Vyvolání Ohnivého Elementála";
                    vasePostava.Utok = vasePostava.UtokCarodeje;
                    vasePostava.ArtHrdiny = carodej.ArtPovolani;
                    vasePostava.poskozeniAlternativniZbrane = carodej.poskozeniAlternativniZbrane;
                    vasePostava.altUtocnaHodnota = carodej.altUtocnaHodnota;
                    vasePostava.cenaUtoku = carodej.cenaUtoku;
                    vasePostava.zakladniUtocnaHodnota = carodej.zakladniUtocnaHodnota;
                    vasePostava.zakladniObrannaHodnota = carodej.zakladniObrannaHodnota;
                    VasePostava.zbranPostavy = Carodej.carodejovaZbran;
                    VasePostava.zbrojPostavy = Carodej.carodejovaZbroj;
                    VasePostava.alternativniZbranPostavy = Carodej.carodejovaZalozniZbran;
                    VasePostava.vybavenaZbran = Carodej.carodejovaZbran;
                    VasePostava.vybavenaAltZbran = Carodej.carodejovaZalozniZbran;
                    VasePostava.vybavenaZbroj = Carodej.carodejovaZbroj;
                    oznameniPovolani = "čaroděj";

                    break;
            }

            VasePostava.inventarPostavy.PridejPredmet(VasePostava.zbranPostavy);
            VasePostava.inventarPostavy.PridejPredmet(VasePostava.zbrojPostavy);
            if (VasePostava.alternativniZbranPostavy != null)
                VasePostava.inventarPostavy.PridejPredmet(VasePostava.alternativniZbranPostavy);         
            vasePostava.zdraviPostavy = VasePostava.hracovaPostava.vZdravi;
            vasePostava.maxMana = VasePostava.hracovaPostava.pocetMany;
            VasePostava._seznamSpecialnichSchopnostiHrace.Add(nazevSSchopnosti, vasePostava.PovolaniSchopnost);
            Thread.Sleep(100);
            Console.WriteLine();
            Console.WriteLine("Výborně, výběr Vaší postavy byl úspěšně dokončen, jste {0} {1}!", oznameniRasy, oznameniPovolani);
            Thread.Sleep(150);
            Console.WriteLine();
            ResetColor();
            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
            Console.ReadKey(true);
        }
        public static void VyberJmena(VasePostava vasePostava) // zde proběhne výběr jména
        {
            Console.ResetColor();
            Console.Clear();

            AnimaceTextu("Jediné co zbývá je jméno Vašeho hrdiny, které si vyberete teď. ");

            AnimaceTextu("Zadejte prosím jméno Vašeho hrdiny: ");

            Console.WriteLine();
            ForegroundColor = ConsoleColor.Blue;
            vasePostava.vJmeno = Console.ReadLine();          
            while (JePismenaNeboCisla(vasePostava.vJmeno) == false || vasePostava.vJmeno.Length > 12)
            {
                Console.WriteLine();
                ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ve jméně Vašeho hrdiny lze použít jen písmena nebo čísla a může mít maximálně 12 znaků.");
                Console.WriteLine();
                ForegroundColor = ConsoleColor.Blue;
                vasePostava.vJmeno = Console.ReadLine();
            }

            Thread.Sleep(150);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("Jméno vašeho hrdiny je {0}!", vasePostava.vJmeno);
            Thread.Sleep(100);
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
            Console.ReadKey(true);
        }

        private static bool JePismenaNeboCisla(string s)// kontrola jestli string obsahuje pismena nebo cisla
        {
            foreach (char c in s)
            {
                if (!char.IsLetterOrDigit(c))
                    return false;
            }
            return true;
        }
        public static bool JePismenaNeboCislaNeboMezery(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c))
                    return false;
            }
            return true;
        }


        private static void PredstaveniPovolani() // pro každé povolání v řetězci proběhne jeho představení
        {
            Valecnik valecnik = new Valecnik();
            Zlodej zlodej = new Zlodej();
            Carodej carodej = new Carodej();
            Povolani[] seznamPovolani = { valecnik, zlodej, carodej };

            foreach (Povolani p in seznamPovolani)
            {
                p.PredstaveniPovolani();
            }
        }

        private static void PredstaveniRasy() // to stejné, ale pro každou rasu
        {
            
            Elf elf = new Elf();
            Kroll kroll = new Kroll();
            Hobit hobit = new Hobit();
            Rasa[] seznamRas = { elf, kroll, hobit };

            foreach (Rasa r in seznamRas)
            {
                r.PredstaveniRasy();
            }
        }

        public static void IntrodukceRasAPovolani() // celek, kde proběhne proces představení
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            AnimaceTextu("Vítejte v představení Povolání a Ras.");

            AnimaceTextu("V této sekci se zobrazí důležité informace o Povoláních a Rasách. Na konci úvodu si vyberete své vlastní.");

            AnimaceTextu("Váš Hrdina bude kombinací Povolání a Rasy. Povolání má své základní atributy, které potom budou upraveny Rasou.");

            AnimaceTextu("Kromě toho Vaše postava získá schopnosti vybraných Ras a Povolání, stejně jako útočný styl vybraného Povolání.");

            AnimaceTextu("Buďte obezřetní, ne každé Povolání a Rasa spolu fungují, volba je však poté 100% na Vás.");

            AnimaceTextu("Začneme Povoláními, to důležité o daném povolání se vždy zobrazí na konzoli.");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
            Console.ReadKey();
            Console.Clear();
            Console.ResetColor();
            PredstaveniPovolani();
            Thread.Sleep(100);
            AnimaceTextu("Nyní se přesuneme k introdukci Ras - Rasy mají své modifikátory statů a také unikátní schopnosti.");

            AnimaceTextu("To důležité o každé Rase se zobrazí na konzoli.");

            Thread.Sleep(150);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
            Console.ReadKey(true);
            Console.Clear();
            Console.ResetColor();
            PredstaveniRasy();
        }

        public static void AnimaceTextu(string text)
        {
            Console.WriteLine();

            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Spacebar)
                    {
                        Console.Write(text.Substring(i + 1));
                        while (Console.KeyAvailable)
                        { // buuff gone
                            Console.ReadKey(true);
                            Thread.Sleep(50);
                        }
                        break;
                    }
                }
            }

            Console.WriteLine();
        }

        private static bool PovznesenH = false;
        private static bool PovznesenN = false;
        private static bool PovznesenS = false;
        private static void TrinketReset()
        {
            if (hrdinaTrinket)
                hrdinaTrinket = false;
            if (enemyTrinket)
                enemyTrinket = false;
        }
        public static bool enemyTrinket = false;
        public static bool hrdinaTrinket = false;
        private static void ResetStavuPov()
        {
            if (PovznesenH == true)
                PovznesenH = false;
            if (PovznesenN == true)
                PovznesenN = false;
            if (PovznesenS == true)
                PovznesenS = false;
        }
        // 1 - parametr hrdiny hráče, 2 - stvoření jakožto nepřítel, 3 - je toto samostatný souboj? pokud ne, na konci neregenurejeme zdraví a manu, ponecháváme buffy
        // 
        public static void Souboj(VasePostava vasePostava, Stvoreni stvoreni, bool multisouboj, bool ZobrazMenu, string nazevStvoreni = null)
        {

            // funkce souboje
            bool vypisTlacitka = true;
            if (nazevStvoreni == null)
                nazevStvoreni = stvoreni.nazevStvoreni;
            Random random = new Random();
            int schopnostTimerMonstra = 0; // aby monstrum neudělalo 2x za sebou speciálku
            int schopnostTimerBuddyho = 0; // aby buddy -||-
            int pocetKol = 0;
            VasePostava._aktualniNepritel = stvoreni;
            Console.WriteLine();
            Thread.Sleep(200);
            Console.ResetColor();
            Console.Clear();
            if (ZobrazMenu)
            {

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("...stiskněte libovolné tlačítko pro otevření přehledového menu před soubojem...");
                Console.ReadKey(true);
                Console.ResetColor();
                Console.Clear();
                Menu.VedlejsiMenuPostavy();
            }

            if (basePostavaSouboj == null)// Base postava (restorace atributů) musí být iniciována až po equip menu
            {
                basePostavaSouboj = new BasePostava(vasePostava);
            }
            //-> předsatavení účastníků souboje, hrdina vs monstrum
            Console.Clear();
            vasePostava.ArtHrdiny();
            Thread.Sleep(3500);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@"
                 _______________________________________________________
                /\                                                      \
            (O)===)><><><><><><><><><><><><><><><><><><><><><><><><><><><)==(O)
                \/''''''''''''''''''''''''''''''''''''''''''''''''''''''/
                (                                                    (
                 )                                                    )
                (                                                    (
                 )                                                    )

                (                                                     (
                 )                                                     )
                (                                                     (
                 )                                                     )
                                 _  _____ _______ __ _____
                 )              | |/ / -_) __(_-</ // (_-<             (
                (               |___/\__/_/ /___/\_,_/___/              )

                (                                                      (
                 )                                                      )
                (                                                      (
                 )                                                      )

                (                                                      (
                 )                                                      )
                (                                                      (
                /\''''''''''''''''''''''''''''''''''''''''''''''''''''''\
            (O)===)><><><><><><><><><><><><><><><><><><><><><><><><><><><)==(O)
                \/______________________________________________________/
                                    ");
            Console.ResetColor();
            Thread.Sleep(3500);
            Console.Clear();
            stvoreni.ArtStvoreni();
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Začíná souboj...");
            Console.WriteLine();
            Thread.Sleep(1000);
            // soupis záklandích statů obou účastněných
            _VypisStatuZucastnenych();
            void _VypisStatuZucastnenych()
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Základní staty účastníků jsou následující: ");
                for (int i = 0; i < Console.WindowWidth; i++)
                {
                    Console.Write("=");
                }
                Console.WriteLine(@"
                     {0}:

                     Síla: {1}
                     Obratnost: {2}
                     Inteligence: {3}
                     Štěstí: {4}
                     Zdraví: {5}
                     Útočná hodnota: {6}
                     Obranná hodnota: {7}
                     Alternativní útočná hodnota: {8}
                     Společník: {9}
                     Počet many: {10}
                     Šance na úhyb: {11}
                     Šance na Kritický zásah: {12}
                     Šance na Stav Povznesenosti/Povznesen?: {13}/{14}
                     Šance na prolomení: {15}", vasePostava.vJmeno, vasePostava.vSila, vasePostava.vObratnost, vasePostava.vInteligence
                                            , vasePostava.vStesti, VasePostava.hracovaPostava.vZdravi, vasePostava.vUtocnaHodnota, vasePostava.vObrannaHodnota,
                                            VasePostava.alternativniZbranPostavy != null ? vasePostava.altUtocnaHodnota : "Povolání nemá alternativní zbraň",
                                            VasePostava.spolecnik != null ? VasePostava.spolecnik.nazevStvoreni : "Nemá společníka", vasePostava.maManu == true ? vasePostava.pocetMany : "Postava nemá manu",
                                            (VasePostava.hracovaPostava.vObratnost > 0) ? $"{VasePostava.hracovaPostava.vObratnost * 2}%" : "0%",
                                            (VasePostava.hracovaPostava.vStesti > 0) ? $"{VasePostava.hracovaPostava.vStesti * 2}%" : "0%", (VasePostava.hracovaPostava.vInteligence > 0) ? $"{VasePostava.hracovaPostava.vInteligence*2}%" : "0%",
                                             (PovznesenH == true) ? "Ano" : "Ne", (VasePostava.hracovaPostava.vSila > 0)?$"{VasePostava.hracovaPostava.vSila*2}%":"0%");
                for (int i = 0; i < Console.WindowWidth / 2; i++)
                {
                    Console.Write("=");
                }
                Console.ForegroundColor = ConsoleColor.Red; // Set a different color
                for (int i = Console.WindowWidth / 2; i < Console.WindowWidth; i++)
                {
                    Console.Write("=");
                }

                Console.WriteLine(@"
                    {0}:

                    Síla: {1}
                    Obratnost: {2}
                    Inteligence: {3}
                    Štěstí: {4}
                    Zdraví: {5}
                    Útočná hodnota: {6}
                    Obranná hodnota: {7}
                    Šance na úhyb: {8}
                    Šance na kritický zásah: {9}
                    Šance na Stav Povznesenosti/Povznesen?: {10}/{11}
                    Šance na prolomení: {12}", stvoreni.nazevStvoreni, stvoreni.sSila, stvoreni.sObratnost, stvoreni.sInteligence, stvoreni.sStesti, stvoreni.sZdravi, stvoreni.sUtocnaHodnota,
                    stvoreni.sObrannaHodnota, (stvoreni.sObratnost > 0) ? $"{stvoreni.sObratnost * 2}%" : "0%", (stvoreni.sStesti > 0) ? $"{stvoreni.sStesti * 2}%" : "0%",
                    (stvoreni.sInteligence > 0) ? $"{stvoreni.sInteligence*2}%" : "0%", (PovznesenN == true) ? "Ano" : "Ne",
                    (stvoreni.sSila > 0) ? $"{stvoreni.sSila*2}%" : "0%");
                for (int i = 0; i < Console.WindowWidth; i++)
                {
                    Console.Write("=");
                }               
                Thread.Sleep(100);
                Console.ResetColor();              
                Console.WriteLine("stiskněte libovolné tlačítko pro započatí souboje...");
                Console.ReadKey(true);
                Console.ResetColor();
                Console.Clear();

            }
            // specialni predmety check
            if(!hrdinaTrinket)
                SpecialniPrCheckHrdina();
            if (!enemyTrinket)
                SpecialniPrCheckEnemy();
            // postih za overcarry
            SoubojovyPostihZaLimit66();
            //Povzneseni ucatniku
            if (!PovznesenH)
                StavPoveznesenosti(1);
            if (!PovznesenN)
                StavPoveznesenosti(2);
            if (!PovznesenS)
                StavPoveznesenosti(3);
            while (VasePostava.hracovaPostava.vZdravi > 0 && stvoreni.sZdravi > 0)
            {
                Bitva();
            }
            void Bitva()
            {
                PrepalStatu();
                Console.Clear();
                Console.CursorVisible = false;
                Console.OutputEncoding = Encoding.Unicode;
                Console.ResetColor();
                Thread.Sleep(100);
                string výzva = @"

                                                                                    `-¸.•*¨) ¸.•*¨)`-¸.•*¨)¸.•*¨)
                                                                                    .•´ (¸.•´ .•´ ¸¸.•¨
    ,_._._._._._._._._|__________________________________________________________,
    |_|_|_|_|_|_|_|_|_|_________________________________________________________/
                                        .______________________________________________________|_._._._._._._._._._.
                                         \_____________________________________________________|_#_#_#_#_#_#_#_#_#_|

    `-¸.•*¨) ¸.•*¨)`-¸.•*¨)¸.•*¨)
    .•´ (¸.•´ .•´ ¸¸.•¨
                                                 BOJOVÉ MENU - akce proti nepříteli

                                                  <Vyberte možnost pomocí šipek>

                                        ";

                string[] moznosti = { "Útok", "Speciální schopnost povolání", "Speciální schopnost rasy", "Použít předmět z inventáře", "Zobrazit atributy účastněných", "Detaily Vašeho společníka", "Nedělat nic" };// menu souboje

                Menu bojoveMenu = new Menu(výzva, moznosti.ToList(), ConsoleColor.DarkCyan);
                int vybranyIndex = bojoveMenu.NavratIndexu();
                Console.CursorVisible = true;
                Console.Clear();
                switch (vybranyIndex)// podle volby proběhne první akce postavy
                {
                    case 0:
                        pocetKol = 1;
                        vasePostava.Utok();
                        Prolomeni(1);
                        KritickyZasah(1);
                        Uhyb(2);
                        if (vasePostava.PoskozeniUtoku() >= stvoreni.sObrannaHodnota)// pokud je hodnota útoku < obranná hodnota, jakoby neproběhl
                        {
                            stvoreni.sZdravi = stvoreni.sZdravi - vasePostava.PoskozeniUtoku() + stvoreni.sObrannaHodnota;
                        }

                        if (stvoreni.sZdravi < 0)// nehcceme zdraví v záporných číslech
                        {
                            stvoreni.sZdravi = 0;
                        }
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        if (vasePostava.PoskozeniUtoku() > 0)
                        {
                            Console.WriteLine("Po započtení obranné hodnoty má {1} {0} zdraví.", stvoreni.sZdravi, nazevStvoreni);
                        }
                        else
                        {
                            Console.WriteLine("Touto akcí nebylo uděleno poškození, tudíž {1} má {0} zdraví.", stvoreni.sZdravi, nazevStvoreni);
                        }
                        if (vasePostava.vZdravi > 0 && stvoreni.sZdravi > 0)
                        {
                            if (VasePostava.zbranPostavy.schopnostZbrane != null && VasePostava.hracovaPostava.poskozeni > 0)
                            {
                                VasePostava.zbranPostavy.schopnostZbrane(true);// pokud je zbraň očarovaná, proved její schopnost.
                            }
                            if (stvoreni.zbrojStvoreni.schopnostZbroje != null && VasePostava.hracovaPostava.poskozeni > 0)
                            {
                                stvoreni.zbrojStvoreni.schopnostZbroje(true);
                            }

                        }
                        Console.ResetColor();
                        Thread.Sleep(150);
                        Console.WriteLine();
                        Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
                        Console.ReadKey(true);
                        break;

                    case 1:
                        pocetKol = 1;
                        var vypisSpecShopnosti = VasePostava._seznamSpecialnichSchopnostiHrace.Select(p => p.Key).ToList();
                        Menu vyberSchopnosti = new("Vyberte si schopnost, kterou chcete použít: ", vypisSpecShopnosti, ConsoleColor.Blue);
                        int vb = vyberSchopnosti.NavratIndexu();
                        var NazevSchopnosti = vypisSpecShopnosti[vb];
                        var vybranaSchopnost = VasePostava._seznamSpecialnichSchopnostiHrace[NazevSchopnosti];
                        vybranaSchopnost.Invoke();
                        Prolomeni(1);
                        KritickyZasah(1);
                        Uhyb(2);
                        if (vasePostava.PoskozeniUtoku() >= stvoreni.sObrannaHodnota)
                        {
                            stvoreni.sZdravi = stvoreni.sZdravi - vasePostava.PoskozeniUtoku() + stvoreni.sObrannaHodnota;
                        }

                        if (stvoreni.sZdravi < 0)
                        {
                            stvoreni.sZdravi = 0;
                        }
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        if (vasePostava.PoskozeniUtoku() > 0)
                        {
                            Console.WriteLine("Po započtení obranné hodnoty má {1} {0} zdraví.", stvoreni.sZdravi, nazevStvoreni);
                        }
                        else
                        {
                            Console.WriteLine("Touto akcí nebylo uděleno poškození, tudíž {1} má {0} zdraví.", stvoreni.sZdravi, nazevStvoreni);
                        }
                        if (vasePostava.vZdravi > 0 && stvoreni.sZdravi > 0)
                        {
                            if (VasePostava.zbranPostavy.schopnostZbrane != null && VasePostava.hracovaPostava.poskozeni > 0)
                            {
                                VasePostava.zbranPostavy.schopnostZbrane(true);// pokud je zbraň očarovaná, proved její schopnost.
                            }
                            if (stvoreni.zbrojStvoreni.schopnostZbroje != null && VasePostava.hracovaPostava.poskozeni > 0)
                            {
                                stvoreni.zbrojStvoreni.schopnostZbroje(true);
                            }

                        }
                        Console.ResetColor();
                        Thread.Sleep(150);
                        Console.WriteLine();
                        Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
                        Console.ReadKey(true);
                        break;

                    case 2:
                        pocetKol = 1;
                        vasePostava.RasovaSchopnost();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Touto akcí nebylo uděleno poškození, tudíž {1} má {0} zdraví.", stvoreni.sZdravi, nazevStvoreni);
                        Console.ResetColor();
                        Thread.Sleep(150);
                        Console.WriteLine();
                        Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
                        Console.ReadKey(true);
                        break;

                    case 3:
                        pocetKol = 0;
                        while (true)
                        {
                            var listInventare = VasePostava.inventarPostavy.ListInventare().Where(p => p is Pouzitelne).GroupBy(p => p.ID).Select(l => l.First()).ToList();
                            var vypisPouzitelnych = listInventare.Select(p => p.nazevPredmetu + ($" ({p.pocetPredmetu(VasePostava.inventarPostavy)})")).ToList();
                            vypisPouzitelnych.Add("Odejít z inventáře");
                            Menu iMenu = new Menu("Vyberte předmět, který chcete použít:", vypisPouzitelnych, ConsoleColor.Yellow);
                            int volba = iMenu.NavratIndexu();
                            if (volba == vypisPouzitelnych.Count - 1)
                                break;
                            Pouzitelne vybranyPredmet = (Pouzitelne)listInventare[volba];
                            vybranyPredmet.FunkcePouzitiPredmetu();

                        }
                        break;

                    case 4:
                        pocetKol = 0;
                        _VypisStatuZucastnenych();
                        break;
                    case 5:
                        pocetKol = 0;
                        Clear();
                        if(VasePostava.spolecnik == null)
                        {
                            ForegroundColor = ConsoleColor.Red;
                            WriteLine();
                            WriteLine("Vyapdá to, že zatím nemáte žádného společníka...");
                            GameplayLokaci_1.Tlacitko();
                            break;                        
                        }
                        ForegroundColor = ConsoleColor.Green;
                        for (int i = 0; i < WindowWidth; i++)
                            Write("=");
                        ForegroundColor = ConsoleColor.Yellow;
                        WriteLine($@"    
                                        Název společníka: {VasePostava.spolecnik.nazevStvoreni}

                                        Zdraví: {VasePostava.spolecnik.sZdravi}
                                        
                                        Síla: {VasePostava.spolecnik.sSila}
                                        Obratnost: {VasePostava.spolecnik.sObratnost}
                                        Inteligence: {VasePostava.spolecnik.sInteligence}
                                        Štěstí: {VasePostava.spolecnik.sStesti}

                                        Útočná hodnota: {VasePostava.spolecnik.sUtocnaHodnota}
                                        Obranná hodnota: {VasePostava.spolecnik.sObrannaHodnota}

                                        Šance na úhyb: {(VasePostava.spolecnik.sObratnost>0 ?VasePostava.spolecnik.sObratnost*2 +"%":"0%")}
                                        Šance na kritický zásah: {(VasePostava.spolecnik.sStesti > 0 ? VasePostava.spolecnik.sStesti * 2 + "%" : "0%")}
                                        Šance na Povznesení/Povznesen? {(VasePostava.spolecnik.sInteligence > 0 ? VasePostava.spolecnik.sInteligence*2 + "%" : "0%")}/{(PovznesenS?"Ano":"Ne")}
                                        Šance na prolomení: {(VasePostava.spolecnik.sSila > 0 ? VasePostava.spolecnik.sSila * 2 + "%" : "0%")}");
                        ForegroundColor = ConsoleColor.Green;
                        for (int i = 0; i < WindowWidth; i++)
                            Write("=");
                        GameplayLokaci_1.Tlacitko();
                        break;
                    case 6:
                        pocetKol = 1;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Rozhodli jste se v tomto kole nic nedělat...");
                        Console.ResetColor();
                        Thread.Sleep(150);
                        Console.WriteLine();
                        Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
                        Console.ReadKey(true);
                        break;
                }

                if (stvoreni.sZdravi > 0 && pocetKol == 1)// jestliže nepřítel žije, je na řadě
                {
                    Console.Clear();
                    int naKohoUtociNepritel = random.Next(0, 2);//  1 - útočí na spolecnika
                    int vyberIndexuMonstra = random.Next(0, 2);
                    if (schopnostTimerMonstra == 1)// timer té schopnosti, aby nebyla 2x za sebou
                    {
                        vyberIndexuMonstra = 0;
                        schopnostTimerMonstra = 0;
                    }
                    if (VasePostava.spolecnik != null && naKohoUtociNepritel == 1) // pokud existuje společník a náhodně padla 1 (z 0 a 1), jde po společníkovi
                    {
                        _UtokNaSpolecnika = true;
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Teď je na řadě Váš nepřítel, {0}, útočící na Vašeho společníka...", nazevStvoreni);
                        Console.ResetColor();
                        Thread.Sleep(150);
                        Console.WriteLine();
                        Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
                        Console.ReadKey(true);
                        switch (vyberIndexuMonstra)
                        {
                            case 0:
                                stvoreni.UtokStvoreni();
                                Prolomeni(2);
                                KritickyZasah(2);                               
                                Uhyb(3);
                                if (stvoreni.PoskozeniStvoreni() >= VasePostava.spolecnik.sObrannaHodnota)// stejně jak u hráče
                                {
                                    VasePostava.spolecnik.sZdravi = VasePostava.spolecnik.sZdravi - stvoreni.PoskozeniStvoreni() + VasePostava.spolecnik.sObrannaHodnota;
                                }

                                if (VasePostava.spolecnik.sZdravi < 0)
                                {
                                    VasePostava.spolecnik.sZdravi = 0;
                                }
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                if (stvoreni.PoskozeniStvoreni() > 0)
                                {
                                    Console.WriteLine("Po započtení obranné hodnoty má Váš společník {0} zdraví.", VasePostava.spolecnik.sZdravi);
                                }
                                else
                                {
                                    Console.WriteLine("Touto akcí nebylo uděleno poškození, tudíž Váš společník má {0} zdraví.", VasePostava.spolecnik.sZdravi);
                                }
                                if (stvoreni.sZdravi > 0 && VasePostava.spolecnik.sZdravi > 0)
                                {

                                    if (VasePostava._aktualniNepritel.zbranStvoreni.schopnostZbrane != null && VasePostava._aktualniNepritel.poskozeni != 0)
                                    {
                                        VasePostava._aktualniNepritel.zbranStvoreni.schopnostZbrane(false);// pokud je zbraň očarovaná, proved její schopnost.
                                    }
                                }
                                Console.ResetColor();
                                break;

                            case 1:
                                schopnostTimerMonstra++;
                                stvoreni.SchopnostStvoreni();
                                Prolomeni(2);
                                KritickyZasah(2);
                                Uhyb(3);
                                if (stvoreni.PoskozeniStvoreni() >= VasePostava.spolecnik.sObrannaHodnota)
                                {
                                    VasePostava.spolecnik.sZdravi = VasePostava.spolecnik.sZdravi - stvoreni.PoskozeniStvoreni() + VasePostava.spolecnik.sObrannaHodnota;
                                }

                                if (VasePostava.spolecnik.sZdravi < 0)
                                {
                                    VasePostava.spolecnik.sZdravi = 0;
                                }
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                if (stvoreni.PoskozeniStvoreni() > 0)
                                {
                                    Console.WriteLine("Po započtení obranné hodnoty má Váš společník {0} zdraví.", VasePostava.spolecnik.sZdravi);
                                }
                                else
                                {
                                    Console.WriteLine("Touto akcí nebylo uděleno poškození, tudíž Váš společník má {0} zdraví.", VasePostava.spolecnik.sZdravi);
                                }
                                if (stvoreni.sZdravi > 0 && VasePostava.spolecnik.sZdravi > 0)
                                {

                                    if (VasePostava._aktualniNepritel.zbranStvoreni.schopnostZbrane != null && VasePostava._aktualniNepritel.poskozeni != 0)
                                    {
                                        VasePostava._aktualniNepritel.zbranStvoreni.schopnostZbrane(false);// pokud je zbraň očarovaná, proved její schopnost.
                                    }
                                }
                                Console.ResetColor();
                                break;
                        }
                    }
                    else // pokud bud neexistuje spol., nebo existuje a nepadla 1, jde nepřítel po hráči.
                    {
                        _UtokNaSpolecnika = false;
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Teď je na řadě Váš nepřítel, {0}, útočící na Vás...", nazevStvoreni);
                        Console.ResetColor();
                        Thread.Sleep(150);
                        Console.WriteLine();
                        Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
                        Console.ReadKey(true);
                        switch (vyberIndexuMonstra)
                        {
                            case 0:
                                stvoreni.UtokStvoreni();
                                Prolomeni(2);
                                KritickyZasah(2);
                                Uhyb(1);
                                if (stvoreni.PoskozeniStvoreni() >= vasePostava.vObrannaHodnota)// stejně jak u hráče
                                {
                                    VasePostava.hracovaPostava.vZdravi = VasePostava.hracovaPostava.vZdravi - stvoreni.PoskozeniStvoreni() + vasePostava.vObrannaHodnota;
                                }

                                if (VasePostava.hracovaPostava.vZdravi < 0)
                                {
                                    VasePostava.hracovaPostava.vZdravi = 0;
                                }
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                if (stvoreni.PoskozeniStvoreni() > 0)
                                {
                                    Console.WriteLine("Po započtení obranné hodnoty má {0} {1} zdraví.", vasePostava.vJmeno, VasePostava.hracovaPostava.vZdravi);
                                }
                                else
                                {
                                    Console.WriteLine("Tento útok nezpůsobil žádné poškození, tudíž má {0} {1} zdraví.", vasePostava.vJmeno, VasePostava.hracovaPostava.vZdravi);
                                }
                                if (stvoreni.sZdravi > 0 && vasePostava.vZdravi >0)
                                {

                                    if (VasePostava._aktualniNepritel.zbranStvoreni.schopnostZbrane != null && stvoreni.poskozeni > 0)
                                    {
                                        VasePostava._aktualniNepritel.zbranStvoreni.schopnostZbrane(false);// pokud je zbraň očarovaná, proved její schopnost.
                                    }
                                    if (VasePostava.zbrojPostavy.schopnostZbroje != null && stvoreni.poskozeni > 0)
                                    {
                                        VasePostava.zbrojPostavy.schopnostZbroje(false);
                                    }
                                }
                                Console.ResetColor();
                                break;

                            case 1:
                                schopnostTimerMonstra++;
                                stvoreni.SchopnostStvoreni();
                                Prolomeni(2);
                                KritickyZasah(2);
                                Uhyb(1);
                                if (stvoreni.PoskozeniStvoreni() >= vasePostava.vObrannaHodnota)
                                {
                                    VasePostava.hracovaPostava.vZdravi = VasePostava.hracovaPostava.vZdravi - stvoreni.PoskozeniStvoreni() + vasePostava.vObrannaHodnota;
                                }

                                if (VasePostava.hracovaPostava.vZdravi < 0)
                                {
                                    VasePostava.hracovaPostava.vZdravi = 0;
                                }
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                if (stvoreni.PoskozeniStvoreni() > 0)
                                {
                                    Console.WriteLine("Po započtení obranné hodnoty má {0} {1} zdraví.", vasePostava.vJmeno, VasePostava.hracovaPostava.vZdravi);
                                }
                                else
                                {
                                    Console.WriteLine("Tato schopnost nezpůsobila žádné poškození, tudíž má {0} {1} zdraví.", vasePostava.vJmeno, VasePostava.hracovaPostava.vZdravi);
                                }
                                if (stvoreni.sZdravi > 0 && vasePostava.vZdravi > 0)
                                {

                                    if (VasePostava._aktualniNepritel.zbranStvoreni.schopnostZbrane != null && VasePostava._aktualniNepritel.poskozeni > 0)
                                    {
                                        VasePostava._aktualniNepritel.zbranStvoreni.schopnostZbrane(false);// pokud je zbraň očarovaná, proved její schopnost.
                                    }
                                    if (VasePostava.zbrojPostavy.schopnostZbroje != null && stvoreni.poskozeni > 0)
                                    {
                                        VasePostava.zbrojPostavy.schopnostZbroje(false);
                                    }
                                }
                                Console.ResetColor();
                                break;
                        }
                    }

                    Thread.Sleep(150);
                    Console.WriteLine();
                    Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
                    Console.ReadKey(true);
                    Console.Clear();
                }
                SmrtSpolecnika();



                if (stvoreni.sZdravi > 0 && VasePostava.spolecnik != null && VasePostava.hracovaPostava.vZdravi > 0 && pocetKol == 1)
                {
                    if (VasePostava.spolecnik.sZdravi > 0)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Teď je na řadě Váš společník, útočící na vašeho společného nepřítele...");
                        Console.ResetColor();
                        Thread.Sleep(150);
                        Console.WriteLine();
                        Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
                        Console.ReadKey(true);

                        int vyberIndexuBuddyho = random.Next(0, 2);
                        if (schopnostTimerBuddyho == 1)
                        {
                            vyberIndexuBuddyho = 0;
                            schopnostTimerBuddyho = 0;
                        }
                        switch (vyberIndexuBuddyho)
                        {
                            case 0:
                                VasePostava.spolecnik.UtokStvoreni();
                                Prolomeni(3);
                                KritickyZasah(3);
                                Uhyb(2);
                                if (VasePostava.spolecnik.PoskozeniStvoreni() >= stvoreni.sObrannaHodnota)
                                {
                                    stvoreni.sZdravi = stvoreni.sZdravi - VasePostava.spolecnik.PoskozeniStvoreni() + stvoreni.sObrannaHodnota;
                                }

                                if (stvoreni.sZdravi < 0)
                                {
                                    stvoreni.sZdravi = 0;
                                }
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                if (VasePostava.spolecnik.PoskozeniStvoreni() > 0)
                                {
                                    Console.WriteLine("Po započtení obranné hodnoty má {1} {0} zdraví.", stvoreni.sZdravi, nazevStvoreni);
                                }
                                else
                                {
                                    Console.WriteLine("Touto akcí nebylo uděleno poškození, tudíž {1} má {0} zdraví.", stvoreni.sZdravi, nazevStvoreni);
                                }
                                SmrtSpolecnika();
                                Console.ResetColor();
                                break;

                            case 1:
                                schopnostTimerBuddyho++;
                                VasePostava.spolecnik.SchopnostStvoreni();
                                Prolomeni(3);
                                KritickyZasah(3);
                                Uhyb(2);
                                if (VasePostava.spolecnik.PoskozeniStvoreni() >= stvoreni.sObrannaHodnota)
                                {
                                    stvoreni.sZdravi = stvoreni.sZdravi - VasePostava.spolecnik.PoskozeniStvoreni() + stvoreni.sObrannaHodnota;
                                }

                                if (stvoreni.sZdravi < 0)
                                {
                                    stvoreni.sZdravi = 0;
                                }
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                if (VasePostava.spolecnik.PoskozeniStvoreni() > 0)
                                {
                                    Console.WriteLine("Po započtení obranné hodnoty má {1} {0} zdraví.", stvoreni.sZdravi, nazevStvoreni);
                                }
                                else
                                {
                                    Console.WriteLine("Touto akcí nebylo uděleno poškození, tudíž {1} má {0} zdraví.", stvoreni.sZdravi, nazevStvoreni);
                                }
                                SmrtSpolecnika();
                                Console.ResetColor();
                                break;
                        }
                        //zde
                        if (vypisTlacitka)
                        {
                            Thread.Sleep(150);
                            Console.WriteLine();
                            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
                            Console.ReadKey(true);
                        }
                        else
                            vypisTlacitka = true;

                    }
                }

                if (pocetKol == 1)
                    pocetKol = 0;
            }
            if (VasePostava.hracovaPostava.vZdravi <= 0)// když prohrajete, zemřete
            {

                ForegroundColor = ConsoleColor.Red;
                AnimaceTextu("Zabili Vás...");
                GameplayLokaci_1.Tlacitko();
                Thread.Sleep(250);
                if (VasePostava.inventarPostavy.MaPredmet(VytvorenePredmety.Lektvar_Vzkříšení))
                {
                    ForegroundColor = ConsoleColor.Cyan;
                    Thread.Sleep(500);
                    WriteLine("Moment...máte u sebe lektvar vzkříšení...");
                    WriteLine();
                    Thread.Sleep(400);
                    WriteLine("Tohle ještě není konec!");
                    WriteLine();
                    Thread.Sleep(400);
                    VasePostava.hracovaPostava.vZdravi = VasePostava.hracovaPostava.zdraviPostavy;
                    if (VasePostava.hracovaPostava.maManu)
                    {
                        VasePostava.hracovaPostava.pocetMany = VasePostava.hracovaPostava.maxMana;
                    }
                    Thread.Sleep(150);
                    Console.ResetColor();
                    Console.WriteLine("stiskněte kteroukoliv klávesu pro pokračování...");
                    Console.WriteLine();
                    Console.ReadKey(true);
                    VasePostava.inventarPostavy.OdeberPredmet(VytvorenePredmety.Lektvar_Vzkříšení);
                    Clear();
                    while (VasePostava.hracovaPostava.vZdravi > 0 && stvoreni.sZdravi > 0)
                    {
                        Bitva();
                    }
                    if (VasePostava.hracovaPostava.vZdravi <= 0)
                        KonecHrySmrtSouboj();
                    else
                        Vitezstvi();
                }
                else
                    KonecHrySmrtSouboj();
            }
            else if (VasePostava.hracovaPostava.vZdravi > 0)// pokud vyhrajete, zkontroluje se jestli je tohle poslední souboj
                Vitezstvi();
            void Vitezstvi()
            {

                if (multisouboj == false)
                {
                    ResetStavuPov();
                    basePostavaSouboj.ObnovaAtributuPostavy(vasePostava);
                    basePostavaSouboj = null;
                    if (VasePostava.spolecnik != null && !(VasePostava.spolecnik is Spoluvezen) && !(VasePostava.spolecnik is Eirlys) && !(VasePostava.spolecnik is SkretBojovnik))
                        ObnovaSpolecnika();
                    else if (VasePostava.spolecnik != null && VasePostava.spolecnik is Spoluvezen || VasePostava.spolecnik is Eirlys || VasePostava.spolecnik is SkretBojovnik 
                        || VasePostava.spolecnik is Dryada || VasePostava.spolecnik is RohatyVyhazovac)
                        ObnovaSpolecnikaBezNullovani();
                    if (VasePostava._aktualniNepritel != null)
                        VasePostava._aktualniNepritel = null;
                    UkladaniFunkci.ResetEirlysAbilit();
                    TrinketReset();
                    ResetLektvaru();
                    Ability2Z.bleed = 0;
                }
                else if (multisouboj == true)
                {
                    if (PovznesenN == true)
                        PovznesenN = false;
                    vasePostava.ZLock = true;
                    vasePostava.bodPresnosti = 0;
                    if (VasePostava._aktualniNepritel != null)
                        VasePostava._aktualniNepritel = null;
                    //...
                }
                Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                AnimaceTextu("Gratulace k vítěznému souboji, hrdino!");
                Console.WriteLine();
                Console.ResetColor();
                Thread.Sleep(150);
                Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
                Console.ReadKey(true);
                Console.Clear();
                RabovaniMrtvol(stvoreni, nazevStvoreni);
            }
            void SmrtSpolecnika()
            {
                if (VasePostava.spolecnik != null)// když zemře, může vyvolat dalšího, už společník neutočí
                {
                    if (VasePostava.spolecnik.sZdravi <= 0)
                    {
                        vypisTlacitka = false;
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        AnimaceTextu("Váš společník zemřel. Vždy si ale můžete vyvolat, nebo najít nového!");
                        Console.ResetColor();
                        Thread.Sleep(150);
                        Console.WriteLine();
                        Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
                        Console.ReadKey(true);
                        Console.Clear();
                        ObnovaSpolecnika();
                    }

                }
            }
            // oživení společníků !!
            void PrepalStatu()
            {
                if (vasePostava.vObratnost > 45)
                    vasePostava.vObratnost = 45;
                if (vasePostava.vSila > 50)
                    vasePostava.vSila = 50;
                if (vasePostava.vInteligence > 50)
                    vasePostava.vInteligence = 50;
                if (vasePostava.vStesti > 50)
                    vasePostava.vStesti = 50;
                if (stvoreni.sObratnost > 45)
                    stvoreni.sObratnost = 45;
                if (stvoreni.sSila > 50)
                    stvoreni.sSila = 50;
                if (stvoreni.sInteligence > 50)
                    stvoreni.sInteligence = 50;
                if (stvoreni.sStesti > 50)
                    stvoreni.sStesti = 50;
                if (VasePostava.spolecnik != null)
                {
                    if (VasePostava.spolecnik.sObratnost > 45)
                        VasePostava.spolecnik.sObratnost = 45;
                    if (VasePostava.spolecnik.sSila > 50)
                        VasePostava.spolecnik.sSila = 50;
                    if (VasePostava.spolecnik.sInteligence > 50)
                        VasePostava.spolecnik.sInteligence = 50;
                    if (VasePostava.spolecnik.sStesti > 50)
                        VasePostava.spolecnik.sStesti = 50;
                    if (VasePostava.spolecnik.sObrannaHodnota < 0)
                    VasePostava.spolecnik.sObrannaHodnota = 0;
                    if (VasePostava.spolecnik.sUtocnaHodnota < 0)
                        VasePostava.spolecnik.sUtocnaHodnota = 0;
                }
                if (vasePostava.vObrannaHodnota < 0)
                    vasePostava.vObrannaHodnota = 0;
                if (stvoreni.sObrannaHodnota < 0)
                    stvoreni.sObrannaHodnota = 0;
                if (vasePostava.vUtocnaHodnota < 0)
                    vasePostava.vUtocnaHodnota = 0;
                if (stvoreni.sUtocnaHodnota < 0)
                    stvoreni.sUtocnaHodnota = 0;
            }
            void ResetLektvaru()
            {
                VytvorenePredmety.OhUp = false;
                VytvorenePredmety.OhDown = false;
                VytvorenePredmety.UhUp = false;
                VytvorenePredmety.UhDown = false;
                VytvorenePredmety.SilaL = false;
                VytvorenePredmety.ObratL = false;
                VytvorenePredmety.InteligenceL = false;
                VytvorenePredmety.StestiL = false;
            }
        }
        public static void RabovaniMrtvol(Stvoreni stvoreni, string nazevStvoreni)
        {
            bool vypis = true;

            while (true)
            {
                int volba = HMenu();
                if (volba == 0)
                    _VyberPredmetu();
                else
                   if (Opravdu() == true)
                    break;
                else
                    continue;
            }
            int HMenu()
            {
                Menu menu = new Menu($"Přejete si prohledat nepřítele: {nazevStvoreni}?", new List<string> { "Ano, prohledat", "Ne, neprohledávat" }, ConsoleColor.Blue);
                return menu.NavratIndexu();
            }
            void _VyberPredmetu()
            {
                if (vypis == true && stvoreni.pocetZlata > 0)
                {
                    vypis = false;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine($"U {nazevStvoreni} jste našli {stvoreni.pocetZlata} zlata, pěkné!");
                    Inventar.PridejZlato(stvoreni.pocetZlata, VasePostava.inventarPostavy);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
                    Console.ReadKey(true);
                    Console.Clear();
                }
                while (true)
                {

                    var nenullPredmety = stvoreni.seznamPredmetu.Where(l => l != null && l != VytvorenePredmety.Žádná_Zbraň && l != VytvorenePredmety.Žádná_Zbroj)
                        .GroupBy(n => n.ID).Select(l => l.First());
                    var zobrazeniIStvoreni = nenullPredmety.Select(p => $"(1)" + $" {p.nazevPredmetu}" + ((p is Specialni)?" (Speciální předmět)":"")).ToList();
                    zobrazeniIStvoreni.Add("Návrat do hlavního menu");
                    Menu menu = new Menu("Tyto předměty jste našli u stvoření, vyberte si který chcete vzít", zobrazeniIStvoreni, ConsoleColor.DarkGreen);
                    int volba = menu.NavratIndexu();
                    if (volba == zobrazeniIStvoreni.Count - 1)
                    {
                        break;
                    }
                    Predmety vybranyPredmet = nenullPredmety.ToList()[volba];
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine();
                    Console.WriteLine("Vzali jste si předmět {0} od {1}.", vybranyPredmet.nazevPredmetu, nazevStvoreni);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
                    Console.ReadKey(true);
                    Console.Clear();
                    stvoreni.seznamPredmetu.Remove(vybranyPredmet);
                    VasePostava.inventarPostavy.PridejPredmet(vybranyPredmet);
                }
            }
            bool Opravdu()
            {
                Menu menu = new Menu("Jste si jisti, že chete odejít?", new List<string> { "Ano, odejít", "Ne, zůstat" }, ConsoleColor.Red);
                if (menu.NavratIndexu() == 0)
                    return true;
                else
                    return false;
            }
        }
        private static Random rand = new Random();
        //------------------STAT act
        /// <summary>
        /// 1 - hráč, 2 - stvoření enemy, 3 - společník, jinak exc
        /// </summary>
        /// <param name="kdoDodguje"></param>
        private static void Uhyb(int kdoDodguje)
        {
            if (kdoDodguje == 1)
                HracDodge();
            else if (kdoDodguje == 2)
                EnemyDodge();
            else if (kdoDodguje == 3)
                SpolecnikDodge();
            else
                throw new Exception("Špatné číslo u úhybu param");

            void HracDodge()
            {
                if (VasePostava.hracovaPostava.vObratnost <= 0)
                    return;
                int _DodgeCislo = rand.Next(1, 101);
                int ObratnostHrace = VasePostava.hracovaPostava.vObratnost * 2;
                if (_DodgeCislo <= ObratnostHrace)
                    if (VasePostava._aktualniNepritel.poskozeni > 0)
                    {
                        UhybPos();
                        return;
                    }
                void UhybPos()
                {

                    ForegroundColor = ConsoleColor.DarkGray;
                    WriteLine();
                    WriteLine("Podařilo se Vám útoku vyhnout, poškození je tedy sníženo na 0!");
                    VasePostava._aktualniNepritel.poskozeni = 0;
                }
            }
            void EnemyDodge()
            {
                if (VasePostava._aktualniNepritel.sObratnost <= 0)
                    return;
                int _DodgeCislo = rand.Next(1, 101);
                int ObratnostNepritele = VasePostava._aktualniNepritel.sObratnost * 2;
                if (_DodgeCislo <= ObratnostNepritele)
                    if (VasePostava.hracovaPostava.poskozeni > 0)
                    {
                        UhybNep();
                        return;
                    }
                void UhybNep()
                {

                    ForegroundColor = ConsoleColor.DarkGray;
                    WriteLine();
                    WriteLine("Nepříteli se podařilo se útoku vyhnout, poškození je tedy sníženo na 0!");
                    VasePostava.hracovaPostava.poskozeni = 0;
                }
            }
            void SpolecnikDodge()
            {
                if (VasePostava.spolecnik == null)
                    return;
                if (VasePostava.spolecnik.sObratnost <= 0)
                    return;
                int _DodgeCislo = rand.Next(1, 101);
                int ObratnostSpol = VasePostava.spolecnik.sObratnost * 2;
                if (_DodgeCislo <= ObratnostSpol)
                    if (VasePostava._aktualniNepritel.poskozeni > 0)
                    {
                        UhybSpol();
                        return;
                    }
                void UhybSpol()
                {

                    ForegroundColor = ConsoleColor.DarkGray;
                    WriteLine();
                    WriteLine("Vašemu společníkovi se podařilo útoku vyhnout, poškození je tedy sníženo na 0!");
                    VasePostava._aktualniNepritel.poskozeni = 0;
                }
            }
        }
        /// <summary>
        /// 1 - hráč, 2 - stvoření enemy, 3 - společník, jinak exc
        /// </summary>
        /// <param name="KdoCrituje"></param>
        private static void KritickyZasah(int KdoCrituje)
        {
            if (KdoCrituje == 1)
                HracCrit();
            else if (KdoCrituje == 2)
                EnemyCrit();
            else if (KdoCrituje == 3)
                SpolecnikCrit();
            else
                throw new Exception("Špatné číslo u kritického zásahu param");
            void HracCrit()
            {
                if (VasePostava.hracovaPostava.vStesti <= 0)
                    return;
                int randomCrit = rand.Next(1, 101);
                int hracStesti = VasePostava.hracovaPostava.vStesti * 2;
                if (randomCrit <= hracStesti)
                    if (VasePostava.hracovaPostava.poskozeni > 0)
                    {
                        HCrit();
                        return;
                    }
                void HCrit()
                {
                    ForegroundColor = ConsoleColor.DarkGray;
                    WriteLine();
                    VasePostava.hracovaPostava.poskozeni *= 2;
                    WriteLine($"Podařil se Vám kritický zásah, poškození se násobí 2x! - {VasePostava.hracovaPostava.poskozeni} poškození!");
                }
            }
            void EnemyCrit()
            {
                if (VasePostava._aktualniNepritel.sStesti <= 0)
                    return;
                int randomCrit = rand.Next(1, 101);
                int nepritelStesti = VasePostava._aktualniNepritel.sStesti * 2;
                if (randomCrit <= nepritelStesti)
                    if (VasePostava._aktualniNepritel.poskozeni > 0)
                    {
                        NCrit();
                        return;
                    }
                void NCrit()
                {
                    ForegroundColor = ConsoleColor.DarkGray;
                    WriteLine();
                    VasePostava._aktualniNepritel.poskozeni *= 2;
                    WriteLine($"Vašemu nepříteli se podařil kritický zásah, poškození se násobí 2x! - {VasePostava._aktualniNepritel.poskozeni} poškození!");
                }
            }
            void SpolecnikCrit()
            {
                if (VasePostava.spolecnik == null)
                    return;
                if (VasePostava.spolecnik.sStesti <= 0)
                    return;
                int randomCrit = rand.Next(1, 101);
                int spolecnikStesti = VasePostava.spolecnik.sStesti * 2;
                if (randomCrit <= spolecnikStesti)
                    if (VasePostava.spolecnik.poskozeni > 0)
                    {
                        SCrit();
                        return;
                    }
                void SCrit()
                {
                    ForegroundColor = ConsoleColor.DarkGray;
                    WriteLine();
                    VasePostava.spolecnik.poskozeni *= 2;
                    WriteLine($"Vašemu společníkovi se podařil kritický zásah, poškození se násobí 2x! - {VasePostava.spolecnik.poskozeni} poškození!");
                }
            }
        }
        /// <summary>
        /// 1 - hráč, 2 - soupeř, 3 - společník, jinak exc
        /// </summary>
        /// <param name="NaKohoSeVztahuje"></param>
        private static void StavPoveznesenosti(int NaKohoSeVztahuje)
        {
            if (NaKohoSeVztahuje == 1)
                HracPovznesen();
            else if (NaKohoSeVztahuje == 2)
                NepritelPovznesen();
            else if (NaKohoSeVztahuje == 3)
                SpolecnikPovznesen();
            void HracPovznesen()
            {
                if (VasePostava.hracovaPostava.vInteligence <= 0)
                    return;
                bool vz = false;
                bool vm = false;
                int Hint = VasePostava.hracovaPostava.vInteligence*2;
                int Sance = rand.Next(1, 101);
                if (Sance <= Hint)
                {
                    PovznesenH = true;
                    ForegroundColor = ConsoleColor.Blue;
                    VasePostava.hracovaPostava.vUtocnaHodnota *= 2;
                    VasePostava.hracovaPostava.vObrannaHodnota *= 2;
                    if (VasePostava.hracovaPostava.maManu && VasePostava.hracovaPostava.pocetMany < VasePostava.hracovaPostava.maxMana)
                    {
                        VasePostava.hracovaPostava.pocetMany = VasePostava.hracovaPostava.maxMana;
                        vm = true;
                    }
                    if (VasePostava.hracovaPostava.vZdravi < VasePostava.hracovaPostava.zdraviPostavy)
                    {
                        VasePostava.hracovaPostava.vZdravi = VasePostava.hracovaPostava.zdraviPostavy;
                        vz = true;
                    }
                    WriteLine();
                    WriteLine("Pro tento souboj se Vám podařilo dostat do stavu povznesenosti, máte tedy následující bonusy:");
                    WriteLine();
                    WriteLine($"Útočná hodnota x2 - nyní je {VasePostava.hracovaPostava.vUtocnaHodnota}.");
                    WriteLine();
                    WriteLine($"Obranná hodnota x2 - nyní je {VasePostava.hracovaPostava.vObrannaHodnota}.");
                    if (vm)
                    {
                        WriteLine();
                        WriteLine($"Úplné doplnění many - nyní máte {VasePostava.hracovaPostava.pocetMany} many.");
                    }
                    if (vz)
                    {
                        WriteLine();
                        WriteLine($"Úplné doplnění zdraví - nyní máte {VasePostava.hracovaPostava.vZdravi} zdraví.");
                    }
                    WriteLine();
                    ResetColor();
                    Thread.Sleep(250);
                    WriteLine("stiskněte libovolné tlačítko pro poikračování....");
                    ReadKey(true);
                    Clear();
                }
            }
            void NepritelPovznesen()
            {
                if (VasePostava._aktualniNepritel.sInteligence <= 0)
                    return;
                int Nint = VasePostava._aktualniNepritel.sInteligence * 2;
                int Sance = rand.Next(1, 101);
                if (Sance <= Nint)
                {
                    PovznesenN = true;
                    ForegroundColor = ConsoleColor.Red;
                    VasePostava._aktualniNepritel.sUtocnaHodnota *= 2;
                    VasePostava._aktualniNepritel.sObrannaHodnota *= 2;

                    WriteLine();
                    WriteLine("Pro tento souboj se soupeři podařilo dostat do stavu povznesenosti, má tedy následující bonusy:");
                    WriteLine();
                    WriteLine($"Útočná hodnota x2 - nyní je {VasePostava._aktualniNepritel.sUtocnaHodnota}.");
                    WriteLine();
                    WriteLine($"Obranná hodnota x2 - nyní je {VasePostava._aktualniNepritel.sObrannaHodnota}.");
                    WriteLine();
                    ResetColor();
                    Thread.Sleep(250);
                    WriteLine("stiskněte libovolné tlačítko pro poikračování....");
                    ReadKey(true);
                    Clear();
                }
            }
            void SpolecnikPovznesen()
            {
                if (VasePostava.spolecnik == null)
                    return;
                if (VasePostava.hracovaPostava.vInteligence <= 0)
                    return;
                bool vz = false;
                bool vm = false;
                int Sint = VasePostava.spolecnik.sInteligence * 2;
                int Sance = rand.Next(1, 101);
                if (Sance <= Sint)
                {
                    PovznesenS = true;
                    ForegroundColor = ConsoleColor.Cyan;
                    VasePostava.spolecnik.sUtocnaHodnota *= 2;
                    VasePostava.spolecnik.sObrannaHodnota *= 2;
                    if (VasePostava.spolecnik.maManu && VasePostava.spolecnik.pocetMany < VasePostava.spolecnik.maxMana)
                    {
                        VasePostava.spolecnik.pocetMany = VasePostava.spolecnik.maxMana;
                        vm = true;
                    }
                    if (VasePostava.spolecnik.sZdravi < VasePostava.spolecnik.maxZdravi)
                    {
                        VasePostava.spolecnik.sZdravi = VasePostava.spolecnik.maxZdravi;
                        vz = true;
                    }
                    WriteLine();
                    WriteLine("Pro tento souboj se Vašemu společníkovi podařilo dostat do stavu povznesenosti, má tedy následující bonusy:");
                    WriteLine();
                    WriteLine($"Útočná hodnota x2 - nyní je {VasePostava.spolecnik.sUtocnaHodnota}.");
                    WriteLine();
                    WriteLine($"Obranná hodnota x2 - nyní je {VasePostava.spolecnik.sObrannaHodnota}.");
                    if (vm)
                    {
                        WriteLine();
                        WriteLine($"Úplné doplnění many - nyní má {VasePostava.spolecnik.pocetMany} many.");
                    }
                    if (vz)
                    {
                        WriteLine();
                        WriteLine($"Úplné doplnění zdraví - nyní má { VasePostava.spolecnik.sZdravi} zdraví.");
                    }
                    WriteLine();
                    ResetColor();
                    Thread.Sleep(250);
                    WriteLine("stiskněte libovolné tlačítko pro poikračování....");
                    ReadKey(true);
                    Clear();
                }
            }
        }
        /// <summary>
        /// 1 - hráč, 2 - soupeř, 3 - společník
        /// </summary>
        /// <param name="KdoJeOdzbrojen"></param>
        private static void Prolomeni(int KdoProlomuje)
        {
            if (KdoProlomuje == 1)
                HracPrulom();
            else if (KdoProlomuje == 2)
                EnemyPrulom();
            else if (KdoProlomuje == 3)
                SpolecnikPrulom();
            else
                throw new Exception("Špatné číslo v průlomu");
            void HracPrulom()
            {
                if (VasePostava.hracovaPostava.vSila <= 0)
                    return;
                int randomCrit = rand.Next(1, 101);
                int hracSila = VasePostava.hracovaPostava.vSila * 2;
                if (randomCrit <= hracSila)
                    if (VasePostava.hracovaPostava.poskozeni > 0)
                    {
                        HPrulom();
                        return;
                    }
                void HPrulom()
                {
                    ForegroundColor = ConsoleColor.DarkGray;
                    WriteLine();
                    VasePostava.hracovaPostava.poskozeni += VasePostava._aktualniNepritel.sObrannaHodnota;
                    WriteLine($"Podařilo se Vám Prolomení - Váš útok ignoruje obrannou hodnotu soupeře. Finální poškození je {VasePostava.hracovaPostava.poskozeni}.");
                }
            }
            void EnemyPrulom()
            {
                if (VasePostava._aktualniNepritel.sSila <= 0)
                    return;
                int randomCrit = rand.Next(1, 101);
                int hracSila = VasePostava._aktualniNepritel.sSila * 2;
                if (randomCrit <= hracSila)
                    if (VasePostava._aktualniNepritel.poskozeni > 0)
                    {
                        EPrulom();
                        return;
                    }
                void EPrulom()
                {
                    ForegroundColor = ConsoleColor.DarkGray;
                    WriteLine();
                    if(!_UtokNaSpolecnika)
                    {
                        VasePostava._aktualniNepritel.poskozeni += VasePostava.hracovaPostava.vObrannaHodnota;
                        WriteLine($"Soupeři se podařilo Prolomení - Jejich útok ignoruje Vaší obrannou hodnotu. Finální poškození je {VasePostava._aktualniNepritel.poskozeni}.");
                    }
                    else
                    {
                        if(VasePostava.spolecnik != null)
                        {
                             VasePostava._aktualniNepritel.poskozeni += VasePostava.spolecnik.sObrannaHodnota;
                             WriteLine($"Soupeři se podařilo Prolomení - Jejich útok ignoruje obrannou hodnotu Vašeho společníka. Finální poškození je {VasePostava._aktualniNepritel.poskozeni}.");
                        }
                    }
                }
            }
            void SpolecnikPrulom()
            {
                if (VasePostava.spolecnik == null)
                    return;
                if (VasePostava.spolecnik.sSila <= 0)
                    return;
                int randomCrit = rand.Next(1, 101);
                int spolecnikSila = VasePostava.spolecnik.sSila * 2;
                if (randomCrit <= spolecnikSila)
                    if (VasePostava.spolecnik.poskozeni > 0)
                    {
                        SCrit();
                        return;
                    }
                void SCrit()
                {
                    ForegroundColor = ConsoleColor.DarkGray;
                    WriteLine();
                    VasePostava.spolecnik.poskozeni += VasePostava._aktualniNepritel.sObrannaHodnota;
                    WriteLine($"Vašemu společníkovi se podařilo Prolomení - Jeho útok ignoruje obrannou hodnotu soupeře. Finální poškození je {VasePostava.spolecnik.poskozeni}.");
                }
            }
        }
        //---------------------STAT ACT
        private static void SoubojovyPostihZaLimit66()
        {
            if (VasePostava.inventarPostavy.ZiskejPocetPredmetu(6) <= VasePostava.hracovaPostava.AktualizaceKapacity())
                return;
            int obr = (int)(VasePostava.hracovaPostava.vObratnost * 0.5);
            int sil = (int)(VasePostava.hracovaPostava.vSila * 0.5);
            int inT = (int)(VasePostava.hracovaPostava.vInteligence * 0.5);
            int ste = (int)(VasePostava.hracovaPostava.vStesti * 0.5);
            int UH = (int)(VasePostava.hracovaPostava.vUtocnaHodnota * 0.5);
            int OH = (int)(VasePostava.hracovaPostava.vObrannaHodnota * 0.5);
            int zdr = (int)(VasePostava.hracovaPostava.vZdravi * 0.5);
            if (obr < 0)
                obr = 0;
            if (sil < 0)
                sil = 0;
            if (inT < 0)
                inT = 0;
            if (ste < 0)
                ste = 0;
            if (UH < 0)
                UH = 0;
            if (OH < 0)
                OH = 0;
            int Postih = rand.Next(0, 3);
            if (Postih == 0)
                return;
            else
            {
                Clear();
                VasePostava.hracovaPostava.vObratnost -= obr;
                VasePostava.hracovaPostava.vSila -= sil;
                VasePostava.hracovaPostava.vInteligence -= inT;
                VasePostava.hracovaPostava.vStesti -= ste;
                VasePostava.hracovaPostava.vUtocnaHodnota -= UH;
                VasePostava.hracovaPostava.vObrannaHodnota -= OH;
                VasePostava.hracovaPostava.vZdravi -= zdr;
                ForegroundColor = ConsoleColor.DarkBlue;
                WriteLine();
                WriteLine("Máte u sebe více předmětů než jste schopni unést, tudíž v tomto souboji máte následuící postihy:");
                WriteLine();
                WriteLine(@$"   
                             Obratnost -{obr} (nyní {VasePostava.hracovaPostava.vObratnost})
                             Síla -{sil} (nyní {VasePostava.hracovaPostava.vSila})
                             Inteligence -{inT} (nyní {VasePostava.hracovaPostava.vInteligence})
                             Štěstí -{ste} (nyní {VasePostava.hracovaPostava.vStesti})
                             Útočná hodnota -{UH} (nyní {VasePostava.hracovaPostava.vUtocnaHodnota})
                             Obranná hodnota -{OH}(nyní {VasePostava.hracovaPostava.vObrannaHodnota})
                             Zdraví -{zdr} (nyní {VasePostava.hracovaPostava.vZdravi})");
                GameplayLokaci_1.Tlacitko();
            }
           
        }
        public static void Okradeni()
        {
           if (VasePostava.inventarPostavy.ZiskejPocetPredmetu(6) > VasePostava.hracovaPostava.AktualizaceKapacity())
           {
             Clear();
             ForegroundColor = ConsoleColor.DarkYellow;
             WriteLine("Někdo si všiml Vašeho početného nákladu. Každý by chtěl část pro sebe...");
             GameplayLokaci_1.Tlacitko();
                new Sberac().SchopnostStvoreni();
           }
        }

        
        public static void Loot(List<Predmety> TypVyberuPredmetu, int pocetPredmetuKZiskani, ConsoleColor barvaVypisu = ConsoleColor.Blue)
        {
            if (pocetPredmetuKZiskani <= 0)
                return;
            Clear();
            ForegroundColor = barvaVypisu;
            for (int i = 0; i < pocetPredmetuKZiskani; i++)
            {
                int ran = new Random().Next(0, TypVyberuPredmetu.Count);
                VasePostava.inventarPostavy.PridejPredmet(TypVyberuPredmetu[ran]);
                WriteLine();
                WriteLine($"Nalezli jste předmět {TypVyberuPredmetu[ran].nazevPredmetu}!");
            }           
            GameplayLokaci_1.Tlacitko();
        }
        
        // spec kontrola
        private static void SpecialniPrCheckHrdina()
        {
            var SpecHrace = VasePostava.inventarPostavy.ListInventare().Where(p => p is Specialni && (p as Specialni).TypSpecialu == Specialni.TypSpecPred.Talsiman && (p as Specialni).SchopnostSpecialniP != null).ToList();
            var SpecVyberH = SpecHrace.GroupBy(p => p.ID).Select(p => p.First());
            foreach (Specialni s in SpecVyberH)
                s.SchopnostSpecialniP.Invoke(true);               
        }
        private static void SpecialniPrCheckEnemy()
        {
            foreach (Predmety p in VasePostava._aktualniNepritel.seznamPredmetu)
                if (p is Specialni && (p as Specialni).TypSpecialu == Specialni.TypSpecPred.Talsiman && (p as Specialni).SchopnostSpecialniP != null)
                    (p as Specialni).SchopnostSpecialniP.Invoke(false);
        }

        public static void Titulky(List<string> subtitles)
        {
            Random random = new Random();
            MusicPlayer.nynejsiSong = MusicPlayer.TheTriumph;
            MusicPlayer.nynejsiSong.PlayLooping();            
            if(OperatingSystem.IsWindows())
            {
                WindowHeight = 17;
                WindowWidth = 70;
                SetBufferSize(WindowWidth, WindowHeight);
            }
            int delayBetweenSubtitles = 3000; // čas mezi titulkami

            int consoleHeight = Console.WindowHeight;
            int consoleWidth = Console.WindowWidth;

            foreach (string subtitle in subtitles)
            {
                ClearConsole();
                ConsoleColor randomColor = (ConsoleColor)random.Next(1, 16);           
                Console.ForegroundColor = randomColor;
                // Calculate the starting position of the subtitle
                int row = (consoleHeight - 1) / 2; // Center vertically
                int col = (consoleWidth - subtitle.Length) / 2; // Center horizontally

                // Display the subtitle at the center of the console
                Console.SetCursorPosition(col, row);
                Console.WriteLine(subtitle);

                Thread.Sleep(delayBetweenSubtitles);
                ClearConsole();
                Thread.Sleep(500); // Adjust this value to control the delay before the next subtitle

                // Calculate the number of spaces to create the spacing effect
                int numSpaces = (consoleHeight - 1) / 2;

                // Print the empty spaces
                for (int i = 0; i < numSpaces; i++)
                {
                    Console.WriteLine();
                }

                Thread.Sleep(500); // Adjust this value to control the delay before the next subtitle
            }
            MusicPlayer.nynejsiSong.Stop();
            if (OperatingSystem.IsWindows())
            {

                WindowHeight = 35;//30
                WindowWidth = 140;//120
                SetBufferSize(WindowWidth, WindowHeight);
            }

        }

        private static void ClearConsole()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
        }

        private static void Podekovani()
        {
            Clear();
            List<string> titulky = new List<string> { "Ilustrace a ASCII: Štěpán Štroner",
            "Hudba od: Leimoti", "Edgar Hopp", "Bonn Fields", "Emily Rubye", "Christian Andersen", "Phoenix Tail", "Howard Harper-Barnes", "John Abbot", "Arylide Fields"
            ,"Hampus Naeselius", "Christopher Moe Ditlevsen", "Jo Wandrili", "Fredrik Ekstrom", "Dream Cave", "Gerard Franklin", "Inspirace od: The Darkest Dungeon",
            "The Elder Scrolls V: Skyrim", "Magic the Gathering", "♥"};
            ForegroundColor = ConsoleColor.Magenta;
            WriteLine();
            WriteLine("Děkuji následujícím osobám za značnou pomoc při vytváření ilustrací a hudby pro Live Thrice.");
            Thread.Sleep(500);
            WriteLine();
            WriteLine("Také děkuji následujícím Herním titulům, případně karetním hrám, za inspiraci do hry:");
            GameplayLokaci_1.Tlacitko();
            Titulky(titulky);
        }
    }
}