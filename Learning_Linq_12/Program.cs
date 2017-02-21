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
            Console.WriteLine("lesson 12\n".ChangeFirstLetterCase());
            ExampleClass testing = new ExampleClass();

            testing.Original();
            Console.WriteLine();

            testing.SkipToLengthTwo();
            Console.WriteLine();

            testing.TakeUntilLengthTwo();
            Console.WriteLine();

            testing.SkipThree();
            Console.WriteLine();

            testing.TakeThreeQuery();
            Console.WriteLine();

            testing.TakeThree();
            Console.WriteLine();

            Console.WriteLine("\nPress any key...");

            Console.ReadKey();
        }
    }

    // Class with Examples
    public class ExampleClass
    {
        string[] countries = { "Australia", "Canada", "Germany", "USA", "India", "UK", "Italy" };

        public void Original()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            Console.WriteLine(string.Join(", ", countries));
        }

        public void SkipToLengthTwo()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            var result = countries.SkipWhile(s => s.Length > 2);
            Console.WriteLine(string.Join(",", result));

        }

        public void TakeUntilLengthTwo()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            var result = countries.TakeWhile(s => s.Length > 2);
            Console.WriteLine(string.Join(",", result));
        }

        public void SkipThree()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            var result = countries.Skip(3);
            Console.WriteLine(string.Join(",", result));
        }
        public void TakeThreeQuery()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            var result  =  (from c in countries select c).Take(3);
            Console.WriteLine(string.Join(",", result));
        }

        public void TakeThree()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            var result = countries.Take(3);
            Console.WriteLine(string.Join(",", result));
        }
 

    }


}
