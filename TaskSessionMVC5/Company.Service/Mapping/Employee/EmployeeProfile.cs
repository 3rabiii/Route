using AutoMapper;
using Company.Service.Interfaces.Employee.Dto;
using Company.Data.Entites;

namespace Company.Service.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}
