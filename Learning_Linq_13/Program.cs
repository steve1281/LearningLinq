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
            Console.WriteLine("lesson 13\n".ChangeFirstLetterCase());
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
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            Context db = Context.Instance;
            /*
            Implement paging using skip and take, in an infinite loop, with error checking.
            */
            IEnumerable<Student> students = db.Students;


            string input = null;
            while (input != "quit")
            {
                Console.WriteLine("Please enter page number - 1,2,3 or 4 (or quit)");
                int pageNumber = 0;
                input = Console.ReadLine();
                if (input.Trim() == "quit") break;
                if (int.TryParse(input, out pageNumber))
                {
                    if (pageNumber > 0 && pageNumber < 5)
                    {
                        int pageSize = 3;
                        IEnumerable<Student> result = students.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
                        Console.WriteLine($"\nDisplay page {pageNumber}");
                        foreach (Student s in result)
                        {
                            Console.WriteLine($"{s.ID}\t{s.Name}\t{s.TotalMarks}");
                        }
                        Console.WriteLine("\n");
                    }
                    else
                    {
                        Console.WriteLine($"{input} is not a number between 1-4");
                    }

                }
                else
                {
                    Console.WriteLine($"{input} is not a number");
                }

            }
        }
    }

}
 