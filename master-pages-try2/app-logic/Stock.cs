using System;

namespace master_pages_try2.app_logic
{
    public class Stock
    {

        private string officialName = "";
        private double price = 0;
        private string sign = "";

        public Stock() { }
        public Stock(string officialName,  string sign ,double price)
        {
            this.OfficialName = officialName;
            this.Price = price;
            this.Sign = sign;
        }

        public string OfficialName { get => officialName; set => officialName = value; }
        public double Price { get => price; set => price = value; }
        public string Sign { get => sign; set => sign = value.ToUpper(); }

        public void DisplayStock()
        {
            Console.WriteLine($"Official Name = {OfficialName}, price = {Price}, sign = {Sign}");
        }


        //create properties : 
        //Official Name, price, sign (=סמליל) ,starting price , closing price, industry(=תעשייה), exchange (=בורסה)
        // is day active 

        //create methods (פעולות ) 
        //start day - setting the current price and the starting price and day is active
        //finish day - setting the current price and the closing price
        //set price - setting the price
        //Print changes percentage (if the day is still  active it's not return nothing) 
        //Display Price - printing the Sign with the current price. 

    }

}
