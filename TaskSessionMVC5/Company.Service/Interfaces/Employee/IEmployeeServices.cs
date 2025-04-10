using Company.Service.Interfaces.Employee.Dto;

namespace Company.Service.Interfaces
{
    public interface IEmployeeServices
    {
        EmployeeDto GetById(int? id);
        IEnumerable<EmployeeDto> GetAll();
        void Add(EmployeeDto employee);
        void Delete(EmployeeDto employee);
        void Update(EmployeeDto employee);
        IEnumerable<EmployeeDto> GetEmployeeByName(string name);
    }
}
