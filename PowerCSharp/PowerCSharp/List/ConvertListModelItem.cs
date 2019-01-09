using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp
{
    static class ConvertListModelItem
    {
        public static void test()
        {
            var myCars = new Car().getList();

            //List<Car2> all = myCars.ConvertAll(x => x.ConvertTo<Car2>());
            List<Car2> all = new List<Car2>();

            // using System.Linq; 不然找不到select method
            all.AddRange(myCars.Select(dataItem => new Car2() { Id = dataItem.Id, Name = dataItem.Name }));

            foreach (var item in all)
            {
                Console.WriteLine(string.Format("Id:{0} Name:{1}",item.Id,item.Name));
            }

        }
    }

    public class Car2
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
