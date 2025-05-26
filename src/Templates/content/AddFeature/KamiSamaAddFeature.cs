using KamiSama.Chassis.Commons.Features;

namespace KamiSama.Chassis.Features;

/// <summary>
/// Concrete Add Feature for {{AddRequest}}, {{Repository}}, {{Entity}}, {{EntityDto}}.
/// </summary>
public class KamiSamaAddFeature(

	{{Repository }} repository,
	IMapper mapper
) : GenericAddFeature <{ { AddRequest} }, { { Repository} }, { { Entity} }, { { EntityDto} }> (repository, mapper)
{
	// You can override the following virtual methods from GenericAddFeature if needed:

	// 1. CheckDuplicateAsync:
	//    Override this to implement domain-specific duplicate checks
	//    Example: ensure the entity does not already exist in the database
	//
	// protected override Task CheckDuplicateAsync({{AddRequest}} request, CancellationToken cancellationToken)
	// {
	//     // Custom duplicate logic here
	//     return Task.CompletedTask;
	// }

	// 2. ConvertToEntity:
	//    Override this if AutoMapper is not sufficient and you need custom mapping logic
	//
	// protected override Task<{{Entity}}> ConvertToEntity({{AddRequest}} request, CancellationToken cancellationToken)
	// {
	//     var entity = new {{Entity}} {
	//         // map fields manually
	//     };
	//     return Task.FromResult(entity);
	// }

	// 3. ConvertToDto:
	//    Override this to customize the response DTO returned from the AddAsync operation
	//
	// protected override Task<{{EntityDto}}> ConvertToDto({{Entity}} entity, CancellationToken cancellationToken)
	// {
	//     var dto = new {{EntityDto}} {
	//         // map fields manually
	//     };
	//     return Task.FromResult(dto);
	// }

	// 4. AddAsync:
	//    You usually don’t need to override this.
	//    Do so only if the entire add flow needs to be replaced.
}
