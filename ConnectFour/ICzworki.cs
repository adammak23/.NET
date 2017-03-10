using System;

namespace ConnectFour
{
    public interface ICzworki
    {
        int CheckingDiagonal();
        int CheckingHorizontal();
        int CheckingVertical();
        int index(int i, int j);
        int tura(int row);
        int TurnTimeout();
        DateTime GetCurrentDate();
    }
}