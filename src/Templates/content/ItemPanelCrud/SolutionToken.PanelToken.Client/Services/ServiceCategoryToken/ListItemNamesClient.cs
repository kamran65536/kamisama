using System.Net.Http.Json;
using KamiSama.Extensions.Paging;

namespace SolutionToken.PanelToken.Services.ServiceCategoryToken;

internal sealed class ListItemNamesClient(HttpClient client) : IListItemNames
{
    public async Task<PagedResult<ItemNameListItemDto>> ListAsync(ItemNameSearchModel searchModel, CancellationToken cancellationToken)
    {
        // TODO(ai): Serialize all search and ordering fields into the query string.
        var url = $"api/ServiceCategoryToken?page={searchModel.Page}&pageSize={searchModel.PageSize}";
        return (await client.GetFromJsonAsync<PagedResult<ItemNameListItemDto>>(url, cancellationToken))!;
    }
}
