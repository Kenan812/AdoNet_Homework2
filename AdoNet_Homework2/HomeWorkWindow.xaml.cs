using System;
using System.Collections.Generic;
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
using System.Data;

namespace AdoNet_Homework2
{
    /// <summary>
    /// Interaction logic for HomeWorkWindow.xaml
    /// </summary>
    public partial class HomeWorkWindow : Window
    {
        private SqlConnection _connection;
        private bool _deletetingItem = false;
        private bool _insertingItem = false;

        private bool _updateStationary = false;
        private bool _updateType = false;
        private bool _updateSales = false;
        private bool _updateManager = false;


        public HomeWorkWindow(SqlConnection connection)
        {
            InitializeComponent();
            _connection = connection;
            _connection.Open();
        }

        private void stationaryButton_Click(object sender, RoutedEventArgs e)
        {
            if (_insertingItem)
            {
                label1.Content = "Stationary Name";
                label2.Content = "Stationary Type Id";
                label3.Content = "Price";
                label4.Content = "N/A";
                label5.Content = "N/A";

                textBox1.IsEnabled = true;
                textBox2.IsEnabled = true;
                textBox3.IsEnabled = true;
                textBox4.IsEnabled = false;
                textBox5.IsEnabled = false;

                textBox4.Text = String.Empty;
                textBox5.Text = String.Empty;
            }

            updateButton.IsEnabled = true;

            _updateStationary = true;
            _updateType = false;
            _updateSales = false;
            _updateManager = false;
        }

        private void managerButton_Click(object sender, RoutedEventArgs e)
        {
            if (_insertingItem)
            {
                label1.Content = "First Name";
                label2.Content = "Last Name";
                label3.Content = "Age";
                label4.Content = "N/A";
                label5.Content = "N/A";

                textBox1.IsEnabled = true;
                textBox2.IsEnabled = true;
                textBox3.IsEnabled = true;
                textBox4.IsEnabled = false;
                textBox5.IsEnabled = false;

                textBox4.Text = String.Empty;
                textBox5.Text = String.Empty;
               

            }

            updateButton.IsEnabled = true;

            _updateManager = true;
            _updateStationary = false;
            _updateSales = false;
            _updateType = false;

        }

        private void salesButton_Click(object sender, RoutedEventArgs e)
        {
            if (_insertingItem)
            {
                label1.Content = "Customer Firm Name";
                label2.Content = "Stationary Id";
                label3.Content = "Manager Id";
                label4.Content = "Sale Date(yyyy/mm/dd)";
                label5.Content = "Purchase Count";

                textBox1.IsEnabled = true;
                textBox2.IsEnabled = true;
                textBox3.IsEnabled = true;
                textBox4.IsEnabled = true;
                textBox5.IsEnabled = true;

            }

            updateButton.IsEnabled = true;

            _updateSales = true;
            _updateStationary = false;
            _updateManager = false;
            _updateType = false;
        }

        private void typeButton_Click(object sender, RoutedEventArgs e)
        {
            if (_insertingItem)
            {
                label1.Content = "Type Name";
                label2.Content = "N/A";
                label3.Content = "N/A";
                label4.Content = "N/A";
                label5.Content = "N/A";

                textBox1.IsEnabled = true;
                textBox2.IsEnabled = false;
                textBox3.IsEnabled = false;
                textBox4.IsEnabled = false;
                textBox5.IsEnabled = false;

                textBox2.Text = String.Empty;
                textBox3.Text = String.Empty;
                textBox4.Text = String.Empty;
                textBox5.Text = String.Empty;
            }

            updateButton.IsEnabled = true;

            _updateType = true;
            _updateStationary = false;
            _updateSales = false;
            _updateManager = false;
        }

        private void insertNewItemButton_Click(object sender, RoutedEventArgs e)
        {
            stationaryButton.IsEnabled = true;
            typeButton.IsEnabled = true;
            salesButton.IsEnabled = true;
            managerButton.IsEnabled = true;

            _insertingItem = true;
            _deletetingItem = false;
        }

        private void deleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            stationaryButton.IsEnabled = true;
            typeButton.IsEnabled = true;
            salesButton.IsEnabled = true;
            managerButton.IsEnabled = true;

            _deletetingItem = true;
            _insertingItem = false;
            updateButton.IsEnabled = true;

            label1.Content = "Id";
            label2.Content = "N/A";
            label3.Content = "N/A";
            label4.Content = "N/A";
            label5.Content = "N/A";

            textBox1.IsEnabled = true;
            textBox2.IsEnabled = false;
            textBox3.IsEnabled = false;
            textBox4.IsEnabled = false;
            textBox5.IsEnabled = false;

            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;
        }


        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (_insertingItem)
            {

                if (_updateType == true)
                {
                    if (textBox1.Text == String.Empty) { MessageBox.Show("Invalid Input"); return; }

                    UpdateType();
                }
                else if (_updateManager == true)
                {
                    if (textBox1.Text == String.Empty || textBox2.Text == String.Empty || textBox3.Text == String.Empty)
                    { MessageBox.Show("Invalid Input"); return; }

                    UpdateManager();
                }

                else if (_updateStationary == true)
                {
                    if (textBox1.Text == String.Empty || textBox2.Text == String.Empty || textBox3.Text == String.Empty)
                    { MessageBox.Show("Invalid Input"); return; }

                    UpdateStationary();
                }

                else if (_updateSales == true)
                {
                    if (textBox1.Text == String.Empty || textBox2.Text == String.Empty || textBox3.Text == String.Empty
                        || textBox4.Text == String.Empty || textBox5.Text == String.Empty)
                    { MessageBox.Show("Invalid Input"); return; }

                    UpdateSales();
                }
            }

