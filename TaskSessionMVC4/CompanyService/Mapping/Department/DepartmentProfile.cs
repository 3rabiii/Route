using AutoMapper;
using Company.Data.Entites;
using Company.Service.Interfaces.Department.Dto;

namespace Company.Service.Mapping
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();
        }
    }
}
