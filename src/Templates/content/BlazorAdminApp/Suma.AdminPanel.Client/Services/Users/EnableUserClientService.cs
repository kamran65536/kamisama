using Suma.AdminPanel.Services.Users;
using KamiSama.Extensions.DependencyInjection;

namespace Suma.AdminPanel.Client.Services.Users;

[AutoInjectScoped<IEnableUser>]
public class EnableUserClientService(HttpClient httpClient) : IEnableUser
{
	public async Task EnableAsync(Guid userId, CancellationToken cancellationToken)
	{
		var response = await httpClient.PostAsync($"api/users/{userId}/enable", null, cancellationToken);
		response.EnsureSuccessStatusCode();
	}
}

