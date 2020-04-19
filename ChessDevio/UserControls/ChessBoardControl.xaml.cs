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
                string color = (p.Position.x + p.Position.y) % 2 == 0 ? "White" : "Black";
                Images.Find(x => x.Position.Equals(p.Position)).Img.Source = new BitmapImage(new Uri($"{p.ImagePath}{color}.png"));
                Uri source = new Uri(p.ImagePath);
            }
            foreach (Piece p in whitePieces)
            {
                string color = (p.Position.x + p.Position.y) % 2 == 0 ? "White" : "Black";
                Images.Find(x => x.Position.Equals(p.Position)).Img.Source = new BitmapImage(new Uri($"{p.ImagePath}{color}.png"));
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
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Image img = new Image();
                    if ((i + j) % 2 == 0)
                    {
                        Uri source = new Uri(@"pack://application:,,,/ChessDevio;component/images/White.png");
                        img.Source = new BitmapImage(source);
                    }
                    else
                    {
                        Uri source = new Uri(@"pack://application:,,,/ChessDevio;component/images/Black.png");
                        img.Source = new BitmapImage(source);
                    }
                    Grid.SetRow(img, i);
                    Grid.SetColumn(img, j);
                    gcBoard.Children.Add(img);
                    Images.Add(new ImagePosition(img, new Position(i, j)));
                }
            }
        }
        public BitmapSource ReplaceTransparency(this BitmapSource bitmap, Color color)
        {
            var rect = new Rect(0, 0, bitmap.PixelWidth, bitmap.PixelHeight);
            var visual = new DrawingVisual();
            var context = visual.RenderOpen();
            context.DrawRectangle(new SolidColorBrush(color), null, rect);
            context.DrawImage(bitmap, rect);
            context.Close();

            var render = new RenderTargetBitmap(bitmap.PixelWidth, bitmap.PixelHeight,
                96, 96, PixelFormats.Pbgra32);
            render.Render(visual);
            return render;
        }

        private void gcBoard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var element = (UIElement)e.Source;
            int y = Grid.GetColumn(element);
            int x = Grid.GetRow(element);
            Position point = new Position(x, y);
            ChessBoardClicked(this, new ChessBoardClickedEventArgs(point));
        }
    }
}
