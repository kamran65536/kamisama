namespace KamiSama.Chassis.Commons.Repositories;

/// <summary>
/// Repository with find by Id feature
/// </summary>
public interface ILookupByIdRepository<TEntity, TKey>
{
	/// <summary>
	/// finds an item with id
	/// </summary>
	Task<TEntity?> FindByIdAsync(TKey id, CancellationToken cancellationToken);
	/// <summary>
	/// Exists if an entity exists by id or not
	/// </summary>
	/// <param name="id"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<bool> ExistsByIdAsync(TKey id, CancellationToken cancellationToken);
}
