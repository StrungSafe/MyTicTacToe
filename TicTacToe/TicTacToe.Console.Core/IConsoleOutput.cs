namespace TicTacToe.Console.Core
{
    public interface IConsoleOutput
    {
        void Write(string value);

        void WriteLine(string value);
    }
}