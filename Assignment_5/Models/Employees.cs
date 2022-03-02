using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5.Models
{
    internal class Employees : List<Employee>
    {
        public Employees()
        {
            Add(new Employee() { EmpNo = 101, EmpName = "Mahesh", DeptName = "IT", Salary = 110000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 102, EmpName = "Tejas", DeptName = "HR", Salary = 120000, Designation = "Director" });
            Add(new Employee() { EmpNo = 103, EmpName = "Nandu", DeptName = "SL", Salary = 130000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 104, EmpName = "Anil", DeptName = "IT", Salary = 140000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 105, EmpName = "Jaywant", DeptName = "HR", Salary = 100000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 106, EmpName = "Abhay", DeptName = "SL", Salary = 90000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 107, EmpName = "Anil", DeptName = "IT", Salary = 80000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 108, EmpName = "Shyam", DeptName = "HR", Salary = 70000, Designation = "Clerk" });
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
}
