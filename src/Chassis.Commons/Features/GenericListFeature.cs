namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Implements a paged list workflow with custom repository and feature result shapes.
/// </summary>
/// <typeparam name="TEntity">The entity type returned by the repository.</typeparam>
/// <typeparam name="TEntityDto">The DTO type returned to callers.</typeparam>
/// <typeparam name="TSearchModel">The search and paging input type.</typeparam>
/// <typeparam name="TRepository">The repository used to load a page.</typeparam>
/// <typeparam name="TPagedResult">The page result returned to callers.</typeparam>
/// <typeparam name="TRepositoryPagedResult">The page result returned by the repository.</typeparam>
/// <param name="repository">The repository used by the list workflow.</param>
public abstract class GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository, TPagedResult, TRepositoryPagedResult>(TRepository repository) :
	IListFeature<TEntityDto, TSearchModel, TPagedResult>
	where TRepository : IListingRepository<TEntity, TSearchModel, TRepositoryPagedResult>
	where TSearchModel : SearchModel
	where TPagedResult : PagedResult<TEntityDto>
	where TRepositoryPagedResult : PagedResult<TEntity>
{
	/// <summary>
	/// Gets the repository available to derived conversion implementations.
	/// </summary>
	protected TRepository Repository { get => repository; }
	/// <summary>
	/// Converts the repository page into the result shape returned to callers.
	/// </summary>
	/// <param name="repositoryResult">The page returned by the repository.</param>
	/// <param name="cancellationToken">A token that can cancel the conversion.</param>
	/// <returns>The converted feature result.</returns>
	protected abstract Task<TPagedResult> ConvertResult(TRepositoryPagedResult repositoryResult, CancellationToken cancellationToken);
	/// <summary>Loads a repository page and converts it to the caller-facing result shape.</summary>
	/// <param name="searchModel">The filtering and paging values.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>A converted page of matching DTOs.</returns>
	public virtual async Task<TPagedResult> ListAsync(TSearchModel searchModel, CancellationToken cancellationToken)
	{
		var result = await repository.ListAsync(searchModel, cancellationToken);

		return await ConvertResult(result, cancellationToken);
	}
}
/// <summary>
/// Implements a paged list workflow using standard <see cref="PagedResult{T}"/> result shapes.
/// </summary>
/// <typeparam name="TEntity">The entity type returned by the repository.</typeparam>
/// <typeparam name="TEntityDto">The DTO type returned to callers.</typeparam>
/// <typeparam name="TSearchModel">The search and paging input type.</typeparam>
/// <typeparam name="TRepository">The repository used to load a page.</typeparam>
/// <param name="repository">The repository used by the list workflow.</param>
public abstract class GenericListFeature<TEntity, TEntityDto, TSearchModel, TRepository>(TRepository repository) :
	IListFeature<TEntityDto, TSearchModel>
	where TRepository : IListingRepository<TEntity, TSearchModel>
	where TSearchModel : SearchModel
{
	/// <summary>
	/// Gets the repository available to derived conversion implementations.
	/// </summary>
	protected TRepository Repository { get => repository; }
	/// <summary>
	/// Converts one repository entity to the DTO returned to callers.
	/// </summary>
	/// <param name="entity">The repository entity to convert.</param>
	/// <param name="cancellationToken">A token that can cancel the conversion.</param>
	/// <returns>The DTO representation of the entity.</returns>
	protected abstract Task<TEntityDto> ConvertToDto(TEntity entity, CancellationToken cancellationToken);
	/// <summary>
	/// Converts an entity page to a DTO page while preserving paging metadata.
	/// </summary>
	/// <param name="result">The entity page returned by the repository.</param>
	/// <param name="cancellationToken">A token that can cancel item conversion.</param>
	/// <returns>The converted DTO page.</returns>
	protected virtual Task<PagedResult<TEntityDto>> ConvertToPagedResultAsync(PagedResult<TEntity> result, CancellationToken cancellationToken)
		=> result.ConvertToAsync(ConvertToDto, cancellationToken);
	/// <summary>Loads a repository page and maps every entity to a DTO.</summary>
	/// <param name="searchModel">The filtering and paging values.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>A page of matching DTOs.</returns>
	public virtual async Task<PagedResult<TEntityDto>> ListAsync(TSearchModel searchModel, CancellationToken cancellationToken)
	{
		var result = await repository.ListAsync(searchModel, cancellationToken);

		return await ConvertToPagedResultAsync(result, cancellationToken);
	}
}
