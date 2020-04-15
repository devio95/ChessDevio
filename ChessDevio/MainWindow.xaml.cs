using ChessDevio.Controlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChessDevio
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetStartControl();
        }
        public void SetPanel(UserControl control)
        {
            spMain.Children.Clear();
            spMain.Children.Add(control);
        }
        private void SetStartControl()
        {
            StartControl sControl = new StartControl();
            SetPanel(sControl);
        }
    }
}
