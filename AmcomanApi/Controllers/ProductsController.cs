using AmcomanApi.ViewModel;
using mialco.amcoman.dal;
using mialco.amcoman.dal.Abstraction;
using mialco.amcoman.dal.Entity;
using mialco.amcoman.repository;
using mialco.amcoman.repository.abstraction;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AmcomanApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		//private IAflRepository<AflProduct> _productRepository; //= new AflEFRepository<AflProduct>(AmcomanContext);
		private IProductRepository _productRepository;
		//private DbContext _context;
		
		public ProductsController(IProductRepository productRepository) 
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
		public ProductsVm Get(string categories,int currentPage, int pageSize)		
		{
			if (currentPage<=0 )
				pageSize = 1;

			if (pageSize <= 0)
				return new ProductsVm(currentPage, pageSize);

			if (string.IsNullOrEmpty(categories))
			{
				return new ProductsVm (currentPage, pageSize);
			}
			var categoryList = categories.Split(',').Select(x=> {
			int result;
				int.TryParse(x, out result);
				return result;
			});
			if (categoryList == null || categoryList.Count() == 0)
			{
				return new ProductsVm(currentPage, pageSize);
			} 

			var productsCount = _productRepository.Count(categoryList);
			if (productsCount == 0)
			{
				return new ProductsVm (currentPage,pageSize);
			}
			var products =  _productRepository.GetProductsByCategoryList(categoryList, currentPage, pageSize);
			
			var result = new ProductsVm(currentPage, pageSize)
			{
			};

			result.Pagination.TotalPages = (int)System.Math.Ceiling((decimal)productsCount / pageSize);
			result.Pagination.TotalItems = productsCount;
			if (currentPage > result.Pagination.TotalPages || currentPage < 1)
			{
				return result;
			}
			foreach (var product in products)
			{
				var productVm = new ProductVm
				{
					Id = product.Id,
					ProductName = product.ProductName,
					Description = product.Description,
					ImgUrl = product.ImgUrl,
					Price = product.Price,
					ImgAlt = product.ImgAlt,
					ImgDescription = product.ImgDescription,
					NavigateUrl = product.NavigateUrl
				};
				result.AddProduct(productVm);
			}
			if (result.Pagination == null)
			{
				result.Pagination = new PaginationVm();
			}
				
			return result;
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
		//[HttpPut("{id}")]`	 
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
