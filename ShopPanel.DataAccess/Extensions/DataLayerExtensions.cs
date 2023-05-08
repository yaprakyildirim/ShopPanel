using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopPanel.DataAccess.Context;
using ShopPanel.DataAccess.Repositories;
using ShopPanel.DataAccess.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopPanel.DataAccess.Extensions
{
	public static class DataLayerExtensions
	{
		public static IServiceCollection LoadDataLayerExtensions(this IServiceCollection services, IConfiguration config)
		{
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));

			services.AddScoped<IUnitOfWork, UnitOfWork>();

			return services;
		}
	}
}
