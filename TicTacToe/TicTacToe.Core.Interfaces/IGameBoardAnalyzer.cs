namespace TicTacToe.Core.Interfaces
{
    public interface IGameBoardAnalyzer
    {
        GameBoardState AnalyzeGameBoard(GameBoardMark[,] gameBoard);
    }
}