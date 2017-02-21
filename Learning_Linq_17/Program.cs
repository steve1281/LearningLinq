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
            Conversion Operators - ToList, ToArray, ToDictionary, ToLookup
                       Cast, OfType, AsEnumerable, AsQueryable
        */
        public static void Main()
        {
            Console.WriteLine("lesson 17\n".ChangeFirstLetterCase());
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
            var db = Context.Instance;
            // .AsEnumerable will force the code prior to it, to run first.
            // so, if your context was a database, it would produce sql commands
            // upto, but no beyond, the .AsEnumerable statement. (and then the rest happens in memory)
            // (this can be positioned to move query logic off the sql server into the
            // client (well) side.)
            var employees = db.Employees
                                .AsEnumerable()
                                .Where(e => e.Gender == "Male")
                                .OrderByDescending(x => x.AnnualSalary)
                                .Take(5)
                                .Select(s => new { s.FirstName, s.AnnualSalary, s.Gender });

            Console.WriteLine(string.Join("\n", employees));

        }
    }


}
