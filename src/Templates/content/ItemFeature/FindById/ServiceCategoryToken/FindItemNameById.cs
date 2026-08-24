using KamiSama.Chassis.Commons.Features;

namespace NamespaceToken.Services.ServiceCategoryToken;

public sealed record ItemNameDto(KeyTypeToken Id);
public interface IFindItemNameById : IFindByIdFeature<ItemNameDto, KeyTypeToken>;

internal sealed class FindItemNameById : IFindItemNameById
{
    public Task<ItemNameDto> FindByIdAsync(KeyTypeToken id, CancellationToken cancellationToken)
        => throw new NotImplementedException("TODO(ai): Load and map ItemName.");
}
