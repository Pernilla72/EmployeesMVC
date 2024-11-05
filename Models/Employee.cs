using System.ComponentModel.DataAnnotations;

namespace EmployeesMVC.Models;

public class Employee
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Enter a name")]
    public string Name { get; set; }

    [Display(Name ="E-mail")]
    [EmailAddress(ErrorMessage = "Fel format på mailadressen")]

    public string Email { get; set; }
}
