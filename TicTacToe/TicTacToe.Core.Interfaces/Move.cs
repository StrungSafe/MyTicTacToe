namespace TicTacToe.Core.Interfaces
{
    public class Move
    {
        public Move(Player player)
        {
            Player = player;
        }

        public Player Player { get; }
    }
}