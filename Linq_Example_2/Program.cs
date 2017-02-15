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
            Console.WriteLine("lesson 2\n".ChangeFirstLetterCase());
            ExampleClass testing = new ExampleClass();
            testing.Example1();
            Console.WriteLine("\n...\n");
            testing.Example2();
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
    }

    // Class with Examples
    public class ExampleClass
    {

        public void Example1()
        {
            // select all students such that gender is male
            // in example 1 use extensions linq
            Context db = Context.Instance;
            var output = db.Students.Where(student => student.Gender == "Male");
            foreach (var s in output)
            {
                Console.WriteLine($"{s.ID}:{s.Name} {s.Gender}");
            }
        }

        public void Example2()
        {
            Context db = Context.Instance;
            //var output = db.Students.Where(student => student.Gender == "Male");
            var output = from student in db.Students
                         where student.Gender == "Male"
                         select student;

            foreach (var s in output)
            {
                Console.WriteLine($"{s.ID}:{s.Name} {s.Gender}");
            }
        }


    }


}
