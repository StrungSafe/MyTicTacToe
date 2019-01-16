namespace TicTacToe.WindowsDesktop.Forms
{
    using System;
    using System.Threading.Tasks;
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

        private async void button1_Click(object sender, EventArgs e) => await MakeMoveAsync(0, 0);

        private async void button2_Click(object sender, EventArgs e) => await MakeMoveAsync(0, 1);

        private async void button3_Click(object sender, EventArgs e) => await MakeMoveAsync(0, 2);

        private async void button4_Click(object sender, EventArgs e) => await MakeMoveAsync(1, 0);

        private async void button5_Click(object sender, EventArgs e) => await MakeMoveAsync(1, 1);

        private async void button6_Click(object sender, EventArgs e) => await MakeMoveAsync(1, 2);

        private async void button7_Click(object sender, EventArgs e) => await MakeMoveAsync(2, 0);

        private async void button8_Click(object sender, EventArgs e) => await MakeMoveAsync(2, 1);

        private async void button9_Click(object sender, EventArgs e) => await MakeMoveAsync(2, 2);

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
                SetText(button, "");
            }
            else if (gameBoardMark == GameBoardMark.X)
            {
                SetText(button, "X");
                SetEnabled(button, false);
            }
            else if (gameBoardMark == GameBoardMark.O)
            {
                SetText(button, "O");
                SetEnabled(button, false);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private void EnableGameBoard(bool enabled)
        {
            SetEnabled(button1, enabled);
            SetEnabled(button2, enabled);
            SetEnabled(button3, enabled);
            SetEnabled(button4, enabled);
            SetEnabled(button5, enabled);
            SetEnabled(button6, enabled);
            SetEnabled(button7, enabled);
            SetEnabled(button8, enabled);
            SetEnabled(button9, enabled);
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

        private Task MakeMoveAsync(int row, int column)
        {
            var task = new Task(() => { MakeMove(row, column); });
            task.Start();
            return task;
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

        private void SetEnabled(Button button, bool enabled)
        {
            if (button.InvokeRequired)
            {
                button.Invoke(new MethodInvoker(() => SetEnabled(button, enabled)));
            }
            else
            {
                button.Enabled = enabled;
            }
        }

        private void SetText(Button button, string text)
        {
            if (button.InvokeRequired)
            {
                button.Invoke(new MethodInvoker(() => SetText(button, text)));
            }
            else
            {
                button.Text = text;
            }
        }

        ~MainForm()
        {
            WindsorContainer.Instance.Release(gameEngine);
        }
    }
}