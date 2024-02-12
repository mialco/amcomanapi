using mialco.amcoman.dal.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace mialco.amcoman.dal.Entity
{
	public class RefreshToken
	{
		public int Id { get; set; }
		public string Token { get; set; }
		public string JwtId { get; set; }
		public System.DateTime DateAdded { get; set; }
		public System.DateTime DateExpire { get; set; }
		public string UserId { get; set; }
        public  bool IsRevoked { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
    }
}
