using MiniProject1.Models;
using System;
using System.Collections.Generic;

namespace MiniProject1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            bool exit = true;
            do
            {
                Console.WriteLine("\n\n1.Add employees\n" +
                                  "2.Search employee\n" +
                                  "3.Display employees\n" +
                                  "4.Update emplyoees\n" +
                                  "5.Delete employees\n" +
                                  "6.Display emplyoees by dept name(IT, HRD, Sales, Admin, Account)\n" +
                                  "7.Display emplyoees by designation(Manager, Engineer, Clerk, Staff)\n" +
                                  "8.Exit\n");
                
                Console.WriteLine("Enter your choice\n");
                int userInput = int.Parse(Console.ReadLine());
              
                switch (userInput)
                {
                    case 1:

                        client.AddEmployee();
                        break;

                    case 2:

                        client.SearchEmployeeById();
                        break;

                    case 3:

                        client.DisplayData();
                        break;

                    case 4:

                        client.UpdateEmployee();
                        break;

                    case 5:

                        client.DeleteEmployee();
                        break;

                    case 6:

                        client.ListEmployeesDeptName();
                        break;

                    case 7:

                        client.ListEmployeesDesignation();
                        break;

                    case 8:

                        exit = false;
                        break;

                    default:

                        Console.WriteLine("Invalid choice...try again");
                        break;
                }
            }
            while (exit);
        }
    }
}
