using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.services.Interfaces.Dbo
{
    public class DepartmentDbo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Code { get; set; }
        public DateTime CreatAt { get; set; }
        public ICollection<EmployeeDbo> employees { get; set; } = new List<EmployeeDbo>();
    }
}
