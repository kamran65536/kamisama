using Suma.AdminPanel.Services.Users;
using KamiSama.Extensions.DependencyInjection;

namespace Suma.AdminPanel.Client.Services.Users;

[AutoInjectScoped<IDisableUser>]
public class DisableUserClientService(HttpClient httpClient) : IDisableUser
{
	public async Task DisableAsync(Guid userId, CancellationToken cancellationToken)
	{
		var response = await httpClient.PostAsync($"api/users/{userId}/disable", null, cancellationToken);
		response.EnsureSuccessStatusCode();
	}
}

