using mialco.amcoman.dal.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace mialco.amcoman.dal.Entity
{
	[Index(nameof(Name), IsUnique = true)]
	public class TopicTemplate:IAflEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Column(TypeName = "nvarchar(100)")]
		public string Name { get; set; }
		public string? Description { get; set; }
		public string? Body { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime LastUpdated { get; set; }
		//navigation property
		public virtual IEnumerable<Topic> Topics { get; set; }
	}
}
