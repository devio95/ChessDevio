using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDevio.Models
{
    public class Player
    {
        public string Name { get; set; }
        public bool Color { get; set; }
        private List<Piece> Pieces { get; set; }
        public Player(string name, bool color)
        {
            Name = name;
            Color = color;
            CreatePieces();
        }
        private void CreatePieces()
        {
            
        }
        public virtual void Move()
        {

        }
    }
}
