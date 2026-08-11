namespace KamiSama.Modules.Identity.Services.Users;

[AutoInjectScoped<IDeleteUser>]
internal class DeleteUser(IUserManager  userManager) : IDeleteUser
{
	public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
	{
		var user = await userManager.FindByIdAsync(userManager.ConvertId(id), cancellationToken) ?? throw new NotFoundException<ApplicationUser>(id);

		await userManager.DeleteAsync(user);
	}
}
