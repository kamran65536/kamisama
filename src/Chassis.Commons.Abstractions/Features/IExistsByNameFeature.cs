namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Defines an existence check for an entity name.
/// </summary>
public interface IExistsByNameFeature
{
	/// <summary>
	/// Determines whether an entity with the supplied name exists.
	/// </summary>
	/// <param name="name">The name to test.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns><see langword="true"/> when the entity exists; otherwise, <see langword="false"/>.</returns>
	Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken);
}
