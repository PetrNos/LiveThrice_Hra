using System;
using System.Collections.Generic;
using System.Threading;
using static DnD_Hra.DndHerniFunkce;
using static DnD_Hra.Lokace;
using static DnD_Hra.VytvoreneLokace;
using static System.Console;
using static DnD_Hra.VytvorenePredmety;
using static DnD_Hra.UkladaniFunkci;
using static DnD_Hra.NoveSpecialniSchopnosti;
using static DnD_Hra.GameplayLokaci_3;
using System.Linq;

namespace DnD_Hra
{
    class GameplayLokaci_5
    {
        static List<Predmety> PredmetyZaHP = new List<Predmety> {Démonická_Šavle, Řemdich_Krvavách_Muk, Nůž_Osudu, Roucho_Nesmrtelnosti, Ďábelsky_Nezničitelný_Plát};
        static void NaplnInvZaHP(Inventar inv, List<Predmety> listItemuzaHP)
        {
            foreach(Predmety p in listItemuzaHP)
            {
                inv.PridejPredmet(p);
            }
        }
        private static void ObetniKamen(string nazevSac, ref int statKObetovani, int pocetprvnihoStatu,string nazevGain, ref int StatkZisku, int pocetDruhehoStatu)
        {
            Clear();
            ForegroundColor = ConsoleColor.Red;
            WriteLine();
            WriteLine("Narazili jste na obětní kámen...");
            Thread.Sleep(250);
            WriteLine();
            WriteLine($"Obětujete - li {pocetprvnihoStatu} {nazevSac}, získáte {pocetDruhehoStatu} {nazevGain}...");
            Tlacitko();
            Menu m = new Menu("Příjmáte nabídku?", new List<string> { "Ano", "Ne" }, ConsoleColor.Red);
            int t = m.NavratIndexu();
            if (t == 1)
            {
                Clear();
                ForegroundColor = ConsoleColor.Red;
                WriteLine();
                WriteLine("Nabídku nepřijmáte...");
                Tlacitko();
            }
            else
            {
                Clear();
                ForegroundColor = ConsoleColor.Red;
                WriteLine();
                WriteLine("Nabídku přijmáte...");
                WriteLine();
                WriteLine("Změny byly úspěšně povedeny.");
                Tlacitko();
                statKObetovani -= pocetprvnihoStatu;
                StatkZisku += pocetDruhehoStatu;
                if (nazevGain == "zdraví" || nazevSac == "zdraví")
                    VasePostava.hracovaPostava.RekonfiguraceHPaMany();              
            }

        }

