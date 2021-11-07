using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace AdoNet_Homework2
{
    /// <summary>
    /// Interaction logic for Ex3Window.xaml
    /// </summary>
    public partial class Ex3Window : Window
    {
        private SqlConnection _connection;

        public Ex3Window(SqlConnection connection)
        {
            InitializeComponent();
            _connection = connection;
            _connection.Open();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _connection.Close();
        }


        // Lets execute the query
        private void ExecuteQuery(string query)
        {
            SqlCommand command = new SqlCommand(query, _connection);

            command.ExecuteNonQuery();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable("StationeryFirm");
            dataAdapter.Fill(dataTable);
            tableDataGrid.ItemsSource = dataTable.DefaultView;
            dataAdapter.Update(dataTable);
        }



        private void ex3_1Button_Click(object sender, RoutedEventArgs e)
        {
            string query = @"SELECT Stationaries.Id, Stationaries.StationarieName, Stationaries.Price, Stationaries.SoldProductNumber, Types.TypeName
                               FROM Stationaries 
                               LEFT JOIN [Types] ON Stationaries.StationaryType = Types.Id";

            ExecuteQuery(query);
        }

        private void ex3_2Button_Click(object sender, RoutedEventArgs e)
        {
            string query = @"SELECT * FROM Types";

            ExecuteQuery(query);
        }

        private void ex3_3Button_Click(object sender, RoutedEventArgs e)
        {
            string query = @"SELECT * FROM Managers";

            ExecuteQuery(query);
        }

        private void ex3_4Button_Click(object sender, RoutedEventArgs e)
        {
            string query = @"SELECT DISTINCT Stationaries.StationarieName AS 'Max stationary number'
                               FROM Stationaries
                               WHERE Stationaries.SoldProductNumber = 
                               (
	                               SELECT MAX(Stationaries.SoldProductNumber)
	                               FROM Stationaries
                               )";

            ExecuteQuery(query);
        }

        private void ex3_5Button_Click(object sender, RoutedEventArgs e)
        {
            string query = @"SELECT DISTINCT Stationaries.StationarieName AS 'Min stationary number'
                               FROM Stationaries
                               WHERE Stationaries.SoldProductNumber = 
                               (
	                               SELECT MIN(Stationaries.SoldProductNumber)
	                               FROM Stationaries
                               )";

            ExecuteQuery(query);
        }

        private void ex3_6Button_Click(object sender, RoutedEventArgs e)
        {
            string query = @"SELECT DISTINCT Stationaries.StationarieName
                             FROM Stationaries
                             WHERE Stationaries.Price = 
                             (
	                             SELECT MAX(Stationaries.Price)
	                             FROM Stationaries
                             )";

            ExecuteQuery(query);
        }

        private void ex3_7Button_Click(object sender, RoutedEventArgs e)
        {
            string query = @"SELECT DISTINCT Stationaries.StationarieName
                             FROM Stationaries
                             WHERE Stationaries.Price = 
                             (
	                             SELECT MIN(Stationaries.Price)
	                             FROM Stationaries
                             )";

            ExecuteQuery(query);
        }



    }
}
