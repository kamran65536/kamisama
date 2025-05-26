using KamiSama.Chassis.Commons.Features;

namespace KamiSama.Chassis.Features;

/// <summary>
/// Concrete ExistsById Feature for {{Entity}}, {{Repository}}, {{KeyType}}.
/// </summary>
public class KamiSamaExistsByIdFeature(

	{{Repository }} repository
) : GenericExistsByIdFeature <{ { Entity} }, { { Repository} }, { { KeyType} }> (repository)
{
	// You can override the following method from GenericExistsByIdFeature if needed:

	// 1. ExistsByIdAsync:
	//    Override this to implement custom logic for existence checks.
	//    For example: include additional filtering, security checks, or soft-delete validation.
	//
	// public override Task<bool> ExistsByIdAsync({{KeyType}} id, CancellationToken cancellationToken)
	// {
	//     // Custom existence check
	//     return base.ExistsByIdAsync(id, cancellationToken);
	// }
}
