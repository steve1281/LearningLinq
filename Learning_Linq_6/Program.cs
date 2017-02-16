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
		Restrictions - ie Where
		Note: Where has two overloads
		Example:
		Where(this IEnumerable, Func<int, bool> predicate)
		-> first param type, and output is bool
		(x => x % 2 == 0)  // takes an int x, evaluates a boolean
		
		Where(this IEnumerable, Func<int, int, bool> predicate)
		The second int param represents the index position, in the IEnumerable.
		-> Select also has this overload.
		
		(recall the "this" identifies this as a extension method)
		*/
        public static void Main()
        {
            Console.WriteLine("lesson 6\n".ChangeFirstLetterCase());
            ExampleClass testing = new ExampleClass();
            testing.WhereWithOr();
            Console.WriteLine();
            testing.EvenNumbersAndIndex();
            Console.WriteLine();
            testing.EvenNumbersLocalDelegate();
            Console.WriteLine();
            testing.EvenNumbersLocalDelegateExternalPredicate();
            Console.WriteLine();
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
    }

    // Class with Examples
    public class ExampleClass
    {
        Context db = Context.Instance;

        public void WhereWithOr()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            var depts =  db.Departments.Where(x => x.Name == "IT" || x.Name == "HR");
            foreach (var dept in depts)
            {
                Console.WriteLine($"{dept.ID} : {dept.Name} at {dept.Location}");
            }
            
        }

        public void EvenNumbersAndIndex()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var output = numbers
                            .Select((Number, Index) => new { Number, Index })
                            .Where(n => n.Number % 2 == 0);
            foreach (var entry in output)
            {
                Console.WriteLine($"Index:{entry.Index} Value: {entry.Number}");
            }
            
        }

        // with a local delegate
        public void EvenNumbersLocalDelegate()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Func<int, bool> pred = n => n % 2 == 0;

            var output = numbers.Where(x => pred(x));

            Console.WriteLine(string.Join(",", output));

        }

        // with an external method
        private bool predicate(int n)
        {
            return n % 2 == 0;
        }
        public void EvenNumbersLocalDelegateExternalPredicate()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var output = numbers.Where(x => predicate(x));

            Console.WriteLine(string.Join(",", output));
        }
    }


}
