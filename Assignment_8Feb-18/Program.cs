using System;
using Assignment_8Feb_18.DataAccess;
using Assignment_8Feb_18.Models;
namespace Assignment_8Feb_18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            
            IDataAccess<Employee , int> data = new EmployeeDataAccess();


            var temp = data.GetAllEmployeesByDeptName(2);

        }
    }
}