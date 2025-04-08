using Session3.BLL.Dtos.Departments;

namespace Session3.BLL.Services.Department;

public interface IDepartmentServices
{
   IEnumerable<DepartmentToReturnDto>GetAllDepartments();
   DepartmentDetailsToReturnDto? GetDepartmentById(int id);
   int CreateDepartment(DepartmentToCreateDto department);
   int UpdateDepartment(DepartmentToUpdateDto department);
   bool DeleteDepartment(int id);

}