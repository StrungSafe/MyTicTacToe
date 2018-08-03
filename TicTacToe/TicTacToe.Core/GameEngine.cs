namespace TicTacToe.Core
{
    using System;
    using Interfaces;

    public class GameEngine : IGameEngine
    {
        private readonly IGameBoard gameBoard;

        private readonly IMoveValidator moveValidator;

        private readonly IWinnerAnalyzer winnerAnalyzer;

        public GameEngine(IGameBoard gameBoard, IMoveValidator moveValidator, IWinnerAnalyzer winnerAnalyzer)
        {
            this.gameBoard = gameBoard ?? throw new ArgumentNullException(nameof(gameBoard));
            this.moveValidator = moveValidator ?? throw new ArgumentNullException(nameof(moveValidator));
            this.winnerAnalyzer = winnerAnalyzer ?? throw new ArgumentNullException(nameof(winnerAnalyzer));

            NewGame();
        }

        public GameBoardMark[,] GameBoard => gameBoard.GameBoard;

        public GameState GameState { get; private set; }

        public void MakeMove()
        {
            moveValidator.ValidateMove();
            gameBoard.PlaceMarker();
            winnerAnalyzer.AnalyzeGameBoard();
        }

        public void NewGame()
        {
            gameBoard.Clear();

            GameState = GameState.NewGameXMove;
        }
    }
}