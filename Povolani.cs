namespace DnD_Hra
{
    internal abstract class Povolani
    {
        public abstract void PredstaveniPovolani();

        public abstract void ArtPovolani();

        // propertýz, jakožto proměnné
        public int pObratnost { get; set; }

        public int pSila { get; set; }
        public int pInteligence { get; set; }
        public int pStesti { get; set; }
        public int pZdravi { get; set; }

        public int zakladniUtocnaHodnota { get; set; }
        public int zakladniObrannaHodnota { get; set; }

        public int pUtocnaHodnota { get; set; }
        public int pObrannaHodnota { get; set; }
        public int poskozeniZbrane { get; set; }
        public int hodnotaBrneni { get; set; }
        public bool maManu { get; set; }
        public int pocetMany { get; set; }
    }
}