using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MiniProject1.Models
{
    public class Client
    {
        EmployeeOpeartions operation = new EmployeeOpeartions();
        List<Employee> employees = new List<Employee>();
       
        

        public void AddEmployee()
        {
            Employee emp = operation.AcceptEmployeeData();
            employees = operation.AddEmployee(emp);
        }

        public void DisplayData()
        {
            operation.PrintEmployees(ref employees);
        }

        public void UpdateEmployee()
        {
            Console.WriteLine("Employee number of the employee which you want to update");
            int id = int.Parse(Console.ReadLine());
            name:
            Console.WriteLine("Updated name");
            string updatedName = Console.ReadLine();
            string regex = @"^[A-Z][a-z]+\s[A-Z][a-z]+$";
            Regex rx = new Regex(regex);
            if (rx.IsMatch(updatedName))
            {
                employees = operation.UpdateEmployee(employees, id, updatedName);
            }
            else
            {
                Console.WriteLine("Must start from Uppercase Character and shouldn't contain special characters\n");
                goto name;
            }
        }

        public void DeleteEmployee()
        {
            Console.WriteLine("Employee number of the employee which you want to delete");
            int delete_id = int.Parse(Console.ReadLine());
            employees = operation.DeleteEmployee(employees, delete_id);
         
        }

        public void ListEmployeesDeptName()
        {
            Console.WriteLine("Enter dept name");
            dept:
            string deptName = Console.ReadLine();
            if(deptName == "IT" || deptName == "HRD" || deptName == "Sales" || deptName == "Admin" || deptName == "Account")
            {
                operation.ListEmployeeByDeptName(employees, deptName);
            }
            else
            {
                Console.WriteLine("Enter Valid DeptName (IT, HRD, Sales, Admin, Account)\n");
                goto dept;
            }
        }

        public void ListEmployeesDesignation()
        {
            Console.WriteLine("Enter designation");
            design:
            string designation = Console.ReadLine();
            if (designation == "Manager" || designation == "Engineer" || designation == "Clerk" || designation == "Staff")
            {
                operation.ListEmployeeByDesignation(employees, designation);
            }
            else
            {
                Console.WriteLine("Enter Valid Designation (Manager, Engineer, Clerk, Staff)");
                goto design;
            }
        }

        public void SearchEmployeeById()
        {
            Console.WriteLine("Enter Employee Id");
            int Empid = int.Parse(Console.ReadLine());
            operation.SearchEmployee(employees,Empid);
        }
    }
}
