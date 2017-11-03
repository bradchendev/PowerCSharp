using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp.List
{
    class ConvertListModelItem
    {
        public void test()
        {
            var myCars = new Car().getList();

            List<Car2> all = myCars.ConvertAll(x => x.ConvertTo<Car2>()); 
        }
    }

    public class Car2
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
