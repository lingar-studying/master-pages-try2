using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Web;

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
                string query = "INSERT INTO users VALUES (@username, @password, @email @commentLingar)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@username", user.UserName);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@commentLingar", user.Comment);

                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();

            }

        }
    }
}