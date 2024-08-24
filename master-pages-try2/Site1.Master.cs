using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using master_pages_try2.app_logic;
namespace master_pages_try2
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateDisplay.Text = DateTime.Now.ToString("dddd, MMMM dd");
            // List of allowed pages that do not require authentication
            string[] allowedPages = { "/web-files/pages/login.aspx", "/lingar-home.aspx" };

            string currentPath = Request.Url.AbsolutePath.ToLowerInvariant();

            if (Session["loggedUser"] == null && !allowedPages.Contains(currentPath))
            {
                Debug.WriteLine("not logged...");
                if (currentPath != "/web-files/pages/login.aspx")
                {
                    Response.Redirect("~/web-files/pages/login.aspx");
                }
            }

        }
        
    }
}