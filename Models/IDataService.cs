namespace EmployeesMVC.Models
{
    public interface IDataService
    {
        IEnumerable<Company> Companies { get; }
        IEnumerable<Employee> Employees { get; }
        Task<Employee[]> GetAllAsync();

        Task<Employee> GetByIdAsync(int id);

        Task AddAsync(Employee employee);
    }
}
