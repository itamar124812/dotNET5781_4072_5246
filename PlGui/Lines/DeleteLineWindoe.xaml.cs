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

namespace PlGui
{
    /// <summary>
    /// Interaction logic for DeleteLineWindoe.xaml
    /// </summary>
    public partial class DeleteLineWindoe : Window
    {
        public DataTransferDeleteWindoe dataTransfer;
        private bool okey = false;
        public DeleteLineWindoe(DataTransferDeleteWindoe dataTransferDeleteWindoe)
        {
            InitializeComponent();
            this.Closed += DeleteLineWindoe_Closed;
            dataTransfer = dataTransferDeleteWindoe;
        }

        private void DeleteLineWindoe_Closed(object sender, EventArgs e)
        {
            if (okey)
            { 
                dataTransfer?.Invoke(int.Parse(LineNum.Text)); 
            }
            else dataTransfer?.Invoke(0);
        }

        private void LineNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch((sender as TextBox).Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                (sender as TextBox).Text = (sender as TextBox).Text.Remove((sender as TextBox).Text.Length - 1);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            okey = false;
            this.Close();
        }

        private void OkeyDelete_Click(object sender, RoutedEventArgs e)
        {
            okey = true;
            this.Close();
        }
    }
}
