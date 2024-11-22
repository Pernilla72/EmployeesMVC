using EmployeesMVC.Views.Employees;

namespace EmployeesMVC.Models;

public interface IDataService
{
    IEnumerable<Company> Companies { get; }
    IEnumerable<Employee> Employees { get; }
    Task<IndexVM> GetAllAsync();
    Task<Employee> GetByIdAsync(int id);
    Task AddAsync(CreateVM createVM);
}
