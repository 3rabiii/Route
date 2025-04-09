using Company.Service.Interfaces;
using Company.Service.Interfaces.Department.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices _departmentServices;

        public DepartmentController(IDepartmentServices departmentServies)
        {
            _departmentServices = departmentServies;
        }
        public IActionResult Index()
        {
            var departments = _departmentServices.GetAll();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentDto department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _departmentServices.Add(department);
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("Department", "ValidationErrors");
                return View(department);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Department",ex.Message);
                return View(department);
            }
        }
        public IActionResult Details(int? id, string ViewName = "Details")
        {
            var department = _departmentServices.GetById(id);
            
            if (department is null)
                return RedirectToAction("NotFoundPage", null, "Home");

            return View(ViewName, department);
        }
        [HttpGet]
        public IActionResult update(int? id)
        {
            return Details(id, "Update");
        }
        
        [HttpPost]
        public IActionResult Update(int? id, DepartmentDto department)
        {
            if (department.Id != id.Value)
                return RedirectToAction("NotFoundPage", null, "Home");

            _departmentServices.Update(department);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var department = _departmentServices.GetById(id);

            if (department is null)
                return RedirectToAction("NotFoundPage", null, "Home");

            _departmentServices.Delete(department);

            return RedirectToAction(nameof(Index));
        }
    }
}
