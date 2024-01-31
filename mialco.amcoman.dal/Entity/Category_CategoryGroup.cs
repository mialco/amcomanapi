using mialco.amcoman.dal.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mialco.amcoman.dal.Entity
{
	[Table("Categories_CategoryGroups")]
	public class Category_CategoryGroup: IAflEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int CategoryId { get; set; }
		public int CategoryGroupId { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime LastUpdated { get; set; }

		public virtual Category Category { get; set; }
		public virtual CategoryGroup CategoryGroup { get; set; }


	}
}
