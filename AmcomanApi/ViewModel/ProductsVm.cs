namespace AmcomanApi.ViewModel
{
	public class ProductsVm
	{
		private List<ProductVm> ? _products;
		public ProductsVm(int currentPage, int pageSize)
		{
			_products = new List<ProductVm> { };
			Pagination = new PaginationVm {CurrentPage=currentPage};
			_pageSize = pageSize;
		}
		public IEnumerable<ProductVm>  Products { get { return _products; }  }
		public PaginationVm ? Pagination { get; set; }

		private int _pageSize;

		public void AddProduct(ProductVm product)
		{
			_products.Add(product);
		}
	}
}
