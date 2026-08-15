using System.Collections;
using System.Data;

namespace KamiSama.Extensions.Paging;

/// <summary>
/// Represents one materialized page of items together with the total number of matching items.
/// Use it to return page data without losing the count needed by callers to render pagination.
/// </summary>
/// <typeparam name="T">The item type.</typeparam>
/// <param name="TotalItemsCount">The total number of matching items across all pages.</param>
/// <param name="Items">The items materialized for this page.</param>
public record PagedResult<T>(int TotalItemsCount, List<T> Items)
{
	/// <summary>
	/// Gets an empty paged result with a total count of zero.
	/// </summary>
	public static PagedResult<T> Empty { get; } = new PagedResult<T>(0, []);
	/// <summary>
	/// Projects each item to another type while preserving the total item count.
	/// </summary>
	/// <typeparam name="TOtherType"></typeparam>
	/// <param name="convertFunc"></param>
	/// <returns></returns>
	public virtual PagedResult<TOtherType> ConvertTo<TOtherType>(Func<T, TOtherType> convertFunc)
		=> new(TotalItemsCount, [.. Items.Select(convertFunc)]);
	/// <summary>
	/// Asynchronously projects each item to another type while preserving the total item count.
	/// </summary>
	public virtual async Task<PagedResult<TOtherType>> ConvertToAsync<TOtherType>(Func<T, CancellationToken, Task<TOtherType>> convertFunc, CancellationToken cancellationToken)
	{
		var items = await Task.WhenAll(Items.Select(x => convertFunc(x, cancellationToken)));
		return new PagedResult<TOtherType>(TotalItemsCount, [.. items]);
	}
}
