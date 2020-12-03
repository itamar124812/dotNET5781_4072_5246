using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
        private ObservableCollection<Upgraded_Bus> Bus_manager_system = new ObservableCollection<Upgraded_Bus>();
       // private Upgraded_Bus current_bus;
        public MainWindow()
        {
            
            InitializeComponent();
            Random r = new Random(DateTime.Now.Millisecond);
            DateTime a = new DateTime(2019,1,1);
            Upgraded_Bus A = new Upgraded_Bus("123-45-678",0,0,0,a,DateTime.Parse("2020,01,02"));
            Upgraded_Bus B = new Upgraded_Bus("237-56-589",0, 19999, 0, a, DateTime.Parse("2020,01,02"));
            Upgraded_Bus C = new Upgraded_Bus("236-86-289",1199, 0, 0, a, DateTime.Parse("2020,01,02"));
            Upgraded_Bus D = new Upgraded_Bus("234-96-780", 0, 0, 0, a, DateTime.Parse("2019,01,02"));
            Bus_manager_system.Add(A);
            Bus_manager_system.Add(B);
            Bus_manager_system.Add(C);
            Bus_manager_system.Add(D);
            for (int i = 0; i <= 5; i++)
            {
                int lisence_num = r.Next(1000000, 10000000);
                Upgraded_Bus F = new Upgraded_Bus(lisence_num.ToString("00-000-00"), 0, 0, 0, DateTime.Parse("2007.4.3"), DateTime.Parse("2020,01,02"));
                Bus_manager_system.Add(F);
            }
            DataContext = Bus_manager_system;
           
            //List_Bus.ItemsSource = Bus_manager_system;
        }
        
       
        private void Button_Add_click(object sender, RoutedEventArgs e)
        {
            Window1 secondwindow = new Window1();
            secondwindow.Show();
            secondwindow.Closed += Secondwindow_Closed;
        }

        private void Secondwindow_Closed(object sender, EventArgs e)
        {
            if ((sender as Window1).enter_bus_successful)
            {
                Bus_manager_system.Add((sender as Window1).Tag as Upgraded_Bus);
                Bus_manager_system_CollectionChanged();
            }
            else return;
        }

        private void Bus_manager_system_CollectionChanged()
        {
            List_Bus.Items.Refresh();
        }


      
        private void refull_Click(object sender, RoutedEventArgs e)
        {
            (List_Bus.SelectedItem as Upgraded_Bus).Make_a_refull();
            

        }

        private void Make_New_Drive(object sender, RoutedEventArgs e)
        {
            drive_window Drive_w = new drive_window();
            Drive_w.Show();
            Drive_w.Closed += Drive_w_Closed;
        }

        private void Drive_w_Closed(object sender, EventArgs e)
        {
            try
            {
                (List_Bus.SelectedItem as Upgraded_Bus).Make_a_trip((sender as drive_window).Distance_for_drive);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void treatment_click(object sender, RoutedEventArgs e)
        {
            (List_Bus.SelectedItem as Upgraded_Bus).Make_a_treatment();
        }

        //private void Itam_double_click(object sender, MouseButtonEventArgs e)
        //{
        //    //Window2 Showing_Details = new Window2();
        //    //Showing_Details.CurrentBus = (List_Bus.SelectedItem as Upgraded_Bus);
        //    //Showing_Details.Show();

        //}
    }
}
