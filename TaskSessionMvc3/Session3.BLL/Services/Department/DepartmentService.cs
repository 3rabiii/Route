using Azure.Core;
using Session3.BLL.Dtos.Departments;
using Session3.DAL.Presistance.Repostories.Departments;

namespace Session3.BLL.Services.Department;

public class DepartmentService: IDepartmentServices
{
    private readonly IDepartmentRepostory _departmentRepostory;

    public DepartmentService(IDepartmentRepostory departmentRepostory)
    {
        _departmentRepostory = departmentRepostory;
    }
    public IEnumerable<DepartmentToReturnDto> GetAllDepartments()
    {
       var departments= _departmentRepostory.QueryableGetAll().Select(department=> new DepartmentToReturnDto
       {
           Id = department.Id,
           Description = department.Description,
           Code = department.Code,
           CreationDate = department.CreationDate,
           Name = department.Name
       }).ToList();
       return departments;
    }

    public DepartmentDetailsToReturnDto? GetDepartmentById(int id)
    {
        var department = _departmentRepostory.GetById(id);
        if (department is not null)
        {
            return new DepartmentDetailsToReturnDto()
            {
                Id = department.Id,
                Description = department.Description,
                Code = department.Code,
                CreationDate = department.CreationDate,
                Name = department.Name,
                CreateDateOn = department.CreateDateOn,
                LastModifiedBy = department.LastModifiedBy,
                LastModifiedOn = department.LastModifiedOn,
                IsDeleted = department.IsDeleted,
                CreatedBy = department.CreatedBy
            };
        }
        return null;
    }

    public int CreateDepartment(DepartmentToCreateDto department)
    {
        var departmentCreated = new DAL.Entities.Department()
        {
            Name = department.Name,
            Description = department.Description,
            Code = department.Code,
            CreationDate = department.CreationDate
        };
       return _departmentRepostory.AddDepartment(departmentCreated);
    }

    public int UpdateDepartment(DepartmentToUpdateDto department)
    {
        var departmentCreated = new DAL.Entities.Department()
        {
            Id = department.Id,
            Name = department.Name,
            Description = department.Description,
            Code = department.Code,
            CreationDate = department.CreationDate
        };
        return _departmentRepostory.UpdateDepartment(departmentCreated);
        
    }

    public bool DeleteDepartment(int id)
    {
        var department = _departmentRepostory.GetById(id);
        if (department is not null)
        {
            return _departmentRepostory.DeleteDepartment(department)>0;
        }
        return false;
    }
}