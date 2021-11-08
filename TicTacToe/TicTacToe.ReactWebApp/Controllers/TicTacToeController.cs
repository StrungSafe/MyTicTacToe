namespace TicTacToe.ReactWebApp.Controllers
{
    using System;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using TicTacToe.Core.Interfaces;

    [Route("api/[controller]")]
    public class TicTacToeController : Controller
    {
        private readonly IGameEngineFactory factory;

        private readonly ILogger logger;

        public TicTacToeController(ILogger<TicTacToeController> logger, IGameEngineFactory factory)
        {
            this.logger = logger;
            this.factory = factory;
        }

        [HttpGet("[action]")]
        public GameResult MakeMove(int row, int column)
        {
            try
            {
                Move move;

                IGameEngine gameEngine = factory.GetEngine();

                if (gameEngine.GameState == GameState.NewGameXMove || gameEngine.GameState == GameState.XMove)
                {
                    move = new Move(Player.X, row, column);
                }
                else
                {
                    move = new Move(Player.O, row, column);
                }

                bool success = gameEngine.MakeMove(move);

                return new GameResult
                       {
                           Success = success,
                           GameState = gameEngine.GameState.ToString(),
                           GameBoard = gameEngine.GameBoard
                       };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "There was an unhandled error making a move.");
                return new GameResult { Success = false };
            }
        }

        [HttpGet("[action]")]
        public GameResult NewGame()
        {
            try
            {
                IGameEngine gameEngine = factory.GetEngine();

                gameEngine.NewGame();

                return new GameResult
                       {
                           Success = true, GameState = gameEngine.GameState.ToString(), GameBoard = gameEngine.GameBoard
                       };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "There was an unhandled error starting a new game.");
                return new GameResult { Success = false };
            }
        }
    }
}