using mialco.amcoman.dal.Entity;
using mialco.amcoman.repository.Abstraction;
using Microsoft.EntityFrameworkCore.Metadata;

namespace mialco.amcoman.mockRepo
{
	public class AflMockRepo<T> : IAflRepository<T> where T : class
	{
		public T Get(int id)
		{
			T? result = default(T);
			var entityType = typeof(T);
			if (entityType == typeof(AflProduct))
			{
				result = new AflProduct
				{
					ProductName = "Product1",
					Id = 1,
					Description = "Product1 descrition",
					Price = 1222.3m,
					RecordStatus = "A",
					NavigateUrl = "https://mialco.com",
					ImgUrl = "http://unclelouieshop.com/images/thumbs/0000013_2-facoffee-show-ceramic-mug_550.jpeg",
					AdditionalInfoTitle = "Additional Info Title",
					AdditionalInfoUrl = "Additional Info Url",
					Advertiser = "Advertizer",
					AdvertizerLinkID = "advertizerLinkIs",
					EndDate = DateTime.Now,
					ImgAlt = "Img Alt Description",
					ImgDescription="Image description",
					IsActive = true,
					LinkCode="Link code",
					StartDate=DateTime.Now
					
					
				} as T;


			}
			return result;
		}


		IEnumerable<T> IAflRepository<T>.GetAll()
		{
			IEnumerable<T> result = null; ;

			if (typeof(T) == typeof(AflProduct))
			{
				result = new List<AflProduct> {
				new AflProduct {
					ProductName="Product1",
					Id=1,
					Description ="Product1 descrition",
					Price=1222.3m,
					RecordStatus="A"
					},
				new AflProduct {
					ProductName="Product2",
					Id=3,
					Description ="Product2 descrition",
					Price=1234.3m,
					RecordStatus="A"
				}
			} as List<T>;
			}


			return result;
		}
	}
}
