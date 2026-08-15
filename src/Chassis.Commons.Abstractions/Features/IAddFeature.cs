namespace KamiSama.Chassis.Commons.Features;

/// <summary>
/// Defines a create use case that accepts a request and returns the created entity DTO.
/// </summary>
/// <typeparam name="TAddRequest">The request type containing values for the new entity.</typeparam>
/// <typeparam name="TEntityDto">The DTO returned after creation.</typeparam>
public interface IAddFeature<TAddRequest, TEntityDto>
{
	/// <summary>
	/// Creates an entity from the request and returns its DTO representation.
	/// </summary>
	/// <param name="request">The values used to create the entity.</param>
	/// <param name="cancellationToken">A token that can cancel the operation.</param>
	/// <returns>The DTO produced for the created entity.</returns>
	Task<TEntityDto> AddAsync(TAddRequest request, CancellationToken cancellationToken);
}
