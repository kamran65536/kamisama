namespace KamiSama.Chassis.Commons.Repositories;

/// <summary>
/// Defines persistence of new entities.
/// </summary>
/// <typeparam name="TEntity">The persisted entity type.</typeparam>
public interface IAddableRepository<TEntity>
{
	/// <summary>
	/// Adds an entity to the underlying store.
	/// </summary>
	/// <param name="entity">The entity to add.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>A task that represents the asynchronous add.</returns>
	Task AddAsync(TEntity entity, CancellationToken cancellationToken);
}
