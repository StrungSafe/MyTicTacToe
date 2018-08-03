namespace TicTacToe.Core.Interfaces
{
    public interface IGameEngine
    {
        GameBoardMark[,] GameBoard { get; }

        GameState GameState { get; }

        void MakeMove();

        void NewGame();
    }
}