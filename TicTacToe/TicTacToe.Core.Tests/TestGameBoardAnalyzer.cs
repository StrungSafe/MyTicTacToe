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

        private static readonly GameBoardMark[,] Active =
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

        private static readonly GameBoardMark[,] DiagonalWin =
        {
            {
                GameBoardMark.X,
                GameBoardMark.Empty,
                GameBoardMark.Empty
            },
            {
                GameBoardMark.Empty,
                GameBoardMark.X,
                GameBoardMark.Empty
            },
            {
                GameBoardMark.Empty,
                GameBoardMark.Empty,
                GameBoardMark.X
            }
        };

        private static readonly GameBoardMark[,] HorizontalWin =
        {
            {
                GameBoardMark.X,
                GameBoardMark.X,
                GameBoardMark.X
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

        private static readonly GameBoardMark[,] OWinner =
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

        private static readonly GameBoardMark[,] TieGame =
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

        private static readonly GameBoardMark[,] VerticalWin =
        {
            {
                GameBoardMark.X,
                GameBoardMark.Empty,
                GameBoardMark.Empty
            },
            {
                GameBoardMark.X,
                GameBoardMark.Empty,
                GameBoardMark.Empty
            },
            {
                GameBoardMark.X,
                GameBoardMark.Empty,
                GameBoardMark.Empty
            }
        };

        private static readonly GameBoardMark[,] XWinner =
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

        private IGameBoardAnalyzer systemUnderTest;

        [TestCaseSource(nameof(Active))]
        public void AnalyzeGameBoard_WhenActiveGame_ReturnsActiveState(GameBoardMark[,] gameBoard)
        {
            GameBoardState actual = systemUnderTest.AnalyzeGameBoard(gameBoard);

            Assert.That(actual, Is.EqualTo(GameBoardState.Active));
        }

        [TestCaseSource(nameof(DiagonalWin))]
        public void AnalyzeGameBoard_WhenDiagonalWin_ReturnsXWinnerState(GameBoardMark[,] gameBoard)
        {
            GameBoardState actual = systemUnderTest.AnalyzeGameBoard(gameBoard);

            Assert.That(actual, Is.EqualTo(GameBoardState.XWinner));
        }

        [TestCaseSource(nameof(HorizontalWin))]
        public void AnalyzeGameBoard_WhenHorizontalWin_ReturnsXWinnerState(GameBoardMark[,] gameBoard)
        {
            GameBoardState actual = systemUnderTest.AnalyzeGameBoard(gameBoard);

            Assert.That(actual, Is.EqualTo(GameBoardState.XWinner));
        }

        [TestCaseSource(nameof(OWinner))]
        public void AnalyzeGameBoard_WhenOWinner_ReturnsOWinnerState(GameBoardMark[,] gameBoard)
        {
            GameBoardState actual = systemUnderTest.AnalyzeGameBoard(gameBoard);

            Assert.That(actual, Is.EqualTo(GameBoardState.OWinner));
        }

        [TestCaseSource(nameof(TieGame))]
        public void AnalyzeGameBoard_WhenTieGame_ReturnsTieState(GameBoardMark[,] gameBoard)
        {
            GameBoardState actual = systemUnderTest.AnalyzeGameBoard(gameBoard);

            Assert.That(actual, Is.EqualTo(GameBoardState.Tie));
        }

        [TestCaseSource(nameof(VerticalWin))]
        public void AnalyzeGameBoard_WhenVerticalWin_ReturnsXWinnerState(GameBoardMark[,] gameBoard)
        {
            GameBoardState actual = systemUnderTest.AnalyzeGameBoard(gameBoard);

            Assert.That(actual, Is.EqualTo(GameBoardState.XWinner));
        }

        [TestCaseSource(nameof(XWinner))]
        public void AnalyzeGameBoard_WhenXWinner_ReturnsXWinnerState(GameBoardMark[,] gameBoard)
        {
            GameBoardState actual = systemUnderTest.AnalyzeGameBoard(gameBoard);

            Assert.That(actual, Is.EqualTo(GameBoardState.XWinner));
        }
    }
}