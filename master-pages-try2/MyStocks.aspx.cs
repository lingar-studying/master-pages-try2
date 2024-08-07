using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using master_pages_try2.app_logic;

namespace master_pages_try2
{
    public partial class MyStocks : System.Web.UI.Page
    {

        public static Stock[] stocks = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Log");
            //Stock[]

            if (!IsPostBack)
            {
                stocks = StockService.CreateMock();

                StocksArea.Text = stocks[0].OfficialName;

                Repeater1.DataSource = stocks;
                Repeater1.DataBind();

            }



        }
        protected void DoSomething(object sender, EventArgs e)
        {
            MyTitle.Text = "Stocks App";
        }

        protected void UpdateSomeStock(object sender, EventArgs e)
        {

            // Amazon.com, Inc.Common Stock(AMZN)
            stocks[2] = new Stock("Amazon.com", "AMZN", 165.44);
            MyTitle.Text = "Check the last stock is- " + stocks[2];
            Repeater1.DataSource = stocks;
            Repeater1.DataBind();

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Retrieve values from TextBox controls
            string name = txtName.Text;
            string ageText = txtAge.Text;

            // Optionally, convert age to an integer
            int age;
            bool isValidAge = int.TryParse(ageText, out age);

            // Process or display the retrieved data
            if (isValidAge)
            {
                lblResult.Text = $"Name: {name}, Age: {age}";
            }
            else
            {
                lblResult.Text = "Invalid age entered.";
            }
        }
    }
}