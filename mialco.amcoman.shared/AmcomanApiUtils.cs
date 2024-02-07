using mialco.amcoman.shared.Abstraction;
using mialco.amcoman.shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mialco.amcoman.shared
{
	public class AmcomanApiUtils : IAmcomanApiUtils
	{
		
		public string GetApiUrl(string apiName)
		{
			return "https://localhost:44300/api/" + apiName;
		}

		public IEnumerable<CategoryTreeDto> BuildCategoryTree(List<CategoryAndGroupDto> categoryAndGroupList)
		{

			Dictionary<int, CategoryTreeDto> tempTree = new Dictionary<int, CategoryTreeDto>();
			// initialize the tree and sort the list if it is the first level
			var categoryTree = new List<CategoryTreeDto>();
			categoryAndGroupList.ToList().Sort((x, y) => $"{x.ParentId:D4}-{x.Name}".CompareTo($"{y.ParentId:D4}-{y.Name}"));

			for (var i = 0; i < categoryAndGroupList.Count; i++)
			{
				var category = categoryAndGroupList[i];
				// Check if the category group already exists in the category tree
				var existingCategory = categoryTree.FirstOrDefault(c => c.ParentId == category.ParentId);

				if (categoryTree.Count == 0 || existingCategory != null)
				{
					// Add the category to the current Level of the category tree
					var newNode = new CategoryTreeDto
					{
						Id = category.CategoryId,
						Name = category.Name,
						Description = category.Description,
						ParentId = category.ParentId,
						Children = new List<CategoryTreeDto>()
					};
					if (tempTree.ContainsKey(newNode.ParentId))
					{
						tempTree[newNode.ParentId].Children.Add(newNode);
					}
					else
					{
						categoryTree.Add(newNode);
						tempTree.Add(newNode.Id, newNode);
					}
				}
			}
			return categoryTree;
		}

	}
}
