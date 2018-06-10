using System;
using System.Collections.Generic;

namespace GameLogic
{
    public class BoardGame
    {
        public Square[,] m_Board;
        public short m_Size;

        internal BoardGame(short size)
        {
            this.m_Size = size;
            m_Board = new Square[this.m_Size, this.m_Size];
            for (int i = 0; i < this.m_Size; i++)
            {
                for (int j = 0; j < this.m_Size; j++)
                {
                    m_Board[i, j] = new Square(Square.eSquareType.None, i, j);
                }
            }
        }

        internal short Size
        {
            get { return m_Size; }
        }

        internal short GetSize()
        {
            return this.m_Size;
        }

        internal Square GetSquare(int i_Row, int i_Column)
        {
            return this.m_Board[i_Row, i_Column];
        }

        internal void BuildBoard()
        {
            {
                for (int i = 0; i < (this.m_Size / 2 - 1); i++)
                {
                    for (int j = 0; j < this.m_Size; j++)
                    {
                        if (i % 2 == 1)
                        {
                            if (j % 2 == 0)
                            {
                                m_Board[i, j].Type = Square.eSquareType.O;
                            }
                        }
                        else
                        {
                            if (j % 2 == 1)
                            {
                                m_Board[i, j].Type = Square.eSquareType.O;
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
                                m_Board[i, j].Type = Square.eSquareType.X;
                            }
                        }
                        else
                        {
                            if (j % 2 == 1)
                            {
                                m_Board[i, j].Type = Square.eSquareType.X;
                            }
                        }
                    }
                }
            }
        }

        internal int GetPointsOfPlayer(Player.eShapeType i_Piece)
        {
            int countPlayerPoints = 0;
            switch (i_Piece)
            {
                case Player.eShapeType.X:

                    for (int i = 0; i < this.m_Size; i++)
                    {
                        for (int j = 0; j < this.m_Size; j++)
                        {
                            Square currentSquare = this.m_Board[i, j];
                            if (currentSquare.Type == Square.eSquareType.X)
                            {
                                countPlayerPoints += 1;
                            }

                            if (currentSquare.Type == Square.eSquareType.K)
                            {
                                countPlayerPoints += 4;
                            }
                        }
                    }

                    break;

                case Player.eShapeType.O:

                    for (int i = 0; i < this.m_Size; i++)
                    {
                        for (int j = 0; j < this.m_Size; j++)
                        {
                            Square currentSquare = this.m_Board[i, j];
                            if (currentSquare.Type == Square.eSquareType.O)
                            {
                                countPlayerPoints += 1;
                            }

                            if (currentSquare.Type == Square.eSquareType.U)
                            {
                                countPlayerPoints += 4;
                            }
                        }
                    }

                    break;
            }

            return countPlayerPoints;
        }

        private Square.eSquareType getTypeOfSquareInBoard(int i_Row, int i_Column)
        {
            Square.eSquareType typeToReturn;
            if (i_Row < 0 || i_Row > this.GetSize() - 1 || i_Column < 0 || i_Column > this.GetSize() - 1)
            {
                typeToReturn = Square.eSquareType.Invalid;
            }
            else
            {
                typeToReturn = this.m_Board[i_Row, i_Column].Type;
            }

            return typeToReturn;
        }

