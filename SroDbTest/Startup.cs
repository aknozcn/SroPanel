using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SroDbTest.Data.Contexts;
using SroDbTest.Data.Interfaces;
using SroDbTest.Data.Repositories;
using SroDbTest.Models.AccountDb;

namespace SroDbTest
{
    public class Startup
    {
        public IConfiguration _configuration;


        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<AccountDbContext>(opt => opt.UseSqlServer(_configuration.GetConnectionString("AccountDb")));
            services.AddDbContext<LogDbContext>(opt => opt.UseSqlServer(_configuration.GetConnectionString("LogDb")));
            services.AddDbContext<ShardDbContext>(opt => opt.UseSqlServer(_configuration.GetConnectionString("ShardDb")));
            services.AddDbContext<PanelDbContext>(opt => opt.UseSqlServer(_configuration.GetConnectionString("PanelDb")));


            services.AddScoped<IAccountRepository, AccountRepository<AccountDbContext>>();

            services.AddAutoMapper(typeof(Startup));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
            {
                opt.Cookie.Name = "SroPanel";
            });

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role));
               // opt.AddPolicy("Member", policy => policy.RequireClaim(ClaimTypes.Role));
            });

            services.AddSession(opt =>
            {
                opt.IdleTimeout = TimeSpan.FromMinutes(20);
                opt.Cookie.HttpOnly = true;
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseSession();


            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
