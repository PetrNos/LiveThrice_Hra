using System;
using System.Threading;
using System.Collections.Generic;
using static System.Console;

namespace DnD_Hra
{
    internal static class VytvorenePredmety
    {
        
        public static List<Predmety> NahodnyVyberKategoriePredmetu()
        {
            List<List<Predmety>> NahodnyVyberPredmetu = new List<List<Predmety>> { VsechnyZbrane, VsechnyZbroje, VsechnyPouzitelne, VsechnyKovSuroviny, VsechnyAlchSuroviny };
            return NahodnyVyberPredmetu[new Random().Next(0, NahodnyVyberPredmetu.Count)];
        }
        //Zbraně:-----------------------------------------/
        public static readonly Zbrane Žádná_Zbraň = new Zbrane("", 0, 0, 0, null);
        public static readonly Zbrane Dýka = new Zbrane("Dýka", 2, 1, 0, null);
        public static readonly Zbrane Meč = new Zbrane("Meč", 3, 2, 0, null);
        public static readonly Zbrane Magická_Hůl = new Zbrane("Magická hůl", 6, 6, 3, null);
        public static readonly Zbrane Luk = new Zbrane("Luk", 2, 2, 0, Ability2Z.WDexZaStr);
        public static readonly Zbrane Ohnivá_Koule = new Zbrane("Ohnivá koule", 5, 4, 2, null);
        public static readonly Zbrane Krumpáč = new Zbrane("Krumpáč", 1, 1, 0, null);
        public static readonly Zbrane Halapartna = new Zbrane("Halapartna", 3, 3, 0, Ability2Z.WSnizeniDex);
       
        //spec.Zbraně------------------------------------------/        
        public static readonly Zbrane Štastlivcovo_Žihadlo = new Zbrane("Šťastlivcovo žihadlo", 6, 1, 0, Ability2Z.WStasneBodnuti2);
        public static readonly Zbrane Smaragdové_Kopí = new Zbrane("Smaragdové kopí", 8, 2, 0, Ability2Z.WSmaragdoveKopi);
        public static readonly Zbrane Prokletá_Čepel = new Zbrane("Prokletá čepel", 1, 6, 0, Ability2Z.WProkletaCepel);
        public static readonly Zbrane Srp_Vetešnice = new Zbrane("Srp Vetešnice (§)", 3, 2, 0, Ability2Z.SrpVetesnice);
        public static readonly Zbrane Fletna_Krale_Koboldu = new Zbrane("Flétna Krále Koboldů", 9, 1, 0, Ability2Z.WKoboldSummon);
        public static readonly Zbrane Harfa_Cisare_Koboldu = new Zbrane("Harfa Císaře Koboldů", 10, 2, 2, Ability2Z.WKoboldSummon);
        public static readonly Zbrane Palcat_Odporu_Smrti = new Zbrane("Palcát Odporu ke smrti", 10, 3, 0, Ability2Z.WAtkDamagePodPul);
        public static readonly Zbrane Hul_Odporu_Smrti = new Zbrane("Hůl Odporu ke smrti", 10, 7, 3, Ability2Z.WAtkDamagePodPul);
        public static readonly Zbrane Pekelny_Bič = new Zbrane("Pekelný Bič (↓)", 5, 3, 0, Ability2Z.PekelnyBic);
        public static readonly Zbrane Krucifix_Naruby = new Zbrane("Krucifix Naruby", 30, 4, 0, Ability2Z.Krucifix);
        //devil shop
        public static readonly Zbrane Démonická_Šavle = new Zbrane("Démonická Šavle", 10, 7, 0, Ability2Z.DemonickaSavle);
        public static readonly Zbrane Řemdich_Krvavách_Muk = new Zbrane("Řemdich Krvavých Muk", 8, 6, 0, Ability2Z.RemdichKrvavychMuk);
        public static readonly Zbrane Nůž_Osudu = new Zbrane("Nůž Osudu", 8, 5, 0, Ability2Z.NuzOsudu);
        //Zbroje:/-------------------------------------------------------
        public static readonly Zbroje Žádná_Zbroj = new Zbroje("", 0, 0, null);
        public static readonly Zbroje Látková_Zbroj = new Zbroje("Látková zbroj", 1, 1, null);
        public static readonly Zbroje Kožená_Zbroj = new Zbroje("Kožená zbroj", 2, 1, null);
        public static readonly Zbroje Železná_Zbroj = new Zbroje("Železná zbroj", 5, 2, Ability2Z.ARedukceObratnostiDrzitele);
        
