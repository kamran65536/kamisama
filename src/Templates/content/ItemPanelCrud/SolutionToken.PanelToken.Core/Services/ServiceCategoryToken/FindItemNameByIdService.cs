using KamiSama.Extensions.DependencyInjection;

namespace SolutionToken.PanelToken.Services.ServiceCategoryToken;

[AutoInjectScoped<IFindItemNameById>]
internal sealed class FindItemNameByIdService : IFindItemNameById
{
    public Task<ItemNameDto> FindByIdAsync(KeyTypeToken id, CancellationToken cancellationToken)
        => throw new NotImplementedException("TODO(ai): Call the bounded-context query and map its DTO.");
}
