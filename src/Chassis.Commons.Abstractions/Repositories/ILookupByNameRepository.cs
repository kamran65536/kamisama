namespace KamiSama.Chassis.Commons.Repositories;

/// <summary>
/// Defines lookup and existence checks by entity name.
/// </summary>
/// <typeparam name="TEntity">The persisted entity type.</typeparam>
public interface ILookupByNameRepository<TEntity>
{
	/// <summary>
	/// Finds an entity by name.
	/// </summary>
	/// <param name="name">The name to find.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>The matching entity, or <see langword="null"/> when none exists.</returns>
	Task<TEntity?> FindByNameAsync(string name, CancellationToken cancellationToken);
	/// <summary>
	/// Determines whether an entity with the supplied name exists.
	/// </summary>
	/// <param name="name">The name to test.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns><see langword="true"/> when the entity exists; otherwise, <see langword="false"/>.</returns>
	Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken);
}
