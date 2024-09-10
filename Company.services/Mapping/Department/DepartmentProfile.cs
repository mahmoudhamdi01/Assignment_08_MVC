using AutoMapper;
using Company.Data.Entities;
using Company.services.Interfaces.Dbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.services.Mapping
{
	public class DepartmentProfile : Profile
	{
		public DepartmentProfile() 
		{
			CreateMap<Department, DepartmentDbo>().ReverseMap();
		}
	}
}
