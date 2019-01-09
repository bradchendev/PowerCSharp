using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerCSharp.WebCrawler;

namespace CSharp46
{
    public class Program
    {
        static void Main(string[] args)
        {

            var url = "https://t-space.tutorabc.com/";
            var events = new TspaceEvent().GetTpaceEvents(url);

            //Console.WriteLine(Guid.NewGuid().ToString());
            //Console.WriteLine(Guid.NewGuid().ToString("N"));

            Console.ReadLine();
        }
    }
}
