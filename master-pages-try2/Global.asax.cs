using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using master_pages_try2.app_logic;
namespace master_pages_try2.web_files.pages
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            // Set session timeout to 5 minutes programmatically
            Debug.WriteLine("Application start");

            //Session.Timeout = 1;

        }


        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

            //Debug.WriteLine("Workig");

            //if (HttpContext.Current.Session == null || Session["userLogged"] == null )
            //{
            //    string path = Request.Url.AbsolutePath.ToLower();

            //    // List of pages that can be accessed without authentication
            //    string[] allowedPages = { "~/web-files/pages/Login.aspx", "~/lingar-home.aspx" };

            //    // Check if the user is not authenticated


            //    Debug.WriteLine("hhhh");
            //    // Redirect if the requested page is not in the allowed list
            //    if (!allowedPages.Contains(path))
            //    {

            //        if (path != "/web-files/pages/login.aspx")
            //        {
            //            Response.Redirect("~/web-files/pages/login.aspx");
            //        }
                  
            //    }

            //}
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}