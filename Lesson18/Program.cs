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
            Console.WriteLine("lesson 18".ChangeFirstLetterCase());
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
            Context db = Context.Instance;
            
            db.SaveChanges();
            var overpaid = db.Employees.Where(s => s.AnnualSalary > 1000);
            foreach (Employee employee in overpaid)
            {
                Console.WriteLine($"Employee: {employee.FirstName} {employee.LastName} makes {employee.AnnualSalary}");

            }
        }

    }


}
