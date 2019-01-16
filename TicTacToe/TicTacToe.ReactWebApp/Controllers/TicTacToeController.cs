namespace TicTacToe.ReactWebApp.Controllers
{
    using System;

    using Microsoft.AspNetCore.Mvc;

    using TicTacToe.Core;
    using TicTacToe.Core.Interfaces;

    [Route("api/[controller]")]
    public class TicTacToeController : Controller
    {
        private static readonly IGameEngine GameEngine = new GameEngine(new GameBoard(new ReactGameSettings()),
            new MoveValidator(), new GameBoardAnalyzer());

        [HttpGet("[action]")]
        public GameResult MakeMove(int gameId, int row, int column)
        {
            try
            {
                Move move;

                if (GameEngine.GameState == GameState.NewGameXMove || GameEngine.GameState == GameState.XMove)
                {
                    move = new Move(Player.X, row, column);
                }
                else
                {
                    move = new Move(Player.O, row, column);
                }

                bool success = GameEngine.MakeMove(move);

                return new GameResult
                       {
                           Success = success,
                           GameState = GameEngine.GameState.ToString(),
                           GameBoard = GameEngine.GameBoard
                       };
            }
            catch (Exception)
            {
                return new GameResult { Success = false };
            }
        }

        [HttpGet("[action]")]
        public GameResult NewGame()
        {
            try
            {
                GameEngine.NewGame();

                return new GameResult
                       {
                           Success = true, GameState = GameEngine.GameState.ToString(), GameBoard = GameEngine.GameBoard
                       };
            }
            catch (Exception)
            {
                return new GameResult { Success = false };
            }
        }
    }

    public class GameResult
    {
        public GameBoardMark[,] GameBoard { get; set; }

        public string GameState { get; set; }

        public bool Success { get; set; }
    }
}