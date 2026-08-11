namespace KamiSama.Modules.Identity.Services.AccountSecurity;

[AutoInjectScoped<ISetTwoFactorAuthenticationEnabled>]
internal class SetTwoFactorAuthenticationEnabled(IUserManager userManager) : ISetTwoFactorAuthenticationEnabled
{
	public async Task SetAsync(Guid userId, bool isEnabled, CancellationToken cancellationToken)
	{
		var user = await userManager.FindByIdAsync(userManager.ConvertId(userId), cancellationToken)
			?? throw new NotFoundException<ApplicationUser>(userId, nameof(userId));

		await userManager.SetTwoFactoryEnabledAsync(user, isEnabled);
	}
}
