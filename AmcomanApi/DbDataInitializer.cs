using mialco.amcoman.dal;
using mialco.amcoman.dal.Entity;
using mialco.amcoman.mockRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmcomanApi
{
	internal class DbDataInitializer
	{
		public static void Seed(IApplicationBuilder appBuilder)
		{
			using (var serviceScope = appBuilder.ApplicationServices.CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetService<AmcomanContext>();
				if (! context.AflProducts.Any())
				{
					var mockRepo = new AflMockRepo<AflProduct>();
					var aflProducts = mockRepo.GetAllForSeed(1, 1);
					context.AddRange(aflProducts);

					context.SaveChanges();
				}
				
			}
		
		}
	}
}
