using mialco.amcoman.repository;
using mialco.amcoman.repository.abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace mialco.amcoman.integration.testing
{
	public class RepositoryTesting: IntegrationTestingBase 		
	{
		ICategoriesAndGroupsRepository ? _categoryAneGroupsRepository;
		IGroupsRepository ? _groupsRepository;
		[SetUp]
		public void Setup()
		{
			_categoryAneGroupsRepository = ServiceProvider.GetService<ICategoriesAndGroupsRepository>();
			_groupsRepository = ServiceProvider.GetService<IGroupsRepository>();
		}

		[Test]
		public void TestCategories()
		{
			// Arrange
			//Act
			var categories = _categoryAneGroupsRepository.GetAll();
			//Assert
			Assert.IsNotNull(categories);
			Assert.AreNotEqual(0, categories.Count());
			
		}

		[Test]
		public void TestCategory()
		{
			// Arrange
			//Act
			var category = _categoryAneGroupsRepository.Get(1);
			//Assert
			Assert.IsNotNull(category);
			Assert.AreEqual(1, category.Id);

		}

		[Test]
		public void TestCategoriesPaged()
		{
			// Arrange
			//Act
			var categoriesp1 = _categoryAneGroupsRepository.GetAll(1,2);
			var categoriesp2 = _categoryAneGroupsRepository.GetAll(2, 2);
			//Assert
			Assert.IsNotNull(categoriesp1);
			Assert.IsNotNull(categoriesp2);
			Assert.AreEqual(2, categoriesp1.Count());
			Assert.AreEqual(2, categoriesp2.Count());
			
			var category1 = categoriesp1.FirstOrDefault();
			Assert.IsTrue(category1.Category_CategoryGroups == null);

		}

		[Test]
		
		public void TestCategoriesWithGroup()
		{
			// Arrange
			//Act
			var categories = _categoryAneGroupsRepository.GetCategoriesWithGroupsBasic(new int[] { 1,2 } );
			//Assert
			Assert.IsNotNull(categories);
			Assert.AreNotEqual(0, categories.Count());

			var category1 = categories.FirstOrDefault();
			Assert.AreNotEqual(0, category1.CategoryGroupId);

			categories = _categoryAneGroupsRepository.GetCategoriesWithGroupsBasic(new int[] { 333});
			Assert.IsNotNull(categories);
			Assert.AreEqual(0, categories.Count());

		}

		[Test]
		public void TestCategoryGroups()
		{
			// Arrange
			//Act
			var groups = _groupsRepository.GetAll();
			Assert.IsNotNull(groups);
			Assert.AreNotEqual(0, groups.Count());

			groups = _groupsRepository.GetAll(1,2);
			Assert.IsNotNull(groups);
			Assert.AreEqual(2, groups.Count());

			groups = _groupsRepository.GetActive(true);
			Assert.IsNotNull(groups);
			Assert.AreNotEqual(0, groups.Count());

			groups = _groupsRepository.GetActive(false);
			Assert.IsNotNull(groups);
			Assert.AreEqual(1, groups.Count());

			groups = _groupsRepository.GetActive(true, 1, 2);
			Assert.IsNotNull(groups);
			Assert.AreEqual(2, groups.Count());

			groups = _groupsRepository.GetActive(false, 1, 2);
			Assert.IsNotNull(groups);
			Assert.AreEqual(1, groups.Count());

			var group = _groupsRepository.Get(1);
			Assert.IsNotNull(group);
			Assert.AreEqual(1, group.Id);


		}

	}
}