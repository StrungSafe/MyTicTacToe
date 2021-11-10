namespace TicTacToe.ReactWebApp
{
    using TicTacToe.Core.Interfaces;

    public interface IGameEngineFactory
    {
        IGameEngine GetEngine();
    }
}