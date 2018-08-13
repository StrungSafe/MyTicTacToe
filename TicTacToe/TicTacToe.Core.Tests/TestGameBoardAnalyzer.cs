namespace TicTacToe.Core.Tests
{
    using Interfaces;
    using NUnit.Framework;

    [TestFixture]
    public class TestGameBoardAnalyzer
    {
        [SetUp]
        public void SetUp()
        {
            systemUnderTest = new GameBoardAnalyzer();
        }

        private IGameBoardAnalyzer systemUnderTest;

        [Test]
        public void AnalyzeGameBoard_WhenActiveGame_ReturnsActiveState()
        {
            GameBoardState actual = systemUnderTest.AnalyzeGameBoard(TestGameBoards.Active);

            Assert.That(actual, Is.EqualTo(GameBoardState.Active));
        }

        [Test]
        public void AnalyzeGameBoard_WhenOWinner_ReturnsOWinnerState()
        {
            GameBoardState actual = systemUnderTest.AnalyzeGameBoard(TestGameBoards.OWinner);

            Assert.That(actual, Is.EqualTo(GameBoardState.OWinner));
        }

        [Test]
        public void AnalyzeGameBoard_WhenTieGame_ReturnsTieState()
        {
            GameBoardState actual = systemUnderTest.AnalyzeGameBoard(TestGameBoards.TieGame);

            Assert.That(actual, Is.EqualTo(GameBoardState.Tie));
        }

        [Test]
        public void AnalyzeGameBoard_WhenXBackwardDiagonalWin_ReturnsXWinnerState()
        {
            GameBoardState actual = systemUnderTest.AnalyzeGameBoard(TestGameBoards.BackwardDiagonalWin);

            Assert.That(actual, Is.EqualTo(GameBoardState.XWinner));
        }

        [Test]
        public void AnalyzeGameBoard_WhenXForwardDiagonalWin_ReturnsXWinnerState()
        {
            GameBoardState actual = systemUnderTest.AnalyzeGameBoard(TestGameBoards.ForwardDiagonalWin);

            Assert.That(actual, Is.EqualTo(GameBoardState.XWinner));
        }

        [Test]
        public void AnalyzeGameBoard_WhenXHorizontalWin_ReturnsXWinnerState()
        {
            GameBoardState actual = systemUnderTest.AnalyzeGameBoard(TestGameBoards.HorizontalWin);

            Assert.That(actual, Is.EqualTo(GameBoardState.XWinner));
        }

        [Test]
        public void AnalyzeGameBoard_WhenXVerticalWin_ReturnsXWinnerState()
        {
            GameBoardState actual = systemUnderTest.AnalyzeGameBoard(TestGameBoards.VerticalWin);

            Assert.That(actual, Is.EqualTo(GameBoardState.XWinner));
        }

        [Test]
        public void AnalyzeGameBoard_WhenXWinner_ReturnsXWinnerState()
        {
            GameBoardState actual = systemUnderTest.AnalyzeGameBoard(TestGameBoards.XWinner);

            Assert.That(actual, Is.EqualTo(GameBoardState.XWinner));
        }

        private static class TestGameBoards
        {
            public static readonly GameBoardMark[,] Active =
            {
                {
                    GameBoardMark.Empty,
                    GameBoardMark.Empty,
                    GameBoardMark.Empty
                },
                {
                    GameBoardMark.Empty,
                    GameBoardMark.Empty,
                    GameBoardMark.Empty
                },
                {
                    GameBoardMark.Empty,
                    GameBoardMark.Empty,
                    GameBoardMark.Empty
                }
            };

            public static readonly GameBoardMark[,] BackwardDiagonalWin =
            {
                {
                    GameBoardMark.X,
                    GameBoardMark.O,
                    GameBoardMark.Empty
                },
                {
                    GameBoardMark.O,
                    GameBoardMark.X,
                    GameBoardMark.Empty
                },
                {
                    GameBoardMark.O,
                    GameBoardMark.Empty,
                    GameBoardMark.X
                }
            };

            public static readonly GameBoardMark[,] ForwardDiagonalWin =
            {
                {
                    GameBoardMark.O,
                    GameBoardMark.Empty,
                    GameBoardMark.X
                },
                {
                    GameBoardMark.O,
                    GameBoardMark.X,
                    GameBoardMark.Empty
                },
                {
                    GameBoardMark.X,
                    GameBoardMark.O,
                    GameBoardMark.Empty
                }
            };

            public static readonly GameBoardMark[,] HorizontalWin =
            {
                {
                    GameBoardMark.X,
                    GameBoardMark.X,
                    GameBoardMark.X
                },
                {
                    GameBoardMark.O,
                    GameBoardMark.O,
                    GameBoardMark.Empty
                },
                {
                    GameBoardMark.O,
                    GameBoardMark.Empty,
                    GameBoardMark.Empty
                }
            };

            public static readonly GameBoardMark[,] OWinner =
            {
                {
                    GameBoardMark.Empty,
                    GameBoardMark.X,
                    GameBoardMark.O
                },
                {
                    GameBoardMark.X,
                    GameBoardMark.O,
                    GameBoardMark.Empty
                },
                {
                    GameBoardMark.O,
                    GameBoardMark.Empty,
                    GameBoardMark.Empty
                }
            };

            public static readonly GameBoardMark[,] TieGame =
            {
                {
                    GameBoardMark.X,
                    GameBoardMark.O,
                    GameBoardMark.X
                },
                {
                    GameBoardMark.O,
                    GameBoardMark.O,
                    GameBoardMark.X
                },
                {
                    GameBoardMark.X,
                    GameBoardMark.X,
                    GameBoardMark.O
                }
            };

            public static readonly GameBoardMark[,] VerticalWin =
            {
                {
                    GameBoardMark.X,
                    GameBoardMark.O,
                    GameBoardMark.O
                },
                {
                    GameBoardMark.X,
                    GameBoardMark.Empty,
                    GameBoardMark.Empty
                },
                {
                    GameBoardMark.X,
                    GameBoardMark.Empty,
                    GameBoardMark.O
                }
            };

            public static readonly GameBoardMark[,] XWinner =
            {
                {
                    GameBoardMark.Empty,
                    GameBoardMark.O,
                    GameBoardMark.X
                },
                {
                    GameBoardMark.O,
                    GameBoardMark.X,
                    GameBoardMark.Empty
                },
                {
                    GameBoardMark.X,
                    GameBoardMark.Empty,
                    GameBoardMark.Empty
                }
            };
        }
    }
}