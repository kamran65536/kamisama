using Suma.AdminPanel.Services.Users;
using KamiSama.Extensions.Paging;
using KamiSama.Extensions.DependencyInjection;
using KamiSama.Modules.Commons.RestSharp;

namespace Suma.AdminPanel.Client.Services.Users;

[AutoInjectScoped<IListUsers>]
public class ListUsersClientService(IRestBuilder restBuilder) : IListUsers
{
	public Task<PagedResult<UserListItemDto>> ListAsync(UserSearchModel searchModel, CancellationToken cancellationToken)
		=> restBuilder
			.ForServiceUrl("api/users", "")
			.AddQueryParameter(searchModel)
			.GetAsync<PagedResult<UserListItemDto>>(cancellationToken);
}

