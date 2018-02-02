using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCSharp.OperatorsExpressions
{
    class MySwitch
    {
        // switch (C# Reference)
        // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/switch
        
        public static void Main2()
        {
            int caseSwitch = 1;

            switch (caseSwitch)
            {
                case 1:
                    Console.WriteLine("Case 1");
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }
        // The example displays the following output:
        //       Case 1

        public enum Color { Red, Green, Blue }

        public static void Main3()
        {
            Color c = (Color)(new Random()).Next(0, 3);
            if (c == Color.Red)
                Console.WriteLine("The color is red");
            else if (c == Color.Green)
                Console.WriteLine("The color is green");
            else if (c == Color.Blue)
                Console.WriteLine("The color is blue");
            else
                Console.WriteLine("The color is unknown.");
        }

    }
}