        //spec.Zbroje------------------------------------------------/
        public static readonly Zbroje Trnová_Useň = new Zbroje("Trnová Useň", 5, 1, Ability2Z.AOdražení25);
        public static readonly Zbroje Lichovo_Roucho = new Zbroje("Lichovo Roucho", 10, 0, Ability2Z.LichovoRoucho);
        public static readonly Zbroje Tunika_Vetešnice = new Zbroje("Tunika Vetešnice (§)", 2, 1,Ability2Z.TunikaVetešnice);
        public static readonly Zbroje Pekelne_Platy = new Zbroje("Pekelné Pláty (↓)", 8, 3, Ability2Z.PekelnePlaty);
        //devil shop
        public static readonly Zbroje Roucho_Nesmrtelnosti = new Zbroje("Roucho Nesmrtelnosti", 10, 6, Ability2Z.RouchoNesmrtelnosti);
        public static readonly Zbroje Ďábelsky_Nezničitelný_Plát = new Zbroje("Ďábelsky Nezničitelný Plát", 10, 9, Ability2Z.DNP);
        //Použitelné-----------------------------------------------/
        public static readonly Pouzitelne Lektvar_Zdraví = new Pouzitelne("Lektvar zdraví", 8, LektvarZdravi);
        public static readonly Pouzitelne Lektvar_Many = new Pouzitelne("Lektvar many", 8, LektvarMany);
        public static readonly Pouzitelne Lektvar_Síly = new Pouzitelne("Lektvar síly", 4, LektvarSily);
        public static readonly Pouzitelne Lektvar_Obratnosti = new Pouzitelne("Lektvar Obratnosti", 4, LektvarObratnosti);
        public static readonly Pouzitelne Lektvar_Inteligence = new Pouzitelne("Lektvar Inteligence", 4, LektvarInteligence);
        public static readonly Pouzitelne Lektvar_Stesti = new Pouzitelne("Lektvar Štěstí", 4, LektvarStesti);
        public static readonly Pouzitelne Jed = new Pouzitelne("Jed", 4, JedS);
        public static readonly Pouzitelne Lektvar_Obrance = new Pouzitelne("Lektvar obránce", 5, LektvarObrance);
        public static readonly Pouzitelne Lektvar_Utocnika = new Pouzitelne("Lektvar útočníka", 5, LektvarUtocnika);
        public static readonly Pouzitelne Lektvar_Neskodnosti = new Pouzitelne("Lektvar neškodnosti", 7, LektvarNeskodnosti);
        public static readonly Pouzitelne Lektvar_Prurazu = new Pouzitelne("Lektvar průrazu", 7, LektvarPrůrazu);
        public static readonly Pouzitelne Zlaťák = new Pouzitelne("Zlaťák", 0, NicZ);
        //přidání použitelné
        public static readonly Pouzitelne Lektvar_Vzkříšení = new Pouzitelne("Lektvar vzkříšení", 30, NicVZ);
        public static readonly Pouzitelne Elixír_Časoprostoru = new Pouzitelne("Elixír Časoprostoru", 10, VraceniVCase);
        public static readonly Pouzitelne Dryak_Sebevzniceni = new Pouzitelne("Dryák Sebevznícení", 7, Sebevzniceni);
        public static readonly Pouzitelne Prach_Prizracnosti = new Pouzitelne("Prach Přízračnosti", 15, PrachPrizracnosti);
        
        //Suroviny------------------------------------------/