        internal List<Move> GetListOfPlayerDiagonalMoves(Player.eShapeType i_Shape)
        {
            List<Move> leggalMoves = new List<Move>();
            short boardSize = this.GetSize();

            for (int r = 0; r < boardSize; r++)
            {
                for (int c = 0; c < boardSize; c++)
                {
                    switch (i_Shape)
                    {
                        case Player.eShapeType.O:
                            // Regular piece of O
                            if (getTypeOfSquareInBoard(r, c) == Square.eSquareType.O)
                            {
                                if (getTypeOfSquareInBoard(r + 1, c - 1) == Square.eSquareType.None)
                                {
                                    leggalMoves.Add(new Move(GetSquare(r, c), GetSquare(r + 1, c - 1)));
                                }

                                if (getTypeOfSquareInBoard(r + 1, c + 1) == Square.eSquareType.None)
                                {
                                    leggalMoves.Add(new Move(GetSquare(r, c), GetSquare(r + 1, c + 1)));
                                }
                            }

                            // King of O
                            if (getTypeOfSquareInBoard(r, c) == Square.eSquareType.U)
                            {
                                if (getTypeOfSquareInBoard(r + 1, c - 1) == Square.eSquareType.None)
                                {
                                    leggalMoves.Add(new Move(GetSquare(r, c), GetSquare(r + 1, c - 1)));
                                }

                                if (getTypeOfSquareInBoard(r + 1, c + 1) == Square.eSquareType.None)
                                {
                                    leggalMoves.Add(new Move(GetSquare(r, c), GetSquare(r + 1, c + 1)));
                                }

                                if (getTypeOfSquareInBoard(r - 1, c - 1) == Square.eSquareType.None)
                                {
                                    leggalMoves.Add(new Move(GetSquare(r, c), GetSquare(r - 1, c - 1)));
                                }

                                if (getTypeOfSquareInBoard(r - 1, c + 1) == Square.eSquareType.None)
                                {
                                    leggalMoves.Add(new Move(GetSquare(r, c), GetSquare(r - 1, c + 1)));
                                }
                            }

                            break;

                        // regular piece for X
                        case Player.eShapeType.X:
                            if (getTypeOfSquareInBoard(r, c) == Square.eSquareType.X)
                            {
                                if (getTypeOfSquareInBoard(r - 1, c - 1) == Square.eSquareType.None)
                                {
                                    leggalMoves.Add(new Move(GetSquare(r, c), GetSquare(r - 1, c - 1)));
                                }

                                if (getTypeOfSquareInBoard(r - 1, c + 1) == Square.eSquareType.None)
                                {
                                    leggalMoves.Add(new Move(GetSquare(r, c), GetSquare(r - 1, c + 1)));
                                }
                            }

                            // King of X
                            if (getTypeOfSquareInBoard(r, c) == Square.eSquareType.K)
                            {
                                if (getTypeOfSquareInBoard(r + 1, c - 1) == Square.eSquareType.None)
                                {
                                    leggalMoves.Add(new Move(GetSquare(r, c), GetSquare(r + 1, c - 1)));
                                }

                                if (getTypeOfSquareInBoard(r + 1, c + 1) == Square.eSquareType.None)
                                {
                                    leggalMoves.Add(new Move(GetSquare(r, c), GetSquare(r + 1, c + 1)));
                                }

                                if (getTypeOfSquareInBoard(r - 1, c - 1) == Square.eSquareType.None)
                                {
                                    leggalMoves.Add(new Move(GetSquare(r, c), GetSquare(r - 1, c - 1)));
                                }

                                if (getTypeOfSquareInBoard(r - 1, c + 1) == Square.eSquareType.None)
                                {
                                    leggalMoves.Add(new Move(GetSquare(r, c), GetSquare(r - 1, c + 1)));
                                }
                            }

                            break;
                    }
                }
            }

            return leggalMoves;
        }

