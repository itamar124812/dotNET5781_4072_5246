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

namespace dotNET5781_3B_4072_5246
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public bool enter_bus_successful;
        public Window1()
        {
            InitializeComponent();
        }

       void canceld_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void add_bus_click(object sender, RoutedEventArgs e)
        {
            string lisence_number = LisenceNumber.Text;
            int refull = (int)refull_num.Value;
            string Mailage = kilometrash.Text;
            int mailage = 0;
            int.TryParse(Mailage, out mailage);
            int km_last_treatment = (int)km_from_treatment.Value;
             if(start_date.SelectedDate == null)
            { 
                MessageBox.Show("You need to enter a date for the start date. The default is today");
                start_date.SelectedDate = DateTime.Now;
            }
            DateTime startDate = (DateTime)start_date.SelectedDate;
            if (last_treatment.SelectedDate == null)
            {
                MessageBox.Show("You need to enter a date for the start date. The default is today");
                last_treatment.SelectedDate = DateTime.Now;
            }
            DateTime last_t = (DateTime)last_treatment.SelectedDate;
            Upgraded_Bus NewBus;
            Upgraded_Bus temp = new Upgraded_Bus("00-000-00", 0, 0, 0, DateTime.Parse("1/1/0001"), DateTime.Parse("1/1/0001"));
            try
            {
                NewBus = new Upgraded_Bus(lisence_number, refull, mailage, km_last_treatment, startDate, last_t);
                temp = NewBus;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                enter_bus_successful = false;
                this.Close();
            }
            enter_bus_successful = true;
            this.Tag = temp;
            this.Close();
        }

       

        private void Mailage_chenge(object sender, TextChangedEventArgs e)
        {
            
            if (System.Text.RegularExpressions.Regex.IsMatch(kilometrash.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                kilometrash.Text = kilometrash.Text.Remove(kilometrash.Text.Length - 1);
            }

        }
    }
}
