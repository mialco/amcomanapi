using mialco.amcoman.dal.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mialco.amcoman.dal
{
	public class AmcomanContext: DbContext
	{
		public AmcomanContext(DbContextOptions<AmcomanContext> options) : base(options) { }

		public DbSet<AflProduct> AflProducts { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//base.OnModelCreating(modelBuilder);
			//modelBuilder.Entity<AflProduct>().
		}
	}
}
