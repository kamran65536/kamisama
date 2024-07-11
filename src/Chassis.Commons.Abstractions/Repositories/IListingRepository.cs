namespace KamiSama.Chassis.Commons.Repositories;

/// <summary>
/// A repository with listing capability
/// </summary>
public interface IListingRepository<TEntity, TSearchModel>
	where TSearchModel : SearchModel
{
	/// <summary>
	/// Lists items and page them
	/// </summary>
	/// <param name="searchModel"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<PagedResult<TEntity>> ListAsync(TSearchModel searchModel, CancellationToken cancellationToken);
}
