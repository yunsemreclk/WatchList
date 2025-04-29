using Microsoft.EntityFrameworkCore;
using WatchList.DataAccess.Context;
using WatchList.Entity.Entities;
using WatchList.WebUI.Services.UserServices;

namespace WatchList.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddDbContext<WatchListContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
            });
            builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<WatchListContext>();
            builder.Services.AddHttpClient();
            builder.Services.AddControllersWithViews();
            builder.Services.AddAuthorization();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.Run();
        }
    }
}
