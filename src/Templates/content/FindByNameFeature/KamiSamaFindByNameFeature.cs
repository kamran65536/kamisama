using KamiSama.Chassis.Commons.Features;

namespace KamiSama.Chassis.Features;

/// <summary>
/// Concrete FindByName Feature for {{Entity}}, {{EntityDto}}, {{Repository}}.
/// </summary>
public class KamiSamaFindByNameFeature(

	{{Repository }} repository,
	IMapper mapper
) : GenericFindByNameFeature <{ { Entity} }, { { EntityDto} }, { { Repository} }> (repository, mapper)
{
	// You can override FindByNameAsync if you want to customize error handling, normalization, etc.

	// public override Task<{{EntityDto}}> FindByNameAsync(string name, CancellationToken cancellationToken)
	// {
	//     // Custom lookup logic
	//     return base.FindByNameAsync(name, cancellationToken);
	// }
}
