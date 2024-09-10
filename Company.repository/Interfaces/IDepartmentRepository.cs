using Company.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.repository.Interfaces
{
	public interface IDepartmentRepository : IGenericRepository<Department>
	{
		object All();
	}
}
