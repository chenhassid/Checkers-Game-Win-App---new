using System;
using System.Collections.Generic;

namespace GameLogic
{
    public class GameManager
    {
        public event EventHandler InvalidMove;

        public event EventHandler MakeMove;

        public event EventHandler EndGameRound;
        public enum eGameStatus
        {
            Winner,
            Lose,
            Draw,
            NotFinished,
        }

        private eGameStatus m_GameStatus;
        private bool v_Turn;
        private BoardGame m_BoardGame;
        private short m_BoardSize;
        private Player m_Player1;
        private Player m_Player2;
        private static Random s_Random = new Random();
        private List<Move> m_LegalJumps;

        public GameManager(string i_Player1, string i_Player2, short i_BoardSize)
        {
            m_GameStatus = eGameStatus.NotFinished;
            v_Turn = true;
            m_Player1 = new Player(Player.eShapeType.X, i_Player1, Player.ePlayerType.Person);
            m_Player2 = new Player(Player.eShapeType.O, i_Player2, Player.ePlayerType.Person);
            m_BoardSize = i_BoardSize;
            m_BoardGame = new BoardGame(m_BoardSize);
            m_BoardGame.BuildBoard();
            m_LegalJumps = new List<Move>();
        }
        public GameManager(string i_Player1, short i_BoardSize)
        {
            m_GameStatus = eGameStatus.NotFinished;
            v_Turn = true;
            m_Player1 = new Player(Player.eShapeType.X, i_Player1, Player.ePlayerType.Person);
            m_Player2 = new Player(Player.eShapeType.O, "Computer", Player.ePlayerType.Computer);
            m_BoardSize = i_BoardSize;
            m_BoardGame = new BoardGame(m_BoardSize);
            m_BoardGame.BuildBoard();
            m_LegalJumps = new List<Move>();
        }

        private static bool isContainsMoveElement(List<Move> i_ListOfMoves, Move i_CurrentMove)
        {
            bool isContainsMove = false;

            foreach (Move m in i_ListOfMoves)
            {
                if (i_CurrentMove.IsEqualsTo(m))
                {
                    isContainsMove = true;
                    break;
                }
            }

            return isContainsMove;
        }
        public Player Player1
        {
            get
            {
                return this.m_Player1;
            }
        }

