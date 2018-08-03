namespace TicTacToe.Core.Tests
{
    using System;
    using Interfaces;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class TestGameEngine
    {
        [SetUp]
        public void SetUp()
        {
            gameBoardMock = Substitute.For<IGameBoard>();

            systemUnderTest = NewGameEngine(gameBoardMock);
        }

        private IGameBoard gameBoardMock;

        private IGameEngine systemUnderTest;

        [Test]
        public void Constructor_WhenInvoked_SetsNewGame()
        {
            AssertNewGame();
        }

        [Test]
        public void Constructor_WhenNullDependencyProvided_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                    NewGameEngine(null));
        }

        [Test]
        public void MakeMove_WhenInvoked_MakesMove()
        {
            systemUnderTest.MakeMove();

            gameBoardMock.Received().PlaceMarker();
        }

        [Test]
        public void NewGame_WhenInvoked_ClearsGameBoard()
        {
            systemUnderTest.NewGame();

            gameBoardMock.Received().Clear();
        }

        [Test]
        public void NewGame_WhenInvoked_SetsNewGame()
        {
            systemUnderTest.NewGame();

            AssertNewGame();
        }

        private void AssertNewGame()
        {
            Assert.That(systemUnderTest.GameState, Is.EqualTo(GameState.NewGameXMove));
        }

        private IGameEngine NewGameEngine(IGameBoard gameBoard)
        {
            return new GameEngine(gameBoard);
        }
    }
}