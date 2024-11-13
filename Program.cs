using EmployeesMVC.Models;

namespace EmployeesMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            //builder.Services.AddTransient<IDataService, DataService>();
            builder.Services.AddSingleton<IDataService, DataService>();
            //builder.Services.AddSingleton<IDataService, AnotherDataService>();
            var app = builder.Build();
            app.UseStaticFiles();
            app.MapControllers();
            app.Run();
        }
    }
}
