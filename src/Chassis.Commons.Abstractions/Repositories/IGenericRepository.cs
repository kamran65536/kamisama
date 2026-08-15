using KamiSama.Extensions.Paging;

namespace KamiSama.Chassis.Commons.Repositories;

/// <summary>
/// Combines add, update, delete, and paged-list repository capabilities with a custom page result.
/// </summary>
/// <typeparam name="TEntity">The persisted entity type.</typeparam>
/// <typeparam name="TSeaerchModel">The search and paging input type.</typeparam>
/// <typeparam name="TPagedResult">The page result returned by list operations.</typeparam>
public interface IGenericRepository<TEntity, TSeaerchModel, TPagedResult>
	: IAddableRepository<TEntity>, IUpdatableRepository<TEntity>, IDeletableRepository<TEntity>, IListingRepository<TEntity, TSeaerchModel, TPagedResult>
	where TSeaerchModel : SearchModel
	where TPagedResult : PagedResult<TEntity>
{
}
/// <summary>
/// Combines add, update, delete, and paged-list repository capabilities using the standard page result.
/// </summary>
/// <typeparam name="TEntity">The persisted entity type.</typeparam>
/// <typeparam name="TSearchModel">The search and paging input type.</typeparam>
public interface IGenericRepository<TEntity, TSearchModel>: 
	IGenericRepository<TEntity, TSearchModel, PagedResult<TEntity>>,
	IListingRepository<TEntity, TSearchModel>
	where TSearchModel : SearchModel
{
}
