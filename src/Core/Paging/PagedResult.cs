using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace KamiSama.Extensions.Paging;

/// <summary>
/// Paged Result
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="TotalItemsCount"></param>
/// <param name="Items"></param>
public record PagedResult<T>(int TotalItemsCount, List<T> Items)
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
}
