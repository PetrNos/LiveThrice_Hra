using System;
using System.Threading;
using static System.Console;

namespace DnD_Hra
{
    internal enum TypPredmetu
    { Zbrane, Zbroje, Pouzitelne, Suroviny, Specialni }
    

    internal abstract class Predmety
    {
        public string nazevPredmetu { get;  set; }
        
        public TypPredmetu typPredmetu { get; set; }
        public int hodnotaPredmetu { get; set; }
        private int pocatecniP = 1;
        public int pocetPredmetu(Inventar i)
        {
           Predmety p = this;
            pocatecniP = 0;
            foreach (Predmety pr in i.ListInventare())
                if (pr == p)
                    pocatecniP++;
            
            return pocatecniP;
        }
        public Guid ID { get; set; }
        public int pocetVylepseniPredmetu { get; set; }
    }

    //Pouzitelne predmety----------------------------------
    internal class Pouzitelne : Predmety
    {
        public Action FunkcePouzitiPredmetu { get; set; }

        public Pouzitelne(string nazevPredmetu, int hodnotaPredmetu, Action FunkcePouzitiPredmetu, TypPredmetu typPredmetu = TypPredmetu.Pouzitelne)
        {
            this.nazevPredmetu = nazevPredmetu;
            this.hodnotaPredmetu = hodnotaPredmetu;
            this.FunkcePouzitiPredmetu = FunkcePouzitiPredmetu;
            //this.pocetPredmetu = pocetPredmetu;
            this.typPredmetu = typPredmetu;
            ID = Guid.NewGuid();
        }
    }

    //Zbroje------------------------------------------------
    internal class Zbroje : Predmety
    {
        public int hodnotaBrneni { get; set; }
        public Action<bool> schopnostZbroje { get; set; }

        //konstruktor
        public Zbroje(string nazevPredmetu, int hodnotaPredmetu, int hodnotaBrneni, Action<bool> schopnostZbroje, int pocetVylepseniPredmetu = 1, TypPredmetu typPredmetu = TypPredmetu.Zbroje)
        {
            this.nazevPredmetu = nazevPredmetu;
            this.hodnotaPredmetu = hodnotaPredmetu;
           // this.pocetPredmetu = pocetPredmetu;
            this.hodnotaBrneni = hodnotaBrneni;
            this.typPredmetu = typPredmetu;
            this.pocetVylepseniPredmetu = pocetVylepseniPredmetu;
            this.schopnostZbroje = schopnostZbroje;
            ID = Guid.NewGuid();
        }

        public static void VylepseniZbroje(Zbroje zbroj)
        {
            if(VasePostava.inventarPostavy.MaPredmet(zbroj))
            {
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine("Úspěšně jste vylepšili zbraň {0}!", zbroj.nazevPredmetu);
                WriteLine();
                WriteLine("Hodnota brnění: {0}", zbroj.hodnotaBrneni);
                WriteLine();
                WriteLine("Cena: {0}", zbroj.hodnotaPredmetu);

                Zbroje vylepsenaZbroj = new Zbroje(zbroj.nazevPredmetu, (int)(zbroj.hodnotaPredmetu * 1.35), (int)zbroj.hodnotaBrneni + (int)(Math.Floor(zbroj.pocetVylepseniPredmetu / 2.0)), zbroj.schopnostZbroje, zbroj.pocetVylepseniPredmetu+1);               
                    vylepsenaZbroj.ID = Guid.NewGuid();
                VasePostava.inventarPostavy.PridejPredmet(vylepsenaZbroj); 
                VasePostava.inventarPostavy.OdeberPredmet(zbroj);
                for (int i = 0; i < WindowWidth; i++)
                    Write("-");
                WriteLine();
                ForegroundColor = ConsoleColor.Blue;
                WriteLine("Nová vylepšená zbroj: ");
                WriteLine();
                WriteLine("Hodnota brnění: {0}", vylepsenaZbroj.hodnotaBrneni); ;
                WriteLine();
                WriteLine("Cena: {0}", vylepsenaZbroj.hodnotaPredmetu);
                WriteLine();
                ForegroundColor = ConsoleColor.Gray;                
                Thread.Sleep(150);
                WriteLine("stiskněte libovolné tlačítko pro pokračování");
                ReadKey(true);
                Clear();
            }
        }
    }

