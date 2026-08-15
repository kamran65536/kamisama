namespace KamiSama.Chassis.Commons.Repositories;

/// <summary>
/// Defines persistence of changes to existing entities.
/// </summary>
/// <typeparam name="TEntity">The persisted entity type.</typeparam>
public interface IUpdatableRepository<TEntity>
{
	/// <summary>
	/// Updates an entity in the underlying store.
	/// </summary>
	/// <param name="entity">The entity containing updated values.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>A task that represents the asynchronous update.</returns>
	Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
}
