namespace KamiSama.Chassis.Commons.Features;
/// <summary>
/// Defines a use case that deletes an entity identified by a key.
/// </summary>
/// <typeparam name="TKey">The entity key type.</typeparam>
public interface IDeleteFeature<TKey>
{
	/// <summary>
	/// Deletes the entity identified by the supplied key.
	/// </summary>
	/// <param name="key">The key of the entity to delete.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>A task that represents the asynchronous deletion.</returns>
	Task DeleteAsync(TKey key, CancellationToken cancellationToken);
}
