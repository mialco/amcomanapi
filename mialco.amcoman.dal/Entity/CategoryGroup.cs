using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mialco.amcoman.dal.Entity
{
	[Table("CategoryGroups")]
	public class CategoryGroup
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string GroupName { get; set; } = string.Empty;
		public string GroupDescription { get; set; } = string.Empty;
		public bool IsActive { get; set; }	
		public DateTime CreatedAt { get; set; } 
		public DateTime LastUpdated { get; set; }
	
		public virtual IEnumerable<Category_CategoryGroup> Categories_CategoryGroups { get; set; }
		
	
	}
}
