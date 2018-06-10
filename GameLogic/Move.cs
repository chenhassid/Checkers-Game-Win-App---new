namespace GameLogic
{
    public class Move
    {
        public enum eTypeOfMove
        {
            Jump,
            Regular,
        }

        private Square m_FromSquare;
        private Square m_ToSquare;
        private eTypeOfMove m_TypeOfMove;

        public Move()
        {
            m_FromSquare = null;
            m_ToSquare = null;
        }

        public Move(Square m_FromPiece, Square m_ToPiece)
        {
            this.m_FromSquare = m_FromPiece;
            this.m_ToSquare = m_ToPiece;
            this.m_TypeOfMove = eTypeOfMove.Regular;
        }

        public eTypeOfMove MoveType
        {
            get
            {
                return m_TypeOfMove;
            }

            set
            {
                m_TypeOfMove = value;
            }
        }

        public Square ToSquare
        {
            get
            {
                return this.m_ToSquare;
            }

            set
            {
                m_ToSquare = value;
            }
        }

        public Square FromSquare
        {
            get
            {
                return this.m_FromSquare;
            }

            set
            {
                m_FromSquare = value;
            }
        }

        public bool IsEqualsTo(Move i_MovetoCompare)
        {
            bool isEqual = true;
            if (this.FromSquare.Row != i_MovetoCompare.FromSquare.Row || this.ToSquare.Row != i_MovetoCompare.ToSquare.Row)
            {
                isEqual = false;
            }

            if (this.FromSquare.Column != i_MovetoCompare.FromSquare.Column || this.ToSquare.Column != i_MovetoCompare.ToSquare.Column)
            {
                isEqual = false;
            }

            return isEqual;
        }

        public bool CheckIsValidMove(Player.eShapeType i_ShapeOfPlayer)
        {
            bool isValidMove = true;

            switch (i_ShapeOfPlayer)
            {
                case Player.eShapeType.X:
                    if (m_FromSquare.Type != Square.eSquareType.X && m_FromSquare.Type != Square.eSquareType.K)
                    {
                        isValidMove = false;
                    }
                    else
                    {
                        if (m_ToSquare.Type != Square.eSquareType.None)
                        {
                            isValidMove = false;
                        }
                        else
                        {
                            if (m_FromSquare.Type == Square.eSquareType.X)
                            {
                                isValidMove = isValidDiagonalMove(Player.eShapeType.X);
                            }
                            else
                            {
                                isValidMove = isValidDiagonalKingMove(Player.eShapeType.X);
                            }
                        }
                    }

                    break;

                case Player.eShapeType.O:

                    if (m_FromSquare.Type != Square.eSquareType.O && m_FromSquare.Type != Square.eSquareType.U)
                    {
                        isValidMove = false;
                    }
                    else
                    {
                        if (m_ToSquare.Type != Square.eSquareType.None)
                        {
                            isValidMove = false;
                        }
                        else
                        {
                            if (m_FromSquare.Type == Square.eSquareType.O)
                            {
                                isValidMove = isValidDiagonalMove(Player.eShapeType.O);
                            }
                            else
                            {
                                isValidMove = isValidDiagonalKingMove(Player.eShapeType.O);
                            }
                        }
                    }

                    break;
            }

            return isValidMove;
        }

        public bool isValidDiagonalMove(Player.eShapeType i_Shape)
        {
            bool isValidMove = false;

            switch (i_Shape)
            {
                case Player.eShapeType.X:
                    if ((m_FromSquare.Row - 1 == m_ToSquare.Row) && (m_FromSquare.Column - 1 == m_ToSquare.Column))
                    {
                        isValidMove = true;
                    }

                    if ((m_FromSquare.Row - 1 == m_ToSquare.Row) && (m_FromSquare.Column + 1 == m_ToSquare.Column))
                    {
                        isValidMove = true;
                    }

                    break;

                case Player.eShapeType.O:
                    if ((m_FromSquare.Row + 1 == m_ToSquare.Row) && (m_FromSquare.Column - 1 == m_ToSquare.Column))
                    {
                        isValidMove = true;
                    }

                    if ((m_FromSquare.Row + 1 == m_ToSquare.Row) && (m_FromSquare.Column + 1 == m_ToSquare.Column))
                    {
                        isValidMove = true;
                    }

                    break;
            }

            return isValidMove;
        }

        public bool isValidDiagonalKingMove(Player.eShapeType i_ShapeOfMove)
        {
            bool isValidKingMove = false;

            if ((m_FromSquare.Row - 1 == m_ToSquare.Row) && (m_FromSquare.Column - 1 == m_ToSquare.Column))
            {
                isValidKingMove = true;
            }

            if ((m_FromSquare.Row - 1 == m_ToSquare.Row) && (m_FromSquare.Column + 1 == m_ToSquare.Column))
            {
                isValidKingMove = true;
            }

            if ((m_FromSquare.Row + 1 == m_ToSquare.Row) && (m_FromSquare.Column - 1 == m_ToSquare.Column))
            {
                isValidKingMove = true;
            }

            if ((m_FromSquare.Row + 1 == m_ToSquare.Row) && (m_FromSquare.Column + 1 == m_ToSquare.Column))
            {
                isValidKingMove = true;
            }

            return isValidKingMove;
        }

        internal void MoveOnBoard(BoardGame i_BoardGame)
        {
            Square fromSquare = i_BoardGame.GetSquare(this.FromSquare.Row, this.FromSquare.Column);
            Square toSquare = i_BoardGame.GetSquare(this.ToSquare.Row, this.ToSquare.Column);

            switch (this.MoveType)
            {
                case eTypeOfMove.Regular:

                    if (fromSquare.Type == Square.eSquareType.X && toSquare.Row == 0)
                    {
                        toSquare.Type = Square.eSquareType.K;
                    }
                    else
                        if (fromSquare.Type == Square.eSquareType.O && toSquare.Row == i_BoardGame.GetSize() - 1)
                    {
                        toSquare.Type = Square.eSquareType.U;
                    }
                    else
                    {
                        toSquare.Type = fromSquare.Type;
                    }

                    fromSquare.Type = Square.eSquareType.None;

                    break;

                case eTypeOfMove.Jump:
                    capturePieceOnBoard(i_BoardGame);

                    if (fromSquare.Type == Square.eSquareType.X && toSquare.Row == 0)
                    {
                        toSquare.Type = Square.eSquareType.K;
                    }
                    else
                    {
                        if (fromSquare.Type == Square.eSquareType.O && toSquare.Row == i_BoardGame.GetSize() - 1)
                        {
                            toSquare.Type = Square.eSquareType.U;
                        }
                        else
                        {
                            toSquare.Type = fromSquare.Type;
                        }
                    }

                    fromSquare.Type = Square.eSquareType.None;
                    break;
            }

         //   i_BoardGame.PrintBoard();
        }

        public void capturePieceOnBoard(BoardGame i_BoardGame)
        {
            int rowOfCapturPiece = 0;
            int columnOfCapturPiece = 0;

            if (m_FromSquare.Row > m_ToSquare.Row)
            {
                rowOfCapturPiece = m_FromSquare.Row - 1;

                if (m_FromSquare.Column > m_ToSquare.Column)
                {
                    columnOfCapturPiece = m_FromSquare.Column - 1;
                }
                else
                {
                    columnOfCapturPiece = m_FromSquare.Column + 1;
                }
            }
            else
            {
                rowOfCapturPiece = m_FromSquare.Row + 1;

                if (m_FromSquare.Column > m_ToSquare.Column)
                {
                    columnOfCapturPiece = m_FromSquare.Column - 1;
                }
                else
                {
                    columnOfCapturPiece = m_FromSquare.Column + 1;
                }
            }

            i_BoardGame.GetSquare(rowOfCapturPiece, columnOfCapturPiece).Type = Square.eSquareType.None;
        }
    }
}
