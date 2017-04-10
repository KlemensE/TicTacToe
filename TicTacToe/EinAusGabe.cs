using System;

namespace TicTacToe
{
    class EinAusGabe : Program
    {
        readonly Spielregeln _regeln = new Spielregeln();

        /// <summary>
        /// Ruft die Spieler zur eingabe auf und kontrolliert ob der nächste Spieler dran kommt
        /// </summary>
        /// <param name="Spieler">1 oder 2</param>
        /// <param name="spielzeichen">X oder O</param>
        /// <param name="FelderStatus">Array mit Inhalt der Felder X,O oder " "</param>
        public void Spieler(int Spieler, string spielzeichen, string[] FelderStatus)
        {
            do
            {
                Zeichnen();
                Console.WriteLine("\nSpieler{0} ist am Zug, geben sie die Position ein zB A1",Spieler);
                NächsterSpieler = _regeln.PositionsBestimmung(Console.ReadLine(), spielzeichen);

                if (NächsterSpieler)
                {
                    Zeichnen();
                    var res = _regeln.ÜberprüfungPosition();
                    if (res != Status.KeinGewinner)
                    {
                        Console.WriteLine(Status.KeinGewinner.ToString());
                        Console.ReadKey();
                        MainLoop = 1;
                        break;
                    }
                }
            } while (!NächsterSpieler);
        }

        /// <summary>
        /// Zeichnet das Feld neu
        /// </summary>
        /// <param name="FelderPosition"></param>
        public void Zeichnen()
        {
            Console.Clear();
            Console.WriteLine("1   2   3");
            Console.WriteLine("{0} | {1} | {2} A", FelderStatus[0], FelderStatus[1], FelderStatus[2]);
            Console.WriteLine("---------");
            Console.WriteLine("{0} | {1} | {2} B", FelderStatus[3], FelderStatus[4], FelderStatus[5]);
            Console.WriteLine("---------");
            Console.WriteLine("{0} | {1} | {2} C", FelderStatus[6], FelderStatus[7], FelderStatus[8]);
        }

        /// <summary>
        /// neu eingabe der Position falls diese Falsch ist
        /// </summary>
        /// <returns>gibt die neu eingegebene Position zurück</returns>
        public string PositionEingeben()
        {
            Console.WriteLine("Geben sie die Position Erneut ein");
            return Console.ReadLine();
        }

        /// <summary>
        /// Kontrolliert den eingegebene Position
        /// </summary>
        /// <param name="position">Die Position im feld</param>
        /// <returns>gibt eine 100% vorhandene Position zurück</returns>
        public string PositionsControlle(string position)
        {
            for (; ; )
            {
                bool Zahl = false;
                if (position.Length == 2)
                {
                    try
                    {
                        for (int i = 1; i <= 3; i++)
                        {
                            if (position[1].ToString().Equals(i.ToString()))
                            {
                                Zahl = true;
                            }
                        }

                        if (!Zahl)
                        {
                            position = PositionEingeben();
                            continue;
                        }
                        if (position[0] == 'A' || position[0] == 'a')
                        {
                            if (Zahl)
                            {
                                return position;
                            }
                        }
                        else if (position[0] == 'B' || position[0] == 'b')
                        {
                            if (Zahl)
                            {
                                return position;
                            }
                        }
                        else if (position[0] == 'C' || position[0] == 'c')
                        {
                            if (Zahl)
                            {
                                return position;
                            }
                        }
                        else
                        {
                            position = PositionEingeben();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    position = PositionEingeben();
                }
            }
        }

    }
}
