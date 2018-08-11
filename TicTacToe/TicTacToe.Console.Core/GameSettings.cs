namespace TicTacToe.Console.Core
{
    using TicTacToe.Core.Interfaces;

    public class GameSettings : IGameSettings
    {
        public int Size => 3;
    }
}