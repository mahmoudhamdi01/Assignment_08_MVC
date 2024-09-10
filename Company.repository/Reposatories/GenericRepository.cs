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
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		private readonly CompanyDBContext _context;
		public GenericRepository(CompanyDBContext context) 
		{
			_context = context;
		}
		public IEnumerable<T> GetAll => 
			_context.Set<T>().ToList();

		public void Add(T entity)
		{
			_context.SaveChanges();
			_context.Add(entity);
		}

		public void Delete(T entity)
		{
			_context.SaveChanges();
			_context.Remove(entity);
		}

		public T GetById(int id)
		=> _context.Set<T>().Find(id);


		public void Update(T entity)
		{
			_context.Update(entity);
			_context.SaveChanges();
		}
	}
}
