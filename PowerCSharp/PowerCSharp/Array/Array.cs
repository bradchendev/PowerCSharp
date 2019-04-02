using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp.Array
{
    class Array
    {
        public void stringExistInArray()
        {
       
            //using System.Linq;
            //...
            //string[] array = { "foo", "bar" };
            //if (array.Contains("foo")) {
            //...
            //}
        }

        public void splitToArray()
        {
            string sNumbers = "1,2,3,4,5";

            var StringArray = sNumbers.Split(',');

            var IntList= sNumbers.Split(',').Select(Int32.Parse).ToList();

            var IntArray = sNumbers.Split(',').Select(Int32.Parse).ToArray();

        }
    }
}
