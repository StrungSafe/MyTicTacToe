namespace TicTacToe.Console.Core
{
    using System;

    public class ConsoleOutput : IConsoleOutput
    {
        public void Write(string value)
        {
            Console.Write(value);
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}