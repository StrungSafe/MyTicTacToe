namespace TicTacToe.Core.Interfaces
{
    public interface IGameEngine
    {
        GameBoardMark[,] GameBoard { get; }

        GameState GameState { get; }

        bool MakeMove(Move move);

        void NewGame();
    }
}