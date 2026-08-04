using KamiSama.Chassis.Commons.Features;
using KamiSama.Extensions.Paging;

namespace KamiSama.Modules.Identity.Features.Users;

[AutoInjectScoped<IListUsers>]
internal class ListUsers(IApplicationUserRepository repository, IUserManager userManager) :
	GenericListFeature<ApplicationUser, UserDto, UserSearchModel, IApplicationUserRepository>(repository),
	IListUsers
{
	/// <summary>
	/// This method is overridden as concurrent access to <see cref="IUserManager.GetRolesAsync(ApplicationUser)" /> is not possible
	/// </summary>
	/// <param name="result"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	protected override async Task<PagedResult<UserDto>> ConvertToPagedResultAsync(PagedResult<ApplicationUser> result, CancellationToken cancellationToken)
	{
		var items = new List<UserDto>(result.Items.Count);

		for (int i = 0; i < result.Items.Count; i++)
		{
			var user = result.Items[i];
			var roles = await userManager.GetRolesAsync(user).ConfigureAwait(true);

			items.Add(user.ToDto([..roles]));
		}

		return new PagedResult<UserDto>(result.TotalItemsCount, items);
	}

	protected override Task<UserDto> ConvertToDto(ApplicationUser entity, CancellationToken cancellationToken)
	{
		//this method is not used in this implementation
		throw new NotImplementedException();
	}
}
