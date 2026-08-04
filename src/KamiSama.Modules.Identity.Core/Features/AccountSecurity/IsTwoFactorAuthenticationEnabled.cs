namespace KamiSama.Modules.Identity.Features.AccountSecurity;

[AutoInjectScoped<IIsTwoFactorAuthenticationEnabled>]
internal class IsTwoFactorAuthenticationEnabled(IUserManager userManager) : IIsTwoFactorAuthenticationEnabled
{
	public async Task<bool> IsEnabledAsync(Guid userId, CancellationToken cancellationToken)
	{
		var user = await userManager.FindByIdAsync(userManager.ConvertId(userId), cancellationToken)
			?? throw new NotFoundException<ApplicationUser>(userId, nameof(userId));

		return await userManager.GetTwoFactorEnabledAsync(user);
	}
}
