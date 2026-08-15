namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Defines a query that returns one entity DTO by identifier.
/// </summary>
/// <typeparam name="TEntityDto">The DTO returned by the query.</typeparam>
/// <typeparam name="TKey">The entity identifier type.</typeparam>
public interface IFindByIdFeature<TEntityDto, TKey>
{
	/// <summary>
	/// Finds an entity by identifier and returns its <typeparamref name="TEntityDto"/> representation.
	/// </summary>
	/// <param name="id">The identifier to find.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>The DTO for the matching entity.</returns>
	Task<TEntityDto> FindByIdAsync(TKey id, CancellationToken cancellationToken);
}