        public static void SatanuvChrtanGameplay()
        {
            Prichod();
            BojeAShop();
            DalsiBoje();
            Satan();
            void Prichod()
            {
                Clear();
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Teleportovali jste se znovu, tentokrát jste přistáli na místě, které jen těžko na první pohled identifikovat.");
                AnimaceTextu("Kamenná jeskyně, ve které pomalu není vidět na krok, propletená pavučinami a počmárána krví.");
                AnimaceTextu("Jedinné co Vás vede vpřed je velmi nevýrazné, červené světlo, které svítí odněkud zepředu.");
                AnimaceTextu("Při detailním prozkoumání zjišťujete, že za Vámi je hluboká propast, na jejímž dně pravděpodobně teče mělký potok.");
                AnimaceTextu("Při pohybu kupředu si musíte dávat pozor na ostré kamenné výběžky, které vypadají, že je tam někdo naschvál vytvořil.");
                AnimaceTextu("Chodby jsou relativně úzké, nakonci každé z nich se nechází místnost, která je vlastně jen rozšířený průchod.");
                AnimaceTextu("Většina je prázdná, v některých jsou sety zrezlých nožů, háků, obvazů a podobných pomůcek.");
                AnimaceTextu("Jediné co slyšíte je proud vody, který se vzdaluje a tlumí s Vaším postupem vpřed.");
                AnimaceTextu(".....");
                Tlacitko();
                Okradeni();
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Následujete světlo, které podle jeho intenzity může být takřka za každým rohem.");
                AnimaceTextu("Když k němu dojdete, zjistíte, že se nachází v další ze zmíněných místností.");
                AnimaceTextu("Je to vlastně velký, průhledný a červený krystal, zaražen v kovovém rámu.");
                AnimaceTextu("Pod rámem se nechází ocelová deska, která je potřísněna krví.");
                AnimaceTextu("Pravděpodobně proto, že na desce také leží zmasakrované tělo, které poravděpodobně bylo součástí nějakého rituálu.");
                AnimaceTextu("Na desce jsou také svíčky a nespočet odlišných surovin, většina z nich je rozdrcena, nebo přelomena.");
                AnimaceTextu("Nikdo jiný kromě Vás v místnosti není. Vlastně vůbec nic kromě rituální desky a jejích komponentů...");
                AnimaceTextu(".....");
                Tlacitko();
                AnimaceTextu("Po odchodu z rituální místnosti, spatříte další červené světlo - s nějvětší pravděpodobností ze stejného zdroje.");
                AnimaceTextu("Jiná cesta tu není, tím pádem víte, že nemáte na výběr, pokračujete v cestě.");
                AnimaceTextu("......");
                AnimaceTextu("Hned v té další místnosti vidíte zvláště vypadající kámen.");
                AnimaceTextu("Když k němu přijdete, krvní je na něm napsáno následující:");
                Tlacitko();
                ObetniKamen("inteligence", ref VasePostava.hracovaPostava.vInteligence, 5, "síly", ref VasePostava.hracovaPostava.vSila, 5);
                Clear();                
            }
            void BojeAShop()
            {
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Poračujete v cestě, opět už jste skoro u rudého světla.");
                AnimaceTextu("......");
                AnimaceTextu("Nejste překvapeni, když tam opět najdete rituální desku, stejně vypadající stejně jako předtím.");
                AnimaceTextu("Co Vás však překvapuje, je osoba stojící u samotné desky, rýpající se v oběti na ocelovém stolku...");
                AnimaceTextu("......");
                Tlacitko();
                Souboj(VasePostava.hracovaPostava, new UctivacDabla(), false, true);
                Clear();
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Víte, že tu nejste sami, tudíž si budete muset dávat pozor...");
                AnimaceTextu("Odvážně pokračujete do další místnosti.");
                AnimaceTextu(".....");
                AnimaceTextu("Procházíte chodbou, když najednou Vás začne svírat velmi zvláštní pocit.");
                AnimaceTextu("Takový, se kterým jste se na Vašich poutích moc často nesetkali...");
                Tlacitko();
                Souboj(VasePostava.hracovaPostava, new Strach(), false, true);
                Clear();
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Víte, že projít celou touto oblastí bude pravděpodobně výzva.");
                AnimaceTextu("Na nic však nečekáte a pokračujete ve Vaší cestě.");
                AnimaceTextu("Přicházíte do další místnosti, na první pohled vypadá prázdně...");
                AnimaceTextu("Zjišťujete, že v rohu je poměrně udžovaná dřevěná deska. Nevíte z jakého důvodu.");
                AnimaceTextu("Když se přiblížíte, trhnete sebou, když na Vás dosud neviděná osoba za deskou promluví...");
                Tlacitko();
                PrimaRec("Ďábelský překupník", "Fíha, vy nevypadáte jako uctívač Ďábla.");
                PrimaRec("Ďábelský překupník", "Oni mi už nemají co nabídnout, všechen jejich život byl zpronevěřen vyšší entitě...");
                PrimaRec("Ďábelský překupník", "Vy ale vypadáte zdravě, živoučce. Ať už jste kdokoliv.");
                PrimaRec("Ďábelský překupník", "Za Vaše předměty Vám rád dám zlato, avšak pokud chcete nakupovat, požaduji jinou měnu.");
                PrimaRec("Ďábelský překupník", "Nemám tušení jak jste se sem dostali, ale možná bychom se mohli domluvit na menším obchodě...");
                Tlacitko();
                Okradeni();
                ForegroundColor = ConsoleColor.Red;
                AnimaceTextu("Vzhledem k pomůckám, které má překupník na desce, chápete, že tohle není obyčejný obchod.");
                AnimaceTextu("Vypadá to, že se tu platí životní silou - velmi vzácnou měnou.");
                AnimaceTextu("Ubližovat si je Vám napoprvé proti srsti, ale když předměty budou dostatečně dobré, možná by to stálo za zvážení...");
                Tlacitko();
                Inventar DabOb = new Inventar();
                NaplnInvZaHP(DabOb, PredmetyZaHP);
                Obchod.ObchodovaniZaZivoty(VasePostava.inventarPostavy, DabOb, "Ďábelském tržišti", 0.9, 1);
                PridaniZaPodminek(PredmetyZaHP);
                Clear();
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Výhodný obchod...Netečně pokračujete do další místnosti, už jste viděli opravdu všechno.");
                Tlacitko();
                ObetniKamen("štěstí", ref VasePostava.hracovaPostava.vStesti, 4, "obratnosti", ref VasePostava.hracovaPostava.vObratnost, 3);
                Clear();
            }
            void DalsiBoje()
            {
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Přicházíte k dalšímu krystalu, scenérie se nemění.");
                AnimaceTextu("Dokonce už od příchodu vidíte dalšího uctívače.");
                AnimaceTextu("Něco Vás ale do místnosti doprovází. Něco, co jste už viděli...");
                Tlacitko();
                Souboj(VasePostava.hracovaPostava, new Strach(), true, true);
                Souboj(VasePostava.hracovaPostava, new UctivacDabla(), false, false);
                Clear();
                AnimaceTextu("V místnosti je další kámen...");
                Tlacitko();
                ObetniKamen("zdraví", ref VasePostava.hracovaPostava.vZdravi, 5, "inteligence", ref VasePostava.hracovaPostava.vInteligence, 10);
                ForegroundColor = ConsoleColor.DarkBlue;
                Tlacitko();
                AnimaceTextu("Přijde Vám, že strach jste porazili. Odvaha Vás motivuje pokračovat vpřed.");
                AnimaceTextu("Zvykáte si na terén v jeskyni, cesta Vám začíná utíkat.");
                AnimaceTextu("Průrvy a chodby Vám přijsou číl dám tím kratší. Sem tam narazíte na obětní kámen...");
                Tlacitko();
                ObetniKamen("obratnosti", ref VasePostava.hracovaPostava.vObratnost, 8, "zdraví", ref VasePostava.hracovaPostava.vZdravi, 5);
                ObetniKamen("síly", ref VasePostava.hracovaPostava.vSila, 5, "inteligence", ref VasePostava.hracovaPostava.vInteligence, 4);
                Clear();
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Dojdete k dalšímu kameni, samozřejmě je hlídaný. Lítě se poustíte do boje.");
                Tlacitko();
                Souboj(VasePostava.hracovaPostava, new UctivacDabla(), false, true);
                Clear();
                Okradeni();
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Svižnou chůzí pokračujete do další místnosti, už víte, co Vás nejspíš čeká...");
                Tlacitko();
            }
            void Satan()
            {
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Když vejdete do další místnosti s krystalem, naleznete tam další kámen...");
                Tlacitko();
                ObetniKamen("obratnosti", ref VasePostava.hracovaPostava.vObratnost, 5, "štěstí", ref VasePostava.hracovaPostava.vStesti, 5);
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Víte, že dost možná je toto ta poslední místnost, protože další světlo z krystalu už nevidíte.");
                AnimaceTextu("Před Vámi je východ, do většiho prostoru jeskyně. Krobnými skulinami začíná prosvítat měsíční světlo.");
                AnimaceTextu("Vypadá to, že tohle je konec jeskyně, zkusíte se dostat ven...");
                AnimaceTextu(".......");
                Tlacitko();
                Okradeni();
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Když se pokusíte projít rozšířeným východem, který pravděpodobně vede ven z jeskyně, balvany se sesunou...");
                AnimaceTextu("Jen tak tak jste unikli. Chvíli pozorujete disperzi prachu z pádu balvanů.");
                AnimaceTextu("Když prach pomine, vidíte, jak se mezi balvany formuje temná hmota.");
                AnimaceTextu("Pomalu nabírá pevné podoby, svírá Vás strach a pocit nebezpečí. Je Vám jasné, že je to pravděpodobně výsledek rituálů.");
                AnimaceTextu("Při úplné formaci před Vámi stojí nepopsatelná entita, vypadá jako...");
                Tlacitko();
                Souboj(VasePostava.hracovaPostava, new Satan(), false, true);
                Recepty.PridejReceptDoSeznamu(TvrobaPredmetu.RKrucifix_Naruby);
                Clear();
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Po smrti byla vyslána rázová vlna, která jeskyni zničia na kousky.");
                AnimaceTextu("Vy, jakožto majitel obráceného Krucifixu, jste jen stáli a destrukci pozorovali.");
                AnimaceTextu("Nejen, že noc byla změněna na den, ale všichni a všechno, co se v jeskyni nacházelo, jakoby neexistovalo.");
                AnimaceTextu("Jediné co vidíte je jasně svítící slunce nad Vámi a louku, na které stojíte.");
                AnimaceTextu("Jste uprostřed ničeho, ale víte, že z této lokace nic nezbylo...");
                Tlacitko();
                DokonciLokaci(Satanuv_chrtan);
                DokonciFinalneLokaci(Satanuv_chrtan);
                OdemkniLokace(Chrám_tří_srdcí);
                ForegroundColor = ConsoleColor.DarkRed;
                WriteLine();
                WriteLine("Dokončili jste lokaci Satanův Chřtán. Cítíte, že Váš cíl se blíží...");
                Tlacitko();
            }           
            static void PridaniZaPodminek(List<Predmety> seznamKPridani)
            {
                Recepty receptPr;
                foreach(Predmety p in seznamKPridani)
                {

                    if (p is Zbrane)
                        receptPr = TvrobaPredmetu.PriradReceptZbrani((p as Zbrane));
                    else if (p is Zbroje)
                        receptPr = TvrobaPredmetu.PriradReceptZbroji((p as Zbroje));
                    else
                        throw new Exception("V Listu předmětů není ani Zbraň ani zbroj");

                    if (VasePostava.inventarPostavy.MaPredmet(p))
                        Recepty.PridejReceptDoSeznamu(receptPr);
                }
            }
        }

