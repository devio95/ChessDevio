using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDevio.Models
{
    public class Rook : Piece
    {
        public override bool AllowMove(Position newPosition, List<Piece> myPieces, List<Piece> opPieces)
        {
            // Jeżeli nie zgadza się ani x ani y
            if (newPosition.x != Position.x && newPosition.y != Position.y)
            {
                return false;
            }
            // Jeśli klikamy w swoją inną bierkę
            if (!CheckIfFree(myPieces, newPosition))
            {
                return false;
            }
            // Jesli klikamy w puste pole lub bicie
            else //if (CheckIfFree(myPieces, newPosition) && CheckIfFree(opPieces, newPosition))
            {
                if (CheckIsWayIsFree(newPosition, myPieces, opPieces))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            throw new NotImplementedException("Brak wykrytego ruchu dla wieży");
        }
        private bool CheckIsWayIsFree(Position newPosition, List<Piece> myPieces, List<Piece> opPieces)
        {
            // Ruszamy się w pozycji Y
            if (newPosition.y != Position.y)
            {
                // Ruch w dół
                if (Position.y < newPosition.y)
                {
                    for (int y = Position.y + 1; y < newPosition.y; y++)
                    {
                        Position tmp = new Position(Position.x, y);
                        if (CheckIfFree(myPieces, tmp) && CheckIfFree(opPieces, tmp))
                        {
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return true;
                }
                //Ruch w górę
                else
                {
                    for (int y = Position.y - 1; y > newPosition.y; y--)
                    {
                        Position tmp = new Position(Position.x, y);
                        if (CheckIfFree(myPieces, tmp) && CheckIfFree(opPieces, tmp))
                        {
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            // Ruszamy się w pozycji X
            else
            {
                // Ruch w prawo
                if (Position.x < newPosition.x)
                {
                    for (int x = Position.x + 1; x < newPosition.x; x++)
                    {
                        Position tmp = new Position(x, Position.y);
                        if (CheckIfFree(myPieces, tmp) && CheckIfFree(opPieces, tmp))
                        {
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return true;
                }
                // Ruch w lewo
                else
                {
                    for (int x = Position.x - 1; x > newPosition.x; x--)
                    {
                        Position tmp = new Position(x, Position.y);
                        if (CheckIfFree(myPieces, tmp) && CheckIfFree(opPieces, tmp))
                        {
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
        }
    }
}
