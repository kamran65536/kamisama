namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Generic Exists by Id Feature Implementation
/// </summary>
public abstract class GenericExistsByNameFeature<TEntity, TRepository>(TRepository repository) :
	IExistsByNameFeature
	where TRepository : ILookupByNameRepository<TEntity>
{
	/// <summary>
	/// Repository field to be used
	/// </summary>
	protected TRepository Repository { get => repository; }
	/// <summary>
	/// returns true if entity by such id exists
	/// </summary>
	public virtual Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken)
		=> repository.ExistsByNameAsync(name, cancellationToken);
}
