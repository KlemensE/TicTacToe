namespace TicTacToe
{
    public enum Status
    {
        Spieler1Gewonnen,
        Spieler2Gewonnen,
        KeinGewinner,
        KeineZügemehrmöglich
    }

    class Spielregeln : Program
    {
        /// <summary>
        /// Konntrolliert ob ein Spieler gewonnen hat oder nicht
        /// </summary>
        /// <returns>Den Status des Spiels</returns>
        public Status ÜberprüfungPosition()
        {
            #region Zeilen
            for (int i = 0; i < 8; i+= 3)
            {
                if (FelderStatus[i].Equals(" "))
                {
                    if ((FelderStatus[i].Equals(FelderStatus[i + 1]) && FelderStatus[i].Equals(FelderStatus[i + 2])))
                    {
                        if (FelderStatus[i].Equals("X"))
                        {
                            return Status.Spieler1Gewonnen;
                        }
                        if (FelderStatus[i].Equals("X"))
                        {
                            return Status.Spieler2Gewonnen;
                        }
                    }
                }
            }
            #endregion

            #region Spalten

            for (int i = 0; i < 3; i++)
            {
                if (FelderStatus[i].Equals(" "))
                {
                    if ((FelderStatus[i].Equals(FelderStatus[i + 3]) && FelderStatus[i].Equals(FelderStatus[i + 6])))
                    {
                        if (FelderStatus[i].Equals("X"))
                        {
                            return Status.Spieler1Gewonnen;
                        }
                        if (FelderStatus[i].Equals("X"))
                        {
                            return Status.Spieler2Gewonnen;
                        }
                    }
                }
            }
            #endregion

            #region Diagonal
            if (FelderStatus[0].Equals(FelderStatus[4]) && FelderStatus[0].Equals(FelderStatus[8]))
            {
                if (FelderStatus[0].Equals("X"))
                {
                    return Status.Spieler1Gewonnen;
                }
                if (FelderStatus[0].Equals("O"))
                {
                    return Status.Spieler2Gewonnen;
                }
            }
            else if (FelderStatus[2].Equals(FelderStatus[4]) && FelderStatus[2].Equals(FelderStatus[6]))
            {
                if (FelderStatus[2].Equals("X"))
                {
                    return Status.Spieler1Gewonnen;
                }
                if (FelderStatus[2].Equals("O"))
                {
                    return Status.Spieler2Gewonnen;
                }
            }

            #endregion

            return Status.KeinGewinner;
        }

        /// <summary>
        /// Kontrolliert ob in Feld geschrieben werden darf oder nicht
        /// </summary>
        /// <param name="eingabe">Der vom benutzer angegebene String</param>
        /// <param name="spielZeichen">Welches Zeichen gesetzt werden soll</param>
        /// <returns>boolean der sagt ob Feldfrei ist oder nicht</returns>
        public bool PositionsBestimmung(string eingabe, string spielZeichen)
        {
            EinAusGabe InOut = new EinAusGabe();
            eingabe = InOut.PositionsControlle(eingabe);
            if (eingabe[0].Equals('A') || eingabe[0].Equals('a'))
            {
                if (eingabe[1].Equals('1') && !FelderBesetzt[0])
                {
                    FelderStatus[0] = spielZeichen;
                    FelderBesetzt[0] = true;
                }
                else if (eingabe[1].Equals('2') && !FelderBesetzt[1])
                {
                    FelderStatus[1] = spielZeichen;
                    FelderBesetzt[1] = true;
                }
                else if (eingabe[1].Equals('3') && !FelderBesetzt[2])
                {
                    FelderStatus[2] = spielZeichen;
                    FelderBesetzt[2] = true;
                }
                else
                {
                    return false;
                }
            }

            else if (eingabe[0].Equals('B') || eingabe[0].Equals('b'))
            {
                if (eingabe[1].Equals('1') && !FelderBesetzt[3])
                {
                    FelderStatus[3] = spielZeichen;
                    FelderBesetzt[3] = true;
                }
                else if (eingabe[1].Equals('2') && !FelderBesetzt[4])
                {
                    FelderStatus[4] = spielZeichen;
                    FelderBesetzt[4] = true;
                }
                else if (eingabe[1].Equals('3') && !FelderBesetzt[5])
                {
                    FelderStatus[5] = spielZeichen;
                    FelderBesetzt[5] = true;
                }
                else
                {
                    return false;
                }
            }

            else if (eingabe[0].Equals('C') || eingabe[0].Equals('c'))
            {
                if (eingabe[1].Equals('1') && !FelderBesetzt[6])
                {
                    FelderStatus[6] = spielZeichen;
                    FelderBesetzt[6] = true;
                }
                else if (eingabe[1].Equals('2') && !FelderBesetzt[7])
                {
                    FelderStatus[7] = spielZeichen;
                    FelderBesetzt[7] = true;
                }
                else if (eingabe[1].Equals('3') && !FelderBesetzt[8])
                {
                    FelderStatus[8] = spielZeichen;
                    FelderBesetzt[8] = true;
                }
                else
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}