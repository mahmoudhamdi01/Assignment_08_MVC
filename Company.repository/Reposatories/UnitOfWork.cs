using Company.Data.Context;
using Company.repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.repository.Reposatories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyDBContext _Context;
        public UnitOfWork(CompanyDBContext context)
        {
            _Context = context;
            departmentRepository = new DepartmentRepository(context);
            employeeRepository = new EmployeeRepository(context);
        }
        public IDepartmentRepository departmentRepository { get; set; }
        public IEmployeeRepository employeeRepository { get; set; }

        public int Complete()
        => _Context.SaveChanges();
    }
}
