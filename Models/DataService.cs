using Microsoft.EntityFrameworkCore;
using System.IO.Pipelines;

namespace EmployeesMVC.Models;

//a) Uppdatera metoderna till att arbeta mot den kontext-klass som nu injiceras i konsturktorn istället för mot den gamla listan (kom ihåg
//att anropa SaveChanges() för att persistera förändringar till databasen)
//b) Den gamla listan kan nu raderas (eller kommenteras ut )
//c) Kör applikationen – allt bör nu fungera som tidigare, förutom att datan nu lagras i en databas istället för listan 
public class DataService(ApplicationDBContext _context) : IDataService
{
    //ApplicationDBContext _context;
    //public DataService(ApplicationDBContext context)
    //{
    //    this._context = context;
    //}

    public IEnumerable<Company> Companies
    {
        get
        {
            return _context.Companies.Include(c => c.Employees);
        }
    }
    public IEnumerable<Employee> Employees
    {
        get
        {
            return _context.Employees.Include(c => c.Company);
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
