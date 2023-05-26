using static DnD_Hra.ArtyLokaci;
using static DnD_Hra.GameplayLokaci_1;
using static DnD_Hra.GameplayLokaci_2;
using static DnD_Hra.GameplayLokaci_3;
using static DnD_Hra.GameplayLokaci_4;
using static DnD_Hra.GameplayLokaci_5;
using System;

namespace DnD_Hra
{
    internal static class VytvoreneLokace
    {
        // Vytvořené lokace
        public static readonly Lokace Město_Valoria = new Lokace("Valoria", ObtiznostLokace.Začátečnická, ValoriaArt, ValoriaGameplay, false);
        public static readonly Lokace Osobní_Domeček = new Lokace("Váš osobní dům", ObtiznostLokace.Začátečnická, OsobniDomecekArt, OsobniDomecekGameplay, true);
        public static readonly Lokace Skřetí_Panství = new Lokace("Skřetí Panství", ObtiznostLokace.Jednoduchá, SkretiPanstviArt, SkřetíPanství, true);
        public static readonly Lokace Dobyté_Panství = new Lokace("Dobyté panství", ObtiznostLokace.Jednoduchá, VasePanstviArt, DobytePanstvi, true);
        public static readonly Lokace Průsmyk_Hrdlořezů = new Lokace("Průsmyk Hrdlořezů", ObtiznostLokace.Jednoduchá, PrusmykHrdlorezuArt, PrusmykHrdlorezuGameplay, true);
        public static readonly Lokace Všudypřítomná_Knihovna = new Lokace("Všudypřítomná knihovna", ObtiznostLokace.Pokročilá, VsudypritomnaKnihovnaArt, VsudypritomnaKnihovnaGameplay, true);
        public static readonly Lokace Nadčasový_Les = new Lokace("Nadčasový Les", ObtiznostLokace.Pokročilá, NadcasovyLesArt, NadcasovyLesGameplay, true);
        public static readonly Lokace Experimentální_Jádro = new Lokace("Experimentální Jádro", ObtiznostLokace.Náročná, ExperimentalniJadroArt, ExperimentalniJadroGameplay, true);
        public static readonly Lokace Znovuzrozeny_Les = new Lokace("Znovuzrozený Les", ObtiznostLokace.Jednoduchá, ZnovuZrozenyLesArt, ZnovuzrozenyLesGameplay, true);
        public static readonly Lokace Astralni_Prechod = new Lokace("Astrální Přechod", ObtiznostLokace.Pokročilá, AstralniprechodArt, AstralniPrechod, true);
        public static readonly Lokace Dabelska_Herna = new Lokace("Ďábelská Herna", ObtiznostLokace.Náročná, DabelskaHernaArt, DabelskaHernaGameplay, true);
        public static readonly Lokace Skoro_Legální_Dábelské_Casino = new Lokace("Skoro legální Ďábelské Casino", ObtiznostLokace.Jednoduchá, SkoroLegalniDabelskoCasinoArt, SkoroLegalniPekelneCasino, true);
        public static readonly Lokace Satanuv_chrtan = new Lokace("Satanův Chřtán", ObtiznostLokace.Náročná, SatanuvChrtanArt, SatanuvChrtanGameplay, true);
        public static readonly Lokace Chrám_tří_srdcí = new Lokace("Chrám Tří Srdcí", ObtiznostLokace.Náročná, ChramTriSrdciArt, ChramTriSrdciGameplay, true);
    }
}
