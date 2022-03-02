using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5.Models
{
    internal class EmpDepts : List<EmpDept>
    {
        public EmpDepts()
        {
            Add(new EmpDept() { EmpNo = 101, EmpName = "Mahesh", DeptNo = 101, Salary = 110000, Designation = "Manager" });
            Add(new EmpDept() { EmpNo = 102, EmpName = "Tejas", DeptNo = 102, Salary = 120000, Designation = "Director" });
            Add(new EmpDept() { EmpNo = 103, EmpName = "Nandu", DeptNo = 103, Salary = 130000, Designation = "Employee" });
            Add(new EmpDept() { EmpNo = 104, EmpName = "Anil", DeptNo = 102, Salary = 140000, Designation = "Employee" });
            Add(new EmpDept() { EmpNo = 105, EmpName = "Jaywant", DeptNo = 103, Salary = 100000, Designation = "Manager" });
            Add(new EmpDept() { EmpNo = 106, EmpName = "Abhay", DeptNo = 101, Salary = 90000, Designation = "Employee" });
            Add(new EmpDept() { EmpNo = 107, EmpName = "Anil", DeptNo = 102, Salary = 80000, Designation = "Manager" });
            Add(new EmpDept() { EmpNo = 108, EmpName = "Shyam", DeptNo = 101, Salary = 70000, Designation = "Clerk" });
            Add(new EmpDept() { EmpNo = 109, EmpName = "Vikram", DeptNo = 103, Salary = 60000, Designation = "Director" });
            Add(new EmpDept() { EmpNo = 110, EmpName = "Suprotim", DeptNo = 101, Salary = 50000, Designation = "Employee" });
        }
    }
}
