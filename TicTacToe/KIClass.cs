using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    class KIClass : Program
    {
        Random rand = new Random();
        public string KIAnfänger()
        {
            string[] Buchstaben = { "a", "b", "c" };
            int Zufall = rand.Next(3);
            string ZufallPosition = string.Empty;
            ZufallPosition += Buchstaben[Zufall];
            ZufallPosition += rand.Next(1, 4);
            return ZufallPosition;
        }

        public string KIForgeschritten()
        {
            #region Zeile
            for (int i = 1; i < FelderStatus.Length; i += 3)
            {
                if (!FelderStatus[i].Equals(" "))
                {
                    if (FelderStatus[i - 1].Equals(FelderStatus[i]) && FelderStatus[i + 1].Equals(" "))
                    {
                        return ZahlZuPosition(i + 2);
                    }
                    else if (FelderStatus[i].Equals(FelderStatus[i + 1]) && FelderStatus[i - 1].Equals(" "))
                    {
                        return ZahlZuPosition(i);
                    }
                }
                else
                {
                    if (FelderStatus[i - 1].Equals(FelderStatus[i + 1]) && !FelderStatus[i - 1].Equals(" "))
                    {
                        return ZahlZuPosition(i + 1);
                    }
                }
            }

            #endregion

            #region Spalten
            for (int i = 3; i <= 5; i++)
            {
                if (!FelderStatus[i].Equals(" "))
                {
                    if (FelderStatus[i - 3].Equals(FelderStatus[i]) && FelderStatus[i + 3].Equals(" "))
                    {
                        return ZahlZuPosition(i + 4);
                    }
                    else if (FelderStatus[i].Equals(FelderStatus[i + 3]) && FelderStatus[i - 3].Equals(" "))
                    {
                        return ZahlZuPosition(i - 2);
                    }
                }
                else
                {
                    if (FelderStatus[i - 3].Equals(FelderStatus[i + 3]) && !FelderStatus[i + 3].Equals(" "))
                    {
                        return ZahlZuPosition(i + 1);
                    }
                }
            }
            #endregion

            #region Diagonal
            int b = 8;
            for (int i = 0; i < FelderStatus.Length; i += 2, b -= 2)
            {
                if (!FelderStatus[4].Equals(" "))
                {
                    if (FelderStatus[i].Equals(FelderStatus[4]) && FelderStatus[b].Equals(" "))
                    {
                        return ZahlZuPosition(b + 1);
                    }
                    else if (FelderStatus[i].Equals(FelderStatus[4]) && FelderStatus[b].Equals(" "))
                    {
                        return (ZahlZuPosition(b + 1));
                    }
                }
                else
                {
                    if (FelderStatus[i].Equals(FelderStatus[b]) && !FelderStatus[i].Equals(" "))
                    {
                        return ZahlZuPosition(5);
                    }
                }

                if (i == 2)
                {
                    i += 2;
                    b -= 2;
                }
            }
            #endregion

            return KIAnfänger();
        }

        public string ZahlZuPosition(int Zahl)
        {
            if (Zahl.Equals(1))
            {
                return "A1";
            }
            else if (Zahl.Equals(2))
            {
                return "A2";
            }
            else if (Zahl.Equals(3))
            {
                return "A3";
            }
            else if (Zahl.Equals(4))
            {
                return "B1";
            }
            else if (Zahl.Equals(5))
            {
                return "B2";
            }
            else if (Zahl.Equals(6))
            {
                return "B3";
            }
            else if (Zahl.Equals(7))
            {
                return "C1";
            }
            else if (Zahl.Equals(8))
            {
                return "C2";
            }
            else
            {
                return "C3";
            }
        }

    }
}