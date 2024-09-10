using Company.Data.Entities;
using Company.repository.Interfaces;
using Company.services.Interfaces;
using Company.services.Interfaces.Dbo;
using Company.services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Complany.Web.Controllers
{
	public class DepartmentController : Controller
	{
		private readonly IDepartmentService _departmentService;
		public DepartmentController(IDepartmentService departmentService) 
		{
            _departmentService = departmentService;
		}
		[HttpGet]
        public IActionResult Index()
        {
			var department = _departmentService.GetAll();
			TempData.Keep("TextTempMessage");
			return View(department);
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(DepartmentDbo department)
		{
			if (ModelState.IsValid)
			{
				_departmentService.Add(department);
                TempData["TextTempMessage"] = "Hello From Employee Index";
                return RedirectToAction(nameof(Index));
			}
			else
			{
				ModelState.AddModelError("DepartmentError", "Validation Error");
				return View(department);
			}
		}
		public IActionResult Details(int? id, string viewName = "Details")
		{
			var department = _departmentService.GetById(id);
			if(department is null)
				return NotFound();
			return View(department);
		}
		[HttpGet]
		public IActionResult Update(int? id)
		{
			return Details(id, "Update");
		}
		[HttpPost]
		public IActionResult Update(int? id, DepartmentDbo department)
		{
			if (department.Id != id.Value)
				return NotFound();
			_departmentService.Update(department);
		    return View(department);
		}
		public IActionResult Delete(int id)
		{
			var department = _departmentService.GetById(id);
			if(department is null)
				return NotFound();
			_departmentService.Delete(department);
			return RedirectToAction(nameof(Index));
		}
	}
}
