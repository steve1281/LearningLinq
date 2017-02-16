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
		Aggregates - Min, Max, Count, Average, Sum, and Aggregate itself (discussed in lesson 5)
		Notes: in the original tutorial, he shows how to do this without linq, and with. I don't
		bother with the non-linq (its obvious) but he makes very good points in the video.
		*/

        public static void Main()
        {
            Console.WriteLine("lesson 4\n".ChangeFirstLetterCase());
            ExampleClass testing = new ExampleClass();
            testing.SimplySum();
            testing.SumEvens();
            testing.SumEvensQuery();
            testing.ShortestCountry();
            testing.ShortestCountry();
            testing.LongestCountry();
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
    }

    // Class with Examples
    public class ExampleClass
    {
        int[] numbers = new int[] {1,2,3,4,5,6,7,8,9,10};
        string[] countries = new string[] { "Canada", "Austriala", "USA", "India", "UK" };

        public void SumEvens()
        {
            Console.WriteLine(numbers.Where(x => x % 2 == 0).Sum());
        }
        public void SimplySum()
        {
            Console.WriteLine(numbers.Sum());
        }
        public void SumEvensQuery()
        {
            Console.WriteLine((from n in numbers where n % 2 == 0 select n).Sum());
        }

        public void ShortestCountry()
        {
            // and the simplified linq (normally not even puit in a method)
            int min_length = countries.Min(x => x.Length);
            Console.WriteLine($"min length: {min_length}");
        }

        public void LongestCountry()
        {
            // and the simplified linq (normally not even puit in a method)
            int max_length =  countries.Max(x => x.Length);
            Console.WriteLine($"max length: {max_length}");
        }

        public void ShortestCountryNoLinq()
        {
            // example of work we would traditionally do:
            string result = null;

            foreach (string s in countries)
            {
                if (result == null || s.Length < result.Length)
                {
                    result = s;
                }
            }
            Console.WriteLine($"min length: {result.Length}");
        }
    }


}
