using System;
using System.Collections.Generic;
using System.Threading;
using static DnD_Hra.DndHerniFunkce;
using static DnD_Hra.VytvorenePredmety;
using static System.Console;

namespace DnD_Hra
{
    internal static class Tutorial
    {
        private static Valecnik valecnik = new Valecnik();       
        public static void _Uvod()
        {
            bool _vyber;
            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine("(Pokud si přejete přeskočit animovaný text, stiskněte tlačítko SPACEBAR)");
            Thread.Sleep(50);
            AnimaceTextu("Vítejte v úvodu do Live Thrice.");
            AnimaceTextu("Přejete se zasvětit do základních mechanik hry před započatím Vašich cest?");
            ResetColor();
            Thread.Sleep(150);
            WriteLine();
            WriteLine("stiskněte libovolné tlačítko pro pokračování");
            ReadKey(true);
            Clear();
            Menu menu = new Menu("Vyberte odpovídající možnost pomocí šipek na Vaší klávesnici a poté klávesy ENTER: ", new List<string> { "Ano, chci uvést do Live Thrice", "Ne, chci přeskočit úvod" }, ConsoleColor.Cyan);
            int volba = menu.NavratIndexu();
            if (volba == 0)
                _vyber = true;
            else
                _vyber = false;
            if (_vyber == true)
                ZakladniMechaniky();
            else
            {
                bool vyber = _Preskoceni();
                if (vyber == true)
                    return;
                else
                    ZakladniMechaniky();
            }
        }
        public static void _Pribeh()
        {
            
            Menu zasveceniPrib = new Menu("Přejete se zasvětit do počátečního příběhu hry Live Thrice?", new List<string> { "Ano", "Ne" }, ConsoleColor.Yellow);
            int zp = zasveceniPrib.NavratIndexu();
            if (zp == 0)
                Pribeh();
            else
                if (_PreskoceniPrib()) return;
                else _Pribeh();


            void Pribeh()
            {
                Clear();
                ForegroundColor = ConsoleColor.Blue;
                AnimaceTextu("Jste nejmladším potomkem představitele šlechtické rodiny.");
                AnimaceTextu("Vaše rodina je vlastně obyčejná rodina vyšší vrstvy, až na jednu - podstatnou - rozdílnost.");
                AnimaceTextu("Několik staletí zpět se tehdejší otec rodiny rozhodl přijmout dar od jednoho kněze - Dratana.");
                AnimaceTextu("Dar spočíval v tom, že rodina dostane možnost žít třikrát. Se všemi výhodami i nevýhodami, které to obnáší.");
                AnimaceTextu("Dar byl rodině nabídnut, protože vyznávala stejné náboženství, jako zmíněný kněz.");
                AnimaceTextu("Dratan dar pravděpodobně tenkrát nabízel z vlastní dobré vůle, zajímalo ho dobré bytí šlechtické rodiny.");
                AnimaceTextu("Od té doby se dar dědí pokrevní linií kupředu.");
                AnimaceTextu("Jste již pátá generace, která darem oplývá. Je užitečný - zpevňuje postavení rodiny a snižuje riziko například v bojích.");
                AnimaceTextu("Od své matky, Lilie, která ohledně daru byla vždy skeptická, se dozvídáte, jak to celé vlastně proběhlo.");
                AnimaceTextu("Kněz si bere fragmenty duší od těch, kteří dar obdrželi. Pomocí magie je spojí s držitelem duše.");
                AnimaceTextu("Jakmile držitel zemře, fragment je zaměněn za duši padlého a držitel tak žije další život.");
                AnimaceTextu("Až donedávna byl dar jen k užitku, párkrát zachránil členy rodiny na válečných taženích.");
                AnimaceTextu("....");
                ForegroundColor = ConsoleColor.Red;
                AnimaceTextu("Poté však Vaše matka onemocněla. Kvůli jejímu skepticismu si rodina nejdřív myslela, že nemoc předstírá.");
                AnimaceTextu("Za důvod měli, že Vaše matka chce dokázat negativní stránku daru a tak přesvědčit ostatní o odstoupení.");
                AnimaceTextu("Jak se však později zjistilo, matka nemoc nepředstírala, co hůře, její skepse byla na místě.");
                AnimaceTextu("Někteří členové rodiny, počínaje Vaší matkou, začali dostávat neobyklé příznaky.");
                AnimaceTextu("Prudké bolesti břicha, zčernání a odpadávání kůže, epizody halucinací...");
                AnimaceTextu("Nikdo jiný v království příznaky nepociťoval a doktoři si nevěděli rady.");
                AnimaceTextu("Vy a Vaše matka, jste tedy dospěli k závěru, že příznaky musí souviset s darem, který rodokmen převzal.");
                AnimaceTextu("Osobní názor Vaší matky je takový, že se kněz zbláznil a s fragmenty duší teď nakládá jinak, než je správné.");
                AnimaceTextu("....");
                ForegroundColor = ConsoleColor.DarkYellow;
                AnimaceTextu("Ostatní, i přes jejich příznaky, odmítají přiznat skutečnost, že dar by mohl způsobovat příznaky nemocí.");
                AnimaceTextu("Vás pohled na věc je stejný, jako Vaší matky.");
                AnimaceTextu("....");
                ForegroundColor = ConsoleColor.Cyan;
                AnimaceTextu("Jelikož Vy příznaky nemáte, dohodli jste se s matkou, že se daru pokusíte zbavit.");
                AnimaceTextu("Ačkoliv je Vaše matka nemohoucí, Vy se na výpravu dát můžete.");
                AnimaceTextu("Nevíte kam jít, kde začít hledat, ani co mimo Vaše království očekávat.");
                AnimaceTextu("Víte však, že pokud se vrátíte, poděkuje Vám celá rodina...");
                GameplayLokaci_1.Tlacitko();
            }
        }
        private static bool _PreskoceniPrib()
        {
            Menu menu = new Menu("Opravdu nechcete zasvětit do příběhu hry?", new List<string> { "Ano, odejít", "Ne, zasvětit mě do příběhu" }, ConsoleColor.Red);
            int volba = menu.NavratIndexu();
            if (volba == 0)
                return true;
            else
                return false;
        }
        private static bool _Preskoceni()
        {
            Menu menu = new Menu("Opravdu chcete odejít z úvodu do hry?", new List<string> { "Ano, odejít", "Ne, zůstat v úvodu a zasvětit mě do mechanik" }, ConsoleColor.Red);
            int volba = menu.NavratIndexu();
            if (volba == 0)
                return true;
            else
                return false;
        }

