using EmployeesMVC.Views.Employees;
using Microsoft.EntityFrameworkCore;

namespace EmployeesMVC.Models;
public class DataService(ApplicationDBContext _context) : IDataService
{

    public IEnumerable<Company> Companies => _context.Companies
        .Include(c => c.Employees);

    public IEnumerable<Employee> Employees => _context.Employees
        .Include(e => e.Company);
    

    public async Task AddAsync(CreateVM createVM)   //Lägg till/Create ny Employee
    {
        var employee = new Employee
        {
            Name = createVM.Name,
            Email = createVM.Email,
            CompanyId = createVM.CompanyId,
        };
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
    }

    public async Task<IndexVM> GetAllAsync()   //Hämta/Visa alla Employee
    {
        var ret = new IndexVM()
        {
            EmployeePersons = await _context.Employees
                .Select(e => new IndexVM.EmployeePersonVM()
                {
                    Name = e.Name,
                    Email = e.Email,
                    CompanyName = e.Company.Name,
                })
                .OrderBy(e => e.Name)
                .ThenBy(e => e.Email)
                .ToArrayAsync()
        };
        ret.ItemCount = ret.EmployeePersons.Count();
        return ret;
    }

    public async Task<Employee> GetByIdAsync(int id)
    {
       var employee = await _context.Employees.SingleOrDefaultAsync(e => e.Id == id);
        if (employee == null)
            throw new KeyNotFoundException($"Employee with ID {id} not found");
        return employee;
    }
}
