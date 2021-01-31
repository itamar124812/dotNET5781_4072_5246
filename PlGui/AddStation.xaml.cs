using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace PlGui
{
    /// <summary>
    /// Interaction logic for AddStation.xaml
    /// </summary>
    public partial class AddStationToLineWindow : Window
    {
        
        BlApi.IBl bL;
        public AddStationToLineWindow(BlApi.IBl bl)
        {
            InitializeComponent();
            if (MessageBox.Show("If the station you want to add is a new station click כן If it already exists click לא.", "Add Station", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                throw new NotImplementedException(); //this.Close();
            }
            LineChice.DataContext = bl.GetsAllLines();
            bL = bl;
        }

        private void Text_Input(object sender,TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch((sender as TextBox).Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                (sender as System.Windows.Controls.TextBox).Text = (sender as TextBox).Text.Remove((sender as TextBox).Text.Length - 1);
            }
        }

        private void LineChice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Index.Items.Clear();
            int i = 0;
            foreach (var item in (((sender as ComboBox).SelectedItem as Bl.BO.LineBus).PassingThrough))
            {
                Index.Items.Add(i);
                ++i;
            }
            Index.Items.Add(i);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (bL.ExistsStation(int.Parse(StationNum.Text)))
            {
                bL.AddStationToLine((LineChice.SelectedItem as Bl.BO.LineBus).Id, int.Parse(StationNum.Text), int.Parse(Index.SelectedItem.ToString()), 0, TimeSpan.Zero);
                this.Close();
            }
            else MessageBox.Show("The station number: "+ StationNum.Text+ " does not exists.");
        }
    }
}
