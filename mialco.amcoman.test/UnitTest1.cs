using mialco.amcoman.shared.Abstraction;
using mialco.amcoman.shared.Dto;
using Microsoft.Extensions.DependencyInjection;

namespace mialco.amcoman.test
{
	[TestFixture]
	public class Tests
	{

		private  IAmcomanApiUtils _apiUtils;

		[SetUp]
		public void Setup()
		{
			//var setup = new Setup();

		}

		[Test]
		public void TestBuildCategoryTree_ShouldBuildTree()
		{
			//_apiUtils = mialco.amcoman.test.Setup.ServiceProvider.GetService(typeof(IAmcomanApiUtils));

			_apiUtils = new AmcomanApiUtils();
			var categoryAndGroupDtos = GenerateCategoryAndGroupDtos().ToList();
			var categoryTree = _apiUtils.BuildCategoryTree(categoryAndGroupDtos);
			Assert.NotNull(categoryTree);
			Assert.AreEqual(3, categoryTree.Count());
			Assert.AreEqual(1, categoryTree.First(x => x.Id == 1).Children.Count);	
			//Assert.Pass();
		}

		private IEnumerable<CategoryAndGroupDto> GenerateCategoryAndGroupDtos()
		{
			return new List<CategoryAndGroupDto>
			{
				new CategoryAndGroupDto
				{
					CategoryId = 1,
					ParentId = 0,
					Name = "Category 1",
					Description = "Category 1 Description",
					CategoryGroupId = 1,
					GroupName = "Group 1"
				},
				new CategoryAndGroupDto
				{
					CategoryId = 2,
					ParentId = 0,
					Name = "Category 2",
					Description = "Category 2 Description",
					CategoryGroupId = 1,
					GroupName = "Group 1"
				},
				new CategoryAndGroupDto
				{
					CategoryId = 3,
					ParentId = 0,
					Name = "Category 3",
					Description = "Category 3 Description",
					CategoryGroupId = 1,
					GroupName = "Group 1"
				},
				new CategoryAndGroupDto
				{
					CategoryId = 4,
					ParentId = 1,
					Name = "Category 4",
					Description = "Category 4 Description",
					CategoryGroupId = 1,
					GroupName = "Group 1"
				},
				new CategoryAndGroupDto
				{
					CategoryId = 5,
					ParentId = 2,
					Name = "Category 5",
					Description = "Category 5 Description",
					CategoryGroupId = 1,
					GroupName = "Group 1"
				},
				new CategoryAndGroupDto
				{
					CategoryId = 6,
					ParentId = 2,
					Name = "Category 6",
					Description = "Category 6 Description",
					CategoryGroupId = 1,
					GroupName = "Group 1"
				},
				new CategoryAndGroupDto
				{
					CategoryId = 7,
					ParentId = 3,
					Name = "Category 7",
					Description = "Category 7 Description",
					CategoryGroupId = 1,
					GroupName = "Group 1"
				},
				new CategoryAndGroupDto
				{
					CategoryId = 8,
					ParentId = 5,
					Name = "Category 8",
					Description = "Category 8 Description",
					CategoryGroupId = 1,
					GroupName = "Group 1"
				},
				new CategoryAndGroupDto
				{
					CategoryId = 9,
					ParentId = 5,
					Name = "Category 9",
					Description = "Category 9 Description",
					CategoryGroupId = 1,
					GroupName = "Group 1"
				},
				new CategoryAndGroupDto
				{
					CategoryId = 10,
					ParentId = 6,
					Name = "Category 10",
					Description = "Category 10 Description",
					CategoryGroupId = 1,
					GroupName = "Group 1"
				},
				new CategoryAndGroupDto
				{
					CategoryId = 11,
					ParentId = 6,
					Name = "Category 11",
					Description = "Category 11 Description",
					CategoryGroupId = 1,
					GroupName = "Group 1"
				},
				new CategoryAndGroupDto
				{
					CategoryId = 12,
					ParentId = 7,
					Name = "Category 12",
					Description = "Category 12 Description",
					CategoryGroupId = 1,
					GroupName = "Group 1"
				},
				new CategoryAndGroupDto
				{
					CategoryId = 13,
					ParentId = 11,
					Name = "Category 13",
					Description = "Category 13 Description",
					CategoryGroupId = 1,
					GroupName = "Group 1"
				},
				new CategoryAndGroupDto 
				{
					CategoryId = 14,
					ParentId = 11,
					Name = "Category 14",
					Description = "Category 14 Description",
					CategoryGroupId = 1,
					GroupName = "Group 1"
				}
			};
		}
	}
}