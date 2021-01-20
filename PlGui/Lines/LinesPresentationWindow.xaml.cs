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
    public delegate void DataTransferAddWindow(int Linenum, int area, int laststation);
    public delegate void DataTransferDeleteWindoe(int id);

    /// <summary>
    /// Interaction logic for LinesPresentationWindow.xaml
    /// </summary>
    public partial class LinesPresentationWindow : Window
    {
        public DataTransferAddWindow del;
        public DataTransferDeleteWindoe DWDateTransfer;
        
        public ObservableCollection<T> Convert<T>(IEnumerable<T> original)
        {
            return new ObservableCollection<T>(original);
        }
        IBl Bl = BlFactory.GetBl();
        ObservableCollection<LineBus> Lines = new ObservableCollection<LineBus>();
        public LinesPresentationWindow()
        {
            InitializeComponent();
            Lines = Convert(Bl.GetsAllLines());
            ListLines.DataContext = Lines;
            del += PassDataFromAddLine;
            DWDateTransfer += DeleteLine;
        }

        private void AddLineButton_Click(object sender, RoutedEventArgs e)
        {
            AddLineWindow addLineWindow = new AddLineWindow(del);
            addLineWindow.Show();
            addLineWindow.Closed += UpdateCollection;
        }

        private void UpdateCollection(object sender, EventArgs e)
        {
            Lines = Convert(Bl.GetsAllLines());
            ListLines.DataContext = Lines;
        }

     

        public void PassDataFromAddLine(int Linenum, int area, int laststation)
        {
            try
            {
                Bl.AddLine(Linenum, area, laststation);
            }
            catch (Bl.BO.BadLineExceptions ex)
            { 
                MessageBox.Show(ex.Message);
            }
            
        }
        void DeleteLine(int id)
        {
            if (id != 0)
            {
                try
                {
                    Bl.DeleteLine(id);
                }
                catch (Bl.BO.BadLineExceptions ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
   
        private void DeleteLine_Click(object sender, RoutedEventArgs e)
        {
            DeleteLineWindoe Deletewindoe = new DeleteLineWindoe(DWDateTransfer);
            Deletewindoe.Show();
            Deletewindoe.Closed += UpdateCollection;
        }

        private void DeleteStationFromLine_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddStatinToLine_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Stations_Click(object sender, RoutedEventArgs e)
        {           
            LineStatinsWindow statinsWindow = new LineStatinsWindow(Bl.GetLine((int)(sender as Button).Tag).PassingThrough.ToList());
            statinsWindow.Show();
        }
    }
}
