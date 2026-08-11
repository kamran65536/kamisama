using Suma.AdminPanel.Services.Operators;
using KamiSama.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace Suma.AdminPanel.Client.Services.Operators;

[AutoInjectScoped<IFindOperatorById>]
public class FindOperatorByIdClientService(HttpClient httpClient) : IFindOperatorById
{
	public async Task<OperatorDto> FindByIdAsync(Guid operatorId, CancellationToken cancellationToken)
		=> await httpClient.GetFromJsonAsync<OperatorDto>($"api/operators/{operatorId}", cancellationToken)
		   ?? throw new InvalidOperationException("No response returned from operators endpoint.");
}
