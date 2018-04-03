using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp
{
    public static class bTime
    {
        public static void test()
        {
            // 直接指定日期時間
            var d = Convert.ToDateTime("2018-03-11 15:00:09");

            // 字串變數轉日期時間
            string dateTime = "2017-11-06 17:50:50.42";
            DateTime dt = Convert.ToDateTime(dateTime);

            TimeSpan start = new TimeSpan(17, 50, 0);
            TimeSpan end = new TimeSpan(23, 00, 0);

            Console.WriteLine(bTime.TimeBetween(dt, start, end));
        }

        private static bool TimeBetween(DateTime datetime, TimeSpan start, TimeSpan end)
        {
            // convert datetime to a TimeSpan
            TimeSpan now = datetime.TimeOfDay;
            // see if start comes before end
            if (start < end)
                return start <= now && now <= end;
            // start is after end, so do the inverse comparison
            return !(end < now && now < start);
        }
    }
}
