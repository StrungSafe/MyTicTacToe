namespace TicTacToe.Console.Core
{
    using TicTacToe.Core.Interfaces;

    public class ConsoleGameSettings : IGameSettings
    {
        public int Size => 3;
    }
}