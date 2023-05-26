using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static System.Console;
using static DnD_Hra.VytvorenePredmety;

namespace DnD_Hra
{
    static class Ability2Z
    {
        //Zbraněěě-------------------------------------------------------------------------------------------------------------------------------------
        public static void WDexZaStr(bool Abilita_Postavy)
        {
            byte SilaZaObr = 1;
            WriteLine();
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Cyan;

            if (Abilita_Postavy == true)
            {
                VasePostava.hracovaPostava.vSila -= SilaZaObr;
                VasePostava.hracovaPostava.vObratnost += SilaZaObr;
                WriteLine($"Díky původu Vaší zbraně dočasně měníte obratnost za sílu! (+{SilaZaObr} k obratnosti a -{SilaZaObr} k síle.)");
                WriteLine();
                Thread.Sleep(350);
                WriteLine($"Nyní má {VasePostava.hracovaPostava.vJmeno} {VasePostava.hracovaPostava.vObratnost} obratnosti a {VasePostava.hracovaPostava.vSila} síly");
            }

            else
            {
                VasePostava._aktualniNepritel.sSila -= SilaZaObr;
                VasePostava._aktualniNepritel.sObratnost += SilaZaObr;
                WriteLine($"Díky původu zbraně mění Váš soupeř obratnost za sílu! (+{SilaZaObr} k obratnosti a -{SilaZaObr} k síle.)");
                WriteLine();
                Thread.Sleep(350);
                WriteLine($"Nyní má {VasePostava._aktualniNepritel.nazevStvoreni} {VasePostava._aktualniNepritel.sObratnost} obratnosti a {VasePostava._aktualniNepritel.sSila} síly");
            }
            Thread.Sleep(250);

        }
        public static void WSnizeniDex(bool Abilita_Postavy)
        {
            byte ObrDeb = 1;
            WriteLine();
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.DarkGreen;

            if (Abilita_Postavy == true)
            {
                
                VasePostava.hracovaPostava.vObratnost -= ObrDeb;
                WriteLine($"Díky tíze Vaší zbraně dočasně ztrácíte obratnost (-{ObrDeb} k obratnosti)");
                WriteLine();
                Thread.Sleep(350);
                WriteLine($"Nyní má {VasePostava.hracovaPostava.vJmeno} {VasePostava.hracovaPostava.vObratnost} obratnosti.");
            }

            else
            {
                
                VasePostava._aktualniNepritel.sObratnost -= ObrDeb;
                WriteLine($"Díky tíze zbraně ztrácí Váš soupeř obratnost (-{ObrDeb} k obratnosti)");
                WriteLine();
                Thread.Sleep(350);
                WriteLine($"Nyní má {VasePostava._aktualniNepritel.nazevStvoreni} {VasePostava._aktualniNepritel.sObratnost} obratnosti.");
            }
            Thread.Sleep(250);

        }
        public static void WProkletaCepel(bool Abilita_Postavy)
        {
            byte ZivotyDown = 4;
            WriteLine();
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.DarkRed;

            if (Abilita_Postavy == true)
            {
                VasePostava.hracovaPostava.vZdravi -= ZivotyDown;
                WriteLine($"Díky schopnosti této zbraně Vám byla dočasně odebrána část životní síly (- {ZivotyDown} zdraví)");
                WriteLine();
                Thread.Sleep(350);
                WriteLine($"Nyní má {VasePostava.hracovaPostava.vJmeno} {VasePostava.hracovaPostava.vZdravi} zdraví");
            }

            else
            {
                VasePostava._aktualniNepritel.sZdravi -= ZivotyDown;
                WriteLine($"Díky schopnosti této zbraně soupeři byla odebrána část životní síly (- {ZivotyDown} zdraví)");
                Thread.Sleep(350);
                WriteLine();
                WriteLine($"Nyní má {VasePostava._aktualniNepritel.nazevStvoreni} {VasePostava._aktualniNepritel.sZdravi} zdraví.");
            }
            Thread.Sleep(250);

        }
        public static void WOhnivýÚtok2(bool Abilita_Postavy)
        {
            byte _OhenPos = 1;
            WriteLine();
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Yellow;
           
            if (Abilita_Postavy == true)
            {
                VasePostava.hracovaPostava.poskozeni += _OhenPos;
                WriteLine($"Váš útok byl díky schopnosti zbraně navíc posílen silou ohně! (+ {_OhenPos} poškození)");
            }
                
            else
            {
                VasePostava._aktualniNepritel.poskozeni += _OhenPos;
                 WriteLine($"Protivníkův útok byl díky schopnosti zbraně navíc posílen silou ohně! (+ {_OhenPos} poškození)");
            }           
            Thread.Sleep(250);
            
        }
        public static void WStasneBodnuti2(bool Abilita_Postavy)//Add štěstí
        {
            byte _StestiPos = 2;
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine();
            if (Abilita_Postavy == true)
            {

                WriteLine($"Díky schopnosti zbraně se Vám navíc dočasně přidalo štěstí! (+ {_StestiPos} štěstí)");
                VasePostava.hracovaPostava.vStesti += _StestiPos;
                WriteLine();
                Thread.Sleep(250);
                WriteLine("{0} má nyní {1} štěstí!", VasePostava.hracovaPostava.vJmeno, VasePostava.hracovaPostava.vStesti);
            }
            else
            {
                WriteLine($"Díky schopnosti zbraně se soupeři navíc dočasně přidalo štěstí! (+ {_StestiPos} štěstí)");
                VasePostava._aktualniNepritel.sStesti += _StestiPos;
                WriteLine();
                Thread.Sleep(250);
                WriteLine("{0} má nyní {1} štěstí!", VasePostava._aktualniNepritel.nazevStvoreni, VasePostava._aktualniNepritel.sStesti);
            }
                          
            Thread.Sleep(250);

        }
        public static void WSmaragdoveKopi(bool Abilita_Postavy)
        {
            byte _SilaPos = 1;
            byte _StestiPos = 1;
            WriteLine();
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.DarkCyan;

            if (Abilita_Postavy == true)
            {
                VasePostava.hracovaPostava.vSila += _SilaPos;
                VasePostava.hracovaPostava.vStesti += _StestiPos;
                WriteLine($"Díky schopnosti Vaší zbraně se Vám zvýšila síla a štěstí o 1!");
                WriteLine();
                Thread.Sleep(300);
                WriteLine($"Nyní má {VasePostava.hracovaPostava.vJmeno} {VasePostava.hracovaPostava.vSila} síly a {VasePostava.hracovaPostava.vStesti} štěstí.");
            }

            else
            {
                VasePostava._aktualniNepritel.sSila += _SilaPos;
                VasePostava._aktualniNepritel.sStesti += _StestiPos;
                WriteLine($"Díky schopnosti zbraně Vašeho nepřítele se jim zvýšila síla a štěstí o 1!");
                Thread.Sleep(300);
                WriteLine();
                WriteLine($"Nyní má {VasePostava._aktualniNepritel.nazevStvoreni} {VasePostava._aktualniNepritel.sSila} síly a {VasePostava._aktualniNepritel.sStesti} štěstí.");
            }
            Thread.Sleep(250);

        }
        public static void WKoboldSummon(bool Abilita_Postavy)
        {
            
            WriteLine();
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Cyan;

            if (Abilita_Postavy == true)
            {
                if(VasePostava.spolecnik == null)
                {
                    WriteLine($"Díky schopnosti Vaší zbraně se Drzý Kobold stal Vašim společníkem!");
                    VasePostava.spolecnik = new Kobold();
                }
                else
                {
                    int zvyseni = (int)(VasePostava.hracovaPostava.poskozeni * 0.25);
                    WriteLine($"Jelikož už společníka máte, všechny jeho staty se zvyšují o {zvyseni}!");
                    VasePostava.spolecnik.sSila += zvyseni;
                    VasePostava.spolecnik.sObratnost += zvyseni;
                    VasePostava.spolecnik.sInteligence += zvyseni;
                    VasePostava.spolecnik.sStesti += zvyseni;
                    VasePostava.spolecnik.sUtocnaHodnota += zvyseni;
                    VasePostava.spolecnik.sObrannaHodnota += zvyseni;
                    if (VasePostava.spolecnik.sObratnost > 45)
                        VasePostava.spolecnik.sObratnost = 45;
                }                
            }           

        }
        public static void WAtkDamagePodPul(bool Abilita_Postavy)
        {

            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Red;

            if (Abilita_Postavy == true)
            {
                if (VasePostava.hracovaPostava.vZdravi  >= (int)(VasePostava.hracovaPostava.zdraviPostavy * 0.5))
                    return;
                else
                {
                    int zvyseni = (int)(VasePostava.hracovaPostava.vUtocnaHodnota * 0.5);
                    VasePostava.hracovaPostava.vUtocnaHodnota += zvyseni;
                     WriteLine();
                    WriteLine($"Vaše zdraví je pod polovinou. Díky schopnosti Vaší zbraně se útočná hodnota zvyšuje o {zvyseni}!");
                    
                }
            }
            else if(!Abilita_Postavy)
            {
                if (VasePostava._aktualniNepritel.sZdravi >= (int)(VasePostava._aktualniNepritel.maxZdravi * 0.5))
                    return;
                else
                {
                    int zvyseni = (int)(VasePostava._aktualniNepritel.sUtocnaHodnota * 0.5);
                    VasePostava._aktualniNepritel.sUtocnaHodnota += zvyseni;
                    WriteLine($"Zdraví nepřítele je pod polovinou. Díky schopnosti jejich zbraně se útočná hodnota zvyšuje o {zvyseni}!");

                }
            }

        }
        public static void DemonickaSavle(bool Abilita_Postavy)
        {

            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Red;
            if (!Abilita_Postavy) return;
            if (Abilita_Postavy == true)
            {               
               
                    int heal = (int)(VasePostava.hracovaPostava.poskozeni * 0.5);
                    VasePostava.hracovaPostava.vZdravi += heal;
                if (VasePostava.hracovaPostava.vZdravi > VasePostava.hracovaPostava.zdraviPostavy)
                    VasePostava.hracovaPostava.vZdravi = VasePostava.hracovaPostava.zdraviPostavy;
                     WriteLine();
                    WriteLine($"Díky schopnosti zbraně jste z cíle vysáli životní sílu. Léčíte si tak {heal} zdraví, pokud Vám chybí!");

              
            }           

        }
        public static int bleed = 0;
        public static void RemdichKrvavychMuk(bool Abilita_Postavy)
        {

            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Red;
            if (!Abilita_Postavy) return;
            if (Abilita_Postavy == true)
            {
                bleed += 2;                           
                WriteLine();
                WriteLine($"Vaše zbraň postupně načerpává sílu z bolesti nepřátel.");
                WriteLine();
                Thread.Sleep(250);
                WriteLine($"Nyní způsobí {bleed} přímého poškození nepříteli...");
                VasePostava._aktualniNepritel.sZdravi -= bleed;
            }

        }
        public static void NuzOsudu(bool Abilita_Postavy)
        {

            Random r = new Random();
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Red;
            if (!Abilita_Postavy) return;
            if (Abilita_Postavy == true)
            {
                int ra = r.Next(1, 5);
                if(ra == 4)
                        {
                    WriteLine();
                    WriteLine("Je tu vždy šance, že soupeř bude o krok blíž ke smrti...");
                    WriteLine();
                    WriteLine("A ta právě nastala. Životy Vašeho nepřítele se snižují na polovinu.");
                    VasePostava._aktualniNepritel.sZdravi /= 2;
                }
            }

        }
        public static void RouchoNesmrtelnosti(bool Abilita_Postavy)
        {

            Random r = new Random();
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Red;
            if (!Abilita_Postavy) return;
            if (Abilita_Postavy == true)
            {
                int ra = r.Next(1, 5);
                if (ra == 4)
                {
                    WriteLine();
                    WriteLine("Někdy se nám podaří před smrtí utéct ještě dál...");
                    WriteLine();
                    WriteLine("Vaše zdraví se léčí do maxima.");
                    VasePostava.hracovaPostava.vZdravi = VasePostava.hracovaPostava.zdraviPostavy;
                }
            }

        }
        public static void DNP(bool Abilita_Postavy)
        {

            Random r = new Random();
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Red;
            if (!Abilita_Postavy) return;
            if (Abilita_Postavy == true)
            {
                if (VasePostava.hracovaPostava.vUtocnaHodnota <= 0)
                    return;
                
                     WriteLine();
                  WriteLine("Vaše zbroj udělá vše pro to, aby chránila svého vlastníka.");
                  WriteLine();
                  Thread.Sleep(350);
                  WriteLine("Konvertuje tak všechnu Vaši útočnou hodnotu na obrannou...");
                  WriteLine();
                VasePostava.hracovaPostava.vObrannaHodnota += VasePostava.hracovaPostava.vUtocnaHodnota;
                VasePostava.hracovaPostava.vUtocnaHodnota = 0;
                WriteLine($"Nyní máte {VasePostava.hracovaPostava.vObrannaHodnota} obranné hodnoty.");
            }

        }
        public static void Krucifix(bool Abilita_Postavy)
        {

            Random r = new Random();
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Red;
            if (!Abilita_Postavy) return;
            if (Abilita_Postavy == true)
            {
                if(VasePostava._aktualniNepritel.sZdravi < (int)(VasePostava._aktualniNepritel.maxZdravi*0.15))
                {
                    WriteLine();
                    WriteLine("Ti, co jsou na pokraji smrt budou ze světa zprovozeni...");
                    WriteLine();
                    Thread.Sleep(350);
                    WriteLine("Zdraví Vašeho nepřítele je pod 15% jeho maximálního zdraví, Krucifix naruby ho tedy popravuje.");
                    WriteLine();
                    VasePostava._aktualniNepritel.sZdravi = 0;
                }
            }
            else
            {
                if (VasePostava.hracovaPostava.vZdravi < (int)(VasePostava.hracovaPostava.zdraviPostavy * 0.15))
                {
                    WriteLine();
                    WriteLine("Ti, co jsou na pokraji smrt budou ze světa zprovozeni...");
                    WriteLine();
                    Thread.Sleep(350);
                    WriteLine("Vaše zdraví je pod 15% Vašeho maximálního zdraví, Krucifix naruby Vás tedy popravuje.");
                    WriteLine();
                    VasePostava.hracovaPostava.vZdravi = 0;
                }
            }

        }

