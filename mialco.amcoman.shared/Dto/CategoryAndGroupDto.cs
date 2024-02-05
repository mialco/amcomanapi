using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mialco.amcoman.shared.Dto
{
	public class CategoryAndGroupDto
	{
		public int CateogoryId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int CategoryGroupId { get; set; }
		public string GroupName { get; set; }
	}
}
