using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using master_pages_try2.app_logic;
namespace master_pages_try2
{
    public partial class StockWithDb : System.Web.UI.Page
    {
        public static SqlConnection con = new SqlConnection(connectionString2);
        public static string connectionString2 = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master-page-try;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
        public static User[] users = null;
        protected void Page_Load(object sender, EventArgs e)
        {


            //only on the first load
            if (!IsPostBack)
            {

                try
                {

                    Debug.WriteLine("Initial db.");


                    string[] data = GetData();

                    dbData.Text = "num= " + data[0] + "| Word = " + data[1];

                    UserDao.CreateInitTables();

                    users = UserDao.GetUsers();
                    Debug.WriteLine("Updating users = " + string.Join("\n", (object[])users));

                    DisplayUsers();


                }
                catch (SqlException ex)
                {
                    Debug.WriteLine("error here:\n" + ex.Message);
                    Debug.WriteLine("SQL Error Number: " + ex.Number);
                    Debug.WriteLine("SQL Error Message: " + ex.Message);
                    Debug.WriteLine("SQL Error StackTrace: " + ex.StackTrace);

                }




            }
            //general area
            try
            {
              


            }
            catch (SqlException ex)
            {
                Debug.WriteLine("error here:\n" + ex.Message);
                Debug.WriteLine("SQL Error Number: " + ex.Number);
                Debug.WriteLine("SQL Error Message: " + ex.Message);
                Debug.WriteLine("SQL Error StackTrace: " + ex.StackTrace);
            }
        }


        protected void AddNewUser(object sender, EventArgs e)
        {
            // Retrieve values from TextBox controls
            string username = OfUserName.Text;
            string password = OfPassword.Text;
            string email = OfEmail.Text;
            string comment = OfComment.Text;
            Debug.WriteLine("Add new User code behind");

            //validation:
            if(UserDao.IsExist("username", username))
            {
                ErrorMsg.Text = "username exists, no duplicates...";
                ErrorMsg.Style.Add("Color", "red");
                //todo - why it's needed (if we don't call it - the list will be empty) 
                DisplayUsers();
                return;

            }
            if (UserDao.IsExist("email", email))
            {
                ErrorMsg.Text = "email exists, no duplicates...";
                ErrorMsg.Style.Add("Color", "red");
                DisplayUsers();

                return;
            }

            //creating new user
            User user = new User(username, password, email, comment);   

            //adding to the db
            User success = UserDao.AddUser(user);
            Debug.WriteLine("User added = " + success);

            ResetTextBoxes(this);

            users = UserDao.GetUsers();
            //Debug.WriteLine("Updating users = " + string.Join("\n", (object[])users));
            ErrorMsg.Text = "User has been added";
            ErrorMsg.Style.Add("Color", "green");

            DisplayUsers();
        }
        public static string[] GetData()
        {
            ////assuming that connection is open

            //SqlCommand command2 = new SqlCommand("SELECT * FROM Cars;",con);
            string query = "SELECT * FROM POC;";
            con = new SqlConnection(connectionString2);
            con.Open();
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
            con.Close();
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

        protected void ResetTextBoxes(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Text = string.Empty;
                }
                else if (ctrl.HasControls())
                {
                    ResetTextBoxes(ctrl); // Recursive call for nested controls
                }
            }
        }

        private void DisplayUsers()
        {
            Debug.WriteLine("Dislay users.. ");
            //UsersTable.Rows.Clear(); 
            foreach (var user in users)
            {
                TableRow row = new TableRow();
                row.Cells.Add(new TableCell { Text = user.UserName });
                row.Cells.Add(new TableCell { Text = user.Email });
                row.Cells.Add(new TableCell { Text = user.Password});
                row.Cells.Add(new TableCell { Text = user.Comment });
                UsersTable.Rows.Add(row);
            }

        }

    }
}