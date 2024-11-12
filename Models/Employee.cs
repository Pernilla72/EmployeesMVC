using System.ComponentModel.DataAnnotations;

namespace EmployeesMVC.Models;

public class Employee
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Enter a name")]
    public required string Name { get; set; }

    [Display(Name ="E-mail")]
    [EmailAddress(ErrorMessage = "Fel format på mailadressen")]
    //[Required(ErrorMessage = "Måste fyllas i")]
    public required string Email { get; set; }
}
