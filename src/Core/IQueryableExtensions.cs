using KamiSama.Extensions.Paging;

namespace KamiSama.Extensions;

/// <summary>
/// IQueryable Extensions
/// </summary>
public static class IQueryableExtensions
{
	/// <summary>
	/// Makes the query paged, used for user interface and apis paging
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
