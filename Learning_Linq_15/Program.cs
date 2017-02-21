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
            Console.WriteLine("lesson 15\n".ChangeFirstLetterCase());
            ExampleClass testing = new ExampleClass();
            testing.EmployeesByJobTitle();
            Console.WriteLine();
            testing.StudentIDToStudentMap();
            Console.WriteLine();
            testing.StudentIDToStudentName();
            Console.WriteLine();
            testing.ConvertListToArray();

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
    }

    // Class with Examples
    public class ExampleClass
    {
        Context db = Context.Instance;
 
        public void ConvertListToArray()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            // convert a List to an Array
            List<string> countries = new List<string> { "US", "India", "UK", "Australia", "Canada" };

            string[] result = (from c in countries
                               orderby c ascending
                               select c).ToArray();

            Console.WriteLine(string.Join("\n", result));
        }
        public void StudentIDToStudentName()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            var students = db.Students;
            Dictionary<int, string> result = students.ToDictionary(x => x.ID, x => x.Name);
            Console.WriteLine(string.Join(", ", result));
        }
        public void StudentIDToStudentMap()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            var students = db.Students;

            // by default, the extension will use Student...
            Dictionary<int, Student> result = students.ToDictionary(x => x.ID);
            Console.WriteLine(string.Join("\n", result.Select(x => new { x.Key, x.Value.ID, x.Value.Name })));

        }

        public void EmployeesByJobTitle()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            var employees = db.Employees;

            ILookup<string, Employee> looks = employees.ToLookup(x => x.JobTitle);
            foreach (var kvp in looks)
            {
                Console.WriteLine(kvp.Key);
                foreach (var e in looks[kvp.Key])
                {
                    Console.WriteLine($"\t{e.EmployeeID}\t{e.FirstName} {e.LastName}");
                }
            }

        }
   
    }


}
