using System;
using System.Threading;
using static System.Console;

namespace DnD_Hra
{
    internal class Past
    {
        private int MinimalniHod;
        private int StatPostavy;

        private bool _Uspech { get; set; }

        private readonly DndKostka kostka = new DndKostka();

        public Past(int MinimalniHod, int StatPostavy, string NaCoSiHazi, string kdoSiHazi)
        {
            this.StatPostavy = StatPostavy;
            this.MinimalniHod = MinimalniHod;
            Clear();
            ForegroundColor = ConsoleColor.Red;
            WriteLine();
            WriteLine("Nyní si {1} hodí past na {0}", NaCoSiHazi, kdoSiHazi);
            ResetColor();
            WriteLine();
            Thread.Sleep(150);
            WriteLine("stiskněte libovolné tlačítko pro pokračování");
            ReadKey(true);
            Clear();
            kostka.KostkyArt();
            kostka.HodKostkou();
            if (kostka.VysledekHodu() + StatPostavy >= MinimalniHod)
                _Uspech = true;
            else
                _Uspech = false;
        }

        public bool Uspech()
        {
            return _Uspech;
        }
    }
}