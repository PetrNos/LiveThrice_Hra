using System;
using System.Threading;

namespace DnD_Hra
{
    internal class Elf : Rasa
    {
        public Elf()
        {
            rObratnost = 1;
            rInteligence = 2;
            rSila = -3;
            rStesti = 0;
            rZdravi = 10 + rSila;
        }

        public void ElfPostavaArt()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Thread.Sleep(150);
            Console.ForegroundColor = ConsoleColor.Green;
            Thread.Sleep(150);
            Console.WriteLine(@"

                                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⣖⢄⠀⣀⣀⣀⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡽⡤⢝⢅⡀⣤⢴⠶⠿⢷⢦⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡎⠀⠈⣧⢫⡻⡀⠀⣀⡴⡷⠛⢻⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⡜⠀⢻⡳⡙⣧⡕⢹⢇⣤⣄⢧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⣼⠁⢠⣫⣟⢿⣷⠀⢸⠀⠐⢾⢣⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣷⡙⢀⢂⡿⢸⣞⡟⠀⣾⠀⠀⠀⠀⢃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣧⡊⡜⠀⢸⣿⡇⠀⡿⠀⠀⠈⢒⠊⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣧⣻⠌⠀⣠⣿⣿⠁⠀⡇⠀⠉⢡⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡼⠓⢁⠤⡺⣟⣷⢿⡀⡇⡷⡖⠤⠼⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⣀⣀⣀⣠⣤⣴⣋⣒⣨⣴⣞⢾⡀⢾⣽⡇⡇⡿⣣⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠫⡣⡀⠑⢄⠀⠌⣣⣻⣖⣮⠷⢗⢵⣕⣾⣿⠇⡇⣇⡸⣿⡿⢖⠖⣶⠤⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⡿⢖⠪⣨⠣⡲⣂⠀⢸⢻⢻⣿⢶⢫⠾⡿⣾⢙⡇⠀⣿⢻⣿⣿⣿⡿⣾⢄⣀⡙⢋⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⣨⢰⠏⣵⢵⣍⠓⠲⡿⣾⢻⣾⡿⠈⠀⠉⠉⠹⣰⠃⠻⠁⠀⠀⠀⠘⣾⣿⣃⣴⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣗⡎⣫⠿⣫⠉⣺⣿⢿⣧⣎⡿⡃⠀⠀⠀⠀⠀⠑⣤⠀⣤⠀⠀⠀⠀⠸⣻⠛⢿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡏⠍⢹⠀⣑⠞⠣⢡⡟⢳⣟⢧⣳⣜⠣⠀⠀⠀⣦⢹⢀⢻⢕⠀⠀⣾⢸⡿⣄⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢣⣇⣼⠗⠁⠀⠀⢱⠁⠀⠙⠳⣫⡩⣅⣀⣀⣠⣽⡸⣩⠵⠿⠚⣶⣿⣤⠟⠈⢻⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⡎⠁⠀⠀⠀⠀⡆⠀⠀⠀⠀⠈⠙⠲⢭⣛⣛⣯⣿⡵⡞⠉⠉⣿⡿⣻⠃⠀⠀⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⢠⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠑⠪⣿⣧⢀⡠⡾⠊⢸⠀⠀⠀⠸⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⠃⠀⠀⠀⠀⢸⠳⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠲⠚⠁⠀⣸⠀⠀⠀⠀⢧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⠀⠀⠀⠀⣿⠀⠙⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣧⠀⠀⠀⠰⢌⣣⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⠃⠀⠀⡰⢳⠀⡇⠀⠀⠈⢧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⢣⠀⠀⢰⠀⠙⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡏⠀⢀⡜⠁⠘⡆⡇⠀⠀⠀⠈⡇⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡿⠀⠉⠀⢸⠀⢀⡼⡆⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡼⠀⢠⠮⢿⣆⠀⣇⣇⠀⠀⠀⢠⡷⣏⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡇⠀⠀⠀⢸⢰⠟⢩⢽⡄⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡇⣰⡏⣵⡄⣿⡆⢸⣿⠀⠀⢀⠟⠁⡆⢳⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⡇⠀⠀⠀⢸⡿⢾⡾⣸⢱⠀⠀


                                                            ");
            Thread.Sleep(2000);
        }

        public override void PredstaveniRasy()
        {
            Elf elf = new Elf();
            Console.Clear();
            elf.ElfPostavaArt();

            DndHerniFunkce.AnimaceTextu("Toto je elf, bystrý, inteligentní a mystický...");

            DndHerniFunkce.AnimaceTextu("Souboje vnímá takticky a přemýšlí dopředu nad každým krokem.");

            DndHerniFunkce.AnimaceTextu("Jeho speciální rasová schopnost se jmenuje Magický Šálek, který je schopen léčit elfa v poměrně vysokých hodnotách.");

            DndHerniFunkce.AnimaceTextu("Magický Šálek také umožňuje elfovi se léčit, do maxima jeho zdraví.");

            DndHerniFunkce.AnimaceTextu("Elf však může šálek použít, jen pokud je pod určitou hranicí zdraví. Pokud má elf manu, je mu přidána i ta.");

            DndHerniFunkce.AnimaceTextu("Elfovi primární staty jsou inteligence a mírně obratnost se štěstím.");

            Thread.Sleep(150);
            Console.WriteLine();
            Console.WriteLine(@"Elfovi úpravy atributů jsou:

                                 Síla: {0}
                                 Obratnost: {1}
                                 Inteligence: {2}
                                 Štěstí: {3}
                                 Zdraví je {4}, toto zdraví se sečte se Zdravím povolání pro vytvoření konečného Zdraví.
                                 ", elf.rSila, elf.rObratnost, elf.rInteligence, elf.rStesti, elf.rZdravi);
            Thread.Sleep(200);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
            Console.ReadKey();
            Console.Clear();
            Console.ResetColor();
        }
    }
}