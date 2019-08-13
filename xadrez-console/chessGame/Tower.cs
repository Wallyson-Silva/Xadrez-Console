﻿using xadrez_console.board;

namespace xadrez_console.chessGame
{
    class Tower : Piece
    {
        public Tower(Color color, Board board) : base(color, board)
        {
        }

        public override string ToString()
        {
            return "T";
        }

        private bool YesMove(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            //above
            pos.DefineValues(Position.Line - 1, Position.Column);
            while (Board.PositionValid(pos) && YesMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line -= 1;
            }
            //
            pos.DefineValues(Position.Line + 1, Position.Column);
            while (Board.PositionValid(pos) && YesMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line += 1;
            }
            //
            pos.DefineValues(Position.Line, Position.Column + 1);
            while (Board.PositionValid(pos) && YesMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column += 1;
            }
            //
            pos.DefineValues(Position.Line, Position.Column - 1);
            while (Board.PositionValid(pos) && YesMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column -= 1;
            }
            return mat;
        }
    }
}