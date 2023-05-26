using System;
using System.Threading;
using System.Text;
namespace DnD_Hra
{
    internal class Carodej : Povolani // inheritovaná class z povolání
    {
        public int poskozeniAlternativniZbrane;
        public int altUtocnaHodnota;
        public int cenaUtoku;
        public static Zbrane carodejovaZbran;
        public static Zbrane carodejovaZalozniZbran;
        public static Zbroje carodejovaZbroj;

        public Carodej() // hodnoty base atributů tohoto povolání
        {
            carodejovaZalozniZbran = VytvorenePredmety.Dýka;
            carodejovaZbran = VytvorenePredmety.Magická_Hůl;
            carodejovaZbroj = VytvorenePredmety.Látková_Zbroj;
            pInteligence = 2;
            pSila = 0;
            pObratnost = 1;
            pStesti = 2;
            maManu = true;
            pocetMany = 15;

            zakladniUtocnaHodnota = 2;
            zakladniObrannaHodnota = 1;
            poskozeniZbrane = carodejovaZbran.poskozeniZbrane;
            pUtocnaHodnota = zakladniUtocnaHodnota + poskozeniZbrane;
            hodnotaBrneni = carodejovaZbroj.hodnotaBrneni;
            pObrannaHodnota = zakladniObrannaHodnota + hodnotaBrneni;
            cenaUtoku = carodejovaZbran.manovaCena;
            poskozeniAlternativniZbrane = carodejovaZalozniZbran.poskozeniZbrane;
            altUtocnaHodnota = 2+carodejovaZalozniZbran.poskozeniZbrane;
            pZdravi = 10 + pObrannaHodnota + pSila;
        }

        //**********************************************************************************

