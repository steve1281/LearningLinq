
using System.Collections.Generic;
using LearningLinq.Serialization;

namespace LearningLinq.DataSources
{
    public class FakeDB
    {
    }

    // Fake DB context, customizable
    public class Context
    {
        const string DB_FOLDER = @"C:\git projects\database\";

        public List<Employee> Employees = new List<Employee>();
        public List<Student> Students = new List<Student>();
        public List<Department> Departments = new List<Department>();


        private Context()
        {
            Init(); // set up database 
            //LoadDatabase(); // load database into core memory.
        }

        // singleton
        private static Context instance = null;
        public static Context Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Context();
                }
                return instance;
            }
        }

        // initialize the database
        public void Init()
        {

            Students.Add(new Student { ID = 101, Name = "Mark", Gender = "Male", Subjects = new List<string> { "ASP.NET", "C#" }, TotalMarks = 800 });
            Students.Add(new Student { ID = 102, Name = "Mary", Gender = "Female", Subjects = new List<string> { "ADO.NET", "C#", "AJAX" }, TotalMarks = 900 });
            Students.Add(new Student { ID = 103, Name = "Pam", Gender = "Female", Subjects = new List<string> { "WCF", "SQL Server", "C#" }, TotalMarks = 700 });
            Students.Add(new Student { ID = 104, Name = "John", Gender = "Male", Subjects = new List<string> { "WPF", "LINQ", "ASP.NET" }, TotalMarks = 600 });
            Students.Add(new Student { ID = 105, Name = "Henry", Gender = "Male", Subjects = new List<string> { "ASP.NET", "C#" }, TotalMarks = 800 });
            Students.Add(new Student { ID = 106, Name = "Sue", Gender = "Female", Subjects = new List<string> { "ADO.NET", "C#", "AJAX" }, TotalMarks = 900 });
            Students.Add(new Student { ID = 107, Name = "Sharon", Gender = "Female", Subjects = new List<string> { "WCF", "SQL Server", "C#" }, TotalMarks = 700 });
            Students.Add(new Student { ID = 108, Name = "Frank", Gender = "Male", Subjects = new List<string> { "WPF", "LINQ", "ASP.NET" }, TotalMarks = 600 });
            Students.Add(new Student { ID = 109, Name = "Bill", Gender = "Male", Subjects = new List<string> { "ASP.NET", "C#" }, TotalMarks = 800 });
            Students.Add(new Student { ID = 110, Name = "Linda", Gender = "Female", Subjects = new List<string> { "ADO.NET", "C#", "AJAX" }, TotalMarks = 900 });
            Students.Add(new Student { ID = 111, Name = "Glenda", Gender = "Female", Subjects = new List<string> { "WCF", "SQL Server", "C#" }, TotalMarks = 700 });

            Employees.Add(new Employee { EmployeeID = 101, FirstName = "Joe", LastName = "Smith", Gender = "Male", AnnualSalary = 30000, DepartmentID = 1 });
            Employees.Add(new Employee { EmployeeID = 102, FirstName = "Mary", LastName = "Jane", Gender = "Female", AnnualSalary = 32000, DepartmentID = 2 });
            Employees.Add(new Employee { EmployeeID = 103, FirstName = "Billy", LastName = "Franklin", Gender = "Male", AnnualSalary = 36000, DepartmentID = 2 });
            Employees.Add(new Employee { EmployeeID = 104, FirstName = "Sue", LastName = "Ellen", Gender = "Female", AnnualSalary = 66000, DepartmentID = 1 });
            Employees.Add(new Employee { EmployeeID = 105, FirstName = "Bob", LastName = "Wiliams", Gender = "Male", AnnualSalary = 55000, DepartmentID = 3 });
            Employees.Add(new Employee { EmployeeID = 101, FirstName = "George", LastName = "Smith", Gender = "Male", AnnualSalary = 30000, DepartmentID = 1 });
            Employees.Add(new Employee { EmployeeID = 102, FirstName = "Linda", LastName = "Jane", Gender = "Female", AnnualSalary = 32000, DepartmentID = 2 });
            Employees.Add(new Employee { EmployeeID = 103, FirstName = "Glenda", LastName = "Franklin", Gender = "Male", AnnualSalary = 36000, DepartmentID = 2 });
            Employees.Add(new Employee { EmployeeID = 104, FirstName = "Karen", LastName = "Ellen", Gender = "Female", AnnualSalary = 66000, DepartmentID = 1 });
            Employees.Add(new Employee { EmployeeID = 105, FirstName = "Frank", LastName = "Wiliams", Gender = "Male", AnnualSalary = 55000, DepartmentID = 3 });


            Departments.Add(new Department { ID = 1, Name = "IT", Location = "New York" });
            Departments.Add(new Department { ID = 2, Name = "HR", Location = "London" });
            Departments.Add(new Department { ID = 3, Name = "Payroll", Location = "Sydney" });

            //SaveChanges(); // overwrite database
        }

        
        public void SaveChanges()
        {
            throw new System.Exception("NotImplemented");
            Serializer serzer = new Serializer();
            serzer.SerializeObject<List<Employee>>(Employees, DB_FOLDER + "employees.xml");
            serzer.SerializeObject<List<Department>>(Departments, DB_FOLDER + "departments.xml");
            serzer.SerializeObject<List<Student>>(Students, DB_FOLDER + "students.xml");
        }
        public void LoadDatabase()
        {
            throw new System.Exception("NotImplemented");
            Serializer serzer = new Serializer();
            Employees = serzer.DeSerializeObject<List<Employee>>(DB_FOLDER +  "employees.xml");
            Departments = serzer.DeSerializeObject<List<Department>>(DB_FOLDER + "departments.xml");
            Students = serzer.DeSerializeObject<List<Student>>(DB_FOLDER + "students.xml");

        }

    }

    // data classes for fake Database
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int AnnualSalary { get; set; }
        public int DepartmentID { get; set; }
    }
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public List<string> Subjects { get; set; }
        public int TotalMarks { set; get; }
    }

    public class Department
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Location { set; get; }
    }

 
}

