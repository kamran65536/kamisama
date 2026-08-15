namespace KamiSama.Chassis.Commons.Repositories;

/// <summary>
/// Provides an EF Core CRUD repository whose standard page result is built with <c>MakePagedAsync</c>.
/// </summary>
/// <typeparam name="TEntity">The EF Core entity type.</typeparam>
/// <typeparam name="TSearchModel">The search and paging input type.</typeparam>
/// <typeparam name="TDbContext">The EF Core context type.</typeparam>
/// <param name="context">The context used for CRUD and query operations.</param>
public abstract class GenericRepository<TEntity, TSearchModel, TDbContext>(TDbContext context) : 
	GenericRepository<TEntity, TSearchModel, TDbContext, PagedResult<TEntity>>(context),
	IGenericRepository<TEntity, TSearchModel>
	where TEntity : class
	where TSearchModel : SearchModel
	where TDbContext : DbContext
{
	/// <summary>Executes the filtered query and returns the requested standard page.</summary>
	/// <param name="query">The filtered entity query.</param>
	/// <param name="searchModel">The paging values.</param>
	/// <param name="cancellationToken">A token that can cancel query execution.</param>
	/// <returns>The materialized entity page.</returns>
	protected override Task<PagedResult<TEntity>> MakeResultAsync(IQueryable<TEntity> query, TSearchModel searchModel, CancellationToken cancellationToken)
		=> query.MakePagedAsync(searchModel, cancellationToken);
}
/// <summary>
/// Provides EF Core CRUD, filtered listing, and counting with a custom page result type.
/// </summary>
/// <typeparam name="TEntity">The EF Core entity type.</typeparam>
/// <typeparam name="TSearchModel">The search and paging input type.</typeparam>
/// <typeparam name="TDbContext">The EF Core context type.</typeparam>
/// <typeparam name="TPagedResult">The custom page result returned by list operations.</typeparam>
/// <param name="context">The context used for CRUD and query operations.</param>
public abstract class GenericRepository<TEntity, TSearchModel, TDbContext, TPagedResult>(TDbContext context) :
	DbRepository<TEntity, TDbContext>(context),
	IGenericRepository<TEntity, TSearchModel, TPagedResult>
	where TEntity : class
	where TSearchModel : SearchModel
	where TDbContext : DbContext
	where TPagedResult : PagedResult<TEntity>
{
	/// <summary>
	/// Applies entity-specific filtering and ordering before listing or counting.
	/// </summary>
	/// <param name="query">The base query for the entity set.</param>
	/// <param name="searchModel">The search values to apply.</param>
	/// <returns>The filtered query.</returns>
	protected abstract IQueryable<TEntity> ApplySearchModel(IQueryable<TEntity> query, TSearchModel searchModel);
	/// <summary>
	/// Executes the filtered query and builds the custom page result.
	/// </summary>
	/// <param name="query">The filtered entity query.</param>
	/// <param name="searchModel">The paging values.</param>
	/// <param name="cancellationToken">A token that can cancel query execution.</param>
	/// <returns>The materialized custom page result.</returns>
	protected abstract Task<TPagedResult> MakeResultAsync(IQueryable<TEntity> query, TSearchModel searchModel, CancellationToken cancellationToken);

	/// <summary>Applies the search model and returns a materialized page of matching entities.</summary>
	/// <param name="searchModel">The filtering and paging values.</param>
	/// <param name="cancellationToken">A token that can cancel query execution.</param>
	/// <returns>A page of matching entities.</returns>
	public Task<TPagedResult> ListAsync(TSearchModel searchModel, CancellationToken cancellationToken)
	{
		var query = base.AsQueryable();

		query = ApplySearchModel(query, searchModel);

		return MakeResultAsync(query, searchModel, cancellationToken);
	}
	/// <summary>Applies the search model and counts matching entities without paging.</summary>
	/// <param name="searchModel">The filtering values.</param>
	/// <param name="cancellationToken">A token that can cancel query execution.</param>
	/// <returns>The number of matching entities.</returns>
	public Task<int> CountAsync(TSearchModel searchModel, CancellationToken cancellationToken)
	{
		var query = base.AsQueryable();
		query = ApplySearchModel(query, searchModel);

		return query.CountAsync(cancellationToken);
	}
}
