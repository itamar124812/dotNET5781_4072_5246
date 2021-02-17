//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.ComponentModel;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using BlApi;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Shapes;

//namespace PlGui
//{
//    /// <summary>
//    /// Interaction logic for Simulation.xaml
//    /// </summary>
//    public partial class Simulation : Window,INotifyPropertyChanged
//    {
//        public bool StartOrStop = true;
//        private BackgroundWorker worker = new BackgroundWorker();
//        IBl bl = BlFactory.GetBl();
//        TimeSpan StartTime;
//        int rate = 0;

//        public event PropertyChangedEventHandler PropertyChanged;

//        public Simulation()
//        {
//            InitializeComponent();
//            worker.DoWork += Worker_DoWork;         
//            TimeSimulation.DataContext = StartTime;
//        }

//        private void Worker_DoWork(object sender, DoWorkEventArgs e)
//        {                                
//            bl.StartSimulator(StartTime, rate, T => { T += TimeSpan.FromSeconds(rate);PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StartTime")); });
//            StartOrStop = false;
//        }

//        private void Try_Text(object sender, TextCompositionEventArgs e)
//        {

//        }

//        private void input_cheke(object sender, TextChangedEventArgs e)
//        {
//            if (System.Text.RegularExpressions.Regex.IsMatch((sender as TextBox).Text, "[^0-9]"))
//            {
//                MessageBox.Show("Please enter only numbers.");
//                (sender as TextBox).Text = (sender as TextBox).Text.Remove((sender as TextBox).Text.Length - 1);
//            }
//        }

//        private void OnOffButton_Click(object sender, RoutedEventArgs e)
//        {
//            if (StartOrStop)
//            {
//                OnOffButton.Content = "Stop";
//                Rate.IsReadOnly = true;
//                TimeSimulation.IsReadOnly = true;
//                TimeSpan.TryParse(TimeSimulation.Text, out StartTime);
//                rate = int.Parse(Rate.Text);
//                worker.RunWorkerAsync();              
//            }
//            else
//            {
//                bl.StopSimulator();
//                Rate.IsReadOnly = false;
//                TimeSimulation.IsReadOnly = false;
//                OnOffButton.Content = "Start";
//                StartOrStop = true;
//            }
//        }
//    }
//}
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
using System.Threading;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BlApi;
using Bl;
using PlGui.PO;


