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
        public Window2()
        {
            InitializeComponent();
            StartDate.Text = CurrentBus.Dateofstart.ToString(string.Format("00/00/0000"));
        }
    }
}
