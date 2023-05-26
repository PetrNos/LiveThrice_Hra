using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Media;
using static System.Console;
using static DnD_Hra.DndHerniFunkce;

namespace DnD_Hra
{
    class MusicPlayer
    {
        //umelci: Leimoti, Edgar Hopp, Bonn Fields,  Emily Rubye, Christian Andersen,
        //Phoenix Tail, Howard Harper-Barnes, John Abbot, Arylide Fields, Hampus Naeselius,
        //Christoffer Moe Ditlevsen,  Jo Wandrini, Fredrik Ekström, Dream Cave, Gerard Franklin
        static bool nacteno = false;
        public static SoundPlayer nynejsiSong;       
        private static readonly SoundPlayer TheArrival = new SoundPlayer("A.wav");
        public static readonly SoundPlayer DragonTaming = new SoundPlayer("DT.wav");
        private static readonly SoundPlayer SunnyFields = new SoundPlayer("F.wav");
        public static readonly SoundPlayer TheTriumph = new SoundPlayer("TT.wav");

        private static readonly List<SoundPlayer> Playlist = new List<SoundPlayer>()
        {
            TheArrival, DragonTaming,SunnyFields, TheTriumph
        };
       private static void NactiVse()
       {
            foreach (SoundPlayer sp in Playlist)
                sp.Load();
       }
        public static void VyberPisnicek()
        {
            if (OperatingSystem.IsWindows())
            {
               if(!nacteno)
               {
                    NactiVse();
                    nacteno = true;
               }
                while (true)
                {

                    Menu vyberHudby = new Menu("Vyberte si hudbu, kterou má Váš magický Bard hrát: ", new List<string> { "1 - The Comeback", "2 - Dragon Training", "3 - Sunny Fields", "4 - The Trophy", "Zastavit barda v hraní", "Odejít z menu hudby" }, ConsoleColor.Yellow);
                    int volba = vyberHudby.NavratIndexu();
                    if (volba == 5)
                        break;
                    if (volba == 4)
                    {
                        zastavAvypust();
                    }
                    else if (volba == 0)
                    {
                        zastavAvypust();
                        nynejsiSong = Playlist[0];
                        nynejsiSong.PlayLooping();
                    }
                    else if (volba == 1)
                    {
                        zastavAvypust();
                        nynejsiSong = Playlist[1];
                        nynejsiSong.PlayLooping();
                    }
                    else if (volba == 2)
                    {   
                        zastavAvypust();
                        nynejsiSong = Playlist[2];
                        nynejsiSong.PlayLooping();
                    }
                    else if (volba == 3)
                    {  
                        zastavAvypust();
                        nynejsiSong = Playlist[3];
                        nynejsiSong.PlayLooping();
                    }
                }
                void zastavAvypust()
                {
                    if(nynejsiSong != null)
                    {
                        nynejsiSong.Stop();
                        nynejsiSong.Dispose();
                        nynejsiSong = null;
                    }
                }

            }
            else
            {
                Clear();
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Na tomto operačním systému bohužel není možno poslouchat Barda. Podporován je jen Windows.");
                WriteLine();
                ResetColor();
                WriteLine("stiskněte libovolné tlačítko pro pokračování...");
                ReadKey(true);
                Clear();
            }
        }
        public static void BardPotkani()
        {
            if(OperatingSystem.IsWindows())
            {
                Clear();               
                ForegroundColor = ConsoleColor.Cyan;
                AnimaceTextu("Na cestě do města potkáváte malý poletující zvoneček, který se na Vás neustále lepí...");
                AnimaceTextu("O magii něco málo víte, ale že dokáže být takhle otravná jste opravdu netušili.");
                AnimaceTextu("Zvoneček za Vámi chvíli dotěrně poletuje a Vy se ho snažíte ignorovat, nepůsobí na Vás nijak speciálně.");
                AnimaceTextu("Potom Vám však ukáže, že dokáže hrát muziku a Vy se zamyslíte.");
                AnimaceTextu("Přecijen se Vám zamlouvá myšlenka muziky při dlouhých chvílích na Vašich cestách...");
                AnimaceTextu("Pokýváním dáte zvonečku najevo, že Vás jeho přítomnost nikterak neruší.");
                AnimaceTextu("Zvoneček zahraje pár šťastně znějících melodií a je Vám v patách na Vašich cestách...");
                WriteLine();
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Ve vašem vedlejším menu si nyní můžete zvolit co má váš magický Bard hrát.");                
                WriteLine();
                ForegroundColor = ConsoleColor.Gray;
                WriteLine("Menu se nyní otevře...");
                WriteLine();
                WriteLine("stiskněte libovolné tlačítko pro pokračování...");
                ReadKey(true);
                Clear();
                Menu.VedlejsiMenuPostavy();

            }
        }
    }    
}
