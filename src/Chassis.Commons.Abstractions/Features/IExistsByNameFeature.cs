namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Exists by name feature
/// </summary>
public interface IExistsByNameFeature
{
	/// <summary>
	/// checks if entity exists or not
	/// </summary>
	/// <returns></returns>
	Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken);
}
