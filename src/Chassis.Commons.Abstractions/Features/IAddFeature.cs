namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Adds an entity from a request
/// </summary>
public interface IAddFeature<TAddRequest>
{
	/// <summary>
	/// Adds the entity
	/// </summary>
	Task AddAsync(TAddRequest request, CancellationToken cancellationToken);
}
