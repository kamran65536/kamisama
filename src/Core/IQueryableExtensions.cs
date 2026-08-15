using KamiSama.Extensions.Paging;

namespace KamiSama.Extensions;

/// <summary>
/// Provides extensions for materializing <see cref="IQueryable{T}"/> sequences as paged results.
/// Use them after applying filtering and ordering to a query.
/// </summary>
public static class IQueryableExtensions
{
	/// <summary>
	/// Counts and materializes the requested page of the query, or all items when the page size is zero.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="query"></param>
	/// <param name="searchModel"></param>
	/// <returns></returns>
	public static PagedResult<T> MakePaged<T>(this IQueryable<T> query, SearchModel searchModel)
	{

		var count = query.Count();
		if (searchModel.PageSize == 0)
		{
			return new PagedResult<T>(count, [.. query]);
		}
		else
		{
			int pageIndex = int.Max(0, searchModel.Page - 1);
			var items = query.Skip(pageIndex * searchModel.PageSize)
				.Take(searchModel.PageSize)
				.ToList();

			return new PagedResult<T>(count, items);
		}
	}
}
