using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using TheComicWorld.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace TheComicWorld
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration["Data:TheComicWorldProducts:ConnectionString"]));
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(Configuration["Data:TheComicWorldIdentity:ConnectionString"]));
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration["Data:TheComicWorldReviews:ConnectionString"]));
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddTransient<IReviewRepository, EFReviewRepository>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: null,
                    template: "{category}/Page{productPage:int}",
                    defaults: new { controller = "Product", action = "List" });
                routes.MapRoute(
                    name: null,
                    template: "Page{productPage:int}",
                    defaults: new { controller = "Product", action = "List", productPage = 1 });
                routes.MapRoute(
                    name: null,
                    template: "{category}",
                    defaults: new { controller = "Product", action = "List", productPage = 1 });
                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new { controller = "Product", action = "List", productPage = 1 });
                routes.MapRoute(
                    name: null,
                    template: "{controller}/{action}/{id?}");
            });
            SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app, userManager, roleManager);
        }
    }
}
