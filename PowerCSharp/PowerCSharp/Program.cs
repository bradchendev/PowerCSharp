using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(Guid.NewGuid().ToString());
            Console.WriteLine(Guid.NewGuid().ToString("N"));
            Console.WriteLine(Guid.NewGuid().ToString("N"));
            Console.WriteLine(Guid.NewGuid().ToString("N"));

            //var myCars = new Car().getList();
            //foreach (var item in myCars)
            //{
            //    Console.WriteLine(item.Name);
            //}

            //ConvertListModelItem.test();


            //bTime.test();

            //ListWebSite.ListLocalIISWebSites();
            //ListWebSite2.ListWebSites(); 

            //new ParrallelFor().test();

            Console.ReadLine();
        }
    }
}