        private static void ZakladniMechaniky()
        {
            Clear();
            AnimaceTextu("Začneme tedy se základními mechanikami, které jsou ve hře obsaženy.");
            AnimaceTextu("Teď se na Vaší obrazovce objeví Menu s možnostmi. Pro informace o dané mechanice ji vyberte a stiskněte ENTER");
            Thread.Sleep(150);
            ResetColor();
            WriteLine();
            WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            ReadKey(true);
            Clear();
            while (true)
            {
                int volbaHrace = ZobrazHlavniMenu();
                if (volbaHrace == 11)
                {
                    bool odchod = MenuOdchodu();
                    if (odchod == true)
                        break;
                    else
                        continue;
                }
                else if (volbaHrace == 0)
                    _HodKostkou();
                else if (volbaHrace == 1)
                    _Souboj();
                else if (volbaHrace == 2)
                    _Pasti();
                else if (volbaHrace == 3)
                    _Inventar();
                else if (volbaHrace == 4)
                    _Obchodovani();
                else if (volbaHrace == 5)
                    _RasyAPovolani();
                else if (volbaHrace == 6)
                    _Predmety();
                else if (volbaHrace == 7)
                    _Lokace();
                else if (volbaHrace == 8)
                    _TvrobaAvylepseni();
                else if (volbaHrace == 9)
                    _Staty();
                else if (volbaHrace == 10)
                    _SmrtAJejiEfekt();
            }
            static bool MenuOdchodu()
            {
                Menu menu = new Menu("Opravdu chcete odejít z představení herních mechanik a celkově tak z úvodu do hry?", new List<string> { "Ano, odejít", "Ne, zůstat v úvodu" }, ConsoleColor.Red);
                int volba = menu.NavratIndexu();
                if (volba == 0)
                    return true;
                else
                    return false;
            }
        }

