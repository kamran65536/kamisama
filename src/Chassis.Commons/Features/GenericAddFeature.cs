namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Generic implementation of <see cref="IAddFeature{TAddRequest, TEntityDto}"/>
/// </summary>
public abstract class GenericAddFeature<TAddRequest, TRepository, TEntity, TEntityDto>(TRepository repository, IMapper mapper) : 
	IAddFeature<TAddRequest, TEntityDto>
	where TRepository : IAddableRepository<TEntity>
{
	/// <summary>
	/// repository of <typeparamref name="TEntity"/>
	/// </summary>
	protected TRepository Repository { get; } = repository;
	/// <summary>
	/// Checks for duplicate item in the database
	/// </summary>
	protected virtual Task CheckDuplicateAsync(TAddRequest request, CancellationToken cancellationToken) => Task.CompletedTask;
	/// <summary>
	/// Converts the request to <typeparamref name="TEntity"/>
	/// default behaivour uses <see cref="IMapper" />
	/// </summary>
	protected virtual Task<TEntity> ConvertToEntity(TAddRequest request, CancellationToken cancellationToken)
		=> Task.FromResult(mapper.Map<TEntity>(request));
	/// <summary>
	/// Converts the result entity to dto
	/// </summary>
	/// <param name="entity"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	protected virtual Task<TEntityDto> ConvertToDto(TEntity entity, CancellationToken cancellationToken)
		=> Task.FromResult(mapper.Map<TEntityDto>(entity));
	/// <inheritdoc />
	public virtual async Task<TEntityDto> AddAsync(TAddRequest request, CancellationToken cancellationToken)
	{
		await CheckDuplicateAsync(request, cancellationToken);

		var entity = await ConvertToEntity(request, cancellationToken);

		await Repository.AddAsync(entity, cancellationToken);

		var dto = await ConvertToDto(entity, cancellationToken);

		return dto;
	}
}
