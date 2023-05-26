using System;
using System.Threading;
using static System.Console;
namespace DnD_Hra
{
    public class DndKostka
    {
        private int vysledek { get; set; }

        public void HodKostkou() // funkce hod kostkou
        {
            int roll;
            vysledek = 0;
            Random random = new Random();
            Thread.Sleep(300);
            WriteLine();
            WriteLine("Probíhá hod kostkou...");
            WriteLine();
            while (true)
            {
                roll = random.Next(1, 4);
                Console.WriteLine($"Padla {roll}");
                Thread.Sleep(350);
                vysledek += roll;
                if (roll == 3)
                {
                    WriteLine();
                    Console.WriteLine("Probíhá další hod kostkou...");
                    WriteLine();
                    Thread.Sleep(250);
                    continue;
                }
                if (roll != 3)
                    WriteLine();
                Console.WriteLine($"Celková hodnota hodů je tedy {vysledek}");
                break;
            }
            WriteLine();
            Thread.Sleep(350);
            ResetColor();
            WriteLine("stiskněte libovolné tlačítko pro pokračování");
            ResetColor();
            ReadKey(true);
            Clear();
        }


        public int VysledekHodu()
        {
            return vysledek;
        }

        //**********************************************************************************
        public void KostkyArt() // art kostek
        {
            Console.WriteLine(@"

                                       (( _______
                             _______     /\O    O\
                            /O     /\   /  \      \
                           /   O  /O \ / O  \O____O\ ))
                        ((/_____O/    \\    /O     /
                          \O    O\    / \  /   O  /
                           \O    O\ O/   \/_____O/
                            \O____O\/ ))       ))
                          ((
                                                        ");
        }

        //********************************************************************************
        public void HodCinknutouKostkou() // funkce hod cinknutou kostkou, první padne vždy 3 kostkou
        {
            bool prvniHod = true;
            int roll;
            vysledek = 0;
            Random random = new Random();
            Thread.Sleep(300);
            WriteLine();
            WriteLine("Probíhá hod cinknutou kostkou...");
            WriteLine();
            while (true)
            {
                if(prvniHod)
                {
                    roll = 3;
                    prvniHod = false;
                }
                else
                    roll = random.Next(1,4);


                Console.WriteLine($"Padla {roll}");
                Thread.Sleep(350);
                vysledek += roll;
                if (roll == 3)
                {
                    WriteLine();
                    Console.WriteLine("Probíhá další hod kostkou...");
                    WriteLine();
                    Thread.Sleep(250);
                    continue;
                }
                if (roll != 3)
                    WriteLine();
                Console.WriteLine($"Celková hodnota hodů je tedy {vysledek}");
                break;
            }
            WriteLine();
            Thread.Sleep(350);
            ResetColor();
            WriteLine("stiskněte libovolné tlačítko pro pokračování");
            ResetColor();
            ReadKey(true);
            Clear();
        }
        public void HodStatovouKostkou() // funkce hod kostkou. neopakujeme hody když padne 3
        {
            int roll;
            vysledek = 0;
            Random random = new Random();
            Thread.Sleep(300);
            WriteLine();
            WriteLine("Probíhá hod kostkou...");
            WriteLine();      
            roll = random.Next(1, 4);
            Console.WriteLine($"Padla {roll}");
            Thread.Sleep(350);
            vysledek += roll;
            WriteLine();
            Console.WriteLine($"Celková hodnota hodů je tedy {vysledek}");                       
            WriteLine();
            Thread.Sleep(350);
            ResetColor();
            WriteLine("stiskněte libovolné tlačítko pro pokračování");
            ResetColor();
            ReadKey(true);
            Clear();
        }
    }
}