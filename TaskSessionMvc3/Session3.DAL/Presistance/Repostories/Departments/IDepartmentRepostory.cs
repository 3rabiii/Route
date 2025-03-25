using System.Diagnostics;
using Session3.DAL.Entities;

namespace Session3.DAL.Presistance.Repostories.Departments;

public interface IDepartmentRepostory
{
    IEnumerable<Department> GetAll(bool AsNoTracking = true);
    Department? GetById(int id);
    int AddDepartment(Department department);
    int UpdateDepartment(Department department);
    int DeleteDepartment(Department department);
}