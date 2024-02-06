using mialco.amcoman.dal.Entity;
using mialco.amcoman.repository;
using mialco.amcoman.repository.abstraction;
using mialco.amcoman.shared.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AmcomanApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoriesAndGroupsRepository _repoCategoryAndGroup;
		private readonly IAflRepository<CategoryGroup> _repoGroup;

		public CategoriesController(ICategoriesAndGroupsRepository  repo, IAflRepository<CategoryGroup> repoGroup)
		{
			_repoCategoryAndGroup = repo;
			this._repoGroup = repoGroup;
		}
		// GET: api/<CategoriesController>
		[HttpGet]
		public ActionResult<IEnumerable<Category>> Get()
		{
			var result = _repoCategoryAndGroup.GetAll().ToList();
			return Ok(result);
		}

		// GET: api/<CategoriesController>
		[HttpGet]
		[Route("bygroup/:id")]
		public ActionResult<IEnumerable<Category>> GetByGroup(int id)
		{
			var result = _repoCategoryAndGroup.GetAll().Where(x=>x.IsActive).ToList();
			return Ok(result);
		}


		// GET: api/<CategoriesController>
		[HttpGet]
		[Route("Groups")]
		public ActionResult<IEnumerable<CategoryGroup>> GetGroups()
		{
			var result = _repoGroup.GetAll().ToList();
			return Ok(result);
		}

		// GET: api/<CategoriesController>
		[HttpGet]
		[Route("Groups/active")]
		public ActionResult<IEnumerable<CategoryGroup>> GetGroups(bool active)
		{
			//TODO: Implement this and add active field to the CategoryGroup entity
			var result = _repoGroup.GetAll().ToList();
			return Ok(result);
		}

		// GET: api/<CategoriesController>
		[HttpGet("tree")]
		public ActionResult<IEnumerable<CategoryTreeDto>> GetCategoryTree(List <int> ? groupIdsfilter)
		{
			var result = new List<CategoryTreeDto>();
			List<Category> categories; 
			if(groupIdsfilter != null && groupIdsfilter.Count!=0)
			{
				var cat =_repoCategoryAndGroup.GetCategoriesWithGroupsBasic(groupIdsfilter)
					.Select(x=> new CategoryAndGroupDto {
						CategoryGroupId=x.CategoryGroupId,
						CateogoryId = x.CateogoryId,
						Name = x.Name,
						Description = x.Description,
						GroupName = x.GroupName, 
					}).ToList();
				
			}
			else
			{
				categories = _repoCategoryAndGroup.GetAll().ToList();
			}	

			return Ok(result);
		}
		//I want to build a tree of categories and groups based on categotyandgroupdto into CategoryTreeDto








		// GET api/<CategoriesController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<CategoriesController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<CategoriesController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<CategoriesController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}

		private Dictionary<int, CategoryTreeDto> _tempTree = new Dictionary<int, CategoryTreeDto>();
		public List<CategoryTreeDto> BuildCategoryTree(List<CategoryAndGroupDto> categoryAndGroupList,int indexStart,  List<CategoryTreeDto> categoryTree)
		{
			// initialize the tree and sort the list if it is the first level
			if (indexStart == 0)
			{
				categoryTree = new List<CategoryTreeDto>();
				categoryAndGroupList.Sort((x, y) => $"{x.ParentId:D4}-{x.Name}".CompareTo($"{y.ParentId:D4}-{y.Name}"));
			}

			for (var i = 0; i< categoryAndGroupList.Count; i++)
			{
				var category = categoryAndGroupList[i];
				// Check if the category group already exists in the category tree
				var existingCategory = categoryTree.FirstOrDefault(c => c.ParentId== category.ParentId);

				if (categoryTree.Count==0 || existingCategory != null)
				{
					// Add the category to the current Level of the category tree
					var newNode = new CategoryTreeDto
					{
						Id = category.CateogoryId,
						Name = category.Name,
						Description = category.Description,
						ParentId = category.ParentId,
						Children = new List<CategoryTreeDto>()
					};
					categoryTree.Add(newNode);
				}
			}
			return categoryTree;
		}
	}
}
