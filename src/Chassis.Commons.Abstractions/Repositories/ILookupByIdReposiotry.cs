namespace KamiSama.Chassis.Commons.Repositories;

/// <summary>
/// Defines lookup and existence checks by entity identifier.
/// </summary>
/// <typeparam name="TEntity">The persisted entity type.</typeparam>
/// <typeparam name="TKey">The entity identifier type.</typeparam>
public interface ILookupByIdRepository<TEntity, TKey>
{
	/// <summary>
	/// Finds an entity by identifier.
	/// </summary>
	/// <param name="id">The identifier to find.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>The matching entity, or <see langword="null"/> when none exists.</returns>
	Task<TEntity?> FindByIdAsync(TKey id, CancellationToken cancellationToken);
	/// <summary>
	/// Determines whether an entity with the supplied identifier exists.
	/// </summary>
	/// <param name="id">The identifier to test.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns><see langword="true"/> when the entity exists; otherwise, <see langword="false"/>.</returns>
	Task<bool> ExistsByIdAsync(TKey id, CancellationToken cancellationToken);
}
