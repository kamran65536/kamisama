namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Defines a paged list query with a caller-selected result type.
/// </summary>
/// <typeparam name="TEntityDto">The DTO type contained in the result.</typeparam>
/// <typeparam name="TSearchModel">The search and paging input type.</typeparam>
/// <typeparam name="TPageResult">The paged result type returned to callers.</typeparam>
public interface IListFeature<TEntityDto, TSearchModel, TPageResult>
	where TSearchModel : SearchModel
	where TPageResult : PagedResult<TEntityDto>
{
	/// <summary>
	/// Searches for matching items and returns the requested page.
	/// </summary>
	/// <param name="searchModel">The filtering and paging values.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>A page of matching DTOs.</returns>
	Task<TPageResult> ListAsync(TSearchModel searchModel, CancellationToken cancellationToken);
}
/// <summary>
/// Defines a paged list query that returns the standard <see cref="PagedResult{T}"/> shape.
/// </summary>
/// <typeparam name="TEntityDto">The DTO type contained in the result.</typeparam>
/// <typeparam name="TSearchModel">The search and paging input type.</typeparam>
public interface IListFeature<TEntityDto, TSearchModel> : IListFeature<TEntityDto, TSearchModel, PagedResult<TEntityDto>>
	where TSearchModel : SearchModel
{
}
