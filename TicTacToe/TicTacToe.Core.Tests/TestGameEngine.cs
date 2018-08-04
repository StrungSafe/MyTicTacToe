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
            moveValidatorMock.IsValidMove().Returns(true);

            gameBoardAnalyzerMock = Substitute.For<IGameBoardAnalyzer>();
            gameBoardAnalyzerMock.AnalyzeGameBoard().Returns(GameBoardState.Open);

            systemUnderTest = NewGameEngine(gameBoardMock, moveValidatorMock, gameBoardAnalyzerMock);
        }

        private IGameBoardAnalyzer gameBoardAnalyzerMock;

        private IGameBoard gameBoardMock;

        private IMoveValidator moveValidatorMock;

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
                    NewGameEngine(null, moveValidatorMock, gameBoardAnalyzerMock));
            Assert.Throws<ArgumentNullException>(
                () =>
                    NewGameEngine(gameBoardMock, null, gameBoardAnalyzerMock));
            Assert.Throws<ArgumentNullException>(
                () =>
                    NewGameEngine(gameBoardMock, moveValidatorMock, null));
        }

        [Test]
        public void MakeMove_WhenGettingGameBoard_ReturnsGameBoard()
        {
            var expected = new GameBoardMark[0, 0];
            gameBoardMock.GameBoard.Returns(expected);

            Assert.That(systemUnderTest.GameBoard, Is.EqualTo(expected));
        }

        [Test]
        public void MakeMove_WhenInvalidMove_DoesNotChangePlayerMove()
        {
            moveValidatorMock.IsValidMove().Returns(false);

            systemUnderTest.MakeMove();

            Assert.That(systemUnderTest.GameState, Is.EqualTo(GameState.NewGameXMove));
        }

        [Test]
        public void MakeMove_WhenInvalidMove_DoesNotMakeMove()
        {
            moveValidatorMock.IsValidMove().Returns(false);

            systemUnderTest.MakeMove();

            gameBoardMock.DidNotReceive().PlaceMarker();
        }

        [Test]
        public void MakeMove_WhenInvalidMove_ReturnsMoveResult()
        {
            moveValidatorMock.IsValidMove().Returns(false);

            bool actual = systemUnderTest.MakeMove();

            Assert.That(actual, Is.False);
        }

        [Test]
        public void MakeMove_WhenInvoked_MakesMove()
        {
            systemUnderTest.MakeMove();

            Received.InOrder(() =>
            {
                moveValidatorMock.IsValidMove();
                gameBoardMock.PlaceMarker();
                gameBoardAnalyzerMock.AnalyzeGameBoard();
            });
        }

        [Test]
        public void MakeMove_WhenMoveMade_SetsOPlayerMove()
        {
            systemUnderTest.MakeMove();

            Assert.That(systemUnderTest.GameState, Is.EqualTo(GameState.OMove));
        }

        [Test]
        public void MakeMove_WhenMovesMade_SetsXPlayer()
        {
            systemUnderTest.MakeMove();
            systemUnderTest.MakeMove();

            Assert.That(systemUnderTest.GameState, Is.EqualTo(GameState.XMove));
        }

        [Test]
        public void MakeMove_WhenTieGameMove_SetsTie()
        {
            gameBoardAnalyzerMock.AnalyzeGameBoard().Returns(GameBoardState.Tie);

            systemUnderTest.MakeMove();

            Assert.That(systemUnderTest.GameState, Is.EqualTo(GameState.Tie));
        }

        [TestCase(GameBoardState.XWinner, GameState.XWinner)]
        [TestCase(GameBoardState.OWinner, GameState.OWinner)]
        public void MakeMove_WhenWinningGameMove_SetsWinner(GameBoardState gameBoardState, GameState expected)
        {
            gameBoardAnalyzerMock.AnalyzeGameBoard().Returns(gameBoardState);

            systemUnderTest.MakeMove();

            Assert.That(systemUnderTest.GameState, Is.EqualTo(expected));
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
            IGameBoardAnalyzer gameBoardAnalyzer)
        {
            return new GameEngine(gameBoard, moveValidator, gameBoardAnalyzer);
        }
    }
}