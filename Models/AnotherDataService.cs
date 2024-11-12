namespace EmployeesMVC.Models
{
    public class AnotherDataService :IDataService
    {
        private List<Employee> _employees =
        [
        new Employee { Id = 1, Name = "Lo Ek", Email = "lo.ek@email.com"},
        new Employee { Id = 2, Name = "Steva Boo", Email = "steva.boo@email.com"},
        new Employee { Id = 3, Name = "Ludde Hansi", Email = "ludde.hansi@email.com"},
        new Employee { Id = 3, Name = "Lee Holzt", Email = "lee.holzt@email.com"}
        ];

        int id;
        public void Add(Employee employee)
        {
            employee.Id = _employees.Max(e => e.Id) + 1;
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
}
