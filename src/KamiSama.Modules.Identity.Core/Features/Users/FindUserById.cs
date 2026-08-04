namespace KamiSama.Modules.Identity.Features.Users;

[AutoInjectScoped<IFindUserById>]
internal class FindUserById(IUserManager userManager) : IFindUserById
{
	public async Task<UserDto> FindByIdAsync(Guid id, CancellationToken cancellationToken)
	{
		var user = await userManager.FindByIdAsync(userManager.ConvertId(id), cancellationToken) ?? throw new NotFoundException<ApplicationUser>(id);
		var roles = await userManager.GetRolesAsync(user);

		return user.ToDto([.. roles]);
	}
}
