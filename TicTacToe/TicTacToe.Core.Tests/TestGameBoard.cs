namespace TicTacToe.Core.Tests
{
    using Interfaces;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    public class TestGameBoard
    {
        [SetUp]
        public void SetUp()
        {
            gameBoardSettingsMock = Substitute.For<IGameBoardSettings>();
            gameBoardSettingsMock.Size.Returns(3);

            systemUnderTest = new GameBoard(gameBoardSettingsMock);
        }

        private IGameBoardSettings gameBoardSettingsMock;

        private IGameBoard systemUnderTest;

        [Test]
        public void BoardGetter_WhenInvoked_ReturnsCopyOfBoard()
        {
            systemUnderTest.Board[1, 1] = GameBoardMark.X;

            Assert.That(systemUnderTest.Board[1, 1], Is.EqualTo(GameBoardMark.Empty));
        }

        [Test]
        public void Clear_WhenInvoked_ClearsBoard()
        {
            systemUnderTest.PlaceMarker(new Move(Player.X, 1, 1));
            systemUnderTest.Clear();

            Assert.That(systemUnderTest.Board.GetLength(0), Is.EqualTo(3));
            Assert.That(systemUnderTest.Board.GetLength(1), Is.EqualTo(3));

            foreach (GameBoardMark boardMark in systemUnderTest.Board)
            {
                Assert.That(boardMark, Is.EqualTo(GameBoardMark.Empty));
            }
        }

        [Test]
        public void Constructor_WhenInvoked_CreatesEmptyBoard()
        {
            Assert.That(systemUnderTest.Board.GetLength(0), Is.EqualTo(3));
            Assert.That(systemUnderTest.Board.GetLength(1), Is.EqualTo(3));

            foreach (GameBoardMark boardMark in systemUnderTest.Board)
            {
                Assert.That(boardMark, Is.EqualTo(GameBoardMark.Empty));
            }
        }

        [Test]
        public void PlaceMarker_WhenInvoked_PlacesMarker()
        {
            var move = new Move(Player.X, 1, 1);

            systemUnderTest.PlaceMarker(move);

            Assert.That(systemUnderTest.Board[1, 1], Is.EqualTo(GameBoardMark.X));
        }
    }
}