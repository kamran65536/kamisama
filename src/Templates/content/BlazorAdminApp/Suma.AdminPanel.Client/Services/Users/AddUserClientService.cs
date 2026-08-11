using Suma.AdminPanel.Services.Users;
using KamiSama.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace Suma.AdminPanel.Client.Services.Users;

[AutoInjectScoped<IAddUser>]
public class AddUserClientService(HttpClient httpClient) : IAddUser
{
	public async Task AddAsync(AddUserRequest request, CancellationToken cancellationToken)
	{
		var response = await httpClient.PostAsJsonAsync("api/users", request, cancellationToken);
		response.EnsureSuccessStatusCode();
	}
}

