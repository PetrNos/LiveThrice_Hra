using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DnD_Hra
{
    internal class Obchod
    {
        /// <summary>
        /// FiltrItemu - 1 - Itemy jen pro zbrojínu, 2 - Jen pro Pouzitelne, 3 - jen pro suroviny
        /// </summary>
        /// <param name="hracuvInventar"></param>
        /// <param name="obchodniInventar"></param>
        /// <param name="VitejteV_"></param>
        /// <param name="koeficientSnizeni"></param>
        /// <param name="FiltrItemu"></param>
        public static void Obchodovani(Inventar hracuvInventar, Inventar obchodniInventar, string VitejteV_, double koeficientSnizeni = 0.5, int FiltrItemu = 0)
        {
            Inventar.OdeberNepotrebne(hracuvInventar);
            Inventar.OdeberNepotrebne(obchodniInventar);
            while (true)
            {
                int zvolenyIndex = ZobrazHlavniMenu(VitejteV_);
                if (zvolenyIndex == 2)
                {
                    Menu jsteSiJisti = new Menu("Opravdu chcete odejít z obchodu?", new List<string> { "Ano", "Ne" }, ConsoleColor.Red);
                    int zvolenaMoznost = jsteSiJisti.NavratIndexu();
                    if (zvolenaMoznost == 0)
                        break;
                    else if (zvolenaMoznost == 1)
                        continue;
                }
                if (zvolenyIndex == 0)
                {
                    KupPredmety(hracuvInventar, obchodniInventar);
                }
                else if (zvolenyIndex == 1)
                {
                    ProdejPredmety(hracuvInventar, koeficientSnizeni,FiltrItemu);
                }
            }
        }

        private static int ZobrazHlavniMenu(string nazevObchodu)
        {
            Console.CursorVisible = false;
            Menu menu = new Menu($"Vítejte v {nazevObchodu}, co chcete udělat?", new List<string> { "Nakoupit", "Prodat své věci", "Opustit Obchod" }, ConsoleColor.Yellow);
            return menu.NavratIndexu();
        }

        private static void KupPredmety(Inventar hracuvInventar, Inventar obchodniInventar)
        {
            Console.Clear();
            while(true)
            {
                var grouplej = obchodniInventar.ListInventare().GroupBy(b => b.ID).Select(g => g.First());
                var obchodniInventarList = grouplej.ToList()

    .Select(g => g.nazevPredmetu + " (" + g.pocetPredmetu(obchodniInventar) + ") " + g.hodnotaPredmetu + " zlata" + (g is Zbrane && (g as Zbrane).schopnostZbrane != null ? " (Se schopností)" : "") + (g is Zbroje && (g as Zbroje).schopnostZbroje != null ? " (Se schopností)" : "") + ((g is Specialni) ? " (Speciální předmět)" : ""))
    .ToList();
                obchodniInventarList.Add("Vrátit zpět");

                Menu menuKoupit = new Menu($"Vyberte si položku k nákupu, nyní máte {VasePostava.inventarPostavy.PocetZlata()} zlata", obchodniInventarList, ConsoleColor.Yellow);
                int indexPredmetu = menuKoupit.NavratIndexu();
                if (indexPredmetu == obchodniInventarList.Count - 1)
                {
                    break;
                }
                Predmety vybranyPredmet = grouplej.ToList()[indexPredmetu];

                if (VasePostava.inventarPostavy.PocetZlata() >= vybranyPredmet.hodnotaPredmetu)
                {
                    Inventar.OdeberZlato(vybranyPredmet.hodnotaPredmetu, VasePostava.inventarPostavy);
                    VasePostava.inventarPostavy.PridejPredmet(vybranyPredmet);
                    obchodniInventar.OdeberPredmet(vybranyPredmet);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Koupili jste {0} za {1} zlata.", vybranyPredmet.nazevPredmetu, vybranyPredmet.hodnotaPredmetu);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Nyní máte {0} zlata.", hracuvInventar.PocetZlata());
                    Console.ResetColor();
                    Thread.Sleep(100);
                    Console.WriteLine();
                    Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
                    Console.ReadKey(true);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Nemáte dostatek zlata na koupi {0}.", vybranyPredmet.nazevPredmetu);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Nyní máte {0} zlata.", hracuvInventar.PocetZlata());
                    Console.ResetColor();
                    Thread.Sleep(100);
                    Console.WriteLine();
                    Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
                    Console.ReadKey(true);
                }
            }
        }

        private static void ProdejPredmety(Inventar hracuvInventar, double koeficientSnizeni, int FiltrItemu)
        {
            // Prodat
            Console.Clear();
            while(true)
            {

                var NoGoldy = hracuvInventar.ListInventare()
                .Where(z => z!=VytvorenePredmety.Zlaťák)
                .GroupBy(z => z.ID)
                .Select(g => g.First())
                .ToList();
                if (!(FiltrItemu >= 0 && FiltrItemu <= 3))
                    throw new Exception("Filtr předmětů je mimo dané rozmezí");
                if (FiltrItemu == 1)
                    NoGoldy.RemoveAll(p => !(p is Zbrane) && !(p is Zbroje));
                else if (FiltrItemu == 2)
                    NoGoldy.RemoveAll(p => !(p is Pouzitelne));
                else if (FiltrItemu == 3)
                    NoGoldy.RemoveAll(p => !(p is Suroviny));
                var hracuvInventarList = NoGoldy.ToList().Select(p => p.nazevPredmetu + " (" + p.pocetPredmetu(hracuvInventar) + ") " + (int)Math.Ceiling(p.hodnotaPredmetu * koeficientSnizeni) + " zlata" + (p == VasePostava.zbranPostavy || p == VasePostava.alternativniZbranPostavy || p == VasePostava.zbrojPostavy ? " (Vybaveno)" : "") + (p.pocetVylepseniPredmetu > 1 ? $" ({p.pocetVylepseniPredmetu - 1}x Vylepšeno)" : "") + (p is Zbrane && (p as Zbrane).schopnostZbrane != null ? " (Se schopností)" : "") + (p is Zbroje && (p as Zbroje).schopnostZbroje != null ? " (Se schopností)" : "")).ToList();
                hracuvInventarList.Add("Vrátit zpět");

                Menu menuProdat = new Menu($"Vyberte si položku k prodeji, nyní máte {hracuvInventar.PocetZlata()} zlata.", hracuvInventarList, ConsoleColor.Yellow);
                int indexPredmetu = menuProdat.NavratIndexu();
                if (indexPredmetu == hracuvInventarList.Count - 1)
                {
                    // návrat do hlavního menu
                    break;
                }
                Predmety vybranyPredmet = NoGoldy.ToList()[indexPredmetu];//C
                if (vybranyPredmet.typPredmetu == TypPredmetu.Specialni)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Tento předmět nelze prodat, jedná se o speciální předmět...");
                    Console.ResetColor();
                    Thread.Sleep(100);
                    Console.WriteLine();
                    Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
                    Console.ReadKey(true);
                    return;
                }
                if (vybranyPredmet == VasePostava.vybavenaAltZbran || vybranyPredmet == VasePostava.vybavenaZbran || vybranyPredmet == VasePostava.vybavenaZbroj || vybranyPredmet.pocetVylepseniPredmetu > 1)
                {
                    Menu vybavenyPredmetMenu = new Menu("Tento předmět máte právě vybaveni, nebo je vylepšený. Jste si jisti jeho prodejem?", new List<string> { "Ano, prodat", "Ne, neprodávat" }, ConsoleColor.Red);
                    int volbaHrace = vybavenyPredmetMenu.NavratIndexu();
                    if (volbaHrace == 0)
                    {
                        if (vybranyPredmet == VasePostava.vybavenaAltZbran)
                        {
                            VasePostava.alternativniZbranPostavy = VytvorenePredmety.Žádná_Zbraň;
                            VasePostava.vybavenaAltZbran = VytvorenePredmety.Žádná_Zbraň;
                        }
                        else if (vybranyPredmet == VasePostava.vybavenaZbran)
                        {
                            VasePostava.zbranPostavy = VytvorenePredmety.Žádná_Zbraň;
                            VasePostava.vybavenaZbran = VytvorenePredmety.Žádná_Zbraň;
                        }
                        else if (vybranyPredmet == VasePostava.zbrojPostavy)
                        {
                            VasePostava.zbrojPostavy = VytvorenePredmety.Žádná_Zbroj;
                            VasePostava.vybavenaZbroj = VytvorenePredmety.Žádná_Zbroj;
                        }

                        ProdalPredmet();
                    }
                    else if (volbaHrace == 1)
                        return;
                }
                else
                    ProdalPredmet();

                void ProdalPredmet()
                {
                    Inventar.PridejZlato((int)Math.Ceiling(vybranyPredmet.hodnotaPredmetu * koeficientSnizeni), hracuvInventar);
                    hracuvInventar.OdeberPredmet(vybranyPredmet);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Prodali jste {0} za {1} zlata.", vybranyPredmet.nazevPredmetu, (int)Math.Ceiling(vybranyPredmet.hodnotaPredmetu * koeficientSnizeni));
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Nyní máte {0} zlata.", hracuvInventar.PocetZlata());
                    Console.ResetColor();
                    Thread.Sleep(100);
                    Console.WriteLine();
                    Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
                    Console.ReadKey(true);
                }
            }

            // Prodal item spráťa
           
        }

        public static void KovarnaObchod(Inventar hracuvInventar, Inventar InventarProdavajiciho, string VitejteV__Kovarne, double KoeficientCeny = 0.5)
        {
            //hracuvInventar.ListInventare().RemoveAll(p => !(p is Zbrane) || !(p is Zbroje));
            Obchodovani(hracuvInventar, InventarProdavajiciho, $"{VitejteV__Kovarne} Kovárně", KoeficientCeny, 1);
            
        }
        public static void LaboratorObchod(Inventar hracuvInventar, Inventar InventarProdavajiciho, string VitejteV__AlchymistickéLaboratoři, double KoeficientCeny = 0.5)
        {
          
            Obchodovani(hracuvInventar, InventarProdavajiciho, $"{VitejteV__AlchymistickéLaboratoři} Alchymistické Laboratoři", KoeficientCeny, 2);
        }
        public static void SurovinyObchod(Inventar hracuvInventar, Inventar InventarProdavajiciho, string VitejteV__ObchoduSeSurovinami, double KoeficientCeny = 0.5)
        {
           
            Obchodovani(hracuvInventar, InventarProdavajiciho, $"{VitejteV__ObchoduSeSurovinami} Obchodu se surovinami", KoeficientCeny, 3);
        }


        public static void ObchodovaniZaZivoty(Inventar hracuvInventar, Inventar obchodniInventar, string NachaziteSeV_, double koeficientSnizeni = 0.5, int FiltrItemu = 0)
        {
            Inventar.OdeberNepotrebne(hracuvInventar);
            Inventar.OdeberNepotrebne(obchodniInventar);
            while (true)
            {
                int zvolenyIndex = HlavniMenu(NachaziteSeV_);
                if (zvolenyIndex == 2)
                {
                    Menu jsteSiJisti = new Menu("Opravdu chcete odejít z obchodu?", new List<string> { "Ano", "Ne" }, ConsoleColor.Red);
                    int zvolenaMoznost = jsteSiJisti.NavratIndexu();
                    if (zvolenaMoznost == 0)
                        break;
                    else if (zvolenaMoznost == 1)
                        continue;
                }
                if (zvolenyIndex == 0)
                {
                    KupPredmetyHP(hracuvInventar, obchodniInventar);
                }
                else if (zvolenyIndex == 1)
                {
                    ProdejPredmetyHP(hracuvInventar, koeficientSnizeni, FiltrItemu);
                }
            }
        }

        private static int HlavniMenu(string nazevObchodu)
        {
            Console.CursorVisible = false;
            Menu menu = new Menu($"Nacházíte se v {nazevObchodu}, co chcete udělat?", new List<string> { "Nakoupit", "Prodat své věci", "Opustit Obchod" }, ConsoleColor.DarkMagenta);
            return menu.NavratIndexu();
        }

        private static void KupPredmetyHP(Inventar hracuvInventar, Inventar obchodniInventar)
        {
            Console.Clear();
            while (true)
            {
                var grouplej = obchodniInventar.ListInventare().GroupBy(b => b.ID).Select(g => g.First());
                var obchodniInventarList = grouplej.ToList()

    .Select(g => g.nazevPredmetu + " (" + g.pocetPredmetu(obchodniInventar) + ") " + g.hodnotaPredmetu + " životů" + (g is Zbrane && (g as Zbrane).schopnostZbrane != null ? " (Se schopností)" : "") + (g is Zbroje && (g as Zbroje).schopnostZbroje != null ? " (Se schopností)" : "") + ((g is Specialni) ? " (Speciální předmět)" : ""))
    .ToList();
                obchodniInventarList.Add("Vrátit zpět");

                Menu menuKoupit = new Menu($"Vyberte si položku k nákupu, nyní máte {VasePostava.hracovaPostava.vZdravi} zdraví", obchodniInventarList, ConsoleColor.Yellow);
                int indexPredmetu = menuKoupit.NavratIndexu();
                if (indexPredmetu == obchodniInventarList.Count - 1)
                {
                    break;
                }
                Predmety vybranyPredmet = grouplej.ToList()[indexPredmetu];

                if (VasePostava.hracovaPostava.vZdravi >= vybranyPredmet.hodnotaPredmetu)
                {
                    VasePostava.hracovaPostava.vZdravi -= vybranyPredmet.hodnotaPredmetu;
                    VasePostava.hracovaPostava.RekonfiguraceHPaMany();
                    hracuvInventar.PridejPredmet(vybranyPredmet);
                    obchodniInventar.OdeberPredmet(vybranyPredmet);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("Koupili jste {0} za {1} zdraví.", vybranyPredmet.nazevPredmetu, vybranyPredmet.hodnotaPredmetu);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Nyní máte {0} zdraví.", VasePostava.hracovaPostava.vZdravi);
                    Console.ResetColor();
                    Thread.Sleep(100);
                    Console.WriteLine();
                    Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
                    Console.ReadKey(true);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nemáte dostatek zdraví na koupi {0}.", vybranyPredmet.nazevPredmetu);
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Nyní máte {0} zdraví.", VasePostava.hracovaPostava.vZdravi);
                    Console.ResetColor();
                    Thread.Sleep(100);
                    Console.WriteLine();
                    Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
                    Console.ReadKey(true);
                }
            }
        }

        private static void ProdejPredmetyHP(Inventar hracuvInventar, double koeficientSnizeni, int FiltrItemu)
        {
            // Prodat
            Console.Clear();
            while (true)
            {

                var NoGoldy = hracuvInventar.ListInventare()
                .Where(z => z != VytvorenePredmety.Zlaťák)
                .GroupBy(z => z.ID)
                .Select(g => g.First())
                .ToList();
                if (!(FiltrItemu >= 0 && FiltrItemu <= 3))
                    throw new Exception("Filtr předmětů je mimo dané rozmezí");
                if (FiltrItemu == 1)
                    NoGoldy.RemoveAll(p => !(p is Zbrane) && !(p is Zbroje));
                else if (FiltrItemu == 2)
                    NoGoldy.RemoveAll(p => !(p is Pouzitelne));
                else if (FiltrItemu == 3)
                    NoGoldy.RemoveAll(p => !(p is Suroviny));
                var hracuvInventarList = NoGoldy.ToList().Select(p => p.nazevPredmetu + " (" + p.pocetPredmetu(hracuvInventar) + ") " + (int)Math.Ceiling(p.hodnotaPredmetu * koeficientSnizeni) + " zlata" + (p == VasePostava.zbranPostavy || p == VasePostava.alternativniZbranPostavy || p == VasePostava.zbrojPostavy ? " (Vybaveno)" : "") + (p.pocetVylepseniPredmetu > 1 ? $" ({p.pocetVylepseniPredmetu - 1}x Vylepšeno)" : "") + (p is Zbrane && (p as Zbrane).schopnostZbrane != null ? " (Se schopností)" : "") + (p is Zbroje && (p as Zbroje).schopnostZbroje != null ? " (Se schopností)" : "")).ToList();
                hracuvInventarList.Add("Vrátit zpět");

                Menu menuProdat = new Menu($"Vyberte si položku k prodeji, nyní máte {hracuvInventar.PocetZlata()} zlata.", hracuvInventarList, ConsoleColor.Yellow);
                int indexPredmetu = menuProdat.NavratIndexu();
                if (indexPredmetu == hracuvInventarList.Count - 1)
                {
                    // návrat do hlavního menu
                    break;
                }
                Predmety vybranyPredmet = NoGoldy.ToList()[indexPredmetu];//C
                if (vybranyPredmet.typPredmetu == TypPredmetu.Specialni)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Tento předmět nelze prodat, jedná se o speciální předmět...");
                    Console.ResetColor();
                    Thread.Sleep(100);
                    Console.WriteLine();
                    Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
                    Console.ReadKey(true);
                    return;
                }
                if (vybranyPredmet == VasePostava.vybavenaAltZbran || vybranyPredmet == VasePostava.vybavenaZbran || vybranyPredmet == VasePostava.vybavenaZbroj || vybranyPredmet.pocetVylepseniPredmetu > 1)
                {
                    Menu vybavenyPredmetMenu = new Menu("Tento předmět máte právě vybaveni, nebo je vylepšený. Jste si jisti jeho prodejem?", new List<string> { "Ano, prodat", "Ne, neprodávat" }, ConsoleColor.Red);
                    int volbaHrace = vybavenyPredmetMenu.NavratIndexu();
                    if (volbaHrace == 0)
                    {
                        if (vybranyPredmet == VasePostava.vybavenaAltZbran)
                        {
                            VasePostava.alternativniZbranPostavy = VytvorenePredmety.Žádná_Zbraň;
                            VasePostava.vybavenaAltZbran = VytvorenePredmety.Žádná_Zbraň;
                        }
                        else if (vybranyPredmet == VasePostava.vybavenaZbran)
                        {
                            VasePostava.zbranPostavy = VytvorenePredmety.Žádná_Zbraň;
                            VasePostava.vybavenaZbran = VytvorenePredmety.Žádná_Zbraň;
                        }
                        else if (vybranyPredmet == VasePostava.zbrojPostavy)
                        {
                            VasePostava.zbrojPostavy = VytvorenePredmety.Žádná_Zbroj;
                            VasePostava.vybavenaZbroj = VytvorenePredmety.Žádná_Zbroj;
                        }

                        ProdalPredmet();
                    }
                    else if (volbaHrace == 1)
                        return;
                }
                else
                    ProdalPredmet();

                void ProdalPredmet()
                {
                    Inventar.PridejZlato((int)Math.Ceiling(vybranyPredmet.hodnotaPredmetu * koeficientSnizeni), hracuvInventar);
                    hracuvInventar.OdeberPredmet(vybranyPredmet);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Prodali jste {0} za {1} zlata.", vybranyPredmet.nazevPredmetu, (int)Math.Ceiling(vybranyPredmet.hodnotaPredmetu * koeficientSnizeni));
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Nyní máte {0} zlata.", hracuvInventar.PocetZlata());
                    Console.ResetColor();
                    Thread.Sleep(100);
                    Console.WriteLine();
                    Console.WriteLine("stiskněte libovolné tlačítko pro pokračování");
                    Console.ReadKey(true);
                }
            }

            // Prodal item spráťa

        }
    }
}