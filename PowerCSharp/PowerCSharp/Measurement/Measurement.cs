using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp.Measurement
{
    class Measurement
    {
        private void measure()
        {
            //2010-04-03
            //[C#]用Stopwatch計算累計耗費時間的注意事項
            //https://dotblogs.com.tw/larrynung/2010/04/03/14384

            // using System.Diagnostics

            // 方法1
            Stopwatch czasAlg = new Stopwatch();
            czasAlg.Start();
            //Do something 
            czasAlg.Stop();
            double timeInSecondsPerN = czasAlg.Elapsed.TotalSeconds;


            // 方法2
            //Converting a Stopwatch to an Int32 makes absolutely no sense. To get the ellapsed time you could use the ElapsedMilliseconds property. So the usual pattern would be:
            Stopwatch watch = Stopwatch.StartNew();
            // Do something you would like to measure
            watch.Stop();
            long totalMilliseconds = watch.ElapsedMilliseconds;
            Console.WriteLine("The operation executed in {0} ms", totalMilliseconds);

        }
    }
}
