using Suma.AdminPanel.Services.Operators;
using KamiSama.Extensions.DependencyInjection;

namespace Suma.AdminPanel.Client.Services.Operators;

[AutoInjectScoped<IDisableOperator>]
public class DisableOperatorClientService(HttpClient httpClient) : IDisableOperator
{
	public async Task DisableAsync(Guid operatorId, CancellationToken cancellationToken)
	{
		var response = await httpClient.PostAsync($"api/operators/{operatorId}/disable", null, cancellationToken);
		response.EnsureSuccessStatusCode();
	}
}