        private static int ZobrazHlavniMenu()
        {
            List<string> moznosti = new List<string> { "Hod kostkou", "Souboj", "Pasti", "Inventář", "Obchodování", "Rasy a povolání", "Předměty", "Lokace", "Tvroba a vylepšování předmětů","Staty a co vlastně dělají", "Odejít z představení mechanik" };
            Menu menu = new Menu("Vyberte mechaniku, o které se chcete dozvědět více:", moznosti, ConsoleColor.Yellow);
            return menu.NavratIndexu();
        }
        private static void _SmrtAJejiEfekt()
        {
            Clear();
            ForegroundColor = ConsoleColor.DarkRed;
            AnimaceTextu("Jak jistě víte, Vaše postava má na jejich různorodých poutích k dispozici 3 životy.");
            AnimaceTextu("Pokud zemřete, život se Vám odebere. Když počet Vašich životů dosáhne 0, hra se nekompromisně ukončí.");
            AnimaceTextu("Společně s tím skončí také existence Vaší postavy tudíž i jejich schopností, předmětů a možnost putovat za Vaším cílem...");
            AnimaceTextu("Pokaždé, co hru spustíte, tu na Vás však čeká jiná postava, dle Vašeho výběru, která možná bude chytřejší, než ta předchozí...");
            AnimaceTextu("Smrt však nemusí být vždy špatná, má i své výhody.");
            AnimaceTextu("Když v lokaci zemřete, ponecháte si veškeré schopnosti a předměty, které v dané lokaci naleznete.");
            AnimaceTextu("Jediné co zmizí po smrti v lokaci jsou zde nabyté atributy, jako jsou životy, útočné a obranné hodnoty, síla, štěstí, a tak dále...");
            AnimaceTextu("Znamená to tedy, že předměty, schopnosti, či jakákoliv jiná specifika pro lokaci můžete získat vícekrát.");
            AnimaceTextu("Příklad - zemřete těsně před koncem lokace, ale v dané lokaci jste našli speciální zbraň a naučili se novou schopnost...");
            AnimaceTextu("Lokace se tedy nebude počítat jako dokončená, ale zbraň i schopnost Vám zůstanou.");
            AnimaceTextu("Pokud do lokace půjdete znovu, můžete získat speciální zbraň, nebo novou schopnost z dané lokace ještě jednou!");
            AnimaceTextu("Znamená to tedy, že životy jsou vlastně prostředky pro Vás. Velmi cenné prostředky...");
            GameplayLokaci_1.Tlacitko();
        }
        private static void _Staty()
        {
            Clear();
            ForegroundColor = ConsoleColor.DarkCyan;
            AnimaceTextu("V této hře jsou k dispozici každé postavě - ať už Vám, nebo jakémukoliv jinému stvoření - čtyři základní staty.");
            ForegroundColor = ConsoleColor.Blue;
            WriteLine();
            WriteLine("1 - Síla");
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine();
            WriteLine("2 - Obratnost");
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine();
            WriteLine("3 - Inteligence");
            ForegroundColor = ConsoleColor.Magenta;
            WriteLine();
            WriteLine("4 - Štěstí");
            ForegroundColor = ConsoleColor.DarkCyan;
            AnimaceTextu("Všechny čtyři staty mají několik společného.");
            AnimaceTextu("Slouží ke zlepšení efektivity speciálních (a rasových) schopností. Pokud je schopnost na statu závislá, její účinnost bude vyšší.");
            AnimaceTextu("Mnohé schopnosti také mají minimální požadavky pro to, aby se vůbec povedly. Vyšší staty šanci na úspěch zajišťují.");
            GameplayLokaci_1.Tlacitko();
            ForegroundColor = ConsoleColor.DarkCyan;
            AnimaceTextu("To však není vše k čemu staty slouží. Další, poměrně častou záležitostí jsou Pasti.");
            AnimaceTextu("Vyšší staty objektivně zajišťují vetší úspěšnost při překonávání Pastí, které jsou s daným statem spojeny.");
            AnimaceTextu("....");
            AnimaceTextu("Další součástí statů jsou bonusy specifické pro jednotlivé staty: ");
            AnimaceTextu("Síla: Síla umožňuje provedení průlomu v souboji - tedy útoku, jehož poškození úplně ignoruje nepřátelskou obrannou hodnotu.");
            AnimaceTextu("Šance na průlom je rovna dvojnásobku síly dané postavy v momentu možnosti jeho provedení.");
            AnimaceTextu("Obratnost: Obratnost umožňuje se vyhnout poškození a tak ho snížit na 0. Šance na úhyb je rovna dvojnásobku obratnosti postavy.");
            AnimaceTextu("Inteligence: Inteligence umožňuje postavě se dostat do tzv. Stavu Povznesenosti.");
            AnimaceTextu("Postava může být povznesena jen jednou za souboj, či sekvenci soubojů. Životy, popřípadě mana se v přechodu do Povznesenosti úplně doplní.");
            AnimaceTextu("Povznesená postava má také do konce daného souboje (soubojů) dvojnásobnou útočnou a obrannou hodnotu - počítáno v momentu Povznesení.");
            AnimaceTextu("Šance na stav povznesenosti je úměrná dvojnásobku inteligence dané postavy.");
            AnimaceTextu("Štěstí: Štěstí vyjadřuje šanci na kritický zásah - takový zásah, u kterého se zdvojnásobí poškození před započtením obranné hodnoty soupeře.");
            AnimaceTextu("Šance na kritický zásah je rovna dvojnásobku štěstí v momentu možnosti jeho provedení.");
            GameplayLokaci_1.Tlacitko();
            ForegroundColor = ConsoleColor.DarkCyan;
            AnimaceTextu("Sílá má také jednu speciální vlastnost - limit možné zátěže ve Vašem inventáři.");
            AnimaceTextu("Čím více síly postava má, tím více toho unese. Ve vedlejším menu je možné vždy Vaši zátěž zkontrolovat, popřípadě snížit vyhozením předmětů.");
            AnimaceTextu("Hra Vás nebude upozorňovat při překročení limitu, ani Vám znemožňovat braní předmětů.");
            AnimaceTextu("Avšak pokud Váš limit bude překročen, může se stát, že se Vaše postava setká s mnohými nepříjemnostmi.");
            AnimaceTextu("Ať už v souboji, nebo mimo něj. Doporučuje se tedy na limit zátěže dbát a inventář podle něj upravovat.");
            GameplayLokaci_1.Tlacitko();
            ForegroundColor = ConsoleColor.DarkCyan;
            AnimaceTextu("Nyní rozumíte tomu, k čemu slouží staty a proč jsou důležité!");
            GameplayLokaci_1.Tlacitko();
        }
        private static void _TvrobaAvylepseni()
        {
            Clear();
            ForegroundColor = ConsoleColor.DarkCyan;
            AnimaceTextu("Ve hře je samozřejmě možné vytvářet a vylepšovat své předměty.");
            AnimaceTextu("Začneme tvorbou předmětů, která se rozděluje do dvou hlavních kategorií.");
            WriteLine();
            ForegroundColor = ConsoleColor.Blue;
            WriteLine("1) Kovárna");
            WriteLine();
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("2) Alchimie");
            WriteLine();
            ResetColor();
            Thread.Sleep(180);
            WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            ReadKey(true);
            Clear();
            ForegroundColor = ConsoleColor.Blue;
            AnimaceTextu("V kovárně je možné vylepšovat své zbraně a zbroje pomocí surovin, které naleznete na svých cestách.");
            AnimaceTextu("Každá zbraň a zbroj má jednu či dvě suroviny, ze kterých se vytváří a vylepšuje.");
            AnimaceTextu("Při vylepšení obvykle vzroste cena předmětu a jeho účinnost (poškození či hodnota brnění).");
            AnimaceTextu("Samozřejmě, počet surovin potřebných pro vylepšení se postupně zvyšuje, stejně ale tak efektivita vylepšení!");
            AnimaceTextu("Proto je doporučeno se svými surovinami zacházet důmyslně a nejdříve myslet a až poté konat.");
            AnimaceTextu("U vytváření to funguje obdobně, avšak cena je pevná a je viditelná v receptu pro vytvoření předmětu.");
            AnimaceTextu("Hráč má vždy všechny recepty v kovárně k dispozici, aby viděl co si může a nemůlže dovolit, či na co si šetřit.");
            WriteLine();
            ResetColor();
            Thread.Sleep(180);
            WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            ReadKey(true);
            Clear();
            ForegroundColor = ConsoleColor.Cyan;
            AnimaceTextu("Dalším způsobem jak vyrábět předměty je alchymistická laboratoř.");
            AnimaceTextu("Zde se vyrábějí většinou použitelné a čistě magické předměty užitečné například v soubojích.");
            AnimaceTextu("Stejně jako v kovárně, mají své recepty podle kterých se vytváří.");
            AnimaceTextu("Suroviny se ale většinou liší od těch které se používají v kovárně.");
            WriteLine();
            ResetColor();
            Thread.Sleep(180);
            WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            ReadKey(true);
            Clear();
            ForegroundColor = ConsoleColor.Green;
            AnimaceTextu("Nyní je načase si vyrábění a vylepšování vyzkoušet.");
            AnimaceTextu("Dostanete suroviny pro výrobu a vylepšení meče nebo dýky, stejně jako výroby léčivého lektvaru, zkuste je využít...");
            AnimaceTextu("Jako první se ocitnete v kovárně. Až z ní odejdete, přejdete do laboratoři.");
            WriteLine();
            ResetColor();
            Thread.Sleep(180);
            WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            ReadKey(true);
            Clear();
            VasePostava.inventarPostavy.PridejPredmet(Květina_Astra);
            for (int i = 0; i < 2; i++)
                VasePostava.inventarPostavy.PridejPredmet(Křídlo_Červeného_Motýla);
            for (int i = 0; i < 4; i++)
                VasePostava.inventarPostavy.PridejPredmet(Železný_Ingot);
            TvrobaPredmetu.Kovarna();
            TvrobaPredmetu.Laborator();
            Inventar.OdeberVseHraci();
            Clear();
            ForegroundColor = ConsoleColor.DarkCyan;
            AnimaceTextu("Nyní snad rozumíte tomu, jak tvořit a vylepšovat předměty!");
            WriteLine();
            ResetColor();
            Thread.Sleep(180);
            WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            ReadKey(true);
            Clear();
        }
        private static void _Lokace()
        {
            Clear();
            ForegroundColor = ConsoleColor.Magenta;
            AnimaceTextu("Lokace jsou místa, která budete při svých poutích objevovat.");
            AnimaceTextu("Některé Lokace jsou ze začátku zamčeny a odemykají se průběžně, k jiným máte přístup okamžitý.");
            AnimaceTextu("V různých lokacích lze nalézt odlišné předměty, poklady, tajemství a také to, co v nich žije...");
            AnimaceTextu("Lokace skýtají několik obtížností, které zkušeným hráčům mohou naznačit spoustu detailů k dané lokaci.");
            AnimaceTextu("Podle obtížnosti se totiž určuje síla a rarita nalezených předmětů a obtížnost soubojů.");
            AnimaceTextu("Obtížnosti lokací mohou být následující:");
            WriteLine();
            ForegroundColor = ConsoleColor.White;
            WriteLine("1) " + ObtiznostLokace.Začátečnická);
            ForegroundColor = ConsoleColor.Green;
            WriteLine();
            WriteLine("2) " + ObtiznostLokace.Jednoduchá);
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine();
            WriteLine("3) " + ObtiznostLokace.Pokročilá);
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine();
            WriteLine("4) " + ObtiznostLokace.Náročná);
            WriteLine();
            ResetColor();
            Thread.Sleep(1000);
            WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            ReadKey(true);
            Clear();            
            ForegroundColor = ConsoleColor.Magenta;
            AnimaceTextu("Když lokaci úspěšně dokončíte, lokace se uzavře a odemkne se Vám přístup k novým lokacím.");                  
            AnimaceTextu("Veškeré detaily se ale nejlépe zjišťují při praktickém hraní. Přeji tedy hodně štěstí při průzkumu!");
            ResetColor();
            Thread.Sleep(150);
            WriteLine("stiskněte libovolné tlačítko pro návrat do menu...");
        }
        private static void _HodKostkou()
        {
            Clear();
            DndKostka kostka = new DndKostka();
            ForegroundColor = ConsoleColor.DarkYellow;
            AnimaceTextu("Hod kostkou je jeden z nejzákladnějších jevů, který se v Live Thrice bude objevovat.");
            AnimaceTextu("Používá se u pastí, u soubojů, nebo na nejrůznější speciální akce, které Váš hrdina bude na cestách prožívat");
            AnimaceTextu("Hodíte si trojstěnnou kostkou a vysledek se poté započítá do akcí. Po 3 se hází znovu.");
            ResetColor();
            kostka.KostkyArt();
            kostka.HodKostkou();
            ForegroundColor = ConsoleColor.DarkYellow;
            AnimaceTextu("Takto vypadá obyčejný hod kostkou, je tu ale ještě speciální hod kostkou, tzv. cinknutá kostka: ");
            ResetColor();
            kostka.KostkyArt();
            kostka.HodCinknutouKostkou();
            ForegroundColor = ConsoleColor.DarkYellow;
            AnimaceTextu("U této kostky je vždy hod cinknutý, tudíž vždy padne poprvé 3!. Lze ji nalézt v hobitově kapse!");
            ResetColor();
            Thread.Sleep(150);
            WriteLine();
            WriteLine("stiskněte libovolné tlačítko pro pokračování");
            ReadKey(true);
            Clear();
        }