namespace PlGui
{
    /// <summary>
    /// Interaction logic for SimulationWindow.xaml
    /// </summary>
    public partial class SimulationWindow : Window
    {
        List<PO.PL_viewST> listhelp = new List<PO.PL_viewST>();
        ObservableCollection<PO.PL_viewST> simolatorItems = new ObservableCollection<PO.PL_viewST>();
        IBl Bl = BlFactory.GetBl();
        int timeInMin = 0;
        TimeSpan Time;
        int rate;
        private readonly BackgroundWorker Worker = new BackgroundWorker();
        public SimulationWindow( )
        {
            InitializeComponent();
            StartStopB.Background = Brushes.Green;
            SimulationLV.Visibility = Visibility.Hidden;
            Worker.DoWork += worker_DoWork;
            Worker.ProgressChanged += worker_ProgressChanged;
            Worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            Worker.WorkerReportsProgress = true;
            Worker.WorkerSupportsCancellation = true;
            HourTB.Text = DateTime.Now.Hour.ToString();
            MinutesTB.Text = DateTime.Now.Minute.ToString();
            SecondTB.Text = DateTime.Now.Second.ToString();
        }
        //fill the simulator into lines and considerate in them frenqency
        private void fillsimolatorItems()
        {
            var help = Bl.GetAllStartRout_By(null).ToList();
            PO.PL_viewST NewTemp;
            simolatorItems.Clear();
            listhelp.Clear();
            for (int i = 0; i < help.Count; i++)
            {
                var yo = Bl.GetAllStationsPassLine_By(help[i].LineId).ToList();
                NewTemp = new PO.PL_viewST();
                // NewTemp.Id = help[i].Id;
                NewTemp.LineId = help[i].LineId;
                NewTemp.fre = Bl.Get_BL_Route(NewTemp.LineId).Frequency;
                NewTemp.StartAt = help[i].StartAt;
                NewTemp.StartStation = 0;
                NewTemp.NowStation = 0;
                NewTemp.CountStation = yo.Count;
                NewTemp.FirstStation = yo[0].Code;
                if (NewTemp.fre != 0)
                    NewTemp.count = 24 / NewTemp.fre;
                NewTemp.NextStation = yo[1].Code;
                NewTemp.NextStationTime = Bl(NewTemp.FirstStation, NewTemp.NextStation).Time;

                NewTemp.LastStation = yo[yo.Count - 1].Code;
                listhelp.Add(NewTemp);
            }
            List<PL_viewST> yephelp = new List<PL_viewST>();
            PL_viewST temp;
            foreach (var item in listhelp)
            {
                if (item.fre != 0)
                    for (int i = 0; i < item.count; i++)
                    {
                        temp = new PL_viewST();
                        temp = item;
                        if (i != 0)
                        {
                            int tep = temp.StartAt.Hours + item.fre;
                            if (tep >= 24)
                                tep %= 24;
                            temp.StartAt = new TimeSpan(tep, temp.StartAt.Minutes, temp.StartAt.Seconds);
                        }
                        yephelp.Add(temp.CopyPropertiesto(new PL_viewST()));
                    }
                else
                    yephelp.Add(item);
            }
            yephelp.Sort();
            foreach (var item in yephelp)
            {
                simolatorItems.Add(item);
            }
        }
        //when you Presses the button event activated by backgroundWorker
        private void StartStopB_Click(object sender, RoutedEventArgs e)
        {
            if (StartStopB.Content.ToString() == "Start")
            {
                try
                {
                    if (Int32.Parse(HourTB.Text) > 24 || Int32.Parse(HourTB.Text) < 0)
                        throw null;
                    if (Int32.Parse(MinutesTB.Text) > 60 || Int32.Parse(HourTB.Text) < 0)
                        throw null;
                    if (Int32.Parse(SecondTB.Text) > 60 || Int32.Parse(SecondTB.Text) < 0)
                        throw null;
                    Int32.Parse(SpeedTB.Text);
                    Time = new TimeSpan(Int32.Parse(HourTB.Text), Int32.Parse(MinutesTB.Text), Int32.Parse(SecondTB.Text));
                    rate = Int32.Parse(SpeedTB.Text);
                    timeInMin = (int)Time.TotalMinutes;
                    ReturnToMainWinButton.IsEnabled = false;

                }
                catch (FormatException)
                {
                    MessageBox.Show("Not all the filed Fill properly");
                    return;
                }
                catch (Exception)
                {

                    MessageBox.Show("Not all the filed Fill properly");
                    return;
                }

                HourTB.IsEnabled = false;
                MinutesTB.IsEnabled = false;
                SecondTB.IsEnabled = false;
                SpeedTB.Visibility = Visibility.Hidden;
                Commit.Visibility = Visibility.Hidden;
                TimeTextBlock.Visibility = Visibility.Hidden;
                speedTextBlock.Visibility = Visibility.Hidden;
                SimulationLV.Visibility = Visibility.Visible;
                StartStopB.Content = "Stop";
                StartStopB.Background = Brushes.Red;
                fillsimolatorItems();
                SimulationLV.ItemsSource = simolatorItems;
                Worker.RunWorkerAsync(1);
            }
            else
            {
                StartStopB.Content = "Start";
                StartStopB.Background = Brushes.Green;
                HourTB.IsEnabled = true;
                MinutesTB.IsEnabled = true;
                SecondTB.IsEnabled = true;
                SimulationLV.Visibility = Visibility.Hidden;
                Commit.Visibility = Visibility.Visible;
                SpeedTB.Visibility = Visibility.Visible;
                TimeTextBlock.Visibility = Visibility.Visible;
                speedTextBlock.Visibility = Visibility.Visible;
                ReturnToMainWinButton.IsEnabled = true;
                if (Worker.IsBusy)
                    Worker.CancelAsync();
            }
        }

