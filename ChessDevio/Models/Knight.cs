using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDevio.Models
{
    public class Knight : Piece
    {
        public override bool AllowMove(Position newPosition, List<Piece> myPieces, List<Piece> opPieces)
        {
            // Jeśli klikamy w swoją bierkę
            if (!CheckIfFree(myPieces, newPosition))
            {
                return false;
            }
            if ((newPosition.x == (Position.x + 2) || newPosition.x == (Position.x - 2)) && (newPosition.y == (Position.y + 1) || newPosition.y == (Position.y - 1)))
            {
                return true;
            }
            if ((newPosition.x == (Position.x + 1) || newPosition.x == (Position.x - 1)) && (newPosition.y == (Position.y + 2) || newPosition.y == (Position.y - 2)))
            {
                return true;
            }
            return false;
        }
    }
}
