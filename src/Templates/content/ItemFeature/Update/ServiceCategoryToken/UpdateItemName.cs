using KamiSama.Chassis.Commons.Features;

namespace NamespaceToken.Services.ServiceCategoryToken;

public sealed record UpdateItemNameRequest;
public interface IUpdateItemName : IUpdateFeature<UpdateItemNameRequest, KeyTypeToken>;

internal sealed class UpdateItemName : IUpdateItemName
{
    public Task UpdateAsync(KeyTypeToken key, UpdateItemNameRequest dto, CancellationToken cancellationToken)
        => throw new NotImplementedException("TODO(ai): Load, validate, patch, and persist ItemName.");
}
