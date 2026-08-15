namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Implements lookup by name, missing-entity handling, and entity-to-DTO mapping.
/// </summary>
/// <typeparam name="TEntity">The entity returned by the repository.</typeparam>
/// <typeparam name="TEntityDto">The DTO returned to callers.</typeparam>
/// <typeparam name="TRepository">The repository type that supports name lookup.</typeparam>
/// <param name="repository">The repository used by the lookup workflow.</param>
public abstract class GenericFindByNameFeature<TEntity, TEntityDto, TRepository>(TRepository repository) : 
	IFindByNameFeature<TEntityDto>
	where TRepository : ILookupByNameRepository<TEntity>
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

	/// <summary>Finds an entity by name, throws when missing, and converts it to a DTO.</summary>
	/// <param name="name">The entity name to find.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>The DTO for the matching entity.</returns>
	/// <exception cref="NotFoundException{TEntity}">No entity exists with the supplied name.</exception>
	public async virtual Task<TEntityDto> FindByNameAsync(string name, CancellationToken cancellationToken)
	{
		var entity = await repository.FindByNameAsync(name, cancellationToken) ?? throw new NotFoundException<TEntity>(name);

		return await ConvertToDto(entity, cancellationToken);
	}
}
