using Company.Data.Context;
using Company.Data.Entities;
using Company.repository.Interfaces;
using Company.repository.Reposatories;
using Company.services.Interfaces;
using Company.services.Mapping;
using Company.services.Services;
using Microsoft.AspNetCore.Identity; 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Complany.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			builder.Services.AddDbContext<CompanyDBContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			});
			builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IDepartmentService, DeapertmentService>();
			builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
			builder.Services.AddAutoMapper(x => x.AddProfile(new EmployeeProfile()));
			builder.Services.AddAutoMapper(x => x.AddProfile(new DepartmentProfile()));

            builder.Services.AddIdentity<Application, IdentityRole>(config =>
			{
				config.Password.RequiredUniqueChars = 2;
				config.Password.RequireDigit = true;
				config.Password.RequireLowercase = true;
				config.Password.RequireUppercase = true;
				config.Password.RequireNonAlphanumeric = true;
				config.Password.RequiredLength = 6;
				config.User.RequireUniqueEmail = true;
				config.Lockout.AllowedForNewUsers = true;
				config.Lockout.MaxFailedAccessAttempts = 3;
				config.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(1);
			}).AddEntityFrameworkStores<CompanyDBContext>()
			  .AddDefaultTokenProviders();

			builder.Services.ConfigureApplicationCookie(options =>
			{
				options.Cookie.HttpOnly = true;
				options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
				options.SlidingExpiration = true;
				options.LoginPath = "/Account/Login";
				options.LogoutPath = "/Account/Logout";
				options.AccessDeniedPath = "/Account/AccountDenied";
				options.Cookie.Name = "admin";
				options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
				options.Cookie.SameSite = SameSiteMode.Strict;
			});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
		
			app.UseAuthorization();
			app.UseAuthentication();
			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
