namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Exists by id feature
/// </summary>
public interface IExistsByIdFeature<TKey>
{
	/// <summary>
	/// checks if entity exists or not
	/// </summary>
	/// <param name="id"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<bool> ExistsByIdAsync(TKey id, CancellationToken cancellationToken);
}