        //Zbrojee-------------------------------------------------------------------------------------------------------------------------------------------------
        public static void LichovoRoucho(bool Abilita_Postavy)
        {
            byte PridaniHP = 2;
            byte PridaniOH = 1;
            int Sance50 = new Random().Next(0, 2);
            WriteLine();
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Red;
            if (Abilita_Postavy == true)
            {
                if(Sance50 == 0)
                VasePostava._aktualniNepritel.sObrannaHodnota += PridaniOH;
                VasePostava._aktualniNepritel.sZdravi += PridaniHP;
                if (Sance50 == 0)
                WriteLine($"Kvůli schopnosti zbroje si soupeř vyléčil zdraví, jestli nějaké chybí (+{PridaniHP} zdraví) a zvýšil obranu (+{PridaniOH} obranná hodnota)");
                else
                WriteLine($"Kvůli schopnosti zbroje Vašeho soupeře si soupeř vyléčil zdraví, pokud mu nějaké chybí (+{PridaniHP} zdraví)");
                WriteLine();
                if (VasePostava._aktualniNepritel.sZdravi > VasePostava._aktualniNepritel.maxZdravi)
                    VasePostava._aktualniNepritel.sZdravi = VasePostava._aktualniNepritel.maxZdravi;
                if (Sance50 == 0)
                    WriteLine("{0} má nyní {1} zdraví a {2} obranné hodnoty!", VasePostava._aktualniNepritel.nazevStvoreni, VasePostava._aktualniNepritel.sZdravi,
                        VasePostava._aktualniNepritel.sObrannaHodnota);
                else
                    WriteLine("{0} má nyní {1} zdraví!", VasePostava._aktualniNepritel.nazevStvoreni, VasePostava._aktualniNepritel.sZdravi);
            }

            else
            {
                if(Sance50 == 0)
                VasePostava.hracovaPostava.vObrannaHodnota += PridaniOH;
                VasePostava.hracovaPostava.vZdravi += PridaniHP;
                if(Sance50 ==0)
                WriteLine($"Kvůli schopnosti zbroje se Vám po útoku vyléčilo zdraví, jestli nějaké chybí (+{PridaniHP} zdraví) a zvýšila obranna (+{PridaniOH} obranná hodnota)");
                else
                WriteLine($"Kvůli schopnosti Vaší zbroje se Vám po útoku vyléčilo zdraví, pokud Vám nějaké chybí (+{PridaniHP} zdraví)");
                WriteLine();
                if (VasePostava.hracovaPostava.vZdravi > VasePostava.hracovaPostava.zdraviPostavy)
                    VasePostava.hracovaPostava.vZdravi = VasePostava.hracovaPostava.zdraviPostavy;
                if (Sance50 == 0)
                    WriteLine("{0} má nyní {1} zdraví a {2} obranné hodnoty!", VasePostava.hracovaPostava.vJmeno, VasePostava.hracovaPostava.vZdravi,
                   VasePostava.hracovaPostava.vObrannaHodnota);
                else
                    WriteLine("{0} má nyní {1} zdraví!", VasePostava.hracovaPostava.vJmeno, VasePostava.hracovaPostava.vZdravi);

            }  
        }
        public static void AOdražení25(bool Abilita_Postavy)//Odražení
        {
            WriteLine();
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.DarkMagenta;

            if (Abilita_Postavy == false)
            {
                int _Odrazeni25 = (int)(VasePostava._aktualniNepritel.poskozeni * 0.25);
                VasePostava._aktualniNepritel.sZdravi -= _Odrazeni25;
                WriteLine($"Díky schopnosti Vaší zbroje soupeřův útok způsobí navíc 25% poškození jemu samému!");
                WriteLine();
                WriteLine("{0} sám sobě způsobil {1} poškození a nyní má {2} zdraví.", VasePostava._aktualniNepritel.nazevStvoreni, _Odrazeni25, VasePostava._aktualniNepritel.sZdravi);
            }

            else
            {
                int _Odrazeni25 = (int)(VasePostava.hracovaPostava.poskozeni * 0.25);
                VasePostava.hracovaPostava.vZdravi -= _Odrazeni25;
                WriteLine($"Díky schopnosti soupeřovi zbroje Váš útok způsobí navíc 25% poškození Vám samotným!");
                WriteLine();
                WriteLine("{0} sám sobě způsobil {1} poškození a nyní má {2} zdraví.", VasePostava.hracovaPostava.vJmeno, _Odrazeni25, VasePostava.hracovaPostava.vZdravi);
            }
            Thread.Sleep(250);

        }
        public static void ARedukceObratnostiDrzitele(bool Abilita_Postavy)
        {
            int redukceObratnosti = 1;
            WriteLine();
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.DarkMagenta;           
            if (Abilita_Postavy == true)
            {
                VasePostava._aktualniNepritel.sObratnost -= redukceObratnosti;
                WriteLine($"Kvůli negativní schopnosti zbroje Vašeho soupeře se mu po útoku snížila obratnost (-{redukceObratnosti} k obratonsti)");
                WriteLine();
                WriteLine("{0} má nyní {1} obratnosti!", VasePostava._aktualniNepritel.nazevStvoreni, VasePostava._aktualniNepritel.sObratnost);               
            }

            else
            {           
                VasePostava.hracovaPostava.vObratnost -= redukceObratnosti;
                WriteLine($"Kvůli negativní schopnosti Vaší zbroje se vám po útoku dočasně snížila obratnost (-{redukceObratnosti} k obratonsti)");
                WriteLine();
                WriteLine("{0} má nyní {1} obratnosti!", VasePostava.hracovaPostava.vJmeno, VasePostava.hracovaPostava.vObratnost);                               
            }
            Thread.Sleep(250);

        }

