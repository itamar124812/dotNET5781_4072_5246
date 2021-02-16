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
            //Simulation simulation = new Simulation();
            //simulation.Show();
           // BootVariablesRandomly();
        }
        void BootVariablesRandomly()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            //stations
            string[] names = { "TelAviv", "BnieBrak", "Afula", "Acre", "Eilat", "Ashdod", "Afula", "Petah Tiqva", "Rishon le Zion", "הרצליה-Herzliya", "Rosh Pina", "Kfar Sava", "Rehovot", "Rosh Ha'ayin", "Bethlehem", "Safed", "Jerusalem", "Haifa", "Beer-Sheva" };
            for (int i = 0; i < 100; i++)
            {
                double Latitude = random.NextDouble() * 2.3 + 31;
                double Longitude = random.NextDouble() * 1.2 + 34.3;
                int index = random.Next(0, names.Length);
                Bl.ADDStation(Latitude, Longitude, i, names[index]);
            }
            //Lines
            for (int i = 0; i < 10; i++)
            {
                int area = random.Next(0, 4);
                int lastStation = random.Next(0, 100);
                Bl.AddLine(i, area, lastStation);
            }
            //LineStations
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < Bl.GetsAllLines().Count() + 1; j++)
                {
                    int stationnum = random.Next(0, 100);
                    double distance = random.Next(0, 100000);
                    int minute = random.Next(0, 60);
                    int second = random.Next(0, 60);
                    int hour = random.Next(0, 24);
                    if (Bl.GetLine(j).PassingThrough.ToList().Find(s => s.Code == stationnum) == null)
                    {
                        try
                        {
                            Bl.AddStationToLine(j, stationnum, i, distance, TimeSpan.Parse(string.Format("{0}:{1}:{2}", hour, minute, second)));
                        }
                        catch (Exception ex)
                        {
                            --i;
                        }
                        }
                    else --i;
                }
            }

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
