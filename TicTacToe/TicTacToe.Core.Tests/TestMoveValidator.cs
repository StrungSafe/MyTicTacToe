namespace TicTacToe.Core.Tests
{
    using Interfaces;
    using NUnit.Framework;

    [TestFixture]
    public class TestMoveValidator
    {
        [SetUp]
        public void SetUp()
        {
            systemUnderTest = new MoveValidator();
        }

        private IMoveValidator systemUnderTest;

        [TestCase(2, 0, 2)]
        [TestCase(2, 2, 0)]
        public void IsValidMove_WhenMoveExceedsBoard_ReturnsFalse(int size, int row, int column)
        {
            bool actual = systemUnderTest.IsValidMove(new Move(Player.X, row, column), GameState.NewGameXMove,
                new GameBoardMark[size, size]);

            Assert.IsFalse(actual);
        }

        [TestCase(GameBoardMark.X)]
        [TestCase(GameBoardMark.O)]
        public void IsValidMove_WhenMoveLocationOccupied_ReturnsFalse(GameBoardMark gameBoardMark)
        {
            bool actual = systemUnderTest.IsValidMove(new Move(Player.X, 0, 0), GameState.NewGameXMove, new[,]
            {
                { gameBoardMark }
            });

            Assert.IsFalse(actual);
        }

        [TestCase(Player.X, GameState.OMove)]
        [TestCase(Player.X, GameState.XWinner)]
        [TestCase(Player.X, GameState.OWinner)]
        [TestCase(Player.X, GameState.Tie)]
        [TestCase(Player.O, GameState.NewGameXMove)]
        [TestCase(Player.O, GameState.XMove)]
        [TestCase(Player.O, GameState.XWinner)]
        [TestCase(Player.O, GameState.OWinner)]
        [TestCase(Player.O, GameState.Tie)]
        public void IsValidMove_WhenNotPlayerTurn_ReturnsFalse(Player player, GameState gameState)
        {
            var move = new Move(player, 0, 0);

            bool actual = systemUnderTest.IsValidMove(move, gameState, new GameBoardMark[1, 1]);

            Assert.IsFalse(actual);
        }

        [Test]
        public void IsValidMove_WhenValidMove_ReturnsTrue()
        {
            bool actual = systemUnderTest.IsValidMove(new Move(Player.X, 0, 0), GameState.NewGameXMove,
                new GameBoardMark[1, 1]);

            Assert.IsTrue(actual);
        }
    }
}