using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp
{
    class DateTimeToString
    {
        void test()
        {
            Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmss"));
            Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmssfff"));

        }

    }
}
