using KamiSama.Chassis.Commons.Features;

namespace KamiSama.Chassis.Features;

/// <summary>
/// Concrete List Feature for {{Entity}}, {{EntityDto}}, {{SearchModel}}, {{Repository}}.
/// </summary>
public class KamiSamaListFeature(
    {{Repository}} repository,
    IMapper mapper
) : GenericListFeature<{{Entity}}, {{EntityDto}}, {{SearchModel}}, {{Repository}}>(repository, mapper)
{
    // You can override the following virtual methods from GenericListFeature if needed:

    // 1. ConvertToDto:
    //    Override this to customize how the entity is mapped to the DTO.
    //
    // protected override {{EntityDto}} ConvertToDto({{Entity}} entity)
    // {
    //     // Manual mapping logic
    //     return new {{EntityDto}} { /* ... */ };
    // }

    // 2. ListAsync:
    //    You typically do not need to override this unless the listing flow needs to be customized.
}