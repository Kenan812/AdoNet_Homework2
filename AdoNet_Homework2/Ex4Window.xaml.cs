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


        private void ex4_1Button_Click(object sender, RoutedEventArgs e)
        {
            if (ex4_1TextBox.Text == String.Empty)
            {
                MessageBox.Show("Name not provided");
                return;
            }

            string typeName = ex4_1TextBox.Text;
            string query = @"SELECT StationarieName, Price, SoldProductNumber FROM Stationaries LEFT JOIN Types ON Types.Id = Stationaries.StationaryType WHERE Types.TypeName = '@typeName'";

            DataTable dataTable = new DataTable("StationeryFirm");
            SqlCommand command = new SqlCommand(query, _connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            SqlParameter parameter = new SqlParameter("@typeName", SqlDbType.NVarChar);
            parameter.Value = typeName;
            command.Parameters.Add(parameter);
            command.ExecuteNonQuery();

            adapter.Fill(dataTable);

            tableDataGrid.ItemsSource = dataTable.DefaultView;
            adapter.Update(dataTable);

        }
    }
}