        private static void _Souboj()
        {
            Clear();
            ForegroundColor = ConsoleColor.Yellow;
            AnimaceTextu("Nyní si zkusíte simulaci Vašeho prvního souboje.");
            AnimaceTextu("V souboji lze použít různé akce, jako útok, rasovou a speciální schopnost, nebo použít předmět z inventáře.");
            AnimaceTextu("V rámci tohoto souboje budete kroll válečník s předem nastavenými staty a vybavením. Bojovat budete proti Dřevěnému panákovi.");
            AnimaceTextu("Také je zde možnost po souboji prohledat poražené, občas u sebe mají cennosti....");
            ResetColor();
            Thread.Sleep(150);
            WriteLine();
            WriteLine("stiskněte libovolné tlačítko pro souboj...");
            ReadKey(true);
            Clear();
            PrirazeniStatu();            
            Souboj(VasePostava.hracovaPostava, new DrevenyPanak(), false, false);
            OdebraniStatu();
            Clear();
            ForegroundColor = ConsoleColor.Yellow;
            AnimaceTextu("Takto tedy vypadá základní souboj...");
            ResetColor();
            Thread.Sleep(150);
            WriteLine();
            WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            ReadKey(true);
            Clear();

            static void PrirazeniStatu()
            {
                Kroll k = new Kroll();
                VasePostava.hracovaPostava.vJmeno = "Vaše postava";              
                VasePostava.inventarPostavy.PridejPredmet(Lektvar_Many);
                VasePostava.hracovaPostava.vObratnost = k.rObratnost+3;
                VasePostava.hracovaPostava.vSila = k.rSila+4;
                VasePostava.hracovaPostava.vInteligence = k.rInteligence+2;
                VasePostava.hracovaPostava.vStesti = k.rStesti+5;
                VasePostava.hracovaPostava.vZdravi = k.rZdravi;
                VasePostava.hracovaPostava.RasovaSchopnost = VasePostava.hracovaPostava.SchopnostKrolla;
                VasePostava.hracovaPostava.HodnotaRasoveSchopnosti = VasePostava.hracovaPostava.StatyRasoveSchopnosti;

                VasePostava.hracovaPostava.vObratnost += valecnik.pObratnost;
                VasePostava.hracovaPostava.vSila += valecnik.pSila;
                VasePostava.hracovaPostava.vInteligence += valecnik.pInteligence;
                VasePostava.hracovaPostava.vZdravi += valecnik.pZdravi;
                VasePostava.hracovaPostava.vStesti += valecnik.pStesti;
                VasePostava.hracovaPostava.vUtocnaHodnota = valecnik.pUtocnaHodnota;
                VasePostava.hracovaPostava.vObrannaHodnota = valecnik.pObrannaHodnota;
                VasePostava.hracovaPostava.poskozeniZbrane = valecnik.poskozeniZbrane;
                VasePostava.hracovaPostava.hodnotaBrneni = valecnik.hodnotaBrneni;
                VasePostava.hracovaPostava.maManu = valecnik.maManu;
                VasePostava.hracovaPostava.PovolaniSchopnost = VasePostava.hracovaPostava.ValecnikovaSchopnost;              
                VasePostava.hracovaPostava.Utok = VasePostava.hracovaPostava.UtokValecnika;              
                VasePostava.hracovaPostava.ArtHrdiny = valecnik.ArtPovolani;
                VasePostava.hracovaPostava.zakladniUtocnaHodnota = valecnik.zakladniUtocnaHodnota;
                VasePostava.hracovaPostava.zakladniObrannaHodnota = valecnik.zakladniObrannaHodnota;
                VasePostava.zbranPostavy = Valecnik.valecnikovaZbran;
                VasePostava.zbrojPostavy = Valecnik.valecnikovaZbroj;
                VasePostava.alternativniZbranPostavy = null;
                VasePostava.vybavenaZbran = Valecnik.valecnikovaZbran;
                VasePostava.vybavenaZbroj = Valecnik.valecnikovaZbroj;
                VasePostava.inventarPostavy.PridejPredmet(VasePostava.zbranPostavy);
                VasePostava.inventarPostavy.PridejPredmet(VasePostava.zbrojPostavy);
            }
            static void OdebraniStatu()
            {
                Inventar.OdeberVseHraci();
                VasePostava.hracovaPostava.vObratnost = 0;
                VasePostava.hracovaPostava.vSila = 0;
                VasePostava.hracovaPostava.vInteligence = 0;
                VasePostava.hracovaPostava.vStesti = 0;
                VasePostava.hracovaPostava.vZdravi = 0;
                VasePostava.hracovaPostava.RasovaSchopnost = null;
                VasePostava.hracovaPostava.HodnotaRasoveSchopnosti = null;

                VasePostava.hracovaPostava.vUtocnaHodnota = 0;
                VasePostava.hracovaPostava.vObrannaHodnota = 0;
                VasePostava.hracovaPostava.poskozeniZbrane = 0;
                VasePostava.hracovaPostava.hodnotaBrneni = 0;
                VasePostava.hracovaPostava.maManu = false;
                VasePostava.hracovaPostava.PovolaniSchopnost = null;               
                VasePostava.hracovaPostava.Utok = null;             
                VasePostava.hracovaPostava.ArtHrdiny = null;
                VasePostava.hracovaPostava.zakladniUtocnaHodnota = 0;
                VasePostava.hracovaPostava.zakladniObrannaHodnota = 0;
                VasePostava.zbranPostavy = null;
                VasePostava.zbrojPostavy = null;
                VasePostava.alternativniZbranPostavy = null;
                VasePostava.vybavenaZbran = null;
                VasePostava.vybavenaZbroj = null;
            }
        }

