using Company.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.services.Interfaces.Dbo
{
    public class EmployeeDbo
    {
		public string Name { get; set; }
		public string Address { get; set; }
		public int Age { get; set; }
		public DateTime HiringDate { get; set; }
		public Decimal Salary { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public IFormFile Image { get; set; }
		public string? ImgUrl { get; set; }
		public Department Department { get; set; }
		public int? DepartmentId { get; set; }
	}
}