        //alchymie---------------------------------------------------/
        public static readonly Suroviny Zvláštní_Čtyřlístek = new Suroviny("Zvláštní čtyřlístek", 2);
        public static readonly Suroviny Křídlo_Červeného_Motýla = new Suroviny("Křídlo červeného motýla", 2);
        public static readonly Suroviny Křídlo_Modrého_Motýla = new Suroviny("Křídlo modrého motýla", 2);
        public static readonly Suroviny Houba_Bodavka = new Suroviny("Houba bodavka", 2);
        public static readonly Suroviny Květina_Astra = new Suroviny("Květina Astra", 2);
        public static readonly Suroviny Silovník_Šedý = new Suroviny("Silovník šedý", 2);
        public static readonly Suroviny Osvícená_Smůla = new Suroviny("Osvícená smůla", 4);
        //oboje, specialní
        public static readonly Suroviny Temná_Esence = new Suroviny("Temná esence", 7);
        //oboje, magie
        public static readonly Suroviny Dračí_Květ = new Suroviny("Dračí květ", 4);
        public static readonly Suroviny Ohnivý_Prach = new Suroviny("Ohnivý prach", 5);
        public static readonly Suroviny Manový_Krystal = new Suroviny("Manový krystal", 6);
        //kování, utility
        public static readonly Suroviny Železný_Ingot = new Suroviny("Železný ingot", 2);       
        public static readonly Suroviny Kůže = new Suroviny("Kůže", 2);
        public static readonly Suroviny Látka = new Suroviny("Látka", 1);
        public static readonly Suroviny Dřevo = new Suroviny("Dřevo", 1);
        public static readonly Suroviny Měsíční_Erb = new Suroviny("Měsíční erb", 5);
        //Drahé kameny, převážně kování
        public static readonly Suroviny Smaragd = new Suroviny("Smaragd", 6);
        //Speciálni/----------------------------------------------------------
        public static readonly Specialni Vlčí_Talisman = new Specialni("Vlčí Talisman", 10, Ability2Z.VlciTalisman, Specialni.TypSpecPred.Talsiman, $" Talisman nalezen v Průsmyku Hrdlořezů." +
            $"\n\n Když jsem zbraní a zbrojí vybaven jako bandita, talisman mě vřele posílí před bitvou...\n\n Zbraně: Meč, Dýka, Luk, Srp Vetešnice, Šťastlivcovo žihadlo\n\n Zbroje: Kožená, Tunika Vetešnice");
        public static readonly Specialni Maska_Míru = new Specialni("Maska Míru", 10, Ability2Z.MaskaMiru, Specialni.TypSpecPred.Talsiman, $" Maska nalezena v Nadčasovém Lese." +
            $"\n\n Když součet poškození mé zbraně a hodnoty brnění mé zbroje nepřesahuje 4, útočí se mi mnohem lépe!");
        public static readonly Specialni Klíč_k_Zábavě = new Specialni("Klíč k zábavě", 20, null, Specialni.TypSpecPred.Klic, $" Kde je klíč, musí být i zámek...");
        public static readonly Specialni Teleportacni_Prach = new Specialni("Teleportační Prach", 10, null, Specialni.TypSpecPred.Klic, $" I když jsem v jiné dimenzi, přecijen moihu navštívít místa mého působení." +
            $" Kde mám věci, přátele, nebo autoritu, tam se mohu teleportovat. Skvělá to věc!");
        public static readonly Specialni Ďábelský_totem_rovnováhy = new Specialni("Ďábelský Totem Rovnováhy", 20, Ability2Z.DabelskyTotemRovnovahy, Specialni.TypSpecPred.Talsiman, $" Talisman nalezen v malé místnosti v Ďábelské Herně.\n" +
            $"Pokud je jeden z mých bojových statů (útočná nebo obranná hodnota) alespoň dvojnásobně vyšší než ten druhý, talisman tuto hodnotu vyrovná, obě hodnoty jsou pak rovné té vyšší.");
        public static readonly Specialni Baňka_Sběratele_Duší = new Specialni("Baňka Sběratele Duší", 500, null, Specialni.TypSpecPred.Klic, $" Klíč ke skončení utrpení všech z mého rodu, stačí ji jen rozbít a vypustit uvězněnou životní sílu...");
        //SEZNAM POUŽITELNÝCH   
        public static readonly List<Predmety> VsechnyPouzitelne = new List<Predmety> { Lektvar_Zdraví, Lektvar_Many, Lektvar_Síly, Jed, Lektvar_Obratnosti, Lektvar_Inteligence
        , Lektvar_Stesti};
        //SEZNAM ZBRANÍ
        public static readonly List<Predmety> VsechnyZbrane = new List<Predmety> { Dýka, Meč, Magická_Hůl, Luk, Ohnivá_Koule, Luk, Halapartna };
        //SEZNAM ZBROJÍ
        public static readonly List<Predmety> VsechnyZbroje = new List<Predmety> { Látková_Zbroj, Kožená_Zbroj, Železná_Zbroj };
        //SEZNAM ALCHYMIE
        public static readonly List<Predmety> VsechnyAlchSuroviny = new List<Predmety> {Křídlo_Modrého_Motýla, Křídlo_Modrého_Motýla, Houba_Bodavka, Květina_Astra,
            Silovník_Šedý, Temná_Esence, Ohnivý_Prach, Dračí_Květ, Manový_Krystal, Osvícená_Smůla};
        // SEZNAM KOVÁNÍ
        public static readonly List<Predmety> VsechnyKovSuroviny = new List<Predmety> { Železný_Ingot, Kůže, Látka, Dřevo, Smaragd, Zvláštní_Čtyřlístek, Měsíční_Erb };

