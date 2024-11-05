using EmployeesMVC.Models;

namespace EmployeesMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<DataService>();
            var app = builder.Build();

           
            app.MapControllers();


            app.Run();
        }
    }
}
