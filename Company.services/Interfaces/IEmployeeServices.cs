using Company.Data.Entities;
using Company.services.Interfaces.Dbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.services.Interfaces
{
    public interface IEmployeeServices
    {
        EmployeeDbo GetById(int? id);
        IEnumerable<EmployeeDbo> GetAll();
        void Add(EmployeeDbo employee);
        void Update(EmployeeDbo employee);
        void Delete(EmployeeDbo employee);
        IEnumerable<EmployeeDbo> GetEmployeeByName(string name);
    }
}
