using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    public class Czworki : ICzworki
    {
        public int[,] array = new int[6, 7];
        bool O = true;
        bool X = false;
        public string playerO;
        public string playerX;
        public string actualPlayer;
        public DateTime TimeOFMatchStart;

        public int index(int i, int j)
        {
            return array[i, j];
        }

        public void SetPlayersNames(string player1, string player2)
        {
            playerO = player1;
            playerX = player2;
        }
        public int tura(int row)
        {
            if (array[0, row - 1] != 0) return 0;
            {
                if (O)
                {
                    actualPlayer = playerO;
                    for (int i = 5; i >= 0; i--)
                    {
                        if (array[i, row - 1] == 0) { array[i, row - 1] = 2; break; }
                    }
                    O = false;
                    X = true;
                    return 2;
                }

                if (X)
                {
                    actualPlayer = playerX;
                    for (int i = 5; i >= 0; i--)
                    {
                        if (array[i, row - 1] == 0) { array[i, row - 1] = 1; break; }
                    }
                    O = true;
                    X = false;
                    return 1;
                }
            }
            return 0;
        }





        public int CheckingHorizontal()
        {
            int Ocol = 0;
            int Xcol = 0;

            for (int i = 0; i < 6; i++)
            {
                Ocol = 0;
                Xcol = 0;

                for (int k = 0; k < 7; k++) //horizontal checking winner
                {
                    if (array[i, k] == 1) Xcol++;
                    if (array[i, k] == 2) Ocol++;
                    if (Ocol == 4) return 2;
                    if (Xcol == 4) return 1;
                }

            }
            return 0;
        }

        public int CheckingVertical()
        {
            int Orow = 0;
            int Xrow = 0;

            for (int j = 0; j < 7; j++) //vertical checking winner
            {
                for (int k = 0; k < 6; k++)
                {
                    if (array[k, j] == 1) Xrow++;
                    if (array[k, j] == 2) Orow++;
                    if (array[k, j] == 0) { Xrow = 0; Orow = 0; }
                    if (Orow == 4) return 4;
                    if (Xrow == 4) return 3;
                }
            }
            return 0;
        }




        public int CheckingDiagonal()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (i + 3 < 6 && j + 3 < 7)
                    {
                        if (array[i, j] == 2 && array[i + 1, j + 1] == 2 && array[i + 2, j + 2] == 2 && array[i + 3, j + 3] == 2) return 4;

                        if (array[i, j] == 1 && array[i + 1, j + 1] == 1 && array[i + 2, j + 2] == 1 && array[i + 3, j + 3] == 1) return 3;
                    }
                    if (i + 3 < 6 && j - 3 >= 0)
                    {
                        if (array[i, j] == 2 && array[i + 1, j - 1] == 2 && array[i + 2, j - 2] == 2 && array[i + 3, j - 3] == 2) return 2;

                        if (array[i, j] == 1 && array[i + 1, j - 1] == 1 && array[i + 2, j - 2] == 1 && array[i + 3, j - 3] == 1) return 1;
                    }
                }
            }
            return 0;
        }


        public int TurnTimeout()
        {
            TimeOFMatchStart = GetCurrentDate();
            if ((DateTime.Now - TimeOFMatchStart).Seconds >= 30)
            {
                if (O)
                {
                    O = false;
                    X = true;
                }
                if (X)
                {
                    X = false;
                    O = true;
                }
            }
            return (DateTime.Now - TimeOFMatchStart).Seconds;
        }
        public DateTime GetCurrentDate()
        {
            return DateTime.Now;
        }


    }
}