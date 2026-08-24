using KamiSama.Chassis.Commons.Features;

namespace NamespaceToken.Services.ServiceCategoryToken;

public sealed record AddItemNameRequest;
public sealed record ItemNameDto(KeyTypeToken Id);
public interface IAddItemName : IAddFeature<AddItemNameRequest, ItemNameDto>;

internal sealed class AddItemName : IAddItemName
{
    public Task<ItemNameDto> AddAsync(AddItemNameRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException("TODO(ai): Validate, map, and persist ItemName.");
}
