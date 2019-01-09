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

        public void Ram()
        {
            //Random Class
            //https://docs.microsoft.com/en-us/dotnet/api/system.random?view=netframework-4.7.2

            // Instantiate random number generator using system-supplied value as seed.
            Random rand = new Random();
            // Generate and display 5 random byte (integer) values.
            byte[] bytes = new byte[5];
            rand.NextBytes(bytes);
            Console.WriteLine("Five random byte values:");
            foreach (byte byteValue in bytes)
                Console.Write("{0, 5}", byteValue);
            Console.WriteLine();
            // Generate and display 5 random integers.
            Console.WriteLine("Five random integer values:");
            for (int ctr = 0; ctr <= 4; ctr++)
                Console.Write("{0,15:N0}", rand.Next());
            Console.WriteLine();
            // Generate and display 5 random integers between 0 and 100.//
            Console.WriteLine("Five random integers between 0 and 100:");
            for (int ctr = 0; ctr <= 4; ctr++)
                Console.Write("{0,8:N0}", rand.Next(101));
            Console.WriteLine();
            // Generate and display 5 random integers from 50 to 100.
            Console.WriteLine("Five random integers between 50 and 100:");
            for (int ctr = 0; ctr <= 4; ctr++)
                Console.Write("{0,8:N0}", rand.Next(50, 101));
            Console.WriteLine();
            // Generate and display 5 random floating point values from 0 to 1.
            Console.WriteLine("Five Doubles.");
            for (int ctr = 0; ctr <= 4; ctr++)
                Console.Write("{0,8:N3}", rand.NextDouble());
            Console.WriteLine();
            // Generate and display 5 random floating point values from 0 to 5.
            Console.WriteLine("Five Doubles between 0 and 5.");
            for (int ctr = 0; ctr <= 4; ctr++)
                Console.Write("{0,8:N3}", rand.NextDouble() * 5);

        }
    }
}
