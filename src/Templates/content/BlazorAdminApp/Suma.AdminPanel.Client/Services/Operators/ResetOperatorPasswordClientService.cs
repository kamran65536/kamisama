using Suma.AdminPanel.Services.Operators;
using KamiSama.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace Suma.AdminPanel.Client.Services.Operators;

[AutoInjectScoped<IResetOperatorPassword>]
public class ResetOperatorPasswordClientService(HttpClient httpClient) : IResetOperatorPassword
{
	public async Task ResetPasswordAsync(ResetOperatorPasswordRequest request, CancellationToken cancellationToken)
	{
		var response = await httpClient.PostAsJsonAsync("api/operators/reset-password", request, cancellationToken);
		response.EnsureSuccessStatusCode();
	}
}
