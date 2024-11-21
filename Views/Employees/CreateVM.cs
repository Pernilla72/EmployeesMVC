using System.ComponentModel.DataAnnotations;

namespace EmployeesMVC.Views.Employees;

public class CreateVM
{
        [Required(ErrorMessage = "Entered a Name")]
        public string? Name { get; set; }    

        [Required(ErrorMessage = "Entered a Email")]
        [EmailAddress]
        public required string Email { get; set; }   
        public int? CompanyId { get; set; } // Företags-ID (kan vara null om "Arbetslös" är valt)
        
        [Range(4, 4, ErrorMessage = "Wrong answer, try again")]
        [Display(Name="Vad är 2 + 2?")]
        public int BotChecked { get; set; }

}
