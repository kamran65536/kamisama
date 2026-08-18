using KamiSama.Modules.Identity.DataTypes;
using KamiSama.Modules.Identity.Features.Users;

namespace Suma.AdminPanel.Services.Users;

[AutoInjectScoped<IListUsers>]
internal class ListUsers(
	ILogger<ListUsers> logger,
	KamiSama.Modules.Identity.Features.Users.IListUsers identityListUsers,
	IFindCurrentUser findCurrentUser) : IListUsers
{
	public async Task<PagedResult<UserListItemDto>> ListAsync(UserSearchModel searchModel, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();

		try
		{
			var currentUser = await findCurrentUser.GetCurrentUserAsync(cancellationToken);

			var usernameOrEmail = string.IsNullOrWhiteSpace(searchModel.Username)
				? searchModel.Email
				: searchModel.Username;
			var identitySearchModel = new KamiSama.Modules.Identity.Features.Users.UserSearchModel(
				searchModel.Page,
				searchModel.PageSize,
				KnownRoles.User,
				usernameOrEmail,
				searchModel.OrderBy);

			var result = await identityListUsers.ListAsync(identitySearchModel, cancellationToken);

			return new PagedResult<UserListItemDto>(
				result.TotalItemsCount,
				[.. result.Items.Select(x => x.ToUserListItemDto(currentUser.Id))]);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "Failed to list users.");
			throw;
		}
	}
}

