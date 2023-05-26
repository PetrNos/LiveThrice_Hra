namespace DnD_Hra
{
    // uložení stavu postavy pro případ smrti, také obnova statů po souboji
    internal class BasePostava
    {
        public int vSila { get; set; }
        public int vObratnost { get; set; }
        public int vInteligence { get; set; }
        public int vStesti { get; set; }
        public int vZdravi { get; set; }
        public int vUtocnaHodnota { get; set; }
        public int vObrannaHodnota { get; set; }
        public int pocetMany { get; set; }        

        public Zbrane alternativniZbranPostavy { get; set; }
        public Zbrane zbranPostavy { get; set; }
        public Zbroje zbrojPostavy { get; set; }
        public BasePostava(VasePostava vasePostava)
        {

            vSila = vasePostava.vSila;
            vObratnost = vasePostava.vObratnost;
            vInteligence = vasePostava.vInteligence;
            vStesti = vasePostava.vStesti;
            vZdravi = vasePostava.vZdravi;
            vUtocnaHodnota = vasePostava.vUtocnaHodnota;
            vObrannaHodnota = vasePostava.vObrannaHodnota;
            pocetMany = VasePostava.hracovaPostava.pocetMany;
            zbranPostavy = VasePostava.zbranPostavy;
            zbrojPostavy = VasePostava.zbrojPostavy;
            if (VasePostava.alternativniZbranPostavy != null)
                alternativniZbranPostavy = VasePostava.alternativniZbranPostavy;
        }

        public void ObnovaAtributuPostavy(VasePostava vasePostava)
        {
            vasePostava.vSila = this.vSila;
            vasePostava.vObratnost = this.vObratnost;
            vasePostava.vInteligence = this.vInteligence;
            vasePostava.vStesti = this.vStesti;
            vasePostava.vZdravi = this.vZdravi;          
            vasePostava.vObrannaHodnota = this.vObrannaHodnota;
            vasePostava.vUtocnaHodnota = this.vUtocnaHodnota;
            vasePostava.pocetMany = this.pocetMany;
            vasePostava.bodPresnosti = 0;
            vasePostava.ZLock = true;
            VasePostava.zbranPostavy = this.zbranPostavy;
            VasePostava.zbrojPostavy = this.zbrojPostavy;
            if (VasePostava.alternativniZbranPostavy != null)
                VasePostava.alternativniZbranPostavy = this.alternativniZbranPostavy;
        }
    }
}