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
            var move = new Move(player);

            bool actual = systemUnderTest.IsValidMove(move, gameState, new GameBoardMark[0, 0]);

            Assert.That(actual, Is.False);
        }
    }
}