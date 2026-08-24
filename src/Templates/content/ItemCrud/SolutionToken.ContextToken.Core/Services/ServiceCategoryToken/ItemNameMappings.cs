using SolutionToken.ContextToken.Services.ServiceCategoryToken;

namespace SolutionToken.ContextToken;

internal static class ItemNameMappings
{
    public static ItemName ToEntity(this AddItemNameRequest request)
        => new(); // TODO(ai): Map editable fields.

    public static ItemNameDto ToDto(this ItemName entity)
        => new(entity.Id); // TODO(ai): Map DTO fields.

    public static void Patch(this ItemName entity, UpdateItemNameRequest request)
    {
        // TODO(ai): Patch editable fields only.
    }
}
