using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace master_pages_try2.app_logic
{
    public class User
    {
        private string userName; 
        private  string password;
        private string email;
        private string comment;

        public User(string userName, string password, string email, string comment)
        {
            this.userName = userName;
            this.password = password;
            this.email = email;
            this.comment = comment;
        }

        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string Comment { get => comment; set => comment = value; }
        public string Email { get => email; set => email = value; }

        public override string ToString()
        {
            return $"user=[username:{userName}, password: {password}, email: {email}, comment: {comment}]";
        }
    }
}