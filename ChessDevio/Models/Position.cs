using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDevio.Models
{
    public class Position
    {
        public int x { get; set; }
        public int y { get; set; }
        public Position(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
        public override bool Equals(object obj)
        {
            Position toEqual = (Position)obj;
            if (toEqual.x == x && toEqual.y == y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
