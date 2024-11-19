using EmployeesMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeesMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDBContext>(o => o.UseSqlServer(connString));
            builder.Services.AddControllersWithViews();            
            builder.Services.AddScoped<IDataService, DataService>();
            //builder.Services.AddSingleton<IDataService, AnotherDataService>();
            var app = builder.Build();
            app.UseStaticFiles();
            app.MapControllers();
            app.Run();
        }
    }
}
