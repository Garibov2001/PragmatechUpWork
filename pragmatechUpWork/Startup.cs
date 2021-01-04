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
using pragmatechUpWork.Models;
using pragmatechUpWork.Utils;
using pragmatechUpWork.Controllers;

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
            // Registe our db context
            services.AddDbContext<UpWorkContext>(options =>
                options.UseSqlServer("Server=.; Database=PragmatechUpWork; Integrated Security=True;"));

            // Integer fieldlara null deyer gonderence error mesajini deyismek:
            services.AddRazorPages()
                .AddMvcOptions(options =>
                {
                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                    _ => "Bu xana bos ola bilmez");
                });

            services.AddControllersWithViews();
            services.AddScoped<Utilities, Utilities>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Home}/{id?}");
            });
        }
    }
}
