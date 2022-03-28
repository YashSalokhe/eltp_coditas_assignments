using _16_March.CustomFilter;
using _16_March.Models;
using _16_March.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _16_March
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Register the DAL dbContext
            //BY passing connectoin information(connection string)
            //by reading key from the appsettings.json
            services.AddDbContext<EnterpriseContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("AppConnStr"));
            });

            //Register the custom services those contains buisness logic
            //service interface,class implementing service interface
            services.AddScoped<IService<Department, int>, DepartmentService>();
            services.AddScoped<IService<Employee, int>, EmployeeService>();
            services.AddScoped<IService<UserInfo, int>, UserService>();

            //Injecting for LOG table
            services.AddControllersWithViews(options => {
                //options.Filters.Add(typeof(LogFilterAttribute));
                options.Filters.Add(typeof(LogFilterAttribute));
                options.Filters.Add(typeof(AppExceptionFilterAttribute));
            });
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //Map with MVC controller
                endpoints.MapControllerRoute(
                    name: "default",
                    // Route URL expression
                    //          HomeController      The Index action method id is optional
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
