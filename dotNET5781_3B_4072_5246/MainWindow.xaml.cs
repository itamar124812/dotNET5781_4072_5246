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

namespace dotNET5781_3B_4072_5246
{
    using Bus = dotNET5781_01_4072_5426.bus;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DateTime a = new DateTime(2019,1,1);
            Upgraded_Bus A = new Upgraded_Bus("123-45-678",0,0,0,a,1);
            A.Make_a_trip(500);
            
           
            
        }
    }
}
