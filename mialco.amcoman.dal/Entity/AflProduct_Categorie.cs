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
		public int ProdId { get; set; }
		public int CatID { get; set; }
		public virtual AflProduct AflProduct { get; set; }
		public virtual Category Category { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime LastUpdated { get; set; }

	}
}