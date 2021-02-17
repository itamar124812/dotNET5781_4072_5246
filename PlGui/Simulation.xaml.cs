﻿using System;
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
    /// <summary>
    /// Interaction logic for Simulation.xaml
    /// </summary>
    public partial class Simulation : Window,INotifyPropertyChanged
    {
        public bool StartOrStop = true;
        private BackgroundWorker worker = new BackgroundWorker();
        IBl bl = BlFactory.GetBl();
        TimeSpan StartTime;
        int rate = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public Simulation()
        {
            InitializeComponent();
            worker.DoWork += Worker_DoWork;         
            TimeSimulation.DataContext = StartTime;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {                                
            bl.StartSimulator(StartTime, rate, T => { T += TimeSpan.FromSeconds(rate);PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StartTime")); });
            StartOrStop = false;
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
                TimeSimulation.IsReadOnly = true;
                TimeSpan.TryParse(TimeSimulation.Text, out StartTime);
                rate = int.Parse(Rate.Text);
                worker.RunWorkerAsync();              
            }
            else
            {
                bl.StopSimulator();
                Rate.IsReadOnly = false;
                TimeSimulation.IsReadOnly = false;
                OnOffButton.Content = "Start";
                StartOrStop = true;



                
            }
        }
    }
}