using mialco.amcoman.dal;
using mialco.amcoman.dal.Abstraction;
using mialco.amcoman.dal.Entity;
using mialco.amcoman.repository;
using mialco.amcoman.repository.abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AmcomanApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private IAflRepository<AflProduct> _productRepository; //= new AflEFRepository<AflProduct>(AmcomanContext);
		//private DbContext _context;

		public ProductsController(IAflRepository<AflProduct> productRepository) 
		{ 
			_productRepository = productRepository;
		
		}
		// GET: api/<ProductsController>
		[HttpGet]
		public IEnumerable<AflProduct> Get(int pageIndex, int pageSize)
		{
			return _productRepository.GetAll(pageIndex, pageSize);
		}
		/// <summary>
		/// localhost:4200/products/list?categories=8
		/// </summary>
		/// <param name="categories - comma delimited list of categories"></param>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <example>localhost:4200/products/list?categories=8,12,22&pageindex=1&pagesize=2</example>
		/// <returns></returns>&pageindex=1&pagesize=2
		// GET: api/<ProductsController>
		[HttpGet("list")]
		public IEnumerable<AflProduct> Get(string categories,int pageIndex, int pageSize)		
		{
			return _productRepository.GetAll();
		}
		// GET api/<ProductsController>/5
		[HttpGet("{id}")]
		public AflProduct Get(int id)
		{
			return _productRepository.Get(id);
		}

		//// POST api/<ProductsController>
		//[HttpPost]
		//public void Post([FromBody] string value)
		//{
		//}

		//// PUT api/<ProductsController>/5
		//[HttpPut("{id}")]
		//public void Put(int id, [FromBody] string value)
		//{
		//}

		//// DELETE api/<ProductsController>/5
		//[HttpDelete("{id}")]
		//public void Delete(int id)
		//{
		//}
	}
}
