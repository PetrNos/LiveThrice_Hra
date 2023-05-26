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
    class GameplayLokaci_4
    {
        //NC les
        private static void MWell(int HealHpAMany)
        {
            Clear();
            ForegroundColor = ConsoleColor.Green;
            WriteLine();
            VasePostava.hracovaPostava.vZdravi += HealHpAMany;
            if (VasePostava.hracovaPostava.vZdravi > VasePostava.hracovaPostava.zdraviPostavy)
            {
                VasePostava.hracovaPostava.vZdravi = VasePostava.hracovaPostava.zdraviPostavy;
            }
            WriteLine($"Našli jste měsíční studnu, doplní se Vám tak {HealHpAMany} zdraví.");
            Thread.Sleep(250);
            WriteLine();
            WriteLine($"Nyní máte {VasePostava.hracovaPostava.vZdravi} zdraví!");
            if (VasePostava.hracovaPostava.maManu)
            {
                ForegroundColor = ConsoleColor.Blue;
                WriteLine();
                Thread.Sleep(350);
                VasePostava.hracovaPostava.pocetMany += HealHpAMany;
                if (VasePostava.hracovaPostava.pocetMany > VasePostava.hracovaPostava.maxMana)
                {
                    VasePostava.hracovaPostava.pocetMany = VasePostava.hracovaPostava.maxMana;
                }
                WriteLine($"A také Vám doplnila {HealHpAMany} many!");
                WriteLine();
                WriteLine($"Nyní máte {VasePostava.hracovaPostava.pocetMany} many!");
            }
            GameplayLokaci_3.Tlacitko();
        }
        public static void NadcasovyLesGameplay()
        {

            Prichod();
            PrvniZapletka();
            ProkleteDryady();
            Bludicka();
            FinalniBoje();
            void Prichod()
            {
                ForegroundColor = ConsoleColor.DarkGreen;
                Clear();
                AnimaceTextu("Pokračujete ve Vaší pouti, ovzduší je suché a Vy doufáte, že brzy najdete něajký zdroj vody.");
                AnimaceTextu("Procházíte nekonečnou loukou, která, jak vidíte před Vámi, vede do jakéhosi lesa...");
                AnimaceTextu("Ačkoliv svítí slunce a za příznivé počasí jste rádi, ocenili byste déšť.");
                AnimaceTextu("......");
                AnimaceTextu("Louka je celá za Vámi a Vy vystupujete do lesa.");
                AnimaceTextu("Les na první pohled vypadá velmi zvláštně, mísí křiklavě zelenou barvu s barvou tmavší.");
                AnimaceTextu("Mech, který vidíte na zemi jakoby svítil výrazně zelenou barvou. Naopak koruny stromů jsou zchřadlé a napokraji smrti.");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkGreen;
                AnimaceTextu("V lese se cítíte zvláštně, nevíte, jestli je to lesem samotným, nebo jen nemáte dostatek vody...");
                AnimaceTextu("Také máte zvláštní pocit, že chodíte v kruzích, avšak podvědomě víte, že to není pravda.");
                AnimaceTextu("Procházíte okolo velikého stromu, na kterém je něco vyryto.");
                AnimaceTextu("Nejdříve jste si mysleli, že to byl datel, nebo nějaké jiné stvoření z lesa, ale je to neznámý jazyk...");
                Tlacitko();
                Okradeni();
                Past poznaJ = new Past(9, VasePostava.hracovaPostava.vInteligence, "inteligenci", VasePostava.hracovaPostava.vJmeno);
                Clear();
                if (poznaJ.Uspech())
                {
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine();
                    WriteLine("Text poznáváte, je to řeč temných elfů...");
                    WriteLine();
                    WriteLine("Píše se: 'Kde rány se nehojí a čas neplyne, v centru zkažený strom naleznete, ten až padne, obnova Lesa započne...'");
                }
                else
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine();
                    WriteLine("Text bohužel nepoznáváte, nevíte, co se na kmeni píše, ani jakým jazykem je to napsáno.");
                }
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkGreen;
                AnimaceTextu("Pokračujete po cestě dále. Les začíná houstnout a Vy přestáváte slyšet známky jakéhokoliv života v tomto ekosystému...");
                Tlacitko();
            }
            void PrvniZapletka()
            {
                ForegroundColor = ConsoleColor.DarkGreen;
                AnimaceTextu("Všímáte si dřevěného uložiště schovaného pod mechovým převisem...");
                AnimaceTextu("Nevidíte důvod si nevzít obsah, nikomu to tady stejně nepatří.");
                Tlacitko();
                Loot(NahodnyVyberKategoriePredmetu(), 3, ConsoleColor.Green);
                ForegroundColor = ConsoleColor.Green;
                WriteLine();
                WriteLine("Také jste našli 15 zlata!");
                Inventar.PridejZlato(15, VasePostava.inventarPostavy);
                Tlacitko();
                PrimaRec("Temná elfka", "Dokonce i tvůj druh neodolá vlastní zvědavosti, to mě nepřekvapuje.");
                PrimaRec("Temná elfka", "Tenhle les je náš, provádíme tu jistá...opatření.");
                PrimaRec("Temná elfka", "Být na mě, dám ti druhou šanci. Ale mám rozkazy a ty jsi vetřelec.");
                Tlacitko();
                Okradeni();
                Souboj(VasePostava.hracovaPostava, new LucistniceTemnychElfu(), true, true);
                Clear();
                ForegroundColor = ConsoleColor.DarkGreen;
                AnimaceTextu("Chápete, že jste na území někoho jiného, kde nejspíš nemáte co dělat.");
                AnimaceTextu("Na druhou stranu úmysly temných elfů často nebývají ty nejčistší.");
                AnimaceTextu(".....");
                AnimaceTextu("Po souboji si také všímáte něčeho zvláštního...");
                AnimaceTextu("Čas tu plyne jinak - rány se nezahojí, mana se neobnoví, magičtí společníci nezaniknou...");
                AnimaceTextu("Vypadá to, že čas je proti Vám. Okamžitě Vám dochází vyýhody a neýhody, které to s sebou nese.");
                AnimaceTextu("Třeba to lze využít ke svému prospěchu...");
                AnimaceTextu(".......");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkGreen;
                AnimaceTextu("Popojdete trochu dál a vidíte další uložiště - tentokrát zahrabané pod jehličím.");
                AnimaceTextu("Víte přesně, co máte čekat...");
                Tlacitko();
                Loot(NahodnyVyberKategoriePredmetu(), 4, ConsoleColor.Green);
                ForegroundColor = ConsoleColor.DarkGreen;
                AnimaceTextu("Měli jste pravdu, okmažitě vidíte další temnou elfku...");
                Tlacitko();
                Souboj(VasePostava.hracovaPostava, new LucistniceTemnychElfu(), true, true);
                Clear();
                ForegroundColor = ConsoleColor.DarkGreen;
                AnimaceTextu("O kus dále vidíte kamennou studnu. Voda v ní je čirá, třeba je v něčem speciální...");
                Tlacitko();
                MWell(10);
                ForegroundColor = ConsoleColor.DarkGreen;
                AnimaceTextu("Procházíte dále lesem, sledujete zchřadlé stromy a následujete prošlapanou cestu.");
                AnimaceTextu("Našlapujete opatrně a máte se na pozoru, jak už víte, nejste tu samy.");
                AnimaceTextu(".....");
                AnimaceTextu("Náhle slyšíte tiché naříkání. Nejdříve jste si mysleli, že máte slyšiny...");
                AnimaceTextu("Ale když vidíte na zemi ležet zeleno-fialové stvoření, víte, že to tak opravdu je.");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkGreen;
                AnimaceTextu("To stvoření je dryáda, znáte je z literatury a hodpodských povídek. Ale víte, že takhle by vypadat něměla.");
                AnimaceTextu("Místo smragdově zelené pleti je zbarveny lehce do fialova a v obličeji má zvláštní posunky.");
                Tlacitko();
                PrimaRec("Neobvyklá dryáda", "Žili jsme tu v...grrr...míru a pokoji.");
                PrimaRec("Neobvyklá dryáda", "Elfovééé přišli a zkazili...to...tu.");
                PrimaRec("Neobvyklá dryáda", "Já a sestry jsme teď naka...žené...");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkGreen;
                AnimaceTextu("Dryáda v křeči zemřela. Víte, že les je něčím nakažen.");
                Tlacitko();
                RabovaniMrtvol(new ProkletaDryada(), "Prokletá Dryáda");
                Clear();
                ForegroundColor = ConsoleColor.DarkGreen;
                AnimaceTextu("Vedle dryády vidíte ležet zvláštní elixír, který si neprodleně berete...");
                Tlacitko();
                Recepty.PridejReceptDoSeznamu(TvrobaPredmetu.RElixír_Časoprostoru);
                VasePostava.inventarPostavy.PridejPredmet(Elixír_Časoprostoru);
                Clear();
            }
            void ProkleteDryady()
            {
                ForegroundColor = ConsoleColor.DarkGreen;
                AnimaceTextu("Nejistě pokračujete dál a dál do lesa.");
                AnimaceTextu("Najednou za Vámi slyšíte agresivní vrčení...");
                AnimaceTextu("Ohlédnete se a vidíte za vámi dvojici dryád, které bohužel už nejsou při smyslech.");
                Tlacitko();
                Okradeni();
                Souboj(VasePostava.hracovaPostava, new ProkletaDryada(), true, true);
                Souboj(VasePostava.hracovaPostava, new ProkletaDryada(), true, false);
                Clear();
                ForegroundColor = ConsoleColor.DarkGreen;
                AnimaceTextu("Znepokojující stav, ve kterém se les nachází se začíná projevovat na všech jeho částech.");
                AnimaceTextu("Nejsou tu žádná zvířata, stromy jsou holé, po houbách ani stopy...");
                AnimaceTextu("V dáli vidíte další studnu, za tu jste rádi...");
                Tlacitko();
                MWell(7);
                ForegroundColor = ConsoleColor.DarkGreen;
                Past past = new Past(9, VasePostava.hracovaPostava.vObratnost, "obratnost", VasePostava.hracovaPostava.vJmeno);
                Clear();
                if (past.Uspech())
                {
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine();
                    WriteLine("Někdo na zem položil nebezpečnou magickou runu, ale včas jste si ji všimli...");

                }
                else
                {

                    ForegroundColor = ConsoleColor.Red;
                    WriteLine();
                    WriteLine("Někdo na zem položil nebezpečnou magickou runu, do které jste bohužel šlápli...");
                    WriteLine();
                    VasePostava.hracovaPostava.vZdravi -= 5;
                    WriteLine($"Vaše zdraví se tak snížilo o 5. Nyní máte {VasePostava.hracovaPostava.vZdravi} zdraví.");
                    if (VasePostava.hracovaPostava.vZdravi <= 0)
                        KonecHryMimoSouboj();
                }
                Tlacitko();

            }
            void Bludicka()
            {
                ForegroundColor = ConsoleColor.DarkGreen;
                AnimaceTextu("Pokračujete do hlubin nakaženého lesa, kde se den nedobrovolně mění v noc.");
                AnimaceTextu("Vše začíná tmavnout, jen tak tak vidíte pod nohy.");
                AnimaceTextu("Zpoza jednoho z kmenů vyjde, nebo spíše vylétne poměrně velká zářící koule.");
                AnimaceTextu("Přemýšlíte, kde by se tu vzala takhle velká světluška...");
                Tlacitko();
                PrimaRec("Bludička", "Poutníku, Vy ty monstra zabíjíte, jste na naší straně.");
                PrimaRec("Bludička", "Ta monstra, která si říkají temní elfové nakazili Prastarou Olši.");
                PrimaRec("Bludička", "Kvůli experimentům které v tomto ekosystému provádí...Přestal fungovat čas tak, jak by měl.");
                PrimaRec("Bludička", "Olše je tady už tisíce let, Dryády stejně tak. Oni tady ale vše ničí.");
                PrimaRec("Bludička", "Vy ale níčíte je, což je to nejlepší, co se tu za poslední dobu stalo.");
                PrimaRec("Bludička", "Uděláme vše pro to, abyste uspěli. Naučím Vás jak nejlépe využívat Vaše přednosti...");
                AnimaceTextu("......");
                Tlacitko();
                NoveSpecialniSchopnosti.VyberSSchopnosti(BludickyAbility, ConsoleColor.Cyan);
                Clear();
                ForegroundColor = ConsoleColor.DarkGreen;
                AnimaceTextu("Za vědomosti od Bludičky jste rádi, alespoň někomu v tomto prostředí na zničení nákazy záleží.");
                AnimaceTextu("Nemluvě o tom, že vidíte další studnu...");
                Tlacitko();
                MWell(5);
                ForegroundColor = ConsoleColor.DarkGreen;
                AnimaceTextu("Dopijete z měsíční studny a zjišťujete, že Vás pravděpodobně delší dobu sleduje dvojice temných elfek...");
                Tlacitko();
                PrimaRec("Temná elfka", "Bojuješ statečně. Ale čas tě porazí, dřív, nebo později...");
                Tlacitko();
                Okradeni();
                Souboj(VasePostava.hracovaPostava, new LucistniceTemnychElfu(), true, true);
                Souboj(VasePostava.hracovaPostava, new LucistniceTemnychElfu(), true, false);

            }
            void FinalniBoje()
            {
                Clear();
                ForegroundColor = ConsoleColor.DarkGreen;
                AnimaceTextu("Pokračujete dále, cítíte, že zlá aura se zesiluje, musíte být blízko...");
                Tlacitko();
                Past past = new Past(9, VasePostava.hracovaPostava.vObratnost, "obratnost", VasePostava.hracovaPostava.vJmeno);
                Clear();
                if (past.Uspech())
                {
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine();
                    WriteLine("Někdo na zem položil nebezpečnou magickou runu, ale včas jste si ji všimli...");

                }
                else
                {

                    ForegroundColor = ConsoleColor.Red;
                    WriteLine();
                    WriteLine("Někdo na zem položil nebezpečnou magickou runu, do které jste bohužel šlápli...");
                    WriteLine();
                    VasePostava.hracovaPostava.vZdravi -= 5;
                    WriteLine($"Vaše zdraví se tak snížilo o 5. Nyní máte {VasePostava.hracovaPostava.vZdravi} zdraví.");
                    if (VasePostava.hracovaPostava.vZdravi <= 0)
                        KonecHryMimoSouboj();
                }
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkGreen;
                AnimaceTextu("Všímáte si dalšího dřevěného uložiště, tentokrát uvnitř kmenu stromu...");
                Tlacitko();
                Loot(VsechnyAlchSuroviny, 3, ConsoleColor.Green);
                ForegroundColor = ConsoleColor.DarkGreen;
                WriteLine();
                WriteLine("Také jste našli 10 zlata!");
                Inventar.PridejZlato(10, VasePostava.inventarPostavy);
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkGreen;
                AnimaceTextu("Vypadá to, že tentokrát úschovnu nikdo nehlídá, výbroně!");
                AnimaceTextu(".....");
                AnimaceTextu("Vidíte cíl Vaší výpravy... Prastará Olše...");
                AnimaceTextu("Věříte, že když byla plně naživu, vypadala opravdu nádherně. Teď je to jen zchřadlý mohutný strom.");
                AnimaceTextu("Určitě stačí jen zničit cokoliv, co nákazu a časovou závadnost způsobuje a vše bude v pořádku...");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkGreen;
                AnimaceTextu("Po cestě nacházíte další studnu, nelze ji minout...");
                MWell(7);
                ForegroundColor = ConsoleColor.DarkGreen;
                AnimaceTextu("Přistupujete k Prastaré Olši, vypadá smutně a osamoceně. Stačí jen najít zdroj nákazy...");
                AnimaceTextu(".....");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkGreen;
                AnimaceTextu("Ze stínů lesa vychází temný elf. Je vyšší a mohutnější než jeho spolubojovnice.");
                AnimaceTextu("Jde pomalu a vypadá, že Vás očekával...");
                Tlacitko();
                PrimaRec("Temný Elf", "Jsem velitel tohoto...úseku.");
                PrimaRec("Temný Elf", "Nerozumím, proč by se někdo tvého druhu bláhově pokoušel nás zastavit.");
                PrimaRec("Temný Elf", "Čas je složitá věc, náročná na chápaní. Nechte ji laskavě těm, kteří ji rozumí.");
                PrimaRec("Temný Elf", "Špatná rozhodnutí se ale trestají, třeba se v příštím životě rozhodnete jinak.");
                Tlacitko();
                Souboj(VasePostava.hracovaPostava, new VelitelTemnychElfu(), false, true);
                Clear();
                ForegroundColor = ConsoleColor.DarkGreen;
                AnimaceTextu("Velitel byl poražen, experimenty mohou skončit.");
                AnimaceTextu("Uvnitř stromu najdete zvláštně vypadající zařízení, které je ke stromu připevněno.");
                AnimaceTextu("Je poháněno jakousi magií. Jedním seknutím ho jednoduše zníčíte - není tu kdo by ho bránil.");
                AnimaceTextu("....");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkGreen;
                AnimaceTextu("Po zničení zdroje nákazy strom okamžitě rozkvetl. Vypadá opravdu majestátně.");
                AnimaceTextu("Koruny ostatních stromů jsou očištěny, na zemi rostou borůvky a rozmanité druhy hub.");
                AnimaceTextu("Světlo proniká do lesa a shnilý ekosystém se mění v bohatou zahradu.");
                AnimaceTextu("Čas se také spravil, začal plynout tak, jak má. Vaše rány se pomalu uzavírají...");
                AnimaceTextu("Přeživší dryády změnu vycítili a okamžitě se přišli podívat co se vlastně stalo.");
                AnimaceTextu("Z jejich výrazů poznáváte velkou radost.");
                Tlacitko();
                PrimaRec("Dryáda", "Děkujeme Vám, zachránili jste nás všechny.");
                PrimaRec("Dryáda", "Bohužel, je tu ještě jedno sídlo ve kterém Temní elfové experimentují...");
                PrimaRec("Dryáda", "Aura je nejsilněji vycítitelná ze západu. Byly bychom Vám vděčné, kdybyste se podívali i tam.");
                PrimaRec("Dryády kolektivně", "Děkujeme Vám poutníku!");
                Tlacitko();
                Okradeni();
                DokonciLokaci(Nadčasový_Les);
                DokonciFinalneLokaci(Nadčasový_Les);
                OdemkniLokace(Experimentální_Jádro);
                if(Všudypřítomná_Knihovna._DokoncenaFinalneLokace)
                OdemkniLokace(Astralni_Prechod);
                ForegroundColor = ConsoleColor.Green;
                WriteLine();
                WriteLine("Gratulujeme, dokončili jste Lokaci Nadčasový Les!");
                Tlacitko();
            }
        }


        //Experimentnlí jádro
        private static bool prvniN = true;
        public static int pocetNavstev = 0;
        private static bool sebralZbr = false;
        public static void ExperimentalniJadroGameplay()
        {
            pocetNavstev++;
            if (pocetNavstev == 3)
                UzamkniLokace(Experimentální_Jádro);
            if (prvniN)
            {
                prvniN = false;
                Clear();
                ForegroundColor = ConsoleColor.Green;
                AnimaceTextu("Rozhodnete se Dryády poslechnout a vydat se zničit zbylé experimentální základny.");
                AnimaceTextu("Když se přibližujete, zjišťujete, že všechny mají něco společného - jsou postaveny v lesích a narušují časoprostor.");
                AnimaceTextu("Tyhle jsou však více hlídané, než ta, na kterou jste narazili jako první.");
                AnimaceTextu(".....");
                AnimaceTextu("Očekáváte další nakažené stromy, které by celou lokaci narušovali. Také očekáváte více temných elfů, nebo prokletých dryád.");
                AnimaceTextu("Nevíte, kolik nepřátel očekávat, ale víte, že na regeneraci Vašich ran se nelze spoléhat - stejně jako v Nadčasovém Lese...");
                Tlacitko();
                ForegroundColor = ConsoleColor.Green;
                WriteLine();
                WriteLine("Před vsupem do Experimentálního Jádra nacházíte zvláštní měsíční studnu...");
                VasePostava.hracovaPostava.vZdravi += 10;
                if (VasePostava.hracovaPostava.maManu)
                    VasePostava.hracovaPostava.pocetMany += 5;
                VasePostava.hracovaPostava.RekonfiguraceHPaMany();
                WriteLine();
                WriteLine("Zdraví se Vám tak permanentně zvyšuje o 10!");
                if (VasePostava.hracovaPostava.maManu)
                {
                    WriteLine();
                    WriteLine("A mana o 5!");
                }
                Tlacitko();
                ForegroundColor = ConsoleColor.Cyan;
                AnimaceTextu("Místo bude fungovat obdobně, jako návštěva skřetího království.");
                AnimaceTextu("Máte tři pokusy na dobytí této lokace a přerušení experimentů temných elfů.");
                AnimaceTextu("Jestliže se Vám to nepodaří, lokace se permanentně uzavře a další dobývání nebude možné.");
                AnimaceTextu("Budete potkávat vlny nepřátel, kteří se Vás budou snažit zastavit a dokončit své experimenty.");
                AnimaceTextu("Pokud se po nějaké vlně nebudete cítit na další souboje, můžete odejít.");
                AnimaceTextu("Odebere se Vám tak pokus, avšak zůstanete naživu...");
                AnimaceTextu("V průběhu také budete získávat nejrůznější poklady. Když odejdete, bude jich méně, než při úspěšném dokončení.");
                AnimaceTextu("Jelikož se nacházíte v nadčasovém prostoru, nebudete se regenrovat, využívejte Vaše zdroje tedy moudře.");
                AnimaceTextu("......");
                AnimaceTextu("Hodně štěstí!");
                Tlacitko();
            }
            else
            {
                ForegroundColor = ConsoleColor.Cyan;
                AnimaceTextu("Další návštěva, další nepřátelé.");
                AnimaceTextu("Hodně štěstí, poutníku!");
                Tlacitko();
            }
            int pocetUspesnychSouboju = 0;
            List<Stvoreni> TE1 = new List<Stvoreni> { new ProkletaDryada(), new ProkletaDryada(), new LucistniceTemnychElfu() };
            List<Stvoreni> TE2 = new List<Stvoreni> { new LucistniceTemnychElfu(), new LucistniceTemnychElfu(), new ProkletaDryada() };
            List<Stvoreni> TE3 = new List<Stvoreni> { new LucistniceTemnychElfu(), new ProkletaDryada(), new VelitelTemnychElfu() };
            List<Stvoreni> TE4 = new List<Stvoreni> { new VelitelTemnychElfu() };


            WaveSouboj(TE1, 1);
            WaveSouboj(TE2, 2);
            WaveSouboj(TE3, 3);
            if (!sebralZbr)
            {
                sebralZbr = true;
                Clear();
                ForegroundColor = ConsoleColor.DarkCyan;
                AnimaceTextu("Mezi souboji jste našli v jednom z obytných stanů zvláštně vypadající zbraň...");
                Tlacitko();
                if (VasePostava.hracovaPostava.maManu)
                {
                    VasePostava.inventarPostavy.PridejPredmet(Hul_Odporu_Smrti);
                    Recepty.PridejReceptDoSeznamu(TvrobaPredmetu.RHul_Odporu_Smrti);
                }
                else
                {
                    VasePostava.inventarPostavy.PridejPredmet(Palcat_Odporu_Smrti);
                    Recepty.PridejReceptDoSeznamu(TvrobaPredmetu.RPalcat_Odporu_Smrti);
                }
            }
            WaveSouboj(TE4, 4, false);
            Souboj(VasePostava.hracovaPostava, new VelitelTemnychElfu(), false, false);
            Clear();
            ForegroundColor = ConsoleColor.DarkGreen;
            AnimaceTextu("Zvládli jste to, všichni veitelé a jejich pomocníci jsou mrtví, ekosystém byl očištěn.");
            AnimaceTextu("Po očištění ho okamžitě obsadili jejich původní obyvatelé - dryády.");
            AnimaceTextu("Samozřejmě jsou Vám vděčné a poskytují Vám jejich Les jako Vaše útočiště.");
            AnimaceTextu("Jste zde kdykoliv vítání...");
            Tlacitko();
            ForegroundColor = ConsoleColor.Cyan;
            AnimaceTextu("Odnášíte si všechny poklady, které jste u temných elfů našli.");
            AnimaceTextu("A také se těšíte na další návštěvu tohoto znovuzrozeného lesa.");
            Tlacitko();
            Loot(VsechnyAlchSuroviny, 5);
            Loot(VsechnyKovSuroviny, 5);
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine();
            WriteLine("Také jste našli 50 zlata!");
            Tlacitko();
            StatovaKniha(3);
            StatovaKniha(2);
            StatovaKniha(1);
            Inventar.PridejZlato(50, VasePostava.inventarPostavy);
            DokonciLokaci(Experimentální_Jádro);
            DokonciFinalneLokaci(Experimentální_Jádro);
            OdemkniLokace(Znovuzrozeny_Les);
            Lokace.VyberoveMenu();
            void WaveSouboj(List<Stvoreni> nepratele, int cisloVlny, bool odejitMenu = true)
            {
                foreach (Stvoreni s in nepratele)
                {
                    Souboj(VasePostava.hracovaPostava, s, true, true);
                }
                Clear();
                ForegroundColor = ConsoleColor.DarkCyan;
                pocetUspesnychSouboju++;
                WriteLine();
                WriteLine($"Vlna číslo {cisloVlny} byla úspěšně poražena!");
                if (cisloVlny == 4)
                {
                    WriteLine();
                    WriteLine("Poslední velitel brání poslední strom. Jste skoro v cíli!");
                }
                Tlacitko();
                if (odejitMenu)
                    Odejít();
            }
            void Odejít()
            {
                Clear();
                Menu Odejit = new Menu("Přejete si po této vlně hlídek experimentů odejít?", new List<string> { "Ne, bojotvat dále", "Ano, odejít" }, ConsoleColor.Red);
                int vb = Odejit.NavratIndexu();
                if (vb == 1)
                {
                    Clear();
                    int pZlata = 5 * pocetUspesnychSouboju;
                    ForegroundColor = ConsoleColor.Blue;
                    WriteLine();
                    WriteLine("Úspěšně odcházíte, při dobývání jste nalezli následující předměty: ");
                    Tlacitko();
                    for (int i = 0; i < pocetUspesnychSouboju; i++)
                        Loot(NahodnyVyberKategoriePredmetu(), 2);
                    ForegroundColor = ConsoleColor.Yellow;
                    WriteLine($"Také si odnášíte {pZlata} zlata!");
                    Tlacitko();
                    ForegroundColor = ConsoleColor.Blue;
                    WriteLine();
                    WriteLine((3 - pocetNavstev > 0) ? $"Zbývá Vám ještě {3 - pocetNavstev} pokusů na dobytí!" : "Toto byl Váš poslední pokus...třeba se to podaří jinému dobrodruhoví.");
                    Tlacitko();
                    Lokace.VyberoveMenu();
                }
                else
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Blue;
                    WriteLine();
                    WriteLine("Připravte se na další vlnu nepřítel!"); ;
                    Tlacitko();
                }
            }
        }


        public static bool DoplneniMoonI = false;
        private static int pnavstev = 0;
        static Dictionary<string, Action<int>> Vyuka = new Dictionary<string, Action<int>>
        {
    {"Zvýšení zdraví", i => VasePostava.hracovaPostava.vZdravi+=i},
        };
        static List<Predmety> MoonSItemy = new List<Predmety> { Osvícená_Smůla, Měsíční_Erb, Lektvar_Zdraví, Lektvar_Many, Lektvar_Síly, Lektvar_Obratnosti, Lektvar_Inteligence, Lektvar_Stesti };
        static Inventar MoonStore = new Inventar();

        //zzl
        public static void ZnovuzrozenyLesGameplay()
        {
            Clear();
            if (!DoplneniMoonI)
                DoplneniObchodniku(MoonStore);
            pnavstev++;
            if (pnavstev == 1)
            {
                ForegroundColor = ConsoleColor.Green;
                AnimaceTextu("Vítejte ve Znovuzrozeném Lese.");
                AnimaceTextu("Čistém a přirozeně životudárném místě.");
                AnimaceTextu("Jste tu vždy vítáni, Dryády počítají s Vaší návštěvou.");
                AnimaceTextu(".....");
                AnimaceTextu("Můžete se tu naučit jak využívat životní sílu, vzít Dryádu s sebou na Vaše cesty, nebo nakupovat vybrané předměty.");
                Tlacitko();
            }
            while (true)
            {
                Menu VPanstvi = new Menu("Vyberte si, co chcete ve Znovuzrozeném Lese dělat", new List<string> { "Obchodovat", "Spolupracovat s Dryádami", "Využít dary životodárné síly", "Odejít" }, ConsoleColor.Cyan);
                int volba = VPanstvi.NavratIndexu();
                if (volba == 3)
                    break;
                else if (volba == 0)
                    Obchodovani();
                else if (volba == 1)
                    NajmutiSpol();
                else if (volba == 2)
                    UceniSe();
            }
            void Obchodovani()
            {
                Obchod.LaboratorObchod(VasePostava.inventarPostavy, MoonStore, "Lesní", 0.7);
            }
            void NajmutiSpol()
            {
                int Cena = 2;
                while (true)
                {
                    Menu spolecnikS = new Menu($"Přejete si mít Dryádu jako Vašeho společníka? (tento společník nemizí, když souboj skončí a stojí {Cena} měsíční erby)\n\nNyní máte {VasePostava.inventarPostavy.PocetPredmetu(Měsíční_Erb)} Měsíčních erbů", new List<string> { "Ano", "Ne" }, ConsoleColor.Cyan);
                    int v = spolecnikS.NavratIndexu();
                    if (v == 1)
                        break;
                    else
                    {

                        if (VasePostava.spolecnik != null && VasePostava.inventarPostavy.PocetPredmetu(Měsíční_Erb) >= Cena)
                        {
                            Clear();
                            Menu m = new Menu($"Vypadá to, že již máte společníka ({VasePostava.spolecnik.nazevStvoreni}). Přejete si ho zaměnit za Dryádu?", new List<string> { "Ano", "Ne" }, ConsoleColor.Red);
                            int t = m.NavratIndexu();
                            if (t == 0)
                            {
                                for (int i = 0; i < Cena; i++)
                                    VasePostava.inventarPostavy.OdeberPredmet(Měsíční_Erb);
                                VasePostava.spolecnik = new Dryada();//DRYADA
                                Clear();
                                ForegroundColor = ConsoleColor.DarkGreen;
                                WriteLine();
                                WriteLine("Výbroně, Dryáda je nyní Váš společník...");
                                Tlacitko();
                            }
                            else break;
                        }
                        else if (VasePostava.spolecnik == null && VasePostava.inventarPostavy.PocetPredmetu(Měsíční_Erb) >= Cena)
                        {
                            for (int i = 0; i < Cena; i++)
                                VasePostava.inventarPostavy.OdeberPredmet(Měsíční_Erb); ;
                            VasePostava.spolecnik = new Dryada();//DRYADA
                            Clear();
                            ForegroundColor = ConsoleColor.Cyan;
                            WriteLine();
                            WriteLine("Výbroně, Dryáda je nyní Váš společník...");
                            Tlacitko();
                        }
                        else
                        {
                            Clear();
                            ForegroundColor = ConsoleColor.Red;
                            WriteLine();
                            WriteLine($"Vypadá to, že pro spolupráci s Dryádou nemáte dost Měsíčních erbů. Požaduje {Cena} Měsíšních erbů a Vy máte jen {VasePostava.inventarPostavy.PocetPredmetu(Měsíční_Erb)}.");
                            Tlacitko();
                        }
                    }

                }

            }
            void UceniSe()
            {
                int cena = 3;
                while (true)
                {
                    var MenuSkillu = Vyuka.Keys.ToList();
                    MenuSkillu.Add("Odejít");
                    Menu m = new Menu($"Chcete zvýšit Vaše zdraví?\n\nCena je {cena}x Osvícená smůla za zvýšení, nyní máte {VasePostava.inventarPostavy.PocetPredmetu(Osvícená_Smůla)} Osvícené smůly", MenuSkillu, ConsoleColor.Cyan);
                    int c = m.NavratIndexu();
                    if (c == MenuSkillu.Count - 1)
                        break;
                    string vybranyAtribut = MenuSkillu[c];
                    Uceni(vybranyAtribut);

                }

                void Uceni(string nazev)
                {
                    if (VasePostava.inventarPostavy.PocetPredmetu(Osvícená_Smůla) < cena)
                    {
                        Clear();
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine();
                        WriteLine("Nemáte dostatek Osvícených smůl na výuku, cena je {0} Osvícených smůl a Vy máte jen {1}.", cena, VasePostava.inventarPostavy.PocetPredmetu(Osvícená_Smůla));
                        Tlacitko();
                        return;
                    }
                    else
                    {
                        for (int i = 0; i < cena; i++)
                            VasePostava.inventarPostavy.OdeberPredmet(Osvícená_Smůla);
                        ForegroundColor = ConsoleColor.Blue;
                        Clear();
                        WriteLine();
                        WriteLine("Výborě, přírodní silou proběhlo {0} o 3!", nazev);
                        Vyuka[nazev](3);
                        int atribut = 0;
                        switch (nazev)
                        {

                            case "Zvýšení zdraví":
                                atribut = VasePostava.hracovaPostava.vZdravi;
                                VasePostava.hracovaPostava.RekonfiguraceHPaMany(); break;
                        }
                        WriteLine();
                        WriteLine("Po {0} je jeho hodnota nyní {1}.", nazev, atribut);
                        Tlacitko();
                        Vyuka.Remove(nazev);
                    }
                }
            }
            void DoplneniObchodniku(Inventar iZ)
            {
                if (DoplneniMoonI)
                    return;
                DoplneniMoonI = true;
                Vyuka = new Dictionary<string, Action<int>>
                    {
                        {"Zvýšení zdraví", i => VasePostava.hracovaPostava.vZdravi+=i},
                    };
                DoplneniInventareFull(MoonStore, MoonSItemy);
                void DoplneniInventareFull(Inventar invKdoplneni3x, List<Predmety> doplnuji)
                {
                    foreach (Predmety P in doplnuji)
                    {
                        if (P.pocetPredmetu(invKdoplneni3x) < 3)
                        {
                            while (P.pocetPredmetu(invKdoplneni3x) < 3)
                            {
                                invKdoplneni3x.PridejPredmet(P);

                            }
                        }
                    }

                }
            }
        }

        //Astrální přechod
        public static void AstralniPrechod()
        {
            Prichod();
            Portal();
            Cesta();
            void Prichod()
            {
                Clear();
                ForegroundColor = ConsoleColor.DarkMagenta;
                AnimaceTextu("Po Vaší návštěvě v začarovaném lesním prostředí se dostáváte do více známé krajiny...");
                AnimaceTextu("Je chvilka po půlnoci a Vy jdete po kamenité cestě. Okolo Vás jsou vysoké stromy, noční zvířata a jeskyně.");
                AnimaceTextu("Vše je tiché a klidné, vítr nefouká a jedniné co slyšíte jsou projevy místní zvěře.");
                AnimaceTextu("V jedné z jeskyní, které vidíte okolo Vás, spatříte tlumené blikající světlo, má fialovou barvu.");
                AnimaceTextu("Rozhdnete se vejít dovnitř a zjistit, co je jeho příčina...");
                AnimaceTextu(".....");
                Tlacitko();
            }
            void Portal()
            {
                ForegroundColor = ConsoleColor.DarkMagenta;
                AnimaceTextu("Světlo musí mít na místě největšího účinku velice intenzivní, jelikož jdete docela dlouho a stále u něj nejste...");
                AnimaceTextu("Po dlouhém kličkování mezi štěrbinami jeskyně přicházíte k velikému purpurovému oválu, u kterého stojí jakýsi čaroděj.");
                AnimaceTextu(".....");
                Tlacitko();
                PrimaRec("Čaroděj", "Další zabloudilec? Pro pána krále já to tady snad nikdy nezavřu...");
                PrimaRec("Čaroděj", "Tohle? Ano, ano, portál, teleportace. Vede do jiných dimenzí, nikdo neví kam přesně. Světy se tam propojují a tak dále...");
                PrimaRec("Čaroděj", "Vy že byste tam potřeboval? No bránit Vám nebudu, rychle se zbavit dalšího čumila je docela příhodné.");
                PrimaRec("Čaroděj", "Nemluvě o tom že se samozřejmě už nikdy nevrátíte.");
                PrimaRec("Čaroděj", "Pro to, abyste vůbec prošli musíte na půl cesty portálu porazit Astrálního strážce. A ani potom není nic jisté!");
                PrimaRec("Čaroděj", "To je fuk... běžte, ať už to tady můžu uzavřít!");
                AnimaceTextu(".....");
                Tlacitko();
            }
            void Cesta()
            {
                ForegroundColor = ConsoleColor.DarkMagenta;
                AnimaceTextu("Střemhlav skáčete do portálu, jelikož víte, že v tomto světě nezískáte to, co chcete...");
                AnimaceTextu(".....");
                AnimaceTextu(".....");
                AnimaceTextu("Při přechodu v portálu Vám přijde, že prolétáváte trubicí, kde se střídají všechny barvy.");
                AnimaceTextu("Pocit to rozhodně příjemný není, ale věříte, že někde co nevidět přistanete.");
                AnimaceTextu(".....");
                AnimaceTextu("......");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkMagenta;
                AnimaceTextu("Portál Vás vyplyvne na dutou, průhlednou podlahu.");
                AnimaceTextu("Pád trochu štípl, ale nic hrozného to nebylo.");
                AnimaceTextu("V udivení se zvednete z podlahy a prohlížíte si místo, ve kterém jste z nějakého důvodu skončili.");
                AnimaceTextu("Než si stihnete prohlédnout detaily, několik desítek stop před Vámi spatříte zvláště vypadající monstrum.");
                AnimaceTextu("Upřeně se na Vás dívá a pomalu se přibližuje. Pravděpodobně je to zmíněný Astrální strážce...");
                AnimaceTextu(".....");
                Tlacitko();
                Souboj(VasePostava.hracovaPostava, new AstralniStrazce(), false, true);
                Recepty.PridejReceptDoSeznamu(TvrobaPredmetu.RPrach_Přízračnosti);
                Clear();
                ForegroundColor = ConsoleColor.DarkMagenta;
                AnimaceTextu("Jakmile jste se od těla této bestie odklonili, portál Vás opět vcucl.");
                AnimaceTextu("Zbytek cesty jste se nesetkali s dalšími překážkami, kromě drobných nevolností...");
                AnimaceTextu("......");
                Tlacitko();
                ForegroundColor = ConsoleColor.DarkMagenta;
                AnimaceTextu("Přistáváte na zvláštně vypadající půdě. Barva, ovzduší, i místní ekosystém, včetně obyvatel, vypadá...neobvykle.");
                AnimaceTextu(".....");
                Tlacitko();
                DokonciLokaci(Astralni_Prechod);
                DokonciFinalneLokaci(Astralni_Prechod);
                OdemkniLokace(Dabelska_Herna);
            }
        }



        static Random r = new Random();
        static Inventar DabelskyObchod = new Inventar();
        static void NaplnDabObchod(Inventar inv)
        {
            inv.ListInventare().AddRange(VsechnyAlchSuroviny);
            inv.PridejPredmet(Pekelne_Platy);
            inv.PridejPredmet(Pekelny_Bič);
            inv.PridejPredmet(Dryak_Sebevzniceni);
            inv.PridejPredmet(Klíč_k_Zábavě);
        }
        public static void HernaOPenize(int minO, int maxO, int nasobitelVyhry)
        {
            byte cena = 5;
            if (VasePostava.inventarPostavy.PocetZlata() >= 5)
            {
                ForegroundColor = ConsoleColor.Green;
                WriteLine();
                WriteLine($"Vstup do herny stojí {cena} Zlatých, děkujeme za poctivé placení vstupu!");
                Tlacitko();
                Inventar.OdeberZlato(cena, VasePostava.inventarPostavy);

            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine();
                WriteLine($"Vstup do herny stojí {cena} Zlatých, které bohužel nemáte...");
                Tlacitko();
                return;
            }
            while (true)
            {
                Menu herna = new Menu("Přejete si hrát o peníze v Ďábelské Herně?", new List<string> { "Ano, hrát!", "Ne, nehrát" }, ConsoleColor.Red);
                int m = herna.NavratIndexu();
                if (m == 1)
                    break;
                else
                {
                    if(VasePostava.inventarPostavy.PocetZlata() <= 0)
                    {
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine();
                        WriteLine("Chudáci bez zlata do herny nemohou...");
                        Tlacitko();
                        return;
                    }
                    ForegroundColor = ConsoleColor.Yellow;
                    Clear();
                    WriteLine();
                    WriteLine($"Zadejte počet zlata, o který chcete hrát: (1 až {VasePostava.inventarPostavy.PocetZlata()}), nebo zadejte '0' pro opuštění herny.");
                    WriteLine();
                    int pZ;
                    CursorVisible = true;
                    while(!int.TryParse(ReadLine(), out pZ) || pZ < 0 || pZ > VasePostava.inventarPostavy.PocetZlata())
                    {
                        WriteLine();
                        WriteLine("Musíte zadat číslo, které je v povoleném rozsahu.");
                        WriteLine();                       
                    }
                    CursorVisible = false;
                    if(pZ == 0)
                    {
                        ForegroundColor = ConsoleColor.Red;
                        Clear();
                        WriteLine();
                        WriteLine("Odcházíte z herny.");
                        Tlacitko();
                        break;
                    }
                    else
                    {
                        ForegroundColor = ConsoleColor.Yellow;
                        Clear();
                        int SpravneC = r.Next(minO, maxO + 1);
                        WriteLine();
                        WriteLine($"Hrajete o {pZ} zlatých. Prohrou vše ztratíte, výhrou získáte {nasobitelVyhry}x Váš vklad!");
                        WriteLine();
                        WriteLine($"Ďáblík si myslí celé číslo mezi {minO} a {maxO} včetně. Jaký je Váš odhad?");
                        WriteLine();
                        int odhad;
                        CursorVisible = true;
                        while (!int.TryParse(ReadLine(), out odhad) || odhad < minO || odhad > maxO)
                        {
                            WriteLine();
                            WriteLine("Musíte zadat číslo, které je v rozsahu myšlených čísel.");
                            WriteLine();                            
                        }
                        CursorVisible = false;
                        if(odhad == SpravneC)
                        {
                            ForegroundColor = ConsoleColor.Green;
                            Clear();
                            WriteLine();
                            WriteLine($"{odhad} je správně! Odnášíte si {nasobitelVyhry}x Váš vklad! ({nasobitelVyhry*pZ} zlata)");
                            WriteLine();
                            WriteLine("Jen tak dále!");
                            Inventar.PridejZlato(nasobitelVyhry * pZ, VasePostava.inventarPostavy);
                            Tlacitko();
                            continue;
                        }
                        else
                        {
                            ForegroundColor = ConsoleColor.Red;
                            Clear();
                            WriteLine();
                            WriteLine($"{odhad} je špatně...Bohužel vklady ztrácíte ({pZ} zlata)");
                            WriteLine();
                            WriteLine("Příště to určitě vyjde!!");
                            Inventar.OdeberZlato(pZ, VasePostava.inventarPostavy);
                            Tlacitko();
                            continue;
                        }
                    }
                }
            }
        }
        public static void BojoveUceni(int cenaStat, int cenaUOH)
        {
            DndKostka kostka = new DndKostka(); 
            while(true)
            {

                Menu vyberUpg = new Menu($"Vyberte si stat, ve kterém se chcete vylepšit:\n\nZákladní čtyři stojí {cenaStat} zlata, Bojové hodnoty stojí {cenaUOH} zlata (nyní máte {VasePostava.inventarPostavy.PocetZlata()} zlata):\n", new List<string> { "Síla", "Obratnost", "Inteligence", "Štěstí", "Obranná hodnota", "Útočná hodnota", "Odejít"}, ConsoleColor.Blue);
                int vU = vyberUpg.NavratIndexu();
                if (vU == 6)
                    break;
                else if (vU == 0)
                    VasePostava.hracovaPostava.vSila += Uceni("Síla", ConsoleColor.Red, cenaStat);
                else if (vU == 1)
                    VasePostava.hracovaPostava.vObratnost += Uceni("Obratnost", ConsoleColor.Yellow, cenaStat);
                else if (vU == 2)
                    VasePostava.hracovaPostava.vInteligence += Uceni("Inteligence", ConsoleColor.Blue, cenaStat);
                else if (vU == 3)
                    VasePostava.hracovaPostava.vStesti += Uceni("Štěstí", ConsoleColor.Green, cenaStat);
                else if (vU == 4)
                {

                    VasePostava.hracovaPostava.vObrannaHodnota += Uceni("Základní obranná hodnota", ConsoleColor.Cyan, cenaUOH); 
                    VasePostava.hracovaPostava.RekonfiguraceUH(); 
                    VasePostava.hracovaPostava.RekonfiguraceAltUH();
                }
                else if (vU == 5)
                {

                    VasePostava.hracovaPostava.vUtocnaHodnota += Uceni("Základní útočná hodnota", ConsoleColor.DarkBlue, cenaUOH); 
                    VasePostava.hracovaPostava.RekonfiguraceOH();
                }
            }


            int Uceni(string nazev, ConsoleColor barva, int cenaStatu)
            {
                Clear();
                if(VasePostava.inventarPostavy.PocetZlata() < cenaStatu)
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine();
                    WriteLine($"Nemáte dost zlata na vylepšení se v atributu {nazev}...");
                    Thread.Sleep(350);
                    WriteLine();
                    WriteLine($"Cena je {cenaStatu} zlata a Vy máte jen {VasePostava.inventarPostavy.PocetZlata()} zlata.");
                    Tlacitko();
                    return 0;
                }
                else
                {
                    Inventar.OdeberZlato(cenaStatu, VasePostava.inventarPostavy);
                    kostka.KostkyArt();
                    kostka.HodStatovouKostkou();
                    ForegroundColor = barva;
                    WriteLine();
                    WriteLine($"Stat {nazev} byl úspěšně zvýšen o {kostka.VysledekHodu()}, výborně!");
                    Thread.Sleep(250);
                    WriteLine();
                    WriteLine($"Nyní máte {VasePostava.inventarPostavy.PocetZlata()} zlata!");
                    Tlacitko();
                    return kostka.VysledekHodu();
                }
            }
        }
        public static void DabelskaHernaGameplay()
        {
            //dalsi gameplay, pridat dryak sebevzniceni ◄
            //pridat set pekelnych zbroji atd ◄
            //shop ◄
            //herna ◄
            //add statu kostkou ◄
            //aplikace klice_k_zabave ◄
            PrichodDoMesta();
            VypnutiPrachu();
            Boje();
            FinalAKlic();
            void PrichodDoMesta()
            {
                Clear();
                ForegroundColor = ConsoleColor.Red;
                AnimaceTextu("Přistáváte na zvláštním místě, má bledě červený nádech.");
                AnimaceTextu("Vypadá jako poušť, avšak něco, co se jeví jako město je ve Vašem dohledu.");
                AnimaceTextu("Okolo Vás je hustý prach, jehož dotek však skoro necítíte.");
                AnimaceTextu("Zvednete se z písku, který je, jako vše okolo Vás, také červený.");
                AnimaceTextu("Nevíte co od tohoto místa čekat, ani kde vlastně můžete být.");
                AnimaceTextu("Namíříte si to tedy k městu, kde se třeba budete někoho schopni zeptat na detaily.");
                AnimaceTextu("Když se přiblížíte, zjišťuje, že ve městě opravdu jsou obyvatelé a také poměrně zajímavě vypadající budovy.");
                AnimaceTextu("Do tváří přes hustý prach nikomu nevidíte. Budovy mají ostrou architekturu, v černo-červeném barevném provedení.");
                AnimaceTextu("Strukturou to vypadá jako obyčejné město - obchody, obytné doby a jiné...");
                AnimaceTextu(".....");
                AnimaceTextu("Uprostřed města stojí velká, dvoupatrová budova, která výrazně vyčnívá nad ostatními nemovitostmi ve městě.");
                AnimaceTextu("Na čele budovy je rudý neonový nápis 'Herna', který je vidět na úctyhodnou vzdálenost.");
                AnimaceTextu("U této budovy je největší rozruch ve městě a většina obyvatel se tam pohybuje...");
                AnimaceTextu(".....");
                Tlacitko();
                AnimaceTextu("Procházíte městem, přes hustý prach nikomu nevidíte do obličeje.");
                AnimaceTextu("Rozhodnete se někoho zeptat na detaily tohoto místa, stále nemáte žádné podstatné infomrace...");
                AnimaceTextu("........");
                AnimaceTextu("Netrvalo dlouho a našli jste venkovní stánek s nerozeznatelnou osobou, vypadá to jako univerzální obchod.");
                AnimaceTextu("Rozhodnete se tedy osoby zeptat...");
                Tlacitko();
                Okradeni();
                PrimaRec("Prodavačka", "U Ďábelské Herny přece, jak byste mohl zapomenout!");
                PrimaRec("Prodavačka", "Rozhodně se tu nebudete nudit!");
                PrimaRec("Prodavačka", "A když už jste tady, třeba se Vám bude líbit něco z dnešní nabídky.");
                Tlacitko();
                NaplnDabObchod(DabelskyObchod);
                Obchod.Obchodovani(VasePostava.inventarPostavy, DabelskyObchod, "tržnici před Ďábelskou Hernou");
                Recepty.PridejReceptDoSeznamu(TvrobaPredmetu.RDryák_Sebevznícení);
                Recepty.PridejReceptDoSeznamu(TvrobaPredmetu.RPekelny_Bic);
                Recepty.PridejReceptDoSeznamu(TvrobaPredmetu.RPekelné_Pláty);

                Clear();
                ForegroundColor = ConsoleColor.Red;
                AnimaceTextu("Vypadá to, že žádné další infomrace nedostanete. Také nevíte, jestli jste tu vůbec vítáni...");
                AnimaceTextu(".....");
                Tlacitko();
                AnimaceTextu("Obavy hodíte za hlavu, jediné co zbývá je jít dále a zjistit více informací.");
                AnimaceTextu("Jdete k dalšímu stanovišti, pokusit se zjistit více.");
                AnimaceTextu("Když jste blíž, všímáte si, že se jedná o malou budovu s nápisem 'Mini-herna'");
                Past vsiml = new Past(8, VasePostava.hracovaPostava.vStesti, "štěstí", VasePostava.hracovaPostava.vJmeno);
                if(vsiml.Uspech())
                {
                    ForegroundColor = ConsoleColor.Green;
                    Clear();
                    WriteLine();
                    WriteLine("Také si všímáte drobného nápisu 'Vstup za 5 zlatých!'...");
                    Tlacitko();
                }
                else
                {
                    ForegroundColor = ConsoleColor.Red;
                    Clear();
                    WriteLine();
                    WriteLine("A to je vše, nic zvláštního na herně není...");
                    Tlacitko();
                }
                Menu herna = new Menu("Přejete si vejít do herny?", new List<string> { "Ano, jít do herny", "Ne, nechodit" }, ConsoleColor.Red);
                int h = herna.NavratIndexu();
                if (h == 0)
                {
                    HernaOPenize(5, 10, 4);
                    Clear();
                    ForegroundColor = ConsoleColor.Red;
                    AnimaceTextu("Vypadá to, že hraní o peníze je zábavné, ale žádné informace nepřináší.");
                    Tlacitko();
                }
                else
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Red;
                    AnimaceTextu("Žádná herna, žádné info, nevadí.");
                    Tlacitko();
                }
                ForegroundColor = ConsoleColor.Red;
                AnimaceTextu("Jdete dále a dále, zjišťujete, že město není nijak rozlehlé, vlastně je vcelku malé.");
                AnimaceTextu("Přicházíte k dalšímu stánku. Za stánkem je malá plocha, kde se právě pár osob učí různé věci.");
                AnimaceTextu("Na čele stánku je nápis 'Bojové učiliště' a vypadá to, že zde můžete zaplatit za zlepšení svých atributů.");
                AnimaceTextu("....");
                AnimaceTextu("Rozhodnete se tedy prodávajícího služeb zeptat na informace o městě...");
                Tlacitko();
                PrimaRec("Učitel umů", "Er? Vy jste tu poprvé? Hahá!");
                PrimaRec("Učitel umů", "Vtipálek Vy jste! Tak co se naučíme dnes?");
                Tlacitko();
                BojoveUceni(20, 40);
           }
            void VypnutiPrachu()
            {
                Clear();
                ForegroundColor = ConsoleColor.Red;
                AnimaceTextu("Vypadá to, že obyvatelé si myslí, že si z nich střílíte.");
                AnimaceTextu("Žádný z obchodníků Vám neposkytl užitečné informace. Nikdo také nevěděl, že nejste zdejší...");
                AnimaceTextu("......");
                AnimaceTextu("Nevíte, co přesně tedy dělat. Rozhodnete se tedy jít do centra celéha města - do Ďábelské Herny.");
                Tlacitko();
                ForegroundColor = ConsoleColor.Red;
                AnimaceTextu("Na Vaší krátké cestě do herny najednou slyšíte pisklavý zvuk, nasledován rozhlasem z nejvyššího patra herny:");
                Tlacitko();
                PrimaRec("Rozhlas", "Vážení! Vlhkost města je v normě, prach tedy vypínáme!");
                PrimaRec("Rozhlas", "Díky za trpělivost a zase za týden!");
                AnimaceTextu("......");
                Tlacitko();
                ForegroundColor = ConsoleColor.Red;
                AnimaceTextu("Na zem dopadají poslední kousky hustého, červeného prachu...");
                AnimaceTextu("Když dopadl ten poslední, ovzduší se pročistilo, dýchatelnost se zlepšila.");
                AnimaceTextu("S udivením sledujete, jak neobykle místní obytelé vypadají.");
                AnimaceTextu("Jejích pleť je většinově červená, nerozdílná od motivu a barev celého města.");
                AnimaceTextu("Někteří obyvatelé mají na hlavě rohu nebo otupené výběžky, ostatní zase mají kapuce.");
                AnimaceTextu("Chvíli stojíte na místě a prohlížíte si v udivení zbytek města, který jste konečně schopni vidět.");
                AnimaceTextu(".....");
                Tlacitko();
                ForegroundColor = ConsoleColor.Red;
                AnimaceTextu("Rozhodnete se pokračovat do Ďábelské Herny a změny si nějak výrazně nevšímáte.");
                AnimaceTextu("Když přijdete před hlavní dveře, pár osob z města vychází i vchází. Vstupem jsou dvojdveře, které se samy otevírají.");
                AnimaceTextu("....");
                AnimaceTextu("Projdete skrz a ocitnete se v dlouhé hale, která září neonovými nápisy a pestrými obrazy na zdech.");
                AnimaceTextu("Vnitřek vypadá vskutku luxusně, vzhledem k tomu, jak město vypadá mimo hernu, jste to rozhodně nečekali.");
                AnimaceTextu("Přijdete před oficiální vchod do místností herny a jste zastaveni místním vyhazovačem...");
                Tlacitko();
                PrimaRec("Rohatý Vyhazovač", "Dobrý den, frájo, prosíme vypráznit kapsy, musíme se podívat, jestli nenesete něco nebezpečného.");
                ForegroundColor = ConsoleColor.Red;
                AnimaceTextu("Jakmile větu dořekl, v pozadí nastal tlumený výbuch...");
                AnimaceTextu(".....");
                PrimaRec("Rohatý Vyhazovač", "Notak Kamikaze, přestaňte, nebo vás vyhodim!");
                PrimaRec("Rohatý Vyhazovač", "Heh, občas je tu trochu rušno... Vás jsem tady ještě neviděl, z jaký rodiny pocházíte?");
                PrimaRec("Rohatý Vyhazovač", "COŽE?! Nejste odsud? Šéf mě zabije... Počkejte chvilku.");
                Tlacitko();
                ForegroundColor = ConsoleColor.Red;
                AnimaceTextu("Vyhazovač vytáhne malou průhlednou kouli ze skryté kapsi ve své zbroji.");
                AnimaceTextu("Odstoupí si od Vás asi tři stopy a vidíte hologram někoho, kdo bude nejspíš jeho nadřízený.");
                AnimaceTextu("Baví se spolu asi dvě minuty, když skončí, zastrčí kuličku zpět do kapsy a jde zpět k Vám.");
                Tlacitko();
                PrimaRec("Rohatý Vyhazovač", "Tak jsem si pokecal se šéfem, a bude to následovně:");
                PrimaRec("Rohatý Vyhazovač", "Dovnitř sice nemůžete, ale prý se mám postarat, že Vaší mrtvolu odvezou vcelku.");
                PrimaRec("Rohatý Vyhazovač", "Což bude docela fuška, ale dokud nezkusím tak nevím...");
                PrimaRec("Rohatý vyhazovač", "KAMARÁDI! MÁME TU NÁVŠTĚVU!");
                AnimaceTextu(".......");
                Tlacitko();
                Okradeni();
            }
            void Boje()
            {
                ForegroundColor = ConsoleColor.Red;
                AnimaceTextu("Zákazníci herny se ve zmatku zastavují.");
                AnimaceTextu("Celá budova začne blikat červeně majákovým efektem, díky magickým lucernám, které signalizují nebezpečí.");
                AnimaceTextu("Občané se evakuují, zásahové jednotky Vám jdou naproti.");
                AnimaceTextu("Opravdu jste netušili, že Vaše přítomnost způsobí poplach celého města, avšak cizinci asi nejsou vítáni...");
                AnimaceTextu(".....");
                Tlacitko();
                Souboj(VasePostava.hracovaPostava, new RohatyVyhazovac(), true, true);
                Souboj(VasePostava.hracovaPostava, new DabelskaKamikaze(), false, false);
                Clear();
                ForegroundColor = ConsoleColor.Red;
                AnimaceTextu("Vyřídili jste Vyhazovače a komando, které bylo přivoláno ze zásahových jednotek.");
                AnimaceTextu("To určitě nebude vše, rozhodně počítáte s dalšími odpůrci Vaší přítomnosti.");
                AnimaceTextu("Hlavní dveře jsou zavřené, zpět do města nelze.");
                AnimaceTextu("Rozhodnete se tedy vydat do druhého patra, nic jiného nezbývá.");
                Tlacitko();
                AnimaceTextu("Pod schody potkáváte dalšího hlídače, který průchod hlídá, s ním je tam zvláštní létající stvoření.");
                AnimaceTextu("Stvoření je malé a vypadá, že jeho prací je vyhledat záškodníky, nebo narušitele pravidel a potrestat je...");
                AnimaceTextu(".....");
                Tlacitko();
                Souboj(VasePostava.hracovaPostava, new ZaskodnickyImp(), true, true);
                Souboj(VasePostava.hracovaPostava, new RohatyVyhazovac(), false, false);
                Clear();
                ForegroundColor = ConsoleColor.Red;
                AnimaceTextu("Běžíte po schodech, nahoře narážíte na opravdu mohutné dveře, které vypadají, že je jen ztěží otevřít.");
                AnimaceTextu("Na několikátý pokus se Vám to však podaří, dveře se rozrazí a po Vašem průchodu setrvačností zavřou.");
                AnimaceTextu(".....");
                Tlacitko();
                ForegroundColor = ConsoleColor.Red;
                AnimaceTextu("Po zavření dveří, jako byste byli úplně v jiném světě. Venkovní zvuk je potlačen, po chaosu ani stopy.");
                AnimaceTextu("Zákazníky Herny jsou tu naprosto v klidu, neovlivněni žádným rozruchem.");
                AnimaceTextu("Jedná se o dlouhou chodbu, s odbočkami do různých hern a jiných služeb.");
                AnimaceTextu("Zpomalíte tedy v chůzi, aby jste zapadli mezi ostatní.");
                AnimaceTextu("Jdete vpřed a pár jedninců do Vás narazí, při čemž si něco mumlají.");
                AnimaceTextu("Dojdete ke kusu vystuženého pergamenu v modře blikajícím rámu, kde vidíte následující zápis:");
                Tlacitko();
                PrimaRec("Historie rodu Ďábelských:", "Někteří z našich řad, ať už z kterékoholiv rodu, se narodili s vadou od vyšší síly - " +
                    "\nať už slepí, hluší, nebo obojí. Ani na takové nesmíme zapomínat a dopřát jim Ďábelksou zábavu! ", ConsoleColor.Blue);
                Tlacitko();
                Okradeni();
                ForegroundColor = ConsoleColor.Red;
                AnimaceTextu("Rozumíte tomu, někteří v tomto patře neslyší, jiní nevidí a ostatní mají obě tyto vady.");
                AnimaceTextu("Patro bylo postaveně výhradně pro ně, je tedy izolované od zbytku budovy a relativně dobře zabezpečené...");
                AnimaceTextu("Než se stihnete dojít na konec uličky, dveře se rozrazí a přichází Vás hledat další zásahová jednotka.");
                AnimaceTextu(".....");
                Tlacitko();
                ForegroundColor = ConsoleColor.Red;
                AnimaceTextu("Přes znakovou řeč se vyhazovač pokouší s neslyšícími a nevidomými domluvit, aby okamžitě opustili místo, mezitím se můžete pokusit schovat...");
                Tlacitko();
                Menu menu = new Menu("Chcete se pokusit schovat do herní místnosti před zásahovou jednotkou?", new List<string> { "Ano", "Ne" }, ConsoleColor.Blue);
                int m = menu.NavratIndexu();
                if(m == 0)
                {
                    Past p = new Past(10, VasePostava.hracovaPostava.vObratnost, "obratnost", VasePostava.hracovaPostava.vJmeno);
                    if(p.Uspech())
                    {
                        Clear();
                        ForegroundColor = ConsoleColor.Green;
                        WriteLine();
                        WriteLine("Podařilo se Vám do herny včas schovat!");
                        WriteLine();
                        WriteLine("Také jste údajně dnešní tisícátý zákazník. Vstup je údajně zdarma.");
                        WriteLine();
                        Thread.Sleep(250);
                        WriteLine("Víte, že o peníze hrát nemusíte, stačí v herně jen přečkat.");
                        Inventar.PridejZlato(5, VasePostava.inventarPostavy);
                        Tlacitko();
                        HernaOPenize(1, 8, 5);
                        Clear();
                        ForegroundColor = ConsoleColor.Red;
                        AnimaceTextu("V herně byl dealer slepý - což jste ostatně poznali hned, když nijak nereagoval na Vaše vtrhnutí do dveří.");
                        AnimaceTextu("Přečkali jste tedy v tichosti i prohlídku komanda. Vyhazovač řekl, že to tu pro jistotu bude hlídat.");
                        AnimaceTextu("Ostatní se odebrali k odchodu, včetně dealera. Zbývá Vám tedy jen jeden souboj...");
                        Tlacitko();
                        Souboj(VasePostava.hracovaPostava, new RohatyVyhazovac(), false, true);

                    }
                    else
                    {
                        Clear();
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine();
                        WriteLine("Nepodařilo se Vám včas schovat. Souboj tedy musíte zvládnout...");
                        Tlacitko();
                        Souboje();
                    }
                }
                else
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Red;
                    AnimaceTextu("Rozhodli jste se neschovávat, souboj je tedy na Vás.");
                    Tlacitko();
                    Souboje();

                }
                void Souboje()
                {
                    Souboj(VasePostava.hracovaPostava, new ZaskodnickyImp(), true, true);
                    Souboj(VasePostava.hracovaPostava, new RohatyVyhazovac(), true, false);
                    Souboj(VasePostava.hracovaPostava, new RohatyVyhazovac(), false, false);
                }
            }
            void FinalAKlic()
            {
                Clear();
                ForegroundColor = ConsoleColor.Red;
                AnimaceTextu("Vypadá to, že na patře jste zůstali sami.");
                AnimaceTextu("Celá herna najednou utichne, neonové nápisy zhasnou a neslyšíte ani krok.");
                AnimaceTextu("Když jste si jisti, že Vás nemáte společnost, rozhodnete se pokusit dostat ven.");
                AnimaceTextu("Po Vaší pravici naleznete těsně nad schodištěm malou místnost, která je však zamčená...");
                Tlacitko();
                if (VasePostava.inventarPostavy.MaPredmet(Klíč_k_Zábavě))
                {
                    ForegroundColor = ConsoleColor.Green;
                    VasePostava.inventarPostavy.OdeberPredmet(Klíč_k_Zábavě);
                    WriteLine();
                    WriteLine("Použili jste Klíč k Zábavě a dveře se otevřeli, výborně...");
                    WriteLine();
                    Thread.Sleep(350);
                    WriteLine("V místnosti nalézáte spoustu zajímavých věcí!");
                    Tlacitko();
                    Loot(VsechnyAlchSuroviny, 4);
                    Loot(VsechnyPouzitelne, 3);
                    StatovaKniha(4);
                    StatovaKniha(2);
                    Clear();
                    ForegroundColor = ConsoleColor.Yellow;
                    WriteLine();
                    WriteLine("Také jste našli 35 zlata!");
                    Inventar.PridejZlato(35, VasePostava.inventarPostavy);
                    Tlacitko();
                    ForegroundColor = ConsoleColor.DarkRed;
                    WriteLine();
                    WriteLine("V neposlední řadě jste zde také našli zvláštní amulet, naleznete jej v inventáři...");
                    VasePostava.inventarPostavy.PridejPredmet(Ďábelský_totem_rovnováhy);
                    Tlacitko();
                }
                else
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine();
                    WriteLine("Bohužel nemáte žádný klíč, který by pasoval do zámku. Dveře tedy zůstávají uzavřeny...");
                    Tlacitko();
                }
                ForegroundColor = ConsoleColor.Red;
                AnimaceTextu("Pokračujete dolů po schodech, dofuáte, že se zvládnete z herny dostat ven a teleportovat se jinam. Máte toho tak akorát.");
                AnimaceTextu("Dole je opravdu prázno, po zákaznících i krupiérech zbyl jen nepořádek a zavřené dveře.");
                AnimaceTextu("Uleví se Vám a vydáváte se k hlavním dveřím...");
                Tlacitko();
                PrimaRec("Vedoucí Herny", "Co si myslíte že děláte a kdo si myslíte že jste?!");
                PrimaRec("Vedoucí Herny","Ano, na Vás mluvim! Prodělal jste mi tu dneska nejméně padesát tisíc zlatých!");
                PrimaRec("Vedoucí Herny", "A Herna je otevřená jen jednou týdně, v den prachování města! Zničil jste mi moje příjmy!");
                PrimaRec("Vedoucí Herny", "Já se na to můžu vy...");
                PrimaRec("Vedoucí Herny", "Víte vy co, to je jedno, tady jsou papíry od podniku, buď Vás dneska zabiju, nebo Vám tuhle barabiznu přenechám.");
                Tlacitko();
                ForegroundColor = ConsoleColor.Red;
                AnimaceTextu("Vedoucí hodil na stůl papíry, které si vytáhl z kapsy od saka. Tasí zbraň a ztrácí trpělivost...");
                Tlacitko();
                Souboj(VasePostava.hracovaPostava, new CEODabelskeHerny(), false, true);
                Clear();
                ForegroundColor = ConsoleColor.Red;
                AnimaceTextu("Ředitel podniku byl poražen, podnik je Váš. Určitě se Vám ho povede obnovit!");
                Tlacitko();
                ForegroundColor = ConsoleColor.Magenta;
                WriteLine();
                WriteLine($"Gratulace k dokončení lokace {VytvoreneLokace.Dabelska_Herna.NazevLokace}!");
                Tlacitko();
                Okradeni();
                DokonciLokaci(Dabelska_Herna);
                DokonciFinalneLokaci(Dabelska_Herna);
                OdemkniLokace(Skoro_Legální_Dábelské_Casino);
                
            }

        }



        static bool prvniNavstevaP = true;
        public static bool DoplnenDabInv = false;
        static Inventar hernaInv = new Inventar();
        static List<Predmety> SeznamPD = new List<Predmety>() {Dryak_Sebevzniceni, Pekelne_Platy, Pekelny_Bič, Ohnivá_Koule, Ohnivý_Prach, Dračí_Květ};
        public static void SkoroLegalniPekelneCasino()
        {
            Clear();
            ForegroundColor = ConsoleColor.Red;
            if(prvniNavstevaP)
            {
                prvniNavstevaP = false;
                AnimaceTextu("Porazili jste kapitána a organizátora celého komplexu Pekelné Herny.");
                AnimaceTextu("Dle práva silnějšího, jste v čele Vy.");
                AnimaceTextu("Neznamená to ale úplnou volnost, stále musíte dodržovat relativně přísná pravidla pro působení.");
                AnimaceTextu("To především znamená mít dosatatek peněz na využívání služeb ďábelských...krupiérů a organizátorů celkově.");
                AnimaceTextu("K místu máte přístup kdykoliv mezi Vašimi výpravami.");
                AnimaceTextu("Příjemnou zábavu!");
                AnimaceTextu(".....");
                Tlacitko();
            }
            if (!DoplnenDabInv)
                DoplneniInventareFull(hernaInv, SeznamPD);
            VyberAktivityCasino();
            
            void VyberAktivityCasino()
            {
                while (true)
                {
                    Menu vyber = new Menu("Vyberte si aktivitu v Ďábelském Casinu!", new List<string> { "Poctivá herna o zlato", "Poctivé učení se dovednostem", "Poctivé obchodování", "Poctivé najmutí vyhazovače", "Poctivě odejít" }, ConsoleColor.Red);
                    int v = vyber.NavratIndexu();
                    if (v == 0)
                        VyberHerny();
                    else if (v == 1)
                        BojoveUceni(30, 60);
                    else if (v == 2)
                        Obchod.Obchodovani(VasePostava.inventarPostavy, hernaInv, "tom nejpoctivějším obchodě pod Sluncem!", 0.6);
                    else if (v == 3)
                        NajmutiSpol();
                    else break;
                    
                }
                void VyberHerny()
                {                   
                    Clear();                   
                    while(true)
                    {
                        Menu herny = new Menu("Vyberte si násobitel výhry (čím vyšší, tím těžší je vyhrát)", new List<string> { "2x", "3x", "4x", "5x", "10x", "100x (odejdete bez zlata)", "Raději odejít" }, ConsoleColor.Red);
                        int h = herny.NavratIndexu();
                        if (h == 0)
                            HernaOPenize(1, 3, 2);
                        else if (h == 1)
                            HernaOPenize(1, 5, 3);
                        else if (h == 2)
                            HernaOPenize(1, 7, 4);
                        else if (h == 3)
                            HernaOPenize(1, 9, 5);
                        else if (h == 4)
                            HernaOPenize(1, 19, 10);
                        else if (h == 5)
                            HernaOPenize(1, 150, 100);
                        else break;

                    }
                }
                void NajmutiSpol()
                {
                    int Cena = 25;
                    while (true)
                    {
                        Menu spolecnikS = new Menu($"Přejete si najmout Rohatého Vyhazovače jako společníka? (tento společník nemizí, když souboj skončí a stojí {Cena} zlatých)\n\nNyní máte {VasePostava.inventarPostavy.PocetZlata()} zlata", new List<string> { "Ano", "Ne" }, ConsoleColor.DarkYellow);
                        int v = spolecnikS.NavratIndexu();
                        if (v == 1)
                            break;
                        else
                        {

                            if (VasePostava.spolecnik != null && VasePostava.inventarPostavy.PocetZlata() >= Cena)
                            {
                                Clear();
                                Menu m = new Menu($"Vypadá to, že již máte společníka ({VasePostava.spolecnik.nazevStvoreni}). Přejete si ho zaměnit za nového společníka Rohatého Vyhazovače?", new List<string> { "Ano", "Ne" }, ConsoleColor.Red);
                                int t = m.NavratIndexu();
                                if (t == 0)
                                {
                                    Inventar.OdeberZlato(Cena, VasePostava.inventarPostavy);
                                    VasePostava.spolecnik = new RohatyVyhazovac();
                                    Clear();
                                    ForegroundColor = ConsoleColor.DarkRed;
                                    WriteLine();
                                    WriteLine("Výbroně, Rohatý Vyhazovač je nyní Váš společník...");
                                    Tlacitko();
                                }
                                else break;
                            }
                            else if (VasePostava.spolecnik == null && VasePostava.inventarPostavy.PocetZlata() >= Cena)
                            {
                                Inventar.OdeberZlato(Cena, VasePostava.inventarPostavy);
                                VasePostava.spolecnik = new RohatyVyhazovac();
                                Clear();
                                ForegroundColor = ConsoleColor.DarkRed;
                                WriteLine();
                                WriteLine("Výbroně, Rohatý Vyhazovač je nyní Váš společník...");
                                Tlacitko();
                            }
                            else
                            {
                                Clear();
                                ForegroundColor = ConsoleColor.Red;
                                WriteLine();
                                WriteLine($"Vypadá to, že na Rohatého Vyhazovače nemáte dost peněz. Stojí {Cena} zlatých a Vy máte jen {VasePostava.inventarPostavy.PocetZlata()}.");
                                Tlacitko();
                            }
                        }

                    }

                }
            }
            void DoplneniInventareFull(Inventar invKdoplneni3x, List<Predmety> doplnuji)
            {
                    DoplnenDabInv = true;
                foreach (Predmety P in doplnuji)
                {
                    if (P.pocetPredmetu(invKdoplneni3x) < 5)
                    {
                        while (P.pocetPredmetu(invKdoplneni3x) < 5)
                        {
                            invKdoplneni3x.PridejPredmet(P);

                        }
                    }
                }

            }
        }
    }

}
