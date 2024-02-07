public interface IAmcomanApiUtils
{
	string GetApiUrl(string apiName);
	List<CategoryTreeDto> BuildCategoryTree(List<CategoryAndGroupDto> categoryAndGroupList);
}
