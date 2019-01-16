namespace TicTacToe.ReactWebApp
{
    using TicTacToe.Core.Interfaces;

    public class ReactGameSettings : IGameSettings
    {
        public int Size => 3;
    }
}