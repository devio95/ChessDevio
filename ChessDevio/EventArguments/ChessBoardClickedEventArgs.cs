using ChessDevio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDevio.EventArguments
{
    public class ChessBoardClickedEventArgs : EventArgs
    {
        public Position Position { get; set; }
        public ChessBoardClickedEventArgs(Position position)
        {
            Position = position;
        }
    }
}
