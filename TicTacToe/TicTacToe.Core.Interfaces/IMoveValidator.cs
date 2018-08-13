namespace TicTacToe.Core.Interfaces
{
    public interface IMoveValidator
    {
        bool IsValidMove(Move move, GameState gameState, GameBoardMark[,] gameBoard);
    }
}