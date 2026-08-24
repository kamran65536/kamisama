using KamiSama.Chassis.Commons.Features;

namespace NamespaceToken.Services.ServiceCategoryToken;

public interface IDeleteItemName : IDeleteFeature<KeyTypeToken>;

internal sealed class DeleteItemName : IDeleteItemName
{
    public Task DeleteAsync(KeyTypeToken id, CancellationToken cancellationToken)
        => throw new NotImplementedException("TODO(ai): Enforce deletion rules and delete ItemName.");
}
