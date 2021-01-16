using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using pragmatechUpWork_Entities;
using pragmatechUpWork.Controllers;
using pragmatechUpWork_DataAccessLayer.Abstarct;
using pragmatechUpWork_DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Routing;
using pragmatechUpWork_BusinessLogicLayer.UnitOfWork.Abstract;
using pragmatechUpWork_BusinessLogicLayer.UnitOfWork.Concrete;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
using pragmatechUpWork_CoreMVC.UI.IdentityClasses;

namespace pragmatechUpWork
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
            services.AddMvc();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            // Registe our db context
            services.AddDbContext<UpWorkContext>(options =>
                options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=PragmatechUpWork; Integrated Security=True;", b => b.MigrationsAssembly("pragmatechUpWork_CoreMVC.UI")));
            services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=PragmatechUpWork; Integrated Security=True;"));
            services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            // Integer fieldlara null deyer gonderence error mesajini deyismek:
            services.AddRazorPages()
                .AddMvcOptions(options =>
                {
                    options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                        _ => "Bu xana bos ola bilmez");
                });

            services.AddControllersWithViews();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProjectDal, EfProjectDal>();
            services.AddTransient<IProjectTaskDal, EfProjectTaskDal>();
            services.AddControllers();
            services.AddRouting();
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.LoginPath = "/Profile/Profile";
                options.AccessDeniedPath = "/Account/Register";
                options.SlidingExpiration = true;
            });
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
            }
            app.UseRouting();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseRouting();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            //app.UseEndpoints(endpoints =>
            //{
            //endpoints.MapControllerRoute(
            //name: "default",
            //pattern: "{ controller = Home}/{ action = Index}/{ id ?}");
            //endpoints.MapRazorPages();
            //});

            app.UseMvc(ConfigurationRouter);
        }

    private void ConfigurationRouter(IRouteBuilder routeBuilder)
    {
        routeBuilder.MapRoute("default", "{controller=Home}/{action=Home}/{id?}");
    }
}
}
