using mialco.amcoman.dal.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mialco.amcoman.dal.Entity
{
	[Table("Categories")]
	public class Category: IAflEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int ParentCategoryId { get; set; }
		public string CategoryName { get; set; } = string.Empty;
		public string CategoryDescription { get; set; } = string.Empty;
		public string CategoryUrl { get; set; } = string.Empty;
		public string CategoryImgUrl { get; set; } = string.Empty;
		public string CategoryImgAlt { get; set; } = string.Empty;
		public string CategoryImgDescription { get; set; } = string.Empty;
		public string CategoryAdditionalInfoTitle { get; set; } = string.Empty;
		public string CategoryAdditionalInfoUrl { get; set; } = string.Empty;
		public string CategoryRecordStatus { get; set; } = string.Empty;
		public string CategoryLinkCode { get; set; } = string.Empty;
		public string CategoryAdvertiser { get; set; } = string.Empty;
		[Column(TypeName = "decimal(18,2)")]
		public decimal CategoryPrice { get; set; }
		public string CategoryAdvertiserLinkID { get; set; } = string.Empty;
		public DateTime CategoryStartDate { get; set; }
		public DateTime CategoryEndDate { get; set; }
		public bool IsActive { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime LastUpdated { get; set; }
		public virtual IEnumerable<AflProduct_Categorie> AflProducts_Categories { get; set; }

	}
}
