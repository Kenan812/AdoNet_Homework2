using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_CreatingTables
{
    class Tables
    {
        private string _connectionString;

        public Tables(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region CREATING TABLES


        public void CreateStationariesTable()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            string query = @"CREATE TABLE Stationaries(
	                         Id INT IDENTITY(1,1) PRIMARY KEY,
	                         StationarieName NVARCHAR(150) NOT NULL UNIQUE,
	                         StationaryType INT FOREIGN KEY REFERENCES Types(Id), 
	                         Price INT DEFAULT(0),
	                         SoldProductNumber INT DEFAULT(0)
                         )";

            if (CheckTableExistance(query)) { Console.WriteLine("Table already exists"); return; }  // If table already exists

            using (connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                command.ExecuteNonQuery();

                Console.WriteLine("'Stationaries' table created");
            }
        }

        public void CreateTypesTable()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            string query = @"CREATE TABLE Types(
	                         Id INT IDENTITY(1,1) PRIMARY KEY,
	                         [TypeName] NVARCHAR(150) NOT NULL,
	                         UniqueStationaryCount INT DEFAULT(0)
                             )";

            if (CheckTableExistance(query)) { Console.WriteLine("Table already exists"); return; }  // If table already exists

            using (connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                command.ExecuteNonQuery();

                Console.WriteLine("'Types' table created");
            }

        }

        public void CreateManagersTable()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            string query = @"CREATE TABLE Managers(
	                         Id INT IDENTITY(1,1) PRIMARY KEY,
	                         FirstName NVARCHAR(150) NOT NULL,
	                         LastName NVARCHAR(150) NOT NULL,
	                         Age INT NOT NULL
                             )";

            if (CheckTableExistance(query)) { Console.WriteLine("Table already exists"); return; }  // If table already exists

            using (connection)
            {
                connection.Open();
                
                SqlCommand command = new SqlCommand(query, connection);

                command.ExecuteNonQuery();

                Console.WriteLine("'Managers' table created");
            }
        }

        public void CreateSalesTable()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            string query = @"CREATE TABLE Sales(
	                         Id INT IDENTITY(1,1) PRIMARY KEY,
	                         CustomerFirmName NVARCHAR(MAX) NOT NULL,
	                         StationaryId INT FOREIGN KEY REFERENCES Stationaries(Id),
	                         ManagerId INT FOREIGN KEY REFERENCES Managers(Id),
	                         SaleDate DATE NOT NULL
                             )";

            if (CheckTableExistance(query)) { Console.WriteLine("Table already exists"); return; }  // If table already exists

            using (connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                command.ExecuteNonQuery();

                Console.WriteLine("'Sales' table created");
            }
        }


        // Returns 'true' if query creates existing table
        // Returns 'false' otherwise
        private bool CheckTableExistance(string query)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            string tableName = GetTableNameFromQuery(query);

            connection.Open();

            List<string> tableNames = new List<string>();
            DataTable dataTable = connection.GetSchema("Tables");

            foreach (DataRow row in dataTable.Rows)
            {
                string dbTableName = row[2].ToString();

                if (dbTableName == tableName) return true;  // Table already exists in DB

            }

            return false;
        }


        // Gets create table query
        // Returns table Name
        private string GetTableNameFromQuery(string query)
        {
            string tableName = String.Empty;

            for (int i = 13; i < query.Length; i++)
            {
                if (query[i] == ' ' || query[i] == '\n' || query[i] == '(')
                {
                    break;
                }

                tableName += query[i];
            }

            return tableName;
        }


        #endregion


        #region CREATING PROCEDURES

        public void CreateProcedures()
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            string query1 = @"CREATE PROC INSERT_TYPE
                             @typeName NVARCHAR(150)
                             AS 
                             BEGIN
	                             INSERT INTO [dbo].[Types] (TypeName)
	                             VALUES (@typeName)
                             END";

            string query2 = @"  CREATE PROC INSERT_STATIONARY
                                @StationaryName NVARCHAR(150),
                                @StationaryType INT,
                                @Price INT
                                AS 
                                BEGIN 
	                                INSERT INTO Stationaries ([StationarieName], [StationaryType], [Price])
	                                VALUES (@StationaryName, @StationaryType, @Price)

	                                UPDATE [Types]
	                                SET UniqueStationaryCount = UniqueStationaryCount + 1
	                                WHERE [Types].Id = @StationaryType
                                END";

            string query3 = @"CREATE PROC INSERT_MANAGER
                             @FirstName NVARCHAR(100),
                             @LastName NVARCHAR(100),
                             @Age INT
                             AS 
                             BEGIN 
	                             INSERT INTO Managers(FirstName, LastName, Age)
	                             VALUES (@FirstName, @LastName, @Age)
                             END";

            string query4 = @"CREATE PROC INSERT_SALE	
                             @CustomerFirmName NVARCHAR(MAX),
                             @StationaryId INT,
                             @ManagerId INT,
                             @SaleDate DATE,
                             @PurchaseCount INT
                             AS 
                             BEGIN
	                             INSERT INTO Sales (CustomerFirmName, StationaryId, ManagerId, SaleDate)
	                             VALUES (@CustomerFirmName, @StationaryId, @ManagerId, @SaleDate)
                       
	                             UPDATE Stationaries
	                             SET SoldProductNumber = SoldProductNumber + @PurchaseCount
	                             WHERE Stationaries.Id = @StationaryId
                             END";

            using (connection)
            {
                connection.Open();
                
                try
                {
                    SqlCommand command1 = new SqlCommand(query1, connection);
                    command1.ExecuteNonQuery();
                }
                catch (Exception) { Console.WriteLine("Procedure exists"); }

                try
                {
                    SqlCommand command2 = new SqlCommand(query2, connection);
                    command2.ExecuteNonQuery();
                }
                catch (Exception) { Console.WriteLine("Procedure exists"); }

                try
                {
                    SqlCommand command3 = new SqlCommand(query3, connection);
                    command3.ExecuteNonQuery();
                }
                catch (Exception) { Console.WriteLine("Procedure exists"); }

                try
                {
                    SqlCommand command4 = new SqlCommand(query4, connection);
                    command4.ExecuteNonQuery();
                }
                catch (Exception) { Console.WriteLine("Procedure exists"); }

            }
        }

        #endregion


        #region INSERTS

        public void InsertNewType(string typeName)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            string query = $"EXEC INSERT_TYPE \"{typeName}\"";

            using (connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                command.ExecuteNonQuery();
            }
        }


        public void InsertNewStationary(string stationaryName, int typeId, int price)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            string query = $"EXEC INSERT_STATIONARY \"{stationaryName}\", {typeId}, {price}";

            using (connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                command.ExecuteNonQuery();
            }
        }


        public void InsertNewManager(string firstName, string lastName, int age)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            string query = $"EXEC INSERT_MANAGER \"{firstName}\", \"{lastName}\", {age}";

            using (connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                command.ExecuteNonQuery();
            }
        }


        public void InsertNewSale(string customerFirmName, int stationaryId, int managerId, DateTime saleDate, int purchaseCount)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            string query = $"EXEC INSERT_SALE \"{customerFirmName}\", {stationaryId}, {managerId}, \"{saleDate.Year}/{saleDate.Month}/{saleDate.Day}\", {purchaseCount}";

            using (connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                command.ExecuteNonQuery();
            }
        }

        #endregion


    }
}
