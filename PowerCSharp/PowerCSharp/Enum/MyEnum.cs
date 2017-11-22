using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp
{
    class MyEnum
    {
        public ObjectState State { get; set; }

        public int StateId
        {
            get { return (int)State; }
        }

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
