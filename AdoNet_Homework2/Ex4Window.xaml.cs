using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace AdoNet_Homework2
{
    /// <summary>
    /// Interaction logic for Ex4Window.xaml
    /// </summary>
    public partial class Ex4Window : Window
    {
        private SqlConnection _connection;

        public Ex4Window(SqlConnection connection)
        {
            InitializeComponent();
            _connection = connection;
            _connection.Open();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _connection.Close();
        }


        private void ex4_1Button_Click(object sender, RoutedEventArgs e)
        {
            if (ex4_1TextBox.Text == String.Empty)
            {
                MessageBox.Show("Name not provided");
                return;
            }

            string typeName = ex4_1TextBox.Text;
            string query = @"SELECT StationarieName, Price, SoldProductNumber FROM Stationaries LEFT JOIN Types ON Types.Id = Stationaries.StationaryType WHERE Types.TypeName = @TypeName";

            DataTable dataTable = new DataTable("StationeryFirm");
            SqlCommand command = new SqlCommand(query, _connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            command.Parameters.AddWithValue("@TypeName", typeName);

            command.ExecuteNonQuery();

            adapter.Fill(dataTable);

            tableDataGrid.ItemsSource = dataTable.DefaultView;
            adapter.Update(dataTable);
        }

        private void ex4_2Button_Click(object sender, RoutedEventArgs e)
        {
            if (ex4_2firstNameTextBox.Text == String.Empty && ex4_2lastNameTextBox.Text == String.Empty)
            {
                MessageBox.Show("First name or slst name not provided");
                return;
            }

            string firstName = ex4_2firstNameTextBox.Text;
            string lastName = ex4_2lastNameTextBox.Text;

            string query = @"SELECT Stationaries.StationarieName, Types.TypeName, Stationaries.Price, Stationaries.SoldProductNumber FROM Stationaries
                             LEFT JOIN Sales ON Sales.StationaryId = Stationaries.Id
                             LEFT JOIN Managers ON Managers.Id = Sales.ManagerId
                             LEFT JOIN Types ON Types.Id = Stationaries.StationaryType
                             WHERE Managers.FirstName = @FirstName AND Managers.LastName = @LastName";

            DataTable dataTable = new DataTable("StationeryFirm");
            SqlCommand command = new SqlCommand(query, _connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@LastName", lastName);

            command.ExecuteNonQuery();

            adapter.Fill(dataTable);

            tableDataGrid.ItemsSource = dataTable.DefaultView;
            adapter.Update(dataTable);
        }

        private void ex4_3Button_Click(object sender, RoutedEventArgs e)
        {
            if (ex4_3TextBox.Text == String.Empty)
            {
                MessageBox.Show("First name or last name not provided");
                return;
            }

            string firmName = ex4_3TextBox.Text;

            string query = @"SELECT Stationaries.StationarieName, Types.TypeName, Stationaries.Price, Stationaries.SoldProductNumber FROM Stationaries
                             LEFT JOIN Sales ON Sales.StationaryId = Stationaries.Id
                             LEFT JOIN Managers ON Managers.Id = Sales.ManagerId
                             LEFT JOIN Types ON Types.Id = Stationaries.StationaryType
                             WHERE Sales.CustomerFirmName = @FirmName";

            DataTable dataTable = new DataTable("StationeryFirm");
            SqlCommand command = new SqlCommand(query, _connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            command.Parameters.AddWithValue("@FirmName", firmName);

            command.ExecuteNonQuery();

            adapter.Fill(dataTable);

            tableDataGrid.ItemsSource = dataTable.DefaultView;
            adapter.Update(dataTable);
        }

        private void ex4_4Button_Click(object sender, RoutedEventArgs e)
        {
            string query = @"SELECT Sales.Id, Sales.CustomerFirmName, Sales.StationaryId, Sales.ManagerId FROM Sales
                             WHERE DATEDIFF(DAY, Sales.SaleDate, GETDATE()) = (
	                             SELECT MIN(DATEDIFF(DAY, Sales.SaleDate, GETDATE())) FROM Sales)";

            SqlCommand command = new SqlCommand(query, _connection);

            command.ExecuteNonQuery();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable("StationeryFirm");
            dataAdapter.Fill(dataTable);
            tableDataGrid.ItemsSource = dataTable.DefaultView;
            dataAdapter.Update(dataTable);
        }

        private void ex4_5Button_Click(object sender, RoutedEventArgs e)
        {
            string query = @"SELECT Types.TypeName, AVG(Stationaries.SoldProductNumber) AS 'Average sold product number'
	                         FROM Stationaries
	                         LEFT JOIN Types ON Types.Id = Stationaries.StationaryType
	                         GROUP BY Types.TypeName";

            SqlCommand command = new SqlCommand(query, _connection);

            command.ExecuteNonQuery();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable("StationeryFirm");
            dataAdapter.Fill(dataTable);
            tableDataGrid.ItemsSource = dataTable.DefaultView;
            dataAdapter.Update(dataTable);
        }
    }
}
