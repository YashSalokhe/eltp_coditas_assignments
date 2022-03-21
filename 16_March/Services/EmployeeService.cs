using _16_March.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _16_March.Services
{
    public class EmployeeService : IService<Employee, int>
    {
        private readonly EnterpriseContext ctx;
        /// <summary>
        ///
        /// </summary>
        public EmployeeService(EnterpriseContext ctx)
        {
            this.ctx = ctx;
        }

       async Task<Employee> IService<Employee, int>.CreateAsync(Employee T)
        {
            var res = await ctx.Employees.AddAsync(T);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }

       async Task<Employee> IService<Employee, int>.DeleteAsync(int id)
        {
            var empToFind = await ctx.Employees.FindAsync(id);
            if (empToFind == null)
            {
                return null;
            }
            ctx.Employees.Remove(empToFind);
            await ctx.SaveChangesAsync();
            return empToFind;
        }

       async Task<IEnumerable<Employee>> IService<Employee, int>.GetAsync()
        {

           var result =  await ctx.Employees.ToListAsync();
            foreach(var emp in result)
            {
                emp.Tax = emp.Salary * 0.10;
            }
            await ctx.SaveChangesAsync();
            return result;
        }

      async  Task<Employee> IService<Employee, int>.GetAsync(int id)
        {
            return await ctx.Employees.FindAsync(id);
        }

       async Task<Employee> IService<Employee, int>.UpdateAsync(int id, Employee T)
        {
            var empToUpdate = await ctx.Employees.FindAsync(id);
            if (empToUpdate == null)
            {
                return null;
            }

            empToUpdate.EmpName = T.EmpName;
            empToUpdate.Salary = T.Salary;
            empToUpdate.Designation = T.Designation;
            empToUpdate.DeptNo = T.DeptNo;
            empToUpdate.Email = T.Email;
            await ctx.SaveChangesAsync();
            return empToUpdate;
        }
    }
}