        public static void Titulky(string subtitleText, int delayBetweenLetters)
        {
            // Clear the console
            Console.Clear();

            // Calculate the number of spaces needed for spacing effect
            int maxSpaces = Console.WindowWidth - subtitleText.Length;
            int currentSpaces = maxSpaces;

            // Print the subtitle letter by letter with ascending spacing
            foreach (char c in subtitleText)
            {
                // Add spacing
                Console.Write(new string(' ', currentSpaces));

                // Print the letter
                Console.Write(c);

                // Delay between letters
                Thread.Sleep(delayBetweenLetters);

                // Move the cursor up one line
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);

                // Decrease the number of spaces
                currentSpaces--;

                // Clear the current line
                Console.Write(new string(' ', Console.WindowWidth));
            }

            // Move the cursor to the next line
            Console.WriteLine();
        }
        public static void ChramTriSrdciGameplay()
        {
            PosledniPochuzka();
            List<string> titulky = new List<string> { "Děkuji za hraní Live Thrice!", "Příběh: Petr Nosek", "Ilustrace a ASCII: Štěpán Štroner", "H. Developer: Petr Nosek",
            "Hudba od: Leimoti", "Edgar Hopp", "Bonn Fields", "Emily Rubye", "Christian Andersen", "Phoenix Tail", "Howard Harper-Barnes", "John Abbot", "Arylide Fields"
            ,"Hampus Naeselius", "Christopher Moe Ditlevsen", "Jo Wandrili", "Fredrik Ekstrom", "Dream Cave", "Gerard Franklin", "Inspirace od: The Darkest Dungeon",
            "The Elder Scrolls V: Skyrim", "Magic the Gathering",".....", "Hra se nyní ukončí, děkujeme!"};
            DndHerniFunkce.Titulky(titulky);
            Clear();           
            ForegroundColor = ConsoleColor.Red;
            WriteLine(@"


                         _     _             _____ _          _          
                        | |   (_)           |_   _| |        (_)         
                        | |    ___   _____    | | | |__  _ __ _  ___ ___ 
                        | |   | \ \ / / _ \   | | | '_ \| '__| |/ __/ _ \
                        | |___| |\ V /  __/   | | | | | | |  | | (_|  __/
                        \_____/_| \_/ \___|   \_/ |_| |_|_|  |_|\___\___|
                                                 

                                        ⣠⣶⣶⣶⣤⡀⠀⠀⠀⠀⠀⠀⣠⣶⣾⣿⣶⣄
                        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⣿⠛⠉⠛⠿⣿⣦⡀⠀⠀⢠⣾⡿⠋⠁⠀⠹⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⡇⠀⠀⠀⠀⠙⣿⣷⡄⢠⣿⡿⠁⠀⠀⠀⠀⣿⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⡇⠀⠀⠀⠀⠀⠘⣿⣷⣼⣿⠃⠀⠀⠀⠀⠀⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣷⠀⠀⠀⠀⠀⠀⠸⣿⣿⡿⠀⠀⠀⠀⠀⢀⣿⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⣿⡄⠀⠀⠀⠀⠀⠀⣿⣿⡇⠀⠀⠀⠀⠀⣸⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⣧⠀⠀⠀⠀⠀⠀⢸⣿⡇⠀⠀⠀⠀⢀⣿⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣿⣷⡄⠀⠹⣿⣧⠀⠀⠀⠀⠀⠈⠛⠁⠀⠀⠀⢀⣾⡿⠀⠀⢠⣾⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⡄⠀⠹⣿⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⣿⠁⠀⢠⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⣿⣿⣿⡄⠀⠙⢿⣿⣄⠀⠀⠀⠀⠀⠀⠀⣼⡿⠁⠀⢠⣿⣿⣿⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                        ⠀⠀⠀⠀⠀⠀⢀⣤⣤⣤⣀⠀⢻⣿⣿⣿⣿⡀⠀⠈⢻⣿⣦⡀⠀⠀⠀⠀⣼⡿⠁⠀⢀⣿⣿⣿⣿⡟⠀⣀⣤⣤⣤⡀⠀⠀⠀⠀⠀
                        ⠀⠀⠀⠀⠀⢰⣿⣿⣿⣿⣿⣷⣾⣿⣿⣿⣿⣧⠀⠀⠀⠹⣿⣷⣄⠀⢀⣾⡟⠀⠀⠀⣼⣿⣿⣿⣿⣷⣾⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀
                        ⠀⠀⠀⠀⠀⠀⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠈⢿⣿⣦⣾⠟⠀⠀⠀⢠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠟⠀⠀⠀⠀⠀
                        ⠀⠀⠀⠀⠀⠀⠀⠈⠛⠿⣿⣿⣿⣿⣿⣿⣿⣿⣷⠀⠀⠀⠀⠈⢻⣿⠇⠀⠀⠀⠀⣾⣿⣿⣿⣿⣿⣿⣿⣿⠿⠛⠁⠀⠀⠀⠀⠀⠀
                        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠙⠛⠿⠿⠿⢿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⡿⠿⠿⠿⠛⠋⠉⠀⠀⠀

                                                                            ");
            ResetColor();
            Environment.Exit(0);
            void PosledniPochuzka()
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Cyan;
                    AnimaceTextu("Vaše teleportační zařízení Vás tentokrát doneslo na podezřele hezky vypadající místo.");
                    AnimaceTextu("Přistáváte na sytě zeleném trávníku, který je pokrytý Zvláštními čtyřlístky a Astrami.");
                    AnimaceTextu("Na místo Vašeho dopadu spadají sluneční paprsky, které se rozdělují přes nebesky bíle mraky přítomné na obloze.");
                    AnimaceTextu("Zpoza nevýrazných mračen se táhne po horizontu duha, výhled vypadá opravdu hezky.");
                    AnimaceTextu("Když se pořádně rozhlédnete, zjišťujete, že jste vlastně na ostrově.");
                    AnimaceTextu(".....");
                    Tlacitko();
                    ForegroundColor = ConsoleColor.Blue;
                    AnimaceTextu("Pod Vámi je jakási propast, její konec je v nedohlednu, vypadá to, jakoby jste byli v nebesích.");
                    AnimaceTextu("Pád by rozhodně byl nepříjemný, obrátite se tedy raději zpět na kouzelně vypadající krajinu.");
                    AnimaceTextu("V dáli spatříte jakýsi chrám, který vypadá, že na místě stojí už dlouhá léta.");
                    AnimaceTextu("I přesto je velmi zachovalý, blyští všemi barvami a efektivně odráží světlo slunce, které zvýrazňuje venkovní barvy a iluminace.");
                    AnimaceTextu("Jeho hlavní dveře, prokládány kermickým sklem, jsou otevřeny. Hosté jsou tedy pravděpodobně vítáni.");
                    AnimaceTextu(".....");
                    Tlacitko();
                    Okradeni();
                    ForegroundColor = ConsoleColor.Yellow;
                    AnimaceTextu("Jste u hlavních dveří a chrám je opravdu majestátní. Barevná kompozice je pečlivě zvolena a gotická architektura vzhledu jedině prospívá");
                    AnimaceTextu("Bez váhání vejdete dovnitř...");
                    AnimaceTextu("Následuje dlouhá chodba, zkrášlena obrazy, které doprovázejí iluminace, spatřeny už z venku.");
                    AnimaceTextu("Mramorové ornamenty tvoří pěkné doplňky a modro - bílý koberec vypadá nově, není na něm žádný prach.");
                    Tlacitko();
                    ForegroundColor = ConsoleColor.Magenta;
                    AnimaceTextu("Přčicházíte až nakonec chodby, která je napojena na větší - pravděpodobně hlavní - místnost.");
                    AnimaceTextu("Nad rámem dveří je zlatem přibyto jméno.");
                    WriteLine("'Dratan'");
                    Thread.Sleep(1000);
                    WriteLine();
                    AnimaceTextu("Dratan? To je přeci kněz! Ten kněz, který má na starost Vaši rodinnou kletbu...");
                    AnimaceTextu("To je přeci hloupost, v tak hezkém chrámu nebůže být někdo, o kom víte že...");
                    AnimaceTextu("....");
                    Tlacitko();
                    PrimaRec("Dratan", "Prvorozené dítě z rodiny vysokého postavení si probojuje cestu až k hlavnímu nepříteli, kterého má za úkol zabít.", ConsoleColor.DarkCyan);
                    PrimaRec("Dratan", "Proč? Jeho rodině se nelíbí, že mohou žít tříkrát. Třikrát...", ConsoleColor.DarkCyan);
                    PrimaRec("Dratan", "Co by za to jiní dali. Tenkrát dobrodinec Dratan za takový dar ani nic nechtěl...", ConsoleColor.DarkCyan);
                    PrimaRec("Dratan", "Jakmile se ale Dratan jen pokusí dotknout toho, co celý život studoval a co Vašemu rodu propůjčilo takovou moc...", ConsoleColor.DarkCyan);
                    PrimaRec("Dratan", "Tak se naskytnou problémy. Problémy, o které se nikdo neprosil. Vše mohlo být v nejlepším pořádku...", ConsoleColor.DarkCyan);
                    Tlacitko();
                    ForegroundColor = ConsoleColor.DarkMagenta;
                    AnimaceTextu("Kněz nevypadá, že by byl při smyslech. Rozhodně se změnil od posledního...setkání.");
                    AnimaceTextu("Z jeho roucho, které kdysi bylo jeho náboženskou symbolikou, se staly cáry, z kterých ukapává podivná černá hmota.");
                    AnimaceTextu(".....");
                    Tlacitko();
                    PrimaRec("Dratan", "Dratan ale chce dokončit co začal! Ostatní nevidí moc, kterou tři životy mají.", ConsoleColor.DarkCyan);
                    PrimaRec("Dratan", "Ještě lépe, moc, kterou skýtají rozdělení duše do více částí...", ConsoleColor.DarkCyan);
                    PrimaRec("Dratan", "Ale ne, Dratana nikdo nemůže chápat...");
                    PrimaRec("Dratan", "Až Dratan zabije ty nevděčníky, kteří neocení jeho štědrost, jeho moc vyjde na světlo světa!");
                    Tlacitko();
                    ForegroundColor = ConsoleColor.DarkBlue;
                    AnimaceTextu("Kněz se potřísnil slizce vypadající tekutinou černé barvy.");
                    AnimaceTextu("Nejen že se zvětšil a nabral poměrně neobvyklou podobu, ale také se...fragmetnoval.");
                    AnimaceTextu("Vypadá to, že části jeho duše nabyli nové podoby a ukořistily si část jeho těla.");
                    AnimaceTextu("V místnosti se nyní pohybuje více knězů, liší se velikostně i povahově");
                    AnimaceTextu("Jedna věc jim však zůstala společná. Touha zabít narušitele experimetu, který změní svět.");
                    AnimaceTextu("....");
                    AnimaceTextu("Víte, že Vaše rodina je ve vážném nebezpečí, ústup tedy nepřipadá v úvahu.");
                    Tlacitko();
                    ForegroundColor = ConsoleColor.Green;
                    AnimaceTextu("Když kněz viděl, že jste tasili zbraň, společně s jeho fragmenty odběhl do ználivě skryté místnosti za ním.");
                    AnimaceTextu("Slyšíte zlomyslný smích, když se v místnosti zavřel...");
                    AnimaceTextu("Zjišťujete, že místnost je zamčena sekvencí runových zámků.");
                    AnimaceTextu("O těch něco víte - vtáhnou Vás do vysoce nestabilní a nebezpečné sféry a postaví před Vás libovolnou výzvu.");
                    AnimaceTextu("Když uspějete, zámek se otevře.");
                    AnimaceTextu("Když ne, často lupiče čeká nejvyšší trest...");
                    AnimaceTextu("Víte, co musíte udělat. Soustřeďte se!");
                    AnimaceTextu(".....");
                    Tlacitko();
                    Pamatovak prvniZ = new Pamatovak(new int[] { 5, 8, 9, 4 }, 4, 1000);
                    prvniZ.Hraj();
                    if (prvniZ.dokonceno)
                    {
                        Pamatovak druhyZ = new Pamatovak(new int[] { 1, 5, 9 }, 3, 750);
                        druhyZ.Hraj();
                        if (druhyZ.dokonceno)
                        {
                            Pamatovak Finale = new Pamatovak(new int[] { 4, 5, 6 }, 3, 550);
                            Finale.Hraj();
                            if (Finale.dokonceno)
                            {
                                Clear();
                                ForegroundColor = ConsoleColor.DarkYellow;
                                AnimaceTextu("Jste v pokoji společně s Dratanem a jeho fragmenty, vypadá překvapeně a stroze nadává.");
                                AnimaceTextu("Je to teď, nebo nikdy.");
                                Tlacitko();
                                Souboj(VasePostava.hracovaPostava, new DratanJednouSeSvetlem(4), true, true, "Knězův fragment - menší");
                                Souboj(VasePostava.hracovaPostava, new DratanJednouSeSvetlem(2), true, true, "Knězův fragment - větší");
                                Souboj(VasePostava.hracovaPostava, new DratanJednouSeSvetlem(1), false, true);
                                Clear();
                                ForegroundColor = ConsoleColor.DarkRed;
                                AnimaceTextu("Kněž byl poražen, nalézáte u něj baňku s dušemi jeho obětí.");
                                AnimaceTextu("Když s ní práskente o zem, cítíte pruské bodnutí, padáte do bezvědomí.");
                                AnimaceTextu("Probouzíte se v zámku, v pokoji, který dobře znáte...");
                                Tlacitko();
                                PrimaRec("Lilia", "Zvládl jsi to...");
                                PrimaRec("Lilia", "Všichni jsou v porádku, osvobodil jsi nás včas.");
                                Tlacitko();
                                ForegroundColor = ConsoleColor.Blue;
                                AnimaceTextu("Víte, že prokletí bylo prolomeno. Všichni z Vašeho rodokmene teď mají jeden jediný život, který však patří jen jim");
                                AnimaceTextu("Je tedy na čase ho žít naplno, bez žádných omezení...");
                                AnimaceTextu("....");
                                AnimaceTextu(".......");
                                AnimaceTextu(".........");
                                AnimaceTextu("..........");
                                Tlacitko();
                                
                        }
                            else
                                NeuspechPamatovaku();
                        }
                        else
                            NeuspechPamatovaku();
                    }
                    else
                        NeuspechPamatovaku();

                    void NeuspechPamatovaku()
                    {
                        Clear();
                        ForegroundColor = ConsoleColor.Red;
                        AnimaceTextu("Víte, jaká jsou rizika runových zámků.");
                        AnimaceTextu("Tentokrát Vás smůla dohnala. Hodně štěstí příště...");
                        AnimaceTextu("........");
                        Tlacitko();
                        DndHerniFunkce.KonecHryMimoSouboj();
                    }
                }                       
            //titulky
        }
    }
}
