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
using System.Linq;
namespace DnD_Hra
{
    class GameplayLokaci_3
    {
        static string dt = ":";
        static string otaznik = @"
                                   ?
                           <Zvolte možnost>";
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
        
        //-----
        public static void Prepadeni(List<Stvoreni> nepratele, int minHod, string textUspech = null, string textNeuspech = null)
        {
            
            Clear();
            Past prepadeni = new Past(minHod, VasePostava.hracovaPostava.vObratnost, "obratnost", VasePostava.hracovaPostava.vJmeno);
            if (!prepadeni.Uspech())
                Prepaden(nepratele);
            else
            {
                ForegroundColor = ConsoleColor.Green;
                if (textUspech == null)
                    WriteLine("Nic se nestalo, vše je v naprostém pořádku...");
                else
                    WriteLine(textUspech);
                Tlacitko();
            }
                      
            void Prepaden(List<Stvoreni> nepratele)
            {
                
                ForegroundColor = ConsoleColor.Red;
                if (textNeuspech == null)
                    WriteLine("Byli jste přepadeni...");
                else
                    WriteLine(textNeuspech);
                Tlacitko();
                foreach (Stvoreni s in nepratele)
                {
                    if (s == nepratele[0] && nepratele.Count != 1)
                        Souboj(VasePostava.hracovaPostava, s, true, true);
                    else if (s == nepratele[^1] && nepratele.Count != 1)
                        Souboj(VasePostava.hracovaPostava, s, false, false);
                    else if (s == nepratele[^1] && nepratele.Count == 1)
                        Souboj(VasePostava.hracovaPostava, s, false, true);
                    else
                        Souboj(VasePostava.hracovaPostava, s, true, false);
                }
                Clear();
                ForegroundColor = ConsoleColor.DarkYellow;
                WriteLine("Nepřátele jste úspěšně odrazili, mějte se na pozoru...");
                Tlacitko();            
            }
        }
        public static bool JeBandita()
        {
            List<Zbrane> zbraneBanditu = new List<Zbrane> {Meč, Dýka, Luk, Srp_Vetešnice, Štastlivcovo_Žihadlo};
            List<Zbroje> zbrojeBanditu = new List<Zbroje> {Kožená_Zbroj, Tunika_Vetešnice};
            if (zbraneBanditu.Contains(VasePostava.zbranPostavy) && zbrojeBanditu.Contains(VasePostava.zbrojPostavy))
                return true;
            else return false;
        }
        public static bool JeEnemyBandita(Stvoreni nepritel)
        {
            List<Zbrane> zbraneBanditu = new List<Zbrane> { Meč, Dýka, Luk, Štastlivcovo_Žihadlo, Srp_Vetešnice };
            List<Zbroje> zbrojeBanditu = new List<Zbroje> { Kožená_Zbroj, Tunika_Vetešnice };
            if (zbraneBanditu.Contains(nepritel.zbranStvoreni) && zbrojeBanditu.Contains(nepritel.zbrojStvoreni))
                return true;
            else return false;
        }
        static Inventar uschovna = new Inventar();
        static int pocetKolBoje = 0;
        //------
        public static void PrusmykHrdlorezuGameplay()
        {
            pocetKolBoje = 0;
            Prichod();
            Vzestup();
            MaskovaciHra();
            PostupKCentru();
            //pridej okradeni
            void Prichod()
            {
                Okradeni();
                Clear();
                ForegroundColor = ConsoleColor.DarkYellow;
                AnimaceTextu("Procházíte šerou, zůženou cestou.");
                AnimaceTextu("Okolo Vás matně vidíte na sobě naskládané balvany, které se tyčí do v šeru nedohledných výšin.");
                AnimaceTextu("Přes některé skaliny, které Vám nad hlavou tvoří veliké brány, jsou přeházené provazy a postavené prkenné mosty.");
                AnimaceTextu("Místo je tiché, kombinace jehličnatých stromů a přírodních kamenných staveb na sobě nedává znát známky života.");
                AnimaceTextu("Po pozorném rozhlédnutí okolo sebe vidíte, že z kamenů a stromů je tvořená dlouhá alej, nebo možná průsmyk...");
                AnimaceTextu("....");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkYellow;
                AnimaceTextu("Z okraje průsmyku se před Vámi vynoří silueta postavy, má ruce nad hlavou a pomalým krokem se přibližuje...");
                PrimaRec("Neznámá postava", "Nejsem nepřítel, vyslechněte si mě však! Je to důležité!");
                PrimaRec("Neznámá postava", "Tenhle průsmyk není pro cizince přívětivý! Přijdete o všechno co u sebe máte, včetně Vaší hlavy!");
                PrimaRec("Neznámá postava", "Jmenuji se Balmund a jsem bývalým vlastníkem tohoto průsmyku...");
                PrimaRec("Balmund", "Býval můj, to ano, ale koupil ho ode mě jeden podivín a ze svojí četou se sem nastěhoval!");
                PrimaRec("Balmund", "Nabízel mnohem víc, než bych za unikátní komplex jako je tenhle mohl kdykoliv chtít, takže jsem neodmítl...");
                PrimaRec("Balmund", "Ale jak říkám, on a jeho rota se tu okamžitě zabydleli a co hůř, střeží to tu Hrdelním právem!");
                PrimaRec("Balmund", "Co to znamená? - No pokud nemáte povolení a budete se v průsmyku potulovat, Vaše hrdlo patří vlastníkovi!");
                PrimaRec("Balmund", "Samozřejme Vám průchod zakazovat nemohu, ale je to pouze na Vaše nebezpečí, mnozí se už nevrátili!");
                PrimaRec("Balmund", "A poslyšte...když se rozhodnou Vás nezabít, často jen kradou. A rozbíjejí co mohou...");
                PrimaRec("Balmund", "Tím myslím - to co u sebe máte a je křehké, udělají vše proto aby to vzali nebo zničili.");
                PrimaRec("Balmund", "Já ovšem povolení mám, průsmykem procházet mohu. Nabízím Vám tedy dočasnou úschovnu předmětů...");
                PrimaRec("Balmund", "Však víte, nechci se vnucovat, ale mohlo by se Vám hodit ochránit Vaše předměty...");
                AnimaceTextu("....");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkYellow;
                AnimaceTextu("Poutník Balmund na Vás působí dost zmateně, avšak chápete, co se Vám snaží sdělit.");
                AnimaceTextu("Přemýšlíte, jestli má smysl věřit senilnímu poutníkovi s Vašimi předměty...");
                Tlacitko();
                UschovnaPoutnika(VasePostava.inventarPostavy);
                Clear();
                ForegroundColor = ConsoleColor.DarkYellow;
                if (!uschovna.ListInventare().Any())
                    AnimaceTextu("Poutníkovi neveříte a tak jste si všechny předměty nechali u sebe.");
                else
                    AnimaceTextu("U poutníka jste si uložili předměty...");
                AnimaceTextu("Rozhodnete se i přes Balmundovo varování pokračovat dále v cestě do průsmyku.");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkYellow;
                AnimaceTextu("Šero se pomalu mění v noc a Vy pokračujete úzkou cestou průsmyku lemovanou balvany a stromy.");
                AnimaceTextu("Dáváte si pozor, občas při vzhlédnutí do vrchní části komplexu spatříte nevýrazný odraz světel - pochodně.");
                AnimaceTextu("Je Vám jasné, že to nemůže být nikdo jiný než členové skupiny, která průsmyk nyní obývá.");
                Tlacitko();
                Okradeni();
                Prepadeni(new List<Stvoreni> { new Bandita(), new Bandita() }, 5, "Nikdo si Vás nevšiml, procházíte dále průsmykem...", "Všimla si Vás dvojice banditů na podvečerní hlídce. Okamžitě uplatňují hrdelní právo");
                Clear();
                ForegroundColor = ConsoleColor.DarkYellow;
                void UschovnaPoutnika(Inventar i)
                {
                   
                    Menu predmety = new Menu("Chcete uschovat u poutníka Vaše předměty?", new List<string> {"Ano", "Ne"}, ConsoleColor.Yellow);
                    int v = predmety.NavratIndexu();
                    if (v == 0)
                    {
                        while (true)
                        {
                            var FiltrPouzitelnych = i.ListInventare().Where(p => p is Pouzitelne).GroupBy(p => p.ID).Select(p => p.First()).ToList();
                            var NazvyInv = FiltrPouzitelnych.Select(p => $"({p.pocetPredmetu(i)}) " + p.nazevPredmetu).ToList();
                            NazvyInv.Add("Odejít");
                            Menu pr = new Menu("Vyberte křekhý předmět, který chcete u poutníka uschovat:", NazvyInv, ConsoleColor.DarkCyan);
                            int index = pr.NavratIndexu();
                            if (index == NazvyInv.Count - 1)
                                break;
                            Predmety VP = FiltrPouzitelnych[index];
                            uschovna.PridejPredmet(VP);
                            i.OdeberPredmet(VP);
                            Clear();
                            ForegroundColor = ConsoleColor.DarkCyan;
                            WriteLine();
                            WriteLine($"Uložili jste si k poutníkovi předmět {VP.nazevPredmetu}...");
                            Tlacitko();
                        }
                    }
                    else
                        if (potvrzeni())
                        return;
                    else UschovnaPoutnika(i);

                    bool potvrzeni()
                    {
                        Menu m = new Menu("Opravdu chcete odejít? Jedná se vlastně o jedinečnou příležitost...", new List<string> { "Ano, odejít", "Ne, neodcházet" }, ConsoleColor.Red);
                        int v = m.NavratIndexu();
                        if (v == 0)
                            return true;
                        else
                            return false;
                    }
                }
            }
            void Vzestup()
            {
                AnimaceTextu("Vidíte, že průsmyk se začíná zvedat. Cesta dál je mnohem strmější než předtím a stromy začínají mizet - teď jsou tu jen skály.");
                Tlacitko();
                Past vzestup = new Past(5, VasePostava.hracovaPostava.vSila, "sílu", VasePostava.hracovaPostava.vJmeno);
                if(vzestup.Uspech())
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine();
                    VasePostava.hracovaPostava.vSila += 1;
                    WriteLine($"Podařilo se Vám strmou cestu jednoduše překonat - síla se Vám zvýšila o 1. Nyní je Vaše síla {VasePostava.hracovaPostava.vSila}");
                    Tlacitko();
                }
                else
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine();
                    VasePostava.hracovaPostava.vSila -= 1;
                    WriteLine($"Strmá cesta pro Vás představovala složitou překážku - síla se Vám snížila o 1. Nyní je Vaše síla {VasePostava.hracovaPostava.vSila}");
                    Tlacitko();
                }
                ForegroundColor = ConsoleColor.DarkYellow;
                AnimaceTextu("Ať už s menšími nebo většími potížemi jste se dostali na vrch strmé kamenité cesty!");
                AnimaceTextu("Vrch průsmyku na Vás působí opravdu zvláštně, vypadá to, že tu mnozí bydlí...");
                AnimaceTextu("Ačkoliv je vrch průsmyku skalnatý, nevypadá, že by bylo složité se v něm pohybovat.");
                AnimaceTextu("Skládá se z jeskynních komplexů, mezery jsou pokryty dřevěnými mosty a vyvýšené body jsou přístupny pomocí svazů provazů.");
                AnimaceTextu("Krom toho jsou tu z dostupných surovin postaveny jednoduché přístřešky - ať už jako sklad surovin, nebo pro obytné účely.");
                AnimaceTextu("A to je jen to, co vidíte v nočním prostředí, za dne by jste si určitě všimli mnohých detailů, které Vám teď unikají...");
                AnimaceTextu(".....");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkYellow;
                AnimaceTextu("Po krátkém zamyšlení usuzujete, že putovat v noci skrz takovou oblast možná není nejlepší nápad...");
                AnimaceTextu("Nejlepší řešení pro Vás tedy je najít si dostatečně daleko bezpečný přístřešek a přenocovat tam.");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkYellow;
                AnimaceTextu("Máte štěstí, opodál se nachází na první pohled nevyužitý přístřešek, tvořený z šikovně poskládaných balvanů a jehličí...");
                AnimaceTextu("Když zjistíte, že opravdu bezpečný je, rozhodnete se zde přenocovat - lepší nápad koneckonců nemáte.");
                AnimaceTextu("....");
                Tlacitko();
                Past nocniPrepadeni = new Past(5, VasePostava.hracovaPostava.vStesti, "štěstí", VasePostava.hracovaPostava.vJmeno);
                if(nocniPrepadeni.Uspech())
                {
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine();
                    WriteLine("Vyspali jste se kupodivu dobře, i přes skalnatou podestýlku...");
                    Tlacitko();
                }
                else
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine();
                    WriteLine("Chvilku po tom, co jste usnuli, slyšíte rychle se přibližující hlasy a mžouravě si ve světle pochodní prohlížíte siluety dvou postav.");
                    Tlacitko();
                    PrimaRec("Bandita 1", "Myslel jsem, že to tady celý vyklidili, že by se nějakej od nás zas ožral?...");
                    PrimaRec("Bandita 2", "Já zas myslel, že tam má bejt sušený maso. No to je jedno, kouknem se.");
                    Tlacitko();
                    ForegroundColor = ConsoleColor.DarkYellow;
                    AnimaceTextu("Rychle vstáváte a doufáte, že hlídkující bandity stihnete zabít dříve, než přivolají další...");
                    AnimaceTextu("V tomto souboji nemáte nic, kromě toho, co máte právě vybaveni, nechcete ztrácet čas.");
                    Tlacitko();
                    var TempInv = VasePostava.inventarPostavy;
                    var hracuvEInv = new Inventar();
                    VasePostava.inventarPostavy = hracuvEInv;
                    Souboj(VasePostava.hracovaPostava, new Bandita(), true, false);
                    Souboj(VasePostava.hracovaPostava, new Bandita(), false, false);
                    VasePostava.inventarPostavy = TempInv;
                    if (hracuvEInv.ListInventare().Any())
                        VasePostava.inventarPostavy.ListInventare().AddRange(hracuvEInv.ListInventare());
                    Clear();
                    ForegroundColor = ConsoleColor.DarkYellow;
                    AnimaceTextu("Bandity jste stihli zabít dříve, než vydali hlásku, ale zbytek noci jste nezavřeli oči...");
                    Tlacitko();

                }
                ForegroundColor = ConsoleColor.Yellow;
                AnimaceTextu("Ráno se probouzíte a opatrně vycházíte se svými věcmi z Vašeho úkrytu.");
                AnimaceTextu("Jakmile vyjdete, okamžitě slyšíte vzdálené hlasy.");
                AnimaceTextu("Vypadá to, že obyvatelé průsmyku jsou nad ránem plně aktivní.");
                AnimaceTextu("Přikrčíte se za nejbližší kámen a pozorně sledujete - doufáte, že zjistíte co jsou zač a co tu vlastně dělají.");
                AnimaceTextu("....");
                AnimaceTextu("Nevidíte nic neobyklého, někteří v průsmyku obchodují, jiní šplhají po kamenech, další zase opékají ranní buřty.");
                AnimaceTextu("Skupina si dobře rozumí. Někteří se baví, jiní dělají svou práci...");
                AnimaceTextu("Netušíte však co jsou zač, ani jestli jejich bytí v průsmyku pochází z nějakého učelu.");
                Tlacitko();
                ForegroundColor = ConsoleColor.Yellow;
                AnimaceTextu("Nejste si jisti jak pokračovat dále, rozhlížíte se okolo sebe a vymýšlíte nejstragetičtější přístup k tomuto místu.");
                AnimaceTextu("Opodál, za mohutným jehličnatým stromem, vidíte ležet banditu - nejspíš odpočívá po náročné noci.");
                AnimaceTextu("Je zázrak že si Vás nevšiml, je asi dvacet stop od Vás...");
                AnimaceTextu("Přijdete blíž a zjišťujete, že tvrdě spí - opravdu tvrdě.");
                AnimaceTextu("Můžete banditu zabít, nebo ho nechat být a odplížit se dále.");
                AnimaceTextu("Kdybyste ho zabili, můžete si však vzít jeho věci a pokusit se splynout s okolím, stát se jedním z nich...");
                Tlacitko();

            }
            void MaskovaciHra()
            {
                OznameniOPrestrojení();
                Menu zabit = new Menu(otaznik, new List<string> { "Zabít dřímajícího banditu", "Raději se odplížit pryč" }, ConsoleColor.Blue);
                int v = zabit.NavratIndexu();
                if(v == 0)
                {
                    Past vrazda = new Past(5, VasePostava.hracovaPostava.vInteligence, "inteligenci", VasePostava.hracovaPostava.vJmeno);
                    if(vrazda.Uspech())
                    {
                        Clear();
                        ForegroundColor = ConsoleColor.Green;
                        WriteLine();
                        WriteLine("Banditu jste šikovným seknutím podřízli, ani nepípnul. Dobrá práce.");
                        Tlacitko();
                        RabovaniMrtvol(new Bandita(), "Dříve dřímající bandita");
                    }
                    else
                    {
                        Clear();
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine();
                        WriteLine("Bandita se díky hluku, který jste způsobili trhnutím vzbudil. Ačkoliv je malátný a je to na něm vidět, útočí.");
                        Tlacitko();
                        Bandita drimacek = new Bandita();
                        drimacek.sZdravi /= 2;
                        drimacek.sObrannaHodnota -= 1;
                        drimacek.sUtocnaHodnota -= 1;
                        drimacek.sObratnost -= 2;
                        Souboj(VasePostava.hracovaPostava, drimacek, false, true, "Dříve dřímající bandita");
                    }
                    if(!JeBandita())
                    {

                        Clear();
                        ForegroundColor = ConsoleColor.Yellow;
                        AnimaceTextu("Přemýšlíte nad tím, jestli se přestrojit za banditu hned, je pro to poměrně dobrá příležitost...");
                        AnimaceTextu("Přestrojit se do dříve zmíněné kombinace zbroje a zbraně se samozřejmě můžete vždy, když bude možnost.");
                        Tlacitko();
                        Menu prestrojeniNaMiste = new Menu(otaznik, new List<string> { "Přestrojit se za banditu (MEČ + KOŽENÁ ZBROJ)", "Ponechat mé věci - nestojím o přestrojení" }, ConsoleColor.Blue);
                        int vyber = prestrojeniNaMiste.NavratIndexu();
                        if(vyber == 0)
                        {
                            VasePostava.zbranPostavy = Meč;
                            VasePostava.inventarPostavy.PridejPredmet(Meč);
                            VasePostava.hracovaPostava.RekonfiguraceUH();
                            VasePostava.zbrojPostavy = Kožená_Zbroj;
                            VasePostava.inventarPostavy.PridejPredmet(Kožená_Zbroj);
                            VasePostava.hracovaPostava.RekonfiguraceOH();
                            Clear();
                            ForegroundColor = ConsoleColor.Green;
                            WriteLine();
                            WriteLine("Vaše zbraň je nyní meč a zbroj je kožená zbroj. Hotový bandita!");
                            Tlacitko();
                        }
                        else
                        {
                            Clear();
                            ForegroundColor = ConsoleColor.Yellow;
                            WriteLine();
                            WriteLine("Rozhodli jste se ponechat Vaše stávající věci...");
                            Tlacitko();
                        }
                    }
                   
                }
                else
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Yellow;
                    AnimaceTextu("Rozhodli jste se odplížit pryč...");
                    AnimaceTextu("Nebyla tak prolita žádná krev. Pokud se kdykoliv budete chtít za banditu přestrojit, můžete tak udělat později.");
                    AnimaceTextu("Ve Vašem vedlejším menu si vybavíte předměty, které jsou specifické pro bandity a budete maskováni.");
                    Tlacitko();
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine();
                    WriteLine("Z Vašeho plížení si odnášíte cenné zkušenosti. Obratnost se Vám zvyšuje o 1.");
                    WriteLine();
                    WriteLine($"Vaše obratnost je nyní {VasePostava.hracovaPostava.vObratnost}!");
                    Tlacitko();
                }
                if (!JeBandita())
                {
                    ForegroundColor = ConsoleColor.Yellow;
                    AnimaceTextu("Vypadá to, že nejste banditou. Nyní se otevře vedlejší menu pro případ, že chcete provést nějaké změny...");
                    Tlacitko();
                    Menu.VedlejsiMenuPostavy();
                    Clear();
                }
                ForegroundColor = ConsoleColor.Yellow;
                AnimaceTextu("Jelikož je den, víte, že nemá moc smysl se pokoušet dále schovávat. Prostředí průsmyku je aktivní v plném proudu...");
                AnimaceTextu("Jdete tedy schovívavě vstříc místu, kde pozorujete největší rozruch...");
                AnimaceTextu("....");
                Tlacitko();
                ForegroundColor = ConsoleColor.Yellow;
                if (!JeBandita())
                    Prepadeni(new List<Stvoreni> { new Bandita(), new Bandita() }, 7, "Kolemjdoucí bandité se na Vás podezíravě podívali, avšak hbitě pokračují v kroku..."
                        , "Kolemjdoucí bandité si Vás všimli, rozeznali že nejste členem průsmyku a tak okamžitě útočí...");
                else
                {
                    PrimaRec("Kolemjdoucí bandité", "Dobrý ráno pane, snad jsme se dobře vyspali!");
                    PrimaRec("Kolemjdoucí bandité", "Ty seš tu určitě novej co, tak tim pádem vítej.");
                    AnimaceTextu("....");
                    Tlacitko();
                }
                ForegroundColor = ConsoleColor.Yellow;
                AnimaceTextu("Beze strachu pokračujete směrem k centru, nejste si jisti co očekávat...");
                AnimaceTextu("....");
                Tlacitko();
                Okradeni();
                ForegroundColor = ConsoleColor.Yellow;
                AnimaceTextu("Jste skoro v centru dění, avšak po strmé odbočce doleva narážíte na malý kamenný obchod, ve kterém pracují tři hrdlořezové.");
                AnimaceTextu("Jedna prodavačka, která obchod vede a dva pomocnící, kteří zboží skládají na prodejní pult, nebo odnášejí do skladu.");
                AnimaceTextu("Něco takového si přece nelze nechat ujít, rozhodně Vás zajímá, co za poklady by mohlo být ve vetešnictví uprostřed ničeho!");
                Tlacitko();
                if (JeBandita())
                {
                    PrimaRec("Vetešnice", "Zdravíčko kolego! Vás neznám, ale to je v pořádku, poslední dobou tu máme spoustu nových hlav...");
                    PrimaRec("Vetešnice", "Podívejte se, co tu dnes prodáváme, určitě budete spokojeni!");
                    Tlacitko();
                    Inventar VetesniceShop = new Inventar();
                    VetesniceShop.PridejPredmet(Vlčí_Talisman);
                    for(int i = 0; i<4;i++)
                    VetesniceShop.PridejPredmet(Látka);
                    for (int i = 0; i < 4; i++)
                    VetesniceShop.PridejPredmet(Zvláštní_Čtyřlístek);
                    for (int i = 0; i < 4; i++)
                        VetesniceShop.PridejPredmet(Železný_Ingot);
                    VetesniceShop.PridejPredmet(Srp_Vetešnice);
                    VetesniceShop.PridejPredmet(Tunika_Vetešnice);
                    Obchod.Obchodovani(VasePostava.inventarPostavy, VetesniceShop, "Nejlepším vetešnictví, které Kamenný Průsmyk viděl", 0.4);
                    Recepty.PridejReceptDoSeznamu(TvrobaPredmetu.RTunika_Vetešnice);
                    Recepty.PridejReceptDoSeznamu(TvrobaPredmetu.RSrp_Vetešnice);
                }
                else
                {
                    PrimaRec("Vetešnice", "Pánové, vypadá to, že je tu někdo, kdo má o hlavu víc než by měl...");
                    PrimaRec("Pomocník hrdlořez", "Cože?... Hele, ten nás určitě chce vykrást!");
                    Tlacitko();
                    Souboj(VasePostava.hracovaPostava, new Vetesnice(), true, true);
                    Recepty.PridejReceptDoSeznamu(TvrobaPredmetu.RTunika_Vetešnice);
                    Recepty.PridejReceptDoSeznamu(TvrobaPredmetu.RSrp_Vetešnice);
                    Souboj(VasePostava.hracovaPostava, new Bandita(), true, true);
                    Souboj(VasePostava.hracovaPostava, new Bandita(), false, false);
                }                             
                void OznameniOPrestrojení()
                {
                    ForegroundColor = ConsoleColor.DarkCyan;
                    AnimaceTextu("Odteď se můžete kdykoliv stát členy skupiny hrdlořezů.");
                    AnimaceTextu("Jejich ikonická zbroj je KOŽENÁ a ikonické HLAVNÍ zbraně jsou MEČ, LUK, nebo DÝKA.");
                    AnimaceTextu("Třeba je takových zbraní a zbrojí více a nějaké se Vám podaří sehnat, kdo ví...");
                    AnimaceTextu("Když budete přímo v kontaktu s banditou a budete přestrojeni, budete maskováni.");                   
                    AnimaceTextu("Pokud však přestrojeni nebudete, hrdlořezové se budou chovat nepřátelsky.");
                    AnimaceTextu("Přestrojit se můžete kdykoliv ve vedlejším menu - to tak, že zvolíte optimální zbraň a zbroj.");
                    AnimaceTextu("Volba je tedy na Vás...");
                    AnimaceTextu("....");
                    Tlacitko();
                }

            }
            void PostupKCentru()
            {
                ForegroundColor = ConsoleColor.Yellow;
                AnimaceTextu("Váš postup k centru jde poměrně rychle, je brzy dopoledne a Vy jste skoro v cíli...");
                AnimaceTextu("Napadá Vás, že toto místo určitě má svého vůdce - někoho, kdo spolek představuje.");
                AnimaceTextu("Také Vás napadá, že kdyby jste vůdce zabili, třeba by ostatní z průsmyku odešli.");
                AnimaceTextu("Tiše pozorujete zvyky obyvatel průsmyku a chováním Vám hrdlořezové připomínají spíše klan, než-li vražednou skupinu.");
                Tlacitko();
                if (!JeBandita())
                    Prepadeni(new List<Stvoreni> { new Bandita() }, 6, "V zamyšlení jste zapomněli dávat pozor. Kolemjdoucí bandita si Vás naštěstí nevšiml.", "Všiml si Vás kolemjdoucí bandita, který bez rozmislu útočí...");
                Clear();
                ForegroundColor = ConsoleColor.Yellow;
                AnimaceTextu("Máte tedy v plánu počkat do noci a pak se dostat k veliteli tohoto klanu - skoncovat to s ním jednou pro vždy.");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkYellow;
                AnimaceTextu("Celý průsmyk začíná červenat při západu slunce.");
                AnimaceTextu("Vyhybáte se komu to jen jde, nechcete se jakkoliv dostat do dalších problémů.");
                AnimaceTextu("Pozorně sledujete hrdlořezy od rána do večera a čekáte na vhodnou příležitost...");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkYellow;
                AnimaceTextu("Úplně se setmělo a Vy jste připraveni se pustit do akce. Samozřejmě nechcete být chyceni - to i za předpokladu že jste maskováni.");
                AnimaceTextu("Tiše našlapujete a vydáváte se vpřed...");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkYellow;
                if (JeBandita())
                {
                    AnimaceTextu("Bez potíží se plížíte až k centru průsmyku, nikdo si Vás ve Vašem přestrojení nevšiml...");
                    AnimaceTextu("Po Vaší pravici vidíte na osamoceném ostrůvku postavený látkový stan, který stráží dva hrdlořezové.");
                    AnimaceTextu("Vypadá to na stan velitele - zkusíte se tam proplížit a svou práci dokončit.");
                    Tlacitko();
                    Past p = new Past(6, VasePostava.hracovaPostava.vObratnost, "obratnost", VasePostava.hracovaPostava.vJmeno);
                    ForegroundColor = ConsoleColor.DarkYellow;
                    if(p.Uspech())
                    {
                        Clear();
                        AnimaceTextu("K Vašemu velkému překvapení Vůdce banditů sedí ve svém stanu na jeho loži - jakoby Vás očekával.");
                        Tlacitko();
                        PrimaRec("Vůdce banditů", "Tihle dva idioti by neuhlídali ani buřt nad ohněm, uhni!");
                        Tlacitko();
                        ForegroundColor = ConsoleColor.DarkYellow;
                        AnimaceTextu("Vidíte, jak vůdce vytahuje svou zvlášntě vypadající dýku a stráž stanu nekompromisně podřízne.");
                        AnimaceTextu("Poté ji zandá za opasek, otočí se k Vám a začne promlouvat...");
                        Tlacitko();
                        PrimaRec("Vůdce banditů", "Slyšel jsem tě už od lesa, ale nebyl důvod se pobuřovat, spoléhal jsem na tyle blbečky.");
                        PrimaRec("Vůdce banditů", "Jak ale vidim, jsou k ničemu a ty jsi mně přišel zabít. Jinak samozřejmě - máš dobrej převlek.");
                        PrimaRec("Vůdce banditů", "Ať je to teda fér, rozdáme si to jako chlapi - hezky jeden proti jednomu, co říkáš?...");
                        Tlacitko();
                        Souboj(VasePostava.hracovaPostava, new VudceBanditu(), false, true);
                        Recepty.PridejReceptDoSeznamu(TvrobaPredmetu.RŠťastlivcovo_Žihadlo);
                        Clear();
                        ForegroundColor = ConsoleColor.DarkYellow;
                        AnimaceTextu("Vůdce padl, na nic nečekáte a mizíte z průsmyku, než si kdokoliv něčeho všimne...");
                        Tlacitko();
                    }
                    else
                    {
                        Clear();
                        ForegroundColor = ConsoleColor.DarkYellow;
                        AnimaceTextu("Stráž stanu Vás viděla přicházet, svého vůdce budou klidně chránit vlastním životem.");
                        AnimaceTextu("Okamžitě jeden ze strážných vůdce budí a útočí na Vás ve třech. Zatím jen ve třech.");
                        Tlacitko();
                        Souboj(VasePostava.hracovaPostava, new Bandita(), true, true);
                        Souboj(VasePostava.hracovaPostava, new Bandita(), true, false);
                        Souboj(VasePostava.hracovaPostava, new VudceBanditu(), false, false);
                        Recepty.PridejReceptDoSeznamu(TvrobaPredmetu.RŠťastlivcovo_Žihadlo);
                        ForegroundColor = ConsoleColor.DarkYellow;
                        AnimaceTextu("Vůdce padl, jeho stráž také. Celý průsmyk je ale na nohou, je vzhůru.");
                        AnimaceTextu("Svíráte se jen při pohledu na desítky hrdlořezů kteří běží k Vám. Víte, že musíte rychle utéct...");
                        Tlacitko();

                        while (true)
                        {
                            pocetKolBoje++;
                            Past unik = new Past(5, VasePostava.hracovaPostava.vObratnost, "obratnost", VasePostava.hracovaPostava.vJmeno);
                            if (unik.Uspech() || pocetKolBoje >=6)
                            {
                                Clear();
                                ForegroundColor = ConsoleColor.DarkYellow;
                                WriteLine();
                                WriteLine("Unikli jste před hrdlořezy!");
                                Tlacitko();
                                break;

                            }
                            else
                            {
                                Clear();
                                ForegroundColor = ConsoleColor.Red;
                                WriteLine();
                                WriteLine("Uniknout se Vám nepodařilo. Třeba po zabití tohoto hrdlořeze získáte potřebné okno pro únik...");
                                Tlacitko();
                                Bandita running = new Bandita();
                                running.seznamPredmetu.RemoveAll(p => p is Predmety);
                                running.pocetZlata = 0;
                                running.sUtocnaHodnota++;
                                running.nazevStvoreni = "Běsnící hrdlořez";
                                Souboj(VasePostava.hracovaPostava, running, false, true);
                            }
                        }
                    }
                }
                else
                {
                    AnimaceTextu("Nadále se odmítáte stát banditou či hrdlořezem, máte tedy svou čest.");
                    AnimaceTextu("Je Vám jasné, že plížit se budete muset naprosto mistrovsky - když Vás někdo uvidí, vyvolá to konflikt.");
                    Tlacitko();
                    Prepadeni(new List<Stvoreni> { new Bandita(), new Bandita() }, 6, "Dvojice banditů prošla nebezpečně blízko Vás, avšak si ničeho nevšimli.",
                        "Dvojice banditů šla okolo Vás a jeden koutkem oka zahlédl neočekávaný pohyb - zaútočili.");
                    ForegroundColor = ConsoleColor.DarkYellow;
                    AnimaceTextu("Nacházíte se v hlavní obytné části průsmyku - tady všichni spí.");
                    AnimaceTextu("Vidíte veliký látkový stan, který stojí na osamoceném skalnatém ostrově. Před ním v pozoru stojí dva hrdlořezové.");
                    AnimaceTextu("Jste si jisti, že tohle je stan velitele, je to teď, nebo nikdy...");
                    Tlacitko();
                    Souboj(VasePostava.hracovaPostava, new Bandita(), true, true);
                    Souboj(VasePostava.hracovaPostava, new Bandita(), true, false);
                    Souboj(VasePostava.hracovaPostava, new VudceBanditu(), false, false);
                    Recepty.PridejReceptDoSeznamu(TvrobaPredmetu.RŠťastlivcovo_Žihadlo);
                    ForegroundColor = ConsoleColor.DarkYellow;
                    AnimaceTextu("Vůdce padl, jeho stráž také. Celý průsmyk je ale na nohou, je vzhůru.");
                    AnimaceTextu("Svíráte se jen při pohledu na desítky hrdlořezů kteří běží k Vám. Víte, že musíte rychle utéct...");
                    Tlacitko();

                    while (true)
                    {
                        pocetKolBoje++;
                        Past unik = new Past(5, VasePostava.hracovaPostava.vObratnost, "obratnost", VasePostava.hracovaPostava.vJmeno);
                        if (unik.Uspech()||pocetKolBoje>=6)
                        {
                            Clear();
                            ForegroundColor = ConsoleColor.DarkYellow;
                            WriteLine();
                            WriteLine("Unikli jste před hrdlořezy!");
                            Tlacitko();
                            break;

                        }
                        else
                        {
                            Clear();
                            ForegroundColor = ConsoleColor.Red;
                            WriteLine();
                            WriteLine("Uniknout se Vám nepodařilo. Třeba po zabití tohoto hrdlořeze získáte potřebné okno pro únik...");
                            Tlacitko();
                            Bandita running = new Bandita();
                            running.seznamPredmetu.RemoveAll(p => p is Predmety);
                            running.pocetZlata = 0;
                            running.sUtocnaHodnota++;
                            running.nazevStvoreni = "Běsnící hrdlořez";
                            Souboj(VasePostava.hracovaPostava, running, false, true);
                        }
                    }


                }
                Clear();
                ForegroundColor = ConsoleColor.DarkYellow;
                AnimaceTextu("Vůdce bezprostředně padl a Vy jste se bezpečně eskortovali...");
                AnimaceTextu("Nedá Vám to a obyvatele průsmyku ještě dalších pár dní pozorujete...");
                Tlacitko();
                AnimaceTextu(".....");
                AnimaceTextu(".....");
                AnimaceTextu(".....");
                ForegroundColor = ConsoleColor.Yellow;
                AnimaceTextu("Tři dny na to vidíte, že se všichni hrdlořezové pohybují směrem pryč. Vůdce byl opravdu jejich základem, který je držel pohromadě.");
                AnimaceTextu("Průsmyk je dobytý a tím pádem náleží jeho původnímu majiteli - Balmundovi.");
                Tlacitko();
                ForegroundColor = ConsoleColor.Yellow;
                AnimaceTextu("Balmund... bylo by dobré mu to říci.");
                if (uschovna.ListInventare().Any())
                    AnimaceTextu("A také si od něj vzít zpět své předměty, na to nelze zapomenout...");
                Tlacitko();
                PrimaRec("Balmund", "No teda, dobrá práce! Jsem moc rád, že průsmyk je zase můj, začínal mi chybět.");
                PrimaRec("Balmund", "A taky - jsem rád že jsi je vyhnal, ten jejich vůdce byl fakt číslo.");
                PrimaRec("Balmund", "Za pomoc ti dám poctivejch 50 zlatejch.");
                if (uschovna.ListInventare().Any())
                    PrimaRec("Balmund", "A tady máš vše co jsi si u mě uložil! Děkuju...!");
                Tlacitko();
                Inventar.PridejZlato(50, VasePostava.inventarPostavy);
                VasePostava.inventarPostavy.ListInventare().AddRange(uschovna.ListInventare());
                ForegroundColor = ConsoleColor.Yellow;
                AnimaceTextu("Jste rádi, že jste poutníkovi pomohli, odměna Vás neminula.");
                AnimaceTextu("50 zlatých a vše co Vám patřilo - to není špatné...");
                Tlacitko();
                Okradeni();
                DokonciLokaci(Průsmyk_Hrdlořezů);
                DokonciFinalneLokaci(Průsmyk_Hrdlořezů);
                ForegroundColor = ConsoleColor.DarkCyan;
                WriteLine();
                WriteLine("Úspěšně jste dokončili lokaci Průsmyk Hrdlořezů. Gratulujeme k úspěchu!");
                Tlacitko();
                OdemkniLokace(Všudypřítomná_Knihovna);
                OdemkniLokace(Nadčasový_Les);
            }
        }
        //------
        public static bool Hadanka(string otazka, string odpoved, int pocetPokusus, ConsoleColor barvaOtazky = ConsoleColor.Blue)
        {
            WriteLine();
            ForegroundColor = ConsoleColor.Magenta;
            WriteLine("Hádanka:");
            ForegroundColor = barvaOtazky;
            int curpokus = 0;
            Clear();
            WriteLine();
            WriteLine($"{otazka}");
            WriteLine();
            WriteLine();          
            ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < WindowWidth; i++)
                Write(">");
            ForegroundColor = barvaOtazky;            
            WriteLine();
            WriteLine();
            WriteLine($"Počet pokusů je: {pocetPokusus}");
            WriteLine();
            WriteLine("Zadejte prosím Vaši odpověď:");
            CursorVisible = true;
            while(curpokus <pocetPokusus)
            {

                curpokus++;
                WriteLine();
                string op = ReadLine().ToLower();
                WriteLine();
                if (op != odpoved)
                {
                    WriteLine($"Toto bohužel nebyla správná odpověď, zbývající počet pokusů je {pocetPokusus - curpokus}.");
                }
                else
                {
                    CursorVisible = false;
                    WriteLine($"{op} je správná odpověď!");
                    Tlacitko();
                    return true;
                }
            }
            CursorVisible = false;
            WriteLine();
            WriteLine("Hádanku se Vám bohužel nepodařilo uhodnout...");
            Tlacitko();
            return false;
        }
        public static void StatovaKniha(int KolikPridava)
        {
            int randomVyber = new Random().Next(1, 7);            
            string nazev = PrirazeniNAzvu(randomVyber);
            Clear();
            ForegroundColor = ConsoleColor.Cyan;
            VylepseniStatu(randomVyber);
            WriteLine("Našli jste knihu, která obsahuje cenné informace...");
            WriteLine();
            WriteLine($"Stat {nazev} byl zvýšen o {KolikPridava}!");
            Tlacitko();
            void VylepseniStatu(int rc)
            {
                if (rc == 1)
                {
                     VasePostava.hracovaPostava.zakladniUtocnaHodnota += KolikPridava;
                     VasePostava.hracovaPostava.RekonfiguraceUH();
                     VasePostava.hracovaPostava.RekonfiguraceAltUH();
                }
                else if (rc == 2)
                {
                     VasePostava.hracovaPostava.zakladniObrannaHodnota += KolikPridava;
                     VasePostava.hracovaPostava.RekonfiguraceOH();
                }
                else if(rc == 3)
                     VasePostava.hracovaPostava.vSila += KolikPridava;
                else if(rc == 4)
                     VasePostava.hracovaPostava.vObratnost += KolikPridava;
                else if(rc == 5)
                     VasePostava.hracovaPostava.vInteligence += KolikPridava;
                else if(rc == 6)
                     VasePostava.hracovaPostava.vStesti += KolikPridava;
                else throw new Exception("číslo mimo rozsah v přiřazení");
            }
            string PrirazeniNAzvu(int rc)
            {
                if (rc == 1)
                    return "Základní útočná hodnota";
                if (rc == 2)
                    return "Základní obranná hodnota";
                if (rc == 3)
                    return "Síla";
                if (rc == 4)
                    return "Obratnost";
                if (rc == 5)
                    return "Inteligence";
                if (rc == 6)
                    return "Štěstí";
                else throw new Exception("číslo mimo rozsah v přiřazení");
            }
        }
        private static int uhodnutoHadanek = 0;
            //pamatovak ready
        public static void VsudypritomnaKnihovnaGameplay()
        {
            uhodnutoHadanek = 0;
            PrichodAroom1();
            Room2Pokracovani();
            Room3Pokracovani();
            void PrichodAroom1()
            {
                Clear();
                ForegroundColor = ConsoleColor.Cyan;
                AnimaceTextu("Je brzy ráno a Vy pokračujete ve Vaší cestě...");
                AnimaceTextu("Ranní rosa je viditelná na trávě, která Vám sléhá pod nohama.");
                AnimaceTextu("Cestou Vás doprovází jmené mrholení, které jste se už naučili ignorovat.");
                AnimaceTextu("Za tlustou mlhou v dáli vidíte plot - černý, dlouhý plot, vypadá to, jakoby ohraničoval hřbitov.");
                AnimaceTextu("Rozhodnete se přistoupit blíže a zjistit, co by uprostřed otevřené krajiny dělal hřbitov...");
                Tlacitko();
                ForegroundColor = ConsoleColor.Cyan;
                AnimaceTextu("Čím blíže jdete, tím méně to vypadá jako hřbitov a více jako areál s rozhlehlou budovou uvnitř.");
                AnimaceTextu("Dostanete se až k mohutné bráně areálu, před kterou stojí dva strážní.");
                Tlacitko();
                PrimaRec("Strážný 1", "Halt, cizinče. Do knihovny má zákaz každý, kdo není dvorní čaroděj větší državy a drží povolení!");
                PrimaRec("Strážný 2", "Vy nevypadáte ani jako dvorní čaroděj, ani jako nikdo kdo drží povole...");
                PrimaRec("Strážný 2", "Tak moment, já Vás znám...");
                PrimaRec("Strážný 2", "Vy jste byl ve Valorii, to kvůli Vám nás vyhnali a teď musíme trčet tady v dešti!");
                PrimaRec("Strážný 1", "Za to zaplatíte...");
                Tlacitko();
                ForegroundColor = ConsoleColor.Cyan;
                AnimaceTextu("Víte, že nadutým strážným nemá smysl cokoli vysvětlovat. Už dávno tasili své zbraně.");
                AnimaceTextu("Připravujete se k boji...");
                Tlacitko();
                Souboj(VasePostava.hracovaPostava, new Strazny(), true, true);
                Souboj(VasePostava.hracovaPostava, new Strazny(), false, false);
                Clear();
                ForegroundColor = ConsoleColor.Cyan;
                AnimaceTextu("S bojem proti strážným už máte nějaké zkušenost, tato šarvátka pro Vás nepředstavovala problém.");
                AnimaceTextu("Teď to ovšem znamená, že bránu nikdo nehlídá.");
                AnimaceTextu("Za opaskem strážného najdete na provázku starobyle vypadající klíč - samozřejmě pasuje do zámku.");
                Tlacitko();
                ForegroundColor = ConsoleColor.Cyan;
                AnimaceTextu("Ocitnete se v areálu, jehož zem je pokryta tlustou vrstvou mlhy.");
                AnimaceTextu("Kromě mlhy poznáváte také vysokou trávu, která je přítomna všude, kromě vyšlapané cesty, kde už je slehlá.");
                AnimaceTextu("Cesta vede do velké, ale nevýrazné budovy stojící uprostřed areálu. Rozhodnete se ji následovat.");
                AnimaceTextu("Dveře do budovy jsou pootevřeny, vchod není uzamčen. Rozhodnete se budovu prozkoumat...");
                AnimaceTextu("....");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkCyan;
                AnimaceTextu("Vevnitř je to starobylé a neudržované. Místo je propletené pavučinami a také je velmi tmavé.");
                AnimaceTextu("Všude jsou regály, ve kterých jsou knihy, místo je tedy opravdu knihovnou, jak říkali strážní.");
                AnimaceTextu("Procházíte potemnělými místnostmi, nenaházíte však nic zajímavého...");
                AnimaceTextu("...........");
                AnimaceTextu("Přijdete však do jedné místnosti, kde za stolem sedí shrbený muž, vypadá to, že píše knihu.");
                AnimaceTextu("Rozhednete se ho oslovit - třeba je to jeden z dvorních čarodějů, o kterých strážní mluvili...");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkCyan;
                AnimaceTextu("Muž prudce pozvedne hlavu. Všímáte si výrazných modrých očí, které celou místnost ozařují.");
                AnimaceTextu("Po lepším prohlédnutí zjišťujete, že tento muž už dlouho není naživu.");
                AnimaceTextu("Páchne jako dva týdný staré maso a jeho žebra odpadávají zpoza róby, kterou má muž na sobě.");
                AnimaceTextu("Skoro mechanicky se zvedne a jde směrem k Vám. Rozhodně nevypadá přátelsky - nebo že přátele rozeznává.");
                AnimaceTextu("Muž tasí zrezivělou dýku a cestou si něco mumlá, třeba s ním přecijen bude řeč!");
                AnimaceTextu("......");
                Tlacitko();
                Okradeni();
                Souboj(VasePostava.hracovaPostava, new NemrtvyKnihovnik("'V tomto světě našem, kolik typů skřetů rozeznáváme, včetně jejich Krále?'", "4", 2, ConsoleColor.DarkGreen), false, true);
                Clear();
                ForegroundColor = ConsoleColor.DarkCyan;
                AnimaceTextu("Zajmavé, toto místo Vám přišlo zvláštní, ale toto jste nečekali...");
                AnimaceTextu("......");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkCyan;
                AnimaceTextu("Přicházíte před uzavřené dveře, vedle nich je v proskleném rámu vystaven papír. Je na něm otázka...");
                Tlacitko();
                if(Hadanka("'Poutník a téže majitel Průsmyku Hrdlořezů. Jak jeho jméno zní?'", "balmund", 3))
                {
                    uhodnutoHadanek++;
                    ForegroundColor = ConsoleColor.DarkCyan;
                    AnimaceTextu("Dveře se pomalu otevírají, vedou do tajné místnosti...");
                    AnimaceTextu("Projdete ji skrz na skrz, přeci tu musí být něco zajímavého.");
                    Tlacitko();
                    Loot(NahodnyVyberKategoriePredmetu(), 4);
                    Loot(NahodnyVyberKategoriePredmetu(), 2);
                    StatovaKniha(1);
                    ForegroundColor = ConsoleColor.DarkCyan;
                    AnimaceTextu("Takové bohatství nelze ponechat bez strážného...");
                    AnimaceTextu("Skrz zeď prolétává étericky vypadající stín, našeptává Vám další hádanku...");
                    Tlacitko();
                    MystickyStin ms = new MystickyStin("'Představitelka Valkýr na tomto světě zjevena jest. Jak její jméno zní?'", "eirlys", 2);
                    Souboj(VasePostava.hracovaPostava, ms, false, true);
                    Clear();
                    if(ms.uspel)
                    {
                        ForegroundColor = ConsoleColor.DarkCyan;
                        AnimaceTextu("Vypadá to, že když uhodnete hádanku stínu, je schopen Vás řádně odměnit...");
                        Tlacitko();
                        ms.VyberNoveSchopnosti();
                    }
                }
                else
                {
                    ForegroundColor = ConsoleColor.DarkCyan;
                    AnimaceTextu("Dveře zůstali uzavřené, hádanka nebyla zodpovězena správně...");
                    Tlacitko();
                }
                Clear();
                ForegroundColor = ConsoleColor.DarkCyan;
                AnimaceTextu("Jdete dál, zaujati co dalšího Vám toto místo přinese...");              
                AnimaceTextu("Procházíte mezi rozlehlými regály této prapodivné knihovny, bedlivě si prohlížíte své okolí.");
                AnimaceTextu("Narážíte na dvě další postavy, které ledabyle skládají knihy do regálů. Víte, co jsou zač...");
                AnimaceTextu(".....");
                Tlacitko();
                Souboj(VasePostava.hracovaPostava, new NemrtvyKnihovnik("'Halapartna jest mocná zbraň, je-li však mocnější než meč?' [ano/ne]", "ano", 1, ConsoleColor.Red), true, true);
                Souboj(VasePostava.hracovaPostava, new NemrtvyKnihovnik("'Výroba lektvaru zdraví skýtá mnohé suroviny, jest jedna z nich Houba bodavka?' [ano/ne]", "ne", 1), false, false);
                Clear();
                ForegroundColor = ConsoleColor.DarkCyan;
                AnimaceTextu("Prohledáváte svazky knih které zbyly po knihovnících...");
                Tlacitko();
                StatovaKniha(1);
            }
            void Room2Pokracovani()
            {
                ForegroundColor = ConsoleColor.DarkCyan;
                AnimaceTextu("Přicházíte k točitým schodům vedou do dalšího patra knihovny.");
                AnimaceTextu("Pod nimi si však všímáte dalšího zarámovaného pergamenu. Už víte, co to znamená...");
                Tlacitko();
                Okradeni();
                if(Hadanka("'Zbraň Valorijského markraběte byla životosajná. Kolik zdraví ona zbraň brala majiteli svému?'", "4", 2))
                {
                    uhodnutoHadanek++;
                    ForegroundColor = ConsoleColor.DarkCyan;
                    AnimaceTextu("Další malý prostor, který skrývá neobyčejé věci...");
                    Tlacitko();
                    Loot(NahodnyVyberKategoriePredmetu(), 3);
                    StatovaKniha(2);
                    ForegroundColor = ConsoleColor.DarkCyan;
                    AnimaceTextu("Po vybrání pokladů se opět objevuje onen stín...");
                    Tlacitko();
                    MystickyStin mystickyStin = new MystickyStin("'Zelení mužíci - skřet válečník a skřet travič mají stejnou zbraň? Jest to pravda?' [ano/ne]", "ano", 1, ConsoleColor.Green);
                    Souboj(VasePostava.hracovaPostava, mystickyStin, false, true);
                    mystickyStin.VyberNoveSchopnosti();
                }
                else
                {
                    ForegroundColor = ConsoleColor.DarkCyan;
                    AnimaceTextu("Kvůli nedostatku informací zůstanou mnohé dveře uzavřeny...");
                    Tlacitko();
                }
                Clear();
                ForegroundColor = ConsoleColor.DarkCyan;
                AnimaceTextu("Pokračujete po točitých schodech nahoru.");
                AnimaceTextu("Všímáte si dalších dveří, před nimiž je opět zarámovaný pergamen.");
                AnimaceTextu("Před těmito dveřmi stojí socha létajícího stvoření.");
                AnimaceTextu(".....");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkCyan;
                AnimaceTextu("Při vycítění života slyšíte ohlušující ránu. Socha bouchne a před Vámi stojí velké, děsivě vypadající stvoření...");
                Tlacitko();
                Souboj(VasePostava.hracovaPostava, new Gargoyl(), false, true);
                Clear();
            }
            void Room3Pokracovani()
            {
                ForegroundColor = ConsoleColor.DarkCyan;
                AnimaceTextu("Po této překvapivé bitvě si to namíříte hned k další hádance...");
                Tlacitko();
                Okradeni();
                if (Hadanka("'Gargoyl jest stvůra lítá, magii však také ovládá. Ohnivé koule, on používá?'[ano/ne]", "ano", 1))
                {
                    uhodnutoHadanek++;
                    ForegroundColor = ConsoleColor.DarkCyan;
                    AnimaceTextu("Další dveře, další tajemství k objevení...");
                    Tlacitko();
                    Loot(NahodnyVyberKategoriePredmetu(), 5);
                    StatovaKniha(1);
                    ForegroundColor = ConsoleColor.DarkCyan;
                    AnimaceTextu("Ani tentokrát Vás stín nezklamal, už ho očekáváte...");
                    Tlacitko();
                    MystickyStin mst = new MystickyStin("'Temná esence na výrobu elixíru vzkříšení potřeba je, kolik jí však onen musí mít?'", "5", 3, ConsoleColor.DarkBlue);
                    Souboj(VasePostava.hracovaPostava, mst, false, true);
                    mst.VyberNoveSchopnosti();
                }
                else
                {
                    ForegroundColor = ConsoleColor.DarkCyan;
                    AnimaceTextu("Tolik způsobů jak vědomosti získat, stačí chtít...");
                    Tlacitko();
                }
                Clear();
                ForegroundColor = ConsoleColor.DarkCyan;
                AnimaceTextu("Jste navrchu knihovny, očekáváte další místnost, dalšího nepřítele, další tajemnství.");
                AnimaceTextu("Našli jste ho - poslední zarámovaný pergamen!");
                AnimaceTextu("Oddychnete si, když zjistíte, že ho nikdo nehlídá...");
                Tlacitko();
                if (Hadanka("'Váš dům, Vaše místo odpočinku. Předměty tam hromadit lze. Kolik míst pro uložení tato budova skýtá?'", "3", 2))
                {
                    uhodnutoHadanek++;
                    ForegroundColor = ConsoleColor.DarkCyan;
                    AnimaceTextu("Poslední místnost, poslední příležitost...");
                    Tlacitko();
                    Loot(NahodnyVyberKategoriePredmetu(), 3);
                    StatovaKniha(2);
                    Clear();
                    ForegroundColor = ConsoleColor.DarkCyan;
                    AnimaceTextu("Netrpělivě očekáváte poslední stín...");
                    Tlacitko();
                    MystickyStin sn = new MystickyStin("'Čtyři hádanky ve čtyřech zarámovaných pergamenech pouští do čtyř místností. Kolik že jste jich Vy uhodli?'", uhodnutoHadanek.ToString(), 1);
                    Souboj(VasePostava.hracovaPostava, sn, false, true);
                    sn.VyberNoveSchopnosti();
                }
                else
                {
                    ForegroundColor = ConsoleColor.DarkCyan;
                    AnimaceTextu("Poslední pokus, poslední selhání...");
                    Tlacitko();
                }
                Clear();
                ForegroundColor = ConsoleColor.DarkCyan;
                AnimaceTextu("To by bylo, přijde Vám že jste prošli celou knihovnu naruby...");
                AnimaceTextu("Ale počkat, vidíte poslední místnost, poslední šanci na tajemství této knihovny...");
                AnimaceTextu("Před rámem dveří stojí dvě sochy gargoylů. Víte, co musíte udělat.");
                AnimaceTextu(".....");
                Tlacitko();
                Souboj(VasePostava.hracovaPostava, new Gargoyl(), true, true);
                Souboj(VasePostava.hracovaPostava, new Gargoyl(), false, false);
                Clear();
                ForegroundColor = ConsoleColor.DarkCyan;
                AnimaceTextu("Dveře jsou stále zavřeny...");
                AnimaceTextu("Vidíte na nich runovým písmem napsáno následující:");
                WriteLine($"-----Potřeba uhodnout minimálně tři hádanky v pergamenech, finální místnost pak otevřena bude. Uhodli jste {uhodnutoHadanek}-----");
                Tlacitko();
                if(uhodnutoHadanek >=3)
                {
                    ForegroundColor = ConsoleColor.DarkCyan;
                    AnimaceTextu("Dveře se otevírají, pod prahem se začíná tvořit jemná mlha.");
                    AnimaceTextu("Jemná modř oslňuje předmět na podstavci uprostřed místnosti...");
                    AnimaceTextu("Bez rozmyšlení si běžíte tento skvost vzít. Vypadá to jako hudební nástroj, když se ho dotknete, slyšíte tlumené chrochtání.");
                    if(VasePostava.hracovaPostava.maManu)
                    {
                        VasePostava.inventarPostavy.PridejPredmet(Harfa_Cisare_Koboldu);
                        Recepty.PridejReceptDoSeznamu(TvrobaPredmetu.RHarfa_Cisare_Koboldu);
                    }
                    else
                    {
                        VasePostava.inventarPostavy.PridejPredmet(Fletna_Krale_Koboldu);
                        Recepty.PridejReceptDoSeznamu(TvrobaPredmetu.RFletna_Krale_Koboldu);
                    }
                }
                else
                {
                    ForegroundColor = ConsoleColor.DarkCyan;
                    AnimaceTextu("Došlo Vám, že jste nejspíše neuhodli dost hádanek. Teď už je ale pozdě. Jediné co zbývá je odejít...");
                    Tlacitko();
                }
                Clear();
                ForegroundColor = ConsoleColor.Cyan;
                AnimaceTextu("Před odchodem si místo poctivě projdete, hledáte zbylé poklady...");
                Tlacitko();
                Loot(VsechnyAlchSuroviny, 2);
                Loot(VsechnyPouzitelne, 2);
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine();
                WriteLine("Také jste našli 15 zlata!");
                Inventar.PridejZlato(15, VasePostava.inventarPostavy);
                Tlacitko();
                StatovaKniha(2);
                StatovaKniha(2);
                StatovaKniha(1);
                ForegroundColor = ConsoleColor.Cyan;
                AnimaceTextu("S unikátním pocitem z tohoto místa odcházíte. Jste zvědavi, jaké další poutě Vás čekají...");
                Tlacitko();
                Okradeni();
                DokonciLokaci(Všudypřítomná_Knihovna);
                DokonciFinalneLokaci(Všudypřítomná_Knihovna);
                if (Nadčasový_Les._DokoncenaFinalneLokace)
                    OdemkniLokace(Astralni_Prechod);
            }
        }

        
    }
}
