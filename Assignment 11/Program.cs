using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_11.DataAccess;
using Assignment_11.Models;

namespace Assignment_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeDataAccess employeeDataAccess = new EmployeeDataAccess();
            DepartmentDataAccess departmentDataAccess = new DepartmentDataAccess();
            bool condition = false;
            //Console.ReadLine();
            do {
                Console.WriteLine("\n1.Read Employee\n" +
                                  "2.Insert Employee\n" +
                                  "3.Update Employee\n" +
                                  "4.Delete Employee\n" +
                                  "5.Read Department\n" +
                                  "6.Insert Department\n" +
                                  "7.Update Department\n" +
                                  "8.Delete Department\n" +
                                  "9.Exit");
                int userInput = Convert.ToInt32(Console.ReadLine());
                switch (userInput)
                {
                    case 1:
                        //GET DATA Employees
                        var ans = employeeDataAccess.GetEmpDataAsync().Result;
                        foreach (var item in ans)
                        {
                            Console.WriteLine($"{item.EmpNo} {item.EmpName} {item.Salary} {item.DeptNo} {item.Designation} {item.Email}");
                        }
                        break;

                    case 2:
                        //INSERT DATA Employees
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
                        var r = employeeDataAccess.Create(newEmp);
                        break;

                    case 3:

                        //UPDATE DATA Employees
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
                        var u = employeeDataAccess.Update(UpdatednewEmp, id);
                        break;

                    case 4:

                        //DELETE Employees
                        Console.WriteLine("Enter Employee Id to be Deleted");
                        int Delete_id = int.Parse(Console.ReadLine());
                        int deletedInfo = employeeDataAccess.Delete(Delete_id).Result;
                        if (deletedInfo == 0)
                        {
                            Console.WriteLine("couldn't delete employee");
                        }
                        else
                        {
                            Console.WriteLine("Employee deleted sucessfully");
                        }
                        break;

                    case 5:

                        //read Department
                        var readDept = departmentDataAccess.GetEmpDataAsync().Result;
                        foreach (var item in readDept)
                        {
                            Console.WriteLine($"{item.DeptNo} {item.DeptName} {item.Location} {item.Capacity} ");
                        }
                        break;

                    case 6:

                        //add department
                        Console.WriteLine("Enter department No");
                        int DepartemntNo = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Department name");
                        string DeptName = Console.ReadLine();

                        Console.WriteLine("Enter capacity of the department");
                        int Capacity = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter location");
                        string Location = Console.ReadLine();

                        var newDept = new Department()
                        {
                            DeptNo = DepartemntNo,
                            DeptName = DeptName,
                            Capacity = Capacity,
                            Location = Location

                        };

                        var d = departmentDataAccess.Create(newDept);
                        break;

                    case 7:

                        Console.WriteLine("Enter department Number that is to be updated");
                        int uDepartemntNo = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter updated Department name");
                        string uDeptName = Console.ReadLine();

                        Console.WriteLine("Enter updated capacity of the department");
                        int uCapacity = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter updated location");
                        string uLocation = Console.ReadLine();

                        var updatedDept = new Department()
                        {
                            DeptNo = uDepartemntNo,
                            DeptName = uDeptName,
                            Capacity = uCapacity,
                            Location = uLocation

                        };

                        var e = departmentDataAccess.Update(updatedDept , uDepartemntNo);
                        break;

                    case 8:

                        Console.WriteLine("Enter Department number that is to be Deleted");
                        int Delete_Deptid = int.Parse(Console.ReadLine());
                        int deletedDeptInfo = departmentDataAccess.Delete(Delete_Deptid).Result;
                        if (deletedDeptInfo == 0)
                        {
                            Console.WriteLine("couldn't delete Department");
                        }
                        else
                        {
                            Console.WriteLine("Department deleted sucessfully");
                        }
                        break;

                    case 9:
                        condition = true;
                        break;

                    default:
                        Console.WriteLine("Incorrect Input..try again");
                        break;
                }
            } while (condition == false);
        }

    }
}
