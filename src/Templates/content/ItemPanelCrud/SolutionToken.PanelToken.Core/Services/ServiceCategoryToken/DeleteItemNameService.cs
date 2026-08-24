using KamiSama.Extensions.DependencyInjection;

namespace SolutionToken.PanelToken.Services.ServiceCategoryToken;

[AutoInjectScoped<IDeleteItemName>]
internal sealed class DeleteItemNameService : IDeleteItemName
{
    public Task DeleteAsync(KeyTypeToken id, CancellationToken cancellationToken)
        => throw new NotImplementedException("TODO(ai): Enforce panel authorization and call the bounded-context delete operation.");
}
