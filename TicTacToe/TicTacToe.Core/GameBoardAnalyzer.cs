namespace TicTacToe.Core
{
    using Interfaces;

    public class GameBoardAnalyzer : IGameBoardAnalyzer
    {
        public GameBoardState AnalyzeGameBoard(GameBoardMark[,] gameBoard)
        {
            if (IsMinimumMovesNotBeenMade(gameBoard))
            {
                return GameBoardState.Active;
            }

            if (TryWinningRow(gameBoard, out GameBoardState gameBoardState))
            {
                return gameBoardState;
            }

            if (TryWinningColumn(gameBoard, out gameBoardState))
            {
                return gameBoardState;
            }

            if (TryWinningDiagonal(gameBoard, out gameBoardState))
            {
                return gameBoardState;
            }

            if (TryTie(gameBoard, out gameBoardState))
            {
                return gameBoardState;
            }

            return GameBoardState.Active;
        }

        private bool IsMinimumMovesNotBeenMade(GameBoardMark[,] gameBoard)
        {
            int minimumNumberOfMarksForWin = 2 * gameBoard.GetLength(0) - 1;
            var movesBeenMadeCount = 0;

            foreach (GameBoardMark gameBoardMark in gameBoard)
            {
                if (gameBoardMark != GameBoardMark.Empty)
                {
                    movesBeenMadeCount++;

                    if (movesBeenMadeCount == minimumNumberOfMarksForWin)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool TryTie(GameBoardMark[,] gameBoard, out GameBoardState gameBoardState)
        {
            foreach (GameBoardMark gameBoardMark in gameBoard)
            {
                if (gameBoardMark == GameBoardMark.Empty)
                {
                    gameBoardState = GameBoardState.Active;
                    return false;
                }
            }

            gameBoardState = GameBoardState.Tie;
            return true;
        }

        private bool TryWinningBackwardDiagonal(GameBoardMark[,] gameBoard, out GameBoardState gameBoardState)
        {
            int rowLength = gameBoard.GetLength(0);
            int columnLength = gameBoard.GetLength(1);

            var winningBackwardDiagonal = true;
            var matchingMark = GameBoardMark.Empty;

            int rowIndex = 0, columnIndex = 0;

            for (; rowIndex < rowLength && columnIndex < columnLength; rowIndex++, columnIndex++)
            {
                if (rowIndex == 0)
                {
                    matchingMark = gameBoard[rowIndex, columnIndex];
                }

                if (gameBoard[rowIndex, columnIndex] != matchingMark)
                {
                    winningBackwardDiagonal = false;
                    break;
                }
            }

            if (matchingMark == GameBoardMark.Empty)
            {
                gameBoardState = GameBoardState.Active;
                return false;
            }

            gameBoardState = winningBackwardDiagonal && matchingMark == GameBoardMark.X ? GameBoardState.XWinner
                : GameBoardState.OWinner;

            return winningBackwardDiagonal;
        }

        private bool TryWinningColumn(GameBoardMark[,] gameBoard, out GameBoardState gameBoardState)
        {
            int rowLength = gameBoard.GetLength(0);
            int columnLength = gameBoard.GetLength(1);

            var winningColumn = false;
            var matchingMark = GameBoardMark.Empty;

            for (var columnIndex = 0; columnIndex < columnLength; columnIndex++)
            {
                matchingMark = GameBoardMark.Empty;
                winningColumn = true;

                for (var rowIndex = 0; rowIndex < rowLength; rowIndex++)
                {
                    if (rowIndex == 0)
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

            if (matchingMark == GameBoardMark.Empty)
            {
                gameBoardState = GameBoardState.Active;
                return false;
            }

            gameBoardState = winningColumn && matchingMark == GameBoardMark.X ? GameBoardState.XWinner
                : GameBoardState.OWinner;

            return winningColumn;
        }

        private bool TryWinningDiagonal(GameBoardMark[,] gameBoard, out GameBoardState gameBoardState)
        {
            return TryWinningBackwardDiagonal(gameBoard, out gameBoardState) ||
                   TryWinningForwardDiagonal(gameBoard, out gameBoardState);
        }

        private bool TryWinningForwardDiagonal(GameBoardMark[,] gameBoard, out GameBoardState gameBoardState)
        {
            int rowLength = gameBoard.GetLength(0);
            int columnLength = gameBoard.GetLength(1);

            var winningForwardDiagonal = true;
            var matchingMark = GameBoardMark.Empty;

            int rowIndex = rowLength - 1, columnIndex = 0;

            for (; rowIndex >= 0 && columnIndex < columnLength; rowIndex--, columnIndex++)
            {
                if (rowIndex == rowLength - 1)
                {
                    matchingMark = gameBoard[rowIndex, columnIndex];
                }

                if (gameBoard[rowIndex, columnIndex] != matchingMark)
                {
                    winningForwardDiagonal = false;
                    break;
                }
            }

            if (matchingMark == GameBoardMark.Empty)
            {
                gameBoardState = GameBoardState.Active;
                return false;
            }

            gameBoardState = winningForwardDiagonal && matchingMark == GameBoardMark.X ? GameBoardState.XWinner
                : GameBoardState.OWinner;

            return winningForwardDiagonal;
        }

        private bool TryWinningRow(GameBoardMark[,] gameBoard, out GameBoardState gameBoardState)
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

            if (matchingMark == GameBoardMark.Empty)
            {
                gameBoardState = GameBoardState.Active;
                return false;
            }

            gameBoardState = winningRow && matchingMark == GameBoardMark.X ? GameBoardState.XWinner
                : GameBoardState.OWinner;

            return winningRow;
        }
    }
}