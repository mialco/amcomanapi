using mialco.amcoman.dal;
using mialco.amcoman.dal.Entity;
using mialco.amcoman.repository.abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace mialco.amcoman.repository
{
	public class GroupsRepository : IGroupsRepository
	{
		private AmcomanContext _amcomanContext;
		private DbSet<CategoryGroup> _groupSet;

		public GroupsRepository(AmcomanContext amcomanContext)
		{
			_amcomanContext = amcomanContext;
			_groupSet = _amcomanContext.CategoryGroups;
		}

		public IEnumerable<CategoryGroup> GetActive(bool isActive)
		{
			return _groupSet.Where(x => x.IsActive == isActive).ToList();	
		}

		public IEnumerable<CategoryGroup> GetActive(bool isActive, int page, int pageSize)
		{
			return _groupSet.Where(x => x.IsActive == isActive).Skip((page - 1) * pageSize).Take(pageSize).ToList();
		}

		public IEnumerable<CategoryGroup> GetAll(int page, int pageSize)
		{
			return _groupSet.Skip((page - 1) * pageSize).Take(pageSize).ToList();
		}

		public IEnumerable<CategoryGroup> GetAll()
		{
			return _groupSet.ToList();
		}

		CategoryGroup IAflRepository<CategoryGroup>.Get(int id)
		{
			return _groupSet.Find(id);
		}
	}
}
