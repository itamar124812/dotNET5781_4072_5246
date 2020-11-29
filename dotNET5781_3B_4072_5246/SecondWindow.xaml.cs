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
            //Upgraded_Bus NewBus = new Upgraded_Bus(lisence_number, refull,mailage,);
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
