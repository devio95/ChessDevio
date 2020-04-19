using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ChessDevio.Models
{
    public class ImagePosition
    {
        public Image Img { get; set; }
        public Position Position { get; set; }
        public ImagePosition(Image img, Position position)
        {
            Img = img;
            Position = position;
        }
    }
}
