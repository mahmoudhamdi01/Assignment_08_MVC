using AutoMapper;
using Company.Data.Entities;
using Company.repository.Interfaces;
using Company.services.Interfaces;
using Company.services.Interfaces.Dbo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.services.Services
{
    public class DeapertmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public DeapertmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(DepartmentDbo department)
        {
			//Department department1 = new Department
			//{ 
			//    Code = department.Code,
			//    Name = department.Name,
			//    CreateAt = DateTime.Now,

			//};
			Department department1 = _mapper.Map<Department>(department);
			_unitOfWork.departmentRepository.Add(department1);
            _unitOfWork.Complete();
		}

        public void Delete(DepartmentDbo department)
        {
			//Department department1 = new Department
			//{
			//	Code = department.Code,
			//	Name = department.Name,
			//	CreateAt = DateTime.Now,

			//};
			Department department1 = _mapper.Map<Department>(department);
			_unitOfWork.departmentRepository.Delete(department1);
			_unitOfWork.Complete();
		}

        public IEnumerable<DepartmentDbo> GetAll()
        {
			var Department = _unitOfWork.employeeRepository.GetAll;
			//var mappedDepartment = Department.Select(x => new DepartmentDbo
			//{
			//    Id = x.Id,
			//    Name = x.Name,
			//    CreatAt = DateTime.Now
			//});
			IEnumerable<DepartmentDbo> mappedDepartment = _mapper.Map<IEnumerable<DepartmentDbo>>(Department);

			return mappedDepartment;
		}

        public DepartmentDbo GetById(int? id)
        {
			if (id is null)
				return null;
			var department = _unitOfWork.departmentRepository.GetById(id.Value);
			if (department is null)
				return null;
			//DepartmentDbo department1 = new DepartmentDbo
			//{
			//	Id = department.Id,
			//             Name = department.Name,
			//             Code = department.Code,
			//             CreatAt= DateTime.Now

			//};
			DepartmentDbo department1  = _mapper.Map<DepartmentDbo>(department);

			return department1;
		}

        

        public void Update(DepartmentDbo department)
        {
            
            //_unitOfWork.departmentRepository.Update(department);
            _unitOfWork.Complete();
        }
    }
}
