using System.Drawing;
using System.Windows.Forms;
using GameLogic;

namespace GameUI05
{
    public class SquareButton : Button
    {
        internal const int k_SquareSize = 50;
        internal Square.eSquareType m_Type;
        internal int m_Row;
        internal int m_Column;

        public Square.eSquareType Type
        {
            get
            {
                return m_Type;
            }

            set
            {
                m_Type = value;
            }
        }

        public int Row
        {
            get { return m_Row; }
        }

        public int Column
        {
            get { return m_Column; }
        }

        public SquareButton(Square.eSquareType i_SquareType, int i_Row, int i_Column)
        {
            this.ClientSize = new Size(k_SquareSize, k_SquareSize);
            m_Type = i_SquareType;
            m_Row = i_Row;
            m_Column = i_Column;

            switch (i_SquareType)
            {
                case Square.eSquareType.K:
                    this.Text = "K";
                    break;
                case Square.eSquareType.U:
                    this.Text = "U";
                    break;
                case Square.eSquareType.O:
                    this.Text = "O";
                    break;
                case Square.eSquareType.X:
                    this.Text = "X";
                    break;
                case Square.eSquareType.None:
                    this.Text = " ";
                    break;
            }
        }
    }
}
