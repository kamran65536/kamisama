using Suma.AdminPanel.Services.Operators;
using KamiSama.Extensions.DependencyInjection;

namespace Suma.AdminPanel.Client.Services.Operators;

[AutoInjectScoped<IEnableOperator>]
public class EnableOperatorClientService(HttpClient httpClient) : IEnableOperator
{
	public async Task EnableAsync(Guid operatorId, CancellationToken cancellationToken)
	{
		var response = await httpClient.PostAsync($"api/operators/{operatorId}/enable", null, cancellationToken);
		response.EnsureSuccessStatusCode();
	}
}
