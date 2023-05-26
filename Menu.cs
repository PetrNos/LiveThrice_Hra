using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DnD_Hra
{
    public class Menu
    {
        private int zvolenyIndex;
        public List<string> moznosti;
        private string vyzva;
        private ConsoleColor barvaVyzvy;
        public int maxvolba { get; set; }

        public Menu(string vyzva, List<string> moznosti, ConsoleColor barvaVyzvy)
        {
            this.vyzva = vyzva;
            this.moznosti = moznosti;
            this.barvaVyzvy = barvaVyzvy;
            this.maxvolba = moznosti.Count - 1;
            zvolenyIndex = 0;
        }

        //**********************************************************************************
        private void ZobrazMoznosti()
        {
           
            Console.ForegroundColor = barvaVyzvy;
            Console.WriteLine(vyzva);

            for (int i = 0; i < moznosti.Count; i++)
            {
                string nynejsiMoznost = moznosti[i];
                string prefix;

                if (i == zvolenyIndex)
                {
                    prefix = "->";
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    prefix = "";
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine($"{prefix} << {nynejsiMoznost} >>");
            }
            Console.ResetColor();
        }

        public int NavratIndexu()
        {
            ConsoleKey stisknuteTlacitko;
            do
            {
                Console.Clear();
                ZobrazMoznosti();

                ConsoleKeyInfo informace = Console.ReadKey(true);
                stisknuteTlacitko = informace.Key;

                if (stisknuteTlacitko == ConsoleKey.UpArrow)
                {
                    zvolenyIndex--;
                    if (zvolenyIndex == -1)
                    {
                        zvolenyIndex = moznosti.Count - 1;
                        while (Console.KeyAvailable)
                        { // buuff gone
                            Console.ReadKey(true);
                            Thread.Sleep(30);
                        }
                    }
                }
                else if (stisknuteTlacitko == ConsoleKey.DownArrow)
                {
                    zvolenyIndex++;
                    if (zvolenyIndex == moznosti.Count)
                    {
                        zvolenyIndex = 0;
                        while (Console.KeyAvailable)
                        { // buuff gone
                            Console.ReadKey(true);
                            Thread.Sleep(30);
                        }
                    }
                }
            } while (stisknuteTlacitko != ConsoleKey.Enter);

            return zvolenyIndex;
        }

        public void Nacitani()
        {
            Console.CursorVisible = false;

            for (int i = 1; i < Console.WindowWidth + 1; i++)
            {
                Console.OutputEncoding = Encoding.Unicode;
                string[] meziload = { "»", ">" };
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                if (i % 2 == 0)
                {
                    Console.Write($"{meziload[0]}");
                }
                else
                {
                    Console.Write($"{meziload[1]}");
                }
                Thread.Sleep(100);
            }
            Console.ResetColor();
            Thread.Sleep(1000);
            Console.CursorVisible = true;
        }

        public static void VedlejsiMenuPostavy()
        {
            Inventar.OdeberNepotrebne(VasePostava.inventarPostavy);
            while (true)
            {
                int vyberHrace = hlavniMenu();
                if (vyberHrace == 0)
                {
                    VybavitSe();
                }
                else if (vyberHrace == 1)
                {
                    ZobrazInventar();
                }
                else if (vyberHrace == 2)
                    VyhoditPredmety();
                else if (vyberHrace == 3)
                    Katalog.HracuvDenik();
                else if (vyberHrace == 4)
                    MusicPlayer.VyberPisnicek();
                else if (vyberHrace == 5)
                {
                    bool Odchod = OdchodZMenu();

                    if (Odchod)
                        break;
                    else
                        continue;
                }
            }
            int hlavniMenu()
            {
                Menu vedlejsiMenu = new Menu("Nacházíte se v menu Inventáře, co si přejete udělat?", new List<string> { "Vybavit se", "Zobrazit inventář","Odebrat předměty z inventáře","Zobrazit osobní deník","Menu magického Barda", "Odejít z vedlejšího menu" }, ConsoleColor.Blue);
                return vedlejsiMenu.NavratIndexu();
            }
            void VyhoditPredmety()
            {
                Inventar.OdebratPredmey(VasePostava.inventarPostavy);
            }
            void VybavitSe()
            {
                Inventar.VybavitSe(VasePostava.inventarPostavy);
            }
            void ZobrazInventar()
            {
                while(true)
                {

                    Menu zobrazeniInventare = new Menu("Které předměty ve Vašem inventáři si přejete zobrazit?", new List<string> { "Zobrazit zbraně", "Zobrazit zbroje", "Zobrazit použitelné", "Zobrazit speciální", "Zobrazit suroviny", "Zobrazit všechy", "Vrátit se" }, ConsoleColor.Cyan);
                    int volba = zobrazeniInventare.NavratIndexu();
                    if (volba == 0)
                        VasePostava.inventarPostavy.ZobrazPredmetyPodleTypu(TypPredmetu.Zbrane);
                    else if (volba == 1)
                        VasePostava.inventarPostavy.ZobrazPredmetyPodleTypu(TypPredmetu.Zbroje);
                    else if (volba == 2)
                        VasePostava.inventarPostavy.ZobrazPredmetyPodleTypu(TypPredmetu.Pouzitelne);
                    else if (volba == 3)
                        VasePostava.inventarPostavy.ZobrazPredmetyPodleTypu(TypPredmetu.Specialni);
                    else if (volba == 4)
                        VasePostava.inventarPostavy.ZobrazPredmetyPodleTypu(TypPredmetu.Suroviny);
                    else if (volba == 5)
                        VasePostava.inventarPostavy.ZobrazVsechnyPredmety();
                    else
                        break;
                }
            }
            bool OdchodZMenu()
            {
                Menu opravdu = new Menu("Jste si jisti odchodem z vedlejšího menu?", new List<string> { "Ano, odejít", "Ne, zůstat" }, ConsoleColor.Red);
                int vlba = opravdu.NavratIndexu();
                if (vlba == 0)
                    return true;
                else
                {
                    return false;
                }
            }
        }
    }
}