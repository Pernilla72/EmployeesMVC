using System.Net.Mail;

namespace EmployeesMVC.Models;

public class DataService : IDataService
{
    private List<Employee> _employees = 
        [
        new Employee { Id = 1, Name = "Bo Ek", Email = "bo.ek@email.com"},
        new Employee { Id = 2, Name = "Eva Boo", Email = "eva.boo@email.com"},
        new Employee { Id = 3, Name = "Ludo Hansi", Email = "ludo.hansi@email.com"},
        new Employee { Id = 3, Name = "Leena Holzt", Email = "leena.holzt@email.com"}
        ];

    int id;

    public void Add(Employee employee)
    {
        employee.Id = _employees.Max(e => e.Id) +1;
        _employees.Add(employee);
    }

    public Employee[] GetAll()
    {
        return _employees.ToArray();
    }

    public Employee GetById(int id)
    {
        return _employees.FirstOrDefault(e => e.Id == id);
    }
}
