using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp.OperationSystem
{
    class OperationSystem
    {
        public void test()
        {
            Console.WriteLine("MachineName: {0}", Environment.MachineName);
        }

        // using System.Net;
        public void DisplayLocalHostName()
        {
            try
            {
                // Get the local computer host name.
                string hostName = Dns.GetHostName();
                Console.WriteLine("Computer name :" + hostName);
            }
            catch (SocketException e)
            {
                // using System.Net.Sockets;

                Console.WriteLine("SocketException caught!!!");
                Console.WriteLine("Source : " + e.Source);
                Console.WriteLine("Message : " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught!!!");
                Console.WriteLine("Source : " + e.Source);
                Console.WriteLine("Message : " + e.Message);
            }
        }

    }
}
