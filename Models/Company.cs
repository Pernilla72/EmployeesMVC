namespace EmployeesMVC.Models;
//a) Lägg till en ny databas-modell(Company) som representerar ett företag där anställda kan arbeta
//Ett företag ska kunna ha flera anställda
//Markera Company-propertyn i Employee som nullable genom att ange datatypen som Company? – detta talar om för EF att en anställd
//inte måste vara kopplad till ett företag
public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Employee> Employees { get; set; }

}
