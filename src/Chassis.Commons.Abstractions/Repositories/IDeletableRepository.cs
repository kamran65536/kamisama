namespace KamiSama.Chassis.Commons.Repositories;

/// <summary>
/// Defines deletion of persisted entities.
/// </summary>
/// <typeparam name="TEntity">The persisted entity type.</typeparam>
public interface IDeletableRepository<TEntity>
{
	/// <summary>
	/// Deletes an entity from the underlying store.
	/// </summary>
	/// <param name="entity">The entity to delete.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>A task that represents the asynchronous deletion.</returns>
	Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
}
