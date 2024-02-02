using mialco.amcoman.dal.Entity;
using mialco.amcoman.repository.Abstraction;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AmcomanApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly IAflRepository<Category> _repo;
		private readonly IAflRepository<CategoryGroup> _repoGroup;

		public CategoriesController(IAflRepository<Category> repo, IAflRepository<CategoryGroup> repoGroup)
		{
			_repo = repo;
			this._repoGroup = repoGroup;
		}
		// GET: api/<CategoriesController>
		[HttpGet]
		public ActionResult<IEnumerable<Category>> Get()
		{
			var result = _repo.GetAll().ToList();
			return Ok(result);
		}

		// GET: api/<CategoriesController>
		[HttpGet]
		[Route("bygroup/:id")]
		public ActionResult<IEnumerable<Category>> GetByGroup(int id)
		{
			var result = _repo.GetAll().Where(x=>x.IsActive).ToList();
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
