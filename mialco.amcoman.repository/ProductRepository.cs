using mialco.amcoman.dal;
using mialco.amcoman.dal.Entity;
using mialco.amcoman.repository.abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mialco.amcoman.repository
{
	public class ProductRepository : IProductRepository
	{
		private AmcomanContext _amcomanContext;
		private DbSet<AflProduct> _productSet;
		public ProductRepository(AmcomanContext amcomanContext)
		{
			_amcomanContext = amcomanContext;
			_productSet = _amcomanContext.AflProducts;
		}
		public AflProduct Get(int id)
		{
			return _productSet.Find(id);
		}

		public IEnumerable<AflProduct> GetAll(int page, int pageSize)
		{
			return _productSet.Skip((page - 1) * pageSize).Take(pageSize).ToList();
		}

		public IEnumerable<AflProduct> GetAll()
		{
			return _productSet.ToList();
		}

		/// <summary>
		/// Get products by category list
		/// </summary>
		/// <param name="categoryIds"></param>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public IEnumerable<AflProduct> GetProductsByCategoryList(IEnumerable<int> categoryIds, int currentPage, int pageSize)
		{
			if (pageSize <= 0) 
				return new List<AflProduct>();
			if (currentPage <= 0)
				return new List<AflProduct>();

			if (categoryIds == null || categoryIds.Count() == 0)
			{
				return new List<AflProduct>();
			}
			else
			{
				//return _productSet.Where(p => categoryIds.Contains(p.CategoryId)).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
				//var result = (from p in _productSet
				//			  join pc in _amcomanContext.AflProducts_Categories on p.Id equals pc.ProdId
				//			  where categoryIds.Contains(pc.CatID)
				//			  select p).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
				var result = _productSet.Include(p => p.AflProducts_Categories)
					.Where(p => categoryIds.Contains(p.AflProducts_Categories.FirstOrDefault().CategoryId))
					.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
				return result;
			}
		}
		
		public int Count(IEnumerable<int> categoryIds)
		{
			if (categoryIds == null || categoryIds.Count() == 0)
			{
				return 0;
			}
			else
			{
				return _productSet.Include(p => p.AflProducts_Categories)
					.Where(p => categoryIds.Contains(p.AflProducts_Categories.FirstOrDefault().CategoryId)).Count();
			}
		}


	}
}
