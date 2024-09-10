using AutoMapper;
using Company.Data.Entities;
using Company.repository.Interfaces;
using Company.services.Helper;
using Company.services.Interfaces;
using Company.services.Interfaces.Dbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.services.Services
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

        public void Add(EmployeeDbo employee)
        {
			//Employee employee1 = new Employee 
			//{
			//    Address = employee.Address,
			//    Age = employee.Age,
			//    DepartmentId = employee.DepartmentId,
			//    Email = employee.Email,
			//    HiringDate = employee.HiringDate,
			//    ImgUrl = employee.ImgUrl,
			//    Name = employee.Name,
			//    PhoneNumber = employee.PhoneNumber,
			//    Salary = employee.Salary
			//};
			employee.ImgUrl = DocumentSettings.uploadfile(employee.Image, "Images");
			Employee employee1 = _mapper.Map<Employee>(employee);
			_unitOfWork.employeeRepository.Add(employee1);
			_unitOfWork.Complete();
		}

        public void Delete(EmployeeDbo employee)
        {
			//Employee employee1 = new Employee
			//{
			//	Address = employee.Address,
			//	Age = employee.Age,
			//	DepartmentId = employee.DepartmentId,
			//	Email = employee.Email,
			//	HiringDate = employee.HiringDate,
			//	ImgUrl = employee.ImgUrl,
			//	Name = employee.Name,
			//	PhoneNumber = employee.PhoneNumber,
			//	Salary = employee.Salary
			//};
			Employee employee1 = _mapper.Map<Employee>(employee);

			_unitOfWork.employeeRepository.Delete(employee1);
            _unitOfWork.Complete();
        }
        public IEnumerable<EmployeeDbo> GetAll()
        {
			var Employee = _unitOfWork.employeeRepository.GetAll;
            //var mappedEmployee = Employee.Select(x => new EmployeeDbo
            //{
            //    DepartmentId = x.DepartmentId,
            //    Email = x.Email,
            //    HiringDate = x.HiringDate,
            //    ImgUrl = x.ImgUrl,
            //    Name = x.Name,
            //    PhoneNumber = x.PhoneNumber,
            //    Salary = x.Salary              
            //});
			IEnumerable<EmployeeDbo> mappedEmployee = _mapper.Map<IEnumerable<EmployeeDbo>>(Employee);

			return mappedEmployee;
        }

        public EmployeeDbo GetById(int? id)
        {
			if (id is null)
				return null;
			var employee = _unitOfWork.employeeRepository.GetById(id.Value);
			if (employee is null)
				return null;
			//EmployeeDbo employee1 = new EmployeeDbo
			//{
			//	Address = employee.Address,
			//	Age = employee.Age,
			//	DepartmentId = employee.DepartmentId,
			//	Email = employee.Email,
			//	HiringDate = employee.HiringDate,
			//	ImgUrl = employee.ImgUrl,
			//	Name = employee.Name,
			//	PhoneNumber = employee.PhoneNumber,
			//	Salary = employee.Salary

			//};
			EmployeeDbo employee1 = _mapper.Map<EmployeeDbo>(employee);

			return employee1;
		}
        public IEnumerable<EmployeeDbo> GetEmployeeByName(string name)
        {
            var employees = _unitOfWork.employeeRepository.GetEmployeeByName(name);
			//var mappedEmployee = employees.Select(x => new EmployeeDbo
			//{
			//	DepartmentId = x.DepartmentId,
			//	Email = x.Email,
			//	HiringDate = x.HiringDate,
			//	ImgUrl = x.ImgUrl,
			//	Name = x.Name,
			//	PhoneNumber = x.PhoneNumber,
			//	Salary = x.Salary
			//});
			IEnumerable<EmployeeDbo> mappedEmployee = _mapper.Map<IEnumerable<EmployeeDbo>>(employees);

			return mappedEmployee;
		}
        public void Update(EmployeeDbo employee)
        {
			//_unitOfWork.employeeRepository.Update(employee);
			_unitOfWork.Complete();
		}
    }
}
