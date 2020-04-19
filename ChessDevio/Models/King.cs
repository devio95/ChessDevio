using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDevio.Models
{
    public class King : Piece
    {
        public override bool AllowMove(Position newPosition, List<Piece> myPieces, List<Piece> opPieces)
        {
            // Jeśli klikamy w swoją inną bierkę
            if (!CheckIfFree(myPieces, newPosition))
            {
                return false;
            }
            if (Math.Abs(Position.x - newPosition.x) > 1 || Math.Abs(Position.y - newPosition.y) > 1)
            {
                return false;
            }
            return true;
        }
    }
}