        //when you press start the simulator start to run the qlock start to get value and you can see the change in the arrive time to station 
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (Worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                Thread.Sleep(1000);
                Worker.ReportProgress(1);
                foreach (PO.PL_viewST item in simolatorItems)
                {
                    //check if its the time for use arraved
                    if (item.StartAt.Hours == Time.Hours || (item.StartAt.Hours < Time.Hours && item.StartAt.Hours > (Time - new TimeSpan(0, 0, rate)).Hours))
                        item.Pass = true;
                    if (item.Pass)
                        updatePOVersion(item);
                }
            }
        }
        //Updates all lines currently in use in terms of time
        private void updatePOVersion(PO.PL_viewST Convert)
        {
            BO.BL_viewST help = new BO.BL_viewST();
            help.LineId = Convert.LineId;
            help.NextStation = Convert.NextStation;
            help.NextStationTime = Convert.NextStationTime;
            help.NowStation = Convert.NowStation;
            //func that use to update the value of the line in the simulation
            Bl.update_StartRoute_View(help, rate);

            Convert.NextStation = help.NextStation;
            Convert.NextStationTime = help.NextStationTime;
            Convert.NowStation = help.NowStation;
        }
        //update the qlock and the all line simulator line all the time that we have change and this happened
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            Action<TimeSpan> updateTime = UPDateQlock;
            Bl.StartSimulator(Time, rate, updateTime);
            Time += new TimeSpan(0, 0, rate);
            SimulationLV.Items.Refresh();
        }

        //if Cancelled
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("The Simulation Stopped");
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Problem");
                new SimulationWindow().Show();
                this.Close();
            }
        }
        //UPDateQlock
        public void UPDateQlock(TimeSpan time)
        {
            HourTB.Text = time.Hours.ToString();

            MinutesTB.Text = time.Minutes.ToString();

            SecondTB.Text = time.Seconds.ToString();
        }
        private void ReturnToMainWinButton_Click(object sender, RoutedEventArgs e)
        {
           // new SecondWindow().Show();
            this.Close();
        }
        //call for station simulation
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    new StationInfoSimulation(Bl, rate).Show();
        //}
    }
}

  //< Window.Resources >
  //      < local:ConverterFromTimeSpanToString x:Key = "Convertor" ></ local:ConverterFromTimeSpanToString >
     
  //       </ Window.Resources >
     
  //       < Grid >
     
  //           < TextBox Name = "TimeSimulation" FontSize = "20" Height = "50"  Text = "{Binding Path=StartTime,Converter={StaticResource ResourceKey=Convertor},Mode=OneWay,UpdateSourceTrigger=PropertyChanged}" HorizontalAlignment = "Left" VerticalAlignment = "Top" Width = "200"  Margin = "125,40,0,0" />
                    
  //                          < TextBox Name = "Rate" Margin = "63,40,0,0" FontSize = "20" VerticalAlignment = "Top" Width = "30" TextAlignment = "Center"  Text = "1" HorizontalAlignment = "Left" TextChanged = "input_cheke" RenderTransformOrigin = "0.764,1.615" ></ TextBox >
                                       
  //                                             < Button Content = "Start" Width = "50" Height = "30"  Margin = "0,0,400,350" VerticalAlignment = "Bottom" Background = "LightCyan" HorizontalAlignment = "Right" Name = "OnOffButton" Click = "OnOffButton_Click" RenderTransformOrigin = "-5.837,-9.271" />
                                                          

  //                                                            </ Grid >