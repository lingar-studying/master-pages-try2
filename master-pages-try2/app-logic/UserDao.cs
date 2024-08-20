using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;

namespace master_pages_try2.app_logic
{
    public class UserDao
    {
        //public static SqlConnection
        static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master-page-try;Integrated Security=True;Connect Timeout=30;Encrypt=False;";





        public static User AddUser(User user)
        {
            SqlConnection connection = new SqlConnection(connectionString);

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

            SqlConnection connection = new SqlConnection(connectionString);

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
            //User user1 = new User("yim222", "1234abcd", "yim@gmail.com", "this is some user1");
            //User user2 = new User("lingar", "1234567", "agaf@gmail.com", "My second user");

            //UserDao.AddUser(user1);
            //UserDao.AddUser(user2);
            connection.Close();

        }


        public static User[] GetUsers()
        {


            SqlConnection connection = new SqlConnection(connectionString);
            //run a specialized SELECT COUNT(*) query beforehand.



            connection.Open();

            string query = "Select COUNT(*) from users";
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int count = reader.GetInt32(0);
            Debug.WriteLine("rows = " + count);
            reader.Close();


            query = "Select * from users";
            command = new SqlCommand(query, connection);

            User[] users = new User[count];
             reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                int i = 0;
                //reader.Ro
                while (reader.Read())//this method read one row, and return true if exist antoher
                {
                    users[i++] = RowToUser(reader);
                }
            }
            Debug.WriteLine($"Select users = {string.Join(",\n", (object[]) users)}");
            reader.Close();
            return users;



        }

        public static User RowToUser(SqlDataReader reader)
        {
            User user = new User(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));

            return user;
        }

    }
}