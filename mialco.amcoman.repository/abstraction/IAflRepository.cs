using mialco.amcoman.dal.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mialco.amcoman.repository.abstraction
{
	public interface IAflRepository<T> where T : class
	{
		IEnumerable<T> GetAll(int page, int pageSize);
		IEnumerable<T> GetAll();
		T Get(int id);
		//AflProductsPage GetAflProductsPage(int page, int pageSize, AflProductFilter filter);
		//AflProductsPage SearchAflProducts(int page, int pageSize, string searchTerms);
		//Task<AflProductsPage> SearchAflProductsAsync(int page, int pageSize, string searchTerms);
		//AflProductItemWithDetails Find(long productId);
		//long Create(AflProductItemWithDetails aflprd);
		//Task<long> CreateAsync(AflProductItemWithDetails prd);
		//bool Update(AflProductItemWithDetails aflprd);
		//Task<bool> UpdateAsync(AflProductItemWithDetails prd);
		//bool Delete(long productId);
		//Task<bool> DeleteAsync(long productId);

		//int Count(AflProductFilter filter);

	}
}
