using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static System.Console;
using static DnD_Hra.VytvorenePredmety;

namespace DnD_Hra
{
    class Katalog
    {
        public static void HracuvDenik()
        {
            int volba;
            while(true)
            {
              volba = VyberMenuKatalogu();
                if (volba == 5)
                    break;
                else if (volba == 0)
                    Bestiar.VyberStvoreni();
                else if (volba == 1)
                    ZobrazeniZbrani();
                else if (volba == 2)
                    ZobrazeniZbroji();
                else if (volba == 3)
                    ZobrazeniPouzitelnych();
                else if (volba == 4)
                    ZobrazeniSpecialnich();
            }
        }
        private static int VyberMenuKatalogu()
        {
            Menu vyberKatalogu = new Menu("Vyberte si, o čem chcete zobrazit Vaše dosavadní poznatky: ", new List<string>() { "Stvoření", "Zbraně", "Zbroje","Použitelné předměty", "Speciální předměty", "Zavřít deník"}, ConsoleColor.Yellow);
            return vyberKatalogu.NavratIndexu();
        }
        private static void ZobrazeniZbrani()
        {
            while(true)
            {

                var seznamZbrani = TvrobaPredmetu.SeznamReceptů.Where(z => z.vyrobenyPredmet is Zbrane).ToList();
                var vypisZbraniMenu = seznamZbrani.Select(z => "Zbraň: " + (z.vyrobenyPredmet.nazevPredmetu)).ToList();
                vypisZbraniMenu.Add("Odejít");
                Menu menuZbrani = new Menu("Vyberte si zbraň, o které se chcete dozvědět více", vypisZbraniMenu, ConsoleColor.Red);
                int index = menuZbrani.NavratIndexu();
                if (index == vypisZbraniMenu.Count - 1)
                    break;
                Recepty vybranyRecept = seznamZbrani[index];
                ZobrazInfoOZbrani(vybranyRecept);
                void ZobrazInfoOZbrani(Recepty recept)
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Blue;
                    WriteLine();
                    WriteLine(@$"
                               Název zbraně: {recept.nazevVyrobenehoPredmetu}

                               Co o zbrani víte:
        
                                    poškození: {(recept.vyrobenyPredmet as Zbrane).poskozeniZbrane}
                                    hodnota: {(recept.vyrobenyPredmet.hodnotaPredmetu)}
                                    manová cena útoku: {((recept.vyrobenyPredmet as Zbrane).manovaCena >0?(recept.vyrobenyPredmet as Zbrane).manovaCena:"Útok nestojí manu")}
                                    schopnost: {((recept.vyrobenyPredmet as Zbrane).schopnostZbrane != null?"Ano":"Ne")}


                                    primární materiál na výrobu: {(recept.primarniMaterialProVyrobu.nazevPredmetu) + " (" + recept.pocetPrimarnihoMaterialu + ")"}
                                    sekundární materiál pro výrobu: {(recept.sekundarniMaterialProVyrobu != null ? (recept.sekundarniMaterialProVyrobu.nazevPredmetu) + " (" + recept.pocetSekundarnihoMaterialu + ")" : "Nemá sekundární materiál")}
                                    ");

                                
                    ForegroundColor = ConsoleColor.Yellow;
                    for (int i = 0; i < WindowWidth; i++)
                        Write("-");
                    WriteLine();
                    Thread.Sleep(350);
                    ForegroundColor = ConsoleColor.DarkGray;
                    WriteLine("stiskněte libovolné tlačítko pro pokračování...");
                    ReadKey(true);
                    ResetColor();
                    Clear();
                }

            }
        }
        private static void ZobrazeniPouzitelnych()
        {
            while(true)
            {

                var seznamPouzitelnych = TvrobaPredmetu.SeznamReceptů.Where(z => z.vyrobenyPredmet is Pouzitelne).ToList();
                var vypisPouzitelnychMenu = seznamPouzitelnych.Select(z => "Zbroj: " + (z.vyrobenyPredmet.nazevPredmetu)).ToList();
                vypisPouzitelnychMenu.Add("Odejít");
                Menu menuZbrani = new Menu("Vyberte si použitelný předmět, o kterém se chcete dozvědět více", vypisPouzitelnychMenu, ConsoleColor.Yellow);
                int index = menuZbrani.NavratIndexu();
                if (index == vypisPouzitelnychMenu.Count - 1)
                   break;
                Recepty vybranyRecept = seznamPouzitelnych[index];
                ZobrazInfoOPP(vybranyRecept);
                void ZobrazInfoOPP(Recepty recept)
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Yellow;
                    WriteLine();
                    WriteLine(@$"
                               Název použitelného poředmětu: {recept.nazevVyrobenehoPredmetu}

                               Co o použielném předmětu víte:
                                        
                                    hodnota: {(recept.vyrobenyPredmet.hodnotaPredmetu)}
                                
                                    primární materiál na výrobu: {(recept.primarniMaterialProVyrobu.nazevPredmetu) + " (" + recept.pocetPrimarnihoMaterialu + ")"}
                                    sekundární materiál pro výrobu: {(recept.sekundarniMaterialProVyrobu != null? (recept.sekundarniMaterialProVyrobu.nazevPredmetu) + " (" + recept.pocetSekundarnihoMaterialu + ")" : "Nemá sekundární materiál")}
                                    ");
                    ForegroundColor = ConsoleColor.Red;
                    for (int i = 0; i < WindowWidth; i++)
                        Write("-");
                    WriteLine();
                    Thread.Sleep(350);
                    ForegroundColor = ConsoleColor.DarkGray;
                    WriteLine("stiskněte libovolné tlačítko pro pokračování...");
                    ReadKey(true);
                    ResetColor();
                    Clear();
                }

            }
        }
        private static void ZobrazeniZbroji()
        {
            while(true)
            {

                var seznamZbroji = TvrobaPredmetu.SeznamReceptů.Where(z => z.vyrobenyPredmet is Zbroje).ToList();
                var vypisZbrojiMenu = seznamZbroji.Select(z => "Zbroj: " + (z.vyrobenyPredmet.nazevPredmetu)).ToList();
                vypisZbrojiMenu.Add("Odejít");
                Menu menuZbrani = new Menu("Vyberte si zbroj, o které se chcete dozvědět více", vypisZbrojiMenu, ConsoleColor.Red);
                int index = menuZbrani.NavratIndexu();
                if (index == vypisZbrojiMenu.Count - 1)
                    break;
                Recepty vybranyRecept = seznamZbroji[index];
                ZobrazInfoOZbroji(vybranyRecept);
                void ZobrazInfoOZbroji(Recepty recept)
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Cyan;
                    WriteLine();
                    WriteLine(@$"
                               Název zbroje: {recept.nazevVyrobenehoPredmetu}

                               Co o zbroji víte:
        
                                    hodnota brnění: {(recept.vyrobenyPredmet as Zbroje).hodnotaBrneni}
                                    hodnota: {(recept.vyrobenyPredmet.hodnotaPredmetu)}                              
                                    schopnost: {((recept.vyrobenyPredmet as Zbroje).schopnostZbroje != null ? "Ano" : "Ne")}

                                    primární materiál na výrobu: {(recept.primarniMaterialProVyrobu.nazevPredmetu) + " (" + recept.pocetPrimarnihoMaterialu + ")"}
                                    sekundární materiál pro výrobu: {(recept.sekundarniMaterialProVyrobu != null ? (recept.sekundarniMaterialProVyrobu.nazevPredmetu) + " (" + recept.pocetSekundarnihoMaterialu + ")" : "Nemá sekundární materiál")}");
                    ForegroundColor = ConsoleColor.Yellow;
                    for (int i = 0; i < WindowWidth; i++)
                        Write("-");
                    WriteLine();
                    Thread.Sleep(350);
                    ForegroundColor = ConsoleColor.DarkGray;
                    WriteLine("stiskněte libovolné tlačítko pro pokračování...");
                    ReadKey(true);
                    ResetColor();
                    Clear();

                }
            }
        }
        private static void ZobrazeniSpecialnich()
        {
            while(true)
            {
                if(!VasePostava.inventarPostavy.ListInventare().Any(p=> p is Specialni))
                {
                    ForegroundColor = ConsoleColor.Red;
                    Clear();
                    WriteLine();
                    WriteLine("Zatím jste na Vašim cestách nenašli žádný speciální předmět. Hodně štěstí s hledáním!");
                    GameplayLokaci_1.Tlacitko();
                    break;
                }
                var specialniPredmety = VasePostava.inventarPostavy.ListInventare().Where(p => p is Specialni).GroupBy(o => o.ID).Select(o => o.First()).ToList();
                var vypisSpec = specialniPredmety.Select(p => p.nazevPredmetu).ToList();
                vypisSpec.Add("Odejít");
                Menu menuS = new Menu("Vyberte speciální předmět, o kterém chcete zobrazit informace:", vypisSpec, ConsoleColor.DarkBlue);
                int spv = menuS.NavratIndexu();
                if (spv == vypisSpec.Count - 1)
                    break;
                Specialni vybranySP = (Specialni)specialniPredmety[spv];
                ZobrazInfoOSp(vybranySP);
                void ZobrazInfoOSp(Specialni Sp)
                {
                    Clear();
                    ForegroundColor = ConsoleColor.DarkBlue;
                    WriteLine();
                    WriteLine(@$"                             
                               Co o speciálním předmětu víte:
                                
                                    Název předmětu: {Sp.nazevPredmetu}

                                    Typ Speciálního předmětu: {Sp.TypSpecialu}

                                    Jisté informace o předmětu:");
                    ForegroundColor = ConsoleColor.Yellow;
                    for (int i = 0; i < WindowWidth; i++)
                        Write("-");
                    WriteLine();
                    WriteLine(Sp.popisS);
                    Thread.Sleep(350);
                    ForegroundColor = ConsoleColor.DarkGray;
                    WriteLine();
                    WriteLine("stiskněte libovolné tlačítko pro pokračování...");
                    ReadKey(true);
                    ResetColor();
                    Clear();

                }
            }
        }
    }
    class Bestiar
    {
        public static List<Stvoreni> PotkaniNepratele = new List<Stvoreni>();

