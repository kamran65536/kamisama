namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Adds an entity from a request
/// </summary>
public interface IAddFeature<TAddRequest, TEntityDto>
{
	/// <summary>
	/// Adds the entity
	/// </summary>
	Task<TEntityDto> AddAsync(TAddRequest request, CancellationToken cancellationToken);
}
