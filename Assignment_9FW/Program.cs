using Assignment_9FW.DataAccess;
using Assignment_9FW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_9FW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDataAccess<Department> dataDept = new DepartmentDataAccess();
            IDataAccess<Employee> dataEmp = new EmployeeDataAccess();

            bool ans = false;
            do
            {
                Console.WriteLine("\n1.Read Employees from employee table\n" +
                                  "2.Insert Employees in Employee table\n" +
                                  "3.Update information of Employee\n" +
                                  "4.Delete Employee\n" +
                                  "5.Read Department from Department table\n" +
                                  "6.Insert Department in Department table\n" +
                                  "7.Update information of Department\n" +
                                  "8.Delete Employee\n" +
                                  "9.Exit\n");
                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        dataEmp.Read();
                        break;

                    case 2:
                        dataEmp.Insert();
                        break;

                    case 3:

                        dataEmp.Read();
                        break ;

                    case 4:

                        dataEmp.Read();
                        dataEmp.Delete();
                        break;

                    case 5:

                        dataDept.Read();
                        break;

                    case 6:

                        dataDept.Insert();
                        break;

                    case 7:

                        dataDept.Read();
                        dataDept.Update();
                        break;

                    case 8:

                        dataDept.Read();
                        dataDept.Delete();
                        break ;

                    case 9: 
                        ans = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice! try again..");
                        break;

                }
            } while (ans == false);


        }
    }
}
