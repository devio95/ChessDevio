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
    }
    public enum PieceColor
    {
        White,
        Black
    }
}
