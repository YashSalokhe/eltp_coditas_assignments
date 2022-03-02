using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW_Asssignment_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employees emps = new Employees();
            Departments dep = new Departments();
            bool ans = true;
            do
            {
                Console.WriteLine("\n1.Print All Employees In Ascending Order of the EmpName\n" +
                                  "2.Print All Employees Group by the DeptName, and also display Employee Count for each DeptName\n" +
                                  "3.Find out Sum of Salary for Employess per DeptName\n" +
                                  "4.Print Employee with Max Salary Per DeptName\n" +
                                  "5.Print Employee with Min Salary Per DeptName\n" +
                                  "6.Print Average Salary Per DeptName\n" +
                                  "7.Print Employees by Designation Group\n" +
                                  "8.Display All EMployees those are Managers, Directors only\n" +
                                  "9.Print All EMployees Having Salary in Range 25000 to 75000\n" +
                                  "10.Print Employee with Second MAx Salary Per DeptName\n" +
                                  "11.Print Employee with Second Max Salary\n" +
                                  "12.Calculate Tax for Each Employee (Print All these Salaries DeptName Wise)\n" +
                                  "13.Join\n" +
                                  "14.Exit\n");
                int userInput = int.Parse(Console.ReadLine());
                switch (userInput)
                {
                    case 1:

                        Q1(emps);
                        break;

                    case 2:

                        Q2(emps);
                        break;

                    case 3:

                        Q3(emps);
                        break;

                    case 4:

                        Q4(emps);
                        break;

                    case 5:

                        Q5(emps);
                        break;

                    case 6:

                        Q6(emps);
                        break;

                    case 7:

                        Q7(emps);
                        break;

                    case 8:

                        Q8(emps);
                        break;

                    case 9:

                        Q9(emps);
                        break;

                    case 10:

                        Q10(emps);
                        break;

                    case 11:

                        Q11(emps);
                        break;

                    case 12:

                        Q12(emps);
                        break;

                    case 13:

                        Q13(emps , dep);
                        break;


                    case 14:
                        ans = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice..try again");
                        break;
                }
            }
            while (ans);
        }

        static void PrintResult(IEnumerable<Employee> emps)
        {
            foreach (var item in emps)
            {
                Console.WriteLine($"{item.EmpNo} {item.EmpName} {item.DeptName} {item.Designation} {item.Salary}");
            }
        }
        static void Q1(IEnumerable<Employee> emps)
        {
            var empNameAsc = emps.OrderBy(e => e.EmpName);
                                
            PrintResult(empNameAsc);

        }

        static void Q2(IEnumerable<Employee> emps)
        {
            var groupByDeptName = emps.GroupBy(e => e.DeptName);

            foreach(var emp in groupByDeptName)
            {
                Console.WriteLine(emp.Key);
                PrintResult(emp.ToList());
                Console.WriteLine($"\nThe count of Employees in {emp.Key} is {emp.Count()}");
            }
        }

        static void Q3(IEnumerable<Employee> emps)
        {
            var deptSal = emps.GroupBy(e => e.DeptName);
                            
            foreach(var dept in deptSal)
            {
                var sum = dept.Sum(e=>e.Salary);
                Console.WriteLine($"\nThe sum of salaries of {dept.Key} is {sum}");
            }
            //Console.WriteLine(sumSalary);
        }

        static void Q4(IEnumerable<Employee> emps)
        {
            var deptSal = emps.GroupBy(e => e.DeptName);
            foreach( var dept in deptSal)
            {
                var maxSal = dept.Max(e => e.Salary);
                Console.WriteLine($"The maximum salary of {dept.Key} is {maxSal} ");
            }
        }

        static void Q5(IEnumerable<Employee> emps)
        {
            var deptSal = emps.GroupBy(e => e.DeptName);
            foreach (var dept in deptSal)
            {
                var minSal = dept.Min(e => e.Salary);
                Console.WriteLine($"The minimum salary of {dept.Key} is {minSal} ");
            }
        }

        static void Q6(IEnumerable<Employee> emps) 
        {
            var deptSal = emps.GroupBy(e => e.DeptName);
            foreach (var dept in deptSal)
            {
                var avgSal = dept.Average(e => e.Salary);
                Console.WriteLine($"The average salary of {dept.Key} is {avgSal} ");
            }
        }

        static void Q7(IEnumerable<Employee> emps) 
        {
            var groupByDesignation = emps.GroupBy(e => e.Designation);

            foreach (var emp in groupByDesignation)
            {
                Console.WriteLine($"\nThe list of employees by Designation - {emp.Key}");
                PrintResult(emp.ToList());
                
            }
        }

        static void Q8(IEnumerable<Employee> emps) 
        {
           
            var groupByDesignation = emps.Where(e => e.Designation == "Manager" || e.Designation == "Director");
            PrintResult(groupByDesignation);
        }

        static void Q9(IEnumerable<Employee> emps) 
        {
            var rangeSal = emps.Where(e => e.Salary >= 25000 && e.Salary <= 75000)
                               .Select(x => x);
                               

            PrintResult(rangeSal);
           // Console.WriteLine(rangeSal);
        }


        static void Q10(IEnumerable<Employee> emps) 
        {
            
            var secondMaxEachDept = emps.OrderByDescending(e=>e.Salary).GroupBy(e=>e.DeptName).Select(e=>e.Skip(1).Take(1));
       
            foreach (var emp in secondMaxEachDept)
            {
               
                PrintResult(emp);
              
            }

        }

        static void Q11(IEnumerable<Employee> emps) 
        {
            var secondMax = emps.OrderByDescending(e=>e.Salary).Skip(1).Take(1);
            foreach (var emp in secondMax)
            {
                PrintResult(secondMax);
            }
        }

        static void Q12(IEnumerable<Employee> emps) 
        {
            var secondMaxEachDept = emps.GroupBy(e => e.DeptName);

            foreach (var emp in secondMaxEachDept)
            {
                var tax = emp.Where(e => e.Salary >= 20000 && e.Salary <= 40000)
                    .Select(x=>( x.Salary * 0.05)/100);
                //double tax = 0;
                //if( emp.Salary >= 20000 && emp.Salary <= 40000)
                //{
                //    tax = (emp.Salary * 0.05)/100;
                //}
                //else if( emp.Salary > 40000 && emp.Salary <= 60000)
                //{
                //    tax = (emp.Salary * 0.1) / 100;
                //}
                //else if(emp.Salary > 60000)
                //{
                //    tax = (emp.Salary * 0.15) / 100;
                //}
                //Console.WriteLine($"the tax to be paid by {emp.EmpName} of dept {emp.DeptName} is {tax}");
            }
                                        
        }

        static void Q13(IEnumerable<Employee> emps, IEnumerable<Department> dept) 
        {
            var join = from s in emps
                       join s1 in dept
                       on s.EmpNo equals s1.DeptNo
                       select new
                       {
                           EmployeeNo = s.EmpNo,
                           EmpName = s.EmpName,
                           Designation = s.Designation,
                           Depatment = s.DeptName,
                           Location = s1.Location,
                           salary = s.Salary
                       };
            foreach (var record in join)
            {
                Console.WriteLine($"{record.EmployeeNo} | {record.EmpName} |  {record.Designation} |  {record.Location} |  {record.Depatment} |  {record.salary}");
            }
        }
    }



    internal class Employee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public string DeptName { get; set; }
        public int Salary { get; set; }
        public string Designation { get; set; }
    }

    internal class Employees: List<Employee>
    {
        public Employees()
        {
            Add(new Employee() { EmpNo = 101, EmpName = "Mahesh", DeptName = "IT", Salary = 110000 , Designation ="Manager" });
            Add(new Employee() { EmpNo = 102, EmpName = "Tejas", DeptName = "HR", Salary = 120000 ,Designation = "Director"});
            Add(new Employee() { EmpNo = 103, EmpName = "Nandu", DeptName = "SL", Salary = 130000 , Designation = "Employee"});
            Add(new Employee() { EmpNo = 104, EmpName = "Anil", DeptName = "IT", Salary = 140000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 105, EmpName = "Jaywant", DeptName = "HR", Salary = 100000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 106, EmpName = "Abhay", DeptName = "SL", Salary = 90000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 107, EmpName = "Anil", DeptName = "IT", Salary = 80000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 108, EmpName = "Shyam", DeptName = "HR", Salary = 70000 , Designation = "Clerk" });
            Add(new Employee() { EmpNo = 109, EmpName = "Vikram", DeptName = "SL", Salary = 60000, Designation = "Director" });
            Add(new Employee() { EmpNo = 110, EmpName = "Suprotim", DeptName = "IT", Salary = 50000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 111, EmpName = "Yash", DeptName = "IT", Salary = 10000, Designation = "Director" });
            Add(new Employee() { EmpNo = 112, EmpName = "Mayur", DeptName = "HR", Salary = 12000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 113, EmpName = "Suyog", DeptName = "SL", Salary = 13000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 114, EmpName = "Harsh", DeptName = "IT", Salary = 14000, Designation = "Director" });
            Add(new Employee() { EmpNo = 115, EmpName = "Sasi", DeptName = "HR", Salary = 10000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 116, EmpName = "Ayush", DeptName = "SL", Salary = 29000, Designation = "Director" });
            Add(new Employee() { EmpNo = 117, EmpName = "Onkar", DeptName = "IT", Salary = 28000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 118, EmpName = "Shreya", DeptName = "HR", Salary = 37000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 119, EmpName = "Ankita", DeptName = "SL", Salary = 46000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 120, EmpName = "Jahanvi", DeptName = "IT", Salary = 65000, Designation = "Director" });
            Add(new Employee() { EmpNo = 121, EmpName = "Chitra", DeptName = "IT", Salary = 81000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 122, EmpName = "Manas", DeptName = "HR", Salary = 92000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 123, EmpName = "Satyam", DeptName = "SL", Salary = 13000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 124, EmpName = "Shreyash", DeptName = "IT", Salary = 14000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 125, EmpName = "Kshitij", DeptName = "HR", Salary = 40000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 126, EmpName = "Shashank", DeptName = "SL", Salary = 8000, Designation = "Director" });
            Add(new Employee() { EmpNo = 127, EmpName = "Tanmay", DeptName = "IT", Salary = 98000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 128, EmpName = "Sahil", DeptName = "HR", Salary = 75000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 129, EmpName = "Labhesh", DeptName = "SL", Salary = 66000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 130, EmpName = "Gatagat", DeptName = "IT", Salary = 55000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 131, EmpName = "Varad", DeptName = "IT", Salary = 19000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 132, EmpName = "Gaurav", DeptName = "HR", Salary = 22000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 133, EmpName = "Athul", DeptName = "SL", Salary = 23000, Designation = "Director" });
            Add(new Employee() { EmpNo = 134, EmpName = "Paras", DeptName = "IT", Salary = 74000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 135, EmpName = "Vishakha", DeptName = "HR", Salary = 20000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 136, EmpName = "Aarohi", DeptName = "SL", Salary = 92000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 137, EmpName = "Vaishnavi", DeptName = "IT", Salary = 28000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 138, EmpName = "Gauri", DeptName = "HR", Salary = 37000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 139, EmpName = "Srushti", DeptName = "SL", Salary = 46000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 140, EmpName = "Sinori", DeptName = "IT", Salary = 57000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 141, EmpName = "Urvika", DeptName = "IT", Salary = 41000, Designation = "Director" });
            Add(new Employee() { EmpNo = 142, EmpName = "Chaitanya", DeptName = "HR", Salary = 2000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 143, EmpName = "Manasi", DeptName = "SL", Salary = 63000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 144, EmpName = "Varun", DeptName = "IT", Salary = 94000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 145, EmpName = "Himaja", DeptName = "HR", Salary = 10000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 146, EmpName = "Akshada", DeptName = "SL", Salary = 9000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 147, EmpName = "Sujeet", DeptName = "IT", Salary = 8000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 148, EmpName = "Suraj", DeptName = "HR", Salary = 70600, Designation = "Manager" });
            Add(new Employee() { EmpNo = 149, EmpName = "Kittu", DeptName = "SL", Salary = 60800, Designation = "Employee" });
            Add(new Employee() { EmpNo = 150, EmpName = "Shubham", DeptName = "IT", Salary = 55000, Designation = "Director" });
        }

    }


    internal class Department
    {
        public int DeptNo { get; set; }
        public string Location { get; set; }
        public string DeptName { get; set; }
        public int Capacity { get; set; }

    }
    internal class Departments : List<Department>
    {
        public Departments()
        {
            Add(new Department() { DeptNo = 101, DeptName = "HR", Location = "Pune", Capacity = 200 });
            Add(new Department() { DeptNo = 102, DeptName = "SL", Location = "Mumbai", Capacity = 400 });
            Add(new Department() { DeptNo = 103, DeptName = "IT", Location = "Hyderabad", Capacity = 700 });
            Add(new Department() { DeptNo = 104, DeptName = "HR", Location = "USA", Capacity = 200 });
            Add(new Department() { DeptNo = 105, DeptName = "SL", Location = "Banglore", Capacity = 200 });
            Add(new Department() { DeptNo = 106, DeptName = "IT", Location = "Delhi", Capacity = 200 });
            Add(new Department() { DeptNo = 107, DeptName = "HR", Location = "Nagur", Capacity = 200 });
            Add(new Department() { DeptNo = 108, DeptName = "SL", Location = "Jalgaon", Capacity = 200 });
            Add(new Department() { DeptNo = 109, DeptName = "HR", Location = "Hinjewadi", Capacity = 200 });
            Add(new Department() { DeptNo = 110, DeptName = "SL", Location = "Chinchwad", Capacity = 200 });
        }
    }

}
