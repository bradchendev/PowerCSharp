using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp.ForIteration
{
    class ForIteration
    {
        public void test()
        {
            string[] s = new string[] { "aaa", "bbb", "ccc" };
            string[] t = new string[] { "xxx", "yyy", "zzz" };

            for (int i = 0; i < s.Count(); i++)
            {
                Console.WriteLine(s[i]);
                Console.WriteLine(t[i]);
            }
        }


    }
}
