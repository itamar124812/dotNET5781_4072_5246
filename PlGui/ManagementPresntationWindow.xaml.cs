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
using System.Windows.Shapes;

namespace PlGui
{
    /// <summary>
    /// Interaction logic for ManagementPresntationWindow.xaml
    /// </summary>
    public partial class ManagementPresntationWindow : Window
    {
        public ManagementPresntationWindow()
        {
            InitializeComponent();
        }

        private void LinePre_Click(object sender, RoutedEventArgs e)
        {
            LinesPresentationWindow linesPresentationWindow = new LinesPresentationWindow();
            linesPresentationWindow.Show();
        }

        private void StationPre_Click(object sender, RoutedEventArgs e)
        {
            StationsPresentationWindow stationsPresentationWindow = new StationsPresentationWindow();
            stationsPresentationWindow.Show();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
