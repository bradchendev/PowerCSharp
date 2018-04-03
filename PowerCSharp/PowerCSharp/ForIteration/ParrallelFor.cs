using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }

        public Product[] getAllSampleProduct()
        {
            Product[] products = new Product[] 
            { 
                new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
                new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3 }, 
                new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16 } 
            };        
            return products;
        }
    }

    public class ParrallelFor
    {
        public void test()
        {

            var products = new Product().getAllSampleProduct();

            Parallel.ForEach(products, (prod) =>
            {
                Console.WriteLine(prod.Name);
            });
        }


    }
}
