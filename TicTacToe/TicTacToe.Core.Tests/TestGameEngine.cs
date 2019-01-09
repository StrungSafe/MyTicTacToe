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
            board = new GameBoardMark[0, 0];

            gameBoardMock = Substitute.For<IGameBoard>();
            gameBoardMock.Board.Returns(board);

            moveValidatorMock = Substitute.For<IMoveValidator>();
            SetUpIsValidMove(true);

            gameBoardAnalyzerMock = Substitute.For<IGameBoardAnalyzer>();
            gameBoardAnalyzerMock.AnalyzeGameBoard(board).Returns(GameBoardState.Active);

            systemUnderTest = NewGameEngine(gameBoardMock, moveValidatorMock, gameBoardAnalyzerMock);

            move = new Move(Player.X, 0, 0);
        }

        private GameBoardMark[,] board;

        private IGameBoardAnalyzer gameBoardAnalyzerMock;

        private IGameBoard gameBoardMock;

        private Move move;

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
        public void GameBoardGetter_WhenGettingGameBoard_ReturnsBoard()
        {
            Assert.That(systemUnderTest.GameBoard, Is.EqualTo(board));
        }

        [Test]
        public void MakeMove_WhenInvalidMove_DoesNotChangePlayerMove()
        {
            SetUpIsValidMove(false);

            InvokeMakeMove();

            Assert.That(systemUnderTest.GameState, Is.EqualTo(GameState.NewGameXMove));
        }

        [Test]
        public void MakeMove_WhenInvalidMove_DoesNotMakeMove()
        {
            SetUpIsValidMove(false);

            InvokeMakeMove();

            gameBoardMock.DidNotReceiveWithAnyArgs().PlaceMarker(move);
        }

        [Test]
        public void MakeMove_WhenInvalidMove_ReturnsMoveResult()
        {
            SetUpIsValidMove(false);

            bool actual = InvokeMakeMove();

            Assert.That(actual, Is.False);
        }

        [Test]
        public void MakeMove_WhenInvoked_MakesMove()
        {
            InvokeMakeMove();

            Received.InOrder(() =>
            {
                moveValidatorMock.IsValidMove(move, Arg.Any<GameState>(), board);
                gameBoardMock.PlaceMarker(move);
                gameBoardAnalyzerMock.AnalyzeGameBoard(board);
            });
        }

        [Test]
        public void MakeMove_WhenMoveMade_SetsOPlayerMove()
        {
            InvokeMakeMove();

            Assert.That(systemUnderTest.GameState, Is.EqualTo(GameState.OMove));
        }

        [Test]
        public void MakeMove_WhenMovesMade_SetsXPlayer()
        {
            InvokeMakeMove();
            InvokeMakeMove();

            Assert.That(systemUnderTest.GameState, Is.EqualTo(GameState.XMove));
        }

        [Test]
        public void MakeMove_WhenTieGameMove_SetsTie()
        {
            gameBoardAnalyzerMock.AnalyzeGameBoard(board).Returns(GameBoardState.Tie);

            InvokeMakeMove();

            Assert.That(systemUnderTest.GameState, Is.EqualTo(GameState.Tie));
        }

        [TestCase(GameBoardState.XWinner, GameState.XWinner)]
        [TestCase(GameBoardState.OWinner, GameState.OWinner)]
        public void MakeMove_WhenWinningGameMove_SetsWinner(GameBoardState gameBoardState, GameState expected)
        {
            gameBoardAnalyzerMock.AnalyzeGameBoard(board).Returns(gameBoardState);

            InvokeMakeMove();

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

        private bool InvokeMakeMove()
        {
            return systemUnderTest.MakeMove(move);
        }

        private IGameEngine NewGameEngine(IGameBoard gameBoard, IMoveValidator moveValidator,
            IGameBoardAnalyzer gameBoardAnalyzer)
        {
            return new GameEngine(gameBoard, moveValidator, gameBoardAnalyzer);
        }

        private void SetUpIsValidMove(bool isValidMoveReturn)
        {
            moveValidatorMock.IsValidMove(move, Arg.Any<GameState>(), board).ReturnsForAnyArgs(isValidMoveReturn);
        }
    }
}