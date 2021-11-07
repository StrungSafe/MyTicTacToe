namespace TicTacToe.ReactWebApp.Controllers
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using TicTacToe.Core;
    using TicTacToe.Core.Interfaces;

    [Route("api/[controller]")]
    public class TicTacToeController : Controller
    {
        private static readonly Dictionary<string, IGameEngine> GameEngines = new Dictionary<string, IGameEngine>();

        private readonly IGameEngine gameEngine;

        private readonly ILogger logger;

        public TicTacToeController(ILogger<TicTacToeController> logger, IHttpContextAccessor accessor)
        {
            this.logger = logger;

            string id = accessor.HttpContext.Session.GetString("engineId");

            if (string.IsNullOrEmpty(id))
            {
                id = Guid.NewGuid().ToString();
                accessor.HttpContext.Session.SetString("engineId", id);
            }

            if (GameEngines.ContainsKey(id))
            {
                gameEngine = GameEngines[id];
            }
            else
            {
                var engine = new GameEngine(new GameBoard(new ReactGameSettings()), new MoveValidator(),
                    new GameBoardAnalyzer());
                GameEngines.Add(id, engine);
                gameEngine = engine;
            }
        }

        [HttpGet("[action]")]
        public GameResult MakeMove(int gameId, int row, int column)
        {
            try
            {
                Move move;

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
                gameEngine.NewGame();

                return new GameResult
                       {
                           Success = true, GameState = gameEngine.GameState.ToString(), GameBoard = gameEngine.GameBoard
                       };
            }
            catch (Exception)
            {
                return new GameResult { Success = false };
            }
        }
    }
}