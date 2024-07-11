namespace KamiSama.Chassis.Commons.Repositories;

/// <summary>
/// A common scenario CRUD repository with add, delete, list, update capabilities
/// </summary>
public interface IGenericRepository<TEntity, TSeaerchModel>
	: IAddableRepository<TEntity>, IUpdatableRepository<TEntity>, IDeletableRepository<TEntity>, IListingRepository<TEntity, TSeaerchModel>
	where TSeaerchModel : SearchModel
{
}
