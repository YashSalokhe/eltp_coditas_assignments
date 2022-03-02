using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assinment_8.DataAccess;
using Assinment_8.Models;

namespace Assinment_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool ans = false;
            IDataAccessCrud<Employee, int> data = new EmployeeDataAccess();
            IDataAccess<Employee,string> report = new Report();

            do
            {
                Console.WriteLine("\n1.Read all data from Employee table\n" +
                              "2.Insert Data in Employee Table\n" +
                              "3.Update Data from Employee Table\n" +
                              "4.Delete data from Employee table\n" +
                              "5.Get All Employees By DeptName\n" +
                              "6.Get All Employees With Max Salary By DeptName\n" +
                              "7.Get Sum Salary By DeptName\n" +
                              "8.Get All Employees By Location\n" +
                              "9.Exit\n");
                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        var employees = data.GetAllData();
                        foreach(var employee in employees)
                        {
                            Console.WriteLine($"{employee.EmpNo}\t{employee.EmpName}\t{employee.Salary}\t{employee.Designation}\t{employee.DeptNo}\t{employee.Email}");
                        }
                        break;

                    case 2:

                        Console.WriteLine("Enter Employee No");
                        int no = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Employee name");
                        string name = Console.ReadLine();

                        Console.WriteLine("Enter Salary");
                        int Salary = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Dept number");
                        int DeptNo = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Designation");
                        string Designation = Console.ReadLine();

                        Console.WriteLine("Enter Email");
                        string Email = Console.ReadLine();

                        var newEmp = new Employee()
                        {
                            EmpNo = no,
                            EmpName = name,
                            Salary = Salary,
                            Designation = Designation,
                            DeptNo = DeptNo,
                            Email = Email

                        };
                        var result = data.Create(newEmp);
                        if (result == null) { Console.WriteLine("Employee addition failed"); }
                        else { Console.WriteLine("Employee added sucessfully\n"); }
                        break;

                    case 3:

                        Console.WriteLine("Enter Employee Id to be updated");
                        int id = int.Parse(Console.ReadLine());


                        Console.WriteLine("Enter Updated Employee name");
                        string Updatedname = Console.ReadLine();

                        Console.WriteLine("Enter Updated Salary");
                        int UpdatedSalary = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Updated Dept number");
                        int UpdatedDeptNo = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Updated Designation");
                        string UpdatedDesignation = Console.ReadLine();

                        Console.WriteLine("Enter Updated Email");
                        string UpdatedEmail = Console.ReadLine();

                        var UpdatednewEmp = new Employee()
                        {
                            EmpNo = id,
                            EmpName = Updatedname,
                            Salary = UpdatedSalary,
                            Designation = UpdatedDesignation,
                            DeptNo = UpdatedDeptNo,
                            Email = UpdatedEmail

                        };
                        var Updatedresult = data.Update(id ,UpdatednewEmp);
                        if (Updatedresult == null) { Console.WriteLine("Employee updation failed"); }
                        else { Console.WriteLine("Employee updated sucessfully\n"); }

                        break;

                    case 4:

                        Console.WriteLine("Enter Employee Id to be Deleted");
                        int Delete_id = int.Parse(Console.ReadLine());
                        var Deletedresult = data.Delete(Delete_id);
                        if (Deletedresult == null) { Console.WriteLine("Employee Deletion failed"); }
                        else { Console.WriteLine("Employee deleted sucessfully\n"); }
                        break;

                    case 5:
                        Console.WriteLine("Enter the department whose employees you want to find");
                        string input = Console.ReadLine();
                        report.GetAllEmployeesByDeptName(input);
                       
                        break;

                    case 6:

                       Console.WriteLine("Enter the department whose Max salary you want to find");
                        string inputDept = Console.ReadLine();
                        report.GetAllEmployeesWithMaxSalByDeptName(inputDept);
                        break;

                    case 7:

                        Console.WriteLine("Enter the department whose sum salary you want to find");
                        string inputDeptsum = Console.ReadLine();
                        report.GetSumSalaryByDeptName(inputDeptsum);
                        break;

                    case 8:

                        Console.WriteLine("Enter the location to search for employee");
                        string location = Console.ReadLine();
                        report.GetAllEmployeesByLocation(location);
                        break;
                    case 9:
                        ans = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice!!Enter valid input");
                        break;
                }

            }
            while(ans == false);
           // Console.ReadLine();
        }
    }
}
