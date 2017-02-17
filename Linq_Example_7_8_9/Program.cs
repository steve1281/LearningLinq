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
            /* projection, from/from, and selectmany
             */
            Console.WriteLine("lessons 7 8 9\n".ChangeFirstLetterCase());
            ExampleClass testing = new ExampleClass();
            testing.FromFromExample();
            Console.WriteLine("\n");
            testing.SelectManyExample();
            Console.WriteLine("\n");
            testing.GetSubjectsQuery();
            Console.WriteLine("\n");
            testing.GetSubjects();
            Console.WriteLine("\n");
            testing.MergeStringArrays();
            Console.WriteLine("\n");
            testing.MergeStringArraysQuery();
            Console.WriteLine("\n");
            testing.EmployeeSelectProject();
            Console.WriteLine("\n");
            testing.MaleEmployees();
            Console.WriteLine("\n");
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
    }

    // Class with Examples
    public class ExampleClass
    {
        Context db = Context.Instance;

        
        public void FromFromExample()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            var student_info = from student in db.Students
                               from subject in student.Subjects
                               select new { StudentName = student.Name, SubjectName = subject };
            foreach(var entry in student_info)
            {
                Console.WriteLine($"{entry.StudentName}/{entry.SubjectName}");
            }

        }
        public void SelectManyExample()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            var student_info = db.Students
                                .SelectMany(s => s.Subjects, 
                                (student, subject) => new { StudentName = student.Name, SubjectName = subject });

            foreach (var entry in student_info)
            {
                Console.WriteLine($"{entry.StudentName}/{entry.SubjectName}");
            }
        }
        public void GetSubjectsQuery()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            // each s will have a list of subjects, so  from/from 
            var subjects = (from s in db.Students from c in s.Subjects select c).Distinct();
            Console.WriteLine(string.Join(", ",subjects));

        }
        public void GetSubjects()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            // use selectmany to flatten - each student has subjects...
            var subjects = db.Students.SelectMany(s => s.Subjects).Distinct();
            Console.WriteLine(string.Join(", ", subjects));
        }
        public void MergeStringArraysQuery()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            string[] stringArray =
            {
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                "0123456789"
            };
            var merged = from s in stringArray from a in s select a;
            Console.WriteLine(string.Join(", ",merged));
        }
        public void MergeStringArrays()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            string[] stringArray =
            {
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                "0123456789"
            };
            var merged = stringArray.SelectMany(s => s);
            Console.WriteLine(string.Join(", ", merged));
        }
        public void EmployeeSelectProject()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            var output = db.Employees
                        .Where(n => n.AnnualSalary > 40000)
                        .Select(emp => new
                        {
                            FullName = emp.FirstName + " " + emp.LastName,
                            emp.AnnualSalary,
                            Bonus = emp.AnnualSalary * 0.1
                        });
            foreach (var data in output)
            {
                Console.WriteLine($"{data.FullName} {data.AnnualSalary} {data.Bonus}");
            }
        }
        public void MaleEmployees()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            var output = db.Employees.Where(n => n.Gender == "Male").Select(n => n.FirstName + " " + n.LastName);
            foreach (var data in output)
            {
                Console.WriteLine(string.Join(", ",data));
            }
        }

    }


}
