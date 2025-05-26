using KamiSama.Chassis.Commons.Features;

namespace KamiSama.Chassis.Features;

/// <summary>
/// Concrete Update Feature for {{UpdateRequest}}, {{Repository}}, {{Entity}}, {{KeyType}}.
/// </summary>
public class KamiSamaUpdateFeature(

	{{Repository }} repository,
	IMapper mapper
) : GenericUpdateFeature <{ { UpdateRequest} }, { { Entity} }, { { Repository} }, { { KeyType} }> (repository, mapper)
{
	// You can override the following virtual methods from GenericUpdateFeature if needed:

	// 1. CheckDuplicateAsync:
	//    Override this to validate that the updated data does not introduce duplicates.
	//    For example: check if another entity already has the updated value (e.g., name, email).
	//
	// protected override Task CheckDuplicateAsync({{KeyType}} id, {{UpdateRequest}} request, CancellationToken cancellationToken)
	// {
	//     // Custom duplicate check
	//     return Task.CompletedTask;
	// }

	// 2. PatchEntityAsync:
	//    Override this to manually map the fields from the request to the entity if AutoMapper is insufficient.
	//
	// protected override Task PatchEntityAsync({{Entity}} entity, {{UpdateRequest}} request, CancellationToken cancellationToken)
	// {
	//     // Custom patch logic
	//     return Task.CompletedTask;
	// }

	// 3. UpdateAsync:
	//    You typically do not need to override this unless the whole update workflow needs customization.
}
