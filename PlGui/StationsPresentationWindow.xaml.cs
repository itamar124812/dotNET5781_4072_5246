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
using System.Collections.ObjectModel;
using Bl.BO;
using BlApi;

namespace PlGui
{
    /// <summary>
    /// Interaction logic for StationsPresentationWindow.xaml
    /// </summary>
    public partial class StationsPresentationWindow : Window
    {
        ObservableCollection<BusStation> busStations = new ObservableCollection<BusStation>();
        IBl Bl = BlFactory.GetBl();
        public ObservableCollection<T> Convert<T>(IEnumerable<T> original)
        {
            return new ObservableCollection<T>(original);
        }
        public StationsPresentationWindow()
        {
            InitializeComponent();
            busStations = Convert(Bl.GetAllStations());
            DataContext = busStations;
            foreach (var item in busStations)
            {
                busStations.Add(item);
            }
        }

    }
}
