using System;
using System.Threading;

namespace DnD_Hra
{
    internal class Valecnik : Povolani // inheritovaná class z povolání
    {
        public static Zbrane valecnikovaZbran;
        public static Zbroje valecnikovaZbroj;

        public Valecnik() // hodnoty base atributů tohoto povolání
        {
            valecnikovaZbran = VytvorenePredmety.Meč;
            valecnikovaZbroj = VytvorenePredmety.Železná_Zbroj;

            pInteligence = 0;
            pSila = 3;
            pObratnost = 1;
            pStesti = 1;
            maManu = false;

            zakladniUtocnaHodnota = 0;
            zakladniObrannaHodnota = 3;
            poskozeniZbrane = valecnikovaZbran.poskozeniZbrane;
            pUtocnaHodnota = zakladniUtocnaHodnota + poskozeniZbrane;
            hodnotaBrneni = valecnikovaZbroj.hodnotaBrneni;
            pObrannaHodnota = zakladniObrannaHodnota + hodnotaBrneni;
            pZdravi = 10 + pObrannaHodnota + pSila;
        }

        public override void ArtPovolani() // print artu postavy valecnika
        {
            
            Thread.Sleep(100);
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine(@"
                                                              ⣰⡷⠁
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠞⠉⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⠊⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢨⠀⠀⡄⠀⠀⠀⠀⠀⠀⣀⠠⢀⠀⠀⠀⠀⠀⠠⠊⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣇⠠⣄⢱⡀⠀⠀⠀⠀⣆⡌⠐⠺⢔⣠⡠⠀⠀⠀⠀⠀⠀⠀⢀⡤⢲
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡂⢻⣧⢾⡟⡗⡀⣀⣀⠀⡯⠰⠀⣳⣴⢋⠂⢂⠀⣀⡀⠤⠐⠂⠈⠉⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⠂⠹⣿⣻⣾⣿⠗⣄⢀⣢⣿⣟⡆⠀⣧⡇⣼⡖⠒⠟⣥⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣴⡀⠀⠃⠍⠹⠃⠑⢋⣹⡗⡗⣿⢁⠘⣾⣧⣿⣯⢿⣇⢻⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡀⢋⢋⢷⡀⠀⠀⠦⢤⣗⣿⣅⠹⣴⠹⡎⠠⡿⡏⣿⣽⢿⣿⢸⡀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⢓⢃⣪⣿⢾⣷⣄⡀⠀⠈⠛⠿⣿⢍⡭⣶⢳⠄⢰⣅⠻⣷⠘⣿⢸⠇⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⢀⣼⣾⣯⡷⠟⠉⠀⠋⣿⣖⣶⣦⣄⡀⣀⠉⣣⣿⣿⣯⡈⠈⠀⡗⠸⡇⠨⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⢤⠄⣀⣾⡿⣶⠏⠀⠀⠀⠀⠀⢸⣥⣿⣿⣟⣿⣷⢶⣿⢿⡿⣿⣎⡀⠀⠀⠀⠠⠂⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⣸⠲⣿⣷⣿⠃⠀⠀⠀⠈⠖⣉⢿⣻⡿⣽⣟⣿⢽⣟⠥⠝⣿⡉⢟⣯⠢⠀⠜⠊⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⣿⣷⣹⠟⠛⠀⠀⠀⠀⠀⣄⢀⣾⡯⠾⠙⠭⠿⠺⠉⣗⣒⣻⣿⡷⠂⠙⠂⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠙⣿⠁⠀⠀⠀⠀⠀⠀⢀⡻⣻⠯⣬⢩⣵⣦⠤⣧⡠⣿⣑⡒⢒⡂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⣿⡆⠀⠀⠀⠀⠀⠀⠀⠻⢿⢯⣥⣀⡶⣒⣊⣣⣬⢭⡶⠒⠛⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⢄⡀⠼⠝⡄⠀⠀⠀⠀⠀⠄⡀⣀⣈⣽⠟⠀⠀⠀⠈⢻⠿⠀⡤⢤⢂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⢈⡷⠒⠛⠁⠀⠀⠀⠀⠈⠐⡀⢀⡼⠋⠀⠀⠀⠀⠀⠀⢄⠀⠀⠊⠸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⠡⠤⢾⠊⠀⠀⠀⠀⠀⠀⠀⠀⠈⢂⢀⣰⡃⠆⠀⠀⠠⠀⡀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠄⠀⠀⠀⠀⠀⣴⣄⣰⡇⠀⠀⠀⠐⠂⡀⠀⠈⠀⠀⠀⣫⢩⠴⣊⡤⠀⠀⠐⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠠⠤⡄⠀⠀⢺⡋⣿⣷⠀⡀⣸⠀⠀⠀⠀⠄⠀⠐⠀⠈⣹⣿⣋⠈⢃⠀⠀⠂⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⡂⢀⠰⢀⠀⠘⣎⢹⣿⠃⠀⠹⠠⢀⠀⠄⡀⠀⠀⠀⣠⠔⠙⢿⣦⠐⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠈⡀⠀⡃⠀⠅⠀⠂⠀⣿⢸⣗⡀⠐⠐⠨⠀⢀⠀⡡⠗⠱⡿⠥⡠⠀⠛⢿⡆⢇⠀⠄⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠈⠀⠈⠁⠀⠀⡀⠀⣦⣟⢼⣯⣅⢀⢀⡀⠈⠙⠶⠀⡵⠓⠙⠀⠀⠉⠁⢼⡧⠁⡄⠒⠂⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⢀⡀⣤⠤⠤⠤⠬⣬⡬⢿⠾⠿⢟⢛⠟⠼⠳⠒⢠⠐⣶⠶⣶⠶⢿⣿⣿⣟⣛⣋⡷⠂⠀⠄⠒⠀⠀⠀⠀


                                                            ");
            Thread.Sleep(2000);
        }

        //**********************************************************************************
        public override void PredstaveniPovolani()
        {
            Valecnik valecnik = new Valecnik();
            Console.Clear();
            valecnik.ArtPovolani();

            DndHerniFunkce.AnimaceTextu("Toto je válečník, věrný a odolný, připraven na každou bitvu...");

            DndHerniFunkce.AnimaceTextu("Skvěle odolává poškození nepřátel a dokáže být smrtící v přímém souboji.");

            DndHerniFunkce.AnimaceTextu("Jeho speciální schopnost se jmenuje Přímý Zásah a je schopna velmi vysokého poškození proti jednotlivcům.");

            DndHerniFunkce.AnimaceTextu("Tu však může použít jen pokud nastřádal dostatek detailů o slabinách nepřátel, to tak, že provádí úspěšné zásahy útokem.");
            DndHerniFunkce.AnimaceTextu("Válečníkův primární stat je síla.");
            Thread.Sleep(150);
            Console.WriteLine();
            Console.WriteLine(@"Válečníkovi základní atributy jsou:

                                 Síla: {0}
                                 Obratnost: {1}
                                 Inteligence: {2}
                                 Štěstí: {3}
                                 Zdraví: {4}
                                 Zbroj: Železná, hodnota brnění: {5}
                                 Zbraň: Meč, útočná hodnota: {6}
                                 Finální obranná hodnota tedy je: {7}
                                 Finální útočná hodnota potom je: {8}
                                 A nemá manu - nemůže používat kouzla.", valecnik.pSila, valecnik.pObratnost, valecnik.pInteligence, valecnik.pStesti,
                                 valecnik.pZdravi, valecnik.hodnotaBrneni, valecnik.poskozeniZbrane, valecnik.pObrannaHodnota, valecnik.pUtocnaHodnota);
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