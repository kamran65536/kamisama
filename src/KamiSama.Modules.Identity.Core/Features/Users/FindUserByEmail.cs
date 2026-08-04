namespace KamiSama.Modules.Identity.Features.Users;

[AutoInjectScoped<IFindUserByEmail>]
internal class FindUserByEmail(IUserManager userManager) : IFindUserByEmail
{
	public async Task<UserDto> FindByEmailAsync(string username, CancellationToken cancellationToken)
	{
		var user = await userManager.FindByEmailAsync(username) ?? throw new NotFoundException<ApplicationUser>(username);
		var roles = await userManager.GetRolesAsync(user);

		return user.ToDto([.. roles]);
	}
}