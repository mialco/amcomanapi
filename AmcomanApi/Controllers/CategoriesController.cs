using mialco.amcoman.dal.Entity;
using mialco.amcoman.repository;
using mialco.amcoman.repository.abstraction;
using mialco.amcoman.shared.Abstraction;
using mialco.amcoman.shared.Dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AmcomanApi.Controllers
{
	[Route("api/[controller]")]
	[Authorize]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoriesAndGroupsRepository _repoCategoryAndGroup;
		private readonly IGroupsRepository _repoGroup;
		private readonly IAmcomanApiUtils _apiUtils;

		public CategoriesController(ICategoriesAndGroupsRepository repo, IGroupsRepository repoGroup,
			IAmcomanApiUtils apiUtils)
		{
			_repoCategoryAndGroup = repo;
			this._repoGroup = repoGroup;
			this._apiUtils = apiUtils;
		}
		// GET: api/<CategoriesController>
		[HttpGet]
		[Authorize]
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
			var result = _repoCategoryAndGroup.GetAll().Where(x => x.IsActive).ToList();
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
			var result = _repoGroup.GetAll().ToList();
			return Ok(result);
		}

		// GET: api/<CategoriesController>
		[HttpGet("tree")]

		public ActionResult<IEnumerable<CategoryTreeDto>> GetCategoryTree([FromQuery] string? groupIdsfilter)
		{

			groupIdsfilter ??= string.Empty;
			IEnumerable<CategoryTreeDto> result; ;
			List<Category> categories;
			IEnumerable<CategoryAndGroupDto> cat;
			var groupsFilterList = new List<int>();
			var parts = groupIdsfilter.Split(',');
			var i = 0;
			foreach (var part in parts)
			{
				if (int.TryParse(part, out i))
				{
					groupsFilterList.Add(i);
				}
			}

			if (groupsFilterList.Count != 0)
			{
				cat = _repoCategoryAndGroup.GetCategoriesWithGroupsBasic(groupsFilterList)
					.Select(x => new CategoryAndGroupDto
					{
						CategoryGroupId = x.CategoryGroupId,
						CategoryId = x.CategoryId,
						Name = x.Name,
						Description = x.Description,
						GroupName = x.GroupName,
						ParentId = x.ParentId
					});

			}
			else
			{
				cat = _repoCategoryAndGroup.GetCategoriesWithGroupsBasic(true)
					.Select(x => new CategoryAndGroupDto
					{
						CategoryGroupId = x.CategoryGroupId,
						CategoryId = x.CategoryId,
						Name = x.Name,
						Description = x.Description,
						GroupName = x.GroupName,
						ParentId = x.ParentId
					});
			}

			result = _apiUtils.BuildCategoryTree(cat.ToList()); ;
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
