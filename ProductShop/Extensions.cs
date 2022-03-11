using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop
{
    static class Extensions
    {
        public static void Show(this Store store)
        {
            foreach (Product item in store.GetProducts())
            {
                Console.WriteLine(item);
            }
        }
    }
}
