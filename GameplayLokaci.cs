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
namespace DnD_Hra
{
    internal static class GameplayLokaci_1
    {
        
        static bool PerfektSkrt()
        {
            if (!zabilHlidku && domluvilSe)
                return true;
            else
                return false;
        }
        public static void Tlacitko()
        {
            ResetColor();
            Thread.Sleep(150);
            WriteLine();
            WriteLine("stiskněte libovolné tlačítko pro pokračování...");
            ReadKey(true);
            Clear();
        }
        public static void PrimaRec(string kdoToRika, string text, ConsoleColor barva = ConsoleColor.DarkGray)
        {
            ForegroundColor = barva;
            WriteLine();
            WriteLine($"{kdoToRika}{dt} \"{text}\"");            
            Thread.Sleep(3000);
            ResetColor();
        }
        //PRVOTNÍ
        static bool _spolOdesel = false;
        static string dt = ":";
        static string otaznik = @"
                                   ?
                           <Zvolte možnost>";
        static bool zabilHlidku = false;
        static bool domluvilSe = false;
        static bool zemrelKupec = false;
        public static void ValoriaGameplay()
        {//tady valoria začíná
          
              //Zacatek();
             // PriselDoMesta();
              //DaleDoMesta();
             // Vezeni();
              PosledniBitva();                     
            //tady lokace končí

            //fce sem
            void Zacatek()
            {
                bool _PresvedcilStraze = false;
                Clear();
                ForegroundColor = ConsoleColor.Blue;
                AnimaceTextu("Jdete nevýraznou krajinou, která místy připomíná spíše Tundru...");
                AnimaceTextu("Namířeno nemáte nikam, ale jste rádi, že Vám nohy slouží.");
                AnimaceTextu("Je relativně teplo. Zamžouráte před sebe a vidíte obrys převelikého města, které se rozpíná v dáli.");
                AnimaceTextu("Bez rozmyslu se rozhodnete k městu vydat...");
                Tlacitko();
                MusicPlayer.BardPotkani();
                Clear();
                ForegroundColor = ConsoleColor.Blue;
                AnimaceTextu("Přicházíte až před brány města, kde Vás zastavuje unaveně vypadající stráž...");
                PrimaRec("Strážný 1", "Co ten tu chce, tulák?");
                PrimaRec("Strážná 2", "To nevím, pustíme ho dovnitř?");
                AnimaceTextu(".............");
                PrimaRec("Strážný 1", "Ehm... vstup do města pouze za 10 zlatých, vandráku!");
                Tlacitko();
                ForegroundColor = ConsoleColor.Blue;
                AnimaceTextu("Nelíbí se Vám, že s Vámi takhle jednají, ale částečně jim rozumíte - nevypadáte zrovna obdivuhodně.");
                AnimaceTextu("Víte, že teď máte pár možností...");
                Tlacitko();
                Menu Zlato = new Menu(otaznik, new List<string> { "\"Stejně vím, že je to podvod. Pusťe mě a nic na vás neřeknu...\"", "\"Tolik peněz nemám.\"" }, ConsoleColor.DarkYellow);
                int m = Zlato.NavratIndexu();
                if (m == 0)
                {
                    Past UspejeNadPodvodem = new Past(250000, VasePostava.hracovaPostava.vStesti, "štěstí", VasePostava.hracovaPostava.vJmeno);
                    if (UspejeNadPodvodem.Uspech())
                        UspelPriObirce();
                }
                if (!_PresvedcilStraze)
                    NeuspelPriObirce();
            }
            void UspelPriObirce()
            {              
                Clear();
                PrimaRec("Strážný 1", "Dobře, dobře, ne tak nahlas... Pojď, rychle, otevřu ti bránu...");
                PrimaRec("Strážná 2", "A psst, ne že to někomu povíš.");
                Tlacitko();

            }
            void NeuspelPriObirce()
            {
                Clear();
                PrimaRec("Strážná 2", "Ať je to jak je to, jedna věc je jistá...");
                PrimaRec("Strážný 1", "A to je to, že jsi úplně švorc!");
                PrimaRec("Strážný 1 a Strážná 2", "hahahahahahaha");
                AnimaceTextu("...........");
                PrimaRec("Strážný 1", "Ale počkej Heleno, víš co by mohl udělat?");
                PrimaRec("Helena", "No... ale Gustave, seš si jistej, že z toho nebudeme mít průser?");
                AnimaceTextu("............");
                PrimaRec("Gustav", "Ale prosimtě, jasně, že nebudem, je to jenom práce, nemám pravdu?");
                AnimaceTextu("............");
                PrimaRec("Gustav", "Poslyšte, neznáma osobo, jestli chcete do města, podsekněte skřety, ty jak nám tu v noci zabili ovce.");
                PrimaRec("Gustav", "Jsou kousek na západ, schovávaj se v jeskyni pod jednim kopcem, myslej si, že jsou nenápadný ale nejsou.");
                PrimaRec("Gustav", "Je to takovej převis, nemůžete to minout, asi pět tisíc stop odsud...");
                PrimaRec("Helena", "Jo... a teď už jděte, čím dřív, tím líp, nechceme další mrtvý ovce!");
                Tlacitko();
                ForegroundColor = ConsoleColor.Blue;
                AnimaceTextu("Je vám jasné, že přes tyhle nafoukance se do města jinak nedostanete.");
                AnimaceTextu("Uvažujete, jestli Vám to za to stojí, ale město vypadá i přes tyhle hlupáky nádherně.");
                AnimaceTextu("Rozhodnete se tedy, že počkáte až se zešeří a zmíněné skřety vyhladíte a ochráníte tak ovce ve městě...");
                AnimaceTextu("Nevíte kudy by skřeti do města v noci mohli přijít, proto si to namíříte přímo do jejich jeskyně.");
                Tlacitko();
                HonNaSkrety();
            }
            void HonNaSkrety()
            {
                ForegroundColor = ConsoleColor.Blue;
                AnimaceTextu("V průběhu čekání na šero si dáte něco k snědku a prohlédnete si okolí tohoto speciálního města.");
                AnimaceTextu("Přes mohutné hradby toho moc vidět není, jediné co spatříte je absurdně vysoká socha, která vyčuhuje nad městem.");
                AnimaceTextu("Socha se stříbří ve slunečním světle a dle Vašeho lajdáckého úsudku je to socha Valkýrie, jakési andělské válečnice.");
                AnimaceTextu("Okolí města jinak nevypadá nijak neobvykle, ale opravdu Vás zajímá jak to vypadá ve městě samotném...");
                AnimaceTextu("Rozhodnete se tedy předčasně vyrazit na prohlídku skřetí jeskyně pod převisem.");
                AnimaceTextu(".............");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Podle pokynů se vydáváte na západ. Vítr příjemně fouká a okolo Vás se začíná pomalu, ale jistě stmívat.");
                AnimaceTextu("Je Vám jasné, že Vás stráže využili na vykonání špinavé práce, kterou by jinak museli udělat oni.");
                AnimaceTextu("Není Vám to však proti srsti, podobných úkolů za sebou už pár máte. Za vstupenku do města to podle Vás stojí...");
                AnimaceTextu(".............");
                AnimaceTextu("Strážní Vám nelhali. Asi 120 stop od Vás se v nočním světle šíří oheň pochodně, která je uchycena v železném stojanu.");
                AnimaceTextu("Stojan je přikut do jakéhosi kamenného útvaru, před kterým stojí silueta malé postavy.");
                AnimaceTextu("Okamžitě poznáváte malého skřeta. Víte, že právě drží hlídku. V hlavě zvažujete možnosti, jak se k situaci postavit...");
                AnimaceTextu(".............");
                Tlacitko();
                Menu akceUskretu = new Menu(otaznik, new List<string> {@"Proplížit se okolo skřeta do jeskyně", "Proplížit se okolo jeskyně a zhodnotit situaci",
                 "Zaútočit na hlídkujícího skřeta"}, ConsoleColor.DarkCyan);
                int v = akceUskretu.NavratIndexu();
                if (v == 2)
                    _BojsHldikou(false);
                else if (v == 1)
                    if (!_PastNaPlizeni(3))
                        _BojsHldikou(true);
                    else
                        _ZkoumaOkoliJeskyne();
                else if (v == 0)
                    if (!_PastNaPlizeni(5))
                        _BojsHldikou(true);
                    else
                        _ProplizilDoJeskyne(true);

                OdchodAdokonceni(zabilHlidku);

                void _BojsHldikou(bool plizilSe)
                {
                    zabilHlidku = true;
                    Clear();
                    ForegroundColor = ConsoleColor.DarkBlue;
                    if (plizilSe)
                        AnimaceTextu("Plížení se Vám bohůžel vůbec nepovedlo a skřet Vás s překvapeným výrazem spatřil...");
                    AnimaceTextu("Víte, že souboj se skřetem, který hlídá, je tedy nevyhnutelný.");
                    AnimaceTextu(".......");
                    Tlacitko();
                    Souboj(VasePostava.hracovaPostava, new SkretBojovnik(), false, true, "Skřetí hlídka");
                    Clear();
                    ForegroundColor = ConsoleColor.DarkBlue;
                    AnimaceTextu("Snaha se plížít je ta tam. Opatrně našlapujete a pokračujete dále do jeskyně...");
                    Tlacitko();
                    _ProplizilDoJeskyne(false);

                }
                bool _PastNaPlizeni(int minVysledek)
                {
                    Past plizeni = new Past(minVysledek, VasePostava.hracovaPostava.vObratnost, "obratnost", VasePostava.hracovaPostava.vJmeno);
                    return plizeni.Uspech();
                }
                void _ZkoumaOkoliJeskyne()
                {
                    Clear();
                    ForegroundColor = ConsoleColor.DarkBlue;
                    AnimaceTextu("Úspěšně jste tichým krokem obešli skřetí jeskyni...");
                    AnimaceTextu("Venku nevidíte nikoho jiného, než původní skřetí hlídku. Zbývají Vám tedy dvě logické možnosti.");

                    Tlacitko();
                    Menu akceUskretu = new Menu(otaznik, new List<string> { "Proplížit se okolo skřeta do jeskyně", "Zaútočit na hlídkujícího skřeta" }, ConsoleColor.DarkCyan);
                    int akce = akceUskretu.NavratIndexu();
                    if (akce == 1)
                        _BojsHldikou(false);
                    else
                        if (!_PastNaPlizeni(3))
                        _BojsHldikou(true);
                    else
                        _ProplizilDoJeskyne(true);


                }
                void _ProplizilDoJeskyne(bool plizilSe)
                {
                    Clear();
                    ForegroundColor = ConsoleColor.DarkBlue;
                    if (plizilSe)
                    {
                        AnimaceTextu("Plížíte se opravdu mistrovsky. Skřetí hlídka neuslyšela ani vánek větru...");
                        AnimaceTextu("Bez větších problémů se dostáváte do skřetí jeskyně.");
                        AnimaceTextu(".......");
                    }
                    AnimaceTextu("Procházíte tiše poměrně nerozměrným jeskynním komplexem. Náhle shlížíte z vysoké rampy na tři skřety sedící u ohniště.");
                    AnimaceTextu("Ohniště je velké a skřeti sedí okolo. Vypadá to, že hodují na nedávno ukořistěné ovci z města...");
                    AnimaceTextu("........");
                    Tlacitko();
                    ForegroundColor = ConsoleColor.DarkBlue;
                    PrimaRec("Skřet 1", "Ovce být dobrá, my vyrazit zas?");
                    PrimaRec("Skřet 2", "Né ty troubo, přistihli by nás a zabili...");
                    PrimaRec("Skřet 3", "My najít jídlo jinde a mít hody i tak!");
                    Tlacitko();
                    ForegroundColor = ConsoleColor.DarkBlue;
                    AnimaceTextu("Skřeti se dobře baví. Podle způsobu mluvy poznáváte, že jeden ze skřetů je výrazně chytřejší než ti ostatní.");
                    AnimaceTextu("Zaujal Vaši pozornost nejen svou mluvou, ale i vzhledem - má na sobě těžkou zbroj a ochranné brýle.");
                    AnimaceTextu("Mezititím co se jeho dva kolegové cpou ovcí, tento skřet sedí u ohně a slévá dohromady jakési chemikálie...");
                    AnimaceTextu("Víte, že skřeti mluví Vaší řečí a že z jedním z nich by se dalo dokonce jednat. Otázka zní, jestli to má smysl.");
                    AnimaceTextu("........");
                    Tlacitko();
                    Menu ZabitciJednat = new Menu(otaznik, new List<string> { "Zaútočit na skupinku skřetů", "Pokusit se jednat" }, ConsoleColor.Magenta);
                    int z = ZabitciJednat.NavratIndexu();
                    if (z == 0)
                        UtokNASkrety(true);
                    else
                        if (!PastNaDomluvu(4))
                        UtokNASkrety(false);
                    else
                        Vydarenadomluva();


                }
                void Vydarenadomluva()
                {
                    domluvilSe = true;
                    Clear();
                    AnimaceTextu(".............");
                    PrimaRec("Nejchytřejší ze skřetů", "Jo, je to risk i pro nás... Máš ale lepší nápad?");
                    PrimaRec("Skřet u ohniště 1", "My nemít zrovna moc možností...");
                    AnimaceTextu(".............");
                    PrimaRec("Nejchytřejší ze skřetů", "Ty že by jsi nás naučil vařit ze surovin v okolí a lovit místní zvířata?");
                    PrimaRec("Skřet u ohniště 2", "My mít rád dobré jídlo...");
                    PrimaRec("Nejchytřejší ze skřetů", "Tak co už, za zkoušknu nic nedáme. Že, pánové?");
                    AnimaceTextu("........");
                    Tlacitko();
                    ForegroundColor = ConsoleColor.DarkBlue;
                    AnimaceTextu("Zbytek noci učíte skřety jak uvařit základní pokrmy a ulovit místní zvěř.");
                    AnimaceTextu("Co se lovu týče skřeti jsou poměrně zdatní, um se střelnými zbraněmi jim není cizí, sami jich pár vlastní...");
                    AnimaceTextu("Největší výzva pro Vás bylo vaření. Naučit skřety zpracovávat zeleninu a maso tak, aby jídlo bylo poživatelné.");
                    AnimaceTextu("Nakonec jste ale uspěli. Dokonce jste jim pomohli sepsat krátkou kuchařku, aby měli předlohu, podle které vařit.");
                    AnimaceTextu("Skřeti nebyli ochotní se učit a párkrát na Vás vytáhli i meče, ale nakonec jste se shledali s úspěchem.");
                    AnimaceTextu("Skulinami v jeskyni začíná prosvítat ranní slunce a Vy se rozhodnete jít zpět do města.");
                    AnimaceTextu(".......");
                    Tlacitko();

                }
                void OdchodAdokonceni(bool ZabilHlidku)
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Blue;
                    if (!ZabilHlidku)
                    {
                        AnimaceTextu("Při cestě zpět si vzpomínáte na skřetí hlídku u vchodu do jeskyně.");
                        AnimaceTextu("Nechcete žádné další problémy, jdete proto raději nouzovým východem, který jste spatřili za ohništěm u skřetů.");
                    }
                    AnimaceTextu("Vracíte se tedy z jeskyně zpět před městské brány s pocitem dobře vykonané práce...");
                    if (PerfektSkrt())
                    {
                        ForegroundColor = ConsoleColor.Green;
                        AnimaceTextu("Jelikož se Vám povedlo inteligetně vyřešit tento úkol a nikoho nezabít, odnášíte si cenné zkušenosti.");
                        AnimaceTextu("Hodnota obratnosti a inteligence se Vám zvyšují o 1!");
                        VasePostava.hracovaPostava.vObratnost += 1;
                        VasePostava.hracovaPostava.vInteligence += 1;
                        WriteLine();
                        WriteLine("{0} má nyní {1} inteligence a {2} obratnosti.", VasePostava.hracovaPostava.vJmeno, VasePostava.hracovaPostava.vInteligence,
                            VasePostava.hracovaPostava.vObratnost);
                        Thread.Sleep(250);
                    }
                    Tlacitko();
                    AnimaceTextu(".........");
                    PrimaRec("Helena", "Kohopak nám to čerti nesou!");
                    PrimaRec("Gustav", "Ty jsi se vrátil, předpokládám, že jsi úkol splnil?");
                    AnimaceTextu(".........");
                    PrimaRec("Gustav", "No teda, dobrá práce... Ani nevíš jak nám to s Helčou pomůže.");
                    PrimaRec("Helena", "To jo, mám z toho radost. Hele víšco? Vem si tohle a já ti otevřu bránu...");
                    AnimaceTextu("........");
                    Tlacitko();
                    ForegroundColor = ConsoleColor.Blue;
                    AnimaceTextu("Předtím, než strážkyně Helena otevře bránu, Vám na ruku napočítá deset zlatých. Za odměnu jste rádi.");
                    AnimaceTextu("S dobrou náladou se opíráte o městskou bránu a jste zvědaví, jak město bude vypadat.");
                    AnimaceTextu(".......");
                    for (int i = 0; i < 10; i++)
                        VasePostava.inventarPostavy.PridejPredmet(Zlaťák);
                    Tlacitko();

                }
                void UtokNASkrety(bool utokRovnou)
                {
                    Clear();

                    if (!utokRovnou)
                    {
                        AnimaceTextu(".........");
                        PrimaRec("Nejchytřejší ze skřetů", "Hele, návštěva, hahaha. A nechce abysme mu zabíjeli ovečky.");
                        PrimaRec("Skřet u ohniště 1", "Co takhle my zabít a sníst tebe?!");
                        PrimaRec("Skřet u ohniště 2", "Ty vypadat lahodně!");
                        Tlacitko();
                    }
                    ForegroundColor = ConsoleColor.DarkBlue;
                    AnimaceTextu("Víte, že se prolije krev. Připravujete se na souboj se skřety v jeskyni...");
                    AnimaceTextu("Ve zlomku času před započatím souboje spatříte na zemi červenou lahvičku. Víte, že se jedná o lektvar zdraví.");
                    AnimaceTextu("Nad ničím nepřemýšlíte a vezmete si ho - pro jistotu.");
                    VasePostava.inventarPostavy.PridejPredmet(Lektvar_Zdraví);
                    Tlacitko();
                    Souboj(VasePostava.hracovaPostava, new SkretTravic(), true, true, "Chytřejší skřet - travič");
                    Souboj(VasePostava.hracovaPostava, new SkretBojovnik(), true, false);
                    Souboj(VasePostava.hracovaPostava, new SkretBojovnik(), false, false);
                    Clear();
                    ForegroundColor = ConsoleColor.DarkBlue;
                    AnimaceTextu("Vyčerpávající bitva. Jste rádi, že skončila vítězně pro Vás...");
                    AnimaceTextu("Na nic nečekáte a svižným krokem jdete ven z jesykně...");
                    AnimaceTextu(".......");
                    Tlacitko();

                }
                bool PastNaDomluvu(int minhod)
                {
                    Past past = new Past(minhod, VasePostava.hracovaPostava.vInteligence, "inteligenci", VasePostava.hracovaPostava.vJmeno);
                    return past.Uspech();
                }
            }
            void PriselDoMesta()
            {
                ForegroundColor = ConsoleColor.Blue;
                AnimaceTextu("Než se nadějete, strážkyně Helena drží v ruce svazek klíčů. Vezme ten největší a otočí jím v honosném zámku.");
                AnimaceTextu("Brána se pootevřela a Vy nedočkavě vstupujete do města...");
                Tlacitko();
                ForegroundColor = ConsoleColor.Blue;
                AnimaceTextu("........");
                AnimaceTextu("Město křičí stříbrně - modrou barevnou paletou, která se projevuje na uniformách místních stráží a praporech na budovách.");
                AnimaceTextu("Všichni mají napilno - stráže, prodejci v nejrůznějších obchodech, dodavatelé zboží jedoucí na koních, ale i obyčejní farmáři.");
                AnimaceTextu("Obyvatelstva rozhodně není málo. Každé řemeslo má ve městě svého zástupce a Vás nenapadá věc, která by městu chyběla.");
                AnimaceTextu("Historii města neznáte, ale už od pohledu víte, že je jaksi spjatá s Valkýriemi.");
                AnimaceTextu("Tu ostatně reprezetuje veliká socha stojící v jejím středu - ta, kterou jste viděli předtím, stejně jako ornamenty na budovách.");
                AnimaceTextu("Líbí se Vám, že město není rozděleno na typické společenské vrstvy, do města jste právě vešli a vidíte všechny typy obyvatelstva.");
                AnimaceTextu("Asi pětset kroků od Vás vidíte v mlze modrou věž jakéhosi malého hradu. Usoudíte, že tam přebývá vládce.");
                AnimaceTextu("......");
                Tlacitko();
                ForegroundColor = ConsoleColor.Blue;
                AnimaceTextu("V hlavě se Vám objeví myšlenka důvodu Vašeho příchodu do města. Žádný nebyl, ale najednou je spousta možností co zde dělat.");
                AnimaceTextu("Hned u vchodu je spousta obchodů - Kovárna, Alchymistická laboratoř, ale také obchod s různorodými surovinami.");
                AnimaceTextu("Přemýšlíte tedy nad tím, kam vyrazit...");
                Tlacitko();
                int navstevaK = 0;
                int navstevaS = 0;
                int navstevaA = 0;
                Inventar Kovar = new Inventar();
                for (int i = 0; i < 4; i++)
                    Kovar.PridejPredmet(Železný_Ingot);
                Kovar.PridejPredmet(Meč);
                Kovar.PridejPredmet(Luk);
                Kovar.PridejPredmet(Dýka);               
                Inventar AlchLab = new Inventar();
                for (int i = 0; i < 2; i++)
                    AlchLab.PridejPredmet(Manový_Krystal);   
                for (int i = 0; i < 5; i++)
                    AlchLab.PridejPredmet(Křídlo_Modrého_Motýla);
                for (int i = 0; i < 5; i++)
                    AlchLab.PridejPredmet(Křídlo_Červeného_Motýla);
                for (int i = 0; i < 3; i++)
                    AlchLab.PridejPredmet(Houba_Bodavka);
                for (int i = 0; i < 3; i++)
                    AlchLab.PridejPredmet(Květina_Astra);
                AlchLab.PridejPredmet(Silovník_Šedý);
                AlchLab.PridejPredmet(Lektvar_Zdraví);
                for (int i = 0; i < 2; i++)
                    AlchLab.PridejPredmet(Dračí_Květ);
                Inventar Sur = new Inventar();
                for (int i = 0; i < 2; i++)
                    Sur.PridejPredmet(Dřevo);
                for (int i = 0; i < 2; i++)
                    Sur.PridejPredmet(Železný_Ingot);                
                for (int i = 0; i < 3; i++)
                    Sur.PridejPredmet(Látka);
                for (int i = 0; i < 3; i++)
                    Sur.PridejPredmet(Kůže);

                while (true)
                {
                    Menu menu = new Menu(otaznik, new List<string> { "Kovárna", "Alchymistická laboratoř", "Obchod se surovinami", "Jít dále do města" }, ConsoleColor.Yellow);
                    int m = menu.NavratIndexu();
                    if (m == 3)
                        break;
                    else if (m == 0)
                        Kovarna();
                    else if (m == 1)
                        Laborator();
                    else
                        Suroviny();
                }
                Clear();
                ForegroundColor = ConsoleColor.Blue;
                if (navstevaA > 0 || navstevaK > 0 || navstevaS > 0)
                    AnimaceTextu("Prohlížením místních řemesel a obchodů jste strávili docela dost času. Nyní je čas na oběd!");
                else
                    AnimaceTextu("Vypadá to, že rádi šetříte, výborně. Před obědem se jdete projít po městě a najít krčmu.");
                AnimaceTextu("Našli jste krčmu podle Vašeho gusta. Po krátké inspekci jste zjistili, že ceny v ní jsou poměrně přijatelné.");
                AnimaceTextu("Usednete ke stolu a přemýšlíte, co si dáte...");
                Tlacitko();
                int cenaKanec = 3;
                int cenaLiska = 7;
                int cenaSalat = 1;
                bool jedl = false;
                while (!jedl)
                {
                    Menu jidelnicek = new Menu(otaznik + $"\nNyní máte {VasePostava.inventarPostavy.PocetZlata()} zlatých", new List<string> { "Kančí s obilnou plackou, výběrové pivo (3 zlaté)", "Liščí s houbami na esenci z Atronacha, živá voda (7 zlatých)", "Salát po Valorijsku, medovina (1 zlatý)", "Raději zůstat bez oběda" }, ConsoleColor.Magenta);
                    int j = jidelnicek.NavratIndexu();
                    if (j == 0)
                        Kanci();
                    else if (j == 1)
                        Lisci();
                    else if (j == 2)
                        Salat();
                    else if (j == 3)
                        BezObeda();
                }
                void Kovarna()
                {
                    navstevaK++;
                    Clear();
                    ForegroundColor = ConsoleColor.Blue;
                    if (navstevaK == 1)
                        AnimaceTextu("Kovárna si udržuje modro - stříbrný vzhled. Kovář vypadá čestně a pracovitě, po jeho boku vidíte výstavu zbraní.");
                    AnimaceTextu("Rozhodnete se tedy vejít do místní kovárny." + (navstevaK > 1 ? $" A to již po {navstevaK}." : ""));
                    Tlacitko();
                    Obchod.KovarnaObchod(VasePostava.inventarPostavy, Kovar, "Valorijské");
                    Clear();
                    ForegroundColor = ConsoleColor.Blue;
                    AnimaceTextu("Nyní přecházíte do části Kovárny, kde si lze samostatně vytvářet a vylepšovat vybavení!");
                    Tlacitko();
                    TvrobaPredmetu.Kovarna();
                    Clear();
                    ForegroundColor = ConsoleColor.Blue;
                    AnimaceTextu("Z Kovárny odcházíte." + (navstevaK == 1 ? " Máte z ní dobrý dojem." : " Znovu."));
                    Tlacitko();
                }
                void Laborator()
                {
                    navstevaA++;
                    Clear();
                    ForegroundColor = ConsoleColor.Blue;
                    if (navstevaA == 1)
                        AnimaceTextu("V Laboratoři je neobvykle vlhký vzduch. Žena, prodávající v tomto obchodě vypadá, že se v řemesle opravdu vyzná!");
                    AnimaceTextu("Rozhodnete se tedy vejít do místní alchymistické laboratoře." + (navstevaA > 1 ? $" A to již po {navstevaA}." : ""));
                    Tlacitko();
                    Obchod.LaboratorObchod(VasePostava.inventarPostavy, AlchLab, "Valorijské");
                    Clear();
                    ForegroundColor = ConsoleColor.Blue;
                    AnimaceTextu("Teď přecházíte k alchymistickému stolu, kde si můžete vyrobit, co se Vám zlíbí.");
                    Tlacitko();
                    TvrobaPredmetu.Laborator();
                    Clear();
                    ForegroundColor = ConsoleColor.Blue;
                    AnimaceTextu("Z laboratoře odcházíte." + (navstevaA == 1 ? " Líbí se Vám originalita tohoto místa." : " Znovu."));
                    Tlacitko();
                }
                void Suroviny()
                {
                    navstevaS++;
                    Clear();
                    ForegroundColor = ConsoleColor.Blue;
                    if (navstevaS == 1)
                        AnimaceTextu("Muž ve venkovním obchodě právě rozsekl poslední špalek, lidé tu vypadají pracovitě.");
                    AnimaceTextu("Rozhodnete se tedy vejít do místního obchodu se surovinami." + (navstevaS > 1 ? $" A to již po {navstevaS}." : ""));
                    Tlacitko();
                    Obchod.SurovinyObchod(VasePostava.inventarPostavy, Sur, "Valoriském");
                    Clear();
                    ForegroundColor = ConsoleColor.Blue;
                    AnimaceTextu("Z obchodu se surovinami odcházíte." + (navstevaS == 1 ? " Jste překvapeni pracovitostí místních." : " Znovu."));
                    Tlacitko();
                }
                void Kanci()
                {
                    Clear();
                    if (VasePostava.inventarPostavy.PocetZlata() < cenaKanec)
                    {
                        ForegroundColor = ConsoleColor.Red;
                        AnimaceTextu($"Vypadá to, že na Kance nemáte dost peněz. Nyní máte {VasePostava.inventarPostavy.PocetZlata()} zlatých...");
                        Tlacitko();
                        return;
                    }
                    ForegroundColor = ConsoleColor.Blue;
                    AnimaceTextu("Kančí Vám bylo po chvilce přineseno. Moc jste si pochutnali, pivo bylo také dobré.");
                    AnimaceTextu("Odcházíte z krčmy s plným žaludkem");
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine();
                    WriteLine("Cítíte se po jídle opravdu dobře. Přidá se Vám tedy 1 k síle!");
                    VasePostava.hracovaPostava.vSila += 1;
                    WriteLine();
                    WriteLine("Nyní máte {0} síly!", VasePostava.hracovaPostava.vSila);
                    Inventar.OdeberZlato(cenaKanec, VasePostava.inventarPostavy);
                    jedl = true;
                    Tlacitko();

                }
                void Lisci()
                {
                    Clear();
                    if (VasePostava.inventarPostavy.PocetZlata() < cenaLiska)
                    {
                        ForegroundColor = ConsoleColor.Red;
                        AnimaceTextu($"Vypadá to, že na Liščí namáte dost peněz. Nyní máte {VasePostava.inventarPostavy.PocetZlata()} zlatých...");
                        Tlacitko();
                        return;
                    }
                    ForegroundColor = ConsoleColor.Blue;
                    AnimaceTextu("Nejistě jste požádali o toto zvláštní jídlo. Viděli jste, jak v kuchyni jeho přípravě přispívá samotný OhnivyElemental!.");
                    AnimaceTextu("Byla to zvláštní podívaná, ale nebyli jste jediní, komu se líbila. Ostatní zákazníci krčmy se také moc rádi dívali.");
                    AnimaceTextu("Když Vám jídlo přinesli v doprovodu Atronacha, který tam jako třešničku na dort přidal vlastní esenci, podivili jste se.");
                    AnimaceTextu("Jídlo však bylo výborné, dokonce by jste si troufli říct, že magické. S nápojem stejnětak...");
                    AnimaceTextu("Po dojedení odcházíte z krčmy s dobrým pocitem.");                  
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine();
                    WriteLine("Je Vám jasné, že na jídle je něco speciálního.");
                    WriteLine();
                    WriteLine("Díky složení pokrmu se Vám zvyšuje zdraví o 2 a inteligence o 1!");
                    WriteLine();
                    if (VasePostava.hracovaPostava.maManu)
                    {
                        WriteLine("Jelikož máte manu, také se Vám zvýšila o 1.");
                        WriteLine();
                    }

                    VasePostava.hracovaPostava.vInteligence += 1;
                    VasePostava.hracovaPostava.vZdravi += 2;
                    if (VasePostava.hracovaPostava.maManu)
                        VasePostava.hracovaPostava.pocetMany += 1;
                    if (!VasePostava.hracovaPostava.maManu)
                        WriteLine("Nyní máte {0} inteligence a {1} zdraví!", VasePostava.hracovaPostava.vSila, VasePostava.hracovaPostava.vZdravi);
                    else
                        WriteLine("Nyní máte {0} inteligence, {1} zdraví a {2} many!", VasePostava.hracovaPostava.vInteligence, VasePostava.hracovaPostava.vZdravi, VasePostava.hracovaPostava.pocetMany);
                    Inventar.OdeberZlato(cenaLiska, VasePostava.inventarPostavy);
                    VasePostava.hracovaPostava.RekonfiguraceHPaMany();
                    jedl = true;
                    Tlacitko();

                }
                void Salat()
                {
                    Clear();
                    if (VasePostava.inventarPostavy.PocetZlata() < cenaSalat)
                    {
                        ForegroundColor = ConsoleColor.Red;
                        AnimaceTextu($"Vypadá to, že na Salát namáte dost peněz. Nyní máte {VasePostava.inventarPostavy.PocetZlata()} zlatých...");
                        Tlacitko();
                        return;
                    }
                    ForegroundColor = ConsoleColor.Blue;
                    AnimaceTextu("Salát s medovinou byl poměrně dobrý, posloužil jako chutný oběd, který Vás dozajista nasytil.");
                    AnimaceTextu("Dojíte a s plným žaludkem odcházíte z krčmy.");
                    jedl = true;
                    Inventar.OdeberZlato(cenaSalat, VasePostava.inventarPostavy);
                    Tlacitko();

                }
                void BezObeda()
                {
                    ForegroundColor = ConsoleColor.Blue;
                    AnimaceTextu("Rozhodli jste se být bez oběda...");
                    WriteLine();
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("Kvůli tomu, že jste se nenajedli, Vám klesá zdraví o 1.");
                    WriteLine();
                    VasePostava.hracovaPostava.vZdravi -= 1;
                    VasePostava.hracovaPostava.RekonfiguraceHPaMany();
                    WriteLine("Nyní máte {0} zdraví.");
                    jedl = true;
                    Tlacitko();
                }
            }
            void DaleDoMesta()
            {
                ForegroundColor = ConsoleColor.Blue;
                AnimaceTextu("Přemýšlíte nad tím, co by v tak zajímavém městě šlo dělat dále...");
                AnimaceTextu("Procházíte tržní čtvrtí, kde vidíte spoustu obchodníků prodávajících nejrůznější zboží.");
                AnimaceTextu("Pozorně se rozhlížíte kolem sebe a snažíte se vstřebat vše, co Valoria nabízí. A že toho není málo.");
                AnimaceTextu(".....");
                AnimaceTextu("Najednou zbystříte. V betonovém výklenku za jedním ze stánků vidíte partu tří zvláštně vypadajících mužů.");
                AnimaceTextu("Mají dlouhé černé pláště a povídají si. Po chvilce pozorování vidíte, jak si jeden z mužů namáčí svou dýku do jakési tekutiny.");
                AnimaceTextu("Když lahvičku zazátkuje, spatříte, jak se pomalým a tichým krokem blíží ke stánku před ním s tasenou dýkou.");
                AnimaceTextu("Víte, že tohle neskončí dobře. Pokud chcete něco udělat, musíte konat hned.");
                AnimaceTextu(".......");
                Tlacitko();
                Menu menu = new Menu(otaznik, new List<string> { "Zaútočit na muže", "Neudělat nic", "Křikem muže oslovit" }, ConsoleColor.DarkMagenta);
                int vo = menu.NavratIndexu();
                if (vo == 0)
                    UtokNaMuze();
                else if (vo == 1)
                    NeudelatNic();
                else
                    OsloveniMuze();
                ForegroundColor = ConsoleColor.Blue;
                AnimaceTextu("Odcházíte ze scenérie společně se strážnými. Periferním viděním si všímáte zbytku města, zatímco jdete směrem k malému hradu...");
                AnimaceTextu("Strážní před hradem otevřou mohutné vchodové dveře. Přicházíte do vládcova hradu.");
                AnimaceTextu("Hrad si udržuje stříbrno - modrý vzhled, stejně jako zbytek města. Na konci hlavní síně vidíte vládce usazeného v jakémsi trůnu.");
                AnimaceTextu("K němu ale nejdete, zabočíte do první chodby vlevo, kde předpokládáte, že se nachází generál.");
                AnimaceTextu("Je to tak. Místnost vypadá strategicky, s rozloženou mapou okolí města na stole a hrstkou stráží, kteří ji obklopují.");
                Tlacitko();
                PrimaRec("Generál", "Dobré odpoledne pánové, Vy... kdo je tohle?");
                if (zemrelKupec)
                    PrimaRec("Strážný 1", "Generále Golie, to je svědek plánované vraždy. Dnes byl v tržnici zavražděn...jeden z kupců.");
                else
                    PrimaRec("Strážný 1", "Generále Golie, to je svědek pokusu o vražu. Dnes byl málem v tržnici zavražděn...jeden z kupců.");
                PrimaRec("Generál", "Je tomu tak?...To jsou hrozné zprávy, okamžitě o tom dám vědět markraběti.");
                PrimaRec("Generál", "A Vy, u celé scény jste byl, žeano?...");
                PrimaRec("Generál", "...Notak, strážní, rozchod!");
                PrimaRec("Strážný 2", "Ano, pane!");
                AnimaceTextu("............");
                PrimaRec("Generál", "Poslyšte, je mi jasné jak se situace vyvinula a že akt dost lidí zahlédlo.");
                PrimaRec("Generál", "Budu je muset uklidnit. Každopádně, Vy mi udělejte laskavost. Nikomu dalšímu o útoku neříkejte.");
                PrimaRec("Generál", "A také se příště nepleťte do... záležitostí města. Děkuji. Tady máte, za Váš čas...pěkný zbytek dne!");
                Tlacitko();
                ForegroundColor = ConsoleColor.Blue;
                AnimaceTextu("Generál Vám dal na ruku pět zlatých a odešel z Vašeho dohledu.");
                for (int i = 0; i < 5; i++)
                    VasePostava.inventarPostavy.PridejPredmet(Zlaťák);
                AnimaceTextu("Po chvilce přišli strážní, kteří Vás z hradu vyvedli.");
                AnimaceTextu("Nerozumíte celé této situaci. Proč generál chce, abyste drželi jazyk za zuby a staví se tak ošemetně k celé záležotsti.");
                AnimaceTextu("A že by Generál kteréhokoliv města za něco takového platil...je přinejmenším velmi zvvláštní.");
                AnimaceTextu("Tím, jak se situace vyvinula, jste znepokojeni. Přemýšlíte, co dělat dál...");
                Tlacitko();
                ForegroundColor = ConsoleColor.Blue;
                if (zemrelKupec)
                {
                    AnimaceTextu("Rádi byste zpět za kupcem a zeptali se ho na situaci, to však není možné, je mrtev...");
                    Tlacitko();

                }
                else
                {
                    AnimaceTextu("Napadlo Vás kupce vyhledat a zeptat se ho na útok, jestli ví něco více, než-li Vy.");
                    AnimaceTextu("Rozhodnete se tedy jít zpět na tržnici s nadějí, že tam nějakým zázrakem kupec stále bude.");
                    AnimaceTextu(".......");
                    AnimaceTextu("Poštěstilo se, na tržnici kupce stále vidíte. Spatříte, jak u něj stojí strážný a dohlíží, aby si kupec mohl stánek složit.");
                    AnimaceTextu("Když Vás Kupec spatří, nechá skládání a vydá se Vám naproti...");
                    Tlacitko();
                    PrimaRec("Kupec", "Dobrý den, děkuji Vám za záchranu, bez Vás bych už tady nebyl.");
                    PrimaRec("Kupec", "V tomhle městě a zabijáci... To jsem odjakživa neviděl. Jako bych já někomu něco provedl...");
                    PrimaRec("Kupec", "Nevím kdo byl ten muž... Ani kdo by si někoho takového mohl najmout, nerozumím tomu!");
                    AnimaceTextu("....");
                    Tlacitko();

                }
                ForegroundColor = ConsoleColor.Blue;
                AnimaceTextu("Rozhodnete se to prozatím nechat být. Jste z dnešní situace však znekliděni, nerozumíte posloupnosti událostí, které se staly.");
                AnimaceTextu(".......");
                AnimaceTextu("Ve městě už se stmívá, rozhodnete se tedy uložit ke spánku. Díky vyspělosti města mají noční ubytovnu pro hosty a to zcela zdarma.");
                AnimaceTextu("Vchod do ubytovny hlídá dvojice stráží. Mají stejný odznak jako generál - jsou tedy z jeho oddílu.");
                AnimaceTextu("Na recepci je Vám řečeno, že Váš je pokoj číslo 38, který je na začátku druhého patra.");
                AnimaceTextu("Postel vypadá pohodlně. Pokoj je vybaven také stolkem a komodou pro odložení věcí. Jste unavení a tak se uložíte ke spánku.");
                AnimaceTextu(".....");
                Tlacitko();
                Past prepadeni = new Past(4, VasePostava.hracovaPostava.vInteligence, "inteligenci", VasePostava.hracovaPostava.vJmeno);
                if (prepadeni.Uspech())
                    UspechPrepadeni();
                else
                    NeuspechPrepadeni();
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Po tom, co se stalo, na nic nečekáte a z těžkou hlavou ubytovnu okamžitě opouštíte.");
                AnimaceTextu("Na cestě ze schodů k východu přemýšlíte nad tím, proč jste zrovna Vy byli dalším cílem nějakého nájemného zabijáka...");
                AnimaceTextu("Jediné co, tak jste přece byli na tržišti u...");
                AnimaceTextu("Když dojdete k východu ubytovny, stráž Vás prudce zastaví. Oba strážní se na sebe podívají a synchronizovaně přikývnou.");
                AnimaceTextu("........");
                Tlacitko();
                PrimaRec("Strážný 1", "Projevujete se jako nebezpečí pro...město, teď půjdete s námi. Bez žádných otázek ani odmlouvání...");
                PrimaRec("Strážný 2", "Myslím, že makraběte Matador de Ángela budete jistě zajímat...");
                PrimaRec("Strážný 1", "Tak jdeme, pohyb!");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Jste opravdu zmateni, nerozumíte, kam Vás stráže vedou a už vůbec jaký pro to mají důvod.");
                AnimaceTextu("Jakékoliv zbytečné mluvy se ale zdržujete, víte, že by Vám to mohlo ublížit...");
                AnimaceTextu("..........");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Stráž Vás tiše vede nocí na místo, které jste už navštívili. Do malého hradu zmíněného markraběte. Nevíte však proč...");
                AnimaceTextu("Vejdete společne do hradu a jdete rovně, do hlavní síně. Zde markrabě společně generálem a čekají na konci místnosti.");
                AnimaceTextu("Stráž Vás před nimi pustí a neprodleně odchází pryč z hradu. V síni jste jen vy tři.");
                Tlacitko();
                PrimaRec("Markrabě Matador de Ángel", "Hmm, nečekal jsem, že budete vypadat...takhle.");
                PrimaRec("Markrabě Matador de Ángel", "Generále, vysvětlete naší návštěvě, jak se věci mají.");
                PrimaRec("Generál", "Určitě situaci nerozumíte, vysvětlím Vám ji tedy. Nájemný zabiják, který byl na tržišti, byl najatý na zabití kupce.");
                PrimaRec("Generál", "Jak jistě víte, Valoria je městem Valkýr. Říká se, že to ony jsou historickými zakladatelkami tohoto údivného města.");
                PrimaRec("Generál", "Díky tomu spusta místních věří na jejich zbožnou představitelku - Eirlys. Místními je uctívána už celá desetiletí...");
                PrimaRec("Generál", "Avšak...avšak náš markrabě Matador de Ángel má na Andělské legendy a zbožnost vůči nim jiný názor.");
                PrimaRec("Generál", "Tudíž od...od jeho nedávného nástupu se nám pravidla ve městě trochu změnila...");
                PrimaRec("Markrabě Matador de Ángel", "Dobře řečeno, Generále, dobře řečeno. Andělské síly - vymyšlené, nebo reálné opravdu nemám v lásce.");
                PrimaRec("Markrabě Matador de Ángel", "Dalo by se řící, že jsem jejich opakem. Hehehe!");
                AnimaceTextu("....");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Sledujete markraběte, oděného v černém rouchu s rudými přívěsky a ornamentováním na šatech. V jeho prstenu má Ďáblovu hlavu z rubínu.");
                AnimaceTextu("Za pasem si všímáte matně černé čepele.");
                AnimaceTextu("Jeho povaha odpovídá jeho oděvu, temná a nepředvídatelná. Váš instinkt Vám napovídá, že jste nejspíše v problémech...");
                AnimaceTextu(".....");
                Tlacitko();
                if (zemrelKupec)
                    PrimaRec("Generál", "Kupec byl velmi pobožný a na Eirlys věřil. Tuto víru projevoval v místním kostele a u svých zákazníků na tržnici.");
                else
                    PrimaRec("Generál", "Kupec je velmi pobožný a na Eirlys věří. Tuto víru projevuje v místním kostele a u svých zákazníků na tržnici.");
                PrimaRec("Markrabě Matador de Ángel", "...Slyšel jsem dokonce, že se ji pokoušel vyvolat...vyvolat! Ten člověk je blázen a zaslouží smrt.");
                PrimaRec("Generál", "Makrkra... Nám se to samozřejmě nelíbilo a tak jsme se situaci rozhodli řešit. Podobně tak u jiných věřících, samozřejmě.");
                PrimaRec("Generál", "Vy - jak všichni víme - jste očitým svědkem a také komplicem v trestném činu podílení se na Andělské víře.");
                PrimaRec("Markrabě Matador de Angel", "Proto jste na seznamu měli být další...");
                PrimaRec("Markrabě Matador de Ángel", "Vy jste se zabijákovi ubranil....HA! Teď ale shnijete v našem žaláři.");
                PrimaRec("Markrabě Matador de Ángel", "Stejně jako všichni, kdo jen pomyslí na Valkyrie!");
                PrimaRec("Generál", "Eh...slyšeli jste markraběte. Odcházíme...nepokoušejte se útočit, ani bránit se...");
                AnimaceTextu(".....");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Ve strachu a zmatení odcházíte z hradu do žaláře.");
                AnimaceTextu("Procházíte klidným nočním městem a vidíte, jak skupinka stráží loučemi zapaluje místní kostel. Jistě na rozkaz Markraběte.");
                AnimaceTextu("Zděsíte se, do čeho jste se to zapletli, ale pokračujete na cestě do vězení...");
                Tlacitko();

                void UspechPrepadeni()
                {
                    ForegroundColor = ConsoleColor.DarkBlue;
                    AnimaceTextu("Někdy v noci se trhnutím probudíte, slyšíte zvláštní zvuk.");
                    AnimaceTextu("Pár sekund Vám trvá, než rozeznáte odkud onen zvuk jde. Jde ze zámku Vašich pokojových dveří.");
                    AnimaceTextu("Víte, že je to zvuk tlumeného chrastění šperháku ve Vašem zámku, což se Vám ani trochu nelíbí.");
                    AnimaceTextu("Tiše popadnete svojí zbraň a stavíte se podél dveří...");
                    AnimaceTextu("......");
                    AnimaceTextu("Dveře se otevřou a koutkem oka zahlédnete stejně oděného muže, jako včera na tržnici. Víte, že je to nejspíě další najatý vrah.");
                    AnimaceTextu("Na nic nečekáte a zabijáka, který s Vámi rozhodně nepočítal, šikovnou ránou na místě usmrtíte.");
                    Tlacitko();
                    RabovaniMrtvol(new NajemnyZabijak(), "Usmrcený nájemný zabiják");
                    Clear();
                }
                void NeuspechPrepadeni()
                {
                    ForegroundColor = ConsoleColor.DarkBlue;
                    AnimaceTextu("Někdy v noci vás probudí zvláštně tlumený skřípot dveří...");
                    AnimaceTextu("Instinktivně si saháte pro Vaši zbraň u nočního stolku. Ve dveřích spatříte siluetu člověka.");
                    AnimaceTextu("Osoba nohou jemně zarazí zpět dveře a stojí ve Vašem pokoji. Všímáte si, že je stejně oděna jako nájemný zabiják na tržišti.");
                    Tlacitko();
                    PrimaRec("Neznámá osoba", "Vypadá to, že máte štěstí na neštěstí. Ve špatný čas, na špatném místě...");
                    Tlacitko();
                    ForegroundColor = ConsoleColor.DarkBlue;
                    AnimaceTextu("Osoba neprodleně vytáhla dýku a pokusila se na Vás zaútočit.");
                    AnimaceTextu("U sebe nemáte batoh, tudíž v tomto souboji nemáte Vaše použitelné předměty.");
                    Tlacitko();
                    var OdebraneP = VasePostava.inventarPostavy.ListInventare().FindAll(p => p is Pouzitelne);
                    VasePostava.inventarPostavy.ListInventare().RemoveAll(z => z is Pouzitelne);
                    Souboj(VasePostava.hracovaPostava, new NajemnyZabijak(), false, true);
                    VasePostava.inventarPostavy.ListInventare().AddRange(OdebraneP);
                    Clear();
                }
                void UtokNaMuze()
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Blue;
                    AnimaceTextu("Bez váhání útočíte na poteciálního vraha jednoho z kupců.");
                    AnimaceTextu("Když lidé v tržnici vidí, že běžíte s tasenou zbraní, vystrašeně ustupují a tvoří Vám tak cestu.");
                    AnimaceTextu("Onen zvláštní muž si Vás také všiml, společně s jeho komplicemi, kteří se potulují za ním. Je mu jasné, že asi nejste přátelští.");
                    AnimaceTextu("Připravuje se tedy na odražení Vašeho útoku...");
                    Tlacitko();
                    Souboj(VasePostava.hracovaPostava, new NajemnyZabijak(), false, true);
                    Clear();
                    ForegroundColor = ConsoleColor.Blue;
                    AnimaceTextu("Muže jste na místě zabili. Jeho komplici nejsou k vidění. Kouknete se kolem a vidíte spoustu vystrašených lidí.");
                    AnimaceTextu("Rozruch se donesl k městské stráži poměrně rychle, už spěchají k Vám s tasenými meči. Zastaví se na místě mtrvoly.");
                    AnimaceTextu("......");
                    Clear();
                    PrimaRec("Strážný 1", "Vy, pane, půjdete s námi.");
                    PrimaRec("Zachráněný kupec", "On mě zachránil, nebýt jeho tak už tu nejsem...");
                    PrimaRec("Strážný 2", "Zajímavé...děkujeme...eh...za záchranu kupce!");
                    PrimaRec("Strážný 1", "Stejně musíte jít s námi, Generál to bude chtít slyšet.");
                    PrimaRec("Strážný 1", "A vy ostatní, mějte se na pozoru. Teď rozchod!");
                    Tlacitko();
                    ForegroundColor = ConsoleColor.Blue;
                    AnimaceTextu("Víte, že jste jednali správně. Generálovi vše vysvětlíte a bude to v pořádku...že?");
                    Tlacitko();

                }
                void NeudelatNic()
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Blue;
                    AnimaceTextu("Rozhodnete se nic neudělat a k situaci pouze přihlížet.");
                    AnimaceTextu("Stalo se přesně to, co jste si mysleli že se stane.");
                    AnimaceTextu("Muž přistoupil ke kupci a podřížl ho. Neslyšně a precizně. Všichni tři se poté mistrovsky proplížili pryč z Vašeho dohledu.");
                    AnimaceTextu("Zvláštní Vám přišlo také to, jak dlouho trvalo, než si aktu někdo všiml. Mrtvý kupec pohotově seděl na své židli asi půl minuty.");
                    AnimaceTextu(".......");
                    AnimaceTextu("Poté začala kolemjdoucí žena nahodile křičet, čímž samozřejmě přivolala opodál stojící stráž.");
                    AnimaceTextu(".......");
                    Tlacitko();
                    PrimaRec("Strážný 1", "Vy, Vy, Vy a Vy půjdete s námi.");
                    PrimaRec("Strážný 2", "To...je...neštěstí!");
                    PrimaRec("Strážný 1", "Ničeho se nebojte, zeptáme se jen na pár otázek. Generál to bude jistě chtít vědět...");
                    Tlacitko();
                    ForegroundColor = ConsoleColor.Blue;
                    AnimaceTextu("Víte, že jste nevinní. Jdete tedy s klidem na zpověd se strážnými, bude to v pořádku...že?");
                    Tlacitko();
                    zemrelKupec = true;
                }
                void OsloveniMuze()
                {
                    ForegroundColor = ConsoleColor.Blue;
                    Clear();
                    AnimaceTextu("Podezřelého muže neprodleně oslovujete a kupce varujete.");
                    AnimaceTextu("Muž byl očividně vyrušen Vaším oslovením. Gestem na své společníky mávl a než se kupec stihl otočit, všichni tři byli pryč.");
                    AnimaceTextu("Na někoho, kdo vypadal jako nájemný zabiják byl muž velice obratný a precizní svými pohyby. Jeho kumpáni taktéž.");
                    AnimaceTextu("Ostatní lidé se ze zájmem ohlížejí, občas i zastaví. Kvůli obratnosti pachatelů toho ale moc neviděli.");
                    AnimaceTextu("Kupci vysvětlíte situaci a on Vám zdrženlivě poděkuje. To už ale vidíte blížící se stráž.");
                    AnimaceTextu("Přijde Vám zvláštní, že v tomhle městě funguje něco jako nájemní zabijáci, rozhodně to k městu nesedí...");
                    Tlacitko();
                    PrimaRec("Zachráněný kupec", "Strážní... byl tu zabiják, málem bylo po mně!");
                    PrimaRec("Střážný 1", "Je to tak? Tak proto takový rozruch. Jsme...jsme rádi, že se Vám nic nestalo, kupče.");
                    PrimaRec("Strážný 2", "To jo. Tedy, díky bohu...");
                    PrimaRec("Strážný 1", "A Vy jste situaci viděl, dokonce jí zabránil. Teď půjdete s námi jako svědek, Generála událost bude zajímat.");
                    PrimaRec("Strážný 2", "A... nebojte, zeptáme se jen na pár otázek.");
                    Tlacitko();
                    ForegroundColor = ConsoleColor.Blue;
                    AnimaceTextu("Víte, že jste zabránili situaci, která by jinak dopadla ošklivě. Odpovíte na pár otázek a vše bude v pořádku...že?");
                    Tlacitko();

                }
            }
            void Vezeni()
            {

                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Stráže Vás odvedou do vězení, máte celu společně s dalším vězněm.");
                AnimaceTextu("Cela je vlhká, vybavená spacími pytli, kýblem jakožto imitací toalety a zbytky jakéhosi jídla.");
                AnimaceTextu("Pečlivě Vám vezmou všechny věci a dají do hromadného skladu, společně s věcmi ostatních...");
                AnimaceTextu("Jediné co zbylo je krumpáč, který Vám dal po chvilce místní bachař.");
                AnimaceTextu("......");
                Tlacitko();
                VasePostava.inventarPostavy.PridejPredmet(Krumpáč);
                PrimaRec("Bachař", "Kdyby jste se nudil, prej je tady spousta železa a dalších kovů, hehe...");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Celá situace se odehrála hrozně rychle, potřebujete chvilku na přehrání si toho, co se vlastně stalo...");
                AnimaceTextu("Víte, že Markrabě je tak trochu blázen a kvůli jeho příkazu se ve městě začínají dít nelidské věci.");
                AnimaceTextu("Generál nevypadal, že by s Markrabětem souhlasil, avšak mu asi nic jiného nezbývalo, za předpokladu, že chce dále žít.");
                AnimaceTextu("A stráže pouze poslouchají rozkazy zkorumpovaného Generála - nic zvláštního.");
                AnimaceTextu("Také mluvili o kupci - o tom z tržnice. Prý se Eirlys pokoušel vyvolat, tomu nerozumíte už vůbec.");
                AnimaceTextu("Je nějaká šance, že by legenda o valkýriích mohla být pravdivá? Jediné co víte je, že Markrabě je výrazně proti ní...");
                AnimaceTextu("......");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Podíváte se na Vašeho spoluvězně. Je to muž středního věku v látkové tunice, jemuž světlé vlasy sahají až po ramena.");
                AnimaceTextu(".....");
                Tlacitko();
                PrimaRec("Spoluvězeň", "Zdravíčko-o...jak jste se sem dostali?");
                PrimaRec("Spoluvězeň", "Aha-a...taky Vás sem hodili bez dobrého důvodu, jak tak koukám.");
                PrimaRec("Spoluvězeň", "Ten-n kupec o kterém mluvíte, to byl nejspíš můj otec. Žije ještě? Řekněte, že jo!");
                if (zemrelKupec)
                    PrimaRec("Spoluvězeň", "Ach...měl jsem to čekat, že s jeho zbožností moc dlouho nepřežije...");
                else
                    PrimaRec("Spoluvězeň", "Tak-k to jsem rád, já jenom doufám, že to tak zůstane...");
                PrimaRec("Spoluvězeň", "Já-á jsem tady za... no poslali na mě nějakýho hajzla, tak jsem ho poslal tam nahoru. Zbytek si domyslíte...");
                AnimaceTextu(".......");
                Tlacitko();
                ForegroundColor = ConsoleColor.Blue;
                AnimaceTextu("Ve vězení jste den a půl. Podmínky nejsou nějak extra přívětivé, ale víte, že by to mohlo být daleko horší...");
                AnimaceTextu("Podávají se tři studená jídla denně. Také máte hodinové odpolední vycházky, kde se seznamujete s ostatními vězni.");
                AnimaceTextu("Vězni, kteří jsou ve vězení už delší dobu začínají občasně vymýšlet plány, jak se dostat pryč.");
                AnimaceTextu("Z doslechu víte, že žádný z nich ještě nikdy nefungoval, ale teď se plánuje něco většího...něco co Vám dává naději.");
                Tlacitko();
                PrimaRec("Vězeň na vycházce", "...večer, když kontrolujou cely, tak přece chodí jen jeden. To je naše nejlepší šance.");
                PrimaRec("Jiný vězeň na vycházce", "Peles vezme krumpáč a přitlačí ho k mřížím, pak má smůlu...");
                PrimaRec("Uvězněný chemik na vycházce", "Hloupost.");
                PrimaRec("Uvězněný chemik na vycházce", "Víte co dělají s nedojedenou večeří? Snědí ji sami, nejlépe před námi, aby nás to mrzelo.");
                PrimaRec("Vězeň na vycházce", "A co má jako bejt?");
                PrimaRec("Uvězněný chemik na vycházce", "Dáme tam večerní hlídce tohle. Bude dělat co si zamaneme. Včera jsem to našel v levé botě...");
                AnimaceTextu("Chemik vytáhne velice malou, ale ostře vypadající lahvičku s neznámou tekutinou.");
                PrimaRec("Uvězněný chemik na vycházce", "Odemkne nám všem cely, potom sklad s věcmi a revoluce může začít...");
                PrimaRec("Uvězněný chemik na vycházce", "Musíme ale jednat rychle. A nebuďte sobci - vše co pašujete rozdejte spravedlivě mezi všechny.");
                PrimaRec("Uvězněný chemik na vycházce", "Počítám s Vámi večer, až si strážný dojde pro zbytky z večeře. Platí?");
                PrimaRec("Ostatní", "Platí...");
                AnimaceTextu("......");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("I podle Vás zní plán nadějně. Možná proto, že nemáte jinou možnost...");
                AnimaceTextu("Všímáte si, že se začíná pomalu stmívat. Do večeře je ale ještě poměrně daleko.");
                AnimaceTextu("Od Vašeho spoluvězně se k Vám přídělem dostali tři lektvary zdraví, jeden lektvar many a lahvička s jedem...");
                for (int i = 0; i < 3; i++)
                    VasePostava.inventarPostavy.PridejPredmet(Lektvar_Zdraví);
                VasePostava.inventarPostavy.PridejPredmet(Jed);
                VasePostava.inventarPostavy.PridejPredmet(Lektvar_Many);
                AnimaceTextu("Poctivě si pašované zboží uložíte a čekáte na večeři...");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Vše jde podle plánu, strážný Vám právě přinesl večeři.");
                AnimaceTextu("Vědomě v dřevěné misce se svým spoluvězněm necháte zbytky jídla. Váš spoluvězeň ze skumavky do jídla nakape chemikovu tekutinu.");
                AnimaceTextu("Strážný přichází ke dveřím věznice a bere si od vás s úšklebkem zbytek jídla. Začne ho okamžitě jíst, u čehož se uchechtává.");
                AnimaceTextu("......");
                Tlacitko();
                PrimaRec("Strážný", "No dobrý to máte, ponravo, hehee!");
                PrimaRec("Strážný", "...ale co to...no teda!...");
                PrimaRec("Váš spoluvězeň", "Odemkni dvířka, šup! Náš sklad věcí taky.");
                PrimaRec("Strážný", "Ale jistě šéfe, hned to bude!");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Strážný okamžitě odemyká cely, jednu po druhé. Nezapomene samozřejmě ani na sklad s vašimi věcmi.");
                AnimaceTextu("Vezmete si všechno, co Vám patří a připravujete se na to, co bude následovat...");
                AnimaceTextu("Rozdělili jste se do taktických dvojic, s Vašim spoluvězněm jste nyní bojové duo.");
                AnimaceTextu("Po tom co projdete dlouhou chodbou si všímáte trojice popíjejících stráží s odznakem Generála. Nezbývá, než si cestu probít.");
                Tlacitko();
                Strazny s, s1, s2;
                s = new Strazny();
                s1 = new Strazny();
                s2 = new Strazny();
                Past PrekvapeniStraznych = new(5, VasePostava.hracovaPostava.vObratnost, "obratnost", VasePostava.hracovaPostava.vJmeno);
                bool prekvapil = PrekvapeniStraznych.Uspech();
                ForegroundColor = ConsoleColor.DarkBlue;
                if (prekvapil)
                    Prekvapeni(new List<Stvoreni> { s, s1, s2 });
                if (prekvapil)
                    AnimaceTextu("Strážní si Vás všimli až na poslední chvíli, překvapili jste je. Některé staty se jim proto v tomto souboji sníží.");
                else
                    AnimaceTextu("Strážní Vás z chodby slyšeli přicházet. Nepřekvapili jste je tedy...");
                AnimaceTextu("Bez váhání se Vy a Váš spoluvězeň připravujete k souboji...");
                Tlacitko();
                var spoluvezen = new Spoluvezen();
                VasePostava.spolecnik = spoluvezen;
                Souboj(VasePostava.hracovaPostava, s, true, true);
                Souboj(VasePostava.hracovaPostava, s1, true, false);
                Souboj(VasePostava.hracovaPostava, s2, false, false);
                Clear();
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Strážné jste úspěšně pobili, souboj byl lítý...");
                if (VasePostava.spolecnik != spoluvezen)
                    AnimaceTextu("Vypadá to, že spoluvězeň už není Vaším společníkem. Vaše bitevní duo tedy končí.");
                AnimaceTextu("Pokračujete v postupu vpřed a sleduete chaos okolo Vás. Vypadá to, že revoluce se prozatím daří...");
                AnimaceTextu("Noční prostředí jste schopni využít ve Váš prospěch. Problémem je, že se o útěku dozvěděl Generál, vidíte totiž členy jeho gardy.");
                AnimaceTextu("Vězňů je opravdu hodně, na čísla vyhráváte. Nevíte však, jak tohle celé má skončit, nad tím nikdo nepřemýšlel...");
                AnimaceTextu("Z myšlenek Vás vytrhne dvojice strážných, která si ve svitu loučí všimla neobvyklého pohybu.");
                AnimaceTextu("Nezbvývá, než se pustit do souboje...");
                Tlacitko();
                Souboj(VasePostava.hracovaPostava, new Strazny(), true, true);
                Souboj(VasePostava.hracovaPostava, new Strazny(), false, false);
                Clear();
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Souboj jste opět úspěšně zvládli. Cítíte se však vyčerpaní...");
                Tlacitko();
                Past vycerpani = new Past(4, VasePostava.hracovaPostava.vSila, "sílu", VasePostava.hracovaPostava.vJmeno);
                if (!vycerpani.Uspech())
                    Vycerpan();
                else
                    Nevycerpan();
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Revoluce se dostala až do městské části. Někteří obyvatelé nahlíží z oken a dveří, jiní spokojeně spí...");
                AnimaceTextu("Strážných postupně ubývá, vězni měli v hromadném skladě uzamčených pár pěkných kousků, jsou tedy dobře vybaveni.");
                AnimaceTextu("Postupem hlouběji do města si všimnete, že kovárna a laboratoř jsou otevřené. Nebo lépe řečeno - probity Vašimi spoluvězni.");
                AnimaceTextu("Nyní se necítíte být ve velkém nebezpečí a pár lektvarů navíc, nebo nabroušení čepele by se možná hodilo...");
                AnimaceTextu(".....");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkBlue;
                if (VasePostava.spolecnik == spoluvezen)
                {
                    _spolOdesel = true;
                    PrimaRec("Spoluvězeň", "Zkusím-m...zkusím je obejít a trochu pocuhat zadní linii, hehe. Hodně štěstí v souboji, parťáku!");
                    ForegroundColor = ConsoleColor.DarkBlue;
                    AnimaceTextu("Spoluvězeň Vás opouští a vydává se na záškodnickou misi. Věříte, že uspěje.");
                    VasePostava.spolecnik = null;
                    Tlacitko();

                }
                Menu menu = new Menu(otaznik, new List<string> { "Jít do kovárny a laboratoře", "Raději tam nechodit a pokračovat v cestě" }, ConsoleColor.Red);
                int volba = menu.NavratIndexu();
                if (volba == 0)
                    JdeTam();
                else
                    NejdeTam();
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Pokračujete v pochodu. Vypadá to, že směrem k hradu, kde sídlí markrabě...");
                AnimaceTextu("Většina lidí už je vzhůru, ačkoliv jediné světlo ve městě je oheň z loučí a zapálených náboženských budov - obojí díky strážným.");
                AnimaceTextu("Pokračujete dál a dál, Váš cíl se přibližuje. Hrad je asi tři sta stop od Vás...");
                AnimaceTextu("Najednou se hradu otevře brána a z ní vyjde hradní legie - tedy to, co z ní zbylo - s generálem v čele.");
                AnimaceTextu("Před Vámi stojí dobrých sto mužů, připravených k boji. Postupuje vpřed.");
                AnimaceTextu("Nervozita mezi vězni se zvýšila, avšak nejsou připraveni na to, se vzdát. Budete bojovat do konce.");
                AnimaceTextu("....");
                AnimaceTextu("Zbytek legie se k Vám přiblížil na šedesát stop. Zastavili na příkaz generála, který začíná mluvit...");
                Tlacitko();
                PrimaRec("Generál", "Na příkaz můj a markraběte Matador de Ángela okamžitě přestaňte!");
                PrimaRec("Generál", "Ničíte naše nádherné město vaší bláhovostí a snahou o útěk. Útěk z vězení ve kterém jste kvůli vašim otřesným činům!");
                PrimaRec("Generál", "Složte zbraně a nikomu se nic nestane! Popravíme jen ty, kvůli kterým vzpoura nastala...");
                AnimaceTextu("....");
                PrimaRec("Jeden z vězňů", "Lháři! Korupce vás dostihla! Markrabě je blázen a vy všichni stejně tak! Nikdy se nevzdáme, žeano přátelé?!");
                PrimaRec("Ostatní vězni", "Nikdy!!");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Na noční obloze jasně svítí měsíc - jediný zdroj světla mimo louče strážných a hořících kostelů.");
                AnimaceTextu("Víte, že ani jedna strana se nehodlá vzdát bez boje. I přesto, že jste jen vězni, víte, že to vy bojujete za čest.");
                AnimaceTextu("Připravujete se tedy na poslední souboj.");
                AnimaceTextu("....");
                Tlacitko();
                void Nevycerpan()
                {
                    ForegroundColor = ConsoleColor.DarkBlue;
                    AnimaceTextu("Vyčerpání jste odolali, pokračujete tedy ve Vašem úkolu...");
                    Tlacitko();
                    ForegroundColor = ConsoleColor.DarkBlue;
                }
                void JdeTam()
                {
                    Clear();
                    ForegroundColor = ConsoleColor.DarkBlue;
                    AnimaceTextu("Rozhodnete se tedy na chvíli revoluci opustit a jít do kovárny a laboratoře. Místo je jen Vaše...");
                    Tlacitko();
                    TvrobaPredmetu.Kovarna();
                    Clear();
                    ForegroundColor = ConsoleColor.DarkBlue;
                    AnimaceTextu("Nyní opouštíte kovárnu a přecházíte do laboratoře.");
                    Tlacitko();
                    TvrobaPredmetu.Laborator();
                    Clear();
                    ForegroundColor = ConsoleColor.DarkBlue;
                    AnimaceTextu("Všechno máte hotové, připravujete se tedy k odchodu...");
                    Tlacitko();
                    PrimaRec("Strážný 1", "No vida, koho to tady máme. Dnes v noci nepřežiješ.");
                    PrimaRec("Strážný 2", "Vzpouří se a ještě krade. Skončíš pod zemí!");
                    AnimaceTextu("......");
                    Tlacitko();
                    Souboj(VasePostava.hracovaPostava, new Strazny(), true, true);
                    Souboj(VasePostava.hracovaPostava, new Strazny(), false, false);
                    Clear();
                    ForegroundColor = ConsoleColor.DarkBlue;
                    AnimaceTextu("Bitvu máte za sebou. Na nic nečekáte a okamžitě místo opouštíte.");
                    Tlacitko();

                }
                void NejdeTam()
                {
                    Clear();
                    ForegroundColor = ConsoleColor.DarkBlue;
                    AnimaceTextu("Rozhodnete se nic neriskovat a pokračovat v pochodu....");
                    Tlacitko();

                }
                void Vycerpan()
                {
                    ForegroundColor = ConsoleColor.Red;
                    AnimaceTextu("Vyčerpání se k Vám bohužel dostává. Zdraví se Vám tak snižuje o 2.");                    
                    VasePostava.hracovaPostava.vZdravi -= 2;
                    VasePostava.hracovaPostava.RekonfiguraceHPaMany();
                    AnimaceTextu($"Nyní máte {VasePostava.hracovaPostava.vZdravi} zdraví.");
                    Tlacitko();
                }
                void Prekvapeni(List<Stvoreni> seznamPrekvapenychNepratel)
                {
                    foreach (Stvoreni s in seznamPrekvapenychNepratel)
                    {
                        s.sObrannaHodnota -= 1;
                        s.sObratnost -= 1;
                        s.sUtocnaHodnota -= 1;
                    }
                }
            }
            void PosledniBitva()
            {
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Celá legie se zrychleným krokem přibližuje...");
                AnimaceTextu("Generál si s sebou vzal jednoho strážného a zaměřil se na Vás...nevíte proč.");
                AnimaceTextu("Bojovat se samotným generálem a jeho strážným je Vám trochu proti srsti, avšak není útěku. Bojuj nebo zemři.");
                Tlacitko();
                if (_spolOdesel)
                {

                    Souboj(VasePostava.hracovaPostava, new GeneralValorie(), false, true);
                    Recepty.PridejReceptDoSeznamu(TvrobaPredmetu.RSmaragdové_Kopí);
                    Clear();
                    ForegroundColor = ConsoleColor.DarkBlue;
                    AnimaceTextu("Váš spoluvězeň se po Vašem náročném souboji s generálem objevil a strážného, který u generála byl, bezlítostně zabil ze zálohy.");
                    AnimaceTextu("Za pomoc jste rádi, po souboji s generálem jste byli vyčerpaní...");
                    Tlacitko();
                }
                else
                {
                    Souboj(VasePostava.hracovaPostava, new GeneralValorie(), true, true);
                    Recepty.PridejReceptDoSeznamu(TvrobaPredmetu.RSmaragdové_Kopí);
                    Souboj(VasePostava.hracovaPostava, new Strazny(), false, true);
                    Clear();
                }
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Po poražení generála cítíte naději, že město odteď bude lepší. Ten, kdo rozšiřoval korupci teď leží na zemi mrtev.");
                AnimaceTextu(".....");
                AnimaceTextu("Rozhlédnete se po bojišti a zjišťujete, že Vaši spolubojovníci také utrpěli nemalé ztráty.");
                AnimaceTextu("Avšak takové ztráty, které jsou potřebné pro vítězství. Vypadá to, že chaos pomalu mizí.");
                AnimaceTextu("Přijde Vám neuvěřitelné, co všechno jste dokázali za jednu noc se svými společníky.");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Lidé pomalu vychází z jejich domů, když krveprolití končí...");
                AnimaceTextu("Ačkoliv je teprve nad ránem a stále tma, vypadá to, že všichni obyvatelé města Valoria jsou vzhůru...");
                AnimaceTextu("Někteří se dokonce začali podílet na hašení hořících kostelů a vynášení trosek ze zbytků budov. Jiní zase vystrašeně stojí opodál.");
                AnimaceTextu("Někteří vypadají šťastně - o korupci moc dobře věděli. Jiní zmateně a smutně - pravda jim doteď unikala.");
                AnimaceTextu("Morálka začíná být lepší, postupně lidem se svými společníky vysvětlujete co se stalo a co je potřeba udělat.");
                AnimaceTextu(".....");
                AnimaceTextu("Najednou si všimente postavy v černém rouchu, která se nelidsky rychle přibližuje směrem z hradu. Markrabě...");
                AnimaceTextu("Se společníky se připravíte na to, ho zabít. Jste zvědaví, proč Markrabě běží samotný proti stovkám občanů, kteří ho nenávidí...");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkBlue;
                AnimaceTextu("Snažíte se na Makraběte z dálky křičet. Vystoupíte z davu a naléháte, aby se zastavil a pikal za jeho ohavné činy proti občanům.");
                AnimaceTextu("Makrabě se jen několik stop před Vámi zastaví. Ukáže na Vás svou vyzáblou rukou a Vy cítíte nepříjemnou auru, která Vás obklopuje.");
                AnimaceTextu("Setmí se Vám před očima a jediné co slyšíte jsou vzdálená volání Vašich společníků z vězení a občanů Valorie...");
                Tlacitko();
                Okradeni();
                ForegroundColor = ConsoleColor.DarkRed;
                AnimaceTextu("Když se z transu probudíte, zjišťujete, že se nacházíte úplně na jiném místě než předtím.");
                AnimaceTextu("Nejlépe byste místo popsali jako rudé pláně s lehce nafialovělou oblohou. Jediné co poznáváte je zvláštní kombinace barev.");
                AnimaceTextu("V dálce vidíte toho, díku komu jste se tu ocitli - Markraběte.");
                AnimaceTextu("Běží k Vám, opět nelidskou rychlostí. Zastavuje...");
                AnimaceTextu("....");
                AnimaceTextu("Najednou slyšíte hlasitou a rozlehlou ránu doprovázenou bílým světlem. Světlo jde zezhrora.");
                AnimaceTextu("Nevěříte vlastním očím - stojí, nebo spíše létá, před Vámi...Anděl.");
                Tlacitko();
                PrimaRec("Markrabě", "Eirlys, co tady děláš?! Naše dohoda zněla jasně, nezahrávej si se mnou!");
                PrimaRec("Eirlys", "Součástí oné dohody nikdy nebylo vraždění nevinných lidí, Matadore.", ConsoleColor.Yellow);
                PrimaRec("Markrabě", "To nikdy nikdo neřekl! Lidé na Vás zapomenou, výměnou za to, že Vám poskytnu místo k živobytí...");
                PrimaRec("Eirlys", "Za to jsme ti vděčné. Opravdu ano. Avšak zabíjet nevinné lidi kvůli tvým osobním domněnkám? To ti nedovolíme.", ConsoleColor.Yellow);
                PrimaRec("Markrabě", "Nepovídej Eirlys, nepovídej. Nic a nikdo mi nebude stát v cestě. Dokončím, co jsem začal...");
                PrimaRec("Markrabě", "Zabiju všechny kdo se postavili proti očistě města. Když jsme u toho - mohl bych začít tady u našeho hosta!");
                PrimaRec("Eirlys", "Ty...", ConsoleColor.Yellow);
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkRed;
                AnimaceTextu("Je Vám jasné, že jde o víc než jste si původně mysleli.");
                AnimaceTextu("Eirlys z legend existuje, vypadá opravdu majestátně. Proč ale uzavírá dohody s takovým... šílencem?");
                AnimaceTextu("Nevypadá jako někdo, kdo by musel dělat kompromisy... už vůbec ne s ním. Třeba je v Markraběti více, než se zdá...");
                AnimaceTextu("....");
                AnimaceTextu("Z myšlenek Vás vytrhl stín za Vašimi zády - Markrabě. Zblízka vypadá ještě hůře, než jste si mysleli.");
                AnimaceTextu("Eirlys polétává nad Vámi, a připravuje se - stejně jako Vy - na nepředvídatelné chování Markraběte...");
                Tlacitko();
                VasePostava.spolecnik = new Eirlys();
                Souboj(VasePostava.hracovaPostava, new MarkrabeMatador(), false, true);
                Recepty.PridejReceptDoSeznamu(TvrobaPredmetu.RProkletáČepel);
                Recepty.PridejReceptDoSeznamu(TvrobaPredmetu.RLichovoRoucho);
                Recepty.PridejReceptDoSeznamu(TvrobaPredmetu.RLektvar_Vzkříšení);
                Clear();
                ForegroundColor = ConsoleColor.DarkRed;
                if (!(VasePostava.spolecnik is Eirlys))
                {
                    AnimaceTextu("Eirlys v nelítostném souboji zemřela, ale Markrabě byl poražen...");
                    AnimaceTextu("Nemá Vás kdo dostat zpět do světa, který znáte. S pocitem zadostiučinění umíráte v této obdivuhodné lokaci...");
                    Tlacitko();
                    KonecHryMimoSouboj();
                    return;

                }
                VasePostava.spolecnik = null;
                AnimaceTextu("Souboj byl úmorný, ale s pomocí samotné představitelky bájných Valkýr jste vyhráli...");
                AnimaceTextu("......");
                Tlacitko();
                PrimaRec("Eirlys", "Děkuji za pomoc, poutníku, tvá síla je obdivuhodná...", ConsoleColor.Yellow);
                PrimaRec("Eirlys", "Tohle místo?... Jedná se zmaterializovaný výplod mysli Markraběte - nebo spíše jeho podoby Liche. Karmínová Pole.", ConsoleColor.Yellow);
                PrimaRec("Eirlys", "Tady vraždil všechny nevinné, ty, které v nás věřili - v naše společenství nebeských válečnic.", ConsoleColor.Yellow);
                PrimaRec("Eirlys", "Také tu nabýval síly, jedná se místo jeho duševního opdočinku, znám tuto krajinu...", ConsoleColor.Yellow);
                PrimaRec("Eirlys", "Vedli jsme zde naše nekonečné bitvy, které neměli vítěze. Chtěly jsme dosáhnout klidu, proto jsme udělaly kompromis.", ConsoleColor.Yellow);
                PrimaRec("Eirlys", "Teď ale zašel moc daleko, jeho smrt byla nevyhnutelná. A ta nastala z velké části díky tobě, poutníku...", ConsoleColor.Yellow);
                PrimaRec("Eirlys", "Prokázal jsi Valkýrám a občanům města Valorie obrovskou službu. Takovou, za kterou jsem povinna tě štědře odměnit.", ConsoleColor.Yellow);
                PrimaRec("Eirlys", "Vyber si Andělský um, já tě ho naučím. Poté tě pošlu zpět do města, poutníku. Nechť tě světlo provází...", ConsoleColor.Yellow);
                Tlacitko();
                VyberSSchopnosti(EirlysAbility, ConsoleColor.Yellow);
                Clear();
                ForegroundColor = ConsoleColor.Blue;
                AnimaceTextu("Eirys zajistila, že jste se bezpečně vrátili do města.");
                AnimaceTextu("Ve městě je mnoho mrtvých, ať už Vašich spoluvězňů, nebo strážných. Obě strany utrpěly ztráty...");
                AnimaceTextu("Mezi padlými strážnými se všímáte také Gustava s Helenou, strážné, kteří Vás pustili do města.");
                AnimaceTextu("Avšak jste si jisti, že jakmile Valkýry převezmou nad městem kontrolu, vše se dá dopořádku. Oběti padly za dobrou věc.");
                AnimaceTextu("Zvědavcům vysvětlíte, co se vlastně stalo. Někteří nejistě přikyvují, jiní Vás mají za blázna.");
                AnimaceTextu("Víte, že na tom nezáleží, brzy uvidí pravdu na vlastní oči...");
                AnimaceTextu("Rozhodnete se město prozatím opustit, víte, že jste pomohli. Třeba se s tímto skvostem Vaše cesty ještě někdy zkříží.");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkCyan;
                WriteLine();
                WriteLine("Dokončili jste lokaci Město Valoria. Gratulujeme!");
                WriteLine();
                WriteLine("Vaše poutě tím však zdaleka nekončí...");
                Tlacitko();
                DokonciLokaci(Město_Valoria);
                DokonciFinalneLokaci(VytvoreneLokace.Město_Valoria);
                OdemkniLokace(Osobní_Domeček);
                OdemkniLokace(Skřetí_Panství);
                OdemkniLokace(Průsmyk_Hrdlořezů);
                //Přidat unlocky lokací po Valorii.
            }
        }//tady končí valoria gameplay
    }
}