    //Zbrane--------------------------------------
    internal class Zbrane : Predmety // dalsi trida, tentokrat pro zbrane
    {
        public int poskozeniZbrane { get; set; }
        public int manovaCena { get; set; }

        public Action<bool> schopnostZbrane { get; set; }
        public static void VylepseniZbrane(Zbrane zbran)
        {
            if (VasePostava.inventarPostavy.MaPredmet(zbran))
            {
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine("Úspěšně jste vylepšili zbraň {0}!", zbran.nazevPredmetu);
                WriteLine();
                WriteLine("Poškození: {0}", zbran.poskozeniZbrane);
                WriteLine();
                WriteLine("Cena: {0}", zbran.hodnotaPredmetu);                
                Zbrane vylepsenaZbran = new Zbrane(zbran.nazevPredmetu, (int)(zbran.hodnotaPredmetu * 1.35), (int)(zbran.poskozeniZbrane) + (int)(Math.Floor(zbran.pocetVylepseniPredmetu / 2.0)),zbran.manovaCena, zbran.schopnostZbrane, zbran.pocetVylepseniPredmetu+1);                                                            
                vylepsenaZbran.ID = Guid.NewGuid();

                VasePostava.inventarPostavy.OdeberPredmet(zbran);
                VasePostava.inventarPostavy.PridejPredmet(vylepsenaZbran);

                for (int i = 0; i < WindowWidth; i++)
                    Write("-");
                WriteLine();
                ForegroundColor = ConsoleColor.Blue;
                WriteLine("Nová vylepšená zbraň: ");
                WriteLine();
                WriteLine("Poškození: {0}", vylepsenaZbran.poskozeniZbrane);
                WriteLine();
                WriteLine("Cena: {0}", vylepsenaZbran.hodnotaPredmetu);
                WriteLine();                
                ForegroundColor = ConsoleColor.Gray;
                Thread.Sleep(150);
                WriteLine("stiskněte libovolné tlačítko pro pokračování");
                ReadKey(true);
                Clear();
            }
        }

        public Zbrane(string nazevPredmetu, int hodnotaPredmetu, int poskozeniZbrane, int manovaCena, Action<bool> schopnostZbrane, int pocetVylepseniPredmetu = 1, TypPredmetu typPredmetu = TypPredmetu.Zbrane)
        {
            this.nazevPredmetu = nazevPredmetu;
            this.hodnotaPredmetu = hodnotaPredmetu;
            //this.pocetPredmetu = pocetPredmetu;
            this.poskozeniZbrane = poskozeniZbrane;
            this.manovaCena = manovaCena;
            this.typPredmetu = typPredmetu;
            this.pocetVylepseniPredmetu = pocetVylepseniPredmetu;
            this.schopnostZbrane = schopnostZbrane;
            ID = Guid.NewGuid();
        }
    }

    internal class Specialni : Predmety
    {       
        public Action<bool> SchopnostSpecialniP { get; set; }
        public enum TypSpecPred {Talsiman, Klic};
        public TypSpecPred TypSpecialu;
        public string popisS { get; private set; }
        public Specialni(string nazevPredmetu, int hodnotaPredmetu, Action<bool> SchopnostSpecialniP, TypSpecPred TypSpecialu, string popisS, TypPredmetu typPredmetu = TypPredmetu.Specialni)
        {
            this.nazevPredmetu = nazevPredmetu;
            this.hodnotaPredmetu = hodnotaPredmetu;
            //this.pocetPredmetu = pocetPredmetu;            
            this.typPredmetu = typPredmetu;
            ID = Guid.NewGuid();
            this.SchopnostSpecialniP = SchopnostSpecialniP;
            this.TypSpecialu = TypSpecialu;
            this.popisS = popisS;
           
        }
    }

    internal class Suroviny : Predmety
    {
        public Suroviny(string nazevPredmetu, int hodnotaPredmetu, TypPredmetu typPredmetu = TypPredmetu.Suroviny)
        {
            this.nazevPredmetu = nazevPredmetu;
            this.hodnotaPredmetu = hodnotaPredmetu;
            this.typPredmetu = typPredmetu;
            ID = Guid.NewGuid();

        }
    }
}