namespace SolutionToken.PanelToken.Services.ServiceCategoryToken;

internal sealed class DeleteItemNameClient(HttpClient client) : IDeleteItemName
{
    public async Task DeleteAsync(KeyTypeToken id, CancellationToken cancellationToken)
    {
        var response = await client.DeleteAsync($"api/ServiceCategoryToken/{id}", cancellationToken);
        response.EnsureSuccessStatusCode();
    }
}
