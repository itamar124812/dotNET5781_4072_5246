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
using BlApi;

namespace PlGui
{
   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBl Bl = BlApi.BlFactory.GetBl();
       

        public MainWindow()
        {
            
            InitializeComponent();
        }

      
       
        private void SignIn(object sender, RoutedEventArgs e)
        {
            if(Bl.IsExists(this.UserNameText.Text))
            {
                if(Bl.CheckPassword(this.UserNameText.Text, Password.Password))
                {
                    if (Bl.IsAdmin(this.UserNameText.Text))
                    {
                        ManagementPresntationWindow managementPresntation = new ManagementPresntationWindow();
                        managementPresntation.Show();
                        this.Close();
                    }
                    else throw new NotImplementedException();
                }
                else
                {
                    MessageBox.Show("You got the password wrong.", "Password wrong");
                    Password.Clear();
                }
            }
            else
            {
                MessageBox.Show(string.Format("There is no user named {0}. Try again", this.UserNameText.Text));
                Password.Clear();
                this.UserNameText.Clear();
            }
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            PlGui.Users.SignUpWindow signUpWindow = new Users.SignUpWindow();
            signUpWindow.Show();
        }
    }
}
