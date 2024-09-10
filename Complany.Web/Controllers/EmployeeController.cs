using Company.Data.Entities;
using Company.services.Interfaces;
using Company.services.Interfaces.Dbo;
using Complany.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Complany.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices _services;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeServices services, IDepartmentService departmentService)
        {
            _services = services;
            _departmentService = departmentService;
        }
        [HttpGet]
        public IActionResult Index(string searchInp)
        {
            //ViewBag.Message = "Hello From Employee Index";
            //ViewData["TextMessage"] = "Hello From Employee Index";
            //TempData["TextTempMessage"] = "Hello From Employee Index";
            IEnumerable<EmployeeDbo> employees = new List<EmployeeDbo>();
            if (string.IsNullOrEmpty(searchInp))
            {
                 employees = _services.GetAll();
            }
            else
            {
                 employees = _services.GetEmployeeByName(searchInp);
            }
                return View(employees);
            
        }
        [HttpGet]
        public IActionResult Create()
        {
            var department = _departmentService.GetAll();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeDbo employee)
        {
            if (ModelState.IsValid)
            {
               _services.Add(employee);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(employee);
            }
        }
        //public IActionResult Delete(int id)
        //{

        //}

    }
}
