using mialco.amcoman.dal.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
			modelBuilder.ApplyConfiguration<IdentityRole>(new RoleConfiguration());
			modelBuilder.Entity<AflProduct_Categorie>().HasOne(p => p.AflProduct).WithMany(p => p.AflProducts_Categories).HasForeignKey(p => p.AflProductId);
		}
	}


	public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
	{
		public void Configure(EntityTypeBuilder<IdentityRole> builder)
		{
			builder.HasData(
				new IdentityRole
				{
					Name = "Admin",
					NormalizedName = "ADMIN"
				},
				new IdentityRole
				{
					Name = "User",
					NormalizedName = "USER"
				}
			);
		}
	}
}
