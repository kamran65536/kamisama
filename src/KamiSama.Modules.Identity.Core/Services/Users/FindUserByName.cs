namespace KamiSama.Modules.Identity.Services.Users;

[AutoInjectScoped<IFindUserByName>]
internal class FindUserByName(IUserManager userManager) : IFindUserByName
{
	public async Task<UserDto> FindByNameAsync(string username, CancellationToken cancellationToken)
	{
		var user = await userManager.FindByNameAsync(username) ?? throw new NotFoundException<ApplicationUser>(username);
		var roles = await userManager.GetRolesAsync(user);

		return user.ToDto([.. roles]);
	}
}