        //W+A sety
        public static void SrpVetesnice(bool Abilita_Postavy)
        {
            if (VasePostava.zbrojPostavy != Tunika_Vetešnice && Abilita_Postavy)
                return;
            if (VasePostava._aktualniNepritel.zbrojStvoreni != Tunika_Vetešnice && !Abilita_Postavy)
                return;
            byte snizeniOH = 1;
            WriteLine();
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Yellow;

            if (Abilita_Postavy == true)
            {

                VasePostava._aktualniNepritel.sObrannaHodnota -= snizeniOH;
                if (VasePostava._aktualniNepritel.sObrannaHodnota < 0)
                    VasePostava._aktualniNepritel.sObrannaHodnota = 0;
                WriteLine($"Díky setové schopnosti Vaší zbraně jste soupeři snížili obrannou hodnotu, pokud už není 0. (-1 obranné hodnoty)");
                WriteLine();
                Thread.Sleep(350);
                WriteLine($"Nyní má {VasePostava._aktualniNepritel.nazevStvoreni} {VasePostava._aktualniNepritel.sObrannaHodnota} obranné hodnoty.");
            }

            else
            {
                if(!DndHerniFunkce._UtokNaSpolecnika)
                {

                    VasePostava.hracovaPostava.vObrannaHodnota -= snizeniOH;
                    if (VasePostava.hracovaPostava.vObrannaHodnota < 0)
                        VasePostava.hracovaPostava.vObrannaHodnota = 0;
                    WriteLine($"Díky setové schopnosti zbraně Vám soupeř snížil obrannou hodnotu, pokud už není 0. (-1 obranné hodnoty)");
                    WriteLine();
                    Thread.Sleep(350);
                    WriteLine($"Nyní má {VasePostava.hracovaPostava.vJmeno} {VasePostava.hracovaPostava.vObrannaHodnota} obranné hodnoty.");
                }
                else
                {
                    VasePostava.spolecnik.sObrannaHodnota -= snizeniOH;
                    if (VasePostava.spolecnik.sObrannaHodnota < 0)
                        VasePostava.spolecnik.sObrannaHodnota = 0;
                    WriteLine($"Díky setové schopnosti zbraně soupeř snížil obrannou hodnotu Vašemu společníkovi, pokud už není 0. (-1 obranné hodnoty)");
                    WriteLine();
                    Thread.Sleep(350);
                    WriteLine($"Nyní má {VasePostava.spolecnik.nazevStvoreni} {VasePostava.spolecnik.sObrannaHodnota} obranné hodnoty.");
                }
            }
            Thread.Sleep(250);
        }
        public static void TunikaVetešnice(bool Abilita_Postavy)
        {
            if (VasePostava.zbranPostavy != Srp_Vetešnice && !Abilita_Postavy)
                return;
            if (VasePostava._aktualniNepritel.zbranStvoreni != Srp_Vetešnice && Abilita_Postavy)
                return;
            WriteLine();
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.DarkYellow;
            List<Predmety> itemy = NahodnyVyberKategoriePredmetu();
            Predmety randomItem = itemy[new Random().Next(0, itemy.Count - 1)];
            if (Abilita_Postavy == false)
            {                
                WriteLine($"Díky setové schopnosti Vaší zbroje ve velké kapse tuniky náhle nacházíte náhodný předmět!");
                WriteLine();
                WriteLine($"Nacházíte předmět {randomItem.nazevPredmetu}! Naleznete ho v inventáři.");
                VasePostava.inventarPostavy.PridejPredmet(randomItem);
            }

            else
            {             
                WriteLine($"Díky setové schopnosti zbroje soupeř rychle v kapse tuniky nachází náhodný předmět!");
                WriteLine();
                WriteLine("Pokud soupeře zabijete, možná bude předmět Váš...");
                WriteLine();
                VasePostava._aktualniNepritel.seznamPredmetu.Add(randomItem);
                
            }
            Thread.Sleep(250);

        }
        public static void PekelnyBic(bool Abilita_Postavy)
        {
            if (VasePostava.zbrojPostavy != Pekelne_Platy && Abilita_Postavy)
                return;
            if (VasePostava._aktualniNepritel.zbrojStvoreni != Pekelne_Platy && !Abilita_Postavy)
                return;
            byte snizeniOI = 1;
            byte zvyseniSS = 2;
            WriteLine();
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Red;

            if (Abilita_Postavy == true)
            {

                VasePostava.hracovaPostava.vObratnost -= snizeniOI;
                VasePostava.hracovaPostava.vInteligence -= snizeniOI;
                VasePostava.hracovaPostava.vSila += zvyseniSS;
                VasePostava.hracovaPostava.vStesti += zvyseniSS;
                WriteLine($"Díky setové schopnosti Vaší zbraně, se Vám zvyšuje síla a štěstí (+{zvyseniSS}) a snižuje obratnost a inteligence (-{snizeniOI})!");
                WriteLine();             
            }

            else
            {
                VasePostava._aktualniNepritel.sObratnost -= snizeniOI;
                VasePostava._aktualniNepritel.sInteligence -= snizeniOI;
                VasePostava._aktualniNepritel.sSila += zvyseniSS;
                VasePostava._aktualniNepritel.sStesti += zvyseniSS;
                WriteLine($"Díky setové schopnosti zbraně Vašeho soupeře se jim zvyšuje síla a štěstí (+{zvyseniSS}) a snižuje obratnost a inteligence (-{snizeniOI})!");
                WriteLine();
            }
            Thread.Sleep(250);
        }
        public static void PekelnePlaty(bool Abilita_Postavy)
        {
            if (VasePostava.zbranPostavy != Pekelny_Bič && !Abilita_Postavy)
                return;
            if (VasePostava._aktualniNepritel.zbranStvoreni != Pekelny_Bič && Abilita_Postavy)
                return;
            WriteLine();
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.Red;
            byte zvyseniUH = 2;
            byte snizeniOH = 1;
            if (Abilita_Postavy == false)
            {
                VasePostava.hracovaPostava.vUtocnaHodnota += zvyseniUH;
                VasePostava.hracovaPostava.vObrannaHodnota -= snizeniOH;
                if (VasePostava.hracovaPostava.vObrannaHodnota < 0)
                    VasePostava.hracovaPostava.vObrannaHodnota = 0;
                WriteLine($"Díky setové schopnosti Vaší zbroje, se Vám zvyšuje útočná hodnota (+{zvyseniUH}) a snižuje obranná hodnota (-{snizeniOH})!");
                WriteLine();
            }
            else
            {
                VasePostava._aktualniNepritel.sUtocnaHodnota += zvyseniUH;
                VasePostava._aktualniNepritel.sObrannaHodnota -= snizeniOH;
                if (VasePostava._aktualniNepritel.sObrannaHodnota < 0)
                    VasePostava._aktualniNepritel.sObrannaHodnota = 0;
                WriteLine($"Díky setové schopnosti zbroje Vašeho soupeře, se jim zvyšuje útočná hodnota (+{zvyseniUH}) a snižuje obranná hodnota (-{snizeniOH})!");
                WriteLine();                          
            }
            Thread.Sleep(250);

        }

