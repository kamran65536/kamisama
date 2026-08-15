namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Implements the create workflow by validating, mapping, persisting, and returning a DTO.
/// </summary>
/// <typeparam name="TAddRequest">The create request type.</typeparam>
/// <typeparam name="TRepository">The repository type used to add entities.</typeparam>
/// <typeparam name="TEntity">The entity type persisted by the repository.</typeparam>
/// <typeparam name="TEntityDto">The DTO returned to callers.</typeparam>
/// <param name="repository">The repository used by the workflow and derived hooks.</param>
public abstract class GenericAddFeature<TAddRequest, TRepository, TEntity, TEntityDto>(TRepository repository) : 
	IAddFeature<TAddRequest, TEntityDto>
	where TRepository : IAddableRepository<TEntity>
{
	/// <summary>
	/// Gets the repository available to derived validation and mapping implementations.
	/// </summary>
	protected TRepository Repository { get => repository; }
	/// <summary>
	/// Validates the request for duplicate or conflicting data before entity creation.
	/// </summary>
	/// <param name="request">The create request to validate.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>A task that completes when validation succeeds.</returns>
	protected virtual Task CheckDuplicateAsync(TAddRequest request, CancellationToken cancellationToken) => Task.CompletedTask;
	/// <summary>
	/// Converts the validated request to the entity that will be persisted.
	/// </summary>
	/// <param name="request">The validated create request.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>The entity to add.</returns>
	protected abstract Task<TEntity> ConvertToEntity(TAddRequest request, CancellationToken cancellationToken);
	/// <summary>
	/// Converts the persisted entity to the DTO returned to the caller.
	/// </summary>
	/// <param name="entity">The entity added by the repository.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>The DTO representation of the entity.</returns>
	protected abstract Task<TEntityDto> ConvertToDto(TEntity entity, CancellationToken cancellationToken);
	/// <summary>Runs duplicate validation, request mapping, repository persistence, and DTO mapping.</summary>
	/// <param name="request">The values used to create the entity.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>The DTO produced from the added entity.</returns>
	public virtual async Task<TEntityDto> AddAsync(TAddRequest request, CancellationToken cancellationToken)
	{
		await CheckDuplicateAsync(request, cancellationToken);

		var entity = await ConvertToEntity(request, cancellationToken);

		await repository.AddAsync(entity, cancellationToken);

		var dto = await ConvertToDto(entity, cancellationToken);

		return dto;
	}
}
