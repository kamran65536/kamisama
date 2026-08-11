using Suma.AdminPanel.Services.Users;
using KamiSama.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace Suma.AdminPanel.Client.Services.Users;

[AutoInjectScoped<IUpdateUser>]
public class UpdateUserClientService(HttpClient httpClient) : IUpdateUser
{
	public async Task UpdateAsync(Guid userId, UpdateUserRequest request, CancellationToken cancellationToken)
	{
		var response = await httpClient.PutAsJsonAsync($"api/users/{userId}", request, cancellationToken);
		response.EnsureSuccessStatusCode();
	}
}

