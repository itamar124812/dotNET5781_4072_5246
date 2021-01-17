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
using BlApi;

namespace PlGui.Users
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        public IBl bl = BlFactory.GetBl();
        public readonly string Key = "4072_1050";
        public SignUpWindow()
        {
            InitializeComponent();
        }

        private void Join_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (key.Text == Key) bl.AddUser(this.NewUserName.Text, NewPasssword.Password, true);
                else bl.AddUser(this.NewUserName.Text, NewPasssword.Password, false);
            }
            catch (Bl.BO.UserException ex)
            {
                MessageBox.Show(ex.Message);
                NewUserName.Clear();
            }
            if (NewUserName.Text != null) this.Close();
        }
    }
}
