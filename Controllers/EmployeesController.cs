﻿using EmployeesMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeesMVC.Controllers
{
    public class EmployeesController(IDataService _dataService) : Controller
    {
        [HttpGet("")]
        public async Task<IActionResult> IndexAsync()
        {
            var Model = await _dataService.GetAllAsync();
            return View(Model);
        }

        [HttpGet("Create")]   //GET skapar ett tomt formulär för att skapa en ny employee
        public IActionResult Create()
        {
            var companies = _dataService.Companies.ToList();
            ViewBag.CompanyList = new SelectList(companies, "Id", "Name");
            return View();
        }

        [HttpPost("Create")]  //Tar emot data från sagda formulär, validerar den och om OK, lägger till 
                              // en ny employee i listan, samt returnerar användaren ill index-sidan.
        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
                return View(employee);

            if (employee.CompanyId == null)
                employee.CompanyId = null;

            _dataService.AddAsync(employee);
            return RedirectToAction(nameof(IndexAsync).Replace("Async", string.Empty));
        }
    }
}
