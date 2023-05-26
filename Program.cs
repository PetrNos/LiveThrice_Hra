using static DnD_Hra.DndHerniFunkce; 
using System;
using static System.Console;
using static DnD_Hra.VytvorenePredmety;
using System.Collections.Generic;
using static DnD_Hra.UkladaniFunkci;
using System.Linq;
using static DnD_Hra.Lokace;
using static DnD_Hra.VytvoreneLokace;
using System.Threading;
namespace DnD_Hra
{
    internal class Program
    {   
        
        //moznost story, moznost tutorialu. Finalni titulky, poděkování pak end. 
        //arty etc. zkusit vyrest trimmy artu
        private static void Main(string[] args)
        {
            if (OperatingSystem.IsWindows())
            {

                WindowHeight = 35;//30
                WindowWidth = 140;//120
                SetBufferSize(WindowWidth, WindowHeight);
            }
            OutputEncoding = System.Text.Encoding.UTF8;           
            CursorVisible = false;                       
            DndHerniFunkce.SpustHlavniMenu();
            PrubehHry();
        }       
        // dulezity:       
         private static void PrubehHry()
         {            
            VasePostava.hracovaPostava = new VasePostava();
            VasePostava.inventarPostavy = new Inventar();                              
            DndHerniFunkce.SpustHlavniMenu();
            Tutorial._Pribeh();
            Tutorial._Uvod();
            PlaythroughText();
            VyberRasy(VasePostava.hracovaPostava, new Hobit(), new Elf(), new Kroll());
            VyberPovolani(VasePostava.hracovaPostava, new Valecnik(), new Zlodej(), new Carodej());
            VyberJmena(VasePostava.hracovaPostava);           
            while (true) 
            Lokace.VyberoveMenu(); 
            static void PlaythroughText()
            {
                Clear();
                ForegroundColor = ConsoleColor.DarkRed;
                AnimaceTextu("V Live Thrice budete umírat - často.");
                AnimaceTextu("U většiny věcí nebudete vědět, co zpočátku dělají, je třeba tedy experimentovat a postupně informace zjišťovat.");
                AnimaceTextu("Ve hře není ukládání, pokud 3x zemřete, hra skončí.");
                AnimaceTextu("Text Vám může velice často napovědět a poskytnout důležité vědomosti, je tedy doporučeno ho číst.");
                AnimaceTextu("Pokud se Vám první, druhý, nebo třetí průchod hrou nepovede, nic si z toho nedělejte, ten další bude lepší.");
                AnimaceTextu("Hra se nemění, vědomosti nabyté v každém průchodu tedy lze využít v tom dalším.");
                AnimaceTextu("....");
                ForegroundColor = ConsoleColor.Magenta;
                AnimaceTextu("Příjemnou zábavu!");
                GameplayLokaci_1.Tlacitko();
            }
         }         
    }
}