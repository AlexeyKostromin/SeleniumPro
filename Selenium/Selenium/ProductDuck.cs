using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium
{
    public class ProductDuck
    {
        public ProductDuck(string url, string name, string price, string customPrice)
        {
            this.url = url;
            this.name = name;
            this.price = price;
            this.customPrice = customPrice;
        }
        
        private string url;
        private string name;
        private string price;
        private string customPrice;

    }
}
