namespace TicTacToe.Core.Interfaces
{
    public interface IGameEngine
    {
        void MakeMove();

        void NewGame();

        GameBoardMark[,] GameBoard { get; }

        GameState GameState { get; }
    }
}