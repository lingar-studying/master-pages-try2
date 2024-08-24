using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using master_pages_try2.app_logic;
using System.Xml.Linq;

namespace master_pages_try2.web_files.pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void LoginUser(object sender, EventArgs e)
        {
            // Retrieve values from TextBox controls
            string username = OfUserName.Text;
            string password = OfPassword.Text;
           
            Debug.WriteLine("login code behind");

           //login by dao - if exist return, if not null 
            //if (UserDao.IsExist("email", email))
            //{
            //    ErrorMsg.Text = "email exists, no duplicates...";
            //    ErrorMsg.Style.Add("Color", "red");
            //    DisplayUsers();

            //    return;
            //}

           

            //adding to the db
            User success = UserDao.Login(username, password);

            if (success == null)
            {
                Debug.WriteLine("WRONG DETAILS. Login failed." );

                ErrorMsg.Text = "WRONG DETAILS. Login failed.";
                ErrorMsg.Style.Add("Color", "red");
                return;
            }
            Debug.WriteLine("User Logged succesfully = " + success);

            Session["loggedUser"] = success;

            ResetTextBoxes(this);

          
            //Debug.WriteLine("Updating users = " + string.Join("\n", (object[])users));
            ErrorMsg.Text = "User has been logged successfully " + success;
            ErrorMsg.Style.Add("Color", "green");
            Response.Redirect("~/Page1.aspx");

            
        }

        //TODO - we can do it service method
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

    }
}