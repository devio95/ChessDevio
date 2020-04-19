using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDevio.Models
{
    public class Pawn : Piece
    {
        public override bool AllowMove(Position newPosition, List<Piece> myPieces, List<Piece> opPieces)
        {
            if (Color == PieceColor.White)
            {
                // Jeżeli pole startowe i 2 ruchy do przodu
                if (Position.y == 1 && newPosition.y == (Position.y + 2) && newPosition.x == Position.x)
                {
                    // Trzeba sprawdzić czy obydwa pola są wolne
                    Position tmpPos = new Position(newPosition.x, newPosition.y - 1);
                    if (CheckIfFree(myPieces, newPosition) && CheckIfFree(opPieces, newPosition) && CheckIfFree(myPieces, tmpPos) && CheckIfFree(opPieces, tmpPos))
                    {
                        return true;
                    }
                }
                // Jeżeli ruch do przodu
                else if (newPosition.y == (Position.y + 1) && newPosition.x == Position.x)
                {
                    // Jesli pole jest puste to mozna wykonac ruch
                    if (CheckIfFree(myPieces, newPosition) && CheckIfFree(opPieces, newPosition))
                    {
                        return true;
                    }
                }
                // Bicie
                else if ((newPosition.x == (Position.x + 1) || newPosition.x == (Position.x - 1)) && newPosition.y == (Position.y + 1))
                {
                    if (!CheckIfFree(opPieces, newPosition))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                // Jeżeli pole startowe i 2 ruchy do przodu
                if (Position.y == 6 && newPosition.y == (Position.y - 2) && newPosition.x == Position.x)
                {
                    // Trzeba sprawdzić czy obydwa pola są wolne
                    Position tmpPos = new Position(newPosition.x, newPosition.y + 1);
                    if (CheckIfFree(myPieces, newPosition) && CheckIfFree(opPieces, newPosition) && CheckIfFree(myPieces, tmpPos) && CheckIfFree(opPieces, tmpPos))
                    {
                        return true;
                    }
                }
                // Jeżeli ruch do przodu
                else if (newPosition.y == (Position.y - 1) && newPosition.x == Position.x)
                {
                    // Jesli pole jest puste to mozna wykonac ruch
                    if (CheckIfFree(myPieces, newPosition) && CheckIfFree(opPieces, newPosition))
                    {
                        return true;
                    }
                }
                // Bicie
                else if ((newPosition.x == (Position.x + 1) || newPosition.x == (Position.x - 1)) && newPosition.y == (Position.y - 1))
                {
                    if (!CheckIfFree(opPieces, newPosition))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
