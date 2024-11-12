using EmployeesMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesMVC.Controllers
{
    public class EmployeesController : Controller
    {
        //private static DataService _dataService = new DataService();
        private readonly IDataService _dataService;
        public EmployeesController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("")]

        public IActionResult Index()
        {
            var Model = _dataService.GetAll();
            return View(Model);
        }

        [HttpGet("Create")]   //GET skapar ett topt formulär för att skapa en ny employee
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]  //Tar emot data från sagda formulär, validerar den och om OK, lägger till 
                              // en ny employee i listan, samt returnerar användaren ill index-sidan.
        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
            return View(employee);

            _dataService.Add(employee);
            return RedirectToAction(nameof(Index));
        }
    }
}
