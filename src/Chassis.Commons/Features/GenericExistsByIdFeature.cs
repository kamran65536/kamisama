
namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Generic Exists by Id Feature Implementation
/// </summary>
public abstract class GenericExistsByIdFeature<TEntity, TRepository, TKey>(TRepository repository) :
	IExistsByIdFeature<TKey>
	where TRepository : ILookupByIdRepository<TEntity, TKey>
{
	/// <summary>
	/// returns true if entity by such id exists
	/// </summary>
	/// <param name="id"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public virtual Task<bool> ExistsByIdAsync(TKey id, CancellationToken cancellationToken)
		=> repository.ExistsByIdAsync(id, cancellationToken);
}
