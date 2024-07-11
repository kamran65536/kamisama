namespace KamiSama.Chassis.Commons.Repositories;

/// <summary>
/// The repository with add capability
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IAddableRepository<TEntity>
{
	/// <summary>
	/// Adds an item to the database
	/// </summary>
	/// <param name="entity"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task AddAsync(TEntity entity, CancellationToken cancellationToken);
}
