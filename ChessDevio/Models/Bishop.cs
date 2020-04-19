using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDevio.Models
{
    public class Bishop : Piece
    {
        public override bool AllowMove(Position newPosition, List<Piece> myPieces, List<Piece> opPieces)
        {
            // Jeśli klikamy w swoją inną bierkę
            if (!CheckIfFree(myPieces, newPosition))
            {
                return false;
            }
            if (CheckIsWayIsCorrect(newPosition, myPieces, opPieces))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckIsWayIsCorrect(Position newPosition, List<Piece> myPieces, List<Piece> opPieces)
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
                    while(!pos.Equals(newPosition))
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
                else if(tmp2.Equals(newPosition))
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
                else if(tmp3.Equals(newPosition))
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
    }
}
