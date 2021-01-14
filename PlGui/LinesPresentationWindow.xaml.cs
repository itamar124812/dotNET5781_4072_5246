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
using  System.Collections.ObjectModel;
using BlApi;
using Bl.BO;

namespace PlGui
{
    /// <summary>
    /// Interaction logic for LinesPresentationWindow.xaml
    /// </summary>
    public partial class LinesPresentationWindow : Window
    {
        public ObservableCollection<T> Convert<T>(IEnumerable<T> original)
        {
            return new ObservableCollection<T>(original);
        }
        IBl Bl = BlFactory.GetBl();
        ObservableCollection<LineBus> Lines = new ObservableCollection<LineBus>();
        public LinesPresentationWindow()
        {
            InitializeComponent();
            Bl.ADDStation(33, 33, 89, "Itamar");
            Bl.ADDStation(33, 33, 70, "Itamar");
            Bl.AddLine(5, 2, 89);
            Bl.AddStationToLine(1, 70, 0);
            Lines = Convert(Bl.GetsAllLines());
            ListLines.DataContext = Lines;
        }

        private void AddLineButton_Click(object sender, RoutedEventArgs e)
        {
            AddLineWindow addLineWindow = new AddLineWindow();
            addLineWindow.Show();
            addLineWindow.Closed += AddLineWindow_Closed;
        }

        private void AddLineWindow_Closed(object sender, EventArgs e)
        {
            Lines = Convert(Bl.GetsAllLines());

            
        }
    }
}