        public List<Move> GetListOfPlayerJumps(Player.eShapeType i_Shape)
        {
            List<Move> leggalJumps = new List<Move>();
            short boardSize = this.GetSize();

            for (int r = 0; r < boardSize; r++)
            {
                for (int c = 0; c < boardSize; c++)
                {
                    switch (i_Shape)
                    {
                        case Player.eShapeType.O:

                            // regular piece of O
                            if (getTypeOfSquareInBoard(r, c) == Square.eSquareType.O)
                            {
                                if ((getTypeOfSquareInBoard(r + 2, c - 2) == Square.eSquareType.None) && (getTypeOfSquareInBoard(r + 1, c - 1) == Square.eSquareType.X || getTypeOfSquareInBoard(r + 1, c - 1) == Square.eSquareType.K))
                                {
                                    leggalJumps.Add(new Move(GetSquare(r, c), GetSquare(r + 2, c - 2)));
                                }

                                if ((getTypeOfSquareInBoard(r + 2, c + 2) == Square.eSquareType.None) && (getTypeOfSquareInBoard(r + 1, c + 1) == Square.eSquareType.X || getTypeOfSquareInBoard(r + 1, c + 1) == Square.eSquareType.K))
                                {
                                    leggalJumps.Add(new Move(GetSquare(r, c), GetSquare(r + 2, c + 2)));
                                }
                            }

                            // King of O
                            if (getTypeOfSquareInBoard(r, c) == Square.eSquareType.U)
                            {
                                if ((getTypeOfSquareInBoard(r + 2, c - 2) == Square.eSquareType.None) && (getTypeOfSquareInBoard(r + 1, c - 1) == Square.eSquareType.X || getTypeOfSquareInBoard(r + 1, c - 1) == Square.eSquareType.K))
                                {
                                    leggalJumps.Add(new Move(GetSquare(r, c), GetSquare(r + 2, c - 2)));
                                }

                                if ((getTypeOfSquareInBoard(r + 2, c + 2) == Square.eSquareType.None) && (getTypeOfSquareInBoard(r + 1, c + 1) == Square.eSquareType.X || getTypeOfSquareInBoard(r + 1, c + 1) == Square.eSquareType.K))
                                {
                                    leggalJumps.Add(new Move(GetSquare(r, c), GetSquare(r + 2, c + 2)));
                                }

                                if ((getTypeOfSquareInBoard(r - 2, c - 2) == Square.eSquareType.None) && (getTypeOfSquareInBoard(r - 1, c - 1) == Square.eSquareType.X || getTypeOfSquareInBoard(r - 1, c - 1) == Square.eSquareType.K))
                                {
                                    leggalJumps.Add(new Move(GetSquare(r, c), GetSquare(r - 2, c - 2)));
                                }

                                if ((getTypeOfSquareInBoard(r - 2, c + 2) == Square.eSquareType.None) && (getTypeOfSquareInBoard(r - 1, c + 1) == Square.eSquareType.X || getTypeOfSquareInBoard(r - 1, c + 1) == Square.eSquareType.K))
                                {
                                    leggalJumps.Add(new Move(GetSquare(r, c), GetSquare(r - 2, c + 2)));
                                }
                            }

                            break;

                        case Player.eShapeType.X:

                            // regular piece of X
                            if (getTypeOfSquareInBoard(r, c) == Square.eSquareType.X)
                            {
                                if ((getTypeOfSquareInBoard(r - 2, c - 2) == Square.eSquareType.None) && (getTypeOfSquareInBoard(r - 1, c - 1) == Square.eSquareType.O || getTypeOfSquareInBoard(r - 1, c - 1) == Square.eSquareType.U))
                                {
                                    leggalJumps.Add(new Move(GetSquare(r, c), GetSquare(r - 2, c - 2)));
                                }

                                if ((getTypeOfSquareInBoard(r - 2, c + 2) == Square.eSquareType.None) && (getTypeOfSquareInBoard(r - 1, c + 1) == Square.eSquareType.O || getTypeOfSquareInBoard(r - 1, c + 1) == Square.eSquareType.U))
                                {
                                    leggalJumps.Add(new Move(GetSquare(r, c), GetSquare(r - 2, c + 2)));
                                }
                            }

                            // king of X
                            if (getTypeOfSquareInBoard(r, c) == Square.eSquareType.K)
                            {
                                if ((getTypeOfSquareInBoard(r + 2, c - 2) == Square.eSquareType.None) && (getTypeOfSquareInBoard(r + 1, c - 1) == Square.eSquareType.O || getTypeOfSquareInBoard(r + 1, c - 1) == Square.eSquareType.U))
                                {
                                    leggalJumps.Add(new Move(GetSquare(r, c), GetSquare(r + 2, c - 2)));
                                }

                                if ((getTypeOfSquareInBoard(r + 2, c + 2) == Square.eSquareType.None) && (getTypeOfSquareInBoard(r + 1, c + 1) == Square.eSquareType.O || getTypeOfSquareInBoard(r + 1, c + 1) == Square.eSquareType.U))
                                {
                                    leggalJumps.Add(new Move(GetSquare(r, c), GetSquare(r + 2, c + 2)));
                                }

                                if ((getTypeOfSquareInBoard(r - 2, c - 2) == Square.eSquareType.None) && (getTypeOfSquareInBoard(r - 1, c - 1) == Square.eSquareType.O || getTypeOfSquareInBoard(r - 1, c - 1) == Square.eSquareType.U))
                                {
                                    leggalJumps.Add(new Move(GetSquare(r, c), GetSquare(r - 2, c - 2)));
                                }

                                if ((getTypeOfSquareInBoard(r - 2, c + 2) == Square.eSquareType.None) && (getTypeOfSquareInBoard(r - 1, c + 1) == Square.eSquareType.O || getTypeOfSquareInBoard(r - 1, c + 1) == Square.eSquareType.U))
                                {
                                    leggalJumps.Add(new Move(GetSquare(r, c), GetSquare(r - 2, c + 2)));
                                }
                            }

                            break;
                    }
                }
            }

            return leggalJumps;
        }

        /*
        public void PrintBoard()
        {
            StringBuilder stringBuilderBoard = new StringBuilder();
            stringBuilderBoard.Append(" ");

            for (int k = 0; k < this.m_Size; k++)
            {
                stringBuilderBoard.Append("  " + (char)(k + 65) + " ");
            }

            stringBuilderBoard.Append(System.Environment.NewLine);

            for (int i = 0; i < this.m_Size; i++)
            {
                stringBuilderBoard.Append(" ");
                for (int k = 0; k < (this.m_Size * 4 + 1); k++)
                {
                    stringBuilderBoard.Append("=");
                }

                stringBuilderBoard.Append(System.Environment.NewLine);
                stringBuilderBoard.Append((char)(i + 97));

                for (int j = 0; j < this.m_Size; j++)
                {
                    stringBuilderBoard.Append("|" + Square.ToStringSqureType(m_Board[i, j].Type));
                }

                stringBuilderBoard.Append("|");
                stringBuilderBoard.Append(System.Environment.NewLine);
            }

            stringBuilderBoard.Append(" ");
            for (int k = 0; k < (this.m_Size * 4 + 1); k++)
            {
                stringBuilderBoard.Append("=");
            }

            System.Console.WriteLine(stringBuilderBoard.ToString());
        }
        */
    }
}
