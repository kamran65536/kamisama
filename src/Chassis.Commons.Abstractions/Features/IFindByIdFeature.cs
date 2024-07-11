namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Find by Id feature
/// </summary>
public interface IFindByIdFeature<TEntityDto, TKey>
{
	/// <summary>
	/// Finds an <typeparamref name="TEntityDto"/> by it's id
	/// </summary>
	/// <returns></returns>
	Task<TEntityDto> FindByIdAsync(TKey id, CancellationToken cancellationToken);
}