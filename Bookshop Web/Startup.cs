using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Bookshop.DataAccess.Data;
using Bookshop.DataAccess.Repositories;
using Bookshop.Business.MapperProfile;
using Bookshop.Business.Interfaces;
using Bookshop.Business.Services;
using Bookshop.Business;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Bookshop.Web
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
            var connectionString = Configuration.GetConnectionString("db");

            services.AddControllersWithViews();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductRepository, EFProductRepository>();
            services.AddScoped<IUserService, FakeUserService>();
            
            services.AddDbContext<BookShopDbContext>(opt => opt.UseSqlServer(connectionString));
            services.AddAutoMapper(typeof(MapProfile));
            services.AddSession();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opt =>
                {
                    opt.LoginPath = "/Users/Login";
                    opt.AccessDeniedPath = "/Users/AccessDenied";
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllerRoute(
                    name: "Products",
                    pattern: "Products/{action}/{id?}",
                    defaults:new
                    {
                        controller="Products",
                        action="Index",
                    });
                endpoints.MapControllerRoute(
                    name: "Carts",
                    pattern: "Cart/{action}/{id?}",
                    defaults:new
                    {
                        controller="Cart",
                        action="Index",
                    });
                endpoints.MapControllerRoute(
                    name: "CategoryAndPage",
                    pattern: "{catId}/Page{page}",
                    defaults:new
                    {
                        controller="Home",
                        action="Index",
                        page=1,
                    });

                endpoints.MapControllerRoute(
                    name: "Category",
                    pattern: "{catId}",
                    defaults:new
                    {
                        controller="Home",
                        action="Index",
                        catId=0,
                        page=1
                    });  


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "Page",
                    pattern: "Page{page}",
                    defaults:new
                    {
                        controller="Home",
                        action="Index",
                        page=1
                    });
            });
        }
    }
}
