using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFChartControlExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        MainViewModel mvm;
        public MainWindow()
        {
            InitializeComponent();

            mvm = new MainViewModel();
            DataContext = mvm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mvm.LineSeriesChartDrawer.Legend[0].LineColor = Colors.Green;

            System.Threading.Tasks.Task.Factory.StartNew(() =>
                mvm.LineSeriesChartDrawer.Legend[0].Name = DateTime.Now.ToString()
                );


        }
    }
}
