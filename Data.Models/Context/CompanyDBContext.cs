using Company.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
 
namespace Company.Data.Context
{
	public class CompanyDBContext : IdentityDbContext<Application>
	{
		

		public CompanyDBContext(DbContextOptions<CompanyDBContext> options) : base(options)
		{
		}
		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	optionsBuilder.UseSqlServer("server = .; database = testDB; trust_connection = true;");
		//}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			//modelBuilder.Entity<BaseEntity>().HasQueryFilter(x => !x.IsDeleted);
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Employee> employees { get; set; }	
		public DbSet<Department> departments { get; set; }	

		
	}
}
