using KamiSama.Extensions.DependencyInjection;

namespace SolutionToken.PanelToken.Services.ServiceCategoryToken;

[AutoInjectScoped<IUpdateItemName>]
internal sealed class UpdateItemNameService : IUpdateItemName
{
    public Task UpdateAsync(KeyTypeToken key, UpdateItemNameRequest dto, CancellationToken cancellationToken)
        => throw new NotImplementedException("TODO(ai): Map and call the bounded-context update operation.");
}
