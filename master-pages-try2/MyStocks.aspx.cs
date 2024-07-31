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
        protected void Page_Load(object sender, EventArgs e)
        {
            Stock[] stocks =  StockService.CreateMock();

            StocksArea.Text = stocks[0].OfficialName;

            Repeater1.DataSource = stocks;
            Repeater1.DataBind();


        }
    }
}