using KamiSama.Chassis.Commons.Repositories;

namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Generic implementation of <see cref="IUpdateFeature{TEntityDto, TKey}"/>
/// </summary>
public abstract class GenericUpdateFeature<TUpdateRequest, TEntity, TRepository, TKey>(TRepository repository, IMapper mapper) :
	IUpdateFeature<TUpdateRequest, TKey>
	where TRepository : ILookupByIdRepository<TEntity, TKey>, IUpdatableRepository<TEntity>
{
	/// <summary>
	/// repository for fearther use
	/// </summary>
	protected TRepository Repository { get => repository; }
	/// <summary>
	/// Checks for duplicate item in the database
	/// </summary>
	protected virtual Task CheckDuplicateAsync(TKey id, TUpdateRequest request, CancellationToken cancellationToken) => Task.CompletedTask;
	/// <summary>
	/// Patches the entity with the request, the default behaviour uses <see cref="IMapper"/>
	/// </summary>
	protected virtual void PatchEntity(TEntity entity, TUpdateRequest request)
		=> mapper.Map(request, entity);
	/// <inheritdoc />
	public async virtual Task UpdateAsync(TKey id, TUpdateRequest request, CancellationToken cancellationToken)
	{
		var entity = await repository.FindByIdAsync(id, cancellationToken) ?? throw new NotFoundException(nameof(TEntity), id);

		await CheckDuplicateAsync(id, request, cancellationToken);

		PatchEntity(entity, request);

		await Repository.UpdateAsync(entity, cancellationToken);
	}
}
