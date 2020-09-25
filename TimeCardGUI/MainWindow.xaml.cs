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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace TimeCardGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public TimeCardInterface timeCard;
        public TimeCardGUI.TimeCardDataSet timeCardDataSet;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timeCardDataSet = ((TimeCardGUI.TimeCardDataSet)(this.FindResource("timeCardDataSet")));
            // Load data into the table TimeCard. You can modify this code as needed.
            TimeCardGUI.TimeCardDataSetTableAdapters.TimeCardTableAdapter timeCardDataSetTimeCardTableAdapter = new TimeCardGUI.TimeCardDataSetTableAdapters.TimeCardTableAdapter();
            timeCardDataSetTimeCardTableAdapter.Fill(timeCardDataSet.TimeCard);
            System.Windows.Data.CollectionViewSource timeCardViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("timeCardViewSource")));
            timeCardViewSource.View.MoveCurrentToFirst();
            timeCard = new TimeCardInterface();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(timeCard.UserState == TimeCardInterface.Clocked.OUT)
            {
                UserLoginTextBox.Text = "ClockingIn";
                timeCard.ClockIn();
                CardPunchBtn.Content = "Clock-Out";
                UserLoginTextBox.Text = "ClockedIn";
            }
            else if(timeCard.UserState == TimeCardInterface.Clocked.IN)
            {
                UserLoginTextBox.Text = "ClockingOut";
                timeCard.ClockOut();
                // Get Description From User
                //timeCard.SetDescription(STRING);
                CardPunchBtn.Content = "Clock-In";
                UserLoginTextBox.Text = "ClockedOut";
            }
        }
    }
}
