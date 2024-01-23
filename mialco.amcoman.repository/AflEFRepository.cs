﻿using mialco.amcoman.dal;
using mialco.amcoman.dal.Abstraction;
using mialco.amcoman.repository.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace mialco.amcoman.repository
{
	public class AflEFRepository<T> : IAflRepository<T> where T : class
	{
		private AmcomanContext _context;
		private DbSet<T> _dbSet;

		public AflEFRepository(AmcomanContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}
		public T Get(long id)
		{
			return _dbSet.Find(id);
		}

		public IEnumerable<T> GetAll()
		{
			return _dbSet.ToList();
		}

		public IEnumerable<T> GetAll(int page, int pageSize)
		{
			return _dbSet.ToList();
		}

	}
}
