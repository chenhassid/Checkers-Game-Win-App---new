using System;
using System.Drawing;
using System.Windows.Forms;
using GameLogic;

namespace GameUI05
{
  internal partial class BoardGameForm : Form
    {
        internal const int k_Margin = 50;
        private GameManager m_Game;
        private short m_Size;
        private SquareButton[,] m_Squares;
        private Move m_CurrentMove;
        private StartGameForm m_StartGameForm;
        private bool v_IsComputerGame;
        internal string m_Player1Name;
        internal string m_Player2Name;

        public BoardGameForm(StartGameForm i_StartGameForm)
        {
            m_StartGameForm = i_StartGameForm;
            m_Size = m_StartGameForm.BoardSize;
            m_Player1Name = m_StartGameForm.TextPlayer1;
            m_Player2Name = m_StartGameForm.TextPlayer2;
            m_CurrentMove = null;
            m_Squares = new SquareButton[this.m_Size, this.m_Size];
            v_IsComputerGame = !m_StartGameForm.CheckBoxPlayer2.Checked;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new Size(SizeBoard * k_Margin - 8, SizeBoard * k_Margin + k_Margin);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeComponent();
            InitBoard();

            if (v_IsComputerGame)
            {
                m_Game = new GameManager(m_StartGameForm.TextPlayer1, m_StartGameForm.BoardSize);
            }
            else
            {
                m_Game = new GameManager(m_StartGameForm.TextPlayer1, m_StartGameForm.TextPlayer2, m_StartGameForm.BoardSize);
            }

            registerEvents();
        }

        public StartGameForm GetStartGameForm
        {
            get
            {
                return m_StartGameForm;
            }
        }

        public Move CurrentMove
        {
            get { return m_CurrentMove; }
            set { m_CurrentMove = value; }
        }

        public SquareButton[,] Squares
        {
            get
            {
                return m_Squares;
            }

            set
            {
                m_Squares = value;
            }
        }

        public short SizeBoard
        {
            get
            {
                return m_Size;
            }

            set
            {
                m_Size = value;
            }
        }

        private void registerEvents()
        {
            m_Game.InvalidMove += new EventHandler(invalidMove);
            m_Game.MakeMove += new EventHandler(makeMove);
            m_Game.EndGameRound += new EventHandler(OnEndRoundGame);
        }

        public void button_Click(Object sender, EventArgs e)
        {
            SquareButton button = (SquareButton)sender;
            int row = button.Row;
            int col = button.Column;

            if (CurrentMove == null)
            {
                CurrentMove = new Move();
            }

            if (CurrentMove.FromSquare == null)
            {
                button.BackColor = Color.AliceBlue;
                CurrentMove.FromSquare = new Square(row, col);
            }
            else
            {
                if (CurrentMove.FromSquare.Row == row && CurrentMove.FromSquare.Column == col)
                {
                    button.BackColor = Color.White;
                    CurrentMove.FromSquare = null;
                }
                else
                {
                    CurrentMove.ToSquare = new Square(row, col);
                }
            }

            if ((CurrentMove.FromSquare != null) && (CurrentMove.ToSquare != null))
            {
                m_Game.GameRound(CurrentMove);
                Squares[CurrentMove.FromSquare.Row, CurrentMove.FromSquare.Column].BackColor = Color.White;
                CurrentMove.FromSquare = null;
                CurrentMove.ToSquare = null;
                CurrentMove = null;
            }
        }

        public void makeMove(object sender, EventArgs e)
        {
            Move currentMove = sender as Move;
            SquareButton toButton = Squares[currentMove.ToSquare.Row, currentMove.ToSquare.Column];
            SquareButton fromButton = Squares[currentMove.FromSquare.Row, currentMove.FromSquare.Column];
            Square fromSquare = currentMove.FromSquare;
            Square toSquare = currentMove.ToSquare;

            if (currentMove.MoveType == GameLogic.Move.eTypeOfMove.Jump)
            {
                int captureRow = fromButton.Row > toButton.Row ? fromButton.Row - 1 : fromButton.Row + 1;
                int captureColumn = fromButton.Column > toButton.Column ? fromButton.Column - 1 : fromButton.Column + 1;
                Squares[captureRow, captureColumn].Text = " ";
            }

            if (fromSquare.Type == Square.eSquareType.X && toSquare.Row == 0)
            {
                toButton.Text = "K";
            }
            else
            {
                if ((fromSquare.Type == Square.eSquareType.O) && toSquare.Row == m_Size - 1)
                {
                    toButton.Text = "U";
                }
                else
                {
                    toButton.Text = fromButton.Text;
                }
            }

            fromButton.Text = Square.ToStringSqureType(Square.eSquareType.None);
        }

        private void invalidMove(object sender, EventArgs e)
        {
            MessageBox.Show("Invalid Move!" + Environment.NewLine + "Please choose a valid move", "Damka", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void OnEndRoundGame(object sender, EventArgs e)
        {
            DialogResult isAnotherRound = DialogResult.None;

            if (m_Game.GameStatus == GameManager.eGameStatus.Draw)
            {
                string drawMsg = "Tie!" + Environment.NewLine + "Another Round?";
                isAnotherRound = MessageBox.Show(drawMsg, "Damka", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {
                string winMsg = (sender as Player).Name + " Won!" + Environment.NewLine + "Another Round?";
                isAnotherRound = MessageBox.Show(winMsg, "Damka", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            if (isAnotherRound == DialogResult.No)
            {
                this.Close();
                Application.Exit();
            }

            if (isAnotherRound == DialogResult.Yes)
            {
                playAnotherRound();
            }
        }

        private void playAnotherRound()
        {
            int player1Points = m_Game.Player1.Points;
            int player2Points = m_Game.Player2.Points;
            this.Controls.Clear();
            this.OnLoad(EventArgs.Empty);
            this.labelPlayer1.Text = m_Player1Name + ": " + player1Points;
            this.labelPlayer2.Text = m_Player2Name + ": " + player2Points;
        }

        private void BoardGame_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void button10_Click(object sender, EventArgs e)
        {
        }

        private void button12_Click(object sender, EventArgs e)
        {
        }

        private void button14_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void button16_Click(object sender, EventArgs e)
        {
        }

        private void button22_Click(object sender, EventArgs e)
        {
        }

        private void button28_Click(object sender, EventArgs e)
        {
        }

        private void button20_Click(object sender, EventArgs e)
        {
        }

        private void button26_Click(object sender, EventArgs e)
        {
        }

        private void button18_Click(object sender, EventArgs e)
        {
        }

        private void button24_Click(object sender, EventArgs e)
        {
        }

        private void button32_Click(object sender, EventArgs e)
        {
        }

        private void button40_Click(object sender, EventArgs e)
        {
        }

        private void button34_Click(object sender, EventArgs e)
        {
        }

        private void button42_Click(object sender, EventArgs e)
        {
        }

        private void button30_Click(object sender, EventArgs e)
        {
        }

        private void button36_Click(object sender, EventArgs e)
        {
        }

        private void button45_Click(object sender, EventArgs e)
        {
        }

        private void button53_Click(object sender, EventArgs e)
        {
        }

        private void button49_Click(object sender, EventArgs e)
        {
        }

        private void button38_Click(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
        }
    }
}
