using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mialco.amcoman.shared.Dto
{
	public class CategoryGroupListViewDto
	{
		public int Id { get; set; }
		public string GroupName { get; set; } = string.Empty;
		public string? GroupDescription { get; set; } = string.Empty;
	}
}
