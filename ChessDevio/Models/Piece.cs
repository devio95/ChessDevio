using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDevio.Models
{
    public abstract class Piece
    {
        public string ImagePath { get; set; }
        public Position Position { get; set; }
        public PieceColor Color { get; set; }
        public abstract bool AllowMove(Position newPosition, List<Piece> myPieces, List<Piece> opPieces);
        public bool CheckIfFree(List<Piece> pieces, Position newPos)
        {
            foreach (Piece pc in pieces)
            {
                if (pc.Position.Equals(newPos))
                {
                    return false;
                }
            }
            return true;
        }
    }
    public enum PieceColor
    {
        White,
        Black
    }
}
