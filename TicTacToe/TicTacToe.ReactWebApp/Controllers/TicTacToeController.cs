namespace TicTacToe.ReactWebApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using TicTacToe.Core;
    using TicTacToe.Core.Interfaces;

    [Route("api/[controller]")]
    public class TicTacToeController : Controller
    {
        [HttpGet("[action]")]
        public GameResult NewGame()
        {
            return new GameResult();
        }

        [HttpGet("[action]")]
        public GameResult MakeMove(int x, int y)
        {
            return new GameResult();
        }
    }

    public class GameResult
    {
        public bool Success { get; set; }
        public string GameState { get; set; }
    }
}