        public static void PridejDoBestiare(Stvoreni stvoreni)
        {
           
            if (!PotkaniNepratele.Any(e => e.nazevStvoreni == stvoreni.nazevStvoreni))
            {
               
                PotkaniNepratele.Add(stvoreni);
                Clear();
                ForegroundColor = ConsoleColor.Green;
                WriteLine("Setkali jste se s novou entitou: {0}!", stvoreni.nazevStvoreni);
                WriteLine();
                Thread.Sleep(150);
                ResetColor();
                WriteLine("stiskněte libovolné tlačítko pro pokračování...");
                ReadKey(true);
                Clear();
            }
        }        
        public static void VyberStvoreni()
        {
            if(!PotkaniNepratele.Any())
            {
                Clear();
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Zatím jste nepotkali žádné nepřátele...");
                WriteLine();
                ResetColor();
                WriteLine("stiskněte libovolné tlačítko pro pokračování...");
                ReadKey(true);
                return;
            }
            while(true)
            {
                var seznamPotvor = PotkaniNepratele.Select(n => "Stvoření: " +  n.nazevStvoreni).ToList();
                seznamPotvor.Add("Odejít");
                Menu vyberPotvor = new Menu("Vyberte entitu z Vašeho deníku, o které se chcete dozvědět více", seznamPotvor, ConsoleColor.Blue);
                int index = vyberPotvor.NavratIndexu();
                if (index == seznamPotvor.Count - 1)
                   break;
                Stvoreni vybraneStvoreni = PotkaniNepratele[index];
                _STinfo(vybraneStvoreni);
            }
        }
        private static void _STinfo(Stvoreni stvoreni)
        {           
            Clear();
            WriteLine();
            ForegroundColor = ConsoleColor.Magenta;
            WriteLine(@$"Název stvoření: {stvoreni.nazevStvoreni}
                        
                         Staty stvoření:

                                síla: {stvoreni.sSila}
                                obratnost: {stvoreni.sObratnost}
                                inteligence: {stvoreni.sInteligence}
                                štěstí: {stvoreni.sStesti}
                                
                                útočná hodnota: {stvoreni.sUtocnaHodnota}
                                obranná hodnota: {stvoreni.sObrannaHodnota}

                                zdraví: {stvoreni.maxZdravi}
                                mana: {(stvoreni.maManu?stvoreni.maxMana:"Nemá manu")}


                        Předměty stvoření:

                                    zbraň: {(stvoreni.zbranStvoreni != Žádná_Zbraň ? stvoreni.zbranStvoreni.nazevPredmetu:"Nemá zbraň")}
                                    zbroj: {(stvoreni.zbrojStvoreni != Žádná_Zbroj ? stvoreni.zbrojStvoreni.nazevPredmetu : "Nemá zbroj")}
                                    použitelný předmět: {(stvoreni.pouzitelnyPredmet != null ?stvoreni.pouzitelnyPredmet.nazevPredmetu :"Nemá použitelný předmět")}
                                    suroviny: {(stvoreni.surovinyStvoreni != null?stvoreni.surovinyStvoreni.nazevPredmetu:"Nemá suroviny")}");
            ForegroundColor = ConsoleColor.DarkBlue;
            for (int i = 0; i < WindowWidth; i++)
                Write("-");
            WriteLine();
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine(" Vaše dojmy o tomto stvoření:");
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine();
            WriteLine(stvoreni.popis);                    
            WriteLine();
            ForegroundColor = ConsoleColor.DarkGray;
            Thread.Sleep(350);
            WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            ReadKey(true);
            ResetColor();
            Clear();
                         
        }
    }
}
