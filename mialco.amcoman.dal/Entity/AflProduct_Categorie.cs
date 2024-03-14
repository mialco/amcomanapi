using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace mialco.amcoman.dal.Entity
{
	[Table ("AflProducts_Categories")]
	public class AflProduct_Categorie
	{
		[ DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("Id")]
		[Key]
		public int Id { get; set; }	
		[ForeignKey("AflProduct")]
		public long AflProductId { get; set; }
		public int CategoryId { get; set; }
		public virtual AflProduct AflProduct { get; set; }
		public virtual Category Category { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime LastUpdated { get; set; }

	}
}