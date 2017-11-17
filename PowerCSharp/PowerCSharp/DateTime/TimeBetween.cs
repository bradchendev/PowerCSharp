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
