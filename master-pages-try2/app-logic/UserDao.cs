using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using System.Collections;
using master_pages_try2.Model;

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
                string query = "INSERT INTO users  VALUES (@username, @password, @email ,@commentLingar)";


                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@username", user.UserName);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@commentLingar", user.Comment);
                Debug.WriteLine(command.CommandText);

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
            try
            {
                connection.Open();
                //string query = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Cars' AND xtype='U')\r\nCREATE TABLE Cars (\r\n    CarID INT PRIMARY KEY,\r\n    CarName NVARCHAR(50),\r\n    CarBrand NVARCHAR(50)\r\n);"



                string query = @"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='users' AND xtype='U')
                    CREATE TABLE users (
                    username Varchar(50) PRIMARY KEY,
                    password NVARCHAR(50) NOT NULL  ,
                    email NVARCHAR(50) NOT NULL UNIQUE,
                    comment nvarchar(500) 
                );";

                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                //User user1 = new User("yim222", "1234abcd", "yim@gmail.com", "this is some user1");
                //User user2 = new User("lingar", "1234567", "agaf@gmail.com", "My second user");

                //UserDao.AddUser(user1);
                //UserDao.AddUser(user2);
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }

            finally
            {
                connection.Close();

            }


        }


        public static User[] GetUsers()
        {


            SqlConnection connection = new SqlConnection(connectionString);
            //run a specialized SELECT COUNT(*) query beforehand.
            SqlDataReader reader = null;
            try
            {
                connection.Open();

                string query = "Select COUNT(*) from users";
                SqlCommand command = new SqlCommand(query, connection);

                reader = command.ExecuteReader();
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
                //Debug.WriteLine($"Select users fro GetUsers(0 = {string.Join(",\n", (object[])users)}");
                return users;

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                reader.Close();
                connection.Close();
            }






        }

        public static User RowToUser(SqlDataReader reader)
        {
            User user = new User(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));

            return user;
        }

        public static bool IsExist(string field, string value)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            //string query = "SELECT COUNT(*) FROM users WHERE @field = @value";//wrong - field cannot be parameterized but should be injected as regular string
            //(for values it's not safe)
            string query = $"SELECT COUNT(*) FROM users WHERE {field} = @value";

            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                ///command.Parameters.AddWithValue("@YourValue", "value_to_check"); // Replace with the value you're checking



                command.Parameters.AddWithValue("@value", value);

                connection.Open();
                // ExecuteScalar returns an object, which we cast to an int
                int count = (int)command.ExecuteScalar();
                Debug.WriteLine("count isexists= " + count);
                return count > 0;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();

            }


        }

        public static User Login(string username, string password)
        {


            SqlConnection connection = new SqlConnection(connectionString);
            //run a specialized SELECT COUNT(*) query beforehand.
            SqlDataReader reader = null;
            SqlCommand command = null;
            try
            {
                connection.Open();

                string query = "Select * from users where username = @userNamePar AND password = @passwordPar";

                command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@userNamePar", username);
                command.Parameters.AddWithValue("@passwordPar", password);

                reader = command.ExecuteReader();
               


               
                if (reader.HasRows)
                {
                    reader.Read();

                    return RowToUser(reader);
                }
                else
                {

                    return null;
                }
             

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                // Ensure reader, command, and connection are closed/disposed
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
                if (command != null)
                {
                    command.Dispose();
                }
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
                       
        }
    }
}