        private static void _Pasti()
        {
            Clear();
            ForegroundColor = ConsoleColor.Green;
            AnimaceTextu("Pasti jsou v této hře vlastně zkoušky.");
            AnimaceTextu("Když narazíte na výzvu, která otestuje Vaše atributy, hodíte si kostkou a závisle na testovaném statu uspějete, nebo ne.");
            AnimaceTextu("V případě úspěchu se většinou stane něco prospěšného, v odlišném případě naopak.");
            AnimaceTextu("Pro ukázku: Potřebujete postavit most z klády opodál, hodíte si tedy past na sílu.");
            AnimaceTextu("V tomto specifickém případě je potřeba hodit nejméně 2...");
            Past stavbaMostu = new Past(2, VasePostava.hracovaPostava.vSila, "sílu", "Hráč");
            bool uspech = stavbaMostu.Uspech();
            ForegroundColor = ConsoleColor.Green;
            if (uspech == true)
                AnimaceTextu("Výborně, v tomto případě jste úspěšně posatvili most a přebrodili řeku!");
            else
                AnimaceTextu("V tomto případě jste bohužel most přes řeku nepostavili a zůstáváte na původním břehu...");

            ResetColor();
            Thread.Sleep(150);
            WriteLine();
            WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            ReadKey(true);
            Clear();
        }

