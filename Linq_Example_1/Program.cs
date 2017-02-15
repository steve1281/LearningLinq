using System;
using System.Linq;
using LearningLinq.CustomExtensions;

namespace LearningLinq.Testing
{
    public class Program
    {
        /*
          series of lessons, based on https://www.youtube.com/watch?v=z3PowDJKOSA&index=1&list=PL6n9fhu94yhWi8K02Eqxp3Xyh_OmQ0Rp6
          by kudvenkat

        The first lesson is a general discussion of LINQ, how is can connect to many underlying
        architectures, how everything is a IEnumerable, and an introdruction of the difference between
        query and extension syntaxes (note: query is converted to extensions, so the speed difference is
        minimal at compile time and non-existant at run time)
        */
        public static void Main()
        {
            Console.WriteLine("lesson 1\n".ChangeFirstLetterCase());
            ExampleClass testing = new ExampleClass();
            testing.Example();
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
    }

    // Class with Examples
    public class ExampleClass
    {
        public void Example()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            // read this as : output is assigned numbers selected as n such that n mod 2 equals 0
            // 
            var output = numbers.Where(n => n % 2 == 0);
            foreach (var n in output)
            {
                Console.WriteLine(n);
            }

        }
    }
}
