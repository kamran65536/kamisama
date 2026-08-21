using Example.Abstractions;
using KamiSama.Extensions.DependencyInjection;
using KamiSama.Modules.Identity.Services.Users;

namespace Example.Core.Users;

[AutoInjectScoped<IListAdminUsers>]
public sealed class UserService(IListUsers users) : IListAdminUsers
{
    public async Task<IReadOnlyList<UserSummary>> ListAsync(CancellationToken cancellationToken = default)
    {
        var result = await users.ListAsync(new UserSearchModel(1, 100, null, null, null), cancellationToken);
        return result.Items.Select(user => new UserSummary(user.Id, user.Username)).ToArray();
    }
}
