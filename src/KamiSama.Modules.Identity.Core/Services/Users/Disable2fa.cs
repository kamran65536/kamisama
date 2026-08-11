namespace KamiSama.Modules.Identity.Services.Users;

[AutoInjectScoped<IDisable2fa>]
internal class Disable2fa(IUserManager userManager) : IDisable2fa
{
	public async Task DisableAsync(Guid userId, CancellationToken cancellationToken)
	{
		var user = (await userManager.FindByIdAsync(userManager.ConvertId(userId), cancellationToken)) ?? throw new NotFoundException<ApplicationUser>(userId, nameof(userId));

		await userManager.SetTwoFactoryEnabledAsync(user, false);
	}
}
