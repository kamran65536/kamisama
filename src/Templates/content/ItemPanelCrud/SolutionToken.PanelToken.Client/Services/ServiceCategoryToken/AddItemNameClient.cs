using System.Net.Http.Json;

namespace SolutionToken.PanelToken.Services.ServiceCategoryToken;

internal sealed class AddItemNameClient(HttpClient client) : IAddItemName
{
    public async Task<ItemNameDto> AddAsync(AddItemNameRequest request, CancellationToken cancellationToken)
    {
        var response = await client.PostAsJsonAsync("api/ServiceCategoryToken", request, cancellationToken);
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<ItemNameDto>(cancellationToken))!;
    }
}
