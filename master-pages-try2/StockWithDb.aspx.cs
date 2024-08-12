using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                string connectionString2 = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master-page-try;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                con = new SqlConnection(connectionString2);
                con.Open();
                
                string[] data = GetData();

                dbData.Text = "num= " + data[0] + "| Word = " + data[1];
                con.Close();

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

        public static void CreateInitTables()
        {

        }
    }
}