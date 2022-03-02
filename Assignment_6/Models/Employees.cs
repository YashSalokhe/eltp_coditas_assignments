using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6.Models
{
    internal class Employees : List<Employee>
    {
        public Employees()
        {
            Add(new Employee() { EmpNo = 101, EmpName = "Mahesh", DeptName = "IT", Salary = 1100000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 102, EmpName = "Tejas", DeptName = "HR", Salary = 1200000, Designation = "Director" });
            Add(new Employee() { EmpNo = 103, EmpName = "Nandu", DeptName = "SL", Salary = 1300000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 104, EmpName = "Anil", DeptName = "IT", Salary = 1400000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 105, EmpName = "Jaywant", DeptName = "HR", Salary = 1000000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 106, EmpName = "Abhay", DeptName = "SL", Salary = 900000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 107, EmpName = "Anil", DeptName = "IT", Salary = 800000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 108, EmpName = "Shyam", DeptName = "HR", Salary = 700000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 109, EmpName = "Vikram", DeptName = "SL", Salary = 600000, Designation = "Director" });
            Add(new Employee() { EmpNo = 110, EmpName = "Suprotim", DeptName = "IT", Salary = 500000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 111, EmpName = "Yash", DeptName = "IT", Salary = 100000, Designation = "Director" });
            Add(new Employee() { EmpNo = 112, EmpName = "Mayur", DeptName = "HR", Salary = 120000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 113, EmpName = "Suyog", DeptName = "SL", Salary = 130000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 114, EmpName = "Harsh", DeptName = "IT", Salary = 140000, Designation = "Director" });
            Add(new Employee() { EmpNo = 115, EmpName = "Sasi", DeptName = "HR", Salary = 1000000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 116, EmpName = "Ayush", DeptName = "SL", Salary = 290000, Designation = "Director" });
            Add(new Employee() { EmpNo = 117, EmpName = "Onkar", DeptName = "IT", Salary = 280000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 118, EmpName = "Shreya", DeptName = "HR", Salary = 370000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 119, EmpName = "Ankita", DeptName = "SL", Salary = 4600000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 120, EmpName = "Jahanvi", DeptName = "IT", Salary = 6500000, Designation = "Director" });
            Add(new Employee() { EmpNo = 121, EmpName = "Chitra", DeptName = "IT", Salary = 810000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 122, EmpName = "Manas", DeptName = "HR", Salary = 920000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 123, EmpName = "Satyam", DeptName = "SL", Salary = 130000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 124, EmpName = "Shreyash", DeptName = "IT", Salary = 104000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 125, EmpName = "Kshitij", DeptName = "HR", Salary = 400000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 126, EmpName = "Shashank", DeptName = "SL", Salary = 80000, Designation = "Director" });
            Add(new Employee() { EmpNo = 127, EmpName = "Tanmay", DeptName = "IT", Salary = 908000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 128, EmpName = "Sahil", DeptName = "HR", Salary = 750000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 129, EmpName = "Labhesh", DeptName = "SL", Salary = 606000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 130, EmpName = "Gatagat", DeptName = "IT", Salary = 505000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 131, EmpName = "Varad", DeptName = "IT", Salary = 190000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 132, EmpName = "Gaurav", DeptName = "HR", Salary = 220000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 133, EmpName = "Athul", DeptName = "SL", Salary = 230000, Designation = "Director" });
            Add(new Employee() { EmpNo = 134, EmpName = "Paras", DeptName = "IT", Salary = 740000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 135, EmpName = "Vishakha", DeptName = "HR", Salary = 200000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 136, EmpName = "Aarohi", DeptName = "SL", Salary = 900000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 137, EmpName = "Vaishnavi", DeptName = "IT", Salary = 208000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 138, EmpName = "Gauri", DeptName = "HR", Salary = 370000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 139, EmpName = "Srushti", DeptName = "SL", Salary = 460000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 140, EmpName = "Sinori", DeptName = "IT", Salary = 570000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 141, EmpName = "Urvika", DeptName = "IT", Salary = 410000, Designation = "Director" });
            Add(new Employee() { EmpNo = 142, EmpName = "Chaitanya", DeptName = "HR", Salary = 200000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 143, EmpName = "Manasi", DeptName = "SL", Salary = 630000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 144, EmpName = "Varun", DeptName = "IT", Salary = 940000, Designation = "Employee" });
            Add(new Employee() { EmpNo = 145, EmpName = "Himaja", DeptName = "HR", Salary = 100000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 146, EmpName = "Akshada", DeptName = "SL", Salary = 900000, Designation = "Manager" });
            Add(new Employee() { EmpNo = 147, EmpName = "Sujeet", DeptName = "IT", Salary = 800000, Designation = "Clerk" });
            Add(new Employee() { EmpNo = 148, EmpName = "Suraj", DeptName = "HR", Salary = 700600, Designation = "Manager" });
            Add(new Employee() { EmpNo = 149, EmpName = "Kittu", DeptName = "SL", Salary = 60800, Designation = "Employee" });
            Add(new Employee() { EmpNo = 150, EmpName = "Shubham", DeptName = "IT", Salary = 550000, Designation = "Director" });
        }

    }
}
