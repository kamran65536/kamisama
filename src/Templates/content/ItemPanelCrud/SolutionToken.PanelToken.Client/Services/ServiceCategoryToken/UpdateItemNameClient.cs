using System.Net.Http.Json;

namespace SolutionToken.PanelToken.Services.ServiceCategoryToken;

internal sealed class UpdateItemNameClient(HttpClient client) : IUpdateItemName
{
    public async Task UpdateAsync(KeyTypeToken key, UpdateItemNameRequest dto, CancellationToken cancellationToken)
    {
        var response = await client.PutAsJsonAsync($"api/ServiceCategoryToken/{key}", dto, cancellationToken);
        response.EnsureSuccessStatusCode();
    }
}
