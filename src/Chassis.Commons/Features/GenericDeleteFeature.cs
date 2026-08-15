namespace KamiSama.Chassis.Commons.Features;
/// <summary>
/// Implements the delete workflow by loading an entity, applying a deletion guard, and deleting it when allowed.
/// </summary>
/// <typeparam name="TEntity">The entity type being deleted.</typeparam>
/// <typeparam name="TRepository">The repository used to find and delete entities.</typeparam>
/// <typeparam name="TKey">The entity key type.</typeparam>
/// <param name="repository">The repository used by the workflow and deletion guard.</param>
public abstract class GenericDeleteFeature<TEntity, TRepository, TKey>(TRepository repository) :
	IDeleteFeature<TKey>
	where TRepository : ILookupByIdRepository<TEntity, TKey>, IDeletableRepository<TEntity>
{
	/// <summary>
	/// Gets the repository available to derived deletion guards.
	/// </summary>
	protected TRepository Repository { get => repository; }
	/// <summary>
	/// Determines whether the loaded entity may be deleted; the default implementation allows deletion.
	/// </summary>
	/// <param name="repository">The repository used by the delete workflow.</param>
	/// <param name="entity">The loaded entity proposed for deletion.</param>
	/// <returns><see langword="true"/> to delete the entity; otherwise, <see langword="false"/>.</returns>
	protected virtual Task<bool> CanBeDeletedAsync(TRepository repository, TEntity entity)
		=> Task.FromResult(true);

	/// <summary>Loads the entity, throws when it is missing, and deletes it when the guard permits.</summary>
	/// <param name="id">The key of the entity to delete.</param>
	/// <param name="cancellationToken">A token that can cancel repository operations.</param>
	/// <returns>A task that represents the asynchronous delete workflow.</returns>
	public async virtual Task DeleteAsync(TKey id, CancellationToken cancellationToken)
	{
		var entity = await repository.FindByIdAsync(id, cancellationToken) ?? throw new NotFoundException(nameof(TEntity), id);

		if (await CanBeDeletedAsync(repository, entity))
			await repository.DeleteAsync(entity, cancellationToken);
	}
}
