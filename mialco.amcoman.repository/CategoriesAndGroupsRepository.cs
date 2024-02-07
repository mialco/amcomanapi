using mialco.amcoman.dal;
using mialco.amcoman.dal.Entity;
using mialco.amcoman.repository.abstraction;
using mialco.amcoman.shared.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mialco.amcoman.repository
{
	public class CategoriesAndGroupsRepository : ICategoriesAndGroupsRepository
	{

		private readonly AmcomanContext _amcomanContext;
		private readonly DbSet<Category> _categorySet;

		public CategoriesAndGroupsRepository(AmcomanContext amcomanContext)
		{
			this._amcomanContext = amcomanContext;
			_categorySet = _amcomanContext.Categories;
		}


		public Category Get(int id)
		{
			return _categorySet.Find(id);
		}

		public IEnumerable<Category> GetAll(int page, int pageSize)
		{
			var skipRecords = (page - 1) * pageSize;
			return _categorySet.Skip(skipRecords).Take(pageSize).ToList();
		}

		public IEnumerable<Category> GetAll()
		{
			return _categorySet.ToList();
		}

		public IEnumerable<CategoryAndGroupDto> GetCategoriesWithGroupsBasic(IEnumerable<int> groupFilterIds)
		{
			var categoriesAndGroups = _amcomanContext.Categories
				.Include(c => c.Category_CategoryGroups)
				.ThenInclude(cg => cg.CategoryGroup)
				.Where(c => c.Category_CategoryGroups.Any(cg => groupFilterIds.Contains(cg.CategoryGroupId) 
				&& cg.IsActive && c.IsActive))
				.Select(c => new CategoryAndGroupDto
				{
					CategoryId = c.Id,
					ParentId = c.ParentCategoryId,
					Name = c.CategoryName,
					Description = c.CategoryDescription,
					CategoryGroupId = c.Category_CategoryGroups.First().CategoryGroupId,
					GroupName = c.Category_CategoryGroups.First().CategoryGroup.GroupName
				}).ToList();
		
			
			return categoriesAndGroups;
		}

		public IEnumerable<CategoryAndGroupDto> GetCategoriesWithGroupsBasic(bool isActive)
		{
			var categoriesAndGroups = _amcomanContext.Categories
				.Include(c => c.Category_CategoryGroups)
				.ThenInclude(cg => cg.CategoryGroup)
				.Where(c => c.Category_CategoryGroups.Any(cg => c.IsActive == isActive && cg.IsActive == isActive))
				.Select(c => new CategoryAndGroupDto
				{
					CategoryId = c.Id,
					ParentId = c.ParentCategoryId,
					Name = c.CategoryName,
					Description = c.CategoryDescription,
					CategoryGroupId = c.Category_CategoryGroups.First().CategoryGroupId,
					GroupName = c.Category_CategoryGroups.First().CategoryGroup.GroupName
				}).ToList();


			return categoriesAndGroups;
		}


		//IEnumerable<CategoryAndGroupDto> ICategoriesAndGroupsRepository.GetCategoriesWithGroupsBasic(System.Collections.Generic.IEnumerable<int> groupFilterIds)
		//{
		//	return this.GetCategoriesWithGroupsBasic(groupFilterIds);
		//}

	}
}
