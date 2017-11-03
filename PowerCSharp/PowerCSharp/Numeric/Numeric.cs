using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp.Numeric
{
    class Numeric
    {
        public void test()
        {
            // 
            int switchThreshMs = 50;
            decimal switchThreshMs2 = (decimal)switchThreshMs / 1000;
            Console.WriteLine(switchThreshMs2.ToString());

            //var result = new List<Dog>()
            //{
            //    new Dog(){num = 1231, name="dog1"},
            //    new Dog(){num = 2337, name="dog2"},
            //    new Dog(){num = 917, name="dog2"}
            //};
            //var c = result.Average(r => r.num);

            //Console.WriteLine(result.Average(r => r.num).ToString());
            //Console.WriteLine(Math.Round(result.Average(r => r.num)).ToString());
            //Console.WriteLine(Convert.ToInt16(Math.Round(result.Average(r => r.num)).ToString()));

            //Console.WriteLine(c.ToString());
        }
    }
}
