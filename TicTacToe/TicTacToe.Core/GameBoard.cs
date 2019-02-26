namespace TicTacToe.Core
{
    using TicTacToe.Core.Interfaces;

    public class GameBoard : IGameBoard
    {
        private readonly IGameSettings gameSettings;

        private GameBoardMark[,] innerBoard;

        public GameBoard(IGameSettings gameSettings)
        {
            this.gameSettings = gameSettings;

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
            int size = gameSettings.Size;
            innerBoard = new GameBoardMark[size, size];

            for (var row = 0; row < size; row++)
            {
                for (var column = 0; column < size; column++)
                {
                    innerBoard[row, column] = GameBoardMark.Empty;
                }
            }
        }
    }
}