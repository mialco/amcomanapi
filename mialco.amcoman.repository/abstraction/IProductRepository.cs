using mialco.amcoman.dal.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mialco.amcoman.repository.abstraction
{
	public  interface IProductRepository: IAflRepository<AflProduct>
	{
		IEnumerable<AflProduct> GetProductsByCategoryList(IEnumerable<int> categoryIds, int pageIndex, int pageSize);
		int Count(IEnumerable<int> categoryIds);
	}
}
