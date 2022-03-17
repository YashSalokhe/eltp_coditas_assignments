using _16_March.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _16_March.Services
{
    public class DepartmentService : IService<Department, int>
    {
        private readonly EnterpriseContext ctx;
        /// <summary>
        ///
        /// </summary>
        public DepartmentService(EnterpriseContext ctx)
        {
            this.ctx = ctx;
        }
        async Task<Department> IService<Department, int>.CreateAsync(Department T)
        {
            var res = await ctx.Departments.AddAsync(T);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }

        async Task<Department> IService<Department, int>.DeleteAsync(int id)
        {
            var deptToFind = await ctx.Departments.FindAsync(id);
            if (deptToFind == null)
            {
                return null;
            }
            ctx.Departments.Remove(deptToFind);
            await ctx.SaveChangesAsync();
            return deptToFind;
        }

        async Task<IEnumerable<Department>> IService<Department, int>.GetAsync()
        {
            return await ctx.Departments.ToListAsync();

        }

        async Task<Department> IService<Department, int>.GetAsync(int id)
        {
            return await ctx.Departments.FindAsync(id);

        }

        async Task<Department> IService<Department, int>.UpdateAsync(int id, Department T)
        {
            var deptToUpdate = await ctx.Departments.FindAsync(id);
            if (deptToUpdate == null)
            {
                return null;
            }

            deptToUpdate.DeptName = T.DeptName;
            deptToUpdate.Capacity = T.Capacity;
            deptToUpdate.Location = T.Location;
            await ctx.SaveChangesAsync();
            return deptToUpdate;
        }
    }
}
