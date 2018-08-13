namespace TicTacToe.Core.Interfaces
{
    public interface IGameBoard
    {
        GameBoardMark[,] Board { get; }

        void Clear();

        void PlaceMarker(Move move);
    }
}