        //Speciální
        public static void VlciTalisman(bool Abilita_Postavy)
        {
            Clear();            
            if (!GameplayLokaci_3.JeBandita() && !GameplayLokaci_3.JeEnemyBandita(VasePostava._aktualniNepritel))
                return;
            int stestiAdd = 3;
            int silaAdd = 2;
            int obrAdd = 2;
            int UAadd = 1;
            WriteLine();
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.DarkYellow;
            if (Abilita_Postavy == true && GameplayLokaci_3.JeBandita())
            {
                DndHerniFunkce.hrdinaTrinket = true;
                VasePostava.hracovaPostava.vStesti += stestiAdd;
                VasePostava.hracovaPostava.vSila += silaAdd;
                VasePostava.hracovaPostava.vObratnost += obrAdd;
                VasePostava.hracovaPostava.vUtocnaHodnota += UAadd;
                WriteLine("Držíte Vlčí talisman a zároveň jste vybaveni jako bandité...");
                WriteLine();
                Thread.Sleep(300);
                WriteLine($"Štěstí se Vám zvyšuje o {stestiAdd}, síla o {silaAdd}, obratnost o {obrAdd} a útočná hodnota o {UAadd}!");
                Thread.Sleep(300);
                GameplayLokaci_1.Tlacitko();

            }
            else if(Abilita_Postavy == false && GameplayLokaci_3.JeEnemyBandita(VasePostava._aktualniNepritel))
            {
                DndHerniFunkce.enemyTrinket = true;
                VasePostava._aktualniNepritel.sStesti += stestiAdd;
                VasePostava._aktualniNepritel.sSila += silaAdd;
                VasePostava._aktualniNepritel.sObratnost += obrAdd;
                VasePostava._aktualniNepritel.sUtocnaHodnota += UAadd;
                WriteLine("Nepřítel drží Vlčí talisman a zároveň je vybaven jako bandita....");
                WriteLine();
                Thread.Sleep(300);
                WriteLine($"Štěstí se soupeři zvyšuje o {stestiAdd}, síla o {silaAdd}, obratnost o {obrAdd} a útočná hodnota o {UAadd}!");
                Thread.Sleep(300);
                GameplayLokaci_1.Tlacitko();    
            }
        }
        public static void MaskaMiru(bool Abilita_Postavy)
        {
            Clear();
            if ((VasePostava.hracovaPostava.poskozeniZbrane + VasePostava.hracovaPostava.hodnotaBrneni) > 4 && (VasePostava._aktualniNepritel.poskozeniZbrane + VasePostava._aktualniNepritel.hodnotaBrneni) > 4)
                return;          
            WriteLine();
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.DarkGreen;
            if (Abilita_Postavy == true && (VasePostava.hracovaPostava.poskozeniZbrane + VasePostava.hracovaPostava.hodnotaBrneni) <= 4)
            {
                DndHerniFunkce.hrdinaTrinket = true;
                WriteLine("Přicházíte v nevýrazné výbavě...");
                WriteLine();
                Thread.Sleep(300);
                VasePostava.hracovaPostava.vUtocnaHodnota *= 2;
                WriteLine($"Útočná hodnota se Vám zdvojnásobuje! Nyní je {VasePostava.hracovaPostava.vUtocnaHodnota}.");
                Thread.Sleep(300);
                GameplayLokaci_1.Tlacitko();

            }
            else if (Abilita_Postavy == false && (VasePostava._aktualniNepritel.poskozeniZbrane + VasePostava._aktualniNepritel.hodnotaBrneni) <= 4)
            {
                DndHerniFunkce.enemyTrinket = true;
                WriteLine("Nepřítel přichází v nevýrazné výbavě...");
                WriteLine();
                Thread.Sleep(300);
                VasePostava._aktualniNepritel.sUtocnaHodnota *= 2;
                WriteLine($"Útočná hodnota se soupeři zdvojnásobuje! Nyní je {VasePostava._aktualniNepritel.sUtocnaHodnota}.");
                Thread.Sleep(300);
                GameplayLokaci_1.Tlacitko();
            }
        }
        public static void DabelskyTotemRovnovahy(bool Abilita_Postavy)
        {
            Clear();
            if (!Abilita_Postavy)
                return;           
            WriteLine();
            Thread.Sleep(150);
            ForegroundColor = ConsoleColor.DarkRed;
            if (Abilita_Postavy == true)
            {
                if (VasePostava.hracovaPostava.vObrannaHodnota >= 2 * VasePostava.hracovaPostava.vUtocnaHodnota || VasePostava.hracovaPostava.vUtocnaHodnota >= 2 * VasePostava.hracovaPostava.vObrannaHodnota)
                {
                   DndHerniFunkce.hrdinaTrinket = true;
                    WriteLine("Vaše bojové hodnoty jsou výrazně rozdílné...");
                    WriteLine();
                    Thread.Sleep(350);
                    WriteLine($"Útočná hodnota je {VasePostava.hracovaPostava.vUtocnaHodnota} a Obranná hodnota je {VasePostava.hracovaPostava.vObrannaHodnota}.");
                    WriteLine();
                    Thread.Sleep(250);
                    int max = Math.Max(VasePostava.hracovaPostava.vObrannaHodnota, VasePostava.hracovaPostava.vUtocnaHodnota);
                    VasePostava.hracovaPostava.vObrannaHodnota = max;
                    VasePostava.hracovaPostava.vUtocnaHodnota = max;
                    WriteLine($"Je na čase to napravit. Obě hodnoty jsou nyní {max}!");
                    GameplayLokaci_1.Tlacitko();
                }
                else return;

            }
           
        }
    }
}
