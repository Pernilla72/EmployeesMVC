using Microsoft.EntityFrameworkCore;
using System.IO.Pipelines;

namespace EmployeesMVC.Models;

//a) Uppdatera metoderna till att arbeta mot den kontext-klass som nu injiceras i konsturktorn istället för mot den gamla listan (kom ihåg
//att anropa SaveChanges() för att persistera förändringar till databasen)
//b) Den gamla listan kan nu raderas (eller kommenteras ut )
//c) Kör applikationen – allt bör nu fungera som tidigare, förutom att datan nu lagras i en databas istället för listan 
public class DataService : IDataService
{

    ApplicationDBContext _context;

    public DataService(ApplicationDBContext context)
    {
        this._context = context;
    }

    //private List<Employee> _employees = 
    //[
    //new Employee { Id = 1, Name = "Bo Ek", Email = "bo.ek@email.com"},
    //new Employee { Id = 2, Name = "Eva Boo", Email = "eva.boo@email.com"},
    //new Employee { Id = 3, Name = "Ludo Hansi", Email = "ludo.hansi@email.com"},
    //new Employee { Id = 3, Name = "Leena Holzt", Email = "leena.holzt@email.com"}
    //];

    public IEnumerable<Company> Companies
    {
        get
        {
            return _context.Companies.Include(c => c.Employees);
        }
    }
    public async Task AddAsync(Employee employee)
    {
        //employee.Id = _context.Employees.Max(e => e.Id) +1;
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
    }

    public async Task<Employee[]> GetAllAsync()
    {
        return await _context.Employees
            .Include(c => c.Company)
            .ToArrayAsync();
    }

    public async Task<Employee> GetByIdAsync(int id) => await _context.Employees.SingleOrDefaultAsync(e => e.Id == id);
}
