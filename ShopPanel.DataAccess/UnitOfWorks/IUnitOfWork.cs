using ShopPanel.Core.Entities;
using ShopPanel.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopPanel.DataAccess.UnitOfWorks
{
	public interface IUnitOfWork : IAsyncDisposable
	{
		IRepository<T> GetRepository<T>() where T : class, IEntityBase, new();

		Task<int> SaveAsync();
		int Save();
	}
}
