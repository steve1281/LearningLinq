using System;
using System.Linq;
using System.Collections.Generic;

using LearningLinq.CustomExtensions;
using LearningLinq.DataSources;
using System.Collections;

namespace LearningLinq.Testing
{
    public class Program
    {
        /*
            Conversion Operators - ToList, ToArray, ToDictionary, ToLookup
                       Cast, OfType, AsEnumerable, AsQueryable
        */
        public static void Main()
        {
            Console.WriteLine("lesson 16\n".ChangeFirstLetterCase());
            ExampleClass testing = new ExampleClass();

            testing.CastExample();
            Console.WriteLine();

            testing.OfTypeExample();
            Console.WriteLine();

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
    }

    // Class with Examples
    public class ExampleClass
    {
        public void CastExample()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            IEnumerable<int> result = null;

            ArrayList numbers = new ArrayList();
            numbers.Add(1); // note that these are added as objects (ArrayList is generic)
            numbers.Add(2);
            numbers.Add(3);
            //numbers.Add("ABC"); // if this is added, an exception will occur.
            result = numbers.Cast<int>();
            Console.WriteLine(string.Join("\n", result));
        }

        public void OfTypeExample()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            IEnumerable<int> result = null;

            ArrayList numbers = new ArrayList();
            numbers.Add(1); // note that these are added as objects (ArrayList is generic)
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add("4");
            numbers.Add("ABC");
            result = numbers.OfType<int>(); // cast those that you can and ignore the rest.
            Console.WriteLine(string.Join(", ", result));
        }
        
    }


}
