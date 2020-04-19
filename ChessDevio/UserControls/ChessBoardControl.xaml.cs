using ChessDevio.EventArguments;
using ChessDevio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace ChessDevio.Controlers
{
    /// <summary>
    /// Interaction logic for ChessBoardControl.xaml
    /// </summary>
    public partial class ChessBoardControl : UserControl
    {
        private List<ImagePosition> Images;
        public event EventHandler ChessBoardClicked;
        public ChessBoardControl()
        {
            InitializeComponent();
            InitFields();
            GenerateBoard();
            ChangeBorderLineColor();
        }
        public void GenerateBoardPieces(List<Piece> blackPieces, List<Piece> whitePieces)
        {
            GenerateBoard();
            foreach (Piece p in blackPieces)
            {
                BitmapSource src = new BitmapImage(new Uri($"{p.ImagePath}.png"));
                Images.Find(x => x.Position.Equals(p.Position)).Img.Source = src;
                Uri source = new Uri(p.ImagePath);
            }
            foreach (Piece p in whitePieces)
            {
                BitmapSource src = new BitmapImage(new Uri($"{p.ImagePath}.png"));
                Images.Find(x => x.Position.Equals(p.Position)).Img.Source = src;
                Uri source = new Uri(p.ImagePath);
            }
        }
        private void InitFields()
        {
            Images = new List<ImagePosition>();
        }
        private void ChangeBorderLineColor()
        {
            var T = Type.GetType("System.Windows.Controls.Grid+GridLinesRenderer," + " PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");

            var GLR = Activator.CreateInstance(T);
            GLR.GetType().GetField("s_oddDashPen", BindingFlags.Static | BindingFlags.NonPublic).SetValue(GLR, new Pen(Brushes.Brown, 2.0));
            GLR.GetType().GetField("s_evenDashPen", BindingFlags.Static | BindingFlags.NonPublic).SetValue(GLR, new Pen(Brushes.Brown, 2.0));
        }
        private void GenerateBoard()
        {
            Images.Clear();
            BrushConverter bc = new BrushConverter();
            for (int column = 0; column < 8; column++)
            {
                for (int row = 0; row < 8; row++)
                {
                    Image img = new Image();
                    Grid gc = new Grid();
                    if ((row + column) % 2 == 0)
                    {
                        gc.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    }
                    else
                    {
                        gc.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    }
                    gc.Children.Add(img);
                    Grid.SetRow(gc, row);
                    Grid.SetColumn(gc, column);
                    gcBoard.Children.Add(gc);
                    Images.Add(new ImagePosition(img, new Position(column, row)));
                }
            }
        }

        private void gcBoard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UIElement element = (UIElement)e.Source;
            int x, y;
            if (element.GetType().Equals(typeof(Grid)))
            {
                UIElement gridParent = (UIElement)LogicalTreeHelper.GetParent(element);
                if (!gridParent.GetType().Equals(typeof(Grid)))
                {
                    return;
                }
                y = Grid.GetRow(element);
                x = Grid.GetColumn(element);
            }
            else
            {
                UIElement el2 = (UIElement)LogicalTreeHelper.GetParent(element);
                x = Grid.GetColumn(el2);
                y = Grid.GetRow(el2);
            }
            Position point = new Position(x, y);
            System.Diagnostics.Debug.WriteLine($"{x},{y}");
            ChessBoardClicked(this, new ChessBoardClickedEventArgs(point));
        }
    }
}
