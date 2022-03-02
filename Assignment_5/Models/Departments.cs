using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5.Models
{
    internal class Departments : List<Department>
    {
        public Departments()
        {
            Add(new Department() { DeptNo = 101, DeptName = "HR", Location = "Pune", Capacity = 200 });
            Add(new Department() { DeptNo = 102, DeptName = "SL", Location = "Mumbai", Capacity = 400 });
            Add(new Department() { DeptNo = 103, DeptName = "IT", Location = "Hyderabad", Capacity = 700 });
            //Add(new Department() { DeptNo = 101, DeptName = "HR", Location = "USA", Capacity = 200 });
            //Add(new Department() { DeptNo = 102, DeptName = "SL", Location = "Banglore", Capacity = 200 });
            //Add(new Department() { DeptNo = 101, DeptName = "IT", Location = "Delhi", Capacity = 200 });
            //Add(new Department() { DeptNo = 103, DeptName = "HR", Location = "Nagur", Capacity = 200 });
            //Add(new Department() { DeptNo = 102, DeptName = "SL", Location = "Jalgaon", Capacity = 200 });
            //Add(new Department() { DeptNo = 103, DeptName = "HR", Location = "Hinjewadi", Capacity = 200 });
            //Add(new Department() { DeptNo = 102, DeptName = "SL", Location = "Chinchwad", Capacity = 200 });
        }
    }
}
