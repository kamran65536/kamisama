namespace KamiSama.Chassis.Commons.Repositories;

/// <summary>
/// Repository with find by Id feature
/// </summary>
public interface IFindByIdRepository<TEntity, TKey>
{
	/// <summary>
	/// finds an item with id
	/// </summary>
	Task<TEntity?> FindByIdAsync(TKey id, CancellationToken cancellationToken);
}
