namespace GameLogic
{
     public class Square
    {
        public enum eSquareType
        {
            Invalid,
            None,
            O,
            U,
            X,
            K,
        }

        internal eSquareType m_Type;
        private int m_Row;
        private int m_Column;

        public Square(eSquareType i_Type, int i_Row, int i_Column)
        {
            this.m_Type = i_Type;
            this.m_Row = i_Row;
            this.m_Column = i_Column;
        }

        public Square(int i_Row, int i_Column)
        {
            this.m_Row = i_Row;
            this.m_Column = i_Column;
        }
        public eSquareType Type
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
        public static string ToStringSqureType(eSquareType i_Type)
        {
            string squareTypeString = string.Empty;
            switch (i_Type)
            {
                case eSquareType.None:
                    squareTypeString = "   ";
                    break;

                case eSquareType.K:
                    squareTypeString = " K ";
                    break;

                case eSquareType.O:
                    squareTypeString = " O ";
                    break;

                case eSquareType.X:
                    squareTypeString = " X ";
                    break;

                case eSquareType.U:
                    squareTypeString = " U ";
                    break;
            }

            return squareTypeString;
        }
    }
}
