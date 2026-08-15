using KamiSama.Chassis.Commons.Repositories;

namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Implements the update workflow by loading, validating, patching, and persisting an entity.
/// </summary>
/// <typeparam name="TUpdateRequest">The request type containing updated values.</typeparam>
/// <typeparam name="TEntity">The entity type being updated.</typeparam>
/// <typeparam name="TRepository">The repository used to find and update entities.</typeparam>
/// <typeparam name="TKey">The entity key type.</typeparam>
/// <param name="repository">The repository used by the workflow and derived hooks.</param>
public abstract class GenericUpdateFeature<TUpdateRequest, TEntity, TRepository, TKey>(TRepository repository) :
	IUpdateFeature<TUpdateRequest, TKey>
	where TRepository : ILookupByIdRepository<TEntity, TKey>, IUpdatableRepository<TEntity>
{
	/// <summary>
	/// Gets the repository available to derived validation and patch implementations.
	/// </summary>
	protected TRepository Repository { get => repository; }
	/// <summary>
	/// Validates the update for duplicate or conflicting data before patching the loaded entity.
	/// </summary>
	/// <param name="id">The key of the entity being updated.</param>
	/// <param name="request">The update request to validate.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>A task that completes when validation succeeds.</returns>
	protected virtual Task CheckDuplicateAsync(TKey id, TUpdateRequest request, CancellationToken cancellationToken) => Task.CompletedTask;
	/// <summary>Copies request values onto the loaded entity before it is saved.</summary>
	/// <param name="entity">The tracked entity to modify.</param>
	/// <param name="request">The update values to apply.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>A task that completes when the entity has been patched.</returns>
	protected abstract Task PatchEntityAsync(TEntity entity, TUpdateRequest request, CancellationToken cancellationToken);
	/// <summary>Loads the entity, validates the request, patches the entity, and updates it through the repository.</summary>
	/// <param name="id">The key of the entity to update.</param>
	/// <param name="request">The update values to apply.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>A task that represents the asynchronous update workflow.</returns>
	public async virtual Task UpdateAsync(TKey id, TUpdateRequest request, CancellationToken cancellationToken)
	{
		var entity = await repository.FindByIdAsync(id, cancellationToken) ?? throw new NotFoundException(nameof(TEntity), id);

		await CheckDuplicateAsync(id, request, cancellationToken);
		await PatchEntityAsync(entity, request, cancellationToken);
		await Repository.UpdateAsync(entity, cancellationToken);
	}
}
