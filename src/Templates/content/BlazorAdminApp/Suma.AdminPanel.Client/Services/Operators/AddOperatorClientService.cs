using Suma.AdminPanel.Services.Operators;
using KamiSama.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace Suma.AdminPanel.Client.Services.Operators;

[AutoInjectScoped<IAddOperator>]
public class AddOperatorClientService(HttpClient httpClient) : IAddOperator
{
	public async Task AddAsync(AddOperatorRequest request, CancellationToken cancellationToken)
	{
		var response = await httpClient.PostAsJsonAsync("api/operators", request, cancellationToken);
		response.EnsureSuccessStatusCode();
	}
}
