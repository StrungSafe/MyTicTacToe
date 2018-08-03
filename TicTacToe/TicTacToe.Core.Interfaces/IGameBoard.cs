namespace TicTacToe.Core.Interfaces
{
    public interface IGameBoard
    {
        void Clear();

        void PlaceMarker();

        GameBoardMark[,] GameBoard { get; }
    }
}