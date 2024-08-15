using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace master_pages_try2.app_logic
{
    public class UserDao
    {
        public static SqlConnection connection => _lazyConnection.Value;

        

        private static readonly Lazy<SqlConnection> _lazyConnection = new Lazy<SqlConnection>(() =>
        {
            string connectionString2 = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master-page-try;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
            return new SqlConnection(connectionString2);
        });

        public static User AddUser(User user)
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO users VALUES (@username, @password, @email ,@commentLingar)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@username", user.UserName);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@commentLingar", user.Comment);
                int rowsAffected = command.ExecuteNonQuery();
                Debug.WriteLine($"Rows inserted: {rowsAffected}"); Debug.WriteLine("Initial db.");
                return user;
            }
            catch (SqlException ex)
            {
                

                Debug.WriteLine("error here:\n" + ex.Message);
                Debug.WriteLine("SQL Error Number: " + ex.Number);
                Debug.WriteLine("SQL Error Message: " + ex.Message);
                Debug.WriteLine("SQL Error StackTrace: " + ex.StackTrace);
                return null;
            }
            finally
            {
                connection.Close();

            }

        }
        //assuming connection is open
        public static void CreateInitTables()
        {
            connection.Open();
            //string query = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Cars' AND xtype='U')\r\nCREATE TABLE Cars (\r\n    CarID INT PRIMARY KEY,\r\n    CarName NVARCHAR(50),\r\n    CarBrand NVARCHAR(50)\r\n);"



            string query = @"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='users' AND xtype='U')
                    CREATE TABLE users (
                    username Varchar(50) PRIMARY KEY,
                    email NVARCHAR(50) NOT NULL UNIQUE,
                    password NVARCHAR(50) NOT NULL,
                    comment nvarchar(500) 
                );";

            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            User user1 = new User("yim222", "1234abcd", "yim@gmail.com", "this is some user1");
            User user2 = new User("lingar", "1234567", "agaf@gmail.com", "My second user");

            UserDao.AddUser(user1);
            UserDao.AddUser(user2);
            connection.Close ();

        }

    }
}