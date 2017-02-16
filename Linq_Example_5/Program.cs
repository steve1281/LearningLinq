using System;
using System.Linq;
using System.Collections.Generic;

using LearningLinq.CustomExtensions;
using LearningLinq.DataSources;

namespace LearningLinq.Testing
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("lesson 5\n".ChangeFirstLetterCase());
            ExampleClass testing = new ExampleClass();
            testing.MultiplySum();
            testing.MultiplySumWithSeed();
            testing.CommaString();
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
    }

    // Class with Examples
    public class ExampleClass
    {
        string[] countries = new string[] { "India", "US", "UK", "Canada", "Australia" };


        public void CommaString()
        {
            var s= countries.Aggregate((a, b) => a + ", " + b);
            Console.WriteLine(s);
        }
        public void MultiplySum()
        {
            int[] numbers = { 2, 3, 4, 5 };

            // produce the multiplicative sum
            // 5*(4*(3*2)))
            var msum = numbers.Aggregate((a, b) => a * b); // 1200

            Console.WriteLine($"{msum}");

        }

        public void MultiplySumWithSeed()
        {
            int[] numbers = { 2, 3, 4, 5 };

            // produce the multiplicative sum
            // 5*(4*(3*2)))
            // also, you can have a seed, say 10
            // 10*(5*(4*(3*2))))
            var msum=numbers.Aggregate(10, (a, b) => a * b); // 1200

            Console.WriteLine($"{msum}");

        }
    }


}