        private static void _Inventar()
        {
            Clear();
            ForegroundColor = ConsoleColor.Cyan;
            AnimaceTextu("Inventářem se rozumí místo vytvořené pro ukládání předmětů Vaší postavy.");
            AnimaceTextu("Z inventáře používáte předměty v souboji i mimo souboj, také procházíte suroviny a vybavujete své zbraně a zbroje.");
            AnimaceTextu("Ve Vašem inventáři lze vidět všechny předměty, rozděleny podle tříd.");
            AnimaceTextu("Pozor - pokud jste ve vybavovacím režimu a nemáte manu, magické zbraně se nezobrazí!");
            AnimaceTextu("V inventáři lze také nalézt Váš osobní deník, kam si postava píše poznámky o již poznaných entitiách");
            AnimaceTextu("Věci, které lze obvykle dělat s inventářem vypadají následovně - nyní Vaší postavě vytvoříme provizorní inventář: ");            
            VasePostava.inventarPostavy.PridejPredmet(Kožená_Zbroj);
            VasePostava.inventarPostavy.PridejPredmet(Látková_Zbroj);
            VasePostava.inventarPostavy.PridejPredmet(Dýka);
            VasePostava.inventarPostavy.PridejPredmet(Magická_Hůl);
            VasePostava.inventarPostavy.PridejPredmet(Lektvar_Zdraví);
            VasePostava.inventarPostavy.PridejPredmet(Lektvar_Many);
            VasePostava.inventarPostavy.PridejPredmet(Železný_Ingot);
            ResetColor();
            Thread.Sleep(150);
            WriteLine();
            WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            ReadKey(true);
            Clear();
            Menu.VedlejsiMenuPostavy();
            Inventar.OdeberVseHraci();
            ForegroundColor = ConsoleColor.Cyan;
            Clear();
            AnimaceTextu("Nyní snad máte dostatečnou představu o tom, jak inventář funguje a co to vlastně je.");
            ResetColor();
            Thread.Sleep(150);
            WriteLine();
            WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            ReadKey(true);
            Clear();
        }

