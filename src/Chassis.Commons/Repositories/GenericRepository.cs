namespace KamiSama.Chassis.Commons.Repositories;

/// <summary>
/// Generic implementation of <see cref="IGenericRepository{TEntity, TSeaerchModel}"/>
/// </summary>
public abstract class GenericRepository<TEntity, TSearchModel, TDbContext>(TDbContext context) : 
	DbRepository<TEntity, TDbContext>(context), 
	IGenericRepository<TEntity, TSearchModel>
	where TEntity : class
	where TSearchModel : SearchModel
	where TDbContext : DbContext
{
	/// <summary>
	/// Applies search model for <see cref="ListAsync(TSearchModel, CancellationToken)"/>
	/// </summary>
	/// <param name="query"></param>
	/// <param name="searchModel"></param>
	/// <returns></returns>
	protected abstract IQueryable<TEntity> ApplySearchModel(IQueryable<TEntity> query, TSearchModel searchModel);

	/// <inheritdoc />
	public Task<PagedResult<TEntity>> ListAsync(TSearchModel searchModel, CancellationToken cancellationToken)
	{
		var query = base.AsQueryable();

		query = ApplySearchModel(query, searchModel);

		return query.MakePagedAsync(searchModel, cancellationToken);
	}
}
