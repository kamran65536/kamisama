namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Generic implementation of <see cref="IAddFeature{TAddRequest}"/>
/// </summary>
/// <typeparam name="TAddRequest"></typeparam>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="TRepository"></typeparam>
/// <param name="repository"></param>
/// <param name="mapper"></param>
public abstract class GenericAddFeature<TAddRequest, TEntity, TRepository>(TRepository repository, IMapper mapper) : IAddFeature<TAddRequest>
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
	/// <inheritdoc />
	public virtual async Task AddAsync(TAddRequest request, CancellationToken cancellationToken)
	{
		await CheckDuplicateAsync(request, cancellationToken);

		var entity = await ConvertToEntity(request, cancellationToken);

		await Repository.AddAsync(entity, cancellationToken);
	}
}
