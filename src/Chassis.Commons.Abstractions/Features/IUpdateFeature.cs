namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Updates an entity from the database
/// </summary>
public interface IUpdateFeature<TEntityDto, TKey>
{
	/// <summary>
	/// Updates the entity
	/// </summary>
	Task UpdateAsync(TKey key, TEntityDto dto, CancellationToken cancellationToken);
}
