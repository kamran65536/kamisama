namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Find by Id feature
/// </summary>
public interface IFindByNameFeature<TEntityDto>
{
	/// <summary>
	/// Finds an <typeparamref name="TEntityDto"/> by it's name
	/// </summary>
	/// <returns></returns>
	Task<TEntityDto> FindByNameAsync(string name, CancellationToken cancellationToken);
}