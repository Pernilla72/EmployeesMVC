using System.Net.Mail;

namespace EmployeesMVC.Models;

public class DataService
{
    private List<Employee> _employees = [
        new Employee { Id = 1, Name = "Bo Ek", Email = "bo.ek@email.com"},
        new Employee { Id = 2, Name = "Ek Bo", Email = "ek.bo@email.com"},
        new Employee { Id = 3, Name = "Ludde Hani", Email = "ludde.hani@email.com"},
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
