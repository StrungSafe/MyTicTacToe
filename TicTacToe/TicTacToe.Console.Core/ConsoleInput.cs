namespace TicTacToe.Console.Core
{
    using System;

    public class ConsoleInput : IConsoleInput
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}