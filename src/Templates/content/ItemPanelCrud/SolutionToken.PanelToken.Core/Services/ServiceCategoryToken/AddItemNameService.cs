using KamiSama.Extensions.DependencyInjection;

namespace SolutionToken.PanelToken.Services.ServiceCategoryToken;

[AutoInjectScoped<IAddItemName>]
internal sealed class AddItemNameService : IAddItemName
{
    public Task<ItemNameDto> AddAsync(AddItemNameRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException("TODO(ai): Call the bounded-context add operation and map its DTO.");
}
