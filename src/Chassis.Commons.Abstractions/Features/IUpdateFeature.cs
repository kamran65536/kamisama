namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Defines an update use case for an entity identified by a key.
/// </summary>
/// <typeparam name="TEntityDto">The request or DTO type containing updated values.</typeparam>
/// <typeparam name="TKey">The entity key type.</typeparam>
public interface IUpdateFeature<TEntityDto, TKey>
{
	/// <summary>
	/// Applies the supplied values to the entity identified by the key.
	/// </summary>
	/// <param name="key">The key of the entity to update.</param>
	/// <param name="dto">The values to apply.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>A task that represents the asynchronous update.</returns>
	Task UpdateAsync(TKey key, TEntityDto dto, CancellationToken cancellationToken);
}
