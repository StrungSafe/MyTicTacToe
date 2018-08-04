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

            if (NotPlayerTurn(move.Player, gameState))
            {
                return false;
            }

            return true;
        }

        private bool IsGameOver(GameState gameState)
        {
            return gameState == GameState.XWinner || gameState == GameState.OWinner || gameState == GameState.Tie;
        }

        private bool NotPlayerTurn(Player player, GameState gameState)
        {
            return player == Player.X && gameState == GameState.OMove ||
                   player == Player.O && gameState == GameState.NewGameXMove ||
                   player == Player.O && gameState == GameState.XMove;
        }
    }
}