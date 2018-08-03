namespace TicTacToe.Core.Tests
{
    using Interfaces;
    using NUnit.Framework;

    [TestFixture]
    public class TestGameEngine
    {
        [SetUp]
        public void SetUp()
        {
            systemUnderTest = new GameEngine();
        }

        private IGameEngine systemUnderTest;

        [Test]
        public void NewGame_WhenInvoked_SetsNewGame()
        {
            systemUnderTest.NewGame();
        }
    }
}