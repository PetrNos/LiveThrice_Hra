using System;
using static System.Console;

namespace DnD_Hra
{
    internal static class ArtyLokaci
    {
        private static void BarvaObtiznosti(Lokace lokace)
        {
            if (lokace.obtiznostLokace == ObtiznostLokace.Začátečnická)
                ForegroundColor = ConsoleColor.White;
            else if (lokace.obtiznostLokace == ObtiznostLokace.Jednoduchá)
                ForegroundColor = ConsoleColor.Green;
            else if (lokace.obtiznostLokace == ObtiznostLokace.Pokročilá)
                ForegroundColor = ConsoleColor.Cyan;
            else if (lokace.obtiznostLokace == ObtiznostLokace.Náročná)
                ForegroundColor = ConsoleColor.Yellow;            
            if (lokace._UzamcenaLokace)
                ForegroundColor = ConsoleColor.DarkGray;
            if (lokace._DokoncenaFinalneLokace)
                ForegroundColor = ConsoleColor.Green;
        }
        

        
        public static void ValoriaArt(Lokace lokace)
        {
            Clear();
            if (!lokace._UzamcenaLokace && !lokace._DokoncenaFinalneLokace)
            {
                WriteLine("Nynější lokace: " + lokace.NazevLokace);
                BarvaObtiznosti(lokace);
                WriteLine("Obtížnost lokace: " + lokace.obtiznostLokace);              
            }
            else if (lokace._DokoncenaFinalneLokace)
            {
                WriteLine("Nynější lokace: " + lokace.NazevLokace);
                WriteLine();
                WriteLine("<<  Úplně dokončeno   >>");
            }
            else if (lokace._UzamcenaLokace)
            {
               
                WriteLine("<<   Uzamčeno   >>");

            }
        }
        public static void OsobniDomecekArt(Lokace lokace)
        {
            Clear();
            if (!lokace._UzamcenaLokace && !lokace._DokoncenaFinalneLokace)
            {
                WriteLine("Nynější lokace: " + lokace.NazevLokace);
                BarvaObtiznosti(lokace);
                WriteLine("Obtížnost lokace: " + "-");                
            }
            else if (lokace._DokoncenaFinalneLokace)
            {
                WriteLine("Nynější lokace: " + lokace.NazevLokace);
                WriteLine();
                WriteLine("<<  Úplně dokončeno   >>");
            }
            else if (lokace._UzamcenaLokace)
            {
               
                WriteLine("<<   Uzamčeno   >>");

            }
        }
        public static void SkretiPanstviArt(Lokace lokace)
        {
            Clear();
            if (!lokace._UzamcenaLokace && !lokace._DokoncenaFinalneLokace)
            {
                WriteLine("Nynější lokace: " + lokace.NazevLokace);
                BarvaObtiznosti(lokace);
                WriteLine("Obtížnost lokace: " + lokace.obtiznostLokace);                
                WriteLine("Zbývající počet pokusů: " + (3-GameplayLokaci_2.pocetNavstev));
            }
            else if (lokace._DokoncenaFinalneLokace)
            {
                WriteLine("Nynější lokace: " + lokace.NazevLokace);
                WriteLine();
                WriteLine("<<  Úplně dokončeno   >>");
            }
            else if (lokace._UzamcenaLokace)
            {
                
                WriteLine("<<   Uzamčeno   >>");

            }
        }
        public static void VasePanstviArt(Lokace lokace)
        {
            Clear();
            if (!lokace._UzamcenaLokace && !lokace._DokoncenaFinalneLokace)
            {
                WriteLine("Nynější lokace: " + lokace.NazevLokace);
                BarvaObtiznosti(lokace);
                WriteLine("Obtížnost lokace: -" );                
            }
            else if (lokace._DokoncenaFinalneLokace)
            {
                WriteLine("Nynější lokace: " + lokace.NazevLokace);
                WriteLine();
                WriteLine("<<  Úplně dokončeno   >>");
            }
            else if (lokace._UzamcenaLokace)
            {
                
                WriteLine("<<   Uzamčeno   >>");

            }
        }
        public static void PrusmykHrdlorezuArt(Lokace lokace)
        {
            Clear();
            if (!lokace._UzamcenaLokace && !lokace._DokoncenaFinalneLokace)
            {WriteLine("Nynější lokace: " + lokace.NazevLokace);
                BarvaObtiznosti(lokace);
                WriteLine("Obtížnost lokace: " + lokace.obtiznostLokace);
            }
            else if (lokace._DokoncenaFinalneLokace)
            {
                WriteLine("Nynější lokace: " + lokace.NazevLokace);
                WriteLine();
                WriteLine("<<  Úplně dokončeno   >>");
            }
            else if (lokace._UzamcenaLokace)
            {
               
                WriteLine("<<   Uzamčeno   >>");

            }
        }
        public static void VsudypritomnaKnihovnaArt(Lokace lokace)
        {
            Clear();
            if (!lokace._UzamcenaLokace && !lokace._DokoncenaFinalneLokace)
            {WriteLine("Nynější lokace: " + lokace.NazevLokace);
                BarvaObtiznosti(lokace);
                WriteLine("Obtížnost lokace: " + lokace.obtiznostLokace);
            }
            else if (lokace._DokoncenaFinalneLokace)
            {
                WriteLine("Nynější lokace: " + lokace.NazevLokace);
                WriteLine();
                WriteLine("<<  Úplně dokončeno   >>");
            }
            else if (lokace._UzamcenaLokace)
            {

                WriteLine("<<   Uzamčeno   >>");

            }
        }
        public static void NadcasovyLesArt(Lokace lokace)
        {
            Clear();
            if (!lokace._UzamcenaLokace && !lokace._DokoncenaFinalneLokace)
            {WriteLine("Nynější lokace: " + lokace.NazevLokace);
                BarvaObtiznosti(lokace);
                WriteLine("Obtížnost lokace: " + lokace.obtiznostLokace);
            }
            else if (lokace._DokoncenaFinalneLokace)
            {
                WriteLine("Nynější lokace: " + lokace.NazevLokace);
                WriteLine();
                WriteLine("<<  Úplně dokončeno   >>");
            }
            else if (lokace._UzamcenaLokace)
            {

                WriteLine("<<   Uzamčeno   >>");

            }
        }
        public static void ExperimentalniJadroArt(Lokace lokace)
        {
            Clear();
            if (!lokace._UzamcenaLokace && !lokace._DokoncenaFinalneLokace)
            {WriteLine("Nynější lokace: " + lokace.NazevLokace);
                BarvaObtiznosti(lokace);
                WriteLine("Obtížnost lokace: " + lokace.obtiznostLokace);
            }
            else if (lokace._DokoncenaFinalneLokace)
            {
                WriteLine("Nynější lokace: " + lokace.NazevLokace);
                WriteLine();
                WriteLine("<<  Úplně dokončeno   >>");
            }
            else if (lokace._UzamcenaLokace)
            {

                WriteLine("<<   Uzamčeno   >>");

            }
        }
        public static void ZnovuZrozenyLesArt(Lokace lokace)
        {
            Clear();
            if (!lokace._UzamcenaLokace && !lokace._DokoncenaFinalneLokace)
            {WriteLine("Nynější lokace: " + lokace.NazevLokace);
                BarvaObtiznosti(lokace);
                WriteLine("Obtížnost lokace: -");
            }
            else if (lokace._DokoncenaFinalneLokace)
            {
                WriteLine("Nynější lokace: " + lokace.NazevLokace);
                WriteLine();
                WriteLine("<<  Úplně dokončeno   >>");
            }
            else if (lokace._UzamcenaLokace)
            {

                WriteLine("<<   Uzamčeno   >>");

            }
        }
        public static void DabelskaHernaArt(Lokace lokace)
        {
            Clear();
            if (!lokace._UzamcenaLokace && !lokace._DokoncenaFinalneLokace)
            {WriteLine("Nynější lokace: " + lokace.NazevLokace);
                BarvaObtiznosti(lokace);
                WriteLine("Obtížnost lokace: " + lokace.obtiznostLokace);
            }
            else if (lokace._DokoncenaFinalneLokace)
            {
                WriteLine("Nynější lokace: " + lokace.NazevLokace);
                WriteLine();
                WriteLine("<<  Úplně dokončeno   >>");
            }
            else if (lokace._UzamcenaLokace)
            {

                WriteLine("<<   Uzamčeno   >>");

            }
        }
        public static void SkoroLegalniDabelskoCasinoArt(Lokace lokace)
        {
            Clear();
            if (!lokace._UzamcenaLokace && !lokace._DokoncenaFinalneLokace)
            {WriteLine("Nynější lokace: " + lokace.NazevLokace);
                BarvaObtiznosti(lokace);
                WriteLine("Obtížnost lokace: -");
            }
            else if (lokace._DokoncenaFinalneLokace)
            {
                WriteLine("Nynější lokace: " + lokace.NazevLokace);
                WriteLine();
                WriteLine("<<  Úplně dokončeno   >>");
            }
            else if (lokace._UzamcenaLokace)
            {

                WriteLine("<<   Uzamčeno   >>");

            }
        }
        public static void AstralniprechodArt(Lokace lokace)
        {
            Clear();
            if (!lokace._UzamcenaLokace && !lokace._DokoncenaFinalneLokace)
            {WriteLine("Nynější lokace: " + lokace.NazevLokace);
                BarvaObtiznosti(lokace);
                WriteLine("Obtížnost lokace: " + lokace.obtiznostLokace);
            }
            else if (lokace._DokoncenaFinalneLokace)
            {
                WriteLine("Nynější lokace: " + lokace.NazevLokace);
                WriteLine();
                WriteLine("<<  Úplně dokončeno   >>");
            }
            else if (lokace._UzamcenaLokace)
            {

                WriteLine("<<   Uzamčeno   >>");

            }
        }
        public static void SatanuvChrtanArt(Lokace lokace)
        {
            Clear();
            if (!lokace._UzamcenaLokace && !lokace._DokoncenaFinalneLokace)
            {
                WriteLine("Nynější lokace: " + lokace.NazevLokace);
                BarvaObtiznosti(lokace);
                WriteLine("Obtížnost lokace: " + lokace.obtiznostLokace);
            }
            else if (lokace._DokoncenaFinalneLokace)
            {
                WriteLine("Nynější lokace: " + lokace.NazevLokace);
                WriteLine();
                WriteLine("<<  Úplně dokončeno   >>");
            }
            else if (lokace._UzamcenaLokace)
            {

                WriteLine("<<   Uzamčeno   >>");

            }
        }
        public static void ChramTriSrdciArt(Lokace lokace)
        {
            Clear();
            if (!lokace._UzamcenaLokace && !lokace._DokoncenaFinalneLokace)
            {
                WriteLine("Nynější lokace: " + lokace.NazevLokace);
                BarvaObtiznosti(lokace);
                WriteLine("Obtížnost lokace: " + "Finální");
            }
            else if (lokace._DokoncenaFinalneLokace)
            {
                WriteLine("Nynější lokace: " + lokace.NazevLokace);
                WriteLine();
                WriteLine("<<  Úplně dokončeno   >>");
            }
            else if (lokace._UzamcenaLokace)
            {

                WriteLine("<<   Uzamčeno   >>");

            }
        }
    }
}