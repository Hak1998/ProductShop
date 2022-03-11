using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop
{
    class Store
    {
        private const string FileName = "Store.txt";
        private Product[] products;
        public Store()
        {
            products = new Product[0];
        }

        public void Add(Product product)
        {
            Product[] newProducts = new Product[products.Length + 1];
            products.CopyTo(newProducts, 0);

            newProducts[products.Length] = product;
            products = newProducts;
        }

        public Product[] GetProducts()
        {
            Product[] tempProducts = new Product[products.Length];

            for (int i = 0; i < this.products.Length; i++)
            {
                tempProducts[i] = new Product();
                tempProducts[i].Name = products[i].Name;
                tempProducts[i].Description = products[i].Description;
                tempProducts[i].Price = products[i].Price;
            }

            return tempProducts;
        }

        public void SaveToFile()
        {
            using StreamWriter stream = new StreamWriter(FileName);
            foreach (Product item in this.products)
            {
                stream.WriteLine(item);
            }
        }

        public void LoadFromFile()
        {
            using StreamReader streamReader = new StreamReader(FileName);
            String line = streamReader.ReadLine();
            do
            {
                Product p = Product.Parse(line);
                this.Add(p);
                line = streamReader.ReadLine();

            } while (line != null);
        }

        public bool Contain(string name)
        {
            foreach (Product product in this.products)
            {
                if (product.Name == name)
                    return true;
            }

            return false;
        }

        public bool Remove(string name)
        {
            if (!this.Contain(name))
                return false;

            Product[] tempRec = new Product[this.products.Length - 1];
            for (int i = 0, j = 0; i < this.products.Length; i++)
            {
                if (this.products[i].Name != name)
                {
                    tempRec[j] = this.products[i];
                    j++;
                }
            }

            this.products = tempRec;
            return true;
        }
    }
}
