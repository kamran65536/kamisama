using Microsoft.AspNetCore.Mvc;

namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Generic implementation of <see cref="IListFeature{TEntityDto, TSearchModel}"/>
/// </summary>
public abstract class GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository, TPagedResult>(TRepository repository, IMapper mapper) :
	IListFeature<TEntityDto, TSearchModel>
	where TRepository : IListingRepository<TEntity, TSearchModel, TPagedResult>
	where TSearchModel : SearchModel
	where TPagedResult : PagedResult<TEntity>
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
/// <summary>
/// Generic implementation of <see cref="IListFeature{TEntityDto, TSearchModel}"/>
/// </summary>
public abstract class GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository>(TRepository repository, IMapper mapper) :
	GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository, PagedResult<TEntity>>(repository, mapper)
	where TRepository : IListingRepository<TEntity, TSearchModel, PagedResult<TEntity>>
	where TSearchModel: SearchModel;
