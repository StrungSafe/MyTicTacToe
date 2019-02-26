namespace TicTacToe.Core
{
    using Interfaces;

    public class MoveValidator : IMoveValidator
    {
        public bool IsValidMove(Move move, GameState gameState, GameBoardMark[,] gameBoard)
        {
            if (IsGameOver(gameState))
            {
                return false;
            }

            if (NotPlayerTurn(move, gameState))
            {
                return false;
            }

            if (MoveExceedsGameBoardBounds(move, gameBoard))
            {
                return false;
            }

            if (IsMoveLocationOccupied(move, gameBoard))
            {
                return false;
            }

            return true;
        }

        private bool IsGameOver(GameState gameState)
        {
            return gameState.HasFlag(GameState.GameOver);
        }

        private bool IsMoveLocationOccupied(Move move, GameBoardMark[,] gameBoard)
        {
            return gameBoard[move.Row, move.Column] != GameBoardMark.Empty;
        }

        private bool MoveExceedsGameBoardBounds(Move move, GameBoardMark[,] gameBoard)
        {
            int row = gameBoard.GetLength(0);
            int column = gameBoard.GetLength(1);

            return move.Row < 0 || move.Column < 0 || move.Row >= row || move.Column >= column;
        }

        private bool NotPlayerTurn(Move move, GameState gameState)
        {
            return move.Player == Player.X && gameState == GameState.OMove ||
                   move.Player == Player.O && gameState.HasFlag(GameState.XMove);
        }
    }
}