namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Defines an existence check for an entity identifier.
/// </summary>
/// <typeparam name="TKey">The entity identifier type.</typeparam>
public interface IExistsByIdFeature<TKey>
{
	/// <summary>
	/// Determines whether an entity with the supplied identifier exists.
	/// </summary>
	/// <param name="id">The identifier to test.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns><see langword="true"/> when the entity exists; otherwise, <see langword="false"/>.</returns>
	Task<bool> ExistsByIdAsync(TKey id, CancellationToken cancellationToken);
}
