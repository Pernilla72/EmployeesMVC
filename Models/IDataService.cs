namespace EmployeesMVC.Models
{
    public interface IDataService
    {
        IEnumerable<Company> Companies { get; }
        Task<Employee[]>GetAllAsync();

        Task <Employee> GetByIdAsync(int id);

        Task AddAsync(Employee employee);
    }
}
