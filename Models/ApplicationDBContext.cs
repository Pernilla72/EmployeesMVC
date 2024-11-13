using Microsoft.EntityFrameworkCore;

namespace EmployeesMVC.Models
{
    public class ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): DbContext(options)

    {
        public required DbSet<Employee> Employees { get; set; }
    }
}
