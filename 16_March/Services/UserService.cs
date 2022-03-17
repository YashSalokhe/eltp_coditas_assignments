using _16_March.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _16_March.Services
{
    public class UserService : IService<UserInfo, int>
    {
        private readonly EnterpriseContext ctx;
        /// <summary>
        ///
        /// </summary>
        public UserService(EnterpriseContext ctx)
        {
            this.ctx = ctx;
        }

        async Task<UserInfo> IService<UserInfo, int>.CreateAsync(UserInfo T)
        {
            var res = await ctx.UserInfos.AddAsync(T);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }

      async  Task<UserInfo> IService<UserInfo, int>.DeleteAsync(int id)
        {
            var userToFind = await ctx.UserInfos.FindAsync(id);
            if (userToFind == null)
            {
                return null;
            }
            ctx.UserInfos.Remove(userToFind);
            await ctx.SaveChangesAsync();
            return userToFind;
        }

      async  Task<IEnumerable<UserInfo>> IService<UserInfo, int>.GetAsync()
        {
            return await ctx.UserInfos.ToListAsync();
        }

       async Task<UserInfo> IService<UserInfo, int>.GetAsync(int id)
        {
            return await ctx.UserInfos.FindAsync(id);
        }

      async  Task<UserInfo> IService<UserInfo, int>.UpdateAsync(int id, UserInfo T)
        {
            var userToUpdate = await ctx.UserInfos.FindAsync(id);
            if (userToUpdate == null)
            {
                return null;
            }

            
            userToUpdate.UserName = T.UserName;
            userToUpdate.UserPassword = T.UserPassword;
           
            await ctx.SaveChangesAsync();
            return userToUpdate;
        }
    }
}
