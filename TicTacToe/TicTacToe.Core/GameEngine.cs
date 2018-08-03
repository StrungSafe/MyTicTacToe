namespace TicTacToe.Core
{
    using System;
    using Interfaces;

    public class GameEngine : IGameEngine
    {
        private readonly IGameBoard gameBoard;

        public GameEngine(IGameBoard gameBoard)
        {
            this.gameBoard = gameBoard ?? throw new ArgumentNullException(nameof(gameBoard));

            GameState = GameState.NewGameXMove;
        }

        public GameBoardMark[,] GameBoard => gameBoard.GameBoard;

        public GameState GameState { get; private set; }

        public void MakeMove()
        {
            gameBoard.PlaceMarker();
        }

        public void NewGame()
        {
            gameBoard.Clear();

            GameState = GameState.NewGameXMove;
        }
    }
}