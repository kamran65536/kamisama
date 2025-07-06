using KamiSama.Chassis.Commons.Repositories;

namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Generic implementation of <see cref="IUpdateFeature{TEntityDto, TKey}"/>
/// </summary>
public abstract class GenericUpdateFeature<TUpdateRequest, TEntity, TRepository, TKey>(TRepository repository) :
	IUpdateFeature<TUpdateRequest, TKey>
	where TRepository : ILookupByIdRepository<TEntity, TKey>, IUpdatableRepository<TEntity>
{
	/// <summary>
	/// repository for further use
	/// </summary>
	protected TRepository Repository { get => repository; }
	/// <summary>
	/// Checks for duplicate item in the database
	/// </summary>
	protected virtual Task CheckDuplicateAsync(TKey id, TUpdateRequest request, CancellationToken cancellationToken) => Task.CompletedTask;
	/// <summary>
	/// </summary>
	protected abstract Task PatchEntityAsync(TEntity entity, TUpdateRequest request, CancellationToken cancellationToken);
	/// <inheritdoc />
	public async virtual Task UpdateAsync(TKey id, TUpdateRequest request, CancellationToken cancellationToken)
	{
		var entity = await repository.FindByIdAsync(id, cancellationToken) ?? throw new NotFoundException(nameof(TEntity), id);

		await CheckDuplicateAsync(id, request, cancellationToken);
		await PatchEntityAsync(entity, request, cancellationToken);
		await Repository.UpdateAsync(entity, cancellationToken);
	}
}
