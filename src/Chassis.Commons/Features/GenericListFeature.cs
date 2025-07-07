namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Generic implementation of <see cref="IListFeature{TEntityDto, TSearchModel}"/>
/// </summary>
public abstract class GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository, TPagedResult, TRepositoryPagedResult>(TRepository repository) :
	IListFeature<TEntityDto, TSearchModel, TPagedResult>
	where TRepository : IListingRepository<TEntity, TSearchModel, TRepositoryPagedResult>
	where TSearchModel : SearchModel
	where TPagedResult : PagedResult<TEntityDto>
	where TRepositoryPagedResult : PagedResult<TEntity>
{
	/// <summary>
	/// Repository field to be used
	/// </summary>
	protected TRepository Repository { get => repository; }
	/// <summary>
	/// Converts the repository result into list result
	/// </summary>
	protected abstract Task<TPagedResult> ConvertResult(TRepositoryPagedResult repositoryResult, CancellationToken cancellationToken);
	///<inheritdoc />
	public virtual async Task<TPagedResult> ListAsync(TSearchModel searchModel, CancellationToken cancellationToken)
	{
		var result = await repository.ListAsync(searchModel, cancellationToken);

		return await ConvertResult(result, cancellationToken);
	}
}
/// <summary>
/// Generic implementation of <see cref="IListFeature{TEntityDto, TSearchModel}"/>
/// </summary>
public abstract class GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository>(TRepository repository) :
	IListFeature<TEntityDto, TSearchModel>
	where TRepository : IListingRepository<TEntity, TSearchModel>
	where TSearchModel : SearchModel
{
	/// <summary>
	/// Repository field to be used
	/// </summary>
	protected TRepository Repository { get => repository; }
	/// <summary>
	/// Converts a database <paramref name="entity"/> to <typeparamref name="TEntity"/>
	/// </summary>
	protected abstract Task<TEntityDto> ConvertToDto(TEntity entity, CancellationToken cancellationToken);
	///<inheritdoc />
	public virtual async Task<PagedResult<TEntityDto>> ListAsync(TSearchModel searchModel, CancellationToken cancellationToken)
	{
		var result = await repository.ListAsync(searchModel, cancellationToken);

		return await result.ConvertToAsync(ConvertToDto, cancellationToken);
	}
}
