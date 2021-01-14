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
using BlApi;

namespace PlGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBl Bl = BlApi.BlFactory.GetBl();
        public MainWindow()
        {
            
            InitializeComponent();
            LinesPresentationWindow lpw = new LinesPresentationWindow();
            lpw.Show();
            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string a = Password.Password;
        }

        private void SignUp(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
