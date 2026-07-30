using System.Collections;
using System.Data;

namespace KamiSama.Extensions.Paging;

/// <summary>
/// Paged Result
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="TotalItemsCount"></param>
/// <param name="Items"></param>
public record PagedResult<T>(int TotalItemsCount, List<T> Items) : IEnumerable<T>
{
	/// <summary>
	/// Empty Result
	/// </summary>
	public static PagedResult<T> Empty { get; } = new PagedResult<T>(0, []);
	/// <summary>
	/// Converts a paged result to another one
	/// </summary>
	/// <typeparam name="TOtherType"></typeparam>
	/// <param name="convertFunc"></param>
	/// <returns></returns>
	public virtual PagedResult<TOtherType> ConvertTo<TOtherType>(Func<T, TOtherType> convertFunc)
		=> new(TotalItemsCount, [.. Items.Select(convertFunc)]);
	/// <summary>
	/// Converts a paged result to another one asynchronously
	/// </summary>
	public virtual async Task<PagedResult<TOtherType>> ConvertToAsync<TOtherType>(Func<T, CancellationToken, Task<TOtherType>> convertFunc, CancellationToken cancellationToken)
	{
		var items = await Task.WhenAll(Items.Select(x => convertFunc(x, cancellationToken)));
		return new PagedResult<TOtherType>(TotalItemsCount, [.. items]);
	}
	/// <summary>
	/// Iterates through Items
	/// </summary>
	public IEnumerator<T> GetEnumerator() => Items.GetEnumerator();
	IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();
}
