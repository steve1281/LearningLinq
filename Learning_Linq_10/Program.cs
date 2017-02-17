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
        OrderBy, OrderByDescending, ThenBy, ThenByDescending, Reverse
        */
        public static void Main()
        {
            Console.WriteLine("lesson 10\n".ChangeFirstLetterCase());
            ExampleClass testing = new ExampleClass();
            testing.SimpleOrderBy();
            Console.WriteLine();
            testing.SimpleOrderByQuery();
            Console.WriteLine();
            testing.OrderedDescending();
            Console.WriteLine();
            testing.OrderedDescendingQuery();
            Console.WriteLine();
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
    }

    // Class with Examples
    public class ExampleClass
    {
        Context db = Context.Instance;

        public void OrderedDescendingQuery()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            var students =  from s in db.Students
                   orderby s.Name 
                   descending
                            select s.Name;
            Console.WriteLine(string.Join("\n", students));
        }

        public void OrderedDescending()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            // actually an IOrderedEnumerable, which is a descendant of IEnumerable
            var students = db.Students.OrderByDescending(s => s.Name);
            foreach (var s in students)
            {
                Console.WriteLine($"{s.Name}");
            }
        }

        public void SimpleOrderByQuery()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            var students =  from s in db.Students
                           orderby s.Name
                           select s.Name;

            Console.WriteLine(string.Join("\n", students));

        }

        public void SimpleOrderBy()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            //  an IOrderedEnumerable, which is a descendant of IEnumerable
            IOrderedEnumerable<Student> students = db.Students.OrderBy(s => s.Name);
            foreach (var s in students)
            {
                Console.WriteLine($"{s.Name}");
            }

        }
  

    }


}
