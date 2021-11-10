namespace TicTacToe.ReactWebApp
{
    using TicTacToe.Core.Interfaces;

    public class GameResult
    {
        public GameBoardMark[,] GameBoard { get; set; }

        public string GameState { get; set; }

        public bool Success { get; set; }
    }
}