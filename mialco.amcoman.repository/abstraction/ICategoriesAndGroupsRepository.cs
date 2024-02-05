using mialco.amcoman.dal.Entity;
using mialco.amcoman.shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mialco.amcoman.repository.abstraction
{
	public interface ICategoriesAndGroupsRepository: IAflRepository<Category>
	{
		public IEnumerable<CategoryAndGroupDto> GetCategoriesWithGroupsBasic(IEnumerable<int> groupFilterIds);
	}
}
