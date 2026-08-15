namespace KamiSama.Chassis.Commons.Repositories;

/// <summary>
/// Defines paged listing and counting with a caller-selected result type.
/// </summary>
/// <typeparam name="TEntity">The persisted entity type.</typeparam>
/// <typeparam name="TSearchModel">The search and paging input type.</typeparam>
/// <typeparam name="TPagedResult">The page result returned by list operations.</typeparam>
public interface IListingRepository<TEntity, TSearchModel, TPagedResult>
	where TSearchModel : SearchModel
	where TPagedResult : PagedResult<TEntity>
{
	/// <summary>
	/// Searches the store and returns the requested page.
	/// </summary>
	/// <param name="searchModel">The filtering and paging values.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>A page of matching entities.</returns>
	Task<TPagedResult> ListAsync(TSearchModel searchModel, CancellationToken cancellationToken);
	/// <summary>
	/// Counts entities matching the search criteria.
	/// </summary>
	/// <param name="searchModel">The filtering values used for the count.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>The number of matching entities.</returns>
	Task<int> CountAsync(TSearchModel searchModel, CancellationToken cancellationToken);
}
/// <summary>
/// Defines paged listing and counting using the standard <see cref="PagedResult{T}"/> shape.
/// </summary>
/// <typeparam name="TEntity">The persisted entity type.</typeparam>
/// <typeparam name="TSearchModel">The search and paging input type.</typeparam>
public interface IListingRepository<TEntity, TSearchModel> : IListingRepository<TEntity, TSearchModel, PagedResult<TEntity>>
	where TSearchModel : SearchModel;
