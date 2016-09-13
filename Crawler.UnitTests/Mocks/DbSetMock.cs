using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Crawler.UnitTests.Mocks
{
	public class DbSetMock<TEntity> : DbSet<TEntity>, IEnumerable<TEntity>, IQueryable
		where TEntity : class
	{
		private IList<TEntity> _data;
		private IQueryable _query;

		public DbSetMock()
		{
			this._data = new List<TEntity>();
			this._query = this._data.AsQueryable();
		}

		public override TEntity Add(TEntity entity)
		{
			this._data.Add(entity);
			return entity;
		}

		Type IQueryable.ElementType => _query.ElementType;

		Expression IQueryable.Expression => _query.Expression;

		IQueryProvider IQueryable.Provider => _query.Provider;

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _data.GetEnumerator();
		}

		IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
		{
			return _data.GetEnumerator();
		}
	}
}
