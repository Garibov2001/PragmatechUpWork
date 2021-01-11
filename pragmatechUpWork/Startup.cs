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
using pragmatechUpWork.Utils;
using pragmatechUpWork.Controllers;
using pragmatechUpWork_DataAccessLayer.Abstarct;
using pragmatechUpWork_DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Routing;
using pragmatechUpWork_BusinessLogicLayer.UnitOfWork.Abstract;
using pragmatechUpWork_BusinessLogicLayer.UnitOfWork.Concrete;

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
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMvc(ConfigurationRouter);
        }

        private void ConfigurationRouter(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("default", "{controller=Home}/{action=Home}/{id?}");
        }
    }
}
