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
    /// The options in the exercise are adding a new bus at the touch of a button,
    ///  Make a new trip with enter bonus, refueling and treatment at the touch of a button.
    ///  By double-clicking on the license number, a window opens with the bus details + refueling option + treatment option.
    ///  When the bus is ready to travel the background color for the license number will be white.When traveling yellow,when refueling green and gray when treatment will be done (additional bonus)
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Upgraded_Bus> Bus_manager_system = new ObservableCollection<Upgraded_Bus>();
       private Upgraded_Bus current_bus;
       
        public MainWindow()
        {
            //We set up 4 "special" buses (they are according to the definitions of the exercise with close treatment or refueling) and added 6 more random buses
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
                AssignsDate(r);
            }
            DataContext = Bus_manager_system;
           
            //List_Bus.ItemsSource = Bus_manager_system;
        }

        private void AssignsDate(Random r)
        {
            int lisence_num = r.Next(1000000, 10000000);
            DateTime DateForStart = new DateTime(1960, 1, 1);
            DateForStart = DateForStart.AddYears(r.Next(0, 58));
            DateForStart = DateForStart.AddMonths(r.Next(0, 12));
            DateForStart = DateForStart.AddDays(r.Next(0, 30));
            DateTime Last_treatment = new DateTime(2020, 1, 1);
            Last_treatment = Last_treatment.AddMonths(r.Next(0, 11));
            Last_treatment = Last_treatment.AddDays(r.Next(0, 30));
            int mailge = r.Next(1000000);
            int fromLastreatment = r.Next(0, 20000);
            int Refull = r.Next(0, 1200);
            Upgraded_Bus F = new Upgraded_Bus(lisence_num.ToString("00-000-00"), Refull, mailge, fromLastreatment, DateForStart, Last_treatment);
            Bus_manager_system.Add(F);
        }
        //Add new bus button function that opens a new window for adding a bus
        private void Button_Add_click(object sender, RoutedEventArgs e)
        {
            Window1 secondwindow = new Window1();
            secondwindow.Show();
            secondwindow.Closed += Secondwindow_Closed;
        }
        //An event that closes the window for adding a new bus makes sure everything went smoothly and adds it
        private void Secondwindow_Closed(object sender, EventArgs e)
        {
            if ((sender as Window1).enter_bus_successful)
            {
                Bus_manager_system.Add((sender as Window1).Tag as Upgraded_Bus);
                Bus_manager_system_CollectionChanged();
            }
            else return;
        }
        //A function that updates the list
        private void Bus_manager_system_CollectionChanged()
        {
            List_Bus.Items.Refresh();
        }
        //A function that finds the selected bus with the license number
        private Upgraded_Bus find(string l_n)
        {
            foreach ( Upgraded_Bus A in List_Bus.Items)
            {
                if (A.l_n == l_n)
                    return A;
            }
            return null;
        }

        //function that sent bus to refueling
        private void refull_Click(object sender, RoutedEventArgs e)
        {
           current_bus= find((sender as Button).Tag as string);
            current_bus.Make_a_refull();
        }
       
        private void Make_New_Drive(object sender, RoutedEventArgs e)
        {
            drive_window Drive_w = new drive_window();
            string bus = (sender as Button).Tag as string;
            current_bus = find(bus);
            Drive_w.Show();
            Drive_w.Closed += Drive_w_Closed;
        }

        private void Drive_w_Closed(object sender, EventArgs e)
        {
            try
            {
               current_bus.Make_a_trip((sender as drive_window).Distance_for_drive);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void treatment_click(object sender, RoutedEventArgs e)
        {
            current_bus = find((sender as Button).Tag as string);
            current_bus.Make_a_treatment();
        }

        private void item_double_click(object sender, MouseButtonEventArgs e)
        {

            current_bus = (sender as ContentControl).DataContext as Upgraded_Bus;
            Window2 showing_ditels = new Window2(current_bus);
            showing_ditels.Show();
        }
    }
}