        private static void _Obchodovani()
        {
            Clear();
            ForegroundColor = ConsoleColor.DarkRed;
            AnimaceTextu("V této části se dozvíte o obchodování.");
            AnimaceTextu("Ve hře není možností k obchodování přespřílišně, proto se jich snažte využít co nejvíce.");
            AnimaceTextu("Co se obchodování týče, jedná se vlastně o výměnu mezi inventáři za počet zlata.");
            AnimaceTextu("Každý předmět má svojí hodnotu, za kterou ho lze koupit nebo prodat.");
            AnimaceTextu("Každý typ obchodu prodává a také kupuje jiné předměty, až na pár vyjímek...");
            WriteLine("Zbrojírna - Prodává a kupuje zbraně a zbroje");
            WriteLine();
            WriteLine("Alchymistická laboratoř - Prodává a kupuje Použitelné předměty");
            WriteLine();
            WriteLine("Obchod se surovinami - Prodává a kupuje suroviny");          
            ResetColor();
            Thread.Sleep(150);
            WriteLine();
            WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            ReadKey(true);
            Clear();
            ForegroundColor = ConsoleColor.DarkRed;
            AnimaceTextu("Rozdílné jsou speciální předměty, které na prodej nejsou, třeba je lze využít jinak...");
            AnimaceTextu("Nyní se ocitnete ve zbrojírně, a můžete vyzkoušet jak obchodování funguje.");
            ResetColor();
            Thread.Sleep(150);
            WriteLine();
            WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            ReadKey(true);
            Clear();
            Inventar.PridejZlato(20, VasePostava.inventarPostavy);
            VasePostava.inventarPostavy.PridejPredmet(Dýka);            
            VasePostava.inventarPostavy.PridejPredmet(Železný_Ingot);

            Inventar zbrojirna = new Inventar();
            zbrojirna.PridejPredmet(Meč);
            zbrojirna.PridejPredmet(Látková_Zbroj);
            zbrojirna.PridejPredmet(Lektvar_Zdraví);
            zbrojirna.PridejPredmet(Magická_Hůl);

            Obchod.KovarnaObchod(VasePostava.inventarPostavy, zbrojirna, "Městské");
            Inventar.OdeberVseHraci();
            ForegroundColor = ConsoleColor.DarkRed;
            Clear();
            AnimaceTextu("Nyní je Vám jasné, jak obchodování funguje.");
            ResetColor();
            Thread.Sleep(150);
            WriteLine();
            WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            ReadKey(true);
            Clear();
        }

