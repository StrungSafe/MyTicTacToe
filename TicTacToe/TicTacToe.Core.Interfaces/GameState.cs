namespace TicTacToe.Core.Interfaces
{
    using System;

    [Flags]
    public enum GameState
    {
        Active = 2,

        GameOver = 4,

        NewGameXMove = 11,

        OMove = 18,

        OWinner = 20,

        Tie = 28,

        XMove = 10,

        XWinner = 12
    }
}