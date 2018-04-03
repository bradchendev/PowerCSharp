using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp
{
    class DateTimeAdd
    {
        /// <summary>
        /// 取上個5分整
        /// </summary>
        public void test()
        {
            var dt = DateTime.Parse("2011-08-11 16:01");
            var dt2 = dt.AddMinutes(-dt.Minute % 5);
            Console.WriteLine(dt2.ToString());
            // 2011-08-11 16:00

            dt = DateTime.Parse("2011-08-11 16:14");
            dt2 = dt.AddMinutes(-dt.Minute % 5);
            Console.WriteLine(dt2.ToString());
            // 2011-08-11 16:10

            dt = DateTime.Parse("2011-08-11 16:15");
            dt2 = dt.AddMinutes(-dt.Minute % 5);
            Console.WriteLine(dt2.ToString());
            // 2011-08-11 16:15

            dt = DateTime.Parse("2011-08-11 16:16");
            dt2 = dt.AddMinutes(-dt.Minute % 5);
            Console.WriteLine(dt2.ToString());
            // 2011-08-11 16:15


            
            // Strip seconds from datetime
            DateTime dt55 = DateTime.Now;
            dt55 = dt55.AddSeconds(-dt.Second);
        }

    }
}
