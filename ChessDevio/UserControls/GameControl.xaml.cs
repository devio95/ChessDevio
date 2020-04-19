using ChessDevio.EventArguments;
using ChessDevio.Models;
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

namespace ChessDevio.UserControls
{
    /// <summary>
    /// Interaction logic for GameControl.xaml
    /// </summary>
    public partial class GameControl : UserControl
    {
        List<Piece> BlackPieces;
        List<Piece> WhitePieces;
        Piece Dragged;
        public GameControl()
        {
            InitializeComponent();
            GenerateStartPositions();
            ChessBoard.GenerateBoardPieces(WhitePieces, BlackPieces);
            ChessBoard.ChessBoardClicked += ChessBoard_ChessBoardClicked;
        }

        private void ChessBoard_ChessBoardClicked(object sender, EventArgs e)
        {
            ChessBoardClickedEventArgs args = (ChessBoardClickedEventArgs)e;
            Position position = args.Position;
            // Jeżeli nic nie zaznaczone to wybieramy bierke do zaznaczenia
            if (Dragged == null)
            {
                if (BlackPieces.Exists(p => p.Position.Equals(position)))
                {
                    Dragged = BlackPieces.Find(p => p.Position.Equals(position));
                }
                else if (WhitePieces.Exists(p => p.Position.Equals(position)))
                {
                    Dragged = WhitePieces.Find(p => p.Position.Equals(position));
                }
            }
            // Wykonanie ruchu
            else
            {
                try
                {
                    // Sprawdzenie czy mozna wykonac ruch
                    if (Dragged.Color == PieceColor.White)
                    {
                        if (!Dragged.AllowMove(position, WhitePieces, BlackPieces))
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (!Dragged.AllowMove(position, BlackPieces, WhitePieces))
                        {
                            return;
                        }
                    }
                    if (BlackPieces.Exists(p => p.Position.Equals(position)))
                    {
                        BlackPieces.Remove(BlackPieces.Find(p => p.Position.Equals(position)));
                        WhitePieces.Remove(WhitePieces.Find(p => p.Position.Equals(Dragged.Position)));
                        Dragged.Position = position;
                        WhitePieces.Add(Dragged);
                    }
                    else if (WhitePieces.Exists(p => p.Position.Equals(position)))
                    {
                        BlackPieces.Remove(BlackPieces.Find(p => p.Position.Equals(Dragged.Position)));
                        WhitePieces.Remove(WhitePieces.Find(p => p.Position.Equals(position)));
                        Dragged.Position = position;
                        BlackPieces.Add(Dragged);
                    }
                    else
                    {
                        if (Dragged.Color == Models.PieceColor.White)
                        {
                            WhitePieces.Find(x => x.Position.Equals(Dragged.Position)).Position = position;
                        }
                        else
                        {
                            BlackPieces.Find(x => x.Position.Equals(Dragged.Position)).Position = position;
                        }
                    }
                }
                finally
                {
                    ChessBoard.GenerateBoardPieces(WhitePieces, BlackPieces);
                    Dragged = null;
                }
            }
        }

        private void GenerateStartPositions()
        {
            BlackPieces = new List<Piece>();
            WhitePieces = new List<Piece>();
            // White pawns
            for (int i = 0; i < 8; i++)
            {
                AddPiece(i, 1, @"pack://application:,,,/ChessDevio;component/images/Pawn", new Pawn(), true);
            }
            // Black pawns
            for (int i = 0; i < 8; i++)
            {
                AddPiece(i, 6, @"pack://application:,,,/ChessDevio;component/images/Pawn", new Pawn(), false);
            }
            // Rooks
            AddPiece(0, 0, @"pack://application:,,,/ChessDevio;component/images/Rook", new Rook(), true);
            AddPiece(7, 0, @"pack://application:,,,/ChessDevio;component/images/Rook", new Rook(), true);
            AddPiece(0, 7, @"pack://application:,,,/ChessDevio;component/images/Rook", new Rook(), false);
            AddPiece(7, 7, @"pack://application:,,,/ChessDevio;component/images/Rook", new Rook(), false);
            // Knights
            AddPiece(1, 0, @"pack://application:,,,/ChessDevio;component/images/Knight", new Knight(), true);
            AddPiece(6, 0, @"pack://application:,,,/ChessDevio;component/images/Knight", new Knight(), true);
            AddPiece(1, 7, @"pack://application:,,,/ChessDevio;component/images/Knight", new Knight(), false);
            AddPiece(6, 7, @"pack://application:,,,/ChessDevio;component/images/Knight", new Knight(), false);
            // Bishops
            AddPiece(2, 0, @"pack://application:,,,/ChessDevio;component/images/Bishop", new Bishop(), true);
            AddPiece(5, 0, @"pack://application:,,,/ChessDevio;component/images/Bishop", new Bishop(), true);
            AddPiece(2, 7, @"pack://application:,,,/ChessDevio;component/images/Bishop", new Bishop(), false);
            AddPiece(5, 7, @"pack://application:,,,/ChessDevio;component/images/Bishop", new Bishop(), false);
            // Queens
            AddPiece(3, 0, @"pack://application:,,,/ChessDevio;component/images/Queen", new Queen(), true);
            AddPiece(3, 7, @"pack://application:,,,/ChessDevio;component/images/Queen", new Queen(), false);
            // Kings
            AddPiece(4, 0, @"pack://application:,,,/ChessDevio;component/images/King", new King(), true);
            AddPiece(4, 7, @"pack://application:,,,/ChessDevio;component/images/King", new King(), false);
        }
        private void AddPiece(int x, int y, string path, Piece piece, bool white)
        {
            piece.ImagePath = path;
            piece.Position = new Position(x, y);
            if (white)
            {
                piece.ImagePath += "Green";
                piece.Color = Models.PieceColor.White;
                WhitePieces.Add(piece);
            }
            else
            {
                piece.ImagePath += "Red";
                piece.Color = Models.PieceColor.Black;
                BlackPieces.Add(piece);
            }
        }
    }
}
