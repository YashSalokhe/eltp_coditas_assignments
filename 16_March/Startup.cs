using _16_March.CustomFilter;
using _16_March.Data;
using _16_March.Models;
using _16_March.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
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


            //The registration of the _16_MarchContext into the dependency container
            services.AddDbContext<_16_MarchContext>(options =>
                   options.UseSqlServer(
                       Configuration.GetConnectionString("_16_MarchContextConnection")));

            //Register the identity provider classes in dependency container    
            // userManager<IdentityUser> : user MAnagement(CRUD)
            // SigninManager<IdentityUser> : User Login Management
            //services.AddDefaultIdentity<IdentityUser>(options =>
            //    //Navigate to confirmEmail page when new user is registered
            //    options.SignIn.RequireConfirmedAccount = false
            //    )


            services.AddDistributedMemoryCache();
            services.AddSession(session => {
                session.IdleTimeout = System.TimeSpan.FromMinutes(20);
            });

            ////Connect to database for security using EF core
            //    .AddEntityFrameworkStores<_16_MarchContext>()
            //    .AddDefaultUI();

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<_16_MarchContext>()
             .AddDefaultUI();




            // Define Policies
            services.AddAuthorization(options => {
                options.AddPolicy("ReadPolicy", policy => {
                    policy.RequireRole("Manager", "Clerk", "Operator");
                });
                options.AddPolicy("ManagerClerkPolicy", policy => {
                    policy.RequireRole("Manager", "Clerk");
                });
                options.AddPolicy("ManagerPolicy", policy => {
                    policy.RequireRole("Manager");
                });

            });




            //Register the custom services those contains buisness logic
            //service interface,class implementing service interface
            services.AddScoped<IService<Department, int>, DepartmentService>();
            services.AddScoped<IService<Employee, int>, EmployeeService>();
            services.AddScoped<IService<UserInfo, int>, UserService>();

            //for cache
            services.AddMemoryCache();

            //Injecting for LOG table
            services.AddControllersWithViews();

            services.AddRazorPages();
           // services.AddControllersWithViews();
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
            app.UseSession();
            app.UseRouting();

            //middleware for user authentication
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //Map with MVC controller
                endpoints.MapControllerRoute(
                    name: "default",
                    // Route URL expression
                    //          HomeController      The Index action method id is optional
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //map request to razor view for identity pages
                endpoints.MapRazorPages();
            });
        }
    }
}
