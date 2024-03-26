using mialco.amcoman.dal.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mialco.amcoman.dal.Entity
{
	[Index(nameof(Name), IsUnique = true)]
	public class Topic:IAflEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Name { get; set; }
		public string ? Description { get; set; }
		public string ? Title { get; set; }
		public string? Body { get; set; }
        public bool IncludeInSitemap { get; set; }
        public bool IncludeInUserMenu { get; set; }
        public bool IncludeInUserFooter { get; set; }
        public int Order { get; set; }
        public string ? MetaKeywords { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaTitle { get; set; }
        public bool	IsActive { get; set; }
        public int TopicTemplateId { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime LastUpdated { get; set; }
		public virtual TopicTemplate TopicTemplate { get; set; }
	}
}
