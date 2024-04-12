using KamiSama.Extensions.Paging;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KamiSama.Repositories.EntityFramework;

/// <summary>
/// IQueryable Extensions
/// </summary>
public static class IOrderedQueryableExtensions
{
	/// <summary>
	/// Makes the query paged, used for user interface and apis paging
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="query"></param>
	/// <param name="searchModel"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public static async Task<PagedResult<T>> MakePagedAsync<T>(this IOrderedQueryable<T> query, SearchModel searchModel, CancellationToken cancellationToken)
	{
		var count = query.Count();
		if (searchModel.PageSize == 0)
		{
			return new PagedResult<T>(count, await query.ToListAsync(cancellationToken));
		}
		else
		{
			int pageIndex = int.Max(0, searchModel.Page - 1);
			var items = await query.Skip(pageIndex * searchModel.PageSize)
				.Take(searchModel.PageSize)
				.ToListAsync(cancellationToken);

			return new PagedResult<T>(count, items);
		}
	}
}
