namespace KamiSama.Repositories;

/// <summary>
/// Adds asynchronous mutation and lookup operations to the synchronous repository contract.
/// </summary>
/// <typeparam name="_EntityType">The entity type stored by the repository.</typeparam>
public interface IAsyncRepository<_EntityType> : IRepository<_EntityType>
{
	/// <summary>
	/// Asynchronously adds an entity according to the implementation's persistence and duplicate rules.
	/// </summary>
	/// <param name="item">The entity to add.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>A task that represents the add operation.</returns>
	Task AddAsync(_EntityType item, CancellationToken cancellationToken);
	/// <summary>
	/// Asynchronously updates an entity according to the implementation's persistence rules.
	/// </summary>
	/// <param name="item">The entity to update.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>A task that represents the update operation.</returns>
	Task UpdateAsync(_EntityType item, CancellationToken cancellationToken);
	/// <summary>
	/// Asynchronously deletes an entity according to the implementation's matching and persistence rules.
	/// </summary>
	/// <param name="item">The entity to delete.</param>
	/// <param name="cancellation">A token that can cancel the operation.</param>
	/// <returns>A task that represents the delete operation.</returns>
	Task DeleteAsync(_EntityType item, CancellationToken cancellation);
	/// <summary>
	/// Asynchronously returns the first entity that satisfies the predicate.
	/// </summary>
	/// <param name="predicate">The predicate used to select an entity.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>A task containing the first matching entity, or <see langword="null"/>.</returns>
	Task<_EntityType?> FindAsync(Expression<Func<_EntityType, bool>> predicate, CancellationToken cancellationToken);
}
