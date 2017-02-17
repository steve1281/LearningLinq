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
            Console.WriteLine("lesson 11\n".ChangeFirstLetterCase());
            ExampleClass testing = new ExampleClass();
            testing.SimpleReverse();
            Console.WriteLine();
            testing.SimpleReverse();
            Console.WriteLine();
            testing.MultiLevelSort();
            Console.WriteLine();
            testing.MultiLevelSortQuery();
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
    }

    // Class with Examples
    public class ExampleClass
    {
        Context db = Context.Instance;

        public void SimpleReverse()
        {

            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            // inverts the student selection - however its initially selected.
            var students = db.Students.Select(s=>s).Reverse();
            foreach (var s in students)
            {
                Console.WriteLine($"{s.Name}");
            }
        }

        public void OrderByName()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            // select and sort by name.
            var students = db.Students.OrderBy(s => s.Name);
            foreach (var s in students)
            {
                Console.WriteLine($"{s.Name}");
            }
        }

        public void MultiLevelSort()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            // select and sort by marks, name
            var students = db.Students.OrderBy(s=>s.TotalMarks).ThenBy(s => s.Name);
            foreach (var s in students)
            {
                Console.WriteLine($"{s.Name}-{s.ID}-{s.TotalMarks}");
            }

        }
        public void MultiLevelSortQuery()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            // select and sort by marks, name
            var students = from s in db.Students
                           orderby s.TotalMarks, s.Name, s.ID descending
                           select new { s.ID, s.TotalMarks, s.Name };

            foreach (var s in students)
            {
                Console.WriteLine($"{s.Name}-{s.ID}-{s.TotalMarks}");
            }

        }

    }


}
