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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Upgraded_Bus CurrentBus;
        public Window2(Upgraded_Bus A)
        {
            InitializeComponent();
            CurrentBus = A;
            StartDate.DataContext = CurrentBus;
            mailage.DataContext = CurrentBus;
            Status.DataContext = CurrentBus;
            Delek.DataContext = CurrentBus;
            fromLasttreatment.DataContext = CurrentBus;
            treatmentKM.DataContext = CurrentBus;
        }
        private void uploadtext(object sender, RoutedEventArgs e)
        {
           int a =(int) (sender as TextBlock).Tag;
            string result;
            if (a == 0)
                result = Bus_status.ready_for_travel.ToString();
            else if (a== 1)
                result = Bus_status.on_the_road.ToString();
            else if (a == 2)
            {
                result = Bus_status.refueling.ToString();
            }
            else result = Bus_status.in_treatment.ToString();
            (sender as TextBlock).Text = result;

        }

        private void UploadtextDelek(object sender, RoutedEventArgs e)
        {
            int result = 1200- (int)(sender as TextBlock).Tag;
            Delek.Text = result.ToString();
        }

        private void treatmentKM_textload(object sender, RoutedEventArgs e)
        {
            int result = 20000 - (int)(sender as TextBlock).Tag;
            treatmentKM.Text = result.ToString();
        }

        private void RefullButton_click(object sender, RoutedEventArgs e)
        {
            CurrentBus.Make_a_refull();
        }
        private void TreatmentButton_click(object sender, RoutedEventArgs e)
        {
                CurrentBus.Make_a_treatment();
        }
    }
}
