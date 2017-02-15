using System;
using System.Linq;
using System.Collections.Generic;

using LearningLinq.CustomExtensions;
using LearningLinq.DataSources;

namespace LearningLinq.Testing
{
    public class Program
    {
        /*
            Extension methods allow use to add functionality to sealed classes.
            (ChangeFirstLetterCase as an example of this)
            Note: 1. takes as a parameter, this
                  2. lives in a static class.
        */
        public static void Main()
        {
            Console.WriteLine("lesson 3\n".ChangeFirstLetterCase());
            ExampleClass testing = new ExampleClass();
            var nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            testing.EvenNumbersExtensionDirectly(nums);
            testing.EvenNumbersLambdaIn(nums);
            testing.EvenNumbersLambdaFuncd(nums);
            testing.EvenNumberLambdaExternalFunc(nums);
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
    }

    // Class with Examples
    public class ExampleClass
    {

        public void EvenNumbersLambdaIn(List<int> numbers)
        {
            var output = numbers.Where(n => n % 2 == 0);
            DumpNumbers(output);
        }
        public void EvenNumbersExtensionDirectly(List<int> numbers)
        {
            // call the extension directly
            var output = Enumerable.Where(numbers, n => n % 2 == 0);
            DumpNumbers(output);
        }

        public void EvenNumbersLambdaFuncd(List<int> numbers)
        {
            // build a delegate and use it
            Func<int, bool> pred = n => n % 2 == 0;
            var output = numbers.Where(x=>pred(x));
            DumpNumbers(output);
        }


        private bool predicate(int x)
        {
            return x % 2 == 0;
        }
        public void EvenNumberLambdaExternalFunc(List<int> numbers)
        {
            var output =  numbers.Where(x => predicate(x));
            DumpNumbers(output);
        }

        private void DumpNumbers(IEnumerable<int> numbers)
        {
            Console.WriteLine("\t" + string.Join(",", numbers));
        }

    }


}
