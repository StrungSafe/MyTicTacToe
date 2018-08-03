namespace TicTacToe.Core.Interfaces
{
    public interface IGameBoard
    {
        GameBoardMark[,] GameBoard { get; }

        void Clear();

        void PlaceMarker();
    }
}