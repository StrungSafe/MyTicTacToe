namespace TicTacToe.Console.Core
{
    using System;
    using TicTacToe.Core.Interfaces;

    public class TicTacToeConsoleProvider : ITicTacToeConsoleService
    {
        private readonly IConsoleInput consoleInput;

        private readonly IConsoleOutput consoleOutput;

        private readonly IGameEngine gameEngine;

        public TicTacToeConsoleProvider(IGameEngine gameEngine, IConsoleOutput consoleOutput,
            IConsoleInput consoleInput)
        {
            this.gameEngine = gameEngine;
            this.consoleOutput = consoleOutput;
            this.consoleInput = consoleInput;
        }

        public void Run()
        {
            do
            {
                Draw(gameEngine.GameBoard);
                MakeMove();
            } while (gameEngine.GameState == GameState.NewGameXMove || gameEngine.GameState == GameState.XMove ||
                     gameEngine.GameState == GameState.OMove);

            Draw(gameEngine.GameBoard);
        }

        private void Draw(GameBoardMark[,] gameEngineGameBoard)
        {
            consoleOutput.WriteLine(
                $"{GetDrawImage(gameEngineGameBoard[0, 0])}|{GetDrawImage(gameEngineGameBoard[0, 1])}|{GetDrawImage(gameEngineGameBoard[0, 2])}");
            consoleOutput.WriteLine(
                $"{GetDrawImage(gameEngineGameBoard[1, 0])}|{GetDrawImage(gameEngineGameBoard[1, 1])}|{GetDrawImage(gameEngineGameBoard[1, 2])}");
            consoleOutput.WriteLine(
                $"{GetDrawImage(gameEngineGameBoard[2, 0])}|{GetDrawImage(gameEngineGameBoard[2, 1])}|{GetDrawImage(gameEngineGameBoard[2, 2])}");
        }

        private string GetDrawImage(GameBoardMark gameBoardMark)
        {
            if (gameBoardMark == GameBoardMark.Empty)
            {
                return " ";
            }

            if (gameBoardMark == GameBoardMark.X)
            {
                return "X";
            }

            if (gameBoardMark == GameBoardMark.O)
            {
                return "O";
            }

            throw new ArgumentOutOfRangeException();
        }

        private string GetGameState()
        {
            if (gameEngine.GameState == GameState.NewGameXMove || gameEngine.GameState == GameState.XMove)
            {
                return "X";
            }

            if (gameEngine.GameState == GameState.OMove)
            {
                return "O";
            }

            throw new ArgumentOutOfRangeException();
        }

        private Player GetPlayer()
        {
            if (gameEngine.GameState == GameState.NewGameXMove || gameEngine.GameState == GameState.XMove)
            {
                return Player.X;
            }

            if (gameEngine.GameState == GameState.OMove)
            {
                return Player.O;
            }

            throw new ArgumentOutOfRangeException();
        }

        private void MakeMove()
        {
            consoleOutput.WriteLine($"{GetGameState()} Move");
            consoleOutput.Write("Row: ");
            string row = consoleInput.ReadLine();
            consoleOutput.Write("Column: ");
            string column = consoleInput.ReadLine();

            var move = new Move(GetPlayer(), Convert.ToInt32(row) - 1, Convert.ToInt32(column) - 1);

            bool moveMade = gameEngine.MakeMove(move);

            if (!moveMade)
            {
                consoleOutput.WriteLine(
                    "There was a problem with the move. Ensure withing board limits and not already taken. Try again.");
            }
        }
    }
}