using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopStudy.Infrastructure.Implementation;
using ShopStudy.Infrastructure.Interfaces;
using ShopStudy.Models;
using ShopStudy.Dal;
using ShopStudy.NewDomain.Entities;

namespace ShopStudy
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<ShopStudyContext>(options => options
                .UseSqlServer(_configuration
                .GetConnectionString("DefaultConnection")));
            services.AddSingleton<ICrud<WorkerViewModel>, InMemoryWorkerService>();
            services.AddSingleton<ICrud<CoffeeShopViewModel>, InMemoryCoffeeShop>();
            services.AddScoped<IProductService, SqlProductService>();
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ShopStudyContext>()
                .AddDefaultTokenProviders();
            services.AddScoped<ICartService, CookieCartService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseStaticFiles();
        }
    }
}
