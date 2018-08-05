namespace TicTacToe.Core
{
    using Interfaces;

    public class GameBoardAnalyzer : IGameBoardAnalyzer
    {
        public GameBoardState AnalyzeGameBoard(GameBoardMark[,] gameBoard)
        {
            int rowLength = gameBoard.GetLength(0);
            int columnLength = gameBoard.GetLength(1);

            var winningRow = false;
            var matchingMark = GameBoardMark.Empty;

            for (var rowIndex = 0; rowIndex < rowLength; rowIndex++)
            {
                matchingMark = GameBoardMark.Empty;
                winningRow = true;

                for (var columnIndex = 0; columnIndex < columnLength; columnIndex++)
                {
                    if (columnIndex == 0)
                    {
                        matchingMark = gameBoard[rowIndex, columnIndex];
                    }

                    if (gameBoard[rowIndex, columnIndex] != matchingMark)
                    {
                        winningRow = false;
                        break;
                    }
                }

                if (winningRow)
                {
                    break;
                }
            }

            if (winningRow)
            {
                return matchingMark == GameBoardMark.X ? GameBoardState.XWinner : GameBoardState.OWinner;
            }

            var winningColumn = false;

            for (var columnIndex = 0; columnIndex < columnLength; columnIndex++)
            {
                matchingMark = GameBoardMark.Empty;
                winningColumn = true;

                for (var rowIndex = 0; rowIndex < rowLength; rowIndex++)
                {
                    if (columnIndex == 0)
                    {
                        matchingMark = gameBoard[rowIndex, columnIndex];
                    }

                    if (gameBoard[rowIndex, columnIndex] != matchingMark)
                    {
                        winningColumn = false;
                        break;
                    }
                }

                if (winningColumn)
                {
                    break;
                }
            }

            if (winningColumn)
            {
                return matchingMark == GameBoardMark.X ? GameBoardState.XWinner : GameBoardState.OWinner;
            }

            return GameBoardState.Active;
        }
    }
}