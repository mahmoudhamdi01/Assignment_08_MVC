using Company.Data.Context;
using Company.Data.Entities;
using Company.repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.repository.Reposatories
{
	public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
	{
		private readonly CompanyDBContext _context;

		public DepartmentRepository(CompanyDBContext context) : base(context) 
		{
			_context = context;
		}

		object IDepartmentRepository.All()
		{
			throw new NotImplementedException();
		}
	}
}

