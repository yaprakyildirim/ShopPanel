﻿using ShopPanel.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopPanel.DataAccess.Repositories
{
	public interface IRepository<T> where T : class, IEntityBase, new()
	{
		Task AddSync(T entity);
		Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);

		Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
		Task<T> GetByGuidAsync(Guid id);
		Task<T> UpdateAsync(T entity);
		Task DeleteAsync(T entity);
		Task<bool> AnySync(Expression<Func<T, bool>> predicate);
		Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
	}
}
