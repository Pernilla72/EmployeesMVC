namespace EmployeesMVC.Models
{
    public interface IDataService
    {
        Employee[]GetAll();

        Employee GetById(int id);

        void Add(Employee employee);
    }
}
