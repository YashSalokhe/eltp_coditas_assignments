using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using System.Text;
using Assignment_5.Models;

namespace Assignment_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            taskException t = new taskException();
            Employees emps = new Employees();
            Departments dep = new Departments();
            EmpDepts empdept = new EmpDepts();
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

                        var temp =t.Q5(emps);
                        Console.WriteLine(temp.Exception);
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

                        Q13(empdept,dep);
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

            foreach (var emp in groupByDeptName)
            {
                Console.WriteLine(emp.Key);
                PrintResult(emp.ToList());
                Console.WriteLine($"\nThe count of Employees in {emp.Key} is {emp.Count()}");
            }
        }

        static void Q3(IEnumerable<Employee> emps)
        {
            var deptSal = emps.GroupBy(e => e.DeptName);

            foreach (var dept in deptSal)
            {
                var sum = dept.Sum(e => e.Salary);
                Console.WriteLine($"\nThe sum of salaries of {dept.Key} is {sum} ");
            }
   
        }

        static void Q4(IEnumerable<Employee> emps)
        {
            var deptSal = emps.OrderByDescending(e => e.Salary).GroupBy(e => e.DeptName).Select(e => e.Take(1)); 

            
            foreach (var dept in deptSal)
            {
                PrintResult(dept);
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

            var secondMaxEachDept = emps.OrderByDescending(e => e.Salary).GroupBy(e => e.DeptName).Select(e => e.Skip(1).Take(1));

            foreach (var emp in secondMaxEachDept)
            {

                PrintResult(emp);

            }

        }

        static void Q11(IEnumerable<Employee> emps)
        {
            var secondMax = emps.OrderByDescending(e => e.Salary).Skip(1).Take(1);
            foreach (var emp in secondMax)
            {
                PrintResult(secondMax);
            }
        }

        static void Q12(IEnumerable<Employee> emps)
        {
            var calculateTax = (from e in emps
                                group e by e.DeptName into deptGroup
                                select new
                                {
                                    DeptName = deptGroup.Key,
                                    Records = deptGroup.ToList()
                                }
                                );


            foreach (var empst in calculateTax)
            {
               
                foreach (var temp in empst.Records)
                {
                    double tax = 0;
                    if (temp.Salary >= 20000 && temp.Salary <= 40000)
                    {
                        tax = (temp.Salary * 0.05) / 100;
                        Console.WriteLine($"Tax to be paid by {temp.EmpName} of {temp.DeptName} having salary {temp.Salary}/- is {Math.Round(tax)}/- rupees");
                    }

                    if (temp.Salary > 40000 && temp.Salary <= 60000)
                    {
                        tax = (temp.Salary * 0.1) / 100;
                        Console.WriteLine($"Tax to be paid by {temp.EmpName} of {temp.DeptName} having salary {temp.Salary}/- is {Math.Round(tax)}/- rupees");
                    }

                    if (temp.Salary > 60000 )
                    {
                        tax = (temp.Salary * 0.15) / 100;
                        Console.WriteLine($"Tax to be paid by {temp.EmpName} of {temp.DeptName} having salary {temp.Salary}/- is {Math.Round(tax)}/- rupees");
                    }

                    else
                    {
                        Console.WriteLine($"Tax to be paid by {temp.EmpName} of {temp.DeptName} having salary {temp.Salary}/- is {Math.Round(tax)}/- rupees");
                    }
                }
            }

        }

        static void Q13(IEnumerable<EmpDept> emps , IEnumerable<Department> dept)
        {

            var join = from s in emps
                       join s1 in dept
                       on s.DeptNo equals s1.DeptNo
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
    
}
