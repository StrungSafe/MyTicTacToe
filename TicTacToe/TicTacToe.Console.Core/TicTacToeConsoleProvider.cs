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
                Clear();
                Draw(gameEngine.GameBoard);
                MakeMove();
            } while (gameEngine.GameState.HasFlag(GameState.Active));

            Clear();
            PrintEndOfGameState();
            Draw(gameEngine.GameBoard);
        }

        private void Clear()
        {
            consoleOutput.Clear();
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
            if (gameEngine.GameState.HasFlag(GameState.XMove))
            {
                return "X";
            }

            if (gameEngine.GameState == GameState.OMove)
            {
                return "O";
            }

            if (gameEngine.GameState == GameState.Tie)
            {
                return "Tie Game";
            }

            if (gameEngine.GameState == GameState.XWinner)
            {
                return "X is the winner";
            }

            if (gameEngine.GameState == GameState.OWinner)
            {
                return "O is the winner";
            }

            throw new ArgumentOutOfRangeException();
        }

        private Player GetPlayer()
        {
            if (gameEngine.GameState.HasFlag(GameState.XMove))
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
            consoleOutput.WriteLine();
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
                    "There was a problem with the move. Ensure withing board limits and space not already taken. Try again.");
            }
        }

        private void PrintEndOfGameState()
        {
            consoleOutput.WriteLine(GetGameState());
            consoleOutput.WriteLine();
        }
    }
}