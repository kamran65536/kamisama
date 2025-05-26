using KamiSama.Chassis.Commons.Features;

namespace KamiSama.Chassis.Features;

/// <summary>
/// Concrete ExistsByName Feature for {{Entity}}, {{Repository}}.
/// </summary>
public class KamiSamaExistsByNameFeature(

	{{Repository }} repository
) : GenericExistsByNameFeature <{ { Entity} }, { { Repository} }> (repository)
{
	// You can override the following if needed:

	// public override Task<bool> ExistsByNameAsync(string name, CancellationToken cancellationToken)
	// {
	//     // Add filtering, normalization, or special logic here
	//     return base.ExistsByNameAsync(name, cancellationToken);
	// }
}
