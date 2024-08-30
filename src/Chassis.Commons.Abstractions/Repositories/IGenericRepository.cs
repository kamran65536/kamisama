using KamiSama.Extensions.Paging;

namespace KamiSama.Chassis.Commons.Repositories;

/// <summary>
/// A common scenario CRUD repository with add, delete, list, update capabilities
/// </summary>
public interface IGenericRepository<TEntity, TSeaerchModel, TPagedResult>
	: IAddableRepository<TEntity>, IUpdatableRepository<TEntity>, IDeletableRepository<TEntity>, IListingRepository<TEntity, TSeaerchModel, TPagedResult>
	where TSeaerchModel : SearchModel
	where TPagedResult : PagedResult<TEntity>
{
}
/// <summary>
/// A common scenario CRUD repository with add, delete, list, update capabilities
/// </summary>
public interface IGenericRepository<TEntity, TSearchModel>: 
	IGenericRepository<TEntity, TSearchModel, PagedResult<TEntity>>,
	IListingRepository<TEntity, TSearchModel>
	where TSearchModel : SearchModel
{
}