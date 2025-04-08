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
    
    
}