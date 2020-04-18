using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ChessDevio.Controler
{
    public static class Controller
    {
        public static MainWindow Window;
        public static void SetControl(UserControl control)
        {
            Window.SetPanel(control);
        }
    }
}
