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

        public static List<Stock> stocks_list = new List<Stock>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Log");
            //Stock[]

            if (!IsPostBack)
            {
                stocks = StockService.CreateMock();

                StocksArea.Text = stocks[0].OfficialName;

                if(stocks_list.Count == 0)
                {
                    for (int i = 0; i < stocks.Length; i++)
                    {
                        stocks_list.Add(stocks[i]);
                    }

                }
               

                Repeater1.DataSource = stocks;
                Repeater1.DataBind();
                Repeater2.DataSource = stocks_list;
                Repeater2.DataBind();
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

        protected void AddNewStock(object sender, EventArgs e)
        {
            // Retrieve values from TextBox controls
            string officalName = OfNameInput.Text;
            string sign = SignInput.Text;
            double price = int.Parse(PriceInput.Text);
            // Optionally, convert age to an integer
            Stock newStock = new Stock(officalName, sign, price);
            stocks_list.Add(newStock);
            Repeater2.DataSource = stocks_list;
            Repeater2.DataBind();


        }
    }
}