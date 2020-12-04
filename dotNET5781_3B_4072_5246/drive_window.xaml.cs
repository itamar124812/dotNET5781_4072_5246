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
    /// Interaction logic for drive_window.xaml
    /// </summary>
    public partial class drive_window : Window
    {
        public int Distance_for_drive;
        
        public drive_window()
        {
            InitializeComponent();
            this.KeyDown += CheckEnter;
        }

        private void input_cheke(object sender, TextChangedEventArgs e)
        {
                if (System.Text.RegularExpressions.Regex.IsMatch(distance.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    distance.Text = distance.Text.Remove(distance.Text.Length - 1);
                }
        }

        
        private void CheckEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string A = distance.Text;
                Distance_for_drive = int.Parse(A);
                this.Close();
            }

        }
    }
}
