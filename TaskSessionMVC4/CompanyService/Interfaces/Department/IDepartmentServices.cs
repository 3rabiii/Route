using Company.Service.Interfaces.Department.Dto;

namespace Company.Service.Interfaces
{
    public interface IDepartmentServices
    {
        DepartmentDto GetById(int? id);
        IEnumerable<DepartmentDto> GetAll();
        void Add(DepartmentDto department);
        void Update(DepartmentDto department);
        void Delete(DepartmentDto department);
    }
}
