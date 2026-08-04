namespace KamiSama.Modules.Identity.Features.Users;

[AutoInjectScoped<IEnableUser>]
internal class EnableUser(
	ILogger<EnableUser> logger,
	IUserManager userManager) : IEnableUser
{
	public async Task EnableUserAsync(Guid userId, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();

		var user = await userManager.FindByIdAsync(userManager.ConvertId(userId), cancellationToken) ?? throw new NotFoundException<ApplicationUser>(userId, nameof(userId));

		await userManager.SetLockoutEndDateAsync(user, null);            // clear lock
		await userManager.ResetAccessFailedCountAsync(user);             // optional
		await userManager.UpdateSecurityStampAsync(user);
	}
}
