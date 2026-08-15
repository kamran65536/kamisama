namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Implements an entity-name existence feature by delegating to a repository.
/// </summary>
/// <typeparam name="TEntity">The entity type checked by the repository.</typeparam>
/// <typeparam name="TRepository">The repository type that supports name lookup.</typeparam>
/// <param name="repository">The repository used for existence checks.</param>
public abstract class GenericExistsByNameFeature<TEntity, TRepository>(TRepository repository) :
	IExistsByNameFeature
	where TRepository : ILookupByNameRepository<TEntity>
{
	/// <summary>
	/// Gets the repository available to derived implementations.
	/// </summary>
	protected TRepository Repository { get => repository; }
	/// <summary>
	/// Determines whether an entity with the supplied name exists.
	/// </summary>
	/// <param name="name">The name to test.</param>
	/// <param name="cancellationToken">A token that can cancel the repository operation.</param>
	/// <returns><see langword="true"/> when an entity exists; otherwise, <see langword="false"/>.</returns>
	public virtual Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken)
		=> repository.ExistsByNameAsync(name, cancellationToken);
}