            else if (_deletetingItem)
            {
                if (_updateType == true)
                {
                    if (textBox1.Text == String.Empty) { MessageBox.Show("Invalid Input"); return; }

                    DeleteType();
                }
                else if (_updateManager == true)
                {
                    if (textBox1.Text == String.Empty) { MessageBox.Show("Invalid Input"); return; }

                    DeleteManager();
                }

                else if (_updateStationary == true)
                {
                    if (textBox1.Text == String.Empty) { MessageBox.Show("Invalid Input"); return; }

                    DeleteStationary();
                }

                else if (_updateSales == true)
                {
                    if (textBox1.Text == String.Empty) { MessageBox.Show("Invalid Input"); return; }

                    DeleteSale();
                }
            }
        }

        private void DeleteSale()
        {
            string id = textBox1.Text;
            string query = @"DELETE_SALES";

            SqlCommand command = new SqlCommand(query, _connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@id", SqlDbType.Int);
            p1.Value = id;

            command.Parameters.Add(p1);

            command.ExecuteNonQuery();

            MessageBox.Show($"Sale succesfully deleted", "Info", MessageBoxButton.OK);
        }


        private void DeleteStationary()
        {
            string id = textBox1.Text;
            string query = @"DELETE_STATIONARY";

            SqlCommand command = new SqlCommand(query, _connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@id", SqlDbType.Int);
            p1.Value = id;

            command.Parameters.Add(p1);

            command.ExecuteNonQuery();

            MessageBox.Show($"Stationary succesfully deleted", "Info", MessageBoxButton.OK);
        }


        private void DeleteManager()
        {
            string id = textBox1.Text;
            string query = @"DELETE_MANAGERS";

            SqlCommand command = new SqlCommand(query, _connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@id", SqlDbType.Int);
            p1.Value = id;

            command.Parameters.Add(p1);

            command.ExecuteNonQuery();

            MessageBox.Show($"Manager succesfully deleted", "Info", MessageBoxButton.OK);
        }

        private void DeleteType()
        {
            string id = textBox1.Text;
            string query = @"DELETE_TYPE";

            SqlCommand command = new SqlCommand(query, _connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@id", SqlDbType.Int);
            p1.Value = id;

            command.Parameters.Add(p1);

            command.ExecuteNonQuery();

            MessageBox.Show($"Type succesfully deleted", "Info", MessageBoxButton.OK);
        }


        private void UpdateSales()
        {
            string customerFirm = textBox1.Text;
            string stationaryId = textBox2.Text;
            string managerId = textBox3.Text;
            string salesDate = textBox4.Text;
            string PurchaseCount = textBox5.Text;

            string query = @"INSERT_SALE";

            SqlCommand command = new SqlCommand(query, _connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CustomerFirmName", customerFirm);
            command.Parameters.AddWithValue("@StationaryId", stationaryId);
            command.Parameters.AddWithValue("@ManagerId", managerId);
            command.Parameters.AddWithValue("@SaleDate", salesDate);
            command.Parameters.AddWithValue("@PurchaseCount", PurchaseCount);

            command.ExecuteNonQuery();

            MessageBox.Show($"Sale succesfully added", "Info", MessageBoxButton.OK);
        }


        private void UpdateStationary()
        {
            string name = textBox1.Text;
            string type = textBox2.Text;
            string price = textBox3.Text;
            string query = @"INSERT_STATIONARY";

            SqlCommand command = new SqlCommand(query, _connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@StationaryName", name);
            command.Parameters.AddWithValue("@StationaryType", type);
            command.Parameters.AddWithValue("@Price", price);

            command.ExecuteNonQuery();

            MessageBox.Show($"Stationary succesfully added", "Info", MessageBoxButton.OK);
        }


        private void UpdateManager()
        {
            string firstName = textBox1.Text;
            string LastName = textBox2.Text;
            string age = textBox3.Text;
            string query = @"INSERT_MANAGER";

            SqlCommand command = new SqlCommand(query, _connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@firstName", SqlDbType.NVarChar);
            SqlParameter p2 = new SqlParameter("@lastName", SqlDbType.NVarChar);
            SqlParameter p3 = new SqlParameter("@age", SqlDbType.Int);

            p1.Value = firstName;
            p2.Value = LastName;
            p3.Value = age;

            command.Parameters.Add(p1);
            command.Parameters.Add(p2);
            command.Parameters.Add(p3);

            command.ExecuteNonQuery();

            MessageBox.Show($"Manager succesfully added", "Info", MessageBoxButton.OK);
        }

        private void UpdateType()
        {
            string typeName = textBox1.Text;
            string query = @"INSERT_TYPE";

            SqlCommand command = new SqlCommand(query, _connection);
            command.CommandType =CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@typeName", SqlDbType.NVarChar);
            p1.Value = typeName;

            command.Parameters.Add(p1);

            command.ExecuteNonQuery();

            MessageBox.Show($"Type {typeName} succesfully added", "Info", MessageBoxButton.OK);
        }



        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _connection.Close();
        }

       
    }
}
