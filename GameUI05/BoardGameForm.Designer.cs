using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLogic;

namespace GameUI05
{
    internal partial class BoardGameForm : Form
    {
        private System.ComponentModel.IContainer components = null;

        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelPlayer1 = new Label();
            this.labelPlayer2 = new Label();
            this.SuspendLayout();
            // 
            // Player1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Location = new Point(k_Margin, 20);
            this.labelPlayer1.Name = "Player1";
            this.labelPlayer1.Size = new Size(45, 13);
            this.labelPlayer1.TabIndex = 0;
            this.labelPlayer1.Font = new Font("Arial", 8F, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.labelPlayer1.Click += new System.EventHandler(this.label1_Click);

            this.labelPlayer1.Text = m_Player1Name + ": 0";
            this.Controls.Add(this.labelPlayer1);

            // 
            // Player2
            // 
            this.labelPlayer2.AutoSize = true;
            this.labelPlayer2.Location = new Point((k_Margin * m_Size) - (labelPlayer1.Left + labelPlayer1.Width + k_Margin), labelPlayer1.Location.Y);
            this.labelPlayer2.Name = "Player2";
            this.labelPlayer2.Size = new System.Drawing.Size(42, 13);
            this.labelPlayer2.TabIndex = 1;
            this.labelPlayer2.Font = new Font("Arial", 8F, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
            this.labelPlayer2.Text = m_Player2Name + ": 0";
            this.labelPlayer2.Click += new System.EventHandler(this.label2_Click);
            this.Controls.Add(this.labelPlayer2);
            // 
            // BoardGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Name = "BoardGameForm";
            this.Text = "Damka";
            this.Load += new System.EventHandler(this.BoardGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        internal void InitBoard()
        {
            for (int i = 0; i < this.m_Size; i++)
            {
                for (int j = 0; j < this.m_Size; j++)
                {

                    if (i % 2 == 1)
                    {
                        if (j % 2 == 0)
                        {
                            m_Squares[i, j] = new SquareButton(Square.eSquareType.None, i, j);
                            m_Squares[i, j].BackColor = Color.White;
                            int yLocation = i * 50 + 50;
                            int xLocation = j * 50 - 4;
                            m_Squares[i, j].Location = new Point(xLocation, yLocation);
                            m_Squares[i, j].Click += new System.EventHandler(button_Click);
                            Controls.Add(m_Squares[i, j]);

                        }
                        else
                        {
                            m_Squares[i, j] = new SquareButton(Square.eSquareType.None, i, j);
                            m_Squares[i, j].Enabled = false;
                            m_Squares[i, j].BackColor = Color.Gray;
                            int yLocation = i * 50 + 50;
                            int xLocation = j * 50 - 4;
                            m_Squares[i, j].Location = new Point(xLocation, yLocation);
                            Controls.Add(m_Squares[i, j]);
                        }
                    }
                    else
                    {
                        if (j % 2 == 1)
                        {
                            m_Squares[i, j] = new SquareButton(Square.eSquareType.None, i, j);
                            m_Squares[i, j].BackColor = Color.White;
                            int yLocation = i * 50 + 50;
                            int xLocation = j * 50 - 4;
                            m_Squares[i, j].Location = new Point(xLocation, yLocation);
                            m_Squares[i, j].Click += new System.EventHandler(button_Click);
                            Controls.Add(m_Squares[i, j]);
                        }
                        else
                        {
                            m_Squares[i, j] = new SquareButton(Square.eSquareType.None, i, j);
                            m_Squares[i, j].Enabled = false;
                            m_Squares[i, j].BackColor = Color.Gray;
                            int yLocation = i * 50 + 50;
                            int xLocation = j * 50 - 4;
                            m_Squares[i, j].Location = new Point(xLocation, yLocation);
                            Controls.Add(m_Squares[i, j]);
                        }
                    }
                }
            }

            for (int i = 0; i < this.m_Size / 2 - 1; i++)
            {
                for (int j = 0; j < this.m_Size; j++)
                {
                    if (i % 2 == 1)
                    {
                        if (j % 2 == 0)
                        {
                            m_Squares[i, j].Type = Square.eSquareType.O;
                            m_Squares[i, j].Text = "O";
                        }
                    }
                    else
                    {
                        if (j % 2 == 1)
                        {
                            m_Squares[i, j].Type = Square.eSquareType.O;
                            m_Squares[i, j].Text = "O";
                        }
                    }
                }
            }

            for (int i = this.m_Size - 1; i > this.m_Size / 2; i--)
            {
                for (int j = 0; j < this.m_Size; j++)
                {
                    if (i % 2 == 1)
                    {
                        if (j % 2 == 0)
                        {
                            m_Squares[i, j].Type = Square.eSquareType.X;
                            m_Squares[i, j].Text = "X";
                        }
                    }
                    else
                    {
                        if (j % 2 == 1)
                        {
                            m_Squares[i, j].Type = Square.eSquareType.X;
                            m_Squares[i, j].Text = "X";
                        }
                    }
                }
            }
        }
        private Label labelPlayer1;
        private Label labelPlayer2;
    }

    #endregion
}
