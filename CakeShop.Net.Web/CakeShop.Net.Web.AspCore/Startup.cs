using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CakeShop.Net.BS.Implementation;
using CakeShop.Net.BS.Interface;
using CakeShop.Net.Model;
using CakeShop.Net.Model.DM;
using CakeShop.Net.Model.DTO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CakeShop.Net.Web.AspCore
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        private IConfigurationRoot _configurationRoot;

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.
                                                            UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            services.AddTransient<IUserManagementBS, UserManagementBs>();
            services.AddTransient<IShoppingCartItemBs, ShoppingCartItemBs>();
            services.AddTransient<IPieBs, PieBs>();
            services.AddScoped<IShoppingCartBs>(sp => ShoppingCartBs.GetCart(sp));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc();

            services.AddMemoryCache();
            services.AddSession();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = false;
            });

            Transformation.MapperInitialization();

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="hostingEnvironment"></param>
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder()
                               .SetBasePath(hostingEnvironment.ContentRootPath)
                               .AddJsonFile("appsettings.json")
                               .Build();

        }


        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // Migrate and seed the database during startup. Must be synchronous.
            try
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                    .CreateScope())
                {
                    serviceScope.ServiceProvider.GetService<AppDbContext>().Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                // I'm using Serilog here, but use the logging solution of your choice.
                //loggerFactory.AddConsole(.(x=>new  "Failed to migrate or seed database");
            }

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            
            //Adds authentication middleware to the request pipeline
            app.UseAuthentication();

            //UseSession and UseMvcWithDefaultRoute should be before the UseMvcWithDefaultRoute
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default",
                                template: "{controller=Home}/{action=Index}/{id?}");

            });
            
            DbInitializer.Seed(app, app.ApplicationServices.GetRequiredService<UserManager<IdentityUser>>());
        }
    }
}
