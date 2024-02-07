using mialco.amcoman.shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mialco.amcoman.shared.Abstraction
{
	public interface IAmcomanApiUtils
	{
		public string GetApiUrl(string apiName);
		public IEnumerable<CategoryTreeDto> BuildCategoryTree(List<CategoryAndGroupDto> categoryAndGroupList);
	}
}
