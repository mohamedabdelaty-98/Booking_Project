using Booking_Project.Models;
using Booking_Project.Reposatory;
using Booking_Project1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Booking_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // configration of sqldbcontext
            builder.Services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("sql"));
            });
            // configration for automapper
            builder.Services.AddAutoMapper(typeof(AutomapperProfile));
            // configration of repocrudoperation you can custom 
            builder.Services.AddScoped<ICrudOperation<Room>, CrudOperationRepo<Room>>();

             //configration of identity
            builder.Services.AddIdentity<ApplicationIdentityUser, IdentityRole>(option=>
            {
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireDigit = false;
            })
                .AddEntityFrameworkStores<Context>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}