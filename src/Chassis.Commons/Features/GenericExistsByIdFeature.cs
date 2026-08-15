
namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Implements an entity-identifier existence feature by delegating to a repository.
/// </summary>
/// <typeparam name="TEntity">The entity type checked by the repository.</typeparam>
/// <typeparam name="TRepository">The repository type that supports identifier lookup.</typeparam>
/// <typeparam name="TKey">The entity identifier type.</typeparam>
/// <param name="repository">The repository used for existence checks.</param>
public abstract class GenericExistsByIdFeature<TEntity, TRepository, TKey>(TRepository repository) :
	IExistsByIdFeature<TKey>
	where TRepository : ILookupByIdRepository<TEntity, TKey>
{
	/// <summary>
	/// Gets the repository available to derived implementations.
	/// </summary>
	protected TRepository Repository { get => repository; }
	/// <summary>
	/// Determines whether an entity with the supplied identifier exists.
	/// </summary>
	/// <param name="id">The identifier to test.</param>
	/// <param name="cancellationToken">A token that can cancel the repository operation.</param>
	/// <returns><see langword="true"/> when an entity exists; otherwise, <see langword="false"/>.</returns>
	public virtual Task<bool> ExistsByIdAsync(TKey id, CancellationToken cancellationToken)
		=> repository.ExistsByIdAsync(id, cancellationToken);
}
