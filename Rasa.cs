namespace DnD_Hra
{
    internal abstract class Rasa
    {
        public int rObratnost { get; set; }
        public int rSila { get; set; }
        public int rInteligence { get; set; }
        public int rStesti { get; set; }
        public int rZdravi { get; set; }

        public abstract void PredstaveniRasy();
    }
}