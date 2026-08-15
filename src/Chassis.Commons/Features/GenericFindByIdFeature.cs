namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Implements lookup by identifier, missing-entity handling, and entity-to-DTO mapping.
/// </summary>
/// <typeparam name="TEntity">The entity returned by the repository.</typeparam>
/// <typeparam name="TEntityDto">The DTO returned to callers.</typeparam>
/// <typeparam name="TRepository">The repository type that supports identifier lookup.</typeparam>
/// <typeparam name="TKey">The entity identifier type.</typeparam>
/// <param name="repository">The repository used by the lookup workflow.</param>
public abstract class GenericFindByIdFeature<TEntity, TEntityDto, TRepository, TKey>(TRepository repository) :
	IFindByIdFeature<TEntityDto, TKey>
	where TRepository : ILookupByIdRepository<TEntity, TKey>
{
	/// <summary>
	/// Gets the repository available to derived mapping implementations.
	/// </summary>
	protected TRepository Repository { get => repository; }

	/// <summary>
	/// Converts the loaded entity to the DTO returned to the caller.
	/// </summary>
	/// <param name="entity">The entity loaded from the repository.</param>
	/// <param name="cancellationToken">A token that can cancel the mapping operation.</param>
	/// <returns>The DTO representation of the entity.</returns>
	protected abstract Task<TEntityDto> ConvertToDto(TEntity entity, CancellationToken cancellationToken);
	/// <summary>
	/// Finds an entity by identifier and converts it to a DTO.
	/// </summary>
	/// <param name="id">The identifier to find.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>The DTO for the matching entity.</returns>
	/// <exception cref="NotFoundException{TEntity}">No entity exists with the supplied identifier.</exception>
	public async virtual Task<TEntityDto> FindByIdAsync(TKey id, CancellationToken cancellationToken)
	{
		var entity = await repository.FindByIdAsync(id, cancellationToken) ?? throw new NotFoundException<TEntity>(id);

		return await ConvertToDto(entity, cancellationToken);
	}
}
