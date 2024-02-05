namespace mialco.amcoman.shared.Dto
{
	public class CategoryTreeDto
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int ParentId { get; set; }
		public List<CategoryTreeDto> Children { get; set; }
	}
}
