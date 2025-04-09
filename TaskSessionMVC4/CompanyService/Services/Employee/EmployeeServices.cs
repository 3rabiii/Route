using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Company.Data.Entites;
using Company.Repository.Interfaces;
using Company.Service.Helper;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Employee.Dto;

namespace Company.Service.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(EmployeeDto employeeDto)
        {
            //Manual Mapping 
            //Employee employee = new Employee
            //{
            //    Adress = employeeDto.Adress,
            //    Age = employeeDto.Age,
            //    DepartmentId = employeeDto.DepartmentId,
            //    Email = employeeDto.Email,
            //    HiringDate = employeeDto.HiringDate,
            //    ImgUrl = employeeDto.ImgUrl,
            //    Name = employeeDto.Name,
            //    PhoneNumber = employeeDto.PhoneNumber,
            //    Salary = employeeDto.Salary,
            //};

            employeeDto.ImgUrl = DocumentSettings.UploadFile(employeeDto.Image, "Images");

            Employee employee = _mapper.Map<Employee>(employeeDto); 
            _unitOfWork.EmployeeRepository.Add(employee);
            _unitOfWork.Complete();
        }

        public void Delete(EmployeeDto employeeDto)
        {
            //Employee employee = new Employee
            //{
            //    Adress = employeeDto.Adress,
            //    Age = employeeDto.Age,
            //    DepartmentId = employeeDto.DepartmentId,
            //    Email = employeeDto.Email,
            //    HiringDate = employeeDto.HiringDate,
            //    ImgUrl = employeeDto.ImgUrl,
            //    Name = employeeDto.Name,
            //    PhoneNumber = employeeDto.PhoneNumber,
            //    Salary = employeeDto.Salary,
            //};
            Employee employee = _mapper.Map<Employee>(employeeDto);
            _unitOfWork.EmployeeRepository.Delete(employee);
            _unitOfWork.Complete();
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            var employees = _unitOfWork.EmployeeRepository.GetAll();

            //var mappedEmployees = employees.Select(x => new EmployeeDto
            //{
            //    Name = x.Name,
            //    PhoneNumber = x.PhoneNumber,
            //    Salary = x.Salary,
            //    ImgUrl = x.ImgUrl,
            //    Id = x.Id,
            //    Adress = x.Adress,
            //    Email = x.Email,
            //    HiringDate = x.HiringDate,
            //    Age = x.Age,
            //    DepartmentId = x.DepartmentId,
            //    CreateAt = x.CreateAt
            //});
            IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return mappedEmployees;
        }

        public EmployeeDto GetById(int? id)
        {
            if (id is null)
                return null;

            var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);

            if (employee is null)
                return null;

            //EmployeeDto employeeDto = new EmployeeDto
            //{
            //    Adress = employee.Adress,
            //    Age = employee.Age,
            //    DepartmentId = employee.DepartmentId,
            //    Email = employee.Email,
            //    HiringDate = employee.HiringDate,
            //    ImgUrl = employee.ImgUrl,
            //    Name = employee.Name,
            //    PhoneNumber = employee.PhoneNumber,
            //    Salary = employee.Salary,
            //    Id = employee.Id,
            //    CreateAt = employee.CreateAt
            //};
            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }

        public IEnumerable<EmployeeDto> GetEmployeeByName(string name)
        {
           var employees = _unitOfWork.EmployeeRepository.GetEmployeeByName(name);
            //var mappedEmployees = employees.Select(x => new EmployeeDto
            //{
            //    Name = x.Name,
            //    PhoneNumber = x.PhoneNumber,
            //    Salary = x.Salary,
            //    ImgUrl = x.ImgUrl,
            //    Id = x.Id,
            //    Adress = x.Adress,
            //    Email = x.Email,
            //    HiringDate = x.HiringDate,
            //    Age = x.Age,
            //    DepartmentId = x.DepartmentId,
            //    CreateAt = x.CreateAt
            //});
            IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return mappedEmployees;
        }
        public void Update(EmployeeDto employee)
        {
           // _unitOfWork.EmployeeRepository.Update(employee);
            _unitOfWork.Complete();
        }
    }
}
