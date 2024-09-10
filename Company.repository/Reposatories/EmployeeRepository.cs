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
	public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
	{
		private readonly CompanyDBContext _context;

		public EmployeeRepository(CompanyDBContext context) : base(context)
		{
			_context = context;
		}

		public Employee GetEmployeeByName(string name)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Employee> GetEmplyeeByAddress(string address)
		{
			throw new NotImplementedException();
		}
	}
}
