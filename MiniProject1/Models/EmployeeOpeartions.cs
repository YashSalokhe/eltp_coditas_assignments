using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MiniProject1.Models
{

    internal class EmployeeOpeartions
    {

        //Temp list
        private List<Employee> Employees;


        public EmployeeOpeartions()
        {
            Employees = new List<Employee>();
        }


        public Employee AcceptEmployeeData()
        {
            Start:
            Employee employee = new Employee();
            Console.WriteLine("Enter EmpNo");
            employee.EmpNo = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter EmpName");
            employee.EmpName = Console.ReadLine();
            Console.WriteLine("Enter DeptName");
            employee.DeptName = Console.ReadLine();
            Console.WriteLine("Enter Designation");
            employee.Designation = Console.ReadLine();
            Console.WriteLine("Enter Salary");
            employee.Salary = Convert.ToInt32(Console.ReadLine());
            string ans = isValidate(Employees, employee.EmpNo, employee.EmpName, employee.DeptName, employee.Designation, employee.Salary);
            if (ans != "")
            {
                Console.WriteLine(ans);
                //employee.EmpNo = 0;
                //employee.EmpName = "";
                //employee.DeptName = "";
                //employee.Designation = "";
                //employee.Salary = 0;
                //AcceptEmployeeData();
                //return employee;
                goto Start;
            }
            else
            {
                return employee;
            }
            
             
        }

        public void PrintEmployees(ref List<Employee> emps)
        {
            Console.WriteLine("EmpNo \t\t EmpName \t DeptName \t Designation \t Salary");
            foreach (Employee emp in emps)
            {
                Console.WriteLine($"{emp.EmpNo} \t\t {emp.EmpName} \t\t {emp.DeptName} \t\t {emp.Designation} \t\t {emp.Salary}");
            }
        }

        public List<Employee> AddEmployee(Employee emp)
        {
            Employees.Add(emp);
            //return Employees;

           

            Dictionary<string, Employee> dic = new Dictionary<string, Employee>();
            dic.Add(emp.DeptName, emp);
            //foreach (var items in dic)
            //{
            //    Console.WriteLine("{0} and {1},{2},{3},{4}",
            //                items.Key, items.Value.EmpNo,items.Value.EmpName,items.Value.Designation,items.Value.Salary);
            //}
            return Employees;
        }

        public List<Employee> UpdateEmployee(List<Employee> emp , int empNo , string updatedName)
        {
               Employees = emp;
            try
            {   foreach (Employee employee in Employees)
                {
                    if(employee.EmpNo == empNo)
                    {
                       // employee = AcceptEmployeeData();
                        employee.EmpName = updatedName;
                     
                        return Employees;
                    }
                }
 
                    throw new Exception($"Employee with {empNo} does not exist");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Occured {ex.Message}");
            }
            return Employees;
        }

        public List<Employee> DeleteEmployee(List<Employee> emp, int empNo)
        {

            Employees = emp;
            try
            {
                foreach (Employee employee in Employees)
                {
                    if (employee.EmpNo == empNo)
                    {
                        Employees.Remove(employee);

                        return Employees;

                    }

                }

                throw new Exception($"Employee with {empNo} does not exist");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Occured {ex.Message}");
            }
            return Employees;
        }

        public void ListEmployeeByDeptName(List<Employee> emp , string deptName)
        {

            foreach(Employee employee in emp)
            {
                if(employee.DeptName == deptName)
                {
                    Console.WriteLine($"{employee.EmpName}");
                    return;
                }
            }
            Console.WriteLine("Is not present\n");

        }

        public void ListEmployeeByDesignation(List<Employee> emp, string designation)
        {
            foreach (Employee employee in emp)
            {
                if (employee.Designation == designation)
                {
                    Console.WriteLine($"{employee.EmpName}");
                    return;

                }
            }
            Console.WriteLine("Is not present\n");
        }

        public void SearchEmployee(List<Employee>emp,int id)
        {
            foreach( Employee employee in emp)
            {
                if (employee.EmpNo == id)
                {
                    Console.WriteLine($"Employee {id} exist");
                    Console.WriteLine($"{employee.EmpName} , {employee.DeptName} , {employee.Designation} , {employee.Salary}");
                    return;
                }
            }
            Console.WriteLine($"Employee {id} does not exist");
            
        }

        public string isValidate(List<Employee> emp,int empId,string empName,string empDept,string empDesig,int salary)
        {
            //bool isID = true;
            string isMsgId = "";
            if (empId > 0)
            {
                foreach(Employee employees in emp)
                {
                    if(employees.EmpNo == empId)
                    {
                       // isID = false;
                        isMsgId = "Employee ID cannot be repeated\n";
                        break;
                    }
                }
            }
            if(empId < 0)
            {
                isMsgId = "Employee ID cannot be negative\n";
            }


            //bool isName = true;
            //+\s[A-Z][a-z]+$
            string regex = @"^[A-Z][a-z]";
            Regex rx = new Regex(regex);
            string isMsgName = "Must start from Uppercase Character and shouldn't contain special characters\n";
            if (rx.IsMatch(empName))
            {
                isMsgName = "";
            }

            //bool isDept = false;
            string isMsgDept = "Enter valid Department name (IT, HRD, Sale, Admin, Account)\n";
            if (empDept == "IT"|| empDept == "HRD"||empDept == "Sales"||empDept == "Admin"||empDept == "Account")
            {
              //  isDept = true;
                isMsgDept = "";
            }

            //bool isDesign = false;
            string isMsgDesign = "Enter valid Designation (Manager, Engineer, Clerk, Staff\n)";
            if (empDesig == "Manager" || empDesig == "Engineer" || empDesig == "Clerk" || empDesig == "Staff")
            {
               // isDesign = true;
                isMsgDesign = "";
            }

           // bool isSalary = false;
            string isMsgSalary = "Salary must be a positive integer";
            if (salary > 0)
            {
                //isSalary = true;
                isMsgSalary = "";
            }
            
            

            
             return isMsgId + isMsgName + isMsgDept + isMsgDesign + isMsgSalary;
            
        }

    }
}