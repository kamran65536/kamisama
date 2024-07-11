namespace Project.Repositories.SearchModels;

public record SampleEntitySearchModel(
	string? Name,
	string? OrderBy,
	int Page,
	int PageSize) : SearchModel(Page, PageSize)
{
	public static new SampleEntitySearchModel All { get; } = new(null, null, 0, 0);
}
