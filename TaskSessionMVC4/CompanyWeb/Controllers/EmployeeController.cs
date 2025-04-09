using Company.Service.Interfaces;
using Company.Service.Interfaces.Employee.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices _employeeServices;
        private readonly IDepartmentServices _departmentServices;

        public EmployeeController(IEmployeeServices employeeServices, IDepartmentServices departmentServices)
        {
            _employeeServices = employeeServices;
            _departmentServices = departmentServices;
        }
        //[HttpGet]
        public IActionResult Index(string searchInp)
        {
            IEnumerable<EmployeeDto> employees = new List<EmployeeDto>();

            if (string.IsNullOrEmpty(searchInp))
                employees = _employeeServices.GetAll();
            else
                employees = _employeeServices.GetEmployeeByName(searchInp);
    
            return View(employees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = _departmentServices.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeDto employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeServices.Add(employee);
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Departments = _departmentServices.GetAll(); 
                ModelState.AddModelError("Employee", "ValidationErrors");
                return View(employee);
            }
            catch (Exception ex)
            {
                ViewBag.Departments = _departmentServices.GetAll();
                ModelState.AddModelError("Employee", ex.Message);
                return View(employee);
            }
        }
    }
}
