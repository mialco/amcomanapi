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
	[Table("AflProducts", Schema="Afl")]	
	public class AflProduct : IAflEntity
	{
		//public AflProduct() { }
		//[Key,ForeignKey("AflProductDetail")]
		//[Key, ForeignKey("AflProduct_Categorie"),
		//	Column("ProdID"),
		//	DatabaseGenerated(DatabaseGeneratedOption.Identity)
		//	]
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		public string ProductName { get; set; } = string.Empty;
		public string ? Description { get; set; }= string.Empty;
		public string NavigateUrl { get; set; } = string.Empty;
		public string ? ImgUrl { get; set; }
		public string ? ImgAlt { get; set; }
		public string ? ImgDescription { get; set; }
		public string ? AdditionalInfoTitle { get; set; }
		public string ?  AdditionalInfoUrl { get; set; }
		public string? RecordStatus { get; set; }
		public string? LinkCode { get; set; }
		public string ?Advertiser { get; set; }
		
		public double Price { get; set; }
		public string ?AdvertizerLinkID { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public bool IsActive { get; set; }

		//[ForeignKey("ProdID")]
		//public virtual AflProductDetail AflProductDetail { get; set; }

		//[ForeignKey("ProdID")]
		//public virtual IEnumerable<AflProducts_Categorie> AflProducts_Categories { get; set; }


	}
}
