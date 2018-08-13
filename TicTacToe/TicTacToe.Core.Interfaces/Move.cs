namespace TicTacToe.Core.Interfaces
{
    public class Move
    {
        public Move(Player player, int row, int column)
        {
            Player = player;
            Row = row;
            Column = column;
        }

        public int Column { get; }

        public Player Player { get; }

        public int Row { get; }
    }
}