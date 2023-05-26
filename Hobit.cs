using System;
using System.Text;
using System.Threading;

namespace DnD_Hra
{
    internal class Hobit : Rasa
    {
        public Hobit()
        {
            rObratnost = 1;
            rInteligence = -1;
            rSila = -2;
            rStesti = 2;
            rZdravi = 10 + rSila;
        }

        public void HobitPostavaArt()
        {
            Thread.Sleep(150);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Thread.Sleep(150);
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(@"  ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣴⠖⡒⠀⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⣿⣿⣥⣶⣶⡟⢤⠀⠀⠀⠀⠀⠀⠀⠀
                        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣴⡒⢶⢶⣾⣏⠛⢻⠿⠿⣿⣿⣿⣷⣦⡀⠀⠀⠀⠀⠀⠀⢀
                        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣏⣣⢃⡹⣿⣿⣦⠀⠀⠀⠛⠓⣬⡿⠛⠀⠀⠀⠀⠀⢀⠴⢻
                        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⠼⠦⢀⣁⡬⡙⣯⡈⠀⠀⠠⢀⡂⠏⠀⠀⠀⠀⠀⠀⡠⢁⠀⡇
                        ⠀⠀⠀⠀⠀⠀⠀⠀⣠⣷⠟⠟⠁⠀⠀⠑⠏⠘⢺⣤⡄⡼⠋⠀⠀⠀⠀⠀⢀⠌⠠⠇⠰⠀
                        ⠀⠀⠀⠀⠀⠀⢀⢼⡴⠃⠁⠀⠀⠀⠀⠀⠀⠑⣽⣿⣣⠇⠀⠀⠀⠀⠀⢀⠎⠌⠐⢠⠃⠀
                        ⠀⠀⠀⠀⠀⣠⡮⡼⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⡘⣟⡟⠀⠀⠀⠀⠀⠀⡌⠎⡐⡠⠁⠀⠀
                        ⠀⠀⠀⠀⡔⢣⡜⠂⠀⠀⢀⡴⠂⢉⡩⠤⣀⢢⣠⢿⠇⠀⠀⠀⠀⠀⣸⡘⠔⡔⠁⠀⠀⠀
                        ⠀⡠⠤⠊⠑⡎⠀⠀⠀⠀⠉⠀⢔⠕⠉⠉⠱⡻⡍⡜⠀⠀⠀⠀⠀⣔⣽⠍⡞⠀⠀⠀⠀⠀
                        ⠀⠻⠱⠶⡟⠀⠀⠀⢠⠃⠀⢊⡆⠀⠨⠩⡿⢿⢼⣇⣀⡀⢀⠿⢍⠙⢣⡖⠁⠀⠀⠀⠀⠀
                        ⠀⠀⠀⢸⠀⢀⠀⢠⠃⠀⠀⡮⠽⡄⠀⣔⠀⠃⠀⠉⠉⡌⠁⠀⠀⢉⣒⡯⠆⠀⠀⠀⠀⠀
                        ⠀⠀⠀⢸⠀⠄⠀⠀⠀⠀⠀⡧⠜⠛⣦⣉⡀⠀⠀⢀⠀⣧⣤⣀⣐⣒⡞⠁⠀⠀⠀⠀⠀⠀
                        ⠀⠀⠀⢸⢇⡇⠀⠀⠀⠀⢀⡋⠩⠼⠶⠤⡯⠓⢖⠒⠳⣿⣟⡺⠉⠉⠀⠀⠀⠀⠀⠀⠀⠀
                        ⠀⠀⠀⢸⢸⡇⠀⡀⠀⠀⢸⢻⠒⠲⡲⢃⡴⡀⠘⢦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                        ⠀⠀⠀⢸⠀⡇⡇⡇⠀⠀⢸⣼⣴⣬⠤⠚⠓⠃⠀⠀⠳⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                        ⠀⠀⠀⢸⢀⠁⡇⡇⠀⠀⣸⣩⠏⠐⠲⢤⣄⣠⡀⠀⠀⠙⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                        ⠀⠀⠀⢸⢸⢠⡇⡇⠀⠀⢟⢙⠀⠀⠀⠔⢣⢏⠰⠭⢂⢀⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                        ⠀⠀⠀⢸⢸⠀⠇⠀⠀⠀⡄⡀⢀⡠⠂⠀⠀⣹⡩⢫⢿⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                        ⠀⠀⣠⢾⢸⠀⢠⠀⠀⠀⡇⡇⠘⢎⠀⠉⠉⠀⠀⢁⠊⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                        ⠀⠸⣅⣸⢸⠀⢸⠀⠀⢰⣴⠇⢀⠜⠑⠒⡶⠞⠊⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                        ⠀⠀⠀⠸⡎⢸⣿⠀⠀⢸⠀⢀⠎⠀⣤⣞⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                        ⠀⠀⠀⠀⠱⣸⡟⠀⡇⢸⢰⠁⠀⠁⣃⢭⣿⣶⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                        ⠀⠀⠀⠀⠀⠀⢧⣤⡇⣯⠈⠑⠒⠒⠒⠠⠤⢭⠭⠽⠗⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                        ⠀⠀⠀⠀⠀⠀⠀⠈⠓⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
            Thread.Sleep(2000);
        }

        public override void PredstaveniRasy()
        {
            Hobit hobit = new Hobit();
            Console.Clear();
            hobit.HobitPostavaArt();

            DndHerniFunkce.AnimaceTextu("Toto je hobit, veselý, všudepřítomný a charismatický...");

            DndHerniFunkce.AnimaceTextu("V soubojích využívá své mrštnosti a selského rozumu, nějakou záhadou mu vždy všechno vyjde...");

            DndHerniFunkce.AnimaceTextu("Jeho speciální rasová schopnost se jmenuje Záhadné štěstí, které výrazně vylepšuje hobitovi hody kostkou.");

            DndHerniFunkce.AnimaceTextu("Záhadné štěstí také někdy přidává hobitovi i obrannou hodnotu.");

            DndHerniFunkce.AnimaceTextu("Hobitovi primární staty jsou štěstí a mírně také obratnost.");

            Thread.Sleep(150);
            Console.WriteLine();
            Console.WriteLine(@"Hobitovi úpravy atributů jsou:

                                 Síla: {0}
                                 Obratnost: {1}
                                 Inteligence: {2}
                                 Štěstí: {3}
                                 Zdraví je {4}, toto zdraví se sečte se Zdravím povolání pro vytvoření konečného Zdraví.
                                 ", hobit.rSila, hobit.rObratnost, hobit.rInteligence, hobit.rStesti, hobit.rZdravi);
            Thread.Sleep(200);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
            Console.ReadKey(true);
            Console.Clear();
            Console.ResetColor();
        }
    }
}