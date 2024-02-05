﻿namespace mialco.amcoman.shared.Dto
{
	public class CategoryDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int ParentId { get; set; }
		public string ImageUrl { get; set; }
		public string IconUrl { get; set; }
		public int SortOrder { get; set; }
		public bool IsPublished { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime LastUpdated { get; set; }
	}
}
