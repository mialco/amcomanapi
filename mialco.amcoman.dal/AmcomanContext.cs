using mialco.amcoman.dal.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace mialco.amcoman.dal
{
	public class AmcomanContext: IdentityDbContext<ApplicationUser>           //DbContext
	{
		public AmcomanContext(DbContextOptions<AmcomanContext> options) : base(options) { }

		public DbSet<AflProduct> AflProducts { get; set; }
		public DbSet<AflProduct_Categorie> AflProducts_Categories { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Category_CategoryGroup> Categories_CategoryGroups { get; set; }
		public DbSet<CategoryGroup> CategoryGroups { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
 			base.OnModelCreating(modelBuilder);
			//modelBuilder.Entity<AflProduct>().
	
		}
	}
}
