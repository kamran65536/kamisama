namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Generic implementation of <see cref="IAddFeature{TAddRequest, TEntityDto}"/>
/// </summary>
public abstract class GenericAddFeature<TAddRequest, TRepository, TEntity, TEntityDto>(TRepository repository) : 
	IAddFeature<TAddRequest, TEntityDto>
	where TRepository : IAddableRepository<TEntity>
{
	/// <summary>
	/// repository of <typeparamref name="TEntity"/>
	/// </summary>
	protected TRepository Repository { get => repository; }
	/// <summary>
	/// Checks for duplicate item in the database
	/// </summary>
	protected virtual Task CheckDuplicateAsync(TAddRequest request, CancellationToken cancellationToken) => Task.CompletedTask;
	/// <summary>
	/// Converts the request to <typeparamref name="TEntity"/>
	/// </summary>
	protected abstract Task<TEntity> ConvertToEntity(TAddRequest request, CancellationToken cancellationToken);
	/// <summary>
	/// Converts the result entity to dto
	/// </summary>
	/// <param name="entity"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	protected abstract Task<TEntityDto> ConvertToDto(TEntity entity, CancellationToken cancellationToken);
	/// <inheritdoc />
	public virtual async Task<TEntityDto> AddAsync(TAddRequest request, CancellationToken cancellationToken)
	{
		await CheckDuplicateAsync(request, cancellationToken);

		var entity = await ConvertToEntity(request, cancellationToken);

		await repository.AddAsync(entity, cancellationToken);

		var dto = await ConvertToDto(entity, cancellationToken);

		return dto;
	}
}
