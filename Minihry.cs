using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static System.Console;

namespace DnD_Hra
{
   class Pamatovak
   {
        Random random = new Random();
        int[] cislaNaZapamatovani;
        int maxpokusy;
        int nynejsipokus;
        int casmizeni;
        string vstuphrace;
        public bool dokonceno;
        
        public Pamatovak(int [] cislaNaZapamatovani, int maxpokusy, int casmizeni)
        {
            this.cislaNaZapamatovani = cislaNaZapamatovani;
            this.maxpokusy = maxpokusy;
            this.casmizeni = casmizeni;
            nynejsipokus = 0;
            dokonceno = false;
        }
        void ZobrazCisla()
        {
            ForegroundColor = ConsoleColor.DarkCyan;
            Thread.Sleep(500);           
            foreach(int i in cislaNaZapamatovani)
            {
                int randomSirka = random.Next(0, WindowWidth);
                int randomVyska = random.Next(0, WindowHeight);
                SetCursorPosition(randomSirka, randomVyska);
                Write(i);
                Thread.Sleep(casmizeni);
                Clear();
            }
            ResetColor();           
        }
        void Uvod()
        {
            Clear();
            WriteLine();
            ForegroundColor = ConsoleColor.DarkBlue;
            WriteLine("Zapamatujte si čísla, která slouží k odemčení zámku...");
            WriteLine();
            WriteLine("3...");
            Thread.Sleep(650);
            WriteLine();
            WriteLine("2...");
            Thread.Sleep(650);
            WriteLine();
            WriteLine("1...");
            Thread.Sleep(650);
            ResetColor();
            Clear();

        }
        public void Hraj()
        {            
           
            while(nynejsipokus < maxpokusy)
            {
                nynejsipokus++;
                Uvod();
                ZobrazCisla();
              Clear();
                WriteLine();
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine("Zadejte čísla, která jste právě viděli vevnitř zámku:");
                CursorVisible = true;
                ResetColor();
                vstuphrace = ReadLine();
                while(!vstuphrace.All(char.IsDigit))
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("Zadejte prosím sekvenci čísel!");
                    ResetColor();
                    vstuphrace = ReadLine();
                }
                int[] inputArray = vstuphrace.Select(c => int.Parse(c.ToString())).ToArray();
                CursorVisible = false;
                if (!inputArray.SequenceEqual(cislaNaZapamatovani))
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine($"Čísla {vstuphrace} nejsou správnou kombinací zámku.");
                    WriteLine();
                    Thread.Sleep(200);
                    WriteLine("Zbývající počet pokusů: {0}", maxpokusy - nynejsipokus);
                    WriteLine();
                    ResetColor();
                    WriteLine("stiskněte libovolné tlačítko pro pokračování...");
                    ReadKey(true);
                }
                else
                {
                    ForegroundColor = ConsoleColor.Green;
                    Clear();
                   WriteLine($"Čísla {vstuphrace} jsou správnou kombinací zámku!.");
                    WriteLine();
                    ResetColor();
                    WriteLine("stiskněte libovolné tlačítko pro pokračování...");
                    ReadKey(true);
                    dokonceno = true;
                    return;
                }
            }
            Clear();
            ForegroundColor = ConsoleColor.Red;
            WriteLine("Toto byl Váš poslední pokus, bohužel se zámek nepodařilo otevřít...");
            WriteLine();
            ResetColor();
            WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            ReadKey(true);
            return;

        }

   }
}
