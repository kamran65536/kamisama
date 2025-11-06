namespace KamiSama.Chassis.Commons.Repositories;

/// <summary>
/// A repository with listing capability
/// </summary>
public interface IListingRepository<TEntity, TSearchModel, TPagedResult>
	where TSearchModel : SearchModel
	where TPagedResult : PagedResult<TEntity>
{
	/// <summary>
	/// Lists items and page them
	/// </summary>
	Task<TPagedResult> ListAsync(TSearchModel searchModel, CancellationToken cancellationToken);
	/// <summary>
	/// Counts the item based on the search model
	/// </summary>
	Task<int> CountAsync(TSearchModel searchModel, CancellationToken cancellationToken);
}
/// <summary>
/// A repository with listing capability
/// </summary>
public interface IListingRepository<TEntity, TSearchModel> : IListingRepository<TEntity, TSearchModel, PagedResult<TEntity>>
	where TSearchModel : SearchModel;