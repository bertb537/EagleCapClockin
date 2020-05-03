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

namespace TimeCardGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            TimeCardGUI.TimeCardDataSet timeCardDataSet = ((TimeCardGUI.TimeCardDataSet)(this.FindResource("timeCardDataSet")));
            // Load data into the table TimeCard. You can modify this code as needed.
            TimeCardGUI.TimeCardDataSetTableAdapters.TimeCardTableAdapter timeCardDataSetTimeCardTableAdapter = new TimeCardGUI.TimeCardDataSetTableAdapters.TimeCardTableAdapter();
            timeCardDataSetTimeCardTableAdapter.Fill(timeCardDataSet.TimeCard);
            System.Windows.Data.CollectionViewSource timeCardViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("timeCardViewSource")));
            timeCardViewSource.View.MoveCurrentToFirst();
        }
    }
}
