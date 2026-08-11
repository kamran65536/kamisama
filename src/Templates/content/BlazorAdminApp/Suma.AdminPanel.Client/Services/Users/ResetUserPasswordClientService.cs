using Suma.AdminPanel.Services.Users;
using KamiSama.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace Suma.AdminPanel.Client.Services.Users;

[AutoInjectScoped<IResetUserPassword>]
public class ResetUserPasswordClientService(HttpClient httpClient) : IResetUserPassword
{
	public async Task ResetPasswordAsync(ResetUserPasswordRequest request, CancellationToken cancellationToken)
	{
		var response = await httpClient.PostAsJsonAsync("api/users/reset-password", request, cancellationToken);
		response.EnsureSuccessStatusCode();
	}
}

