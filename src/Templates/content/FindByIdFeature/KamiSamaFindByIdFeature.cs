using KamiSama.Chassis.Commons.Features;

namespace KamiSama.Chassis.Features;

/// <summary>
/// Concrete FindById Feature for {{Entity}}, {{EntityDto}}, {{Repository}}, {{KeyType}}.
/// </summary>
public class KamiSamaFindByIdFeature(

	{{Repository }} repository,
	IMapper mapper
) : GenericFindByIdFeature <{ { Entity} }, { { EntityDto} }, { { Repository} }, { { KeyType} }> (repository, mapper)
{
	// You can override ConvertToDto if you need custom mapping logic.

	// protected override {{EntityDto}} ConvertToDto({{Entity}} entity)
	// {
	//     // Custom mapping
	//     return new {{EntityDto}} { /* ... */ };
	// }

	// You typically don’t override FindByIdAsync unless the entire workflow needs customization.
}
