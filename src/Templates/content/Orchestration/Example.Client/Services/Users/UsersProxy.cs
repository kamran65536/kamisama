using Example.Abstractions;
using System.Net.Http.Json;

namespace Example.Client.Services.Users;

public sealed class UsersProxy(HttpClient http) : IListAdminUsers
{
    public async Task<IReadOnlyList<UserSummary>> ListAsync(CancellationToken cancellationToken = default)
        => await http.GetFromJsonAsync<UserSummary[]>("api/users", cancellationToken) ?? [];
}
