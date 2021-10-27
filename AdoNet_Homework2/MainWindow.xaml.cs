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
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;

namespace AdoNet_Homework2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isConnected;
        private string _connectionString;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void connectButton_Click(object sender, RoutedEventArgs e)
        {
            _isConnected = true;
            _connectionString = ConfigurationManager.ConnectionStrings["LocalDB"].ConnectionString;
        }

        private void disconnectButton_Click(object sender, RoutedEventArgs e)
        {
            _isConnected = false;
            _connectionString = String.Empty;
        }

        private void Ex3button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Ex4button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void homeWorkButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
