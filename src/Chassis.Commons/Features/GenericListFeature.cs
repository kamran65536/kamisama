namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Generic implementation of <see cref="IListFeature{TEntityDto, TSearchModel}"/>
/// </summary>
public abstract class GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository, TPagedResult, TRepositoryPagedResult>(TRepository repository, IMapper mapper) :
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
	/// <param name="repositoryResult"></param>
	/// <returns></returns>
	protected virtual TPagedResult ConvertResult(TRepositoryPagedResult repositoryResult)
		=> mapper.Map<TPagedResult>(repositoryResult);
	///<inheritdoc />
	public virtual async Task<TPagedResult> ListAsync(TSearchModel searchModel, CancellationToken cancellationToken)
	{
		var result = await repository.ListAsync(searchModel, cancellationToken);

		return ConvertResult(result);
	}
}
/// <summary>
/// Generic implementation of <see cref="IListFeature{TEntityDto, TSearchModel}"/>
/// </summary>
public abstract class GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository>(TRepository repository, IMapper mapper) :
	IListFeature<TEntityDto, TSearchModel>
	where TRepository : IListingRepository<TEntity, TSearchModel>
	where TSearchModel : SearchModel
{
	/// <summary>
	/// Repository field to be used
	/// </summary>
	protected TRepository Repository { get => repository; }
	/// <summary>
	/// Covnerts a database <paramref name="entity"/> to <typeparamref name="TEntity"/>
	/// default behaviour uses <see cref="IMapper" />
	/// </summary>
	/// <param name="entity"></param>
	/// <returns></returns>
	protected virtual TEntityDto ConvertToDto(TEntity entity)
		=> mapper.Map<TEntityDto>(entity);
	///<inheritdoc />
	public virtual async Task<PagedResult<TEntityDto>> ListAsync(TSearchModel searchModel, CancellationToken cancellationToken)
	{
		var result = await repository.ListAsync(searchModel, cancellationToken);

		return result.ConvertTo(ConvertToDto);
	}
}
