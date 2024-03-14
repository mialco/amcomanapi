namespace AmcomanApi.ViewModel
{
	public class PaginationVm
	{
		public int CurrentPage { get; set; }
		public int TotalItems { get; set; }
		public int TotalPages { get; set; }
		public bool HasPreviousPage { get => CurrentPage > 1; }
		public bool HasNextPage { get => CurrentPage < TotalPages; }
	}
}
