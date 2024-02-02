using mialco.amcoman.dal.Entity;
using mialco.amcoman.repository.Abstraction;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

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
				if (entityType== typeof(Category))
				{
					result = new Category
					{
						CategoryName = "Category1",
						Id = 1,
						CategoryDescription = "Category1 descrition",
						CategoryPrice = 1222.3m,
						CategoryRecordStatus = "A",
						CategoryAdditionalInfoTitle = "Additional Info Title",
						CategoryAdditionalInfoUrl = "Additional Info Url",
						CategoryImgAlt = "Image alt",
						CategoryImgDescription = "Image Description",
						IsActive = true,
						CategoryImgUrl = "http://mialco.com/images/thumbs/0000091_e-commerce-installation-on-aws-basic-installation_415.jpeg",
						CategoryUrl = "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
						CategoryStartDate = DateTime.Now,
						CategoryEndDate = DateTime.Now.AddDays(1000),
						CategoryAdvertiser = "Advertizer name:",
						CategoryAdvertiserLinkID = "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
						CategoryLinkCode = "sae3d5412"
					} as T;
				}

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

			if (typeof(T) == typeof(Category))
			{
				result = CategoryGenerator.GenerateNestedCategories() as List<T>;
			}
			if (typeof(T) == typeof(CategoryGroup))
			{
				result = new List<CategoryGroup> {
					new CategoryGroup {
						GroupName="CategoryGroup1",
						// Id=1, Commnent all ids because they are auto generated
						GroupDescription ="CategoryGroup1 descrition",
						CreatedAt= DateTime.Now,
						LastUpdated = DateTime.Now
					},
					new CategoryGroup {
						GroupName="CategoryGroup2",
						//Id=2,
						GroupDescription ="CategoryGroup2 descrition",
						CreatedAt= DateTime.Now,
						LastUpdated = DateTime.Now
					},
					new CategoryGroup {
						GroupName="CategoryGroup3",
						//Id=3,
						GroupDescription ="CategoryGroup3 descrition",
						CreatedAt= DateTime.Now,
						LastUpdated = DateTime.Now
					},
					new CategoryGroup {
						GroupName="CategoryGroup4",
						//Id=4,
						GroupDescription ="CategoryGroup4 descrition",
						CreatedAt= DateTime.Now,
						LastUpdated = DateTime.Now
					}
				} as List<T>;

			}

			if (typeof(T) == typeof(Category_CategoryGroup))
			{
				result = new List<Category_CategoryGroup> {
						new Category_CategoryGroup {
							CategoryId=1,
							CategoryGroupId=1,
							IsActive=true,
							CreatedAt= DateTime.Now,
							LastUpdated = DateTime.Now
						},
						new Category_CategoryGroup {
							CategoryId=2,
							CategoryGroupId=2,
							IsActive=true,
							CreatedAt= DateTime.Now,
							LastUpdated = DateTime.Now
						},
						new Category_CategoryGroup {
							CategoryId=3,
							CategoryGroupId=3,
							IsActive=true,
							CreatedAt= DateTime.Now,
							LastUpdated = DateTime.Now
						},
						new Category_CategoryGroup {
							CategoryId=4,
							CategoryGroupId=4,
							IsActive=true,
							CreatedAt= DateTime.Now,
							LastUpdated = DateTime.Now
						},

						new Category_CategoryGroup {
							CategoryId=5,
							CategoryGroupId=1,
							IsActive=true,
							CreatedAt= DateTime.Now,
							LastUpdated = DateTime.Now
						},
						new Category_CategoryGroup {
							CategoryId=6,
							CategoryGroupId=2,
							IsActive=true,
							CreatedAt= DateTime.Now,
							LastUpdated = DateTime.Now
						},
						new Category_CategoryGroup {
							CategoryId=7,
							CategoryGroupId=3,
							IsActive=true,
							CreatedAt= DateTime.Now,
							LastUpdated = DateTime.Now
						},
						new Category_CategoryGroup {
							CategoryId=8,
							CategoryGroupId=4,
							IsActive=true,
							CreatedAt= DateTime.Now,
							LastUpdated = DateTime.Now
						},
						new Category_CategoryGroup {
							CategoryId=9,
							CategoryGroupId=1,
							IsActive=true,
							CreatedAt= DateTime.Now,
							LastUpdated = DateTime.Now
						},
						new Category_CategoryGroup {
							CategoryId=10,
							CategoryGroupId=2,
							IsActive=true,
							CreatedAt= DateTime.Now,
							LastUpdated = DateTime.Now
						},
						new Category_CategoryGroup {
							CategoryId=11,
							CategoryGroupId=3,
							IsActive=true,
							CreatedAt= DateTime.Now,
							LastUpdated = DateTime.Now
						},
						new Category_CategoryGroup {
							CategoryId=12,
							CategoryGroupId=4,
							IsActive=true,
							CreatedAt= DateTime.Now,
							LastUpdated = DateTime.Now
						}

					} as List<T>;
			}


			return result;
		}

		public IEnumerable<T> GetAll()
		{
			throw new NotImplementedException();
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
			if (typeof(T) == typeof(Category))
			{
				result = CategoryGenerator.GenerateNestedCategories() as List<T>;
			}


			return result;
		}

		public class CategoryGenerator
		{
			public static List<Category> GenerateNestedCategories()
			{
				var categories = new List<Category>();

				for (int i = 1; i <= 20; i++)
				{
					var category = new Category
					{
						CategoryName = $"Category{i}",
						//Id = i, We should not set the id here because it is auto generated
						CategoryDescription = $"Category{i} description",
						CategoryPrice = 1222.3m,
						CategoryRecordStatus = "A",
						CategoryAdditionalInfoTitle = "Additional Info Title",
						CategoryAdditionalInfoUrl = "Additional Info Url",
						CategoryImgAlt = "Image alt",
						CategoryImgDescription = "Image Description",
						IsActive = true,
						CategoryImgUrl = "http://mialco.com/images/thumbs/0000091_e-commerce-installation-on-aws-basic-installation_415.jpeg",
						CategoryUrl = "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
						CategoryStartDate = DateTime.Now,
						CategoryEndDate = DateTime.Now.AddDays(1000),
						CategoryAdvertiser = "Advertiser name:",
						CategoryAdvertiserLinkID = "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
						CategoryLinkCode = "sae3d5412"
					};

					GenerateNestedCategoriesRecursive(category, 1, 4);

					categories.Add(category);
				}

				return categories;
			}

			private static void GenerateNestedCategoriesRecursive(Category parentCategory, int currentLevel, int maxLevel)
			{
				if (currentLevel >= maxLevel)
					return;

				for (int i = 1; i <= 20; i++)
				{
					var category = new Category
					{
						CategoryName = $"Category{i}",
						Id = i,
						ParentCategoryId = parentCategory.Id,
						CategoryDescription = $"Category{i} description",
						CategoryPrice = 1222.3m,
						CategoryRecordStatus = "A",
						CategoryAdditionalInfoTitle = "Additional Info Title",
						CategoryAdditionalInfoUrl = "Additional Info Url",
						CategoryImgAlt = "Image alt",
						CategoryImgDescription = "Image Description",
						IsActive = true,
						CategoryImgUrl = "http://mialco.com/images/thumbs/0000091_e-commerce-installation-on-aws-basic-installation_415.jpeg",
						CategoryUrl = "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
						CategoryStartDate = DateTime.Now,
						CategoryEndDate = DateTime.Now.AddDays(1000),
						CategoryAdvertiser = "Advertiser name:",
						CategoryAdvertiserLinkID = "https://mialco.com/e-commerce-installation-on-aws-basic-installation",
						CategoryLinkCode = "sae3d5412"
					};

					//parentCategory. SubCategories.Add(category); //Explain this line?/

					GenerateNestedCategoriesRecursive(category, currentLevel + 1, maxLevel);
				}
			}
		}


	}
}
