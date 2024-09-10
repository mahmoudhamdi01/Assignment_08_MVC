using Company.Data.Entities;
using Company.services.Interfaces.Dbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.services.Interfaces
{
    public interface IDepartmentService
    {
        DepartmentDbo GetById(int? id);
        IEnumerable<DepartmentDbo> GetAll();
        void Add(DepartmentDbo department);
        void Update(DepartmentDbo department);
        void Delete(DepartmentDbo department);
    }
}
