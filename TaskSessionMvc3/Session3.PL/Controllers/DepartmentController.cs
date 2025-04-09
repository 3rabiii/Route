using Microsoft.AspNetCore.Mvc;
using Session3.BLL.Services.Department;

namespace Session3.PL.Controllers;

public class DepartmentController: Controller
{
    private readonly IDepartmentServices _departmentService;

    public DepartmentController(IDepartmentServices departmentService)
    {
        _departmentService = departmentService;
    }
    [HttpGet]
    public IActionResult Index()
    {
        var departments = _departmentService.GetAllDepartments();
        return View(departments);
    }
     [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Create(Department department)
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
        public IActionResult Update(int? id, Department department)
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
