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
			if(groupIdsfilter != null)
			{
				//categories = _repo.GetAll().Select(x=>
				//new { Id = x.Id, Name = x.CategoryName,Description=x.CategoryDescription ,IsActive = x.IsActive }.
				//}) 
				//	Where(x=>groupIdsfilter.Contains(x.CategoryGroupId)).ToList();
			}
			else
			{
				categories = _repoCategoryAndGroup.GetAll().ToList();
			}	

			return Ok(result);
		}

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
	}
}
