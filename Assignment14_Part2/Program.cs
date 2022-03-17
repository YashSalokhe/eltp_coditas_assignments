// See https://aka.ms/new-console-template for more information
using Assignment14_Part1.Models;
using Assignment14_Part1.DataAccess;
using System.Text.Json;

bool ans = true;

IDataAccess<Department, int> dept = new DepartmentDataAccess();
IDataAccess<Employee, int> emp = new EmployeeDataAccess();
do
{
    Console.WriteLine("\nEnter your choice\n" +
                        "1.Add employee to employee table\n" +
                        "2.Read Employee from table\n" +
                        "3.Update Employee from employee table\n" +
                        "4.Delete Employee from employee table\n" +
                        "5.Add departmemt to department table\n" +
                        "6.Read Department from table\n" +
                        "7.Update Department from Department table\n" +
                        "8.Delete Department from Department table\n" +
                        "9.EXIT");
    int userInput = Convert.ToInt32(Console.ReadLine());
    switch (userInput)
    {
        case 1:
            Console.WriteLine("Enter Employee number\n");
            int No = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employee name\n");
            string? Name = Console.ReadLine();
            Console.WriteLine("Enter Designation\n");
            string? Design = Console.ReadLine();
            Console.WriteLine("Enter Salary");
            int salary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter department number\n");
            int deptNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Email\n");
            string? email = Console.ReadLine();
            Employee employee = new()
            {
                DeptNo = deptNo,
                EmpNo = No,
                EmpName = Name,
                Designation = Design,
                Salary = salary,
                Email = email
            };
            emp.CreateAsync(employee);
            break;

        case 2:

            var resRead = emp.GetAsync();
            Console.WriteLine("\n" + JsonSerializer.Serialize(resRead));
            break;

        case 3:
            Console.WriteLine("Enter Employee number to update\n");
            int UpdatedNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter updated Employee name\n");
            string? UpdatedName = Console.ReadLine();
            Console.WriteLine("Enter updated Designation\n");
            string? UpdatedDesign = Console.ReadLine();
            Console.WriteLine("Enter updated Salary");
            int Updatedsalary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter updated department number\n");
            int UpdateddeptNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter updated Email\n");
            string? Updatedemail = Console.ReadLine();
            Employee Updatedemployee = new()
            {
                DeptNo = UpdateddeptNo,
                EmpNo = UpdatedNo,
                EmpName = UpdatedName,
                Designation = UpdatedDesign,
                Salary = Updatedsalary,
                Email = Updatedemail
            };
            emp.UpdateAsync(UpdatedNo, Updatedemployee);
            break;

        case 4:

            Console.WriteLine("Enter employee number to delete\n");
            int delEmp = Convert.ToInt32(Console.ReadLine());
            var resultDelEmp = emp.DeleteAsync(delEmp);
            break;

        case 5:

            Console.WriteLine("Enter Department number\n");
            int depNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter department Name\n");
            string? depName = Console.ReadLine();
            Console.WriteLine("Enter capacity\n");
            int capacity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter location\n");
            string? location = Console.ReadLine();

            Department deptartment = new()
            {
                DeptNo = depNo,
                DeptName = depName,
                Location = location,
                Capacity = capacity
            };
            dept.CreateAsync(deptartment);
            break;

        case 6:

            var resReaddept = dept.GetAsync();
            Console.WriteLine(JsonSerializer.Serialize(resReaddept));
            break;

        case 7:

            int UpdateddepNo = Convert.ToInt32(Console.ReadLine());
            string? UpdateddepName = Console.ReadLine();
            int Updatedcapacity = Convert.ToInt32(Console.ReadLine());
            string? Updatedlocation = Console.ReadLine();

            Department Updateddeptartment = new()
            {
                DeptNo = UpdateddepNo,
                DeptName = UpdateddepName,
                Location = Updatedlocation,
                Capacity = Updatedcapacity
            };
            dept.UpdateAsync(UpdateddepNo, Updateddeptartment);
            break;

        case 8:

            Console.WriteLine("Enter Department number to delete\n");
            int delDept = Convert.ToInt32(Console.ReadLine());
            var resultDelDept = emp.DeleteAsync(delDept);
            break;
        case 9:
            ans = false;
            break;
        default:
            Console.WriteLine("Invalid choice....try again");
            break;
    }
} while (ans == true);
