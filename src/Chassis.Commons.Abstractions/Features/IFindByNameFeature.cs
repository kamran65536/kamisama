namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Defines a query that returns one entity DTO by name.
/// </summary>
/// <typeparam name="TEntityDto">The DTO returned by the query.</typeparam>
public interface IFindByNameFeature<TEntityDto>
{
	/// <summary>
	/// Finds an entity by name and returns its <typeparamref name="TEntityDto"/> representation.
	/// </summary>
	/// <param name="name">The entity name to find.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>The DTO for the matching entity.</returns>
	Task<TEntityDto> FindByNameAsync(string name, CancellationToken cancellationToken);
}