        //Funkce pro použitelné
        public static bool UhUp = false;
        public static bool UhDown = false;
        public static bool OhUp = false;
        public static bool OhDown = false;
        public static bool SilaL = false;
        public static bool ObratL = false;
        public static bool InteligenceL = false;
        public static bool StestiL = false;        
        private static void LektvarZdravi()
        {
            Console.Clear();
            for (int i = 0; i < 10; i++)
            {
                if (VasePostava.hracovaPostava.vZdravi >= VasePostava.hracovaPostava.zdraviPostavy)
                {
                    break;
                }
                VasePostava.hracovaPostava.vZdravi += 1;
            }
            VasePostava.inventarPostavy.OdeberPredmet(Lektvar_Zdraví);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0} použil Léčivý lektvar!", VasePostava.hracovaPostava.vJmeno);
            Thread.Sleep(200);
            Console.WriteLine();
            Console.WriteLine("Po použití Léčivého lektvaru má {0} {1} zdraví!", VasePostava.hracovaPostava.vJmeno, VasePostava.hracovaPostava.vZdravi);
            Thread.Sleep(200);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            Console.ReadKey(true);
            Console.Clear();
            Console.ResetColor();
        }
        private static void LektvarMany()
        {
            Console.Clear();
            if (VasePostava.hracovaPostava.maManu == true)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (VasePostava.hracovaPostava.pocetMany >= VasePostava.hracovaPostava.maxMana)
                    {
                        break;
                    }
                    VasePostava.hracovaPostava.pocetMany += 1;
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                VasePostava.inventarPostavy.OdeberPredmet(Lektvar_Many);
                Console.WriteLine("{0} použil Lektvar many!", VasePostava.hracovaPostava.vJmeno);
                Thread.Sleep(200);
                Console.WriteLine();
                Console.WriteLine("Po použití Lektvaru many má {0} {1} many!", VasePostava.hracovaPostava.vJmeno, VasePostava.hracovaPostava.pocetMany);
                Thread.Sleep(200);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
                Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
                Console.ReadKey(true);
                Console.Clear();
                Console.ResetColor();
            }
            else
            {
                VasePostava.inventarPostavy.OdeberPredmet(Lektvar_Many);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("{0} použil Lektvar many, avšak nemá žádnou manu, tudíž nelze žádnou doplnit.", VasePostava.hracovaPostava.vJmeno);
                Thread.Sleep(250);
                Console.WriteLine();
                Console.WriteLine("Třeba pro tento předmět najdete jiné využití...");
                Thread.Sleep(200);
                Console.WriteLine();
                Console.WriteLine("Po použití Lektvaru many má {0} stále 0 many!", VasePostava.hracovaPostava.vJmeno);
                Thread.Sleep(200);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
                Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
                Console.ReadKey(true);
                Console.Clear();
                Console.ResetColor();
            }
        }
        private static void NicVZ()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Vypili jste lektvar vzkříšení...No vida, stále jste naživu!");
            Thread.Sleep(200);
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            VasePostava.inventarPostavy.OdeberPredmet(Lektvar_Vzkříšení);
            Console.ReadKey(true);
            Console.Clear();
            Console.ResetColor();
        }
        private static void NicZ()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Házet po soupeři zlato uprostřed souboje možná není nejlepší nápad...");
            Thread.Sleep(200);
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            VasePostava.inventarPostavy.OdeberPredmet(Zlaťák);
            Console.ReadKey(true);
            Console.Clear();
            Console.ResetColor();
        }
        private static void LektvarSily()
        {
            if (SilaL)
            {
                Clear();
                ForegroundColor = ConsoleColor.Red;
                WriteLine();
                WriteLine("Tento lektvar jste za bitvu už jednou použili...");
                VasePostava.inventarPostavy.OdeberPredmet(Lektvar_Utocnika);
                GameplayLokaci_1.Tlacitko();
                return;
            }
            SilaL = true;
            Console.Clear();
            VasePostava.hracovaPostava.vSila += 5;
            VasePostava.inventarPostavy.OdeberPredmet(Lektvar_Síly);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("{0} použil Lektvar síly!", VasePostava.hracovaPostava.vJmeno);
            Thread.Sleep(200);
            Console.WriteLine();
            Console.WriteLine("Po použití Lekvaru síly má {0} {1} síly!", VasePostava.hracovaPostava.vJmeno, VasePostava.hracovaPostava.vSila);
            Thread.Sleep(200);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            Console.ReadKey(true);
            Console.Clear();
            Console.ResetColor();
        }
        private static void LektvarObratnosti()
        {
            if (ObratL)
            {
                Clear();
                ForegroundColor = ConsoleColor.Red;
                WriteLine();
                WriteLine("Tento lektvar jste za bitvu už jednou použili...");
                VasePostava.inventarPostavy.OdeberPredmet(Lektvar_Utocnika);
                GameplayLokaci_1.Tlacitko();
                return;
            }
            ObratL = true;
            Console.Clear();
            VasePostava.hracovaPostava.vObratnost += 5;
            VasePostava.inventarPostavy.OdeberPredmet(Lektvar_Obratnosti);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("{0} použil Lektvar obratnosti!", VasePostava.hracovaPostava.vJmeno);
            Thread.Sleep(200);
            Console.WriteLine();
            Console.WriteLine("Po použití Lekvaru obratnosti má {0} {1} obratnosti!", VasePostava.hracovaPostava.vJmeno, VasePostava.hracovaPostava.vObratnost);
            Thread.Sleep(200);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            Console.ReadKey(true);
            Console.Clear();
            Console.ResetColor();
        }
        private static void LektvarInteligence()
        {
            if (InteligenceL)
            {
                Clear();
                ForegroundColor = ConsoleColor.Red;
                WriteLine();
                WriteLine("Tento lektvar jste za bitvu už jednou použili...");
                VasePostava.inventarPostavy.OdeberPredmet(Lektvar_Utocnika);
                GameplayLokaci_1.Tlacitko();
                return;
            }
            InteligenceL = true;
            Console.Clear();
            VasePostava.hracovaPostava.vInteligence += 5;
            VasePostava.inventarPostavy.OdeberPredmet(Lektvar_Inteligence);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("{0} použil Lektvar inteligence!", VasePostava.hracovaPostava.vJmeno);
            Thread.Sleep(200);
            Console.WriteLine();
            Console.WriteLine("Po použití Lekvaru inteligence má {0} {1} inteligence!", VasePostava.hracovaPostava.vJmeno, VasePostava.hracovaPostava.vInteligence);
            Thread.Sleep(200);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            Console.ReadKey(true);
            Console.Clear();
            Console.ResetColor();
        }
        private static void LektvarStesti()
        {
            if (StestiL)
            {
                Clear();
                ForegroundColor = ConsoleColor.Red;
                WriteLine();
                WriteLine("Tento lektvar jste za bitvu už jednou použili...");
                VasePostava.inventarPostavy.OdeberPredmet(Lektvar_Utocnika);
                GameplayLokaci_1.Tlacitko();
                return;
            }
            StestiL = true;
            Console.Clear();
            VasePostava.hracovaPostava.vStesti += 5;
            VasePostava.inventarPostavy.OdeberPredmet(Lektvar_Stesti);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0} použil Lektvar štěstí!", VasePostava.hracovaPostava.vJmeno);
            Thread.Sleep(200);
            Console.WriteLine();
            Console.WriteLine("Po použití Lekvaru štěstí má {0} {1} štěstí!", VasePostava.hracovaPostava.vJmeno, VasePostava.hracovaPostava.vStesti);
            Thread.Sleep(200);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            Console.ReadKey(true);
            Console.Clear();
            Console.ResetColor();
        }
        private static void JedS()
        {
            Console.Clear();          
            VasePostava.inventarPostavy.OdeberPredmet(Jed);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("{0} použil Jed!", VasePostava.hracovaPostava.vJmeno);
            Thread.Sleep(200);
            Console.WriteLine();
            int Jeddmg = 8 - VasePostava._aktualniNepritel.sObrannaHodnota;
            if (Jeddmg < 0)
                Jeddmg = 0;
            Console.WriteLine("Jed způsobil {0} poškození", Jeddmg);
            VasePostava._aktualniNepritel.sZdravi -= Jeddmg;
            if (VasePostava._aktualniNepritel.sZdravi < 0)
                VasePostava._aktualniNepritel.sZdravi = 0;
            Console.WriteLine();
            Console.WriteLine("Po použití jedu má Váš nepřítel {0} zdraví!", VasePostava._aktualniNepritel.sZdravi);
            Thread.Sleep(200);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            Console.ReadKey(true);
            Console.Clear();
            Console.ResetColor();
        }
        private static void VraceniVCase()
        {
            Console.Clear();
            VasePostava.inventarPostavy.OdeberPredmet(Elixír_Časoprostoru);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0} použil Elixír Časoprostoru!", VasePostava.hracovaPostava.vJmeno);
            Thread.Sleep(200);
            Console.WriteLine();          
            Console.WriteLine("Jste zpět ve stavu, jako před bitvou...");
            DndHerniFunkce.basePostavaSouboj.ObnovaAtributuPostavy(VasePostava.hracovaPostava);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            Console.ReadKey(true);
            Console.Clear();
            Console.ResetColor();
        }
        private static void Sebevzniceni()
        {
            Console.Clear();
            VasePostava.inventarPostavy.OdeberPredmet(Jed);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("{0} použil Dryák Sebevznícení!", VasePostava.hracovaPostava.vJmeno);
            Thread.Sleep(200);
            Console.WriteLine();
            VasePostava.hracovaPostava.vZdravi /= 2;
            int Boom = VasePostava.hracovaPostava.vZdravi - VasePostava._aktualniNepritel.sObrannaHodnota;
            if (Boom < 0)
                Boom = 0;
            Console.WriteLine("Sebevzplanutí Vám vzalo polovinu Vašeho zdraví, poté způsobilo poškození ve výši Vašeho zdraví.");
            Console.WriteLine();
            Console.WriteLine($"Dryák Sebevznícení způsobil {Boom} poškození a nyní máte {VasePostava.hracovaPostava.vZdravi} zdraví.");
            VasePostava._aktualniNepritel.sZdravi -= Boom;
            if (VasePostava._aktualniNepritel.sZdravi < 0)
                VasePostava._aktualniNepritel.sZdravi = 0;
            Console.WriteLine();
            Console.WriteLine("Po výbuchu má Váš nepřítel {0} zdraví!", VasePostava._aktualniNepritel.sZdravi);
            Thread.Sleep(200);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            Console.ReadKey(true);
            Console.Clear();
            Console.ResetColor();
        }
        private static void LektvarObrance()
        {   
            if(OhUp)
            {
                Clear();
                ForegroundColor = ConsoleColor.Red;
                WriteLine();
                WriteLine("Tento lektvar jste za bitvu už jednou použili...");
                VasePostava.inventarPostavy.OdeberPredmet(Lektvar_Obrance);
                GameplayLokaci_1.Tlacitko();
                return;
            }
            OhUp = true;
            Console.Clear();
            VasePostava.hracovaPostava.vObrannaHodnota = (int)(VasePostava.hracovaPostava.vObrannaHodnota * 1.5);
            VasePostava.inventarPostavy.OdeberPredmet(Lektvar_Obrance);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("{0} použil Lektvar obránce!", VasePostava.hracovaPostava.vJmeno);
            Thread.Sleep(200);
            Console.WriteLine();
            Console.WriteLine("Po použití Lekvaru obránce má {0} {1} obranné hodnoty!", VasePostava.hracovaPostava.vJmeno, VasePostava.hracovaPostava.vObrannaHodnota);
            Thread.Sleep(200);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            Console.ReadKey(true);
            Console.Clear();
            Console.ResetColor();
        }
        private static void LektvarUtocnika()
        {
            if (UhUp)
            {
                Clear();
                ForegroundColor = ConsoleColor.Red;
                WriteLine();
                WriteLine("Tento lektvar jste za bitvu už jednou použili...");
                VasePostava.inventarPostavy.OdeberPredmet(Lektvar_Utocnika);
                GameplayLokaci_1.Tlacitko();
                return;
            }
            OhUp = true;
            Console.Clear();
            VasePostava.hracovaPostava.vUtocnaHodnota = (int)(VasePostava.hracovaPostava.vUtocnaHodnota * 1.5);
            VasePostava.inventarPostavy.OdeberPredmet(Lektvar_Utocnika);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0} použil Lektvar útočníka!", VasePostava.hracovaPostava.vJmeno);
            Thread.Sleep(200);
            Console.WriteLine();
            Console.WriteLine("Po použití Lekvaru útočníka má {0} {1} útočné hodnoty!", VasePostava.hracovaPostava.vJmeno, VasePostava.hracovaPostava.vUtocnaHodnota);
            Thread.Sleep(200);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            Console.ReadKey(true);
            Console.Clear();
            Console.ResetColor();
        }
        private static void LektvarNeskodnosti()
        {
            if (UhDown)
            {
                Clear();
                ForegroundColor = ConsoleColor.Red;
                WriteLine();
                WriteLine("Tento lektvar jste za bitvu už jednou použili...");
                VasePostava.inventarPostavy.OdeberPredmet(Lektvar_Neskodnosti);
                GameplayLokaci_1.Tlacitko();
                return;
            }
            UhDown = true;
            Console.Clear();
            VasePostava._aktualniNepritel.sUtocnaHodnota = (int)(VasePostava._aktualniNepritel.sUtocnaHodnota * 0.5);
            VasePostava.inventarPostavy.OdeberPredmet(Lektvar_Utocnika);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0} použil Lektvar neškodnosti!", VasePostava.hracovaPostava.vJmeno);
            Thread.Sleep(200);
            Console.WriteLine();
            Console.WriteLine("Po použití Lekvaru neškodnosti má {0} {1} útočné hodnoty.", VasePostava._aktualniNepritel.nazevStvoreni, VasePostava._aktualniNepritel.sUtocnaHodnota);
            Thread.Sleep(200);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            Console.ReadKey(true);
            Console.Clear();
            Console.ResetColor();
        }
        private static void LektvarPrůrazu()
        {
            if (OhDown)
            {
                Clear();
                ForegroundColor = ConsoleColor.Red;
                WriteLine();
                WriteLine("Tento lektvar jste za bitvu už jednou použili...");
                VasePostava.inventarPostavy.OdeberPredmet(Lektvar_Prurazu);
                GameplayLokaci_1.Tlacitko();
                return;
            }
            OhDown = true;
            Console.Clear();
            VasePostava._aktualniNepritel.sObrannaHodnota = (int)(VasePostava._aktualniNepritel.sObrannaHodnota * 0.5);
            VasePostava.inventarPostavy.OdeberPredmet(Lektvar_Utocnika);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0} použil Lektvar průrazu!", VasePostava.hracovaPostava.vJmeno);
            Thread.Sleep(200);
            Console.WriteLine();
            Console.WriteLine("Po použití Lekvaru průrazu má {0} {1} obranné hodnoty.", VasePostava._aktualniNepritel.nazevStvoreni, VasePostava._aktualniNepritel.sObrannaHodnota);
            Thread.Sleep(200);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            Console.ReadKey(true);
            Console.Clear();
            Console.ResetColor();
        }
        private static void PrachPrizracnosti()
        {
            Console.Clear();
            if(VasePostava.hracovaPostava.vZdravi == 1)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine();
                WriteLine("Snažít se použít Prach Přízračnosti na pokraji smrti není nejlepší nápad...");
                WriteLine();
                Thread.Sleep(250);
                WriteLine("Zkuste to, až budete mít více zdraví...");
                GameplayLokaci_1.Tlacitko();
                VasePostava.inventarPostavy.OdeberPredmet(Prach_Prizracnosti);
                return;
            }
            VasePostava.hracovaPostava.vZdravi = 1;
            VasePostava.hracovaPostava.vObratnost = 45;
            VasePostava.inventarPostavy.OdeberPredmet(Prach_Prizracnosti);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0} použil Prach Přízračnosti!", VasePostava.hracovaPostava.vJmeno);
            Thread.Sleep(200);
            Console.WriteLine();
            Console.WriteLine("Po použití Prachu Přízračnosti má {0} 1 život, ale 45 obratnosti!.", VasePostava.hracovaPostava.vJmeno);
            Thread.Sleep(200);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            Console.ReadKey(true);
            Console.Clear();
            Console.ResetColor();
        }
    }
   
}