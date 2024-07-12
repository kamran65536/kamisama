namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Generic implementation of <see cref="IListFeature{TEntityDto, TSearchModel}"/>
/// </summary>
public abstract class GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository>(TRepository repository, IMapper mapper) :
	IListFeature<TEntityDto, TSearchModel>
	where TRepository : IListingRepository<TEntity, TSearchModel>
	where TSearchModel : SearchModel
{
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