        private static void _RasyAPovolani()
        {
            Clear();
            IntrodukceRasAPovolani();
        }

        private static void _Predmety()
        {
            Clear();
            ForegroundColor = ConsoleColor.Blue;
            AnimaceTextu("Předměty jsou objekty, se kterými se budete setkávat na svých cestách velice často.");
            AnimaceTextu("Rozdělují se do 5 základních kategorií: ");
            ForegroundColor = ConsoleColor.Red;
            AnimaceTextu("1. Zbraně");
            ForegroundColor = ConsoleColor.Blue;
            AnimaceTextu("2. Zbroje");
            ForegroundColor = ConsoleColor.Cyan;
            AnimaceTextu("3. Použitelné");
            ForegroundColor = ConsoleColor.DarkYellow;
            AnimaceTextu("4. Suroviny");
            ForegroundColor = ConsoleColor.DarkBlue;
            AnimaceTextu("5. Speciální");
            ForegroundColor = ConsoleColor.Blue;
            AnimaceTextu("Zbraně slouží k souboji, některé jsou magické a některé ne. Mají určité poškození, případně manovou cenu.");
            AnimaceTextu("Zbroje chrání před útoky, mají své obranné číslo symbolizující jejich účinnost.");
            AnimaceTextu("Zbroje a zbraně mohou mít nějaké schopnosti, které se projeví v souboji. Na to je hráč upozorněn v inventáři.");
            AnimaceTextu("Schopnosti zbraní a zbrojí mohou být pro hráče jak prospěšné, tak negativní. To lze zjistit jedině soubojem!");
            AnimaceTextu("V názvu zbraní a zbrojí může najít podivné symboly. Pokud najdete zbraň i zbroj se stejným symbolem, jedná se o set.");
            AnimaceTextu("Hlavní zbraňě a zbroje, které jsou v setu, mají speciální schopnosti pokud jsou používány společně. (tzn. jsou vybaveny najednou)");
            AnimaceTextu("Použitelné předměty lze používat a mají speciální efekt při použití.");
            AnimaceTextu("Suroviny lze používat k vytváření nejrůznějších předmětů.");
            AnimaceTextu("Speciální předměty jsou nepředvídatelné a nikdo neví co přesně dělají, často to jsou talismany, artefakty a tak dále...");
            AnimaceTextu("Předměty lze prohlížet ve Vašem inventáři, zbraněmi a zbrojemi se lze vybavit.");
            AnimaceTextu("Použitelné předměty lze použít, to i při souboji a speciální předměty slouží pro unikátní situace.");
            AnimaceTextu("Suroviny často utilizujete v kovárnách či laboratořích.");
            ResetColor();
            Thread.Sleep(150);
            WriteLine();
            WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            ReadKey(true);
            Clear();
        }
    }
}