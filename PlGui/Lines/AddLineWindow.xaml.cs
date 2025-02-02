﻿using System;
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

namespace PlGui
{
    /// <summary>
    /// Interaction logic for AddLineWindow.xaml
    /// </summary>
    public partial class AddLineWindow : Window
    {
        public DataTransferAddWindow dataTransferDelegate;
        public AddLineWindow(DataTransferAddWindow del)
        {
            InitializeComponent();
            dataTransferDelegate = del;
        }
        private void input_cheke(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch((sender as TextBox).Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                (sender as TextBox).Text = (sender as TextBox).Text.Remove((sender as TextBox).Text.Length - 1);
            }

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
             dataTransferDelegate?.Invoke(int.Parse(LineNumText.Text),ConvertArea(),int.Parse(CodeStation.Text) );
            this.Close();
        }
        private int ConvertArea()
        {
            //North, South, Central, Jerusalem, General.
            if (Area.SelectedItem  == Area.Items[0])
                return 0;
            else if (Area.SelectedItem == Area.Items[1]) return 1;
            else if (Area.SelectedItem == Area.Items[2]) return 2;
            else if (Area.SelectedItem == Area.Items[3]) return 3;
            return 4;
        }
    }
 }
