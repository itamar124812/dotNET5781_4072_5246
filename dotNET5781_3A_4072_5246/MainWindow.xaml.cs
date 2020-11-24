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

namespace dotNET5781_3A_4072_5246
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    using CollectionBusLines = dotNET5781_02_4072_5246.CollectionBusLines;
    using LineBus = dotNET5781_02_4072_5246.LineBus;
    using station = dotNET5781_02_4072_5246.BusLineStation;
    using area = dotNET5781_02_4072_5246.area;
    public partial class MainWindow : Window 
    {
        private LineBus currentDisplayBusLine;
        public MainWindow()
        {
            InitializeComponent();
            CollectionBusLines A = new CollectionBusLines();
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 10; i++)
            {
                
                    int b = r.Next(0, 1000);
                    LineBus D = new LineBus(b);
                    station temp1 = new station(2 * i);
                    station temp2 = new station(2 * i + 1);
                    D.enter_head(temp1);
                    D.The_line_bus.Add(temp2);
                try
                {
                    A.add(D);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
            cbBusLines.ItemsSource = A;
            cbBusLines.DisplayMemberPath = "_Bus_Number ";
            cbBusLines.SelectedIndex = 0;
           



        }
        void ShowBusLine(int indexr)
        {
            
            currentDisplayBusLine = (cbBusLines.ItemsSource as CollectionBusLines).find(indexr);
            string s= indexr.ToString();
            UpGrid.DataContext = currentDisplayBusLine;
            
            lbBusLineStations.DataContext = currentDisplayBusLine.The_line_bus;
            
            area a =  (area)currentDisplayBusLine.AREA;
            string b = a.ToString();
            tbArea.Text = b;
            
        }
       
        
        private void cbBusLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
             ShowBusLine((cbBusLines.SelectedValue as LineBus)._Bus_Number);
            
        }

        private void func(object sender, MouseButtonEventArgs e)
        {
             Random r = new Random(DateTime.Now.Millisecond);
                int x = r.Next(0, 100);
                int y = r.Next(0, 100);
                string temp = x.ToString();
                temp += y.ToString();
                for_fun.Width += x;
                for_fun.Height += y; 
            
        }
    }
}
