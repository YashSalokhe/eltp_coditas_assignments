using Assignment14_Part1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment14_Part1.DataAccess
{
    public class EmployeeDataAccess : IDataAccess<Employee, int>
    {
        EnterpriseContext ctx;
        public EmployeeDataAccess()
        {
            ctx = new EnterpriseContext();
        }
        async Task<Employee> IDataAccess<Employee, int>.CreateAsync(Employee entity)
        {
            var resultCreateEmp = await ctx.Employees.AddAsync(entity);
            await ctx.SaveChangesAsync();
            return resultCreateEmp.Entity;
        }

        async Task<Employee?> IDataAccess<Employee, int>.DeleteAsync(int id)
        {

            var resultDeleteEmp = await ctx.Employees.FindAsync(id);
            if (resultDeleteEmp == null)
            {
                return null;
            }
            ctx.Employees.Remove(resultDeleteEmp);
            await ctx.SaveChangesAsync();
            return resultDeleteEmp;
        }

        async Task<IEnumerable<Employee>> IDataAccess<Employee, int>.GetAsync()
        {
            var resultReadEmp = await ctx.Employees.ToListAsync();
            return resultReadEmp;
        }

        async Task<Employee?> IDataAccess<Employee, int>.UpdateAsync(int id, Employee entity)
        {
            var resultUpdateEmp = await ctx.Employees.FindAsync(id);
            if (resultUpdateEmp == null)
            {
                return null;
            }
            resultUpdateEmp.EmpName = entity.EmpName;
            resultUpdateEmp.Designation = entity.Designation;
            resultUpdateEmp.Salary = entity.Salary;
            resultUpdateEmp.Email = entity.Email;
            resultUpdateEmp.DeptNo = entity.DeptNo;

            await ctx.SaveChangesAsync();
            return resultUpdateEmp;
        }
    }
}
