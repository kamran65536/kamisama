using KamiSama.Extensions.DependencyInjection;
using KamiSama.Extensions.Paging;

namespace SolutionToken.PanelToken.Services.ServiceCategoryToken;

[AutoInjectScoped<IListItemNames>]
internal sealed class ListItemNamesService : IListItemNames
{
    public Task<PagedResult<ItemNameListItemDto>> ListAsync(ItemNameSearchModel searchModel, CancellationToken cancellationToken)
        => throw new NotImplementedException("TODO(ai): Map search, call the bounded-context list operation, and map the page.");
}
