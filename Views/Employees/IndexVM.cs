using EmployeesMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeesMVC.Views.Employees;

public class IndexVM
{
    public required EmployeePersonVM[] EmployeePersons { get; set; }
    public int ItemCount { get; set; }
    public class EmployeePersonVM
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
        public string? CompanyName { get; set; }
        public DateTime Time { get; set; }
        internal bool MarkedInColor;  //Admin i e-mail ska visas med röd bakgrundsfärg
    }
}

//<link rel="stylesheet" href="https://unpkg.com/@@picocss/pico@@latest/css/pico.classless.min.css">