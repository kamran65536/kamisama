using Suma.AdminPanel.Services.Accounts;
using KamiSama.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace Suma.AdminPanel.Client.Services.Accounts;

[AutoInjectScoped<IChangePassword>]
public class ChangePasswordClientService(HttpClient httpClient) : IChangePassword
{
	public async Task ChangeAsync(ChangePasswordRequest request, CancellationToken cancellationToken)
	{
		var response = await httpClient.PostAsJsonAsync("api/accounts/change-password", request, cancellationToken);
		response.EnsureSuccessStatusCode();
	}
}
