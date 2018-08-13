namespace TicTacToe.WindowsDesktop.Forms
{
    using System;
    using System.Windows.Forms;
    using CastleWindsor;
    using Core.Interfaces;

    public partial class MainForm : Form
    {
        private readonly IGameEngine gameEngine;

        public MainForm()
        {
            InitializeComponent();

            gameEngine = WindsorContainer.Instance.Resolve<IGameEngine>();

            NewGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MakeMove(0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MakeMove(0, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MakeMove(0, 2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MakeMove(1, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MakeMove(1, 1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MakeMove(1, 2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MakeMove(2, 0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MakeMove(2, 1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MakeMove(2, 2);
        }

        private void CheckForEndOfGame()
        {
            if (gameEngine.GameState.HasFlag(GameState.GameOver))
            {
                EnableGameBoard(false);
            }
        }

        private void DrawGameBoard()
        {
            DrawGameBoardMark(button1, 0, 0);
            DrawGameBoardMark(button2, 0, 1);
            DrawGameBoardMark(button3, 0, 2);
            DrawGameBoardMark(button4, 1, 0);
            DrawGameBoardMark(button5, 1, 1);
            DrawGameBoardMark(button6, 1, 2);
            DrawGameBoardMark(button7, 2, 0);
            DrawGameBoardMark(button8, 2, 1);
            DrawGameBoardMark(button9, 2, 2);
        }

        private void DrawGameBoardMark(Button button, int row, int column)
        {
            GameBoardMark gameBoardMark = gameEngine.GameBoard[row, column];

            if (gameBoardMark == GameBoardMark.Empty)
            {
                button.Text = "";
            }
            else if (gameBoardMark == GameBoardMark.X)
            {
                button.Text = "X";
                button.Enabled = false;
            }
            else if (gameBoardMark == GameBoardMark.O)
            {
                button.Text = "O";
                button.Enabled = false;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private void EnableGameBoard(bool enabled)
        {
            button1.Enabled = enabled;
            button2.Enabled = enabled;
            button3.Enabled = enabled;
            button4.Enabled = enabled;
            button5.Enabled = enabled;
            button6.Enabled = enabled;
            button7.Enabled = enabled;
            button8.Enabled = enabled;
            button9.Enabled = enabled;
        }

        private Player GetCurrentPlayer()
        {
            if (gameEngine.GameState.HasFlag(GameState.XMove))
            {
                return Player.X;
            }

            if (gameEngine.GameState == GameState.OMove)
            {
                return Player.O;
            }

            throw new ArgumentOutOfRangeException();
        }

        private void MakeMove(int row, int column)
        {
            Player player = GetCurrentPlayer();

            bool moveMade = gameEngine.MakeMove(new Move(player, row, column));

            if (moveMade)
            {
                DrawGameBoard();
                CheckForEndOfGame();
            }
        }

        private void NewGame()
        {
            gameEngine.NewGame();

            DrawGameBoard();
            EnableGameBoard(true);
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        ~MainForm()
        {
            WindsorContainer.Instance.Release(gameEngine);
        }
    }
}