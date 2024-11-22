using Microsoft.EntityFrameworkCore;

namespace EmployeesMVC.Models;

public class ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : DbContext(options)

{
    public required DbSet<Employee> Employees { get; set; }
    public required DbSet<Company> Companies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(
         new Employee { Id = 1, Name = "Bo Ek", Email = "bo.ek@email.com" },
         new Employee { Id = 2, Name = "Eva Boo", Email = "eva.boo@email.com", CompanyId = 1 },
         new Employee { Id = 3, Name = "Ludo Hansi", Email = "ludo.hansi@email.com", CompanyId = 1 },
         new Employee { Id = 4, Name = "Leena Holzt", Email = "leena.holzt@email.com", CompanyId = 2 }

 );
        modelBuilder.Entity<Company>().HasData(
            new Company { Id = 1, Name = "Företaget" },
            new Company { Id = 2, Name = "Andra företaget" }
            );
    }
}