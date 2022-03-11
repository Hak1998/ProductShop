using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop
{
    class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Price}";
        }

        public Product()
        {

        }

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public static Product Parse(string line)
        {
            int indexOfDefis = line.IndexOf('-');

            if (indexOfDefis == -1)
                return null;

            string name = line.Substring(0, indexOfDefis)?.Trim();
            if (string.IsNullOrEmpty(name))
                return null;

            string strPrice = line.Substring(indexOfDefis + 1)?.Trim();

            decimal price;
            if (!decimal.TryParse(strPrice, out price))
                return null;

            return new Product(name, price);
        }
    }
}
