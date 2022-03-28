using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_5;

namespace Assignment_5.Models
{
    internal class taskException
    {
        public Task Q5(IEnumerable<Employee> emps)
        {
            try
            {
                var deptSal = emps.GroupBy(e => e.DeptName);
                var ans = emps.OrderBy(e => e.Salary).GroupBy(e => e.DeptName).Select(e => e.Take(1));
                foreach (var dept in ans)
                {
                    // PrintResult(dept);
                    Console.WriteLine("hiii");
                }
                return (Task)ans;
            }
            catch (Exception ex)
            {
                return Task.FromException<object>( ex);
            }

        }

    }
}
