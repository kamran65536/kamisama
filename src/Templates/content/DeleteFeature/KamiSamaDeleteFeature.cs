using KamiSama.Chassis.Commons.Features;

namespace KamiSama.Chassis.Features;

/// <summary>
/// Concrete Delete Feature for {{Entity}}, {{Repository}}, {{KeyType}}.
/// </summary>
public class KamiSamaDeleteFeature(
    {{Repository}} repository
) : GenericDeleteFeature<{{Entity}}, {{Repository}}, {{KeyType}}>(repository)
{
    // You can override the following virtual method from GenericDeleteFeature if needed:

    // 1. CanBeDeletedAsync:
    //    Override this to add logic for whether an entity is allowed to be deleted.
    //    For example: prevent deletion if the entity is in use or in a locked state.
    //
    // protected override Task<bool> CanBeDeletedAsync({{Repository}} repository, {{Entity}} entity)
    // {
    //     // Custom rule
    //     return Task.FromResult(true);
    // }

    // 2. DeleteAsync:
    //    You typically do not override this unless the deletion workflow needs full customization.
}