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
        private bool male;

        public User(string userName, string password, bool male)
        {
            this.userName = userName;
            this.password = password;
            this.male = male;
        }

        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public bool Male { get => male; set => male = value; }
    }
}