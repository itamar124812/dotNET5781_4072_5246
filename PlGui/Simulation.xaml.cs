using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents; 
using System.Windows.Input;
using BlApi;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PlGui
{
    public class Tools:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private TimeSpan time;
        public TimeSpan StartTime
        {
            get => time; 
            set
            {
                time = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StartTime"));
            }
        }
    }
    /// <summary>
    /// Interaction logic for Simulation.xaml
    /// </summary>
    public partial class Simulation : Window
    {
        public bool StartOrStop = true;
        private BackgroundWorker worker = new BackgroundWorker();
        IBl bl = BlFactory.GetBl();
        Tools tool = new Tools();
        int rate = 0;
        
      

        public Simulation()
        {
            InitializeComponent();
            worker.DoWork += Worker_DoWork;
            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;
            Clock.DataContext = tool;
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
 
            bl.StartSimulator(tool.StartTime, rate, UpdateTime);
            StartOrStop = false;
        }
        void UpdateTime(TimeSpan T)
        {
            tool.StartTime+=TimeSpan.FromSeconds(rate);
            T = tool.StartTime;
        }

        private void Try_Text(object sender, TextCompositionEventArgs e)
        {

        }

        private void input_cheke(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch((sender as TextBox).Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                (sender as TextBox).Text = (sender as TextBox).Text.Remove((sender as TextBox).Text.Length - 1);
            }
        }

        private void OnOffButton_Click(object sender, RoutedEventArgs e)
        {
            if (StartOrStop)
            {
                OnOffButton.Content = "Stop";
                Rate.IsReadOnly = true;
                Clock.IsReadOnly = true;
                try
                {
                    tool.StartTime = TimeSpan.Parse(Clock.Text);
                }
                catch(Exception ex)
                {
                    tool.StartTime = TimeSpan.Zero;
                }
                rate = int.Parse(Rate.Text);
                worker.RunWorkerAsync();              
            }
            else
            {
                worker.CancelAsync();
                bl.StopSimulator();
                Rate.IsReadOnly = false;
                Clock.IsReadOnly = false;
                OnOffButton.Content = "Start";
                StartOrStop = true;               
            }
        }
    }
}
