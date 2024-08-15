using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using master_pages_try2.app_logic;
namespace master_pages_try2
{
    public partial class StockWithDb : System.Web.UI.Page
    {
        public static SqlConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {


            //only on the first load
            if (!IsPostBack)
            {

                try
                {

                    Debug.WriteLine("Initial db.");

                    string connectionString2 = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master-page-try;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                    con = new SqlConnection(connectionString2);
                    con.Open();

                    string[] data = GetData();

                    dbData.Text = "num= " + data[0] + "| Word = " + data[1];

                    CreateInitTables();


                    User user1 = new User("yim222", "1234abcd", "yim@gmail.com", "this is some user1");
                    User user2 = new User("lingar", "1234567", "agaf@gmail.com", "My second user");

                    UserDao.AddUser(user1);
                    UserDao.AddUser(user2);
                    con.Close();
                }
                catch (SqlException  ex)
                {
                    Debug.WriteLine("error here:\n" + ex.Message);
                    Debug.WriteLine("SQL Error Number: " + ex.Number);
                    Debug.WriteLine("SQL Error Message: " + ex.Message);
                    Debug.WriteLine("SQL Error StackTrace: " + ex.StackTrace);

                }


            }

        }

        public static string[] GetData()
        {
            ////assuming that connection is open

            //SqlCommand command2 = new SqlCommand("SELECT * FROM Cars;",con);
            string query = "SELECT * FROM POC;";
            SqlCommand command = new SqlCommand(query, con);


            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string[] data = { reader.GetInt32(0) + "", reader.GetString(1) };


            //if (reader.HasRows)
            //{
            //    while (reader.Read())
            //    {
            //        Console.WriteLine("{0}\t{1}", reader.GetInt32(0),
            //            reader.GetString(1));
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("No rows found.");
            //}
            reader.Close();

            return data;
        }

        //trying this:
        //https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/dataset-datatable-dataview/creating-a-datatable
        public static void CreateInitTablesOlD()
        {
            DataTable workTable = new DataTable("Users");
            DataSet customers = new DataSet();

            DataTable userTables = customers.Tables.Add("users_table");
            DataColumn dataColumn = new DataColumn();
            dataColumn.ColumnName = "username";
            dataColumn.DataType = typeof(string);
            dataColumn.Unique = true;


            userTables.Columns.Add(dataColumn);
            userTables.Columns.Add("password", typeof(string), "");

            userTables.Columns.Add("male", typeof(bool), "");

            //insert 
            //https://learn.microsoft.com/en-us/visualstudio/data-tools/insert-new-records-into-a-database?view=vs-2022&tabs=csharp

        }

        //assuming connection is open
        public static void CreateInitTables()
        {
            //string query = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Cars' AND xtype='U')\r\nCREATE TABLE Cars (\r\n    CarID INT PRIMARY KEY,\r\n    CarName NVARCHAR(50),\r\n    CarBrand NVARCHAR(50)\r\n);"

           

                string query = @"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='users' AND xtype='U')
                    CREATE TABLE users (
                    username Varchar(50) PRIMARY KEY,
                    email NVARCHAR(50) NOT NULL UNIQUE,
                    password NVARCHAR(50) NOT NULL,
                    comment nvarchar(500) 
                );";

            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();

        }
    }
}