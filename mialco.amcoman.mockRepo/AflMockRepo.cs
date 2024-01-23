using mialco.amcoman.dal.Entity;
using mialco.amcoman.repository.Abstraction;
using Microsoft.EntityFrameworkCore.Metadata;

namespace mialco.amcoman.mockRepo
{
	public class AflMockRepo<T> : IAflRepository<T> where T : class
	{
		public T Get(long id)
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
					ImgDescription = "Image description",
					IsActive = true,
					LinkCode = "Link code",
					StartDate = DateTime.Now


				} as T;


			}
			return result;
		}

		public IEnumerable<T> GetAll(int page, int pageSize)
		{
			IEnumerable<T>? result = null; ;

			if (typeof(T) == typeof(AflProduct))
			{
				result = new List<AflProduct> {
				new AflProduct {
					ProductName="Product1",
					Id=1,
					Description ="Product1 descrition",
					Price=1222.3m,
					RecordStatus="A",
					AdditionalInfoTitle="Additional Info Title",
					AdditionalInfoUrl = "Additional Info Url",
					ImgAlt ="Image alt",
					ImgDescription = "Image Description",
					IsActive = true,
					ImgUrl = "http://mialco.com/images/thumbs/0000091_e-commerce-installation-on-aws-basic-installation_415.jpeg",
					NavigateUrl= "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					StartDate= DateTime.Now,
					EndDate = DateTime.Now.AddDays(1000),
					Advertiser="Advertizer name:",
					AdvertizerLinkID = "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					LinkCode="sae3d5412",
					},
				new AflProduct {
					ProductName="Product2",
					Id=2,
					Description ="Product2 descrition",
					Price=1234.3m,
					RecordStatus="A",
					AdditionalInfoTitle="Additional Info Title",
					AdditionalInfoUrl = "Additional Info Url",
					ImgAlt ="Image alt",
					ImgDescription = "Image Description",
					IsActive = true,
					ImgUrl = "http://mialco.com/images/thumbs/0000091_e-commerce-installation-on-aws-basic-installation_415.jpeg",
					NavigateUrl= "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					StartDate= DateTime.Now,
					EndDate = DateTime.Now.AddDays(1000),
					Advertiser="Advertizer name:",
					AdvertizerLinkID = "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					LinkCode="sae3d5412",
				},
				new AflProduct {
					ProductName="Product3",
					Id=3,
					Description ="Product3 descrition",
					Price=1234.3m,
					RecordStatus="A",
					AdditionalInfoTitle="Additional Info Title",
					AdditionalInfoUrl = "Additional Info Url",
					ImgAlt ="Image alt",
					ImgDescription = "Image Description",
					IsActive = true,
					ImgUrl = "http://mialco.com/images/thumbs/0000091_e-commerce-installation-on-aws-basic-installation_415.jpeg",
					NavigateUrl= "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					StartDate= DateTime.Now,
					EndDate = DateTime.Now.AddDays(1000),
					Advertiser="Advertizer name:",
					AdvertizerLinkID = "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					LinkCode="sae3d5412",
				},
								new AflProduct {
					ProductName="Product2",
					Id=4,
					Description ="Product2 descrition",
					Price=1234.3m,
					RecordStatus="A",
					AdditionalInfoTitle="Additional Info Title",
					AdditionalInfoUrl = "Additional Info Url",
					ImgAlt ="Image alt",
					ImgDescription = "Image Description",
					IsActive = true,
					ImgUrl = "http://mialco.com/images/thumbs/0000091_e-commerce-installation-on-aws-basic-installation_415.jpeg",
					NavigateUrl= "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					StartDate= DateTime.Now,
					EndDate = DateTime.Now.AddDays(1000),
					Advertiser="Advertizer name:",
					AdvertizerLinkID = "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					LinkCode="sae3d5412",

				},
												new AflProduct {
					ProductName="Product3",
					Id=33,
					Description ="Product33 descrition",
					Price=1234.3m,
					RecordStatus="A",
					AdditionalInfoTitle="Additional Info Title",
					AdditionalInfoUrl = "Additional Info Url",
					ImgAlt ="Image alt",
					ImgDescription = "Image Description",
					IsActive = true,
					ImgUrl = "http://mialco.com/images/thumbs/0000091_e-commerce-installation-on-aws-basic-installation_415.jpeg",
					NavigateUrl= "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					StartDate= DateTime.Now,
					EndDate = DateTime.Now.AddDays(1000),
					Advertiser="Advertizer name:",
					AdvertizerLinkID = "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					LinkCode="sae3d5412",

				},
				new AflProduct {
					ProductName="Product4",
					Id=43,
					Description ="<b>Product43 descrition</b>",
					Price=1234.3m,
					RecordStatus="A",
					AdditionalInfoTitle="Additional Info Title",
					AdditionalInfoUrl = "Additional Info Url",
					ImgAlt ="Image alt",
					ImgDescription = "Image Description",
					IsActive = true,
					ImgUrl = "http://mialco.com/images/thumbs/0000091_e-commerce-installation-on-aws-basic-installation_415.jpeg",
					NavigateUrl= "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					StartDate= DateTime.Now,
					EndDate = DateTime.Now.AddDays(1000),
					Advertiser="Advertizer name:",
					AdvertizerLinkID = "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					LinkCode="sae3d5412",

				},
				new AflProduct {
					ProductName="Product5",
					Id=5,
					Description ="Product5 descrition",
					Price=1234.3m,
					RecordStatus="A",
					AdditionalInfoTitle="Additional Info Title",
					AdditionalInfoUrl = "Additional Info Url",
					ImgAlt ="Image alt",
					ImgDescription = "Image Description",
					IsActive = true,
					ImgUrl = "http://mialco.com/images/thumbs/0000091_e-commerce-installation-on-aws-basic-installation_415.jpeg",
					NavigateUrl= "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					StartDate= DateTime.Now,
					EndDate = DateTime.Now.AddDays(1000),
					Advertiser="Advertizer name:",
					AdvertizerLinkID = "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					LinkCode="sae3d5412",

				},
				new AflProduct {
					ProductName="Product6",
					Id=6,
					Description ="<h1>Product6</h1><br><h2>description</h2>",
					Price=1234.3m,
					RecordStatus="A",
					AdditionalInfoTitle="Additional Info Title",
					AdditionalInfoUrl = "Additional Info Url",
					ImgAlt ="Image alt",
					ImgDescription = "Image Description",
					IsActive = true,
					ImgUrl = "http://mialco.com/images/thumbs/0000091_e-commerce-installation-on-aws-basic-installation_415.jpeg",
					NavigateUrl= "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					StartDate= DateTime.Now,
					EndDate = DateTime.Now.AddDays(1000),
					Advertiser="Advertizer name:",
					AdvertizerLinkID = "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					LinkCode="sae3d5412",

				},
				new AflProduct {
					ProductName="Product7",
					Id=7,
					Description ="Product7 descrition",
					Price=1234.3m,
					RecordStatus="A",
					AdditionalInfoTitle="Additional Info Title",
					AdditionalInfoUrl = "Additional Info Url",
					ImgAlt ="Image alt",
					ImgDescription = "Image Description",
					IsActive = true,
					ImgUrl = "http://mialco.com/images/thumbs/0000091_e-commerce-installation-on-aws-basic-installation_415.jpeg",
					NavigateUrl= "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					StartDate= DateTime.Now,
					EndDate = DateTime.Now.AddDays(1000),
					Advertiser="Advertizer name:",
					AdvertizerLinkID = "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					LinkCode="sae3d5412",

				},
				new AflProduct {
					ProductName="Product8",
					Id=8,
					Description ="Product8 descrition",
					Price=1234.3m,
					RecordStatus="A",
					AdditionalInfoTitle="Additional Info Title",
					AdditionalInfoUrl = "Additional Info Url",
					ImgAlt ="Image alt",
					ImgDescription = "Image Description",
					IsActive = true,
					ImgUrl = "http://mialco.com/images/thumbs/0000091_e-commerce-installation-on-aws-basic-installation_415.jpeg",
					NavigateUrl= "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					StartDate= DateTime.Now,
					EndDate = DateTime.Now.AddDays(1000),
					Advertiser="Advertizer name:",
					AdvertizerLinkID = "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					LinkCode="sae3d5412",

				}

			} as List<T>;
			}


			return result;
		}

		public IEnumerable<T> GetAllForSeed(int page, int pageSize)
		{
			IEnumerable<T>? result = null; ;

			if (typeof(T) == typeof(AflProduct))
			{
				result = new List<AflProduct> {
				new AflProduct {
					ProductName="Product1",
					//Id=1,
					Description ="Product1 descrition",
					Price=1222.3m,
					RecordStatus="A",
					AdditionalInfoTitle="Additional Info Title",
					AdditionalInfoUrl = "Additional Info Url",
					ImgAlt ="Image alt",
					ImgDescription = "Image Description",
					IsActive = true,
					ImgUrl = "http://mialco.com/images/thumbs/0000091_e-commerce-installation-on-aws-basic-installation_415.jpeg",
					NavigateUrl= "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					StartDate= DateTime.Now,
					EndDate = DateTime.Now.AddDays(1000),
					Advertiser="Advertizer name:",
					AdvertizerLinkID = "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					LinkCode="sae3d5412",
					},
				new AflProduct {
					ProductName="Product2",
					//Id=2,
					Description ="Product2 descrition",
					Price=1234.3m,
					RecordStatus="A",
					AdditionalInfoTitle="Additional Info Title",
					AdditionalInfoUrl = "Additional Info Url",
					ImgAlt ="Image alt",
					ImgDescription = "Image Description",
					IsActive = true,
					ImgUrl = "http://mialco.com/images/thumbs/0000091_e-commerce-installation-on-aws-basic-installation_415.jpeg",
					NavigateUrl= "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					StartDate= DateTime.Now,
					EndDate = DateTime.Now.AddDays(1000),
					Advertiser="Advertizer name:",
					AdvertizerLinkID = "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					LinkCode="sae3d5412",
				},
				new AflProduct {
					ProductName="Product3",
					//Id=3,
					Description ="Product3 descrition",
					Price=1234.3m,
					RecordStatus="A",
					AdditionalInfoTitle="Additional Info Title",
					AdditionalInfoUrl = "Additional Info Url",
					ImgAlt ="Image alt",
					ImgDescription = "Image Description",
					IsActive = true,
					ImgUrl = "http://mialco.com/images/thumbs/0000091_e-commerce-installation-on-aws-basic-installation_415.jpeg",
					NavigateUrl= "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					StartDate= DateTime.Now,
					EndDate = DateTime.Now.AddDays(1000),
					Advertiser="Advertizer name:",
					AdvertizerLinkID = "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					LinkCode="sae3d5412",
				},
								new AflProduct {
					ProductName="Product2",
					//Id=4,
					Description ="Product2 descrition",
					Price=1234.3m,
					RecordStatus="A",
					AdditionalInfoTitle="Additional Info Title",
					AdditionalInfoUrl = "Additional Info Url",
					ImgAlt ="Image alt",
					ImgDescription = "Image Description",
					IsActive = true,
					ImgUrl = "http://mialco.com/images/thumbs/0000091_e-commerce-installation-on-aws-basic-installation_415.jpeg",
					NavigateUrl= "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					StartDate= DateTime.Now,
					EndDate = DateTime.Now.AddDays(1000),
					Advertiser="Advertizer name:",
					AdvertizerLinkID = "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					LinkCode="sae3d5412",

				},
												new AflProduct {
					ProductName="Product3",
					//Id=33,
					Description ="Product33 descrition",
					Price=1234.3m,
					RecordStatus="A",
					AdditionalInfoTitle="Additional Info Title",
					AdditionalInfoUrl = "Additional Info Url",
					ImgAlt ="Image alt",
					ImgDescription = "Image Description",
					IsActive = true,
					ImgUrl = "http://mialco.com/images/thumbs/0000091_e-commerce-installation-on-aws-basic-installation_415.jpeg",
					NavigateUrl= "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					StartDate= DateTime.Now,
					EndDate = DateTime.Now.AddDays(1000),
					Advertiser="Advertizer name:",
					AdvertizerLinkID = "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					LinkCode="sae3d5412",

				},
				new AflProduct {
					ProductName="Product4",
					//Id=43,
					Description ="<b>Product43 descrition</b>",
					Price=1234.3m,
					RecordStatus="A",
					AdditionalInfoTitle="Additional Info Title",
					AdditionalInfoUrl = "Additional Info Url",
					ImgAlt ="Image alt",
					ImgDescription = "Image Description",
					IsActive = true,
					ImgUrl = "http://mialco.com/images/thumbs/0000091_e-commerce-installation-on-aws-basic-installation_415.jpeg",
					NavigateUrl= "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					StartDate= DateTime.Now,
					EndDate = DateTime.Now.AddDays(1000),
					Advertiser="Advertizer name:",
					AdvertizerLinkID = "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					LinkCode="sae3d5412",

				},
				new AflProduct {
					ProductName="Product5",
					//Id=5,
					Description ="Product5 descrition",
					Price=1234.3m,
					RecordStatus="A",
					AdditionalInfoTitle="Additional Info Title",
					AdditionalInfoUrl = "Additional Info Url",
					ImgAlt ="Image alt",
					ImgDescription = "Image Description",
					IsActive = true,
					ImgUrl = "http://mialco.com/images/thumbs/0000091_e-commerce-installation-on-aws-basic-installation_415.jpeg",
					NavigateUrl= "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					StartDate= DateTime.Now,
					EndDate = DateTime.Now.AddDays(1000),
					Advertiser="Advertizer name:",
					AdvertizerLinkID = "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					LinkCode="sae3d5412",

				},
				new AflProduct {
					ProductName="Product6",
					//Id=6,
					Description ="<h1>Product6</h1><br><h2>description</h2>",
					Price=1234.3m,
					RecordStatus="A",
					AdditionalInfoTitle="Additional Info Title",
					AdditionalInfoUrl = "Additional Info Url",
					ImgAlt ="Image alt",
					ImgDescription = "Image Description",
					IsActive = true,
					ImgUrl = "http://mialco.com/images/thumbs/0000091_e-commerce-installation-on-aws-basic-installation_415.jpeg",
					NavigateUrl= "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					StartDate= DateTime.Now,
					EndDate = DateTime.Now.AddDays(1000),
					Advertiser="Advertizer name:",
					AdvertizerLinkID = "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					LinkCode="sae3d5412",

				},
				new AflProduct {
					ProductName="Product7",
					//Id=7,
					Description ="Product7 descrition",
					Price=1234.3m,
					RecordStatus="A",
					AdditionalInfoTitle="Additional Info Title",
					AdditionalInfoUrl = "Additional Info Url",
					ImgAlt ="Image alt",
					ImgDescription = "Image Description",
					IsActive = true,
					ImgUrl = "http://mialco.com/images/thumbs/0000091_e-commerce-installation-on-aws-basic-installation_415.jpeg",
					NavigateUrl= "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					StartDate= DateTime.Now,
					EndDate = DateTime.Now.AddDays(1000),
					Advertiser="Advertizer name:",
					AdvertizerLinkID = "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					LinkCode="sae3d5412",

				},
				new AflProduct {
					ProductName="Product8",
					//Id=8,
					Description ="Product8 descrition",
					Price=1234.3m,
					RecordStatus="A",
					AdditionalInfoTitle="Additional Info Title",
					AdditionalInfoUrl = "Additional Info Url",
					ImgAlt ="Image alt",
					ImgDescription = "Image Description",
					IsActive = true,
					ImgUrl = "http://mialco.com/images/thumbs/0000091_e-commerce-installation-on-aws-basic-installation_415.jpeg",
					NavigateUrl= "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					StartDate= DateTime.Now,
					EndDate = DateTime.Now.AddDays(1000),
					Advertiser="Advertizer name:",
					AdvertizerLinkID = "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
					LinkCode="sae3d5412",

				}

			} as List<T>;
			}


			return result;
		}


	}
}
