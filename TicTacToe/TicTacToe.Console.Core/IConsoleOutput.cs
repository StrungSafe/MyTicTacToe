namespace TicTacToe.Console.Core
{
    public interface IConsoleOutput
    {
        void Clear();

        void Write(string value);

        void WriteLine(string value);

        void WriteLine();
    }
}