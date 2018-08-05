namespace TicTacToe.Core
{
    using Interfaces;

    public class GameBoard : IGameBoard
    {
        private readonly IGameBoardSettings gameBoardSettings;

        private GameBoardMark[,] innerBoard;

        public GameBoard(IGameBoardSettings gameBoardSettings)
        {
            this.gameBoardSettings = gameBoardSettings;

            CreateNewGameBoard();
        }

        public GameBoardMark[,] Board => innerBoard.Clone() as GameBoardMark[,];

        public void Clear()
        {
            CreateNewGameBoard();
        }

        public void PlaceMarker(Move move)
        {
            innerBoard[move.Row, move.Column] = move.Player == Player.X ? GameBoardMark.X : GameBoardMark.O;
        }

        private void CreateNewGameBoard()
        {
            int size = gameBoardSettings.Size;
            innerBoard = new GameBoardMark[size, size];

            for (var row = 0; row < innerBoard.GetLength(0); row++)
            {
                for (var column = 0; column < innerBoard.GetLength(1); column++)
                {
                    innerBoard[row, column] = GameBoardMark.Empty;
                }
            }
        }
    }
}