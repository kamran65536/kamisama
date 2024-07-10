using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Extensions.Paging;

/// <summary>
/// Basic Search model for 
/// </summary>
/// <param name="Page">page number starts from 1</param>
/// <param name="PageSize"></param>
/// <param name="OrderBy"></param>
[ExcludeFromCodeCoverage]
public record SearchModel(int Page, int PageSize, string? OrderBy = null)
{
	/// <summary>
	/// Represent Search model for All items
	/// </summary>
	public static SearchModel All { get; } = new SearchModel(0, 0);

	/// <summary>
	/// creates a search model from page
	/// </summary>
	/// <param name="pageNo"></param>
	/// <param name="pageSize"></param>
	/// <returns></returns>
	public static SearchModel FromPage(int pageNo, int pageSize) => new(pageNo, pageSize);
}
