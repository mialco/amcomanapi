using mialco.amcoman.dal.Abstraction;
using mialco.amcoman.dal.Entity;
using mialco.amcoman.repository.Abstraction;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AmcomanApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private IAflRepository<AflProduct> _productRepository;

		public ProductsController(IAflRepository<AflProduct> productRepository) 
		{ 
			_productRepository = productRepository;
		
		}
		// GET: api/<ProductsController>
		[HttpGet]
		public  IEnumerable<AflProduct> Get(int pageIndex, int pageSize)
		{
			return _productRepository.GetAll(pageIndex,pageSize);
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
