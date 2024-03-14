using Microsoft.EntityFrameworkCore;

namespace AmcomanApi.ViewModel
{
	public class ProductVm
	{
		public long Id { get; set; }
		public string ProductName { get; set; } = string.Empty;
		public string? Description { get; set; } = string.Empty;
		public string NavigateUrl { get; set; } = string.Empty;
		public string? ImgUrl { get; set; }
		public string? ImgAlt { get; set; }
		public string? ImgDescription { get; set; }
		[Precision(18, 4)]
		public decimal ? Price { get; set; }

	}
}
