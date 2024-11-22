using EmployeesMVC.Models;
using EmployeesMVC.Views.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static EmployeesMVC.Views.Employees.IndexVM;


namespace EmployeesMVC.Controllers
{
    public class EmployeesController(IDataService _dataService) : Controller
    {
        [HttpGet("")]
        public async Task<IActionResult> IndexAsync()
        {
            var viewModel = await _dataService.GetAllAsync();
            return View(viewModel);
        }


        [HttpGet("Create")]   //GET skapar ett tomt formulär för att skapa en ny employee
        public IActionResult Create()
        {
            var companies = _dataService.Companies.ToList();
            ViewBag.CompanyList = new SelectList(_dataService.Companies, "Id", "Name");
            return View();
        }

        [HttpPost("Create")]  //Tar emot data från sagda formulär, validerar den och om OK, lägger till 
                              // en ny employee i listan, samt returnerar användaren ill index-sidan.
        public IActionResult Create(CreateVM createVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CompanyList = new SelectList(_dataService.Companies, "Id", "Name");
                return View(createVM);
            }

            //var employee = _dataService.Create(createVM);
            _dataService.AddAsync(createVM);
            return RedirectToAction(nameof(IndexAsync).Replace("Async", string.Empty));
        }
    }
}
