namespace KamiSama.Chassis.Commons.Features;
/// <summary>
/// Deletes an entity by key feature
/// </summary>
/// <typeparam name="TKey"></typeparam>
public interface IDeleteFeature<TKey>
{
	/// <summary>
	/// deletes the entity
	/// </summary>
	Task DeleteAsync(TKey key, CancellationToken cancellationToken);
}