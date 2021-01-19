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
using pragmatechUpWork_NotificationServices.General;
using pragmatechUpWork_NotificationServices.Abstract;
using pragmatechUpWork_NotificationServices.Concrete;

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

            // Buradan Identitimizi configure ede bilirik
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
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

            //-----------------------------------------------------------------
            //---------------------- Email Notification ---------------------------
            //-----------------------------------------------------------------

            //Email konqurasiyasi ucun:
            var emailConfig = Configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();

            //Email konfiqurasiyasini inject edirik 
            //EmailSender ucun ele ona gore de AddSingleton yazmisiq
            services.AddSingleton(emailConfig);

            //Hansi controllere email gondermek lazim olsa, inject ede bilecek:
            services.AddScoped<IEmailService, EmailSender>();
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
                app.UseExceptionHandler("/error/500");
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseRouting();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseAuthentication();

            
            // 404 Not Found Page
            app.Use(async (ctx, next) =>
            {
                await next();

                if (ctx.Response.StatusCode == 404 && !ctx.Response.HasStarted)
                {
                    //Re-execute the request so the user gets the error page
                    string originalPath = ctx.Request.Path.Value;
                    ctx.Items["originalPath"] = originalPath;
                    ctx.Request.Path = "/error/404";
                    await next();
                }
            });

            app.UseMvc(ConfigurationRouter);
        }

    private void ConfigurationRouter(IRouteBuilder routeBuilder)
    {
        routeBuilder.MapRoute("default", "{controller=Home}/{action=Home}/{id?}");
    }
}
}
