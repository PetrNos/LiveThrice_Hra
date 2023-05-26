using System;
using System.Threading;

namespace DnD_Hra
{
    internal class Kroll : Rasa
    {
        

        public Kroll()
        {
            rObratnost = -1;
            rInteligence = -2;
            rSila = 3;
            rStesti = 0;
            rZdravi = 10 + rSila;
        }

        private void KrollPostavaArt()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Thread.Sleep(150);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Thread.Sleep(150);
            Console.WriteLine(@"

                            ⠀⠀⠀   ⠀⠀⠀⡟⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⢻⣷⠀⠀⢠⠃⢾⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡶⣦⡀⣇⠛⡷⣠⠞⠀⢸⣧⡄⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢱⠈⠛⠙⠀⠈⠋⠀⠀⢸⣷⡷⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠨⣷⠐⢄⠀⠀⣀⠀⠁⠀⢘⣰⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠰⡾⠦⠐⠃⠁⠢⡈⢳⠐⢁⣟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⣦⠶⠀⠒⠚⠛⠛⠳⣯⡁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⢾⠁⠀⠀⠀⠀⠀⠀⠀⠀⢸⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠀⡟⠘⠀⠀⠀⠀⠀⢀⠀⢀⣀⠀⠘⠇⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣼⠶⡞⣕⠀⢀⡀⠦⡄⠠⠀⠀⡂⣌⡄⣵⣳⣠⡼⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣻⣷⢩⢹⠾⣿⡿⣷⡾⠍⣾⣾⣾⣿⢓⣟⡋⠋⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⣿⠀⠐⢄⣄⢙⠛⠛⠿⠛⠛⠌⢹⡆⡼⠁⣃⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣿⡖⡀⠀⣡⢀⠀⠀⠀⠀⠀⠸⢭⣼⢀⢸⣼⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡇⠁⢼⠋⣷⣶⣤⣴⣤⣶⣤⠃⢳⠈⣷⡞⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⡇⠸⣾⠀⠸⢛⣿⣾⣿⠙⡇⠀⢸⡄⣷⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⢣⢀⠙⠶⠞⠻⠀⠀⠈⣛⠳⠶⢋⣿⡇⣿⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⡞⢹⣿⣿⠈⠿⣷⣴⡴⠛⠩⠉⠉⠒⢦⢴⡿⠿⠁⣿⣿⢿⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⠏⠀⢸⣿⡇⠀⠀⠉⠙⢦⡀⢀⣀⣀⣠⡾⡛⠀⠀⠀⡿⣿⠀⠻⣷⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⠃⠀⠀⠸⣏⢧⠀⠀⠀⢂⠀⠉⡉⠩⠉⢩⢠⠀⠀⠀⢸⢣⡏⠀⠀⠈⠙⢦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠴⠾⠹⠃⠀⠀⠀⠀⢻⣞⢧⡀⠀⠀⢢⠀⠀⠀⠀⠀⠈⣠⠦⣴⢧⡞⠁⠀⠀⠀⠀⠈⠿⢶⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠈⢻⣧⣻⣶⠀⠈⡅⠀⠀⣀⠁⣼⣡⡀⢹⠟⠀⠀⠀⠀⠀⠀⠀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⠀⠀⢀⠤⣾⣟⠻⣿⡙⠲⣤⣎⢿⣍⠤⢚⣵⢻⠀⡄⠑⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠀⠀⣿⠈⢱⣿⠉⣹⢷⣿⣿⣷⣿⡍⠀⢇⢸⠇⠀⠀⠀⠀⠀⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⢰⠃⠀⠀⡇⠀⢀⢴⡒⠋⣿⠀⠸⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠋⠀⠀⠀⣟⣤⡌⠨⢅⣠⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀

                                                            ");
            Thread.Sleep(2000);
        }

        public override void PredstaveniRasy()
        {
            Kroll kroll = new Kroll();
            Console.Clear();
            kroll.KrollPostavaArt();

            DndHerniFunkce.AnimaceTextu("Toto je kroll, silný, otužilý a nesmírně odvážný...");

            DndHerniFunkce.AnimaceTextu("V soubojích využívá hrubé síly, těžkých zbraní a nebere si žádné servítky...");

            DndHerniFunkce.AnimaceTextu("Jeho speciální rasová schopnost se jmenuje Berserkův řev, který krollovi přidává útočnou hodnotu.");

            DndHerniFunkce.AnimaceTextu("Tato útočná hodnota je za cenu krollova zdraví.");
            DndHerniFunkce.AnimaceTextu("Pokud je však kroll dostatečně silný, zdraví mu není ubráno a také si přidá obrannou hodnotu.");

            DndHerniFunkce.AnimaceTextu("Krollův primární stat je síla.");
            Thread.Sleep(150);
            Console.WriteLine();
            Console.WriteLine(@"Krollovy úpravy atributů jsou:

                                 Síla: {0}
                                 Obratnost: {1}
                                 Inteligence: {2}
                                 Štěstí: {3}
                                 Zdraví je {4}, toto zdraví se sečte se Zdravím povolání pro vytvoření konečného Zdraví.
                                 ", kroll.rSila, kroll.rObratnost, kroll.rInteligence, kroll.rStesti, kroll.rZdravi);
            Thread.Sleep(200);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
            Console.ReadKey(true);
            Console.Clear();
            Console.ResetColor();
        }
    }
}