using Company.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.repository.Interfaces
{
	public interface IEmployeeRepository : IGenericRepository<Employee>
	{
		Employee GetEmployeeByName(string name);
		IEnumerable<Employee> GetEmplyeeByAddress(string address);
	}
}
