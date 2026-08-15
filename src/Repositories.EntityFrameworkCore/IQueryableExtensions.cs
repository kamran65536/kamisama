using KamiSama.Extensions.Paging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KamiSama.Repositories.EntityFrameworkCore;

/// <summary>
/// Provides Entity Framework Core paging for database queries.
/// </summary>
public static class IQueryableExtensions
{
	/// <summary>
	/// Counts the complete query and materializes the requested page.
	/// </summary>
	/// <typeparam name="T">The element type returned by the query.</typeparam>
	/// <param name="query">The EF Core query to page. Apply a deterministic ordering before calling this method.</param>
	/// <param name="searchModel">The one-based page number and page size; a page size of zero returns all items.</param>
	/// <param name="cancellationToken">A token that can cancel list materialization but not the synchronous count.</param>
	/// <returns>A result containing the unpaged count and the requested items.</returns>
	/// <remarks>
	/// The method does not add ordering. The count executes synchronously and does not observe
	/// <paramref name="cancellationToken"/>. Count and materialization are separate queries, so concurrent changes can
	/// make the count and items inconsistent.
	/// </remarks>
	public static async Task<PagedResult<T>> MakePagedAsync<T>(this IQueryable<T> query, SearchModel searchModel, CancellationToken cancellationToken)
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
