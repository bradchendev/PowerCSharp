using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp
{
    class MyEnum
    {
        public void test()
        {
            //string s = Environment.MachineName;
            string s = "ApServer02";
            ApServer item = (ApServer)Enum.Parse(typeof(ApServer), s, false);
            Console.WriteLine((int)item);
            // return 2
            Console.WriteLine(item);
            // return ApServer02
        }



        public ObjectState State { get; set; }

        public int StateId
        {
            get { return (int)State; }
        }

    }

    enum ApServer
    {
        ApServer01 = 1,
        ApServer02 = 2,
        ApServer03 = 3
    }

    public enum ObjectState
    {
        Starting = 0,
        Started = 1,
        Stopping = 2,
        Stopped = 3,
        Unknown = 4,
    }
}
