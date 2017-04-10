using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TicTacToe
{
    class Program
    {
        public static bool Ki;
        public static string KiLevel = string.Empty;
        public static string Ausgabe = string.Empty;
        public static Status Status = Status.KeinGewinner;
        public static bool NächsterSpieler;
        public static string[] FelderStatus = { " ", " ", " ", " ", " ", " ", " ", " ", " " };
        public static bool[] FelderBesetzt = { false, false, false, false, false, false, false, false, false };
        public static int MainLoop;

        static void Main()
        {

            Spielregeln regeln = new Spielregeln();
            EinAusGabe inOut = new EinAusGabe();

            #region KI Auswahl
            {
                Console.Clear();
                Console.WriteLine("(1) Singleplayer \n(2) Multiplayer");
                string Auswahl = Console.ReadLine();
                if (Auswahl == "1")
                {
                    Ki = true;

                    
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("1)Anfänger \n2)Fortgeschrittener \n3)ProGamer");
                        KiLevel = Console.ReadLine();
                        if (KiLevel.Equals("1") || KiLevel.Equals("2") || KiLevel.Equals("3"))
                        {
                            break;
                        }
                    }
                    
                }
            }
            #endregion

            for (MainLoop = 0; MainLoop < 1; )
            {

                inOut.Spieler(1, "X",FelderStatus);

                if (MainLoop == 1)
                {
                    break;
                }

                if (!Ki)
                {
                    inOut.Spieler(2, "O",FelderStatus);
                    inOut.Zeichnen();
                }
                else
                {
                    #region KI
                    do
                    {
                        KIClass kiKlasse = new KIClass();
                        
                        string KIPosition = string.Empty;
                        if (KiLevel.Equals("1"))
                        {
                            KIPosition = kiKlasse.KIAnfänger();
                        }
                        else if (KiLevel.Equals("2"))
                        {
                            KIPosition = kiKlasse.KIForgeschritten();
                        }
                        //InOut.Zeichnen();
                        NächsterSpieler = regeln.PositionsBestimmung(KIPosition, "O");
                        inOut.Zeichnen();
                        Status = regeln.ÜberprüfungPosition();
                        Ausgabe = Status.ToString();
                        if (Status != Status.KeinGewinner)
                        {
                            Console.WriteLine(Ausgabe);
                            Console.ReadKey();
                            MainLoop = 1;
                            break;
                        }
                    } while (!NächsterSpieler);
                    #endregion
                }
            }
        }
    }
}