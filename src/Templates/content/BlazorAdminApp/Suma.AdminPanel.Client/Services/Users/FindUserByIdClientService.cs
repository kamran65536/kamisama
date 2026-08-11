using Suma.AdminPanel.Services.Users;
using KamiSama.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace Suma.AdminPanel.Client.Services.Users;

[AutoInjectScoped<IFindUserById>]
public class FindUserByIdClientService(HttpClient httpClient) : IFindUserById
{
	public async Task<UserDto> FindByIdAsync(Guid userId, CancellationToken cancellationToken)
		=> await httpClient.GetFromJsonAsync<UserDto>($"api/users/{userId}", cancellationToken)
		   ?? throw new InvalidOperationException("No response returned from users endpoint.");
}

