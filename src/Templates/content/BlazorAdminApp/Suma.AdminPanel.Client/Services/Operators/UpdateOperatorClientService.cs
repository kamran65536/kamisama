using Suma.AdminPanel.Services.Operators;
using KamiSama.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace Suma.AdminPanel.Client.Services.Operators;

[AutoInjectScoped<IUpdateOperator>]
public class UpdateOperatorClientService(HttpClient httpClient) : IUpdateOperator
{
	public async Task UpdateAsync(Guid operatorId, UpdateOperatorRequest request, CancellationToken cancellationToken)
	{
		var response = await httpClient.PutAsJsonAsync($"api/operators/{operatorId}", request, cancellationToken);
		response.EnsureSuccessStatusCode();
	}
}
