using System;
using _16_March.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(_16_March.Areas.Identity.IdentityHostingStartup))]
namespace _16_March.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) =>
            //{
            //    services.AddDbContext<_16_MarchContext>(options =>
            //        options.UseSqlServer(
            //            context.Configuration.GetConnectionString("_16_MarchContextConnection")));

            //    services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //        .AddEntityFrameworkStores<_16_MarchContext>();
            //});
        }
    }
}
