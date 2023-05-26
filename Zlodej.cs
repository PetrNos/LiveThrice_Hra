using System;
using System.Threading;

namespace DnD_Hra
{
    internal class Zlodej : Povolani // inheritovaná class z povolání
    {
        public static Zbrane zlodejovaZbran;
        public static Zbroje zlodejovaZbroj;

        public Zlodej() // hodnoty base atributů tohoto povolání
        {
            zlodejovaZbran = VytvorenePredmety.Luk;
            zlodejovaZbroj = VytvorenePredmety.Kožená_Zbroj;
            pInteligence = 1;
            pSila = 0;
            pObratnost = 2;
            pStesti = 2;
            maManu = false;

            zakladniUtocnaHodnota = 3;
            zakladniObrannaHodnota = 0;
            poskozeniZbrane = zlodejovaZbran.poskozeniZbrane;
            pUtocnaHodnota = zakladniUtocnaHodnota + poskozeniZbrane;
            hodnotaBrneni = zlodejovaZbroj.hodnotaBrneni;
            pObrannaHodnota = zakladniObrannaHodnota + hodnotaBrneni;
            pZdravi = 10 + pObrannaHodnota + pSila;
        }

        public override void ArtPovolani() // print artu postavy zlodeje
        {
            Thread.Sleep(100);
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(@"

                                                   ,==.       /\\
                                       ,-. ,-.    /( `|\     /  \\
                                      (   `-. `. /,+./,,).../___ ))
                                       \     `-.:.( \)----,[=====|E)->
                                        \        / \ \  ,'_3     ||
                                         )      / ,'\/.','  \    ))
                                        /     ,' /   `.'     \  //
                                       (   ,-/  (             \//
                                        `-' /    \             V
                                           '/^;^:^\
                                      ._.._/ /   \ \
                                     / _____/    / /
                                    (,'         / /
                                               ( (
                                                `.;

                                                            ");
            Thread.Sleep(2000);
        }

        //**********************************************************************************
        public override void PredstaveniPovolani()
        {
            Zlodej zlodej = new Zlodej();
            Console.Clear();
            zlodej.ArtPovolani();

            DndHerniFunkce.AnimaceTextu("Toto je zloděj, přesný a zákeřný, říká se, že vyvázne z každé situace...");

            DndHerniFunkce.AnimaceTextu("Jeho útoky zbraněmi jsou nejsmrtelnější, když s nimi soupeř nepočítá, v tom zloděj exceluje.");

            DndHerniFunkce.AnimaceTextu("Jeho speciální schopnost je Mistrovství Hbitosti, které je velice riskatní, ale má obrovský potenciál poškození.");

            DndHerniFunkce.AnimaceTextu("Mistrovství Hbitosti může zloděj použít kdy se mu zachce, avšak musí počítat s riskem, který to obnáší...");
            DndHerniFunkce.AnimaceTextu("Zlodějovi primární staty jsou obratnost a štěstí.");
            Thread.Sleep(150);
            Console.WriteLine();
            Console.WriteLine(@"Zlodějovi základní atributy jsou:

                                 Síla: {0}
                                 Obratnost: {1}
                                 Inteligence: {2}
                                 Štěstí: {3}
                                 Zdraví: {4}
                                 Zbroj: Kožená, hodnota brnění: {5}
                                 Zbraň: Luk, útočná hodnota: {6}
                                 Finální obranná hodnota tedy je: {7}
                                 Finální útočná hodnota potom je: {8}
                                 A nemá manu - nemůže používat kouzla.", zlodej.pSila, zlodej.pObratnost, zlodej.pInteligence, zlodej.pStesti,
                                 zlodej.pZdravi, zlodej.hodnotaBrneni, zlodej.poskozeniZbrane, zlodej.pObrannaHodnota, zlodej.pUtocnaHodnota
                                 );
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