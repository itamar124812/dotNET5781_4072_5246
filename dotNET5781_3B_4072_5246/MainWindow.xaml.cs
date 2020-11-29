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

namespace dotNET5781_3B_4072_5246
{
    using Bus = dotNET5781_01_4072_5426.bus;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Random r = new Random(DateTime.Now.Millisecond);
            DateTime a = new DateTime(2019,1,1);
            Upgraded_Bus A = new Upgraded_Bus("123-45-678",0,0,0,a,DateTime.Parse("2020,01,02"));
            Upgraded_Bus B = new Upgraded_Bus("237-56-589",0, 19999, 0, a, DateTime.Parse("2020,01,02"));
            Upgraded_Bus C = new Upgraded_Bus("236-86-289",1199, 0, 0, a, DateTime.Parse("2020,01,02"));
            Upgraded_Bus D = new Upgraded_Bus("234-96-780", 0, 0, 0, a, DateTime.Parse("2019,01,02"));
            List<Upgraded_Bus> Bus_manager_system = new List<Upgraded_Bus>();
            Bus_manager_system.Add(A);
            Bus_manager_system.Add(B);
            Bus_manager_system.Add(C);
            Bus_manager_system.Add(D);
            for (int i = 0; i < 5; i++)
            {
                int lisence_num = r.Next(1000000, 10000000);
                Upgraded_Bus F = new Upgraded_Bus(lisence_num.ToString("00-000-00"), 0, 0, 0, DateTime.Parse("2007.4.3"), DateTime.Parse("2020,01,02"));
                Bus_manager_system.Add(F);
            }
            List_Bus.ItemsSource = Bus_manager_system;
            List_Bus.DisplayMemberPath = "l_n";
            
        }
        

        private void Button_Add_click(object sender, RoutedEventArgs e)
        {
            Window1 secondwindow = new Window1();
            secondwindow.Show();
        }

        private void Showing_Details(object sender, MouseButtonEventArgs e)
        {
           
        }
    }
}
