namespace TicTacToe.Core
{
    using System;

    using TicTacToe.Core.Interfaces;

    public class GameEngine : IGameEngine
    {
        private readonly IGameBoard gameBoard;

        private readonly IGameBoardAnalyzer gameBoardAnalyzer;

        private readonly Guid guid;

        private readonly IMoveValidator moveValidator;

        public GameEngine(IGameBoard gameBoard, IMoveValidator moveValidator, IGameBoardAnalyzer gameBoardAnalyzer)
        {
            this.gameBoard = gameBoard ?? throw new ArgumentNullException(nameof(gameBoard));
            this.moveValidator = moveValidator ?? throw new ArgumentNullException(nameof(moveValidator));
            this.gameBoardAnalyzer = gameBoardAnalyzer ?? throw new ArgumentNullException(nameof(gameBoardAnalyzer));

            guid = Guid.NewGuid();

            NewGame();
        }

        public GameBoardMark[,] GameBoard => gameBoard.Board;

        public GameState GameState { get; private set; }

        public string Id => guid.ToString();

        public bool MakeMove(Move move)
        {
            if (!moveValidator.IsValidMove(move, GameState, GameBoard))
            {
                return false;
            }

            gameBoard.PlaceMarker(move);

            GameBoardState gameBoardState = gameBoardAnalyzer.AnalyzeGameBoard(GameBoard);

            UpdateGameState(gameBoardState);

            return true;
        }

        public void NewGame()
        {
            gameBoard.Clear();

            GameState = GameState.NewGameXMove;
        }

        private void UpdateGameState(GameBoardState newGameBoardState)
        {
            if (GameState.HasFlag(GameState.XMove))
            {
                GameState = GameState.OMove;
            }
            else if (GameState == GameState.OMove)
            {
                GameState = GameState.XMove;
            }

            if (newGameBoardState == GameBoardState.Tie)
            {
                GameState = GameState.Tie;
            }
            else if (newGameBoardState == GameBoardState.XWinner)
            {
                GameState = GameState.XWinner;
            }
            else if (newGameBoardState == GameBoardState.OWinner)
            {
                GameState = GameState.OWinner;
            }
        }
    }
}