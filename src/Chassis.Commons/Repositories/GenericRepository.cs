namespace KamiSama.Chassis.Commons.Repositories;

/// <summary>
/// Generic implementation of <see cref="IGenericRepository{TEntity, TSeaerchModel}"/>
/// </summary>
public abstract class GenericRepository<TEntity, TSearchModel, TDbContext>(TDbContext context) : 
	GenericRepository<TEntity, TSearchModel, TDbContext, PagedResult<TEntity>>(context),
	IGenericRepository<TEntity, TSearchModel>
	where TEntity : class
	where TSearchModel : SearchModel
	where TDbContext : DbContext
{
	/// <inheritdoc />
	protected override Task<PagedResult<TEntity>> MakeResultAsync(IQueryable<TEntity> query, TSearchModel searchModel, CancellationToken cancellationToken)
		=> query.MakePagedAsync(searchModel, cancellationToken);
}
/// <summary>
/// Generic implementation of <see cref="IGenericRepository{TEntity, TSeaerchModel}"/>
/// </summary>
public abstract class GenericRepository<TEntity, TSearchModel, TDbContext, TPagedResult>(TDbContext context) :
	DbRepository<TEntity, TDbContext>(context),
	IGenericRepository<TEntity, TSearchModel, TPagedResult>
	where TEntity : class
	where TSearchModel : SearchModel
	where TDbContext : DbContext
	where TPagedResult : PagedResult<TEntity>
{
	/// <summary>
	/// Applies search model for <see cref="ListAsync(TSearchModel, CancellationToken)"/>
	/// </summary>
	protected abstract IQueryable<TEntity> ApplySearchModel(IQueryable<TEntity> query, TSearchModel searchModel);
	/// <summary>
	/// Converts the query to paged result
	/// </summary>
	/// <returns></returns>
	protected abstract Task<TPagedResult> MakeResultAsync(IQueryable<TEntity> query, TSearchModel searchModel, CancellationToken cancellationToken);

	/// <inheritdoc />
	public Task<TPagedResult> ListAsync(TSearchModel searchModel, CancellationToken cancellationToken)
	{
		var query = base.AsQueryable();

		query = ApplySearchModel(query, searchModel);

		return MakeResultAsync(query, searchModel, cancellationToken);
	}
	/// <inheritdoc />
	public Task<int> CountAsync(TSearchModel searchModel, CancellationToken cancellationToken)
	{
		var query = base.AsQueryable();
		query = ApplySearchModel(query, searchModel);

		return query.CountAsync(cancellationToken);
	}
}