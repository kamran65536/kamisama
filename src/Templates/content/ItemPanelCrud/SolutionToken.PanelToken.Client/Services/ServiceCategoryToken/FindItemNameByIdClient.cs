using System.Net.Http.Json;

namespace SolutionToken.PanelToken.Services.ServiceCategoryToken;

internal sealed class FindItemNameByIdClient(HttpClient client) : IFindItemNameById
{
    public async Task<ItemNameDto> FindByIdAsync(KeyTypeToken id, CancellationToken cancellationToken)
        => (await client.GetFromJsonAsync<ItemNameDto>($"api/ServiceCategoryToken/{id}", cancellationToken))!;
}