        public Player Player2
        {
            get
            {
                return this.m_Player2;
            }
        }
        public BoardGame GetBoardGame()
        {
            return this.m_BoardGame;
        }
        public eGameStatus GameStatus
        {
            get { return this.m_GameStatus; }
            set { this.m_GameStatus = value; }
        }
        public void GameRound(Move i_CurrentMove)
        {
            i_CurrentMove.FromSquare = m_BoardGame.GetSquare(i_CurrentMove.FromSquare.Row, i_CurrentMove.FromSquare.Column);
            i_CurrentMove.ToSquare = m_BoardGame.GetSquare(i_CurrentMove.ToSquare.Row, i_CurrentMove.ToSquare.Column);

            if (this.m_GameStatus == eGameStatus.NotFinished)
            {
                if (v_Turn)
                {
                    playCurrentPlayerTurn(i_CurrentMove, m_Player1, m_Player2);
                }
                else
                {
                    if (m_Player2.PlayerType == Player.ePlayerType.Person)
                    {
                        playCurrentPlayerTurn(i_CurrentMove, m_Player2, m_Player1);
                    }
                }

                checkGameStatus();
                if (this.m_GameStatus == eGameStatus.NotFinished)
                {
                    if (!v_Turn)
                    {
                        if (m_Player2.PlayerType == Player.ePlayerType.Computer)
                        {
                            PlayComputerTurn();
                        }
                    }
                }
            }

            checkGameStatus();
            if (this.m_GameStatus != eGameStatus.NotFinished)
            {
                if (this.m_GameStatus == eGameStatus.Winner)
                {
                    EndGameRound.Invoke(Player1, EventArgs.Empty);
                }
                else
                {
                    EndGameRound.Invoke(Player2, EventArgs.Empty);
                }
            }
        }
        private void checkGameStatus()
        {
            List<Move> diagonalMovesOfPlayer1 = m_BoardGame.GetListOfPlayerDiagonalMoves(Player.eShapeType.X);
            List<Move> diagonalMovesOfPlayer2 = m_BoardGame.GetListOfPlayerDiagonalMoves(Player.eShapeType.O);
            List<Move> jumpsMovesOfPlayer1 = m_BoardGame.GetListOfPlayerJumps(Player.eShapeType.X);
            List<Move> jumpsMovesOfPlayer2 = m_BoardGame.GetListOfPlayerJumps(Player.eShapeType.O);

            if (diagonalMovesOfPlayer1.Count == 0 && diagonalMovesOfPlayer2.Count == 0 && jumpsMovesOfPlayer1.Count == 0 && jumpsMovesOfPlayer2.Count == 0)
            {
                this.m_GameStatus = eGameStatus.Draw;
            }
            else
            {
                if ((diagonalMovesOfPlayer1.Count == 0 && jumpsMovesOfPlayer1.Count == 0) || (m_BoardGame.GetPointsOfPlayer(m_Player1.GetShapeType()) == 0))
                {
                    this.m_GameStatus = eGameStatus.Lose;
                    m_Player2.Points = (m_BoardGame.GetPointsOfPlayer(m_Player2.GetShapeType()) - m_BoardGame.GetPointsOfPlayer(m_Player1.GetShapeType()));
                }
                else
                {
                    if ((diagonalMovesOfPlayer2.Count == 0 && jumpsMovesOfPlayer2.Count == 0) || (m_BoardGame.GetPointsOfPlayer(m_Player2.GetShapeType()) == 0))
                    {
                        this.m_GameStatus = eGameStatus.Winner;
                        m_Player1.Points = (m_BoardGame.GetPointsOfPlayer(m_Player1.GetShapeType()) - m_BoardGame.GetPointsOfPlayer(m_Player2.GetShapeType()));
                    }
                }
            }
        }
        internal void PlayComputerTurn()
        {
            List<Move> computerJumpsMoves = m_BoardGame.GetListOfPlayerJumps(Player.eShapeType.O);
            int lengthOfJumpsList = computerJumpsMoves.Count;
            Move currentMoveForComputer = null;

            if (lengthOfJumpsList > 0)
            {
                while (lengthOfJumpsList > 0)
                {
                    int indexOfJumplMove = s_Random.Next(0, lengthOfJumpsList);
                    currentMoveForComputer = computerJumpsMoves[indexOfJumplMove];
                    currentMoveForComputer.MoveType = Move.eTypeOfMove.Jump;
                    MakeMove.Invoke(currentMoveForComputer, EventArgs.Empty);
                    currentMoveForComputer.MoveOnBoard(m_BoardGame);
                    m_Player2.IsJumpTurn = true;

                    if (hasAnotherJump(currentMoveForComputer, m_Player2))
                    {
                        computerJumpsMoves = getListOfJumpsForPiece(m_Player2.GetShapeType(), currentMoveForComputer.ToSquare);
                        lengthOfJumpsList = computerJumpsMoves.Count;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                List<Move> computerDiagonalMoves = m_BoardGame.GetListOfPlayerDiagonalMoves(Player.eShapeType.O);
                int lengthOfListDiagonal = computerDiagonalMoves.Count;
                int indexOfDiagonalMove = s_Random.Next(0, lengthOfListDiagonal);
                currentMoveForComputer = computerDiagonalMoves[indexOfDiagonalMove];
                currentMoveForComputer.MoveType = Move.eTypeOfMove.Regular;
                MakeMove.Invoke(currentMoveForComputer, EventArgs.Empty);
                currentMoveForComputer.MoveOnBoard(m_BoardGame);
            }

            v_Turn = !v_Turn;
        }
        private void playCurrentPlayerTurn(Move i_CurrentMove, Player i_PlayerTurn, Player i_NotPlayerTurn)
        {
            bool isValid = isValidMove(i_CurrentMove, i_PlayerTurn);
            if (!isValid)
            {
                InvalidMove.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MakeMove.Invoke(i_CurrentMove, EventArgs.Empty);
                i_CurrentMove.MoveOnBoard(m_BoardGame);

                if (i_PlayerTurn.IsJumpTurn)
                {
                    if (hasAnotherJump(i_CurrentMove, i_PlayerTurn))
                    {
                        m_LegalJumps = getListOfJumpsForPiece(i_PlayerTurn.GetShapeType(), i_CurrentMove.ToSquare);
                    }
                    else
                    {
                        v_Turn = !v_Turn;
                        i_PlayerTurn.IsJumpTurn = false;
                    }
                }
                else
                {
                    v_Turn = !v_Turn;
                }
            }
        }
        private bool hasAnotherJump(Move i_CurrentMove, Player i_PlayerTurn)
        {
            List<Move> playerSecondJumps = getListOfJumpsForPiece(i_PlayerTurn.GetShapeType(), i_CurrentMove.ToSquare);

            return (playerSecondJumps.Count > 0) ? true : false;
        }
        public bool isValidMove(Move i_CurrentMove, Player i_PlayerTurn)
        {
            bool isValid = false;

            if (i_PlayerTurn.IsJumpTurn)
            {
                if (isContainsMoveElement(m_LegalJumps, i_CurrentMove))
                {
                    isValid = true;
                    i_CurrentMove.MoveType = Move.eTypeOfMove.Jump;
                }
            }
            else
            {
                List<Move> playerJumpMoves = m_BoardGame.GetListOfPlayerJumps(i_PlayerTurn.GetShapeType());

                if (playerJumpMoves.Count > 0)
                {
                    if (isContainsMoveElement(playerJumpMoves, i_CurrentMove))
                    {
                        isValid = true;
                        i_CurrentMove.MoveType = Move.eTypeOfMove.Jump;
                        i_PlayerTurn.IsJumpTurn = true;
                    }
                    else
                    {
                        i_PlayerTurn.IsJumpTurn = false;
                        isValid = false;
                    }
                }
                else
                {
                    if (i_CurrentMove.CheckIsValidMove(i_PlayerTurn.GetShapeType()))
                    {
                        isValid = true;
                        i_CurrentMove.MoveType = Move.eTypeOfMove.Regular;
                    }
                    else
                    {
                        isValid = false;
                    }
                }
            }

            return isValid;
        }

        private List<Move> getListOfJumpsForPiece(Player.eShapeType i_Shape, Square i_Square)
        {
            int squareRow = i_Square.Row;
            int squareColumn = i_Square.Column;
            Move currentMove;
            List<Move> leggalJumpsForPiece = m_BoardGame.GetListOfPlayerJumps(i_Shape);

            for (int i = 0; i < leggalJumpsForPiece.Count; i++)
            {
                currentMove = leggalJumpsForPiece[i];

                if (currentMove.FromSquare.Row != squareRow || currentMove.FromSquare.Column != squareColumn)
                {
                    leggalJumpsForPiece.Remove(currentMove);
                }
            }

            return leggalJumpsForPiece;
        }
    }
}
