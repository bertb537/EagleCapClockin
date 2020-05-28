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
        public TimeCardInterface timeCard;
<<<<<<< HEAD
<<<<<<< HEAD
        public TimeCardGUI.TimeCardDataSet timeCardDataSet;

=======
>>>>>>> parent of 8d0f7f8... Depency and Organization issues solved. TimeCard class is now housed in GUI project; TimeCardData project removed
=======
>>>>>>> parent of 8d0f7f8... Depency and Organization issues solved. TimeCard class is now housed in GUI project; TimeCardData project removed
        public MainWindow()
        {
            TimeCardGUI.TimeCardDataSet timeCardDataSet = ((TimeCardGUI.TimeCardDataSet)(this.FindResource("timeCardDataSet")));
            timeCard = new TimeCardInterface(timeCardDataSet.TimeCard);
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
<<<<<<< HEAD
<<<<<<< HEAD
            timeCard = new TimeCardInterface(timeCardDataSet.TimeCard);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if(UserState == Clocked.IN)
            //{
            //    timeCard.ClockIn();
            //    timeCard.GetTime()
            //}
=======
>>>>>>> parent of 8d0f7f8... Depency and Organization issues solved. TimeCard class is now housed in GUI project; TimeCardData project removed
=======
>>>>>>> parent of 8d0f7f8... Depency and Organization issues solved. TimeCard class is now housed in GUI project; TimeCardData project removed
        }
    }
}
