using System.Xml.Schema;
using AutoMapper;
using Company.Data.Entites;
using Company.Repository.Interfaces;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Department.Dto;

namespace Company.Service.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        //private readonly IDepartmentRepository _departmentRepository;

        public DepartmentServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            //_departmentRepository = departmentRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(DepartmentDto departmentDto)
        {
            //var mappedDepartment = new DepartmentDto
            //{
            //    Code = department.Code,
            //    Name = department.Name,
            //    CreateAt = DateTime.Now
            //};
            Department department = _mapper.Map<Department>(departmentDto);
            _unitOfWork.DepartmentRepository.Add(department);
            _unitOfWork.Complete();
        }

        public void Delete(DepartmentDto departmentDto)
        {
            Department department = _mapper.Map<Department>(departmentDto);
            _unitOfWork.DepartmentRepository.Delete(department);
            _unitOfWork.Complete();
        }
        public IEnumerable<DepartmentDto> GetAll()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            IEnumerable<DepartmentDto> departmentDtos = _mapper.Map<IEnumerable<DepartmentDto>>(departments);
            return departmentDtos;
        }

        public DepartmentDto GetById(int? id)
        {
            if (id is null)
                return null;

            var department = _unitOfWork.DepartmentRepository.GetById(id.Value);
            
            if (department is null)
                return null;

            DepartmentDto departmentDto = _mapper.Map<DepartmentDto>(department);
            return departmentDto;
        }

        public void Update(DepartmentDto department)
        {
            //var dept = GetById(department.Id);
            //if (dept.Name != department.Name)
            //{
            //    if (GetAll().Any(x => x.Name == department.Name))
            //        throw new Exception("DuplicateDepartmentName");
            //}
            //dept.Name = department.Name;
            //dept.Code = department.Code;

           // _unitOfWork.DepartmentRepository.Update(department);
            _unitOfWork.Complete();
        }
    }
}
