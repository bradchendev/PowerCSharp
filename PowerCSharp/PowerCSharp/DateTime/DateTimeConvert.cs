using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp
{
    // Custom Date and Time Format Strings
    // https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings
    class StringToDatetime
    {
        void test()
        {
            // using System.Globalization;
            string myStr = "12/11/17 2:52:35 PM";
            DateTime dt = DateTime.ParseExact(myStr, "yy/MM/dd h:mm:ss tt", CultureInfo.InvariantCulture);
            Console.WriteLine(dt);

            string myStr2 = "201801181901";
            DateTime dt2 = Convert.ToDateTime(DateTime.ParseExact(myStr2, "yyyyMMddHHmm", CultureInfo.InvariantCulture));
            Console.WriteLine(dt2);
        }
    }

    class DateTimeToString
    {
        void test()
        {
            Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmss"));
            //20180123
            Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            //20180123135941
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff"));
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"));
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff"));
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.ffffZ"));
            //2017-12-11 11:27:07
            //2017-12-11 11:27:07.2115
            //2017-12-11T11:27:07.212Z
            //2017-12-11 11:27:07.2125
            //2017-12-11T11:27:07.2125Z
        }

    }



    class DateTimeFromString
    {
        void test()
        {
            // How to: Convert a String to a DateTime (C# Programming Guide)
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/how-to-convert-a-string-to-a-datetime

            string dateTime = "01/08/2008 14:50:50.42";
            DateTime dt = Convert.ToDateTime(dateTime);
            Console.WriteLine("Year: {0}, Month: {1}, Day: {2}, Hour: {3}, Minute: {4}, Second: {5}, Millisecond: {6}",
                              dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
            // Specify exactly how to interpret the string.  
            IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);

            // Alternate choice: If the string has been input by an end user, you might    
            // want to format it according to the current culture:   
            // IFormatProvider culture = System.Threading.Thread.CurrentThread.CurrentCulture;  
            DateTime dt2 = DateTime.Parse(dateTime, culture, System.Globalization.DateTimeStyles.AssumeLocal);
            Console.WriteLine("Year: {0}, Month: {1}, Day: {2}, Hour: {3}, Minute: {4}, Second: {5}, Millisecond: {6}",
                              dt2.Year, dt2.Month, dt2.Day, dt2.Hour, dt2.Minute, dt2.Second, dt2.Millisecond);
            /* Output (assuming first culture is en-US and second is fr-FR):  
            Year: 2008, Month: 1, Day: 8, Hour: 14, Minute: 50, Second: 50, Millisecond: 420  
            Year: 2008, Month: 8, Day: 1, Hour: 14, Minute: 50, Second: 50, Millisecond: 420  
            Press any key to continue . . .  
            */
        }
    }
}
