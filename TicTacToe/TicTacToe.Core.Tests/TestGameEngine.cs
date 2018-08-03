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

            moveValidatorMock = Substitute.For<IMoveValidator>();

            winnerAnalyzerMock = Substitute.For<IWinnerAnalyzer>();

            systemUnderTest = NewGameEngine(gameBoardMock, moveValidatorMock, winnerAnalyzerMock);
        }

        private IGameBoard gameBoardMock;

        private IMoveValidator moveValidatorMock;

        private IGameEngine systemUnderTest;

        private IWinnerAnalyzer winnerAnalyzerMock;

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
                    NewGameEngine(null, moveValidatorMock, winnerAnalyzerMock));
            Assert.Throws<ArgumentNullException>(
                () =>
                    NewGameEngine(gameBoardMock, null, winnerAnalyzerMock));
            Assert.Throws<ArgumentNullException>(
                () =>
                    NewGameEngine(gameBoardMock, moveValidatorMock, null));
        }

        [Test]
        public void MakeMove_WhenInvoked_MakesMove()
        {
            systemUnderTest.MakeMove();

            Received.InOrder(() =>
            {
                moveValidatorMock.ValidateMove();
                gameBoardMock.PlaceMarker();
                winnerAnalyzerMock.AnalyzeGameBoard();
            });
        }

        [Test]
        public void NewGame_WhenInvoked_SetsNewGame()
        {
            systemUnderTest.NewGame();

            AssertNewGame();
        }

        private void AssertNewGame()
        {
            gameBoardMock.Received().Clear();

            Assert.That(systemUnderTest.GameState, Is.EqualTo(GameState.NewGameXMove));
        }

        private IGameEngine NewGameEngine(IGameBoard gameBoard, IMoveValidator moveValidator,
            IWinnerAnalyzer winnerAnalyzer)
        {
            return new GameEngine(gameBoard, moveValidator, winnerAnalyzer);
        }
    }
}