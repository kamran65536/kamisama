namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Lists the items feature
/// </summary>
public interface IListFeature<TEntityDto, TSearchModel, TPageResult>
	where TSearchModel : SearchModel
	where TPageResult : PagedResult<TEntityDto>
{
	/// <summary>
	/// Lists items and page thm
	/// </summary>
	/// <param name="searchModel"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<TPageResult> ListAsync(TSearchModel searchModel, CancellationToken cancellationToken);
}
/// <summary>
/// Lists the items feature
/// </summary>
public interface IListFeature<TEntityDto, TSearchModel> : IListFeature<TEntityDto, TSearchModel, PagedResult<TEntityDto>>
	where TSearchModel : SearchModel
{
}
