namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Lists the items feature
/// </summary>
/// <typeparam name="TEntityDto"></typeparam>
/// <typeparam name="TSearchModel"></typeparam>
public interface IListFeature<TEntityDto, TSearchModel>
	where TSearchModel : SearchModel
{
	/// <summary>
	/// Lists items and page thm
	/// </summary>
	/// <param name="searchModel"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<PagedResult<TEntityDto>> ListAsync(TSearchModel searchModel, CancellationToken cancellationToken);
}
