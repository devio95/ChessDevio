using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDevio.Models
{
    public class Queen : Piece
    {
        public override bool AllowMove(Position newPosition, List<Piece> myPieces, List<Piece> opPieces)
        {
            // Jeśli klikamy w swoją inną bierkę
            if (!CheckIfFree(myPieces, newPosition))
            {
                return false;
            }
            // Jeżeli ruch jak wierza góra/dół
            if (newPosition.x == Position.x || newPosition.y == Position.y)
            {
                return RockMove(newPosition, myPieces, opPieces);
            }
            else
            {
                return BishopMove(newPosition, myPieces, opPieces);
            }
        }
        private bool BishopMove(Position newPosition, List<Piece> myPieces, List<Piece> opPieces)
        {
            for (int i = 1; i < 5; i++)
            {
                // Pozycje 4 ruchów
                Position tmp1 = new Position(Position.x + i, Position.y + i);
                Position tmp2 = new Position(Position.x - i, Position.y + i);
                Position tmp3 = new Position(Position.x + i, Position.y - i);
                Position tmp4 = new Position(Position.x - i, Position.y - i);
                if (tmp1.Equals(newPosition))
                {
                    Position pos = new Position(Position.x + 1, Position.y + 1);
                    while (!pos.Equals(newPosition))
                    {
                        if (CheckIfFree(myPieces, pos) && CheckIfFree(opPieces, pos))
                        {
                            pos.x++;
                            pos.y++;
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else if (tmp2.Equals(newPosition))
                {
                    Position pos = new Position(Position.x - 1, Position.y + 1);
                    while (!pos.Equals(newPosition))
                    {
                        if (CheckIfFree(myPieces, pos) && CheckIfFree(opPieces, pos))
                        {
                            pos.x--;
                            pos.y++;
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else if (tmp3.Equals(newPosition))
                {
                    Position pos = new Position(Position.x + 1, Position.y - 1);
                    while (!pos.Equals(newPosition))
                    {
                        if (CheckIfFree(myPieces, pos) && CheckIfFree(opPieces, pos))
                        {
                            pos.x++;
                            pos.y--;
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else if (tmp4.Equals(newPosition))
                {
                    Position pos = new Position(Position.x - 1, Position.y - 1);
                    while (!pos.Equals(newPosition))
                    {
                        if (CheckIfFree(myPieces, pos) && CheckIfFree(opPieces, pos))
                        {
                            pos.x--;
                            pos.y--;
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
            return false;
        }
        private bool RockMove(Position newPosition, List<Piece> myPieces, List<Piece> opPieces)
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