        public override void ArtPovolani() // printik artu postavy carodeje
        {
            Thread.Sleep(100);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            
            Console.WriteLine(@"

                                      ⣠⣤⡤⣤⣄⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀   ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⡴⠋⠏⠀⣿⣏⣿⡆⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣤⡖⠘⠘⢶⢄⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⡇⢬⣷⡿⣫⣞⣿⠃⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⠚⠉⣠⢴⣶⡀⠀⢀⠉⠣⡀⠀⠀⢀⣀⠀⠀⠀⠀⠛⢖⡍⠠⢳⡞⠁⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⣜⡁⠀⢘⣷⣤⠖⡠⠒⡺⠟⠛⠉⠀⣀⣉⣉⣩⠵⢲⡯⡖⣽⠇⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢾⣸⠃⠀⠈⢻⢃⣄⠖⠊⢀⣠⣶⣾⡿⠿⠛⠁⠀⠀⠸⢷⢊⡎⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⢜⢗⢁⣤⡒⠋⡁⠒⢛⣆⠀⠀⠀⠀⠀⠀⢸⢼⡁⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⢜⣻⣾⠾⣟⡺⢠⠞⠁⠀⠀⠀⢱⠀⠀⠀⠀⠀⣸⡞⢵⣮⡂⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠷⣠⣲⡺⠜⠿⣿⠁⣀⣚⢷⠨⣥⣴⠀⠀⠀⢸⡄⢀⣠⠊⣿⡏⣶⢽⡲⠁⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⢐⣿⡟⠀⢐⠟⢛⣶⣯⡀⠀⡀⢸⣿⡯⢻⠀⣿⣷⡏⡖⠁⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⠀⢀⡺⢹⣯⠽⢿⡛⠁⢀⣸⡇⢀⡇⣾⠗⠀⠀⠀⣿⣿⢁⡃⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⠀⠀⡸⠃⢸⣿⠀⢠⣝⢲⡯⠞⠛⠚⢧⣗⠁⠀⠈⠀⣿⣏⢬⠃⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⡜⠀⢸⡀⠠⠚⠉⠒⠊⠁⠈⠀⠀⠀⢠⠀⡏⠀⠀⠀⠄⣿⠯⡏⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠘⣿⣶⣤⡀⠀⠀⠀⠀⠀⠀⠀⡸⢸⣁⠀⠀⠀⡆⣟⢿⠃⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⡖⡖⣿⣿⣿⣿⣦⡤⡀⠀⠀⠀⠀⡇⢘⣿⡗⢼⡄⡇⡟⡜⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣶⡪⣪⣿⣿⣿⣿⣿⣾⣮⣶⡴⣤⡇⢸⣿⡃⠀⠙⠧⠇⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠚⠙⠏⠀⠉⠛⠿⣿⣿⣷⣼⡇⢸⠇⠃⠀⠀⠀⢀⢳⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠛⢿⡇⡜⠃⠀⠀⠀⠀⠘⡼⡄⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡄⠀⠀⠀⠀⠀⠀⢀⡀⢸⣿⡘⠀⠀⡀⠀⠀⠀⣷⡇⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠇⢘⠀⠀⠀⠀⠀⠀⡇⠘⢿⡀⠀⠀⢃⠀⠀⠀⢻⡇⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣇⣸⠀⠀⠀⠀⠀⠰⡇⠀⢸⡇⠀⠰⠸⠀⠀⠀⠸⣃⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠈⡟⠆⠀⠀⠀⡀⢄⡻⢄⣻⣇⠀⠀⠇⡇⠀⠀⠀⣿⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣾⢔⣷⣝⢆⢔⣷⣿⠿⢻⣿⣿⣟⣛⣧⣷⡧⠄⠄⠀⠹⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠈⠛⠛⠛⠟⠛⠛⠙⠛⠟⠦⠴⠤⠽⠚⠉⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀

                                                            ");
            Thread.Sleep(2000);
        }

        //**********************************************************************************
        public override void PredstaveniPovolani()
        {
            Carodej carodej = new Carodej();
            Console.Clear();
            carodej.ArtPovolani();
            Console.WriteLine();
            DndHerniFunkce.AnimaceTextu("Toto je čaroděj, tichý a moudrý, nikdo neví, co se mu právě honí hlavou...");

            DndHerniFunkce.AnimaceTextu("Čarodějova hlavní zbraň je magie, tvoří, ničí, léčí - podle toho, co si čaroděj zrovna usmyslí.");

            DndHerniFunkce.AnimaceTextu("Když čarodějovi jeho mana dojde, musí útočit svou záložní zbraní, do doby, než se mana regeneruje.");

            DndHerniFunkce.AnimaceTextu("Žáložní útoky zbraní zpravidla obnovují 15% čarodějovi maximální many.");

            DndHerniFunkce.AnimaceTextu("Záložní (Alternativní) útočná hodnota se většinou vyhýbá posílením celkové útočné hodnoty, proto je třeba útočit z rozvahou.");

            DndHerniFunkce.AnimaceTextu("Jeho speciální schopnost je vyvolání Ohnivého Elementála, elegantního stvoření, které ovládá magii.");

            DndHerniFunkce.AnimaceTextu("Ohnivého Elementála může vyvolat za svou manu, která se mu postupem času regeneruje.");

            DndHerniFunkce.AnimaceTextu("Ohnivý Elementál vysílá ohnivé koule a když je na pokraji smrti, vzplane, zemře, a tak doplní svému pánovi manu.");

            DndHerniFunkce.AnimaceTextu("Čarodějovým primárním statem je inteligence.");

            Thread.Sleep(150);
            Console.WriteLine();

            Console.WriteLine(@"Čarodějovi základní atributy jsou:

                                 Síla: {0}
                                 Obratnost: {1}
                                 Inteligence: {2}
                                 Štěstí: {3}
                                 Zdraví: {4}
                                 Zbroj: Látková, hodnota brnění: {5}
                                 Zbraň: Magická Hůl, útočná hodnota: {6}, alternativně dýka, útočná hodnota: {11}

    Poznámka: Každý útok Magickou Holí stojí {10} many, když mu mana dojde, používá dýku.

                                 Finální obranná hodnota tedy je: {7}
                                 Finální útočná hodnota potom je: {8}, alternativně {12}
                                 A má manu - může používat kouzla, hodnota many je: {9}", carodej.pSila, carodej.pObratnost, carodej.pInteligence, carodej.pStesti,
                                 carodej.pZdravi, carodej.hodnotaBrneni, carodej.poskozeniZbrane, carodej.pObrannaHodnota, carodej.pUtocnaHodnota,
                                  carodej.pocetMany, carodej.cenaUtoku, carodej.poskozeniAlternativniZbrane, carodej.altUtocnaHodnota);
            Thread.Sleep(200);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
            Console.ReadKey(true);
            Console.Clear();
            Console.ResetColor();
        }

        //**********************************************************************************
    }
}