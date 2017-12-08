using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp
{
    class DatetimeFormat
    {
        public void test()
        {
            // Yesterday 00:00:00 
            var yesterdayStartTime = DateTime.Now.Date.AddDays(-1);

            // Yesterday 23:59:59
            var yesterdayEndTime = new DateTime(yesterdayStartTime.Year, yesterdayStartTime.Month, yesterdayStartTime.Day, 23, 59, 59);

        }

    }
}
