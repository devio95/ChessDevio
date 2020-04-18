using ChessDevio.Controler;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ChessDevio
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ApplicationStart(object sender, StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Controller.Window = mainWindow;
            Current.MainWindow = mainWindow;
            mainWindow.Show();
        }
    }
}
