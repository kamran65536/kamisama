using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Extensions.Paging;

/// <summary>
/// Represents paging and optional ordering criteria for a query.
/// A page size of zero requests all matching items.
/// </summary>
/// <param name="Page">The one-based page number.</param>
/// <param name="PageSize">The maximum number of items in a page; zero requests all items.</param>
/// <param name="OrderBy">The optional ordering expression or field name.</param>
[ExcludeFromCodeCoverage]
public record SearchModel(int Page, int PageSize, string? OrderBy = null)
{
	/// <summary>
	/// Gets search criteria that request all matching items without paging.
	/// </summary>
	public static SearchModel All { get; } = new SearchModel(0, 0);

	/// <summary>
	/// Creates search criteria for the specified one-based page number and page size.
	/// </summary>
	/// <param name="pageNo"></param>
	/// <param name="pageSize"></param>
	/// <returns></returns>
	public static SearchModel FromPage(int pageNo, int pageSize) => new(pageNo, pageSize);
}
