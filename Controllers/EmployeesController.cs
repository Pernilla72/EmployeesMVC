using EmployeesMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private static DataService _dataService = new DataService();

        [HttpGet("")]

        public IActionResult Index()
        {
            var Model = _dataService.GetAll();
            return View(Model);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
            return View(employee);

            _dataService.Add(employee);
            return RedirectToAction(nameof(Index));
        }
    }
}
