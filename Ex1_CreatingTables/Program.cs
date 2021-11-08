using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_CreatingTables
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LocalDB"].ConnectionString;

            Tables tablesCreating = new Tables(connectionString);

            tablesCreating.CreateTypesTable();
            tablesCreating.CreateStationariesTable();
            tablesCreating.CreateManagersTable();
            tablesCreating.CreateSalesTable();

            tablesCreating.CreateProcedures();

            InsertTypes(tablesCreating);
            InsertStationaries(tablesCreating);
            InsertManagers(tablesCreating);
            InsertSales(tablesCreating);
        }

        public static void InsertTypes(Tables tables)
        {
            tables.InsertNewType("Writing Accessories");
            tables.InsertNewType("Paper Products");
            tables.InsertNewType("Goods For Paperwork");
            tables.InsertNewType("Documentation Storage Products");
            tables.InsertNewType("Goods For Creativity");

        }

        public static void InsertStationaries(Tables tables)
        {
            tables.InsertNewStationary("Pen", 1, 1);
            tables.InsertNewStationary("Puncher", 3, 4);
            tables.InsertNewStationary("Stapler", 3, 5);
            tables.InsertNewStationary("Folder", 4, 10);
            tables.InsertNewStationary("Portfolio", 4, 15);
            tables.InsertNewStationary("Document Case", 4, 20);
            tables.InsertNewStationary("Binder", 4, 2);
            tables.InsertNewStationary("Envelope", 4, 3);
            tables.InsertNewStationary("Cut Paper", 2, 1);
            tables.InsertNewStationary("Notebook", 2, 7);
            tables.InsertNewStationary("Plasticine", 5, 6);
            tables.InsertNewStationary("Paints", 5, 9);
            tables.InsertNewStationary("Colour Pencils", 1, 10);
            tables.InsertNewStationary("Paper", 2, 1);
            tables.InsertNewStationary("Paper Pile", 2, 50);
            tables.InsertNewStationary("Cardboard", 5, 2);
            tables.InsertNewStationary("Copybook", 2, 2);
            tables.InsertNewStationary("Gray Pencil", 1, 1);
        }

        public static void InsertManagers(Tables tables)
        {
            tables.InsertNewManager("Jane", "Foster", 30);
            tables.InsertNewManager("Henry", "Hall", 25);
            tables.InsertNewManager("John", "Crow", 45);
        }

        public static void InsertSales(Tables tables)
        {
            tables.InsertNewSale("Amazon", 1, 1, new DateTime(2020, 6, 6), 1000);
            tables.InsertNewSale("Amazon", 1, 1, new DateTime(2020, 6, 6), 1000);
            tables.InsertNewSale("Amazon", 2, 1, new DateTime(2020, 6, 6), 5000);
            tables.InsertNewSale("Amazon", 3, 1, new DateTime(2020, 6, 6), 5000);
            tables.InsertNewSale("Amazon", 4, 1, new DateTime(2020, 6, 6), 1000);
            tables.InsertNewSale("Amazon", 5, 1, new DateTime(2020, 6, 6), 2000);
            tables.InsertNewSale("Amazon", 6, 1, new DateTime(2020, 6, 6), 3000);
            tables.InsertNewSale("Amazon", 7, 1, new DateTime(2020, 6, 6), 4000);
            tables.InsertNewSale("Amazon", 8, 1, new DateTime(2020, 6, 6), 1000);
            tables.InsertNewSale("Amazon", 9, 1, new DateTime(2020, 6, 6), 15000);
            tables.InsertNewSale("Amazon", 10, 1, new DateTime(2020, 6, 6), 12000);
            tables.InsertNewSale("Amazon", 11, 1, new DateTime(2020, 6, 6), 10000);
            tables.InsertNewSale("Amazon", 12, 1, new DateTime(2020, 6, 6), 1000);
            tables.InsertNewSale("Amazon", 13, 1, new DateTime(2020, 6, 6), 7000);
            tables.InsertNewSale("Amazon", 14, 1, new DateTime(2020, 6, 6), 9000);
            tables.InsertNewSale("Amazon", 15, 1, new DateTime(2020, 6, 6), 8000);
            tables.InsertNewSale("Amazon", 16, 1, new DateTime(2020, 6, 6), 3000);
            tables.InsertNewSale("Amazon", 17, 1, new DateTime(2020, 6, 6), 25000);
            tables.InsertNewSale("Amazon", 18, 1, new DateTime(2020, 6, 6), 12500);
            tables.InsertNewSale("Space-X", 1, 2, new DateTime(2021, 7, 20), 1000);
            tables.InsertNewSale("Space-X", 3, 2, new DateTime(2021, 7, 20), 900);
            tables.InsertNewSale("Space-X", 6, 2, new DateTime(2021, 7, 20), 300);
            tables.InsertNewSale("Space-X", 10, 2, new DateTime(2021, 7, 20), 500);
            tables.InsertNewSale("Space-X", 11, 2, new DateTime(2021, 7, 20), 400);
            tables.InsertNewSale("Space-X", 12, 2, new DateTime(2021, 7, 20), 1000);
            tables.InsertNewSale("Space-X", 4, 2, new DateTime(2021, 7, 20), 1100);
            tables.InsertNewSale("Space-X", 7, 2, new DateTime(2021, 7, 20), 170);
            tables.InsertNewSale("Facebook", 1, 3, new DateTime(2020, 12, 15), 550);
            tables.InsertNewSale("Facebook", 13, 3, new DateTime(2020, 12, 15), 300);
            tables.InsertNewSale("Facebook", 5, 3, new DateTime(2020, 12, 15), 250);
            tables.InsertNewSale("Facebook", 2, 3, new DateTime(2020, 12, 15), 50);
            tables.InsertNewSale("Facebook", 7, 3, new DateTime(2020, 12, 15), 500);
            tables.InsertNewSale("Facebook", 8, 3, new DateTime(2020, 12, 15), 1000);

        }

